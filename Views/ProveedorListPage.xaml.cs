using MiAppCrud.Models;
using MiAppCrud.Controllers;
using System.Collections.ObjectModel;

namespace MiAppCrud.Views
{
    public partial class ProveedorListPage : ContentPage
    {
        private ProveedorController _proveedorController;
        private ObservableCollection<Proveedor> _proveedores;

        public ProveedorListPage()
        {
            InitializeComponent();

            _proveedorController = new ProveedorController();
            _proveedores = new ObservableCollection<Proveedor>(_proveedorController.GetAllProveedores());

            ProveedoresListView.ItemsSource = _proveedores;
        }

        // Evento al seleccionar un proveedor de la lista
        private async void OnProveedorSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem is Proveedor proveedor)
            {
                // Navegar a la página de edición con el proveedor seleccionado
                await Navigation.PushAsync(new ProveedorEditPage(proveedor));
            }
        }

        // Evento al hacer clic en "Agregar Proveedor"
        private async void OnAddProveedorClicked(object sender, EventArgs e)
        {
            // Navegar a la página de edición sin un proveedor (para agregar uno nuevo)
            await Navigation.PushAsync(new ProveedorEditPage());
        }

        // Método para actualizar la lista cuando regresa a la página
        protected override void OnAppearing()
        {
            base.OnAppearing();
            _proveedores.Clear();
            foreach (var proveedor in _proveedorController.GetAllProveedores())
            {
                _proveedores.Add(proveedor);  // Actualiza la lista con los proveedores actuales
            }
        }
    }
}
