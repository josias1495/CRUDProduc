using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace CRUDProduc.Model
{
    [Table(nameof(ProductosModel))]
    public class ProductosModel : ClaseBase
    {
        private int _IDProducto;

        public int IDProducto
        {
            get { return _IDProducto; }
            set { _IDProducto = value; OnPropertyChanged(); }
        }

        private string _NombreProducto;

        public string NombreProducto
        {
            get { return _NombreProducto; }
            set { _NombreProducto = value; OnPropertyChanged(); }
        }

        private int _IdCategoria;

        public int IdCategoria
        {
            get { return _IdCategoria; }
            set { _IdCategoria = value; OnPropertyChanged(); }
        }


    }
}
