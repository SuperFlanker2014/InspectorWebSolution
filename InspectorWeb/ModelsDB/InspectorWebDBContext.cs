using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace InspectorWeb.ModelsDB
{
    public partial class InspectorWebDBContext : DbContext
    {
        public InspectorWebDBContext(DbContextOptions<InspectorWebDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<DirBanks> DirBanks { get; set; }
        public virtual DbSet<DirClientTypes> DirClientTypes { get; set; }
        public virtual DbSet<DirCountries> DirCountries { get; set; }
        public virtual DbSet<DirDiaseasesStates> DirDiaseasesStates { get; set; }
        public virtual DbSet<DirDiseases> DirDiseases { get; set; }
        public virtual DbSet<DirDiseasesCounts> DirDiseasesCounts { get; set; }
        public virtual DbSet<DirDiseasesGroups> DirDiseasesGroups { get; set; }
        public virtual DbSet<DirExaminationMethods> DirExaminationMethods { get; set; }
        public virtual DbSet<DirExaminations> DirExaminations { get; set; }
        public virtual DbSet<DirGoods> DirGoods { get; set; }
        public virtual DbSet<DirGoodsExams> DirGoodsExams { get; set; }
        public virtual DbSet<DirGoodsGroups> DirGoodsGroups { get; set; }
        public virtual DbSet<DirGoodsGroupsCategories> DirGoodsGroupsCategories { get; set; }
        public virtual DbSet<DirInvoiceTypes> DirInvoiceTypes { get; set; }
        public virtual DbSet<DirMarkTypes> DirMarkTypes { get; set; }
        public virtual DbSet<DirObjectsCategories> DirObjectsCategories { get; set; }
        public virtual DbSet<DirOrganizations> DirOrganizations { get; set; }
        public virtual DbSet<DirPlacesUnits> DirPlacesUnits { get; set; }
        public virtual DbSet<DirQualityTypes> DirQualityTypes { get; set; }
        public virtual DbSet<DirRegionsDistricts> DirRegionsDistricts { get; set; }
        public virtual DbSet<DirSamplesActions> DirSamplesActions { get; set; }
        public virtual DbSet<DirSamplesExaminations> DirSamplesExaminations { get; set; }
        public virtual DbSet<DirServices> DirServices { get; set; }
        public virtual DbSet<DirServicesBillsPatterns> DirServicesBillsPatterns { get; set; }
        public virtual DbSet<DirServicesGroups> DirServicesGroups { get; set; }
        public virtual DbSet<DirServicesPatterns> DirServicesPatterns { get; set; }
        public virtual DbSet<DirServicesSumFactors> DirServicesSumFactors { get; set; }
        public virtual DbSet<DirServicesUnits> DirServicesUnits { get; set; }
        public virtual DbSet<DirTextInspections> DirTextInspections { get; set; }
        public virtual DbSet<DirTextObjectTargetType> DirTextObjectTargetType { get; set; }
        public virtual DbSet<DirTextSamplesSourceTypes> DirTextSamplesSourceTypes { get; set; }
        public virtual DbSet<DirTextVerdictPatterns> DirTextVerdictPatterns { get; set; }
        public virtual DbSet<DirTextWoodCompositions> DirTextWoodCompositions { get; set; }
        public virtual DbSet<DirTransportTypes> DirTransportTypes { get; set; }
        public virtual DbSet<DirUnits> DirUnits { get; set; }
        public virtual DbSet<DirUnitsGroups> DirUnitsGroups { get; set; }
        public virtual DbSet<DirUnitsGroupsDiseases> DirUnitsGroupsDiseases { get; set; }
        public virtual DbSet<DirUsers> DirUsers { get; set; }
        public virtual DbSet<DirWeightUnits> DirWeightUnits { get; set; }
        public virtual DbSet<DocsActs> DocsActs { get; set; }
        public virtual DbSet<DocsAgreements> DocsAgreements { get; set; }
        public virtual DbSet<DocsAll> DocsAll { get; set; }
        public virtual DbSet<DocsBills> DocsBills { get; set; }
        public virtual DbSet<DocsBillsServices> DocsBillsServices { get; set; }
        public virtual DbSet<DocsClients> DocsClients { get; set; }
        public virtual DbSet<DocsConclusionsExamination> DocsConclusionsExamination { get; set; }
        public virtual DbSet<DocsConclusionsExport> DocsConclusionsExport { get; set; }
        public virtual DbSet<DocsConclusionsImport> DocsConclusionsImport { get; set; }
        public virtual DbSet<DocsConclusionsObjects> DocsConclusionsObjects { get; set; }
        public virtual DbSet<DocsExaminationTasks> DocsExaminationTasks { get; set; }
        public virtual DbSet<DocsExaminationTasksExaminations> DocsExaminationTasksExaminations { get; set; }
        public virtual DbSet<DocsGoods> DocsGoods { get; set; }
        public virtual DbSet<DocsGoodsDiseases> DocsGoodsDiseases { get; set; }
        public virtual DbSet<DocsUnits> DocsUnits { get; set; }
        public virtual DbSet<DocsUnitsDiseases> DocsUnitsDiseases { get; set; }
        public virtual DbSet<DocsUnitsExaminations> DocsUnitsExaminations { get; set; }
        public virtual DbSet<DocsWithGoods> DocsWithGoods { get; set; }
        public virtual DbSet<SecAccessMatrix> SecAccessMatrix { get; set; }
        public virtual DbSet<SecAppObjects> SecAppObjects { get; set; }
        public virtual DbSet<SecAppObjectsTypes> SecAppObjectsTypes { get; set; }
        public virtual DbSet<SecObjects> SecObjects { get; set; }
        public virtual DbSet<SecOperations> SecOperations { get; set; }
        public virtual DbSet<SecPermissions> SecPermissions { get; set; }
        public virtual DbSet<SecSubjects> SecSubjects { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=localhost;Database=InspectorWebDB;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.6-servicing-10079");

            modelBuilder.Entity<DirBanks>(entity =>
            {
                entity.HasKey(e => e.Guid);

                entity.ToTable("dirBanks");

                entity.Property(e => e.Guid)
                    .HasColumnName("guid")
                    .ValueGeneratedNever();

                entity.Property(e => e.Adress)
                    .HasColumnName("adress")
                    .HasMaxLength(200);

                entity.Property(e => e.Bik)
                    .IsRequired()
                    .HasColumnName("bik")
                    .HasMaxLength(20);

                entity.Property(e => e.City)
                    .HasColumnName("city")
                    .HasMaxLength(50);

                entity.Property(e => e.CorrAcc)
                    .HasColumnName("corr_acc")
                    .HasMaxLength(20);

                entity.Property(e => e.Title)
                    .HasColumnName("title")
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<DirClientTypes>(entity =>
            {
                entity.HasKey(e => e.Guid);

                entity.ToTable("dirClientTypes");

                entity.Property(e => e.Guid)
                    .HasColumnName("guid")
                    .ValueGeneratedNever();

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasColumnName("title")
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<DirCountries>(entity =>
            {
                entity.HasKey(e => e.Guid);

                entity.ToTable("dirCountries");

                entity.Property(e => e.Guid)
                    .HasColumnName("guid")
                    .ValueGeneratedNever();

                entity.Property(e => e.In)
                    .HasColumnName("in")
                    .HasMaxLength(50);

                entity.Property(e => e.IsRussia).HasColumnName("is_russia");

                entity.Property(e => e.Out)
                    .HasColumnName("out")
                    .HasMaxLength(50);

                entity.Property(e => e.Sert)
                    .HasColumnName("sert")
                    .HasMaxLength(500);

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasColumnName("title")
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<DirDiaseasesStates>(entity =>
            {
                entity.HasKey(e => e.Guid);

                entity.ToTable("dirDiaseasesStates");

                entity.Property(e => e.Guid)
                    .HasColumnName("guid")
                    .ValueGeneratedNever();

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasColumnName("title")
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<DirDiseases>(entity =>
            {
                entity.HasKey(e => e.Guid);

                entity.ToTable("dirDiseases");

                entity.Property(e => e.Guid)
                    .HasColumnName("guid")
                    .ValueGeneratedNever();

                entity.Property(e => e.ExaminationGuid).HasColumnName("examination_guid");

                entity.Property(e => e.GroupGuid).HasColumnName("group_guid");

                entity.Property(e => e.IsKarantin).HasColumnName("is_karantin");

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasColumnName("title")
                    .HasMaxLength(100);

                entity.Property(e => e.TitleLatin)
                    .HasColumnName("title_latin")
                    .HasMaxLength(100);

                entity.HasOne(d => d.ExaminationGu)
                    .WithMany(p => p.DirDiseases)
                    .HasForeignKey(d => d.ExaminationGuid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_dirDiseases_dirExaminations");

                entity.HasOne(d => d.GroupGu)
                    .WithMany(p => p.DirDiseases)
                    .HasForeignKey(d => d.GroupGuid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_dirDiseases_dirDiseasesGroups");
            });

            modelBuilder.Entity<DirDiseasesCounts>(entity =>
            {
                entity.HasKey(e => e.Guid);

                entity.ToTable("dirDiseasesCounts");

                entity.Property(e => e.Guid)
                    .HasColumnName("guid")
                    .ValueGeneratedNever();

                entity.Property(e => e.Title)
                    .HasColumnName("title")
                    .HasMaxLength(20);
            });

            modelBuilder.Entity<DirDiseasesGroups>(entity =>
            {
                entity.HasKey(e => e.Guid);

                entity.ToTable("dirDiseasesGroups");

                entity.Property(e => e.Guid)
                    .HasColumnName("guid")
                    .ValueGeneratedNever();

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasColumnName("title")
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<DirExaminationMethods>(entity =>
            {
                entity.HasKey(e => e.Guid);

                entity.ToTable("dirExaminationMethods");

                entity.Property(e => e.Guid)
                    .HasColumnName("guid")
                    .ValueGeneratedNever();

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasColumnName("title")
                    .HasMaxLength(500);
            });

            modelBuilder.Entity<DirExaminations>(entity =>
            {
                entity.HasKey(e => e.Guid);

                entity.ToTable("dirExaminations");

                entity.Property(e => e.Guid)
                    .HasColumnName("guid")
                    .ValueGeneratedNever();

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasColumnName("title")
                    .HasMaxLength(30);
            });

            modelBuilder.Entity<DirGoods>(entity =>
            {
                entity.HasKey(e => e.Guid);

                entity.ToTable("dirGoods");

                entity.Property(e => e.Guid)
                    .HasColumnName("guid")
                    .ValueGeneratedNever();

                entity.Property(e => e.GroupGuid).HasColumnName("group_guid");

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasColumnName("title")
                    .HasMaxLength(50);

                entity.HasOne(d => d.GroupGu)
                    .WithMany(p => p.DirGoods)
                    .HasForeignKey(d => d.GroupGuid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_dirGoods_dirGoodsGroups");
            });

            modelBuilder.Entity<DirGoodsExams>(entity =>
            {
                entity.HasKey(e => e.Guid);

                entity.ToTable("dirGoodsExams");

                entity.Property(e => e.Guid)
                    .HasColumnName("guid")
                    .ValueGeneratedNever();

                entity.Property(e => e.ExaminationGuid).HasColumnName("examination_guid");

                entity.Property(e => e.GroupGuid).HasColumnName("group_guid");

                entity.HasOne(d => d.ExaminationGu)
                    .WithMany(p => p.DirGoodsExams)
                    .HasForeignKey(d => d.ExaminationGuid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_dirGoodsExams_dirExaminations");

                entity.HasOne(d => d.GroupGu)
                    .WithMany(p => p.DirGoodsExams)
                    .HasForeignKey(d => d.GroupGuid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_dirGoodsExams_dirGoodsGroups");
            });

            modelBuilder.Entity<DirGoodsGroups>(entity =>
            {
                entity.HasKey(e => e.Guid);

                entity.ToTable("dirGoodsGroups");

                entity.Property(e => e.Guid)
                    .HasColumnName("guid")
                    .ValueGeneratedNever();

                entity.Property(e => e.CategoryGuid).HasColumnName("category_guid");

                entity.Property(e => e.IsForest).HasColumnName("is_forest");

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasColumnName("title")
                    .HasMaxLength(50);

                entity.Property(e => e.WeightUnitGuid).HasColumnName("weight_unit_guid");

                entity.HasOne(d => d.CategoryGu)
                    .WithMany(p => p.DirGoodsGroups)
                    .HasForeignKey(d => d.CategoryGuid)
                    .HasConstraintName("FK_dirGoodsGroups_dirGoodsGroupsCategories");

                entity.HasOne(d => d.WeightUnitGu)
                    .WithMany(p => p.DirGoodsGroups)
                    .HasForeignKey(d => d.WeightUnitGuid)
                    .HasConstraintName("FK_dirGoodsGroups_dirWeightUnits");
            });

            modelBuilder.Entity<DirGoodsGroupsCategories>(entity =>
            {
                entity.HasKey(e => e.Guid);

                entity.ToTable("dirGoodsGroupsCategories");

                entity.Property(e => e.Guid)
                    .HasColumnName("guid")
                    .ValueGeneratedNever();

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasColumnName("title")
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<DirInvoiceTypes>(entity =>
            {
                entity.HasKey(e => e.Guid);

                entity.ToTable("dirInvoiceTypes");

                entity.Property(e => e.Guid)
                    .HasColumnName("guid")
                    .ValueGeneratedNever();

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasColumnName("title")
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<DirMarkTypes>(entity =>
            {
                entity.HasKey(e => e.Guid);

                entity.ToTable("dirMarkTypes");

                entity.Property(e => e.Guid)
                    .HasColumnName("guid")
                    .ValueGeneratedNever();

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasColumnName("title")
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<DirObjectsCategories>(entity =>
            {
                entity.HasKey(e => e.Guid);

                entity.ToTable("dirObjectsCategories");

                entity.Property(e => e.Guid)
                    .HasColumnName("guid")
                    .ValueGeneratedNever();

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasColumnName("title")
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<DirOrganizations>(entity =>
            {
                entity.HasKey(e => e.Guid);

                entity.ToTable("dirOrganizations");

                entity.Property(e => e.Guid)
                    .HasColumnName("guid")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.Accountant)
                    .HasColumnName("accountant")
                    .HasMaxLength(150);

                entity.Property(e => e.Addressee)
                    .HasColumnName("addressee")
                    .HasMaxLength(500);

                entity.Property(e => e.Adress)
                    .HasColumnName("adress")
                    .HasMaxLength(500);

                entity.Property(e => e.AgreementNote).HasColumnName("agreement_note");

                entity.Property(e => e.BankBik)
                    .HasColumnName("bank_bik")
                    .HasMaxLength(12);

                entity.Property(e => e.BankCaccount)
                    .HasColumnName("bank_caccount")
                    .HasColumnType("numeric(20, 0)");

                entity.Property(e => e.BankCity)
                    .HasColumnName("bank_city")
                    .HasMaxLength(100);

                entity.Property(e => e.BankSaccount)
                    .HasColumnName("bank_saccount")
                    .HasColumnType("numeric(20, 0)");

                entity.Property(e => e.BankTitle)
                    .HasColumnName("bank_title")
                    .HasMaxLength(200);

                entity.Property(e => e.Director)
                    .HasColumnName("director")
                    .HasMaxLength(150);

                entity.Property(e => e.DirectorDivKarantin)
                    .HasColumnName("director_div_karantin")
                    .HasMaxLength(150);

                entity.Property(e => e.Fax)
                    .HasColumnName("fax")
                    .HasMaxLength(50);

                entity.Property(e => e.Inn)
                    .HasColumnName("inn")
                    .HasMaxLength(12);

                entity.Property(e => e.Kpp)
                    .HasColumnName("kpp")
                    .HasColumnType("numeric(9, 0)");

                entity.Property(e => e.ParentGuid).HasColumnName("parent_guid");

                entity.Property(e => e.PaymentAdressee)
                    .HasColumnName("payment_adressee")
                    .HasMaxLength(500);

                entity.Property(e => e.PaymentTarget)
                    .HasColumnName("payment_target")
                    .HasMaxLength(500);

                entity.Property(e => e.RegionNumber)
                    .IsRequired()
                    .HasColumnName("region_number")
                    .HasMaxLength(2);

                entity.Property(e => e.Telephone)
                    .HasColumnName("telephone")
                    .HasMaxLength(50);

                entity.Property(e => e.Title)
                    .HasColumnName("title")
                    .HasMaxLength(500);

                entity.Property(e => e.TitleShort)
                    .HasColumnName("title_short")
                    .HasMaxLength(200);

                entity.HasOne(d => d.ParentGu)
                    .WithMany(p => p.InverseParentGu)
                    .HasForeignKey(d => d.ParentGuid)
                    .HasConstraintName("FK_dirOrganizations_dirOrganizations");
            });

            modelBuilder.Entity<DirPlacesUnits>(entity =>
            {
                entity.HasKey(e => e.Guid);

                entity.ToTable("dirPlacesUnits");

                entity.Property(e => e.Guid)
                    .HasColumnName("guid")
                    .ValueGeneratedNever();

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasColumnName("title")
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<DirQualityTypes>(entity =>
            {
                entity.HasKey(e => e.Guid);

                entity.ToTable("dirQualityTypes");

                entity.Property(e => e.Guid)
                    .HasColumnName("guid")
                    .ValueGeneratedNever();

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasColumnName("title")
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<DirRegionsDistricts>(entity =>
            {
                entity.HasKey(e => e.Guid);

                entity.ToTable("dirRegionsDistricts");

                entity.Property(e => e.Guid)
                    .HasColumnName("guid")
                    .ValueGeneratedNever();

                entity.Property(e => e.RegionGuid).HasColumnName("region_guid");

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasColumnName("title")
                    .HasMaxLength(50);

                entity.HasOne(d => d.RegionGu)
                    .WithMany(p => p.DirRegionsDistricts)
                    .HasForeignKey(d => d.RegionGuid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_dirRegionsDistricts_dirCountries");
            });

            modelBuilder.Entity<DirSamplesActions>(entity =>
            {
                entity.HasKey(e => e.Guid);

                entity.ToTable("dirSamplesActions");

                entity.Property(e => e.Guid)
                    .HasColumnName("guid")
                    .ValueGeneratedNever();

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasColumnName("title")
                    .HasMaxLength(150);
            });

            modelBuilder.Entity<DirSamplesExaminations>(entity =>
            {
                entity.HasKey(e => e.Guid);

                entity.ToTable("dirSamplesExaminations");

                entity.Property(e => e.Guid)
                    .HasColumnName("guid")
                    .ValueGeneratedNever();

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasColumnName("title")
                    .HasMaxLength(500);

                entity.Property(e => e.TypeGuid).HasColumnName("typeGuid");

                entity.HasOne(d => d.TypeGu)
                    .WithMany(p => p.DirSamplesExaminations)
                    .HasForeignKey(d => d.TypeGuid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_dirSamplesExaminations_dirExaminations");
            });

            modelBuilder.Entity<DirServices>(entity =>
            {
                entity.HasKey(e => e.Guid);

                entity.ToTable("dirServices");

                entity.Property(e => e.Guid)
                    .HasColumnName("guid")
                    .ValueGeneratedNever();

                entity.Property(e => e.GroupGuid).HasColumnName("group_guid");

                entity.Property(e => e.Price)
                    .HasColumnName("price")
                    .HasColumnType("numeric(10, 2)");

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasColumnName("title")
                    .HasMaxLength(300);

                entity.Property(e => e.TitleShort)
                    .IsRequired()
                    .HasColumnName("title_short")
                    .HasMaxLength(100);

                entity.Property(e => e.UnitGuid).HasColumnName("unit_guid");

                entity.HasOne(d => d.GroupGu)
                    .WithMany(p => p.DirServices)
                    .HasForeignKey(d => d.GroupGuid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_dirServices_dirServicesGroups");

                entity.HasOne(d => d.UnitGu)
                    .WithMany(p => p.DirServices)
                    .HasForeignKey(d => d.UnitGuid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_dirServices_dirServicesUnits");
            });

            modelBuilder.Entity<DirServicesBillsPatterns>(entity =>
            {
                entity.HasKey(e => e.Guid);

                entity.ToTable("dirServicesBillsPatterns");

                entity.Property(e => e.Guid)
                    .HasColumnName("guid")
                    .ValueGeneratedNever();

                entity.Property(e => e.PatternGuid).HasColumnName("pattern_guid");

                entity.Property(e => e.ServiceGuid).HasColumnName("service_guid");

                entity.HasOne(d => d.PatternGu)
                    .WithMany(p => p.DirServicesBillsPatterns)
                    .HasForeignKey(d => d.PatternGuid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_dirServicesBillsPatterns_dirServicesPatterns");

                entity.HasOne(d => d.ServiceGu)
                    .WithMany(p => p.DirServicesBillsPatterns)
                    .HasForeignKey(d => d.ServiceGuid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_dirServicesBillsPatterns_dirServices");
            });

            modelBuilder.Entity<DirServicesGroups>(entity =>
            {
                entity.HasKey(e => e.Guid);

                entity.ToTable("dirServicesGroups");

                entity.Property(e => e.Guid)
                    .HasColumnName("guid")
                    .ValueGeneratedNever();

                entity.Property(e => e.Factor)
                    .HasColumnName("factor")
                    .HasColumnType("numeric(10, 2)");

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasColumnName("title")
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<DirServicesPatterns>(entity =>
            {
                entity.HasKey(e => e.Guid);

                entity.ToTable("dirServicesPatterns");

                entity.Property(e => e.Guid)
                    .HasColumnName("guid")
                    .ValueGeneratedNever();

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasColumnName("title")
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<DirServicesSumFactors>(entity =>
            {
                entity.HasKey(e => e.Guid);

                entity.ToTable("dirServicesSumFactors");

                entity.Property(e => e.Guid)
                    .HasColumnName("guid")
                    .ValueGeneratedNever();

                entity.Property(e => e.SumFactor)
                    .HasColumnName("sum_factor")
                    .HasColumnType("decimal(3, 2)")
                    .HasDefaultValueSql("((1.0))");

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasColumnName("title")
                    .HasMaxLength(300)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.TitleShort)
                    .IsRequired()
                    .HasColumnName("title_short")
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<DirServicesUnits>(entity =>
            {
                entity.HasKey(e => e.Guid);

                entity.ToTable("dirServicesUnits");

                entity.Property(e => e.Guid)
                    .HasColumnName("guid")
                    .ValueGeneratedNever();

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasColumnName("title")
                    .HasMaxLength(100);

                entity.Property(e => e.UnitCode)
                    .HasColumnName("unit_code")
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<DirTextInspections>(entity =>
            {
                entity.HasKey(e => e.Guid);

                entity.ToTable("dirTextInspections");

                entity.Property(e => e.Guid)
                    .HasColumnName("guid")
                    .ValueGeneratedNever();

                entity.Property(e => e.Title)
                    .HasColumnName("title")
                    .HasMaxLength(500);
            });

            modelBuilder.Entity<DirTextObjectTargetType>(entity =>
            {
                entity.HasKey(e => e.Guid);

                entity.ToTable("dirTextObjectTargetType");

                entity.Property(e => e.Guid)
                    .HasColumnName("guid")
                    .ValueGeneratedNever();

                entity.Property(e => e.Text)
                    .IsRequired()
                    .HasColumnName("text")
                    .HasMaxLength(500);
            });

            modelBuilder.Entity<DirTextSamplesSourceTypes>(entity =>
            {
                entity.HasKey(e => e.Guid);

                entity.ToTable("dirTextSamplesSourceTypes");

                entity.Property(e => e.Guid)
                    .HasColumnName("guid")
                    .ValueGeneratedNever();

                entity.Property(e => e.Text)
                    .IsRequired()
                    .HasColumnName("text")
                    .HasMaxLength(500);
            });

            modelBuilder.Entity<DirTextVerdictPatterns>(entity =>
            {
                entity.HasKey(e => e.Guid);

                entity.ToTable("dirTextVerdictPatterns");

                entity.Property(e => e.Guid)
                    .HasColumnName("guid")
                    .ValueGeneratedNever();

                entity.Property(e => e.Text)
                    .IsRequired()
                    .HasColumnName("text")
                    .HasMaxLength(400);
            });

            modelBuilder.Entity<DirTextWoodCompositions>(entity =>
            {
                entity.HasKey(e => e.Guid);

                entity.ToTable("dirTextWoodCompositions");

                entity.Property(e => e.Guid)
                    .HasColumnName("guid")
                    .ValueGeneratedNever();

                entity.Property(e => e.IsBoard).HasColumnName("is_board");

                entity.Property(e => e.IsKind).HasColumnName("is_kind");

                entity.Property(e => e.IsTimber).HasColumnName("is_timber");

                entity.Property(e => e.Text)
                    .IsRequired()
                    .HasColumnName("text")
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<DirTransportTypes>(entity =>
            {
                entity.HasKey(e => e.Guid);

                entity.ToTable("dirTransportTypes");

                entity.Property(e => e.Guid)
                    .HasColumnName("guid")
                    .ValueGeneratedNever();

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasColumnName("title")
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<DirUnits>(entity =>
            {
                entity.HasKey(e => e.Guid);

                entity.ToTable("dirUnits");

                entity.Property(e => e.Guid)
                    .HasColumnName("guid")
                    .ValueGeneratedNever();

                entity.Property(e => e.GroupGuid).HasColumnName("group_guid");

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasColumnName("title")
                    .HasMaxLength(50);

                entity.HasOne(d => d.GroupGu)
                    .WithMany(p => p.DirUnits)
                    .HasForeignKey(d => d.GroupGuid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_dirUnits_dirUnitsGroups");
            });

            modelBuilder.Entity<DirUnitsGroups>(entity =>
            {
                entity.HasKey(e => e.Guid);

                entity.ToTable("dirUnitsGroups");

                entity.Property(e => e.Guid)
                    .HasColumnName("guid")
                    .ValueGeneratedNever();

                entity.Property(e => e.Title)
                    .HasColumnName("title")
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<DirUnitsGroupsDiseases>(entity =>
            {
                entity.HasKey(e => e.Guid);

                entity.ToTable("dirUnitsGroupsDiseases");

                entity.Property(e => e.Guid)
                    .HasColumnName("guid")
                    .ValueGeneratedNever();

                entity.Property(e => e.DiseaseGuid).HasColumnName("disease_guid");

                entity.Property(e => e.GroupGuid).HasColumnName("group_guid");

                entity.HasOne(d => d.DiseaseGu)
                    .WithMany(p => p.DirUnitsGroupsDiseases)
                    .HasForeignKey(d => d.DiseaseGuid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_dirUnitsGroupsDiseases_dirDiseases");

                entity.HasOne(d => d.GroupGu)
                    .WithMany(p => p.DirUnitsGroupsDiseases)
                    .HasForeignKey(d => d.GroupGuid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_dirUnitsGroupsDiseases_dirUnitsGroups");
            });

            modelBuilder.Entity<DirUsers>(entity =>
            {
                entity.HasKey(e => e.Guid)
                    .HasName("PK_dirUsers_1");

                entity.ToTable("dirUsers");

                entity.Property(e => e.Guid)
                    .HasColumnName("guid")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(100);

                entity.Property(e => e.OrgGuid).HasColumnName("org_guid");

                entity.Property(e => e.PasswordHash)
                    .HasColumnName("password_hash")
                    .HasDefaultValueSql("((757602046))");

                entity.HasOne(d => d.OrgGu)
                    .WithMany(p => p.DirUsers)
                    .HasForeignKey(d => d.OrgGuid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_dirUsers_dirOrganizations1");
            });

            modelBuilder.Entity<DirWeightUnits>(entity =>
            {
                entity.HasKey(e => e.Guid);

                entity.ToTable("dirWeightUnits");

                entity.Property(e => e.Guid)
                    .HasColumnName("guid")
                    .ValueGeneratedNever();

                entity.Property(e => e.Mnemonic)
                    .HasColumnName("mnemonic")
                    .HasMaxLength(50);

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasColumnName("title")
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<DocsActs>(entity =>
            {
                entity.HasKey(e => e.Guid)
                    .HasName("PK_docsActs_1");

                entity.ToTable("docsActs");

                entity.Property(e => e.Guid)
                    .HasColumnName("guid")
                    .ValueGeneratedNever();

                entity.Property(e => e.ClientAdressWarehouse)
                    .HasColumnName("client_adress_warehouse")
                    .HasMaxLength(200);

                entity.Property(e => e.Laboratory)
                    .HasColumnName("laboratory")
                    .HasMaxLength(10);

                entity.Property(e => e.Representative)
                    .HasColumnName("representative")
                    .HasMaxLength(200);

                entity.HasOne(d => d.Gu)
                    .WithOne(p => p.DocsActs)
                    .HasForeignKey<DocsActs>(d => d.Guid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_docsActs_docsWithGoods");
            });

            modelBuilder.Entity<DocsAgreements>(entity =>
            {
                entity.HasKey(e => e.Guid)
                    .HasName("PK_docsAgreements_1");

                entity.ToTable("docsAgreements");

                entity.Property(e => e.Guid)
                    .HasColumnName("guid")
                    .ValueGeneratedNever();

                entity.Property(e => e.DateLimit).HasColumnName("date_limit");

                entity.Property(e => e.Subject)
                    .HasColumnName("subject")
                    .HasMaxLength(100);

                entity.HasOne(d => d.Gu)
                    .WithOne(p => p.DocsAgreements)
                    .HasForeignKey<DocsAgreements>(d => d.Guid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_docsAgreements_docsAll");
            });

            modelBuilder.Entity<DocsAll>(entity =>
            {
                entity.HasKey(e => e.Guid);

                entity.ToTable("docsAll");

                entity.Property(e => e.Guid)
                    .HasColumnName("guid")
                    .ValueGeneratedNever();

                entity.Property(e => e.Date).HasColumnName("date");

                entity.Property(e => e.DocClientGuid).HasColumnName("doc_client_guid");

                entity.Property(e => e.DocParentGuid).HasColumnName("doc_parent_guid");

                entity.Property(e => e.DocUserGuid).HasColumnName("doc_user_guid");

                entity.Property(e => e.Number)
                    .HasColumnName("number")
                    .HasMaxLength(20);

                entity.HasOne(d => d.DocClientGu)
                    .WithMany(p => p.DocsAll)
                    .HasForeignKey(d => d.DocClientGuid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_docsAll_docsClients");

                entity.HasOne(d => d.DocParentGu)
                    .WithMany(p => p.InverseDocParentGu)
                    .HasForeignKey(d => d.DocParentGuid)
                    .HasConstraintName("FK_docsAll_docsAll");

                entity.HasOne(d => d.DocUserGu)
                    .WithMany(p => p.DocsAll)
                    .HasForeignKey(d => d.DocUserGuid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_docsAll_dirUsers");
            });

            modelBuilder.Entity<DocsBills>(entity =>
            {
                entity.HasKey(e => e.Guid)
                    .HasName("PK_docsBills_1");

                entity.ToTable("docsBills");

                entity.Property(e => e.Guid)
                    .HasColumnName("guid")
                    .ValueGeneratedNever();

                entity.Property(e => e.BillType).HasColumnName("bill_type");

                entity.Property(e => e.DocSum)
                    .HasColumnName("doc_sum")
                    .HasColumnType("numeric(10, 2)");

                entity.Property(e => e.FactAddress)
                    .HasColumnName("fact_address")
                    .HasMaxLength(500);

                entity.Property(e => e.IsCash).HasColumnName("is_cash");

                entity.Property(e => e.IsRussia).HasColumnName("is_russia");

                entity.Property(e => e.IsTransacted).HasColumnName("is_transacted");

                entity.Property(e => e.PaydocDate).HasColumnName("paydoc_date");

                entity.Property(e => e.PaydocNum)
                    .HasColumnName("paydoc_num")
                    .HasMaxLength(50);

                entity.Property(e => e.TaxNds)
                    .HasColumnName("tax_nds")
                    .HasColumnType("numeric(4, 2)")
                    .HasDefaultValueSql("((18.00))");

                entity.HasOne(d => d.Gu)
                    .WithOne(p => p.DocsBills)
                    .HasForeignKey<DocsBills>(d => d.Guid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_docsBills_docsAll");
            });

            modelBuilder.Entity<DocsBillsServices>(entity =>
            {
                entity.HasKey(e => e.Guid);

                entity.ToTable("docsBillsServices");

                entity.Property(e => e.Guid)
                    .HasColumnName("guid")
                    .ValueGeneratedNever();

                entity.Property(e => e.Count)
                    .HasColumnName("count")
                    .HasColumnType("numeric(10, 2)")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.DocGuid).HasColumnName("doc_guid");

                entity.Property(e => e.FactorGuid).HasColumnName("factor_guid");

                entity.Property(e => e.ServiceGuid).HasColumnName("service_guid");

                entity.HasOne(d => d.DocGu)
                    .WithMany(p => p.DocsBillsServices)
                    .HasForeignKey(d => d.DocGuid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_docsBillsServices_docsBills");

                entity.HasOne(d => d.FactorGu)
                    .WithMany(p => p.DocsBillsServices)
                    .HasForeignKey(d => d.FactorGuid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_docsBillsServices_dirServicesSumFactors");

                entity.HasOne(d => d.ServiceGu)
                    .WithMany(p => p.DocsBillsServices)
                    .HasForeignKey(d => d.ServiceGuid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_docsBillsServices_dirServices");
            });

            modelBuilder.Entity<DocsClients>(entity =>
            {
                entity.HasKey(e => e.Guid);

                entity.ToTable("docsClients");

                entity.Property(e => e.Guid)
                    .HasColumnName("guid")
                    .ValueGeneratedNever();

                entity.Property(e => e.Adress)
                    .HasColumnName("adress")
                    .HasMaxLength(500);

                entity.Property(e => e.AdressFact)
                    .HasColumnName("adress_fact")
                    .HasMaxLength(500);

                entity.Property(e => e.AdressWarehouse)
                    .HasColumnName("adress_warehouse")
                    .HasMaxLength(500);

                entity.Property(e => e.BankAccount)
                    .HasColumnName("bank_account")
                    .HasMaxLength(20);

                entity.Property(e => e.BankGuid).HasColumnName("bank_guid");

                entity.Property(e => e.FaceAgreement)
                    .HasColumnName("face_agreement")
                    .HasMaxLength(500);

                entity.Property(e => e.Inn)
                    .IsRequired()
                    .HasColumnName("inn")
                    .HasMaxLength(14);

                entity.Property(e => e.Kpp)
                    .HasColumnName("kpp")
                    .HasMaxLength(14);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(300);

                entity.Property(e => e.Phone)
                    .HasColumnName("phone")
                    .HasMaxLength(50);

                entity.Property(e => e.RegionGuid).HasColumnName("region_guid");

                entity.Property(e => e.RegionRayonGuid).HasColumnName("region_rayon_guid");

                entity.Property(e => e.Representative)
                    .HasColumnName("representative")
                    .HasMaxLength(50);

                entity.Property(e => e.TypeGuid).HasColumnName("type_guid");

                entity.HasOne(d => d.BankGu)
                    .WithMany(p => p.DocsClients)
                    .HasForeignKey(d => d.BankGuid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_docsClients_dirBanks");

                entity.HasOne(d => d.RegionGu)
                    .WithMany(p => p.DocsClients)
                    .HasForeignKey(d => d.RegionGuid)
                    .HasConstraintName("FK_docsClients_dirCountries");

                entity.HasOne(d => d.RegionRayonGu)
                    .WithMany(p => p.DocsClients)
                    .HasForeignKey(d => d.RegionRayonGuid)
                    .HasConstraintName("FK_docsClients_dirRegionsDistricts");

                entity.HasOne(d => d.TypeGu)
                    .WithMany(p => p.DocsClients)
                    .HasForeignKey(d => d.TypeGuid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_docsClients_dirClientTypes");
            });

            modelBuilder.Entity<DocsConclusionsExamination>(entity =>
            {
                entity.HasKey(e => e.Guid)
                    .HasName("PK_docsConclusionsExamination_1");

                entity.ToTable("docsConclusionsExamination");

                entity.Property(e => e.Guid)
                    .HasColumnName("guid")
                    .ValueGeneratedNever();

                entity.Property(e => e.FactAddress)
                    .HasColumnName("fact_address")
                    .HasMaxLength(500);

                entity.Property(e => e.InvoiceDate).HasColumnName("invoice_date");

                entity.Property(e => e.InvoiceNumber)
                    .HasColumnName("invoice_number")
                    .HasMaxLength(150);

                entity.Property(e => e.InvoiceTypeGuid).HasColumnName("invoice_type_guid");

                entity.Property(e => e.KarantinSertDate).HasColumnName("karantin_sert_date");

                entity.Property(e => e.KarantinSertNumber)
                    .HasColumnName("karantin_sert_number")
                    .HasMaxLength(50);

                entity.Property(e => e.SertFrom)
                    .HasColumnName("sert_from")
                    .HasMaxLength(200);

                entity.Property(e => e.SertNumber)
                    .HasColumnName("sert_number")
                    .HasMaxLength(50);

                entity.Property(e => e.TargetOrSource)
                    .HasColumnName("target_or_source")
                    .HasMaxLength(1000);

                entity.Property(e => e.TargetOrSourceGuid).HasColumnName("target_or_source_guid");

                entity.Property(e => e.TransportNumber)
                    .HasColumnName("transport_number")
                    .HasMaxLength(50);

                entity.Property(e => e.TransportTypeGuid).HasColumnName("transport_type_guid");

                entity.HasOne(d => d.Gu)
                    .WithOne(p => p.DocsConclusionsExamination)
                    .HasForeignKey<DocsConclusionsExamination>(d => d.Guid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_docsConclusionsExamination_docsWithGoods");

                entity.HasOne(d => d.InvoiceTypeGu)
                    .WithMany(p => p.DocsConclusionsExamination)
                    .HasForeignKey(d => d.InvoiceTypeGuid)
                    .HasConstraintName("FK_docsConclusionsExamination_dirInvoiceTypes");

                entity.HasOne(d => d.TargetOrSourceGu)
                    .WithMany(p => p.DocsConclusionsExamination)
                    .HasForeignKey(d => d.TargetOrSourceGuid)
                    .HasConstraintName("FK_docsConclusionsExamination_dirCountries");

                entity.HasOne(d => d.TransportTypeGu)
                    .WithMany(p => p.DocsConclusionsExamination)
                    .HasForeignKey(d => d.TransportTypeGuid)
                    .HasConstraintName("FK_docsConclusionsExamination_dirTransportTypes");
            });

            modelBuilder.Entity<DocsConclusionsExport>(entity =>
            {
                entity.HasKey(e => e.Guid)
                    .HasName("PK_docsConclusionsExport_1");

                entity.ToTable("docsConclusionsExport");

                entity.Property(e => e.Guid)
                    .HasColumnName("guid")
                    .ValueGeneratedNever();

                entity.Property(e => e.Addressee)
                    .HasColumnName("addressee")
                    .HasMaxLength(200);

                entity.Property(e => e.Disinfection)
                    .HasColumnName("disinfection")
                    .HasMaxLength(150);

                entity.Property(e => e.FactAddress)
                    .HasColumnName("fact_address")
                    .HasMaxLength(500);

                entity.Property(e => e.Inspection)
                    .HasColumnName("inspection")
                    .HasMaxLength(500);

                entity.Property(e => e.InvoicNumber)
                    .HasColumnName("invoic_number")
                    .HasMaxLength(150);

                entity.Property(e => e.InvoiceDate)
                    .HasColumnName("invoice_date")
                    .HasMaxLength(20);

                entity.Property(e => e.InvoiceTypeGuid).HasColumnName("invoice_type_guid");

                entity.Property(e => e.MarkGuid).HasColumnName("mark_guid");

                entity.Property(e => e.OriginDistrictGuid).HasColumnName("origin_district_guid");

                entity.Property(e => e.OriginText)
                    .HasColumnName("origin_text")
                    .HasMaxLength(200);

                entity.Property(e => e.Remark)
                    .IsRequired()
                    .HasColumnName("remark")
                    .HasMaxLength(500)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Representative)
                    .HasColumnName("representative")
                    .HasMaxLength(50);

                entity.Property(e => e.SamplesActionGuid).HasColumnName("samples_action_guid");

                entity.Property(e => e.SamplesDoc)
                    .HasColumnName("samples_doc")
                    .HasMaxLength(200);

                entity.Property(e => e.SamplesDocDate)
                    .HasColumnName("samples_doc_date")
                    .HasMaxLength(20);

                entity.Property(e => e.SamplesDocNumber)
                    .HasColumnName("samples_doc_number")
                    .HasMaxLength(20);

                entity.Property(e => e.SendingTo)
                    .IsRequired()
                    .HasColumnName("sending_to")
                    .HasMaxLength(100);

                entity.Property(e => e.TransportNumber)
                    .HasColumnName("transport_number")
                    .HasMaxLength(50);

                entity.Property(e => e.TransportTypeGuid).HasColumnName("transport_type_guid");

                entity.Property(e => e.Verdict)
                    .HasColumnName("verdict")
                    .HasMaxLength(400);

                entity.Property(e => e.Warehouse)
                    .HasColumnName("warehouse")
                    .HasMaxLength(500);

                entity.Property(e => e.WoodComposition)
                    .HasColumnName("wood_composition")
                    .HasMaxLength(500);

                entity.HasOne(d => d.Gu)
                    .WithOne(p => p.DocsConclusionsExport)
                    .HasForeignKey<DocsConclusionsExport>(d => d.Guid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_docsConclusionsExport_docsWithGoods");

                entity.HasOne(d => d.InvoiceTypeGu)
                    .WithMany(p => p.DocsConclusionsExport)
                    .HasForeignKey(d => d.InvoiceTypeGuid)
                    .HasConstraintName("FK_docsConclusionsExport_dirInvoiceTypes");

                entity.HasOne(d => d.MarkGu)
                    .WithMany(p => p.DocsConclusionsExport)
                    .HasForeignKey(d => d.MarkGuid)
                    .HasConstraintName("FK_docsConclusionsExport_dirMarkTypes");

                entity.HasOne(d => d.OriginDistrictGu)
                    .WithMany(p => p.DocsConclusionsExport)
                    .HasForeignKey(d => d.OriginDistrictGuid)
                    .HasConstraintName("FK_docsConclusionsExport_dirRegionsDistricts");

                entity.HasOne(d => d.SamplesActionGu)
                    .WithMany(p => p.DocsConclusionsExport)
                    .HasForeignKey(d => d.SamplesActionGuid)
                    .HasConstraintName("FK_docsConclusionsExport_dirSamplesActions");

                entity.HasOne(d => d.TransportTypeGu)
                    .WithMany(p => p.DocsConclusionsExport)
                    .HasForeignKey(d => d.TransportTypeGuid)
                    .HasConstraintName("FK_docsConclusionsExport_dirTransportTypes");
            });

            modelBuilder.Entity<DocsConclusionsImport>(entity =>
            {
                entity.HasKey(e => e.Guid)
                    .HasName("PK_docsConclusionsImport_1");

                entity.ToTable("docsConclusionsImport");

                entity.Property(e => e.Guid)
                    .HasColumnName("guid")
                    .ValueGeneratedNever();

                entity.Property(e => e.Arrived)
                    .IsRequired()
                    .HasColumnName("arrived")
                    .HasMaxLength(100);

                entity.Property(e => e.ArrivedDistrictGuid).HasColumnName("arrived_district_guid");

                entity.Property(e => e.Disinfection)
                    .HasColumnName("disinfection")
                    .HasMaxLength(150);

                entity.Property(e => e.FactAddress)
                    .HasColumnName("fact_address")
                    .HasMaxLength(500);

                entity.Property(e => e.IkrNumber)
                    .HasColumnName("ikr_number")
                    .HasMaxLength(50);

                entity.Property(e => e.Inspection)
                    .HasColumnName("inspection")
                    .HasMaxLength(500);

                entity.Property(e => e.InvoiceDate)
                    .HasColumnName("invoice_date")
                    .HasMaxLength(20);

                entity.Property(e => e.InvoiceNumber)
                    .HasColumnName("invoice_number")
                    .HasMaxLength(150);

                entity.Property(e => e.InvoiceTypeGuid).HasColumnName("invoice_type_guid");

                entity.Property(e => e.MarkGuid).HasColumnName("mark_guid");

                entity.Property(e => e.QualityDate)
                    .HasColumnName("quality_date")
                    .HasMaxLength(20);

                entity.Property(e => e.QualityNumber)
                    .HasColumnName("quality_number")
                    .HasMaxLength(50);

                entity.Property(e => e.QualityTypeGuid).HasColumnName("quality_type_guid");

                entity.Property(e => e.Remark)
                    .IsRequired()
                    .HasColumnName("remark")
                    .HasMaxLength(500)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Representative)
                    .HasColumnName("representative")
                    .HasMaxLength(50);

                entity.Property(e => e.SamplesActionGuid).HasColumnName("samples_action_guid");

                entity.Property(e => e.SamplesDoc)
                    .HasColumnName("samples_doc")
                    .HasMaxLength(200);

                entity.Property(e => e.SamplesDocDate)
                    .HasColumnName("samples_doc_date")
                    .HasMaxLength(20);

                entity.Property(e => e.SamplesDocNumber)
                    .HasColumnName("samples_doc_number")
                    .HasMaxLength(20);

                entity.Property(e => e.Sender)
                    .HasColumnName("sender")
                    .HasMaxLength(200);

                entity.Property(e => e.SertFrom)
                    .HasColumnName("sert_from")
                    .HasMaxLength(200);

                entity.Property(e => e.SertNumber)
                    .HasColumnName("sert_number")
                    .HasMaxLength(50);

                entity.Property(e => e.TransportNumber)
                    .HasColumnName("transport_number")
                    .HasMaxLength(50);

                entity.Property(e => e.TransportTypeGuid).HasColumnName("transport_type_guid");

                entity.Property(e => e.Verdict)
                    .HasColumnName("verdict")
                    .HasMaxLength(500);

                entity.Property(e => e.Warehouse)
                    .HasColumnName("warehouse")
                    .HasMaxLength(500);

                entity.HasOne(d => d.ArrivedDistrictGu)
                    .WithMany(p => p.DocsConclusionsImport)
                    .HasForeignKey(d => d.ArrivedDistrictGuid)
                    .HasConstraintName("FK_docsConclusionsImport_dirRegionsDistricts");

                entity.HasOne(d => d.Gu)
                    .WithOne(p => p.DocsConclusionsImport)
                    .HasForeignKey<DocsConclusionsImport>(d => d.Guid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_docsConclusionsImport_docsWithGoods");

                entity.HasOne(d => d.InvoiceTypeGu)
                    .WithMany(p => p.DocsConclusionsImport)
                    .HasForeignKey(d => d.InvoiceTypeGuid)
                    .HasConstraintName("FK_docsConclusionsImport_dirInvoiceTypes");

                entity.HasOne(d => d.MarkGu)
                    .WithMany(p => p.DocsConclusionsImport)
                    .HasForeignKey(d => d.MarkGuid)
                    .HasConstraintName("FK_docsConclusionsImport_dirMarkTypes");

                entity.HasOne(d => d.QualityTypeGu)
                    .WithMany(p => p.DocsConclusionsImport)
                    .HasForeignKey(d => d.QualityTypeGuid)
                    .HasConstraintName("FK_docsConclusionsImport_dirQualityTypes");

                entity.HasOne(d => d.SamplesActionGu)
                    .WithMany(p => p.DocsConclusionsImport)
                    .HasForeignKey(d => d.SamplesActionGuid)
                    .HasConstraintName("FK_docsConclusionsImport_dirSamplesActions");

                entity.HasOne(d => d.TransportTypeGu)
                    .WithMany(p => p.DocsConclusionsImport)
                    .HasForeignKey(d => d.TransportTypeGuid)
                    .HasConstraintName("FK_docsConclusionsImport_dirTransportTypes");
            });

            modelBuilder.Entity<DocsConclusionsObjects>(entity =>
            {
                entity.HasKey(e => e.Guid);

                entity.ToTable("docsConclusionsObjects");

                entity.Property(e => e.Guid)
                    .HasColumnName("guid")
                    .ValueGeneratedNever();

                entity.Property(e => e.CategoryGuid).HasColumnName("category_guid");

                entity.Property(e => e.Conclusion).HasColumnName("conclusion");

                entity.Property(e => e.Representative)
                    .HasColumnName("representative")
                    .HasMaxLength(50);

                entity.Property(e => e.Verdict).HasColumnName("verdict");

                entity.HasOne(d => d.CategoryGu)
                    .WithMany(p => p.DocsConclusionsObjects)
                    .HasForeignKey(d => d.CategoryGuid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_docsConclusionsObjects_dirObjectsCategories");

                entity.HasOne(d => d.Gu)
                    .WithOne(p => p.DocsConclusionsObjects)
                    .HasForeignKey<DocsConclusionsObjects>(d => d.Guid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_docsConclusionsObjects_docsAll");
            });

            modelBuilder.Entity<DocsExaminationTasks>(entity =>
            {
                entity.HasKey(e => e.Guid);

                entity.ToTable("docsExaminationTasks");

                entity.Property(e => e.Guid)
                    .HasColumnName("guid")
                    .ValueGeneratedNever();

                entity.Property(e => e.ClientId).HasColumnName("clientId");

                entity.Property(e => e.CountMassVolume)
                    .HasColumnName("countMassVolume")
                    .HasMaxLength(500);

                entity.Property(e => e.Date).HasColumnName("date");

                entity.Property(e => e.DateReceipt).HasColumnName("dateReceipt");

                entity.Property(e => e.DateSampling).HasColumnName("dateSampling");

                entity.Property(e => e.DestinationCountryId).HasColumnName("destinationCountryId");

                entity.Property(e => e.ExamiationPlace)
                    .HasColumnName("examiationPlace")
                    .HasMaxLength(500);

                entity.Property(e => e.HasAppendix).HasColumnName("hasAppendix");

                entity.Property(e => e.Number).HasColumnName("number");

                entity.Property(e => e.OriginCountryId).HasColumnName("originCountryId");

                entity.Property(e => e.SafePackage)
                    .HasColumnName("safePackage")
                    .HasMaxLength(500);

                entity.Property(e => e.SamplingActor)
                    .HasColumnName("samplingActor")
                    .HasMaxLength(500);

                entity.Property(e => e.SamplingPlace)
                    .HasColumnName("samplingPlace")
                    .HasMaxLength(500);

                entity.Property(e => e.SamplingProductionId).HasColumnName("samplingProductionId");

                entity.Property(e => e.SamplingStandard)
                    .HasColumnName("samplingStandard")
                    .HasMaxLength(100);

                entity.Property(e => e.ShouldReturn).HasColumnName("shouldReturn");

                entity.Property(e => e.Title)
                    .HasColumnName("title")
                    .HasMaxLength(100);

                entity.HasOne(d => d.Client)
                    .WithMany(p => p.DocsExaminationTasks)
                    .HasForeignKey(d => d.ClientId)
                    .HasConstraintName("FK_docsExaminationTasks_docsClients");

                entity.HasOne(d => d.DestinationCountry)
                    .WithMany(p => p.DocsExaminationTasksDestinationCountry)
                    .HasForeignKey(d => d.DestinationCountryId)
                    .HasConstraintName("FK_docsExaminationTasks_dirCountries");

                entity.HasOne(d => d.OriginCountry)
                    .WithMany(p => p.DocsExaminationTasksOriginCountry)
                    .HasForeignKey(d => d.OriginCountryId)
                    .HasConstraintName("FK_docsExaminationTasks_dirsCountries1");

                entity.HasOne(d => d.SamplingProduction)
                    .WithMany(p => p.DocsExaminationTasks)
                    .HasForeignKey(d => d.SamplingProductionId)
                    .HasConstraintName("FK_docsExaminationTasks_dirGoods");
            });

            modelBuilder.Entity<DocsExaminationTasksExaminations>(entity =>
            {
                entity.HasKey(e => e.Guid);

                entity.ToTable("docsExaminationTasksExaminations");

                entity.Property(e => e.Guid)
                    .HasColumnName("guid")
                    .ValueGeneratedNever();

                entity.Property(e => e.Comments)
                    .HasColumnName("comments")
                    .HasMaxLength(500);

                entity.Property(e => e.EndDate).HasColumnName("endDate");

                entity.Property(e => e.ExaminationId).HasColumnName("examinationId");

                entity.Property(e => e.ExaminationResult)
                    .HasColumnName("examinationResult")
                    .HasMaxLength(500);

                entity.Property(e => e.MethodId).HasColumnName("methodId");

                entity.Property(e => e.TaskId).HasColumnName("taskId");

                entity.Property(e => e.UserId).HasColumnName("userId");

                entity.HasOne(d => d.Examination)
                    .WithMany(p => p.DocsExaminationTasksExaminations)
                    .HasForeignKey(d => d.ExaminationId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_docsExaminationTasksExaminations_dirSamplesExaminations");

                entity.HasOne(d => d.Method)
                    .WithMany(p => p.DocsExaminationTasksExaminations)
                    .HasForeignKey(d => d.MethodId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_docsExaminationTasksExaminations_dirExaminationMethods");

                entity.HasOne(d => d.Task)
                    .WithMany(p => p.DocsExaminationTasksExaminations)
                    .HasForeignKey(d => d.TaskId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_docsExaminationTasksExaminations_docsExaminationTasks");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.DocsExaminationTasksExaminations)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_docsExaminationTasksExaminations_dirUsers");
            });

            modelBuilder.Entity<DocsGoods>(entity =>
            {
                entity.HasKey(e => e.Guid)
                    .HasName("PK_docsGoods_1");

                entity.ToTable("docsGoods");

                entity.Property(e => e.Guid)
                    .HasColumnName("guid")
                    .ValueGeneratedNever();

                entity.Property(e => e.DocGuid).HasColumnName("doc_guid");

                entity.Property(e => e.GoodGuid).HasColumnName("good_guid");

                entity.Property(e => e.Places).HasColumnName("places");

                entity.Property(e => e.PlacesUnitGuid).HasColumnName("places_unit_guid");

                entity.Property(e => e.ProductionCountryGuid).HasColumnName("production_country_guid");

                entity.Property(e => e.SamplesCount).HasColumnName("samples_count");

                entity.Property(e => e.Weight)
                    .HasColumnName("weight")
                    .HasColumnType("numeric(18, 4)");

                entity.Property(e => e.WeightUnitGuid).HasColumnName("weight_unit_guid");

                entity.HasOne(d => d.DocGu)
                    .WithMany(p => p.DocsGoods)
                    .HasForeignKey(d => d.DocGuid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_docsGoods_docsWithGoods");

                entity.HasOne(d => d.GoodGu)
                    .WithMany(p => p.DocsGoods)
                    .HasForeignKey(d => d.GoodGuid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_docsGoods_dirGoods");

                entity.HasOne(d => d.PlacesUnitGu)
                    .WithMany(p => p.DocsGoods)
                    .HasForeignKey(d => d.PlacesUnitGuid)
                    .HasConstraintName("FK_docsGoods_dirPlacesUnits");

                entity.HasOne(d => d.ProductionCountryGu)
                    .WithMany(p => p.DocsGoods)
                    .HasForeignKey(d => d.ProductionCountryGuid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_docsGoods_dirCountries");

                entity.HasOne(d => d.WeightUnitGu)
                    .WithMany(p => p.DocsGoods)
                    .HasForeignKey(d => d.WeightUnitGuid)
                    .HasConstraintName("FK_docsGoods_dirWeightUnits");
            });

            modelBuilder.Entity<DocsGoodsDiseases>(entity =>
            {
                entity.HasKey(e => new { e.Guid, e.DiaseaseGuid })
                    .HasName("PK_docsGoodsDiseases_1");

                entity.ToTable("docsGoodsDiseases");

                entity.Property(e => e.Guid).HasColumnName("guid");

                entity.Property(e => e.DiaseaseGuid).HasColumnName("diasease_guid");

                entity.Property(e => e.Count)
                    .HasColumnName("count")
                    .HasColumnType("numeric(8, 2)");

                entity.Property(e => e.CountGuid).HasColumnName("count_guid");

                entity.Property(e => e.DiaseaseStateGuid).HasColumnName("diasease_state_guid");

                entity.HasOne(d => d.CountGu)
                    .WithMany(p => p.DocsGoodsDiseases)
                    .HasForeignKey(d => d.CountGuid)
                    .HasConstraintName("FK_docsGoodsDiseases_dirDiseasesCounts");

                entity.HasOne(d => d.DiaseaseGu)
                    .WithMany(p => p.DocsGoodsDiseases)
                    .HasForeignKey(d => d.DiaseaseGuid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_docsGoodsDiseases_dirDiseases");

                entity.HasOne(d => d.DiaseaseStateGu)
                    .WithMany(p => p.DocsGoodsDiseases)
                    .HasForeignKey(d => d.DiaseaseStateGuid)
                    .HasConstraintName("FK_docsGoodsDiseases_dirDiaseasesStates");

                entity.HasOne(d => d.Gu)
                    .WithMany(p => p.DocsGoodsDiseases)
                    .HasForeignKey(d => d.Guid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_docsGoodsDiseases_docsGoods");
            });

            modelBuilder.Entity<DocsUnits>(entity =>
            {
                entity.HasKey(e => e.Guid)
                    .HasName("PK_docsConclusionsObjectsUnits");

                entity.ToTable("docsUnits");

                entity.Property(e => e.Guid)
                    .HasColumnName("guid")
                    .ValueGeneratedNever();

                entity.Property(e => e.Count).HasColumnName("count");

                entity.Property(e => e.DistrictGuid).HasColumnName("district_guid");

                entity.Property(e => e.DocGuid).HasColumnName("doc_guid");

                entity.Property(e => e.ExamBait).HasColumnName("exam_bait");

                entity.Property(e => e.ExamDust).HasColumnName("exam_dust");

                entity.Property(e => e.ExamSample).HasColumnName("exam_sample");

                entity.Property(e => e.ExamTrap).HasColumnName("exam_trap");

                entity.Property(e => e.UnitGuid).HasColumnName("unit_guid");

                entity.Property(e => e.Volume)
                    .HasColumnName("volume")
                    .HasColumnType("numeric(10, 2)");

                entity.Property(e => e.VolumeUnit)
                    .IsRequired()
                    .HasColumnName("volume_unit")
                    .HasMaxLength(50);

                entity.HasOne(d => d.DistrictGu)
                    .WithMany(p => p.DocsUnits)
                    .HasForeignKey(d => d.DistrictGuid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_docsUnits_dirRegionsDistricts");

                entity.HasOne(d => d.DocGu)
                    .WithMany(p => p.DocsUnits)
                    .HasForeignKey(d => d.DocGuid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_docsUnits_docsConclusionsObjects");

                entity.HasOne(d => d.UnitGu)
                    .WithMany(p => p.DocsUnits)
                    .HasForeignKey(d => d.UnitGuid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_docsUnits_dirUnits");
            });

            modelBuilder.Entity<DocsUnitsDiseases>(entity =>
            {
                entity.HasKey(e => new { e.Guid, e.DiaseaseGuid });

                entity.ToTable("docsUnitsDiseases");

                entity.Property(e => e.Guid).HasColumnName("guid");

                entity.Property(e => e.DiaseaseGuid).HasColumnName("diasease_guid");

                entity.Property(e => e.ExamCount).HasColumnName("exam_count");

                entity.Property(e => e.ExamMethod)
                    .IsRequired()
                    .HasColumnName("exam_method")
                    .HasMaxLength(50);

                entity.HasOne(d => d.DiaseaseGu)
                    .WithMany(p => p.DocsUnitsDiseases)
                    .HasForeignKey(d => d.DiaseaseGuid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_docsUnitsDiseases_dirDiseases");

                entity.HasOne(d => d.Gu)
                    .WithMany(p => p.DocsUnitsDiseases)
                    .HasForeignKey(d => d.Guid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_docsUnitsDiseases_docsUnits1");
            });

            modelBuilder.Entity<DocsUnitsExaminations>(entity =>
            {
                entity.HasKey(e => new { e.Guid, e.ExaminationGuid });

                entity.ToTable("docsUnitsExaminations");

                entity.Property(e => e.Guid).HasColumnName("guid");

                entity.Property(e => e.ExaminationGuid).HasColumnName("examination_guid");

                entity.Property(e => e.Volume)
                    .HasColumnName("volume")
                    .HasColumnType("numeric(10, 2)");

                entity.HasOne(d => d.ExaminationGu)
                    .WithMany(p => p.DocsUnitsExaminations)
                    .HasForeignKey(d => d.ExaminationGuid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_docsUnitsExaminations_dirExaminations");

                entity.HasOne(d => d.Gu)
                    .WithMany(p => p.DocsUnitsExaminations)
                    .HasForeignKey(d => d.Guid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_docsUnitsExaminations_docsUnits");
            });

            modelBuilder.Entity<DocsWithGoods>(entity =>
            {
                entity.HasKey(e => e.Guid);

                entity.ToTable("docsWithGoods");

                entity.Property(e => e.Guid)
                    .HasColumnName("guid")
                    .ValueGeneratedNever();

                entity.HasOne(d => d.Gu)
                    .WithOne(p => p.DocsWithGoods)
                    .HasForeignKey<DocsWithGoods>(d => d.Guid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_docsWithGoods_docsAll");
            });

            modelBuilder.Entity<SecAccessMatrix>(entity =>
            {
                entity.HasKey(e => e.Guid);

                entity.ToTable("secAccessMatrix");

                entity.Property(e => e.Guid)
                    .HasColumnName("guid")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.ObjectGuid).HasColumnName("object_guid");

                entity.Property(e => e.OperationGuid).HasColumnName("operation_guid");

                entity.Property(e => e.PermissionGuid).HasColumnName("permission_guid");

                entity.Property(e => e.SubjectGuid).HasColumnName("subject_guid");

                entity.HasOne(d => d.ObjectGu)
                    .WithMany(p => p.SecAccessMatrix)
                    .HasForeignKey(d => d.ObjectGuid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_secAccessMatrix_secObjects");

                entity.HasOne(d => d.OperationGu)
                    .WithMany(p => p.SecAccessMatrix)
                    .HasForeignKey(d => d.OperationGuid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_secAccessMatrix_secOperations");

                entity.HasOne(d => d.PermissionGu)
                    .WithMany(p => p.SecAccessMatrix)
                    .HasForeignKey(d => d.PermissionGuid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_secAccessMatrix_secPermissions");

                entity.HasOne(d => d.SubjectGu)
                    .WithMany(p => p.SecAccessMatrix)
                    .HasForeignKey(d => d.SubjectGuid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_secAccessMatrix_secSubjects");
            });

            modelBuilder.Entity<SecAppObjects>(entity =>
            {
                entity.HasKey(e => e.Guid)
                    .HasName("PK_secObjects");

                entity.ToTable("secAppObjects");

                entity.Property(e => e.Guid)
                    .HasColumnName("guid")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(50);

                entity.Property(e => e.TypeGuid).HasColumnName("type_guid");

                entity.HasOne(d => d.TypeGu)
                    .WithMany(p => p.SecAppObjects)
                    .HasForeignKey(d => d.TypeGuid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_secObjects_secObjectsTypes");
            });

            modelBuilder.Entity<SecAppObjectsTypes>(entity =>
            {
                entity.HasKey(e => e.Guid)
                    .HasName("PK_secObjectsTypes");

                entity.ToTable("secAppObjectsTypes");

                entity.Property(e => e.Guid)
                    .HasColumnName("guid")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<SecObjects>(entity =>
            {
                entity.HasKey(e => e.Guid)
                    .HasName("PK_secObjects_1");

                entity.ToTable("secObjects");

                entity.Property(e => e.Guid)
                    .HasColumnName("guid")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.ObjectGuid).HasColumnName("object_guid");

                entity.Property(e => e.Title)
                    .HasColumnName("title")
                    .HasMaxLength(50);

                entity.Property(e => e.TypeGuid).HasColumnName("type_guid");

                entity.HasOne(d => d.ObjectGu)
                    .WithMany(p => p.SecObjects)
                    .HasForeignKey(d => d.ObjectGuid)
                    .HasConstraintName("FK_secObjects_secAppObjects");

                entity.HasOne(d => d.TypeGu)
                    .WithMany(p => p.SecObjects)
                    .HasForeignKey(d => d.TypeGuid)
                    .HasConstraintName("FK_secObjects_secAppObjectsTypes");
            });

            modelBuilder.Entity<SecOperations>(entity =>
            {
                entity.HasKey(e => e.Guid);

                entity.ToTable("secOperations");

                entity.Property(e => e.Guid)
                    .HasColumnName("guid")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<SecPermissions>(entity =>
            {
                entity.HasKey(e => e.Guid);

                entity.ToTable("secPermissions");

                entity.Property(e => e.Guid)
                    .HasColumnName("guid")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<SecSubjects>(entity =>
            {
                entity.HasKey(e => e.Guid);

                entity.ToTable("secSubjects");

                entity.Property(e => e.Guid)
                    .HasColumnName("guid")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.OrgGuid).HasColumnName("org_guid");

                entity.Property(e => e.Title)
                    .HasColumnName("title")
                    .HasMaxLength(50);

                entity.Property(e => e.UserGuid).HasColumnName("user_guid");

                entity.HasOne(d => d.OrgGu)
                    .WithMany(p => p.SecSubjects)
                    .HasForeignKey(d => d.OrgGuid)
                    .HasConstraintName("FK_secSubjects_dirOrganizations");

                entity.HasOne(d => d.UserGu)
                    .WithMany(p => p.SecSubjects)
                    .HasForeignKey(d => d.UserGuid)
                    .HasConstraintName("FK_secSubjects_dirUsers");
            });
        }
    }
}
