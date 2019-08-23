using System;
using System.Collections.Generic;
using System.Text;
using SQLite;
using System.IO;
using CRUDProduc.Model;
using System.Threading.Tasks;

namespace CRUDProduc.Service
{
    public class Repository
    {
        SQLiteConnection BaseDeDatos;

        public Repository()
        {
            var UbicacionBD = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "CRUDProduc.db3");
            BaseDeDatos = new SQLiteConnection(UbicacionBD);
            BaseDeDatos.CreateTable<ProductosModel>();
            BaseDeDatos.CreateTable<CategoriasModel>();
        }

        //Insertar 

        public int CrearProducto(ProductosModel NuevoProdcuto)
        {
            return BaseDeDatos.Insert(NuevoProdcuto);
        }

        public int CrearCategoria(CategoriasModel NuevaCategoria)
        {
            return BaseDeDatos.Insert(NuevaCategoria);
        }

        //Actualizar

        public int ActualizarProducto(ProductosModel ProductoIdentificado)
        {
            return BaseDeDatos.Update(ProductoIdentificado);
        }

        public int ActualizarCategoria(CategoriasModel CategoriaIdentificada)
        {
            return BaseDeDatos.Update(CategoriaIdentificada);
        }

        //Leer Todas los Productos. 

        public List<ProductosModel> BuscarProduc(string text)
        {
            return BaseDeDatos.Table<ProductosModel>().ToList();
        }

        //Leer solo un producto 

        public ProductosModel LeerProducto(int IdProducto)
        {
            return BaseDeDatos.Table<ProductosModel>().Where(n => n.IDProducto == IdProducto).FirstOrDefault();
        }

        //Leer Todas las Categorias. 

        public List<CategoriasModel> BuscadorCate(string text)
        {
            return BaseDeDatos.Table<CategoriasModel>().ToList();
        }

        //Leer solo una Categoria 

        public CategoriasModel LeerCategoria(int IdCategoria)
        {
            return BaseDeDatos.Table<CategoriasModel>().Where(n => n.IdCategoria == IdCategoria).FirstOrDefault();
        }
    }
}
