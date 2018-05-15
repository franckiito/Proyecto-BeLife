using BeLife.Entity;
using System;
using System.Windows;
using System.Windows.Controls;

namespace BeLife.Interfaz
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class Contratos : Window
    {
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

            LimpiaDatos();

            
        }

        private void LimpiaDatos()
        {
            txtRutBuscar.Text = "";
            txtxNombreCliente.Text = "";
            txtApellidoCliente.Text = "";
            txtObservaciones.Text = "";

            cargaPlanes();
        }

        private void cargaPlanes()
        {
            Negocio.Plan plan = new Negocio.Plan();
            PlanList.ItemsSource = plan.RetornaPlanes();
            PlanList.SelectedIndex = -1;
            
        }

        private void btnAgregaContrato_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
