// <copyright file="PachaSystemContext.cs" company="Pacha System">
// Copyright (c) Pacha System. All rights reserved.
// </copyright>

namespace PachaSystem.Data
{
    using NLog;
    using PachaSystem.Data.Migrations;
    using PachaSystem.Data.Models;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity;
    using System.Data.Entity.ModelConfiguration.Conventions;

    public class PachaSystemContext : DbContext
    {
        private static readonly Logger _logger = LogManager.GetCurrentClassLogger();

        public PachaSystemContext()
            : base("PachaSystemERP.Properties.Settings.PachaSystemERPConnectionString")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<PachaSystemContext, Configuration>());
            //Database.Log = s => logger.Debug(s);
        }

        public DbSet<AssociatedInvoice> AssociatedInvoices { get; set; }

        public DbSet<ConceptType> ConceptTypes { get; set; }
        public DbSet<CurrencyType> CurrencyTypes { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<DocumentType> DocumentTypes { get; set; }

        public DbSet<FiscalCondition> FiscalConditionTypes { get; set; }

        public DbSet<InvoiceDetails> InvoiceDetails { get; set; }
        public DbSet<Invoice> Invoices { get; set; }
        public DbSet<InvoiceType> InvoiceTypes { get; set; }
        public DbSet<MeasureUnit> MeasureUnits { get; set; }
        public DbSet<ProductCategory> ProductCategories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<TributeCategory> TributeCategories { get; set; }
        public DbSet<TributeDetails> TributeDetails { get; set; }
        public DbSet<Tribute> Tributes { get; set; }
        public DbSet<Vat> Vat { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Add(new DecimalPropertyConvention(19, 2));

            modelBuilder.Entity<AssociatedInvoice>()
                .HasKey(x => x.ID)
                .HasRequired(x => x.Invoice)
                .WithOptional(x => x.AssociatedReceipt);
            modelBuilder.Entity<AssociatedInvoice>().Property(x => x.InvoiceNumber).IsRequired();

            modelBuilder.Entity<Customer>().Property(x => x.BusinessName).IsRequired();
            modelBuilder.Entity<Customer>().Property(x => x.DocumentNumber).IsRequired();
            modelBuilder.Entity<Customer>().Property(x => x.Address).IsRequired();

            modelBuilder.Entity<ConceptType>().Property(x => x.ID).HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
            modelBuilder.Entity<ConceptType>().Property(x => x.Name).IsRequired();

            modelBuilder.Entity<CurrencyType>().Property(x => x.ID).HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
            modelBuilder.Entity<CurrencyType>().Property(x => x.Code).IsRequired();
            modelBuilder.Entity<CurrencyType>().Property(x => x.Description).IsRequired();

            modelBuilder.Entity<DocumentType>().Property(x => x.ID).HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
            modelBuilder.Entity<DocumentType>().Property(x => x.Description).IsRequired();

            modelBuilder.Entity<FiscalCondition>().Property(x => x.ID).HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
            modelBuilder.Entity<FiscalCondition>().Property(x => x.Description).IsRequired();

            modelBuilder.Entity<Product>().Property(x => x.Code).IsRequired();
            modelBuilder.Entity<Product>().Property(x => x.Description).IsRequired();

            modelBuilder.Entity<ProductCategory>().Property(x => x.Name).IsRequired();

            modelBuilder.Entity<MeasureUnit>().Property(x => x.ID).HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
            modelBuilder.Entity<MeasureUnit>().Property(x => x.Description).IsRequired();

            modelBuilder.Entity<InvoiceDetails>().HasKey(x => new { x.InvoiceID, x.ProductID });

            modelBuilder.Entity<InvoiceType>().Property(x => x.ID).HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
            modelBuilder.Entity<InvoiceType>().Property(x => x.Description).IsRequired();

            modelBuilder.Entity<Tribute>().HasKey(x => x.ID).Property(x => x.Description).IsRequired();

            modelBuilder.Entity<TributeCategory>().Property(x => x.Description).IsRequired();

            modelBuilder.Entity<TributeDetails>().HasKey(x => new { x.InvoiceID, x.TributeID });

            modelBuilder.Entity<Vat>().Property(x => x.ID).HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
            modelBuilder.Entity<Vat>().Property(x => x.Description).IsRequired();
        }
    }
}