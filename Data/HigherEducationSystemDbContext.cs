//using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
//using Castle.Core.Resource;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.Options;
using System.Reflection.Metadata;
using HigherEducationApp.Models;
using HigherEducationApp.Models.Users;
using System.ComponentModel.DataAnnotations.Schema;

namespace HigherEducationApp.Data
{
    public class HigherEducationSystemDbContext : DbContext
    {
        private string connectionString = "server=127.0.0.1;port=3306;username=root;password=dgiva4444;database=new_schema";
        public DbSet<LinkReady> LinksReady { get; set; }
        public DbSet<YearReport> YearReports { get; set; }
        public DbSet<Region> Regions { get; set; }
        public DbSet<RegionReport> RegionReports { get; set; }
        public DbSet<Institution> Institutions { get; set; }
        public DbSet<InstitutionReport> InstitutionReports { get; set; }
        public DbSet<UnitMeasure> UnitsMeasure { get; set; }
        public DbSet<TypeIndicator> TypeIndicators { get; set; }
        public DbSet<Indicator> Indicators { get; set; }
        public DbSet<Ugn> Ugns { get; set; }
        public DbSet<DistributionUgn> DistributionUgns { get; set; }
        public DbSet<BranchScience> BranchesScience { get; set; }
        public DbSet<DistributionBranches> DistributionBranches { get; set; }
        public DbSet<VerificationResult> VerificationResults { get; set; }
        public DbSet<Tonality> Tonalities { get; set; }
        public DbSet<ReviewOfInstitution> ReviewsOfInstitution { get; set; }
        //public DbSet<User> Users { get; set; }
        //public DbSet<Admin> Admins { get; set; }
        //public DbSet<Applicant> Applicants { get; set; }
        //public DbSet<RepresentativeInstitution> RepresentativesInstitution { get; set; }

        public HigherEducationSystemDbContext(DbContextOptions options) : base(options) { }

        public HigherEducationSystemDbContext()
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseSqlServer(connectionString);
            optionsBuilder.UseMySql(connectionString, new MySqlServerVersion(new Version(8, 0, 25)));
            //optionsBuilder.ConfigureWarnings(w => w.Ignore(CoreEventId.LazyLoadOnDisposedContextWarning));
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            /*Настройка связей между таблицами*/

            modelBuilder.Entity<LinkReady>();

            ////user <-> applicant
            //modelBuilder.Entity<Applicant>()
            //    .HasOne(u => u.User)
            //    .WithOne(m => m.Applicant)
            //    .HasForeignKey<User>();
            ////user <-> representativeInstitution
            //modelBuilder.Entity<RepresentativeInstitution>()
            //    .HasOne(u => u.User)
            //    .WithOne(m => m.RepresentativeInstitution)
            //    .HasForeignKey<User>();

            ////user <-> admin
            //modelBuilder.Entity<Admin>()
            //    .HasOne(u => u.User)
            //    .WithOne(m => m.Admin)
            //    .HasForeignKey<User>();
            //modelBuilder.Entity<User>().UseTptMappingStrategy<User>();

            //yearReports <-> institutionReports
            modelBuilder.Entity<YearReport>()
                .HasMany(u => u.InstitutionReports)
                .WithOne(m => m.Year)
                .HasForeignKey("id_year")
                .IsRequired();

            //yearReports <-> regionReport
            modelBuilder.Entity<YearReport>()
                .HasMany(u => u.RegionReports)
                .WithOne(m => m.YearReport)
                .HasForeignKey("id_year")
                .IsRequired();

            //regionReport <-> region
            modelBuilder.Entity<RegionReport>()
                .HasOne(u => u.Region)
                .WithMany(m => m.RegionReports)
                .HasForeignKey("id_region")
                .IsRequired();

            //region <-> institution
            //modelBuilder.Entity<Region>()
            //    .HasMany(u => u.Institutions)
            //    .WithOne(m => m.Region)
            //    .HasForeignKey("id_region")
            //    .IsRequired();
            modelBuilder.Entity<Institution>()
                .HasOne(u => u.Region)
                .WithMany(m => m.Institutions)
                .HasForeignKey("id_region")
                .IsRequired();

            //institution <-> institutionReport
            modelBuilder.Entity<Institution>()
                .HasMany(u => u.InstitutionReports)
                .WithOne(m => m.Institution)
                .HasForeignKey("id_institution")
                .IsRequired();

            //institution <-> verificationResult
            modelBuilder.Entity<Institution>()
                .HasMany(u => u.VerificationResults)
                .WithOne(m => m.Institution)
                .HasForeignKey("id_institution")
                .IsRequired();

            //institution <-> reviewOfInstitution
            modelBuilder.Entity<Institution>()
                .HasMany(u => u.Reviews)
                .WithOne(m => m.Institution)
                .HasForeignKey("id_institution")
                .IsRequired();

            //institution <-> distributionUgn
            modelBuilder.Entity<Institution>()
                .HasMany(u => u.Ugns)
                .WithOne(m => m.Institution)
                .HasForeignKey("id_institution")
                .IsRequired();

            //institutionReport <-> indicators
            //modelBuilder.Entity<InstitutionReport>()
            //    .HasMany(u => u.Indicators)
            //    .WithOne(m => m.InstitutionReport)
            //    .HasForeignKey("id_institution_report_year")
            //    .IsRequired();
            modelBuilder.Entity<Indicator>()
                .HasOne(c => c.InstitutionReport)
                .WithMany(c => c.Indicators)
                .HasForeignKey("id_institution_report_year")
                .IsRequired();

            //institutionReport <-> distributionBranches
            modelBuilder.Entity<InstitutionReport>()
                .HasMany(u => u.DistributionBranches)
                .WithOne(m => m.InstitutionReport)
                .HasForeignKey("id_institution_report_year")
                .IsRequired();

            //distributionBranches <-> branches
            modelBuilder.Entity<DistributionBranches>()
                .HasOne(u => u.BranchScience)
                .WithMany()
                .HasForeignKey("id_branches")
                .IsRequired();

            //indicators <-> typeIndicators
            modelBuilder.Entity<Indicator>()
                .HasOne(u => u.TypeIndicator)
                .WithMany(c => c.Indicators)
                .HasForeignKey("id_name_indicator")
                .IsRequired();

            //typeIndicators <-> unitsMeasure
            modelBuilder.Entity<TypeIndicator>()
                .HasOne(u => u.UnitMeasure)
                .WithMany()
                .HasForeignKey("id_unit_measure")
                .IsRequired();

            //reviewOfInstitution <-> tonality
            modelBuilder.Entity<ReviewOfInstitution>()
                .HasOne(u => u.Tonality)
                .WithMany()
                .HasForeignKey("id_tonality")
                .IsRequired();

            //distributionUgn <-> ugn
            modelBuilder.Entity<DistributionUgn>()
                .HasOne(u => u.Ugn)
                .WithMany()
                .HasForeignKey("id_ugn")
                .IsRequired();
        }
        public DbSet<HigherEducationApp.Models.RatingInstitution> RatingInstitution { get; set; }
    }
}
