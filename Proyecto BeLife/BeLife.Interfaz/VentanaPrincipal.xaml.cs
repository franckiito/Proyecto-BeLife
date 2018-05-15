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
using System.Windows.Shapes;

namespace BeLife.Interfaz
{
    /// <summary>
    /// Lógica de interacción para VentanaPrincipal.xaml
    /// </summary>
    public partial class VentanaPrincipal : Window
    {
        public VentanaPrincipal()
        {
            InitializeComponent();
        }

        private void btnIrRegistraCliente_Click(object sender, RoutedEventArgs e)
        {
            RegistraCliente registraCliente = new RegistraCliente();
            App.Current.MainWindow = registraCliente;
            this.Close();
            registraCliente.Show();
        }

        private void btnIrListaCliente_Click(object sender, RoutedEventArgs e)
        {
            ListadoClientes listadoClientes = new ListadoClientes();
            App.Current.MainWindow = listadoClientes;
            this.Close();
            listadoClientes.Show();
        }

        private void btnIrContrato_Click(object sender, RoutedEventArgs e)
        {
            Contratos contratos = new Contratos();
            App.Current.MainWindow = contratos;
            this.Close();
            contratos.Show();
        }

        private void btnIrListaContratos_Click(object sender, RoutedEventArgs e)
        {
            ListadoContratos listadoContratos = new ListadoContratos();
            App.Current.MainWindow = listadoContratos;
            this.Close();
            listadoContratos.Show();
        }
    }
}
