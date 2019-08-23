using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace CRUDProduc.Model
{
    [Table(nameof(CategoriasModel))]
    public class CategoriasModel
    {
        [PrimaryKey, AutoIncrement,]
        public int IdCategoria { get; set; }
        public string NombreCategoria { get; set; }
        public string DescripcionCAtegoria { get; set; }
    }
}
