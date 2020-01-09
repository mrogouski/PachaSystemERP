// <copyright file="PachaSystemContext.cs" company="Pacha System">
// Copyright (c) Pacha System. All rights reserved.
// </copyright>

namespace PachaSystem.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity;
    using System.Data.Entity.ModelConfiguration.Conventions;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using NLog;
    using PachaSystem.Data.Migrations;
    using PachaSystem.Data.Models;

    public class PachaSystemContext : DbContext
    {
        private static readonly Logger _logger = LogManager.GetCurrentClassLogger();

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="PachaSystemContext"/>.
        /// </summary>
        public PachaSystemContext()
            : base("PachaSystemERP.Properties.Settings.PachaSystemERPConnectionString")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<PachaSystemContext, Configuration>());
            //Database.Log = s => logger.Debug(s);
        }

        public DbSet<AssociatedInvoice> AssociatedReceipts { get; set; }

        public DbSet<Client> Clients { get; set; }

        public DbSet<ConceptType> ConceptTypes { get; set; }

        public DbSet<CurrencyType> CurrencyTypes { get; set; }

        public DbSet<DocumentType> DocumentTypes { get; set; }

        public DbSet<FiscalConditionType> FiscalConditionTypes { get; set; }

        public DbSet<Item> Items { get; set; }

        public DbSet<ItemCategory> ItemCategories { get; set; }

        public DbSet<MeasureUnit> MeasureUnits { get; set; }

        public DbSet<Invoice> Receipts { get; set; }

        public DbSet<InvoiceDetails> ReceiptDetails { get; set; }

        public DbSet<InvoiceType> ReceiptTypes { get; set; }

        public DbSet<Tribute> Tributes { get; set; }

        public DbSet<TributeCategory> TributeCategories { get; set; }

        public DbSet<TributeDetails> TributeDetails { get; set; }

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

            modelBuilder.Entity<Client>().Property(x => x.BusinessName).IsRequired();
            modelBuilder.Entity<Client>().Property(x => x.DocumentNumber).IsRequired();
            modelBuilder.Entity<Client>().Property(x => x.Address).IsRequired();

            modelBuilder.Entity<ConceptType>().Property(x => x.ID).HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
            modelBuilder.Entity<ConceptType>().Property(x => x.Name).IsRequired();

            modelBuilder.Entity<CurrencyType>().Property(x => x.ID).HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
            modelBuilder.Entity<CurrencyType>().Property(x => x.Code).IsRequired();
            modelBuilder.Entity<CurrencyType>().Property(x => x.Description).IsRequired();

            modelBuilder.Entity<DocumentType>().Property(x => x.ID).HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
            modelBuilder.Entity<DocumentType>().Property(x => x.Description).IsRequired();

            modelBuilder.Entity<FiscalConditionType>().Property(x => x.ID).HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
            modelBuilder.Entity<FiscalConditionType>().Property(x => x.Description).IsRequired();

            modelBuilder.Entity<Item>().Property(x => x.Code).IsRequired();
            modelBuilder.Entity<Item>().Property(x => x.Description).IsRequired();

            modelBuilder.Entity<ItemCategory>().Property(x => x.Name).IsRequired();

            modelBuilder.Entity<MeasureUnit>().Property(x => x.ID).HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
            modelBuilder.Entity<MeasureUnit>().Property(x => x.Description).IsRequired();

            modelBuilder.Entity<InvoiceDetails>().HasKey(x => new { x.InvoiceID, x.ItemID });

            modelBuilder.Entity<InvoiceType>().Property(x => x.ID).HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
            modelBuilder.Entity<InvoiceType>().Property(x => x.Description).IsRequired();

            modelBuilder.Entity<Tribute>().Property(x => x.ID).HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
            modelBuilder.Entity<Tribute>().Property(x => x.Description).IsRequired();

            modelBuilder.Entity<TributeCategory>().Property(x => x.Name).IsRequired();

            modelBuilder.Entity<TributeDetails>().HasKey(x => new { x.ReceiptID, x.TributeID });

            modelBuilder.Entity<Vat>().Property(x => x.ID).HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
            modelBuilder.Entity<Vat>().Property(x => x.Description).IsRequired();
        }
    }
}
