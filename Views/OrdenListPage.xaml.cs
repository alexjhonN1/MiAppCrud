using System;
using System.Collections.ObjectModel;
using Microsoft.Maui.Controls;

namespace MiAppCrud.Views
{
    public partial class OrdenListPage : ContentPage
    {
        public ObservableCollection<Orden> Ordenes { get; set; }


        public OrdenListPage()
        {
            InitializeComponent();

            Ordenes = new ObservableCollection<Orden>
            {
                new Orden { Fecha = DateTime.Now.AddDays(-1).ToString("dd/MM/yyyy") },
                new Orden { Fecha = DateTime.Now.ToString("dd/MM/yyyy") }
            };

            OrdenesListView.ItemsSource = Ordenes;
        }

        private void OnAddOrderClicked(object sender, EventArgs e)
        {
            Ordenes.Add(new Orden { Fecha = DateTime.Now.ToString("dd/MM/yyyy") });
        }

        private void OnOrderTapped(object sender, ItemTappedEventArgs e)
        {
            if (e.Item == null)
                return;

            var ordenSeleccionada = e.Item as Orden;
            DisplayAlert("Orden seleccionada", $"Fecha: {ordenSeleccionada.Fecha}", "OK");

            ((ListView)sender).SelectedItem = null;
        }
    }

    public class Orden
    {
        public string Fecha { get; set; }
    }
}