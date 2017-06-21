using Nop.Core;
using Nop.Data;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nop.Plugin.Widgets.DeliveryDiscount.Data
{
    public class DeliveryDiscountLabelObjectContext : DbContext, IDbContext
    {
        public bool ProxyCreationEnabled { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public bool AutoDetectChangesEnabled { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public DeliveryDiscountLabelObjectContext(string nameOrConnectionString) 
            : base(nameOrConnectionString)
        {

        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new DeliveryDiscountLabelMap());
            base.OnModelCreating(modelBuilder);
        }

        public string CreateDataBaseInstallationScript()
        {
            return (this as IObjectContextAdapter).ObjectContext.CreateDatabaseScript();
        }

        public void Install()
        {
            Database.SetInitializer<DeliveryDiscountLabelObjectContext>(null);
            Database.ExecuteSqlCommand(CreateDataBaseInstallationScript());
            SaveChanges();
        }

        public void Uninstall()
        {
            var dbScript = "DROP TABLE DeliveryDiscountLabels";
            Database.ExecuteSqlCommand(dbScript);
            SaveChanges();
        }

        public new  IDbSet<TEntity> Set<TEntity>() where TEntity: BaseEntity
        {
            return base.Set<TEntity>();
        }

        public IList<TEntity> ExecuteStoredProcedureList<TEntity>(string commandText, params object[] parameters) where TEntity : BaseEntity, new()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TElement> SqlQuery<TElement>(string sql, params object[] parameters)
        {
            throw new NotImplementedException();
        }

        public int ExecuteSqlCommand(string sql, bool doNotEnsureTransaction = false, int? timeout = default(int?), params object[] parameters)
        {
            throw new NotImplementedException();
        }

        public void Detach(object entity)
        {
            throw new NotImplementedException();
        }
    }
}
