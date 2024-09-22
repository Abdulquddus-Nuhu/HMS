using Alansar.Core.Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Alansar.Data
{
    public class TenantFilter
    {
    }


    public static class TenantModelBuilderExtensions
    {
        public static ModelBuilder ApplyTenantQueryFilter(this ModelBuilder modelBuilder, string tenantId)
        {
            foreach (var entityType in modelBuilder.Model.GetEntityTypes())
            {
                // Check if the entity implements ITenant
                if (!typeof(ITenant).IsAssignableFrom(entityType.ClrType))
                {
                    continue;
                }

                var param = Expression.Parameter(entityType.ClrType, "entity");
                var tenantIdProperty = Expression.PropertyOrField(param, nameof(ITenant.TenantKey));

                // Create expression to filter by TenantId
                var tenantIdFilter = Expression.Equal(tenantIdProperty, Expression.Constant(tenantId, typeof(string)));
                var tenantFilterLambda = Expression.Lambda(tenantIdFilter, param);

                // Apply the filter to the entity
                entityType.SetQueryFilter(tenantFilterLambda);
            }

            return modelBuilder;
        }
    }










    public static class SoftDeleteModelBuilderExtensions
    {
        public static ModelBuilder ApplySoftDeleteQueryFilter(this ModelBuilder modelBuilder)
        {
            foreach (var entityType in modelBuilder.Model.GetEntityTypes())
            {
                if (!typeof(ITenant).IsAssignableFrom(entityType.ClrType))
                {
                    continue;
                }

                var param = Expression.Parameter(entityType.ClrType, "entity");
                var prop = Expression.PropertyOrField(param, nameof(ITenant.TenantKey));
                var entityNotDeleted = Expression.Lambda(Expression.Equal(prop, Expression.Constant(false)), param);

                entityType.SetQueryFilter(entityNotDeleted);
            }

            return modelBuilder;
        }
    }

}
