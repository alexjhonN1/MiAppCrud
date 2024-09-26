using Microsoft.Maui.Controls;
using MiAppCrud.Controllers;
using MiAppCrud.Models;

namespace MiAppCrud.Views
{
    public partial class ProductoListPage : ContentPage
    {
        private ProductoController _controller;
        private Producto _productoSeleccionado;

        public ProductoListPage()
        {
            InitializeComponent();
            _controller = new ProductoController();
            LoadProductos();
        }

        private async void LoadProductos()
        {
            ProductosListView.ItemsSource = await _controller.GetAllProductos();
        }

        private async void OnProductTapped(object sender, ItemTappedEventArgs e)
        {
            _productoSeleccionado = (Producto)e.Item;
            await DisplayAlert("Producto Seleccionado", $"Producto: {_productoSeleccionado.Nombre}", "OK");
        }

        private async void OnAddProductClicked(object sender, EventArgs e)
        {
            // Redirige a la vista para agregar un nuevo producto
            await Navigation.PushAsync(new ProductoEditPage());
        }

        private async void OnUpdateProductClicked(object sender, EventArgs e)
        {
            if (_productoSeleccionado != null)
            {
                await Navigation.PushAsync(new ProductoEditPage(_productoSeleccionado));
            }
            else
            {
                await DisplayAlert("Error", "Debe seleccionar un producto para actualizar", "OK");
            }
        }
    }
}
