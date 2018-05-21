using BeLife.Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfBeLife
{
    /// <summary>
    /// Lógica de interacción para ListadoContratos.xaml
    /// </summary>
    public partial class ListadoContratos : Page
    {
        public ListadoContratos()
        {
            InitializeComponent();
            LimpiaDatos();
            CargaContratos();
        }

        private void CargaContratos()
        {
            Contrato contrato = new Contrato();
            grdContratos.ItemsSource = contrato.ReadAll();
        }

        private void LimpiaDatos()
        {
            txtNumeroContrato.Text = "";
            txtRutCliente.Text = "";
            CargarPlan();
        }

        private void CargarPlan()
        {
            Plan plan = new Plan();
            cboPoliza.ItemsSource = plan.ReadAll();
            cboPoliza.Items.Refresh();
            cboPoliza.SelectedIndex = -1;
        }

        private void BtnMantCliMenu_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new MantenedorClientes());

        }

        private void BtnListCliMenu_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new ListadoClientes());

        }


        private void BtnMantContr_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new MantenedorContratos());

        }

        private void BtnListContr_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new ListadoContratos());

        }

        private void BtnMenuLateral_Click(object sender, RoutedEventArgs e)
        {
            FlyMenu.IsOpen = true;

        }

        private void btnBorrarFiltro_Click(object sender, RoutedEventArgs e)
        {
            txtNumeroContrato.Text = "";
            txtRutCliente.Text = "";
            cboPoliza.SelectedIndex = -1;
        }

        private void BtnFiltrar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                //Lee los controles de la interfaz.
                string numeroContrato = txtNumeroContrato.Text;
                string rutCliente = txtRutCliente.Text;

                Plan plan = new Plan();
                
                if(cboPoliza.SelectedIndex >= 0)
                {
                    plan = (Plan)cboPoliza.SelectedItem;
                }

                Contrato contrato = new Contrato();

                //Solo Numero Contrato
                if (String.IsNullOrEmpty(numeroContrato) == false && String.IsNullOrEmpty(rutCliente) != false && !plan.Read())
                {
                    grdContratos.ItemsSource = contrato.ReadAllByNumeroContrato(numeroContrato);
                }
                //Solo Rut Cliente
                if (String.IsNullOrEmpty(numeroContrato) != false && String.IsNullOrEmpty(rutCliente) == false && !plan.Read())
                {
                    grdContratos.ItemsSource = contrato.ReadAllByRutCliente(rutCliente);
                }
                //Solo Poliza
                if (String.IsNullOrEmpty(numeroContrato) != false && String.IsNullOrEmpty(rutCliente) != false && plan.Read())
                {
                    grdContratos.ItemsSource = contrato.ReadAllByPoliza(plan.PolizaActual);
                }
                //Numero contrato y Rut
                if (String.IsNullOrEmpty(numeroContrato) == false && String.IsNullOrEmpty(rutCliente) == false && !plan.Read())
                {
                    grdContratos.ItemsSource = contrato.ReadAllByNumByRut(numeroContrato, rutCliente);
                }
                //Numero contrato y Poliza
                if (String.IsNullOrEmpty(numeroContrato) == false && String.IsNullOrEmpty(rutCliente) != false && plan.Read())
                {
                    grdContratos.ItemsSource = contrato.ReadAllByNumByPol(numeroContrato, plan.PolizaActual);
                }
                //Rut y Poliza
                if (String.IsNullOrEmpty(numeroContrato) != false && String.IsNullOrEmpty(rutCliente) == false && plan.Read())
                {
                    grdContratos.ItemsSource = contrato.ReadAllByRutByPol(rutCliente, plan.PolizaActual);
                }
                //Rut, Sexo y Estado
                if (String.IsNullOrEmpty(numeroContrato) == false && String.IsNullOrEmpty(rutCliente) == false && plan.Read())
                {
                    grdContratos.ItemsSource = contrato.ReadAllByAll(numeroContrato, rutCliente, plan.PolizaActual);
                }
                //NINGUNO
                if (String.IsNullOrEmpty(numeroContrato) != false && String.IsNullOrEmpty(rutCliente) != false && !plan.Read())
                {
                    grdContratos.ItemsSource = contrato.ReadAll();
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Atención", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }
        }
    }
}
