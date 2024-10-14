using Refit;

namespace Alansar.Client.ApiCalls
{
    public interface IStudentApi
    {
        [Get("/api/student/count")]
        Task<int> GetStudentCountAsync([Header("TenantId")] string tenantId, [Header("Role")] string role, [Header("Email")] string email);

        [Get("/api/diningspace/count")]
        Task<int> GetDiningSpaceCountAsync([Header("TenantId")] string tenantId, [Header("Role")] string role, [Header("Email")] string email);

        [Get("/api/room/count")]
        Task<int> GetRoomCountAsync([Header("TenantId")] string tenantId, [Header("Role")] string role, [Header("Email")] string email);
    }
}
