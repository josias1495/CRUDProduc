using CRUDProduc.Model;
using CRUDProduc.Service;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using Xamarin.Forms;
using CRUDProduc.View;

namespace CRUDProduc.ViewModel
{
    public class InicioViewModel : ClaseBase
    {
        Repository Repositorio { get; set; }

        private ObservableCollection<ProductosModel> _Producto;

        public ObservableCollection<ProductosModel> Producto
        {
            get { return _Producto; }
            set { _Producto = value; OnPropertyChanged(); }
        }

        private ObservableCollection<CategoriasModel> _Categoria;

        public ObservableCollection<CategoriasModel> Categoria
        {
            get { return _Categoria; }
            set { _Categoria = value; OnPropertyChanged(); }
        }


        public Command GuardarCommand { get; set; }
        public Command AgregarCommand { get; set; }
        public Command VerCommand { get; set; }
        public ProductosModel ProductoSeleccionado { get; set; }
        public CategoriasModel CategoriaSeleccionada { get; set; }

        public int IDProductoF { get; set; }
        public string DescripcionF { get; set; }
        public string CategoriaF { get; set; }
        public string NombreProductoF { get; set; }


        public InicioViewModel()
        {
            ObtenerProducto();
            ObtenerCategoria();
            ProductoSeleccionado = null;
            CategoriaSeleccionada = null;
            Repositorio = new Repository();
            AgregarCommand = new Command(AgregarProducto);
            GuardarCommand = new Command(GuardarCategoria);
            VerCommand = new Command(VerCategoria);

        }

        public void ObtenerProducto()
        {
            var Repo = new Repository();
            var Resultado = Repo.BuscarProduc(NombreProductoF);
            Producto = new ObservableCollection<ProductosModel>(Resultado);
        }

        public void ObtenerCategoria()
        {
            var Reposi = new Repository();
            var Result = Reposi.BuscadorCate(CategoriaF);
            Categoria = new ObservableCollection<CategoriasModel>(Result);
            
        }




        public InicioViewModel(ProductosModel ProductoParametro) : this()
        {
            ProductoSeleccionado = ProductoParametro;
            if (ProductoParametro != null)
            {
                NombreProductoF = ProductoParametro.NombreProducto;
                
                
            }
        }

        public InicioViewModel( CategoriasModel CategoriaParametro) : this()
        {
            CategoriaSeleccionada = CategoriaParametro;
            if (CategoriaParametro!=null)
            {
                CategoriaF = CategoriaParametro.NombreCategoria;
                DescripcionF = CategoriaParametro.DescripcionCAtegoria;
            }

        }

        void AgregarProducto()
        {
            if (ProductoSeleccionado != null)
            {
                ProductoSeleccionado.NombreProducto = NombreProductoF;
                
                

                var respuestaDB = Repositorio.ActualizarProducto(ProductoSeleccionado);

            }
            else
            {
                var productoNuevo = new ProductosModel();
                productoNuevo.NombreProducto = NombreProductoF;
                
             

                var resultadoDb = Repositorio.CrearProducto(productoNuevo);
                Producto.Add(productoNuevo);
            }
        }

        void GuardarCategoria()
        {
            if (ProductoSeleccionado != null)
            {
                ProductoSeleccionado.NombreProducto = NombreProductoF;



                var respuestaDB = Repositorio.ActualizarProducto(ProductoSeleccionado);

            }
            else if (CategoriaSeleccionada != null)
            {
                CategoriaSeleccionada.NombreCategoria = CategoriaF;
                CategoriaSeleccionada.DescripcionCAtegoria = DescripcionF;
                var respuDB = Repositorio.ActualizarCategoria(CategoriaSeleccionada);
            }
            else
            {
                var productoNuevo = new ProductosModel();
                var CategoriaNueva = new CategoriasModel();
                productoNuevo.NombreProducto = NombreProductoF;
                CategoriaNueva.NombreCategoria = CategoriaF;
                CategoriaNueva.DescripcionCAtegoria = DescripcionF;



                var resultadoDb = Repositorio.CrearProducto(productoNuevo);
                var creandocateBD = Repositorio.CrearCategoria(CategoriaNueva);
            }
        }

        void VerCategoria()
        {
            App.Current.MainPage = new NavigationPage(new CategoriasView());
        }


    }
}
