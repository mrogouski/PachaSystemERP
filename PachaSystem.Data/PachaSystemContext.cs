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

        public DbSet<CategoriaTributo> CategoriaTributo { get; set; }

        public DbSet<Cliente> Cliente { get; set; }

        public DbSet<Receipt> Comprobante { get; set; }

        public DbSet<ReceiptDetails> DetalleComprobante { get; set; }

        public DbSet<DetalleTributo> DetalleTributo { get; set; }

        public DbSet<Iva> Iva { get; set; }

        public DbSet<Producto> Producto { get; set; }

        public DbSet<CategoriaProducto> Rubro { get; set; }

        public DbSet<TipoComprobante> TipoComprobante { get; set; }

        public DbSet<TipoConcepto> TipoConcepto { get; set; }

        public DbSet<TipoDocumento> TipoDocumento { get; set; }

        public DbSet<TipoMoneda> TipoMoneda { get; set; }

        public DbSet<TipoResponsable> TipoResponsable { get; set; }

        public DbSet<Tributo> Tributo { get; set; }

        public DbSet<UnidadMedida> UnidadMedida { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Add(new DecimalPropertyConvention(19, 2));

            modelBuilder.Entity<CategoriaProducto>().Property(x => x.Descripcion).IsRequired();

            modelBuilder.Entity<CategoriaTributo>().Property(x => x.Descripcion).IsRequired();

            modelBuilder.Entity<Cliente>().Property(x => x.RazonSocial).IsRequired();
            modelBuilder.Entity<Cliente>().Property(x => x.NumeroDocumento).IsRequired();
            modelBuilder.Entity<Cliente>().Property(x => x.Domicilio).IsRequired();

            modelBuilder.Entity<ReceiptDetails>().HasKey(x => new { x.ComprobanteID, x.ProductoID });

            modelBuilder.Entity<DetalleTributo>().HasKey(x => new { x.ComprobanteID, x.TributoID });

            modelBuilder.Entity<ComprobanteAsociado>()
                .HasRequired(x => x.Comprobante)
                .WithOptional(x => x.AssociatedReceipt);
            modelBuilder.Entity<ComprobanteAsociado>().Property(x => x.NumeroComprobante).IsRequired();

            modelBuilder.Entity<Producto>().Property(x => x.Codigo).IsRequired();
            modelBuilder.Entity<Producto>().Property(x => x.Descripcion).IsRequired();

            modelBuilder.Entity<TipoComprobante>().Property(x => x.ID).HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
            modelBuilder.Entity<TipoComprobante>().Property(x => x.Descripcion).IsRequired();

            modelBuilder.Entity<TipoConcepto>().Property(x => x.ID).HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
            modelBuilder.Entity<TipoConcepto>().Property(x => x.Descripcion).IsRequired();

            modelBuilder.Entity<Iva>().Property(x => x.ID).HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
            modelBuilder.Entity<Iva>().Property(x => x.Descripcion).IsRequired();

            modelBuilder.Entity<TipoDocumento>().Property(x => x.ID).HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
            modelBuilder.Entity<TipoDocumento>().Property(x => x.Descripcion).IsRequired();

            modelBuilder.Entity<TipoMoneda>().Property(x => x.ID).HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
            modelBuilder.Entity<TipoMoneda>().Property(x => x.Codigo).IsRequired();
            modelBuilder.Entity<TipoMoneda>().Property(x => x.Descripcion).IsRequired();

            modelBuilder.Entity<TipoResponsable>().Property(x => x.ID).HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
            modelBuilder.Entity<TipoResponsable>().Property(x => x.Descripcion).IsRequired();

            modelBuilder.Entity<Tributo>().Property(x => x.ID).HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
            modelBuilder.Entity<Tributo>().Property(x => x.Descripcion).IsRequired();

            modelBuilder.Entity<UnidadMedida>().Property(x => x.ID).HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
            modelBuilder.Entity<UnidadMedida>().Property(x => x.Descripcion).IsRequired();
        }
    }
}
