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
    /// Lógica de interacción para ListadoClientes.xaml
    /// </summary>
    public partial class ListadoClientes : Page
    {

        public ListadoClientes()
        {
            InitializeComponent();
            LimpiaDatos();
            CargaClientes();

        }

        private void CargaClientes()
        {
            Cliente cliente = new Cliente();
            grdClientes.ItemsSource = cliente.ReadAll();

        }

        private void LimpiaDatos()
        {
            txtRut.Text = "";
            CargaDatos();
        }

        private void CargaDatos()
        {
            Sexo sexo = new Sexo();
            cboSexo.ItemsSource = sexo.ReadAll();
            cboSexo.SelectedIndex = -1;

            EstadoCivil estadoCivil = new EstadoCivil();
            cboEstado.ItemsSource = estadoCivil.ReadAll();
            cboEstado.SelectedIndex = -1;
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

        private void btnFiltrar_Click(object sender, RoutedEventArgs e)
        {
            try
            {

                //Lee los controles de la interfaz.
                string rut = txtRut.Text;

                Sexo sexo = new Sexo();
                sexo.Id = cboSexo.SelectedIndex + 1;

                EstadoCivil estado = new EstadoCivil();
                estado.Id = cboEstado.SelectedIndex + 1;

                Cliente cliente = new Cliente();

                //Solo Rut
                if (String.IsNullOrEmpty(rut) == false && !sexo.Read() && !estado.Read())
                {
                    grdClientes.ItemsSource = cliente.ReadAll(rut);
                }
                //Solo Sexo
                if (String.IsNullOrEmpty(rut) != false && sexo.Read() && !estado.Read())
                {
                    grdClientes.ItemsSource = cliente.ReadAllBySexo(sexo.Id);
                }
                //Solo Estado
                if (String.IsNullOrEmpty(rut) != false && !sexo.Read() && estado.Read())
                {
                    grdClientes.ItemsSource = cliente.ReadAllByEstadoCivil(estado.Id);
                }
                //Rut y Sexo
                if (String.IsNullOrEmpty(rut) == false && sexo.Read() && !estado.Read())
                {
                    grdClientes.ItemsSource = cliente.ReadAllRutSexo(rut, sexo.Id);
                }
                //Rut y Estado
                if (String.IsNullOrEmpty(rut) == false && !sexo.Read() && estado.Read())
                {
                    grdClientes.ItemsSource = cliente.ReadAllRutEstado(rut, estado.Id);
                }
                //Sexo y Estado
                if (String.IsNullOrEmpty(rut) != false && sexo.Read() && estado.Read())
                {
                    grdClientes.ItemsSource = cliente.ReadAll(sexo.Id, estado.Id);
                }
                //Rut, Sexo y Estado
                if (String.IsNullOrEmpty(rut) == false && sexo.Read() && estado.Read())
                {
                    grdClientes.ItemsSource = cliente.ReadAll(rut, sexo.Id, estado.Id);
                }
                //NINGUNO
                if (String.IsNullOrEmpty(rut) != false && !sexo.Read() && !estado.Read())
                {
                    grdClientes.ItemsSource = cliente.ReadAll();
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Atención", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }
        }

        private void btnBorrarFiltro_Click(object sender, RoutedEventArgs e)
        {
            txtRut.Text = "";
            cboEstado.SelectedIndex = -1;
            cboSexo.SelectedIndex = -1;
        }
    }
}
