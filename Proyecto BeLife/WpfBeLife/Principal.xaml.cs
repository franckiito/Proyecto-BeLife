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
using MahApps.Metro.Controls;
using WpfBeLife.Properties;
using MahApps.Metro.Controls.Dialogs;

namespace WpfBeLife
{
    /// <summary>
    /// Lógica de interacción para Principal.xaml
    /// </summary>
    public partial class Principal : Page
    {

        public Principal()
        {
            InitializeComponent();

        }


        private void BtnMantCli_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new MantenedorClientes());


        }

        private void BtnListCli_Click(object sender, RoutedEventArgs e)
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

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void BtnMantCli_IsMouseCapturedChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            
        }


        private void BtnMantCli_MouseEnter(object sender, MouseEventArgs e)
        {
            

            if (BtnMantCli.IsMouseOver)
            {
                //BtnMantCli.Background = Brushes.DarkOrange;
            }

        }

        private void BtnMantCli_MouseLeave(object sender, MouseEventArgs e)
        {
            //BtnMantCli.Background = 
        }
    }
    
}
