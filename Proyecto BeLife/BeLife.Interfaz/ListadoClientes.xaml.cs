using BeLife.Entity;
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
    /// Lógica de interacción para ListadoClientes.xaml
    /// </summary>
    public partial class ListadoClientes : Window
    {
        public ListadoClientes()
        {
            InitializeComponent();
            LimpiaDatos();
            CargaClientes();

            string rut = txtRut.Text;
            string sexo = SexoList.Text;
            string estado = EstadoCivilList.Text;


        }

        private void CargaClientes()
        {


            try
            {
                using (BeLifeEntities context = new BeLifeEntities())
                {
                    
                    var query = (from c in context.Cliente

                                 select new
                                 {
                                     c.RutCliente,
                                     c.Nombres,
                                     c.Apellidos,
                                     FechaNacimiento = (c.FechaNacimiento.Day + "/" + ((c.FechaNacimiento.Month < 10) ? ("0" + c.FechaNacimiento.Month) : (c.FechaNacimiento.Month.ToString())) + "/" + c.FechaNacimiento.Year),
                                     EstadoCivil = c.EstadoCivil.Descripcion,
                                     Sexo = c.Sexo.Descripcion,
                                 });
                    var result = query.ToList();

                    ClientesList.ItemsSource = result;
                    

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }



        }

        private void LimpiaDatos()
        {
            txtRut.Text = "";
            CargaDatos();
        }

        private void CargaDatos()
        {
            Negocio.Sexo sexo = new Negocio.Sexo();
            SexoList.ItemsSource = sexo.retornaSexos();
            SexoList.SelectedIndex = -1;

            Negocio.EstadoCivil estadoCivil = new Negocio.EstadoCivil();
            EstadoCivilList.ItemsSource = estadoCivil.RetornaEstadosCiviles();
            EstadoCivilList.SelectedIndex = -1;
        }

        private void btnIrPrincipal_Click(object sender, RoutedEventArgs e)
        {
            VentanaPrincipal ventanaPrincipal = new VentanaPrincipal();
            App.Current.MainWindow = ventanaPrincipal;
            this.Close();
            ventanaPrincipal.Show();
        }

        private void btnIrRegistra_Click(object sender, RoutedEventArgs e)
        {
            RegistraCliente registraCliente = new RegistraCliente();
            App.Current.MainWindow = registraCliente;
            this.Close();
            registraCliente.Show();
        }

        private void btnBuscar_Click(object sender, RoutedEventArgs e)
        {
            
        }



        private bool ValidaRut(string _rut)
        {
            bool valida = false;

            //Tiene datos rut
            if (String.IsNullOrEmpty(_rut) == false)
            {
                valida = true;
            }

            return valida;
        }

        private bool ValidaSexo(string _sexo)
        {
            bool valida = false;

            //Tiene datos rut
            if (String.IsNullOrEmpty(_sexo) == false)
            {
                valida = true;
            }

            return valida;
        }

        private bool ValidaEstado(string _estado)
        {
            bool valida = false;

            //Tiene datos rut
            if (String.IsNullOrEmpty(_estado) == false)
            {
                valida = true;
            }

            return valida;
        }

    }
}
