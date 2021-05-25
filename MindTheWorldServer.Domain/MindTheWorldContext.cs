using Microsoft.EntityFrameworkCore;

namespace MindTheWorldServer.Domain
{
    public partial class MindTheWorldContext : DbContext
    {
        public MindTheWorldContext()
        {
        }

        public MindTheWorldContext(DbContextOptions<MindTheWorldContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Co2EmissionsPerPerson> Co2EmissionsPerPeople { get; set; }
        public virtual DbSet<CoalConsumption> CoalConsumptions { get; set; }
        public virtual DbSet<Country> Countries { get; set; }
        public virtual DbSet<EpidemicDeath> EpidemicDeaths { get; set; }
        public virtual DbSet<GrossDomesticProduct> GrossDomesticProducts { get; set; }
        public virtual DbSet<HappinessScore> HappinessScores { get; set; }
        public virtual DbSet<HumanDevelopmentIndex> HumanDevelopmentIndexes { get; set; }
        public virtual DbSet<InfantMortality> InfantMortalities { get; set; }
        public virtual DbSet<LiteracyRateAdultTotal> LiteracyRateAdultTotals { get; set; }
        public virtual DbSet<MaterialFootprintPerCapitum> MaterialFootprintPerCapita { get; set; }
        public virtual DbSet<OilConsumption> OilConsumptions { get; set; }
        public virtual DbSet<Population> Populations { get; set; }
        public virtual DbSet<RenewableWater> RenewableWaters { get; set; }
        public virtual DbSet<ResidentialElectricityUse> ResidentialElectricityUses { get; set; }
        public virtual DbSet<WaterSourceAccess> WaterSourceAccesses { get; set; }
        public virtual DbSet<WaterWithdrawlPerPerson> WaterWithdrawlPerPeople { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Data Source=localhost;Initial Catalog=MindTheWorld;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Co2EmissionsPerPerson>(entity =>
            {
                entity.HasKey(e => new { e.CountryId, e.Year })
                    .HasName("PK_CO2EPP_ID");

                entity.ToTable("Co2EmissionsPerPerson");

                entity.Property(e => e.Value).HasColumnType("decimal(10, 6)");

                entity.HasOne(d => d.Country)
                    .WithMany(p => p.Co2EmissionsPerPeople)
                    .HasForeignKey(d => d.CountryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CO2EPP_CountryId");
            });

            modelBuilder.Entity<CoalConsumption>(entity =>
            {
                entity.HasKey(e => new { e.CountryId, e.Year })
                    .HasName("PK_CC_ID");

                entity.ToTable("CoalConsumption");

                entity.Property(e => e.Value).HasColumnType("decimal(18, 6)");

                entity.HasOne(d => d.Country)
                    .WithMany(p => p.CoalConsumptions)
                    .HasForeignKey(d => d.CountryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CC_CountryId");
            });

            modelBuilder.Entity<Country>(entity =>
            {
                entity.ToTable("Country");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<EpidemicDeath>(entity =>
            {
                entity.HasKey(e => new { e.CountryId, e.Year })
                    .HasName("PK_ED_ID");

                entity.ToTable("EpidemicDeath");

                entity.HasOne(d => d.Country)
                    .WithMany(p => p.EpidemicDeaths)
                    .HasForeignKey(d => d.CountryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ED_CountryId");
            });

            modelBuilder.Entity<GrossDomesticProduct>(entity =>
            {
                entity.HasKey(e => new { e.CountryId, e.Year })
                    .HasName("PK_GDP_ID");

                entity.ToTable("GrossDomesticProduct");

                entity.Property(e => e.Value).HasColumnType("decimal(10, 6)");

                entity.HasOne(d => d.Country)
                    .WithMany(p => p.GrossDomesticProducts)
                    .HasForeignKey(d => d.CountryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_GDP_CountryId");
            });

            modelBuilder.Entity<HappinessScore>(entity =>
            {
                entity.HasKey(e => new { e.CountryId, e.Year })
                    .HasName("PK_HS_ID");

                entity.ToTable("HappinessScore");

                entity.Property(e => e.Value).HasColumnType("decimal(10, 6)");

                entity.HasOne(d => d.Country)
                    .WithMany(p => p.HappinessScores)
                    .HasForeignKey(d => d.CountryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_HS_CountryId");
            });

            modelBuilder.Entity<HumanDevelopmentIndex>(entity =>
            {
                entity.HasKey(e => new { e.CountryId, e.Year })
                    .HasName("PK_HDI_ID");

                entity.ToTable("HumanDevelopmentIndex");

                entity.Property(e => e.Value).HasColumnType("decimal(10, 6)");

                entity.HasOne(d => d.Country)
                    .WithMany(p => p.HumanDevelopmentIndices)
                    .HasForeignKey(d => d.CountryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_HDI_CountryId");
            });

            modelBuilder.Entity<InfantMortality>(entity =>
            {
                entity.HasKey(e => new { e.CountryId, e.Year })
                    .HasName("PK_IM_ID");

                entity.ToTable("InfantMortality");

                entity.Property(e => e.Value).HasColumnType("decimal(10, 6)");

                entity.HasOne(d => d.Country)
                    .WithMany(p => p.InfantMortalities)
                    .HasForeignKey(d => d.CountryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_IM_CountryId");
            });

            modelBuilder.Entity<LiteracyRateAdultTotal>(entity =>
            {
                entity.HasKey(e => new { e.CountryId, e.Year })
                    .HasName("PK_LRAT_ID");

                entity.ToTable("LiteracyRateAdultTotal");

                entity.Property(e => e.Value).HasColumnType("decimal(10, 6)");

                entity.HasOne(d => d.Country)
                    .WithMany(p => p.LiteracyRateAdultTotals)
                    .HasForeignKey(d => d.CountryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_LRAT_CountryId");
            });

            modelBuilder.Entity<MaterialFootprintPerCapitum>(entity =>
            {
                entity.HasKey(e => new { e.CountryId, e.Year })
                    .HasName("PK_MFPC_ID");

                entity.Property(e => e.Value).HasColumnType("decimal(10, 6)");

                entity.HasOne(d => d.Country)
                    .WithMany(p => p.MaterialFootprintPerCapita)
                    .HasForeignKey(d => d.CountryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_MFPC_CountryId");
            });

            modelBuilder.Entity<OilConsumption>(entity =>
            {
                entity.HasKey(e => new { e.CountryId, e.Year })
                    .HasName("PK_OC_ID");

                entity.ToTable("OilConsumption");

                entity.Property(e => e.Value).HasColumnType("decimal(18, 6)");

                entity.HasOne(d => d.Country)
                    .WithMany(p => p.OilConsumptions)
                    .HasForeignKey(d => d.CountryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_OC_CountryId");
            });

            modelBuilder.Entity<Population>(entity =>
            {
                entity.HasKey(e => new { e.CountryId, e.Year })
                    .HasName("PK_PPL_ID");

                entity.ToTable("Population");

                entity.HasOne(d => d.Country)
                    .WithMany(p => p.Populations)
                    .HasForeignKey(d => d.CountryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PPL_CountryId");
            });

            modelBuilder.Entity<RenewableWater>(entity =>
            {
                entity.HasKey(e => new { e.CountryId, e.Year })
                    .HasName("PK_RW_ID");

                entity.ToTable("RenewableWater");

                entity.Property(e => e.Value).HasColumnType("decimal(18, 6)");

                entity.HasOne(d => d.Country)
                    .WithMany(p => p.RenewableWaters)
                    .HasForeignKey(d => d.CountryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_RW_CountryId");
            });

            modelBuilder.Entity<ResidentialElectricityUse>(entity =>
            {
                entity.HasKey(e => new { e.CountryId, e.Year })
                    .HasName("PK_REU_ID");

                entity.ToTable("ResidentialElectricityUse");

                entity.Property(e => e.Value).HasColumnType("decimal(18, 6)");

                entity.HasOne(d => d.Country)
                    .WithMany(p => p.ResidentialElectricityUses)
                    .HasForeignKey(d => d.CountryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_REU_CountryId");
            });

            modelBuilder.Entity<WaterSourceAccess>(entity =>
            {
                entity.HasKey(e => new { e.CountryId, e.Year })
                    .HasName("PK_WSA_ID");

                entity.ToTable("WaterSourceAccess");

                entity.Property(e => e.Value).HasColumnType("decimal(10, 6)");

                entity.HasOne(d => d.Country)
                    .WithMany(p => p.WaterSourceAccesses)
                    .HasForeignKey(d => d.CountryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_WSA_CountryId");
            });

            modelBuilder.Entity<WaterWithdrawlPerPerson>(entity =>
            {
                entity.HasKey(e => new { e.CountryId, e.Year })
                    .HasName("PK_WWPP_ID");

                entity.ToTable("WaterWithdrawlPerPerson");

                entity.Property(e => e.Value).HasColumnType("decimal(18, 6)");

                entity.HasOne(d => d.Country)
                    .WithMany(p => p.WaterWithdrawlPerPeople)
                    .HasForeignKey(d => d.CountryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_WWPP_CountryId");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
