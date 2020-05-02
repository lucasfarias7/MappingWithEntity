using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Data.Entity.Validation;
using _01052020Entity.Entidades;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace _01052020Entity.Data
{
    public class DataContext : DbContext
    {
        private static string ConexaoString = @"Data Source=DESKTOP-11CCP3D\SQLEXPRESS;Initial Catalog=ProdutoMarca;Integrated Security=true;Connect Timeout=30";

        public DataContext() : base(ConexaoString)
        {
            Database.SetInitializer<DataContext>(new CreateDatabaseIfNotExists<DataContext>());
            Database.Initialize(false);
            Database.Log = d => System.Diagnostics.Debug.WriteLine(d);
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
        }

        public override int SaveChanges()
        {
            try
            {
                return base.SaveChanges();
            }
            catch (DbEntityValidationException e)
            {
                foreach (var eve in e.EntityValidationErrors)
                {
                    Console.WriteLine("Entidade do tipo \"{0}\" no estado \"{1}\" tem os seguintes erros de validação:",
                        eve.Entry.Entity.GetType().Name, eve.Entry.State);
                    foreach (var ve in eve.ValidationErrors)
                    {
                        Console.WriteLine("- Property: \"{0}\", Erro: \"{1}\"",
                            ve.PropertyName, ve.ErrorMessage);
                    }
                }
                throw;
            }
        }


        public DbSet<Produto> produtos { get; set; }

        public DbSet<Marca> marcas { get; set; }

    }
}
