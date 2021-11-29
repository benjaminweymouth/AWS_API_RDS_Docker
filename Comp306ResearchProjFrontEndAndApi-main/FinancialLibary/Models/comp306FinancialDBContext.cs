using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace FinancialLibary.Models
{
    public partial class comp306FinancialDBContext : DbContext
    {
        public comp306FinancialDBContext()
        {
        }

        public comp306FinancialDBContext(DbContextOptions<comp306FinancialDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<DbdataforStockVolatility> DbdataforStockVolatilities { get; set; }
        public virtual DbSet<SurveyInfoTable> SurveyInfoTables { get; set; }
        public virtual DbSet<SurveyInfoTable> SurveyInfoList { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                //optionsBuilder.UseSqlServer("Data Source=mssqlserver.ceoc7mqdaafd.us-east-1.rds.amazonaws.com;Initial Catalog=comp306FinancialDB; User ID=comp306researchdb;Password=dAtAbAsE123;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<DbdataforStockVolatility>(entity =>
            {
                entity.HasKey(e => e.StockIdTicker);

                entity.ToTable("DBdataforStockVolatility");

                entity.Property(e => e.StockIdTicker).HasMaxLength(50);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Sector)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.StockVolatility)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<SurveyInfoTable>(entity =>
            {
                entity.HasKey(e => e.SurveyId)
                    .HasName("PK__SurveyIn__A5481F7D20DAC19A");

                entity.ToTable("SurveyInfoTable");

                entity.Property(e => e.SurveyId)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("SurveyId"); 

                entity.Property(e => e.StockIdTicker)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.SurveyAmount)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.SurveyCryptoVsstocks)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("SurveyCryptoVSStocks");

                entity.Property(e => e.SurveyIndustry)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.SurveyPersonName)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.SurveyRiskTolerance)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("SurveyRiskTolerance");

                entity.HasOne(d => d.StockIdTickerNavigation)
                    .WithMany(p => p.SurveyInfoTables)
                    .HasForeignKey(d => d.StockIdTicker)
                    .HasConstraintName("FK_SurveyInfoTable_StockIdTicker");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
