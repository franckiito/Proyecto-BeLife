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

namespace BeLife.Interfaz
{
    /// <summary>
    /// Lógica de interacción para VentanaPrincipal.xaml
    /// </summary>
    public partial class ListadoContratos : Window
    {
        public ListadoContratos()
        {
            InitializeComponent();
        }

        private void btnIrPrincipal_Click(object sender, RoutedEventArgs e)
        {
            VentanaPrincipal ventana = new VentanaPrincipal();
            App.Current.MainWindow = ventana;
            this.Close();
            ventana.Show();
        }
    }
}
