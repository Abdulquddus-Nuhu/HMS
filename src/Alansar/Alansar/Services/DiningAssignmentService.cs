using Alansar.Data;
using Alansar.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace Alansar.Services
{
    public class DiningAssignmentService : IHostedService, IDisposable
    {
        private readonly IServiceProvider _serviceProvider;
        private Timer _timer;

        public DiningAssignmentService(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            // Start the timer to run every 14 days (two weeks)
            //_timer = new Timer(AssignStudents, null, TimeSpan.Zero, TimeSpan.FromDays(14));
            //while (true)
            //{
            //    _timer = new Timer(AssignStudents, null, TimeSpan.Zero, TimeSpan.FromSeconds(15));
            //}
            _timer = new Timer(AssignStudents, null, TimeSpan.Zero, TimeSpan.FromSeconds(15));
            return Task.CompletedTask;
        }

        private async void AssignStudents(object state)
        {
            using (var scope = _serviceProvider.CreateScope())
            {
                var context = scope.ServiceProvider.GetRequiredService<AppDbContext>();
                var students = await context.Students.ToListAsync();
                var diningSpaces = await context.DiningSpaces.ToListAsync();

                var assignments = new List<DiningAssignment>();
                var startDate = DateTime.UtcNow.Date;
                var endDate = startDate.AddDays(14);
                //var endDate = startDate.AddMilliseconds(1400);

                // Example: Randomly assign students to dining spaces
                var random = new Random();
                foreach (var student in students)
                {
                    var diningSpace = diningSpaces[random.Next(diningSpaces.Count)];
                    assignments.Add(new DiningAssignment
                    {
                        StudentId = student.Id,
                        DiningSpaceId = diningSpace.Id,
                        StartDate = startDate,
                        EndDate = endDate
                    });
                }

                context.DiningAssignments.AddRange(assignments);
                await context.SaveChangesAsync();
            }
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            _timer?.Change(Timeout.Infinite, 0);
            return Task.CompletedTask;
        }

        public void Dispose()
        {
            _timer?.Dispose();
        }
    }

}
