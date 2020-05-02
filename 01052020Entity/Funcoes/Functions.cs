using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _01052020Entity.Entidades;
using _01052020Entity.Data;

namespace _01052020Entity.Funcoes
{
    public class Functions
    {

        public static void AddDataBase()
        {
            DataContext db = new DataContext();

            Marca marca = new Marca()
            {
                Nome = "Adidas"
            };

            db.marcas.Add(marca);

            Produto prod = new Produto()
            {
                Nome = "Futsal Cr7 3",
                Preco = 30m,
                IdMarca = marca.Id,
                Marca = marca
            };

            db.produtos.Add(prod);

            db.SaveChanges();
        }


        public static void SelectInsert()
        {
            DataContext db = new DataContext();

            Marca marca = db.marcas.Find(1);

            Produto prod = new Produto()
            {
                Nome = "Futsal Cr7 2",
                Preco = 40m,
                Marca = marca,
                IdMarca = marca.Id
            };

            db.produtos.Add(prod);

            db.SaveChanges();
        }

        public static void Update()
        {
            DataContext db = new DataContext();

            Produto prod = db.produtos.Find(1);
            prod.Preco = 60m;

            db.SaveChanges();
        }

        public static void UpdateEntityState()
        {
            DataContext db = new DataContext();

            Marca marca = db.marcas.Find(2);

            Produto prod = new Produto()
            {
                Id = 2,
                Nome = "Futsal cr7 modificado",
                Preco = 65m,
                Marca = marca,
                IdMarca = marca.Id
            };

            db.Entry(prod).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
            
        }

        public static void Delete()
        {
            DataContext db = new DataContext();

            Produto prod = db.produtos.Find(3);

            db.produtos.Remove(prod);

            db.SaveChanges();
            
        }

        public static void DeleteEntityState()
        {
            DataContext db = new DataContext();

            Marca marca = db.marcas.Find(1);

            Produto prod = new Produto()
            {
                Id = 1,
                Nome = "teste",
                Marca = marca,
                Preco = 50m,
                IdMarca = marca.Id
                
            };

            db.Entry(prod).State = System.Data.Entity.EntityState.Deleted;
            db.SaveChanges();
        }

        public static void AlterandoMarcaDeProduto()
        {
            DataContext db = new DataContext();

            Marca marca = db.marcas.Find(1);

            Produto prod = db.produtos.Find(2);

            prod.Marca = marca;

            db.SaveChanges();
        }

        public static void InsertMarcaWithListProduto()
        {
            DataContext db = new DataContext();

            Marca marca = new Marca()
            {
                Nome = "Puma",
                produtos = new List<Produto>()
            };

            marca.produtos.Add(new Produto()
            {
                Nome = "Tenis puma 1",
                Preco = 37m,
                IdMarca = marca.Id
            });

            marca.produtos.Add(new Produto()
            {
                Nome = "Tenis puma 2",
                Preco = 35m,
                IdMarca = marca.Id
            });

            marca.produtos.Add(new Produto()
            {
                Nome = "Tenis puma 3",
                Preco = 30m,
                IdMarca = marca.Id
            });

            marca.produtos.Add(new Produto()
            {
                Nome = "Tenis puma 4",
                Preco = 40m,
                IdMarca = marca.Id
            });

            db.marcas.Add(marca);

            db.SaveChanges();
        }

        public static void ListarMarcaProduto()
        {
            DataContext db = new DataContext();

            Produto prod = db.produtos.Find(4);

            Console.WriteLine(prod.Marca.Nome);
        }

        public static void ListarProdutoMarca()
        {
            DataContext db = new DataContext();

            Marca marca = db.marcas.Find(3);

            marca.produtos.ToList().ForEach(p => Console.WriteLine(p.Nome));
        }

        public static void DeletandoMarca()
        {
            DataContext db = new DataContext();

            Marca marca = db.marcas.Find(3);

            db.marcas.Remove(marca);

            db.SaveChanges();
        }

    }
}
