﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace NetworkBase
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class NetworkBaseEntities : DbContext
    {
        public NetworkBaseEntities()
            : base("name=NetworkBaseEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Departments> Departments { get; set; }
        public virtual DbSet<DeviceNetworks> DeviceNetworks { get; set; }
        public virtual DbSet<Devices> Devices { get; set; }
        public virtual DbSet<Networks> Networks { get; set; }
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }
        public virtual DbSet<Users> Users { get; set; }
    
        public virtual int dbo_backup()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("dbo_backup");
        }
    }
}
