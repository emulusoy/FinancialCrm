﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace FinancialCrm.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class FinancialCrmDbEntities : DbContext
    {
        public FinancialCrmDbEntities()
            : base("name=FinancialCrmDbEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }
        public virtual DbSet<TblBank> TblBank { get; set; }
        public virtual DbSet<TblBankProcess> TblBankProcess { get; set; }
        public virtual DbSet<TblBill> TblBill { get; set; }
        public virtual DbSet<TblCategory> TblCategory { get; set; }
        public virtual DbSet<TblSpending> TblSpending { get; set; }
        public virtual DbSet<TblUser> TblUser { get; set; }
    }
}