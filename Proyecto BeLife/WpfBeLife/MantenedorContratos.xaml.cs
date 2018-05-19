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
    /// Lógica de interacción para MantenedorContratos.xaml
    /// </summary>
    public partial class MantenedorContratos : Page
    {
        public MantenedorContratos()
        {
            InitializeComponent();
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

        private void BtnCrearContr_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Contrato contrato = new Contrato()
                {
                    Numero = txtNumeroContrato.Text,
                    Creacion = (DateTime)FechaInicio.SelectedDate,
                    Termino = (DateTime)FechaTermino.SelectedDate,
                    InicioVigencia = DateTime.Today,
                    FinVigencia = DateTime.Today,
                    PrimaAnual = float.Parse(txtPrimaAnual.Text),
                    PrimaMensual = float.Parse(txtPrimaMensual.Text),
                    Observaciones = txtObservacion.Text
                };

                Cliente cliente = new Cliente() {
                    Rut = txtRut.Text
                };

                if (cliente.Read())
                {
                    txtNombre.Text = cliente.Nombres;
                    txtApellido.Text = cliente.Apellidos;
                }

                if (contrato.Create())
                {
                    MessageBox.Show("Contrato agregado", "Información", MessageBoxButton.OK, MessageBoxImage.Information);
                    LimpiaDatos();
                }
                else
                {
                    MessageBox.Show("El Contrato no se pudo agregar.", "Atención", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Atención", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }
        }

        private void LimpiaDatos()
        {
            txtNumeroContrato.Text = "";
            FechaInicio.SelectedDate = null;
            FechaTermino.SelectedDate = null;
            cboPlan.SelectedIndex = -1;
            txtPrimaAnual.Text = "";
            txtPrimaMensual.Text = "";
            txtObservacion.Text = "";
            txtNombre.Text = "";
            txtApellido.Text = "";
        }
    }
}
