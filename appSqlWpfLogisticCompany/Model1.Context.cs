//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace appSqlWpfLogisticCompany
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class LogisticCompanyDB2Entities : DbContext
    {
        public LogisticCompanyDB2Entities()
            : base("name=LogisticCompanyDB2Entities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Category_Trailer> Category_Trailer { get; set; }
        public virtual DbSet<Consignees> Consignees { get; set; }
        public virtual DbSet<Drivers> Drivers { get; set; }
        public virtual DbSet<Executors> Executors { get; set; }
        public virtual DbSet<Requests> Requests { get; set; }
        public virtual DbSet<Shippers> Shippers { get; set; }
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }
        public virtual DbSet<Users> Users { get; set; }
        public virtual DbSet<Users_Gender> Users_Gender { get; set; }
        public virtual DbSet<Users_Photo> Users_Photo { get; set; }
        public virtual DbSet<Users_Roles> Users_Roles { get; set; }
        public virtual DbSet<Vehicles> Vehicles { get; set; }
    }
}
