﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace GRB.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class GoaRehabEntities : DbContext
    {
        public GoaRehabEntities()
            : base("name=GoaRehabEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<AnnouncementsTbl> AnnouncementsTbls { get; set; }
        public virtual DbSet<GoaRehabTbl> GoaRehabTbls { get; set; }
        public virtual DbSet<InmatesTbl> InmatesTbls { get; set; }
        public virtual DbSet<NewsTbl> NewsTbls { get; set; }
        public virtual DbSet<PicturesTbl> PicturesTbls { get; set; }
        public virtual DbSet<ProfileTbl> ProfileTbls { get; set; }
        public virtual DbSet<ProjectsTbl> ProjectsTbls { get; set; }
        public virtual DbSet<StaffTbl> StaffTbls { get; set; }
    }
}
