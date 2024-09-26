using System;
using MiAppCrud.Models;
using MiAppCrud.Controllers;

namespace MiAppCrud.Views
{
    public partial class ProveedorEditPage : ContentPage
    {
        public ProveedorEditPage(Proveedor proveedor = null)
        {
            InitializeComponent();

            // Si se pasa un proveedor, lo vinculamos al BindingContext para editarlo
            if (proveedor == null)
            {
                BindingContext = new Proveedor();  // Para un nuevo proveedor
            }
            else
            {
                BindingContext = proveedor;  // Para editar un proveedor existente
            }
        }

        // Método de guardar (ya existente)
        private async void OnSaveClicked(object sender, EventArgs e)
        {
            var proveedor = (Proveedor)BindingContext;  // Obtenemos el proveedor del BindingContext
            ProveedorController proveedorController = new ProveedorController();
            proveedorController.AddOrUpdateProveedor(proveedor);

            await DisplayAlert("Éxito", "Proveedor guardado exitosamente", "OK");
            await Navigation.PopAsync();
        }

        // Nuevo método para actualizar
        private async void OnUpdateClicked(object sender, EventArgs e)
        {
            var proveedor = (Proveedor)BindingContext;
            ProveedorController proveedorController = new ProveedorController();

            proveedorController.AddOrUpdateProveedor(proveedor); // Se utiliza el mismo método

            await DisplayAlert("Actualización", "Proveedor actualizado exitosamente", "OK");
            await Navigation.PopAsync();
        }
    }
}
