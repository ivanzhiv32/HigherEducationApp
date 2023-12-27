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
        DbSet<YearReport> YearReports { get; set; }
        DbSet<Region> Regions { get; set; }
        DbSet<RegionReport> RegionReports { get; set; }
        DbSet<Institution> Institutions { get; set; }
        DbSet<InstitutionReport> InstitutionReports { get; set; }
        DbSet<UnitMeasure> UnitsMeasure { get; set; }
        DbSet<TypeIndicator> TypeIndicators { get; set; }
        DbSet<Indicator> Indicators { get; set; }
        DbSet<Ugn> Ugns { get; set; }
        DbSet<DistributionUgn> DistributionUgns { get; set; }
        DbSet<BranchScience> BranchesScience { get; set; }
        DbSet<DistributionBranches> DistributionBranches { get; set; }
        DbSet<VerificationResult> VerificationResults { get; set; }
        DbSet<Tonality> Tonalities { get; set; }
        DbSet<ReviewOfInstitution> ReviewsOfInstitution { get; set; }
        DbSet<User> Users { get; set; }
        DbSet<Admin> Admins { get; set; }
        DbSet<Applicant> Applicants { get; set; }
        DbSet<RepresentativeInstitution> RepresentativesInstitution { get; set; }

        public HigherEducationSystemDbContext(DbContextOptions options) : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySql(connectionString, new MySqlServerVersion(new Version(8, 0, 25)));
            //optionsBuilder.ConfigureWarnings(w => w.Ignore(CoreEventId.LazyLoadOnDisposedContextWarning));
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            /*Настройка связей между таблицами*/

            //user <-> applicant
            //user <-> representativeInstitution
            //user <-> admin
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
            modelBuilder.Entity<Region>()
                .HasMany(u => u.Institutions)
                .WithOne(m => m.Region)
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
            modelBuilder.Entity<InstitutionReport>()
                .HasMany(u => u.Indicators)
                .WithOne(m => m.InstitutionReport)
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
                .WithMany()
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
    }
}
