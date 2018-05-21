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
            CargarPlan();
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

                Cliente cliente = new Cliente() {
                    Rut = txtRut.Text
                };

                if (cliente.Read())
                {
                    txtNombre.Text = cliente.Nombres;
                    txtApellido.Text = cliente.Apellidos;
                }

                Contrato contrato = new Contrato()
                {
                    Creacion = DateTime.Today,
                    Termino = (DateTime)FechaTermino.SelectedDate,
                    InicioVigencia = DateTime.Today,
                    FinVigencia = DateTime.Today,
                    PrimaMensual = float.Parse(txtPrimaMensual.Text),
                    Observaciones = txtObservacion.Text,
                    EstaVigente = (bool)CheckVigente.IsChecked,
                    ConDeclaracionDeSalud = (bool)CheckDeclaracionSalud.IsChecked

                };

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
            InicioVigencia.SelectedDate = null;
            cboPlan.SelectedIndex = -1;
            txtPrimaAnual.Text = "";
            txtPrimaMensual.Text = "";
            txtObservacion.Text = "";
            txtNombre.Text = "";
            txtApellido.Text = "";
        }

        private void BtnBuscarContr_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Contrato con = new Contrato()
                {
                    Numero = txtNumeroContrato.Text
                };
                if (con.Read())
                {
                    txtNumeroContrato.Text = con.Numero;
                    FechaInicio.SelectedDate = con.Creacion;
                    FechaTermino.SelectedDate = con.Termino;
                    cboPlan.SelectedIndex = int.Parse(con.PlanAsociado.Id);
                    txtPrimaAnual.Text = con.PrimaAnual+"";
                    txtPrimaMensual.Text = con.PrimaMensual+"";
                    txtObservacion.Text = con.Observaciones;
                    txtNombre.Text = con.Titular.Nombres;
                    txtApellido.Text = con.Titular.Apellidos;
                    CheckVigente.IsChecked = con.EstaVigente;
                    CheckDeclaracionSalud.IsChecked = con.ConDeclaracionDeSalud;
                    MessageBox.Show("Datos del Contrato fueron cargados correctamente.", "Información", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else
                {
                    MessageBox.Show("Datos del contrato no fueron encontrados.", "Información", MessageBoxButton.OK, MessageBoxImage.Information);
                }

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Atención", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }
        }

        private void BtnEliminarContr_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Contrato con = new Contrato()
                {
                    Numero = txtNumeroContrato.Text
                };
                if (con.Delete())
                {
                    MessageBox.Show("El contrato de numero " + con.Numero + " fue eliminado.", "Información", MessageBoxButton.OK, MessageBoxImage.Information);
                    LimpiaDatos();
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Atención", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }
            
        }

        private void BtnActualizarContr_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Contrato con = new Contrato()
                {
                    Numero = txtNumeroContrato.Text,
                    Creacion = DateTime.Today,
                    InicioVigencia = (DateTime)InicioVigencia.SelectedDate,
                    PrimaAnual = float.Parse(txtPrimaAnual.Text),
                    PrimaMensual = float.Parse(txtPrimaMensual.Text),
                    Observaciones = txtObservacion.Text
                };

                if (con.Update())
                {
                    MessageBox.Show("Cliente actualizado", "Información", MessageBoxButton.OK, MessageBoxImage.Information);
                    LimpiaDatos();
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Atención", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }
        }

        private void CargarPlan()
        {
            Plan plan = new Plan();
            cboPlan.ItemsSource = plan.ReadAll();
            cboPlan.Items.Refresh();
            cboPlan.SelectedIndex = -1;
        }
    }
}
