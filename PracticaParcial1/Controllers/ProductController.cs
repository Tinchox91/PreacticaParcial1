using MVC_conJson.Models;
using PracticaParcial1.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticaParcial1.Controllers
{
    public class ProductController
    {
        public List<Producto> LoadProductList() => ProductView.CargarProductos();
        public void ShowProductList(List<Producto> list) => ProductView.MostarProductos(list);
    }
}
