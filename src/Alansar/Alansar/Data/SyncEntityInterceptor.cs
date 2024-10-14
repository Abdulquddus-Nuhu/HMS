//using Alansar.Core.Entities.Identity;
//using Alansar.Core.Entities;
//using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
//using Microsoft.EntityFrameworkCore.Diagnostics;
//using Microsoft.EntityFrameworkCore;

//namespace Alansar.Data
//{
//    public class SyncEntityInterceptor : SaveChangesInterceptor
//    {
//        private readonly AppDbContext _appDbContext;
//        private readonly IdentityDbContext _identityContext;

//        public SyncEntityInterceptor(AppDbContext appDbContext, IdentityDbContext identityContext)
//        {
//            _appDbContext = appDbContext;
//            _identityContext = identityContext;
//        }



//        public override ValueTask<InterceptionResult<int>> SavingChangesAsync(DbContextEventData eventData, InterceptionResult<int> result, CancellationToken cancellationToken = default)
//        {
//            var context = eventData.Context;  // Get the DbContext instance
//            if (context is IdentityDbContext)
//            {
//                Console.WriteLine("Interceptor is working on IdentityDbContext.");
//                SyncIdentityChanges(eventData);  // Pass eventData instead of context
//            }

//            return base.SavingChangesAsync(eventData, result, cancellationToken);
//        }



//        private void SyncIdentityChanges(DbContextEventData eventData)
//        {
//            var identityEntries = eventData.Context.ChangeTracker.Entries()
//                .Where(e => e.Entity is User || e.Entity is Tenant);

//            foreach (var entry in identityEntries)
//            {
//                if (entry.State == EntityState.Added)
//                {
//                    // Sync to AppDbContext for added entity
//                    SyncAddEntity(entry.Entity);
//                }
//                else if (entry.State == EntityState.Modified)
//                {
//                    // Sync modifications to AppDbContext
//                    SyncUpdateEntity(entry.Entity);
//                }
//                else if (entry.State == EntityState.Deleted)
//                {
//                    // Sync deletions to AppDbContext
//                    SyncDeleteEntity(entry.Entity);
//                }
//            }
//        }

//        private void SyncAddEntity(object entity)
//        {
//            if (entity == null)
//            {
//                throw new ArgumentNullException(nameof(entity), "Entity cannot be null in SyncAddEntity.");
//            }

//            if (entity is User user)
//            {
//                var newUser = new User
//                {
//                    Id = user.Id,
//                    UserName = user.UserName,
//                    Email = user.Email,
//                    SecurityStamp = user.SecurityStamp,
//                    ConcurrencyStamp = user.ConcurrencyStamp,
//                    Created = user.Created,
//                    CreatedBy = user.CreatedBy,
//                    AccessFailedCount = user.AccessFailedCount,
//                    Deleted = user.Deleted,
//                    DeletedBy = user.DeletedBy,
//                    IsDeleted = user.IsDeleted,
//                    EmailConfirmed = user.EmailConfirmed,
//                    FirstName = user.FirstName,
//                    LastModifiedBy = user.LastModifiedBy,
//                    LastName = user.LastName,
//                    IsActive = user.IsActive,
//                    LockoutEnabled = user.LockoutEnabled,
//                    LockoutEnd = user.LockoutEnd,
//                    MiddleName = user.MiddleName,
//                    Modified = user.Modified,
//                    RoleType = user.RoleType,
//                    NormalizedEmail = user.NormalizedEmail,
//                    NormalizedUserName = user.NormalizedUserName,
//                    PasswordHash = user.PasswordHash,
//                    PhoneNumber = user.PhoneNumber,
//                    PhoneNumberConfirmed = user.PhoneNumberConfirmed,
//                    TenantKey = user.TenantKey,
//                    TwoFactorEnabled = user.TwoFactorEnabled,
//                    // map other fields as needed
//                };

//                // Ensure _appDbContext is not null
//                if (_appDbContext == null)
//                {
//                    throw new InvalidOperationException("AppDbContext is not initialized.");
//                }

//                _appDbContext.User.Add(newUser);
//            }
//            else if (entity is Tenant tenant)
//            {
//                var newTenant = new Tenant
//                {
//                    Id = tenant.Id,
//                    SchoolName = tenant.SchoolName,
//                    Created = tenant.Created,
//                    CreatedBy = tenant.CreatedBy,
//                    Deleted = tenant.Deleted,
//                    DeletedBy = tenant.DeletedBy,
//                    IsDeleted = tenant.IsDeleted,
//                    Email = tenant.Email,
//                    IsActive = tenant.IsActive,
//                    LastModifiedBy = tenant.LastModifiedBy,
//                    Modified = tenant.Modified,
//                };

//                if (_appDbContext == null)
//                {
//                    throw new InvalidOperationException("AppDbContext is not initialized.");
//                }

//                _appDbContext.Tenant.Add(newTenant);
//            }

//            _appDbContext.SaveChanges();
//        }

//        private void SyncUpdateEntity(object entity)
//        {
//            if (entity == null)
//            {
//                throw new ArgumentNullException(nameof(entity), "Entity cannot be null in SyncUpdateEntity.");
//            }

//            // Ensure _appDbContext is not null
//            if (_appDbContext == null)
//            {
//                throw new InvalidOperationException("AppDbContext is not initialized.");
//            }

//            if (entity is User user)
//            {
//                var existingUser = _appDbContext.User.FirstOrDefault(u => u.Id == user.Id);
//                if (existingUser != null)
//                {
//                    existingUser.LastModifiedBy = user.LastModifiedBy;
//                    existingUser.Modified = user.Modified;
//                    existingUser.PhoneNumber = user.PhoneNumber;
//                    existingUser.UserName = user.UserName;
//                    existingUser.Email = user.Email;
//                    existingUser.IsActive = user.IsActive;  
//                    existingUser.FirstName = user.FirstName;
//                    existingUser.LastName = user.LastName;


//                    _appDbContext.User.Update(existingUser);
//                }
//            }
//            else if (entity is Tenant tenant)
//            {
//                var existingTenant = _appDbContext.Tenant.FirstOrDefault(t => t.Id == tenant.Id);
//                if (existingTenant != null)
//                {
//                    existingTenant.SchoolName = tenant.SchoolName;
//                    // map other fields as needed
//                    _appDbContext.Tenant.Update(existingTenant);
//                }
//            }

//            _appDbContext.SaveChanges();
//        }

//        private void SyncDeleteEntity(object entity)
//        {
//            if (entity == null)
//            {
//                throw new ArgumentNullException(nameof(entity), "Entity cannot be null in SyncDeleteEntity.");
//            }

//            // Ensure _appDbContext is not null
//            if (_appDbContext == null)
//            {
//                throw new InvalidOperationException("AppDbContext is not initialized.");
//            }

//            if (entity is User user)
//            {
//                var existingUser = _appDbContext.User.FirstOrDefault(u => u.Id == user.Id);
//                if (existingUser != null)
//                {
//                    _appDbContext.User.Remove(existingUser);
//                }
//            }
//            else if (entity is Tenant tenant)
//            {
//                var existingTenant = _appDbContext.Tenant.FirstOrDefault(t => t.Id == tenant.Id);
//                if (existingTenant != null)
//                {
//                    _appDbContext.Tenant.Remove(existingTenant);
//                }
//            }

//            _appDbContext.SaveChanges();
//        }
//    }

//}
