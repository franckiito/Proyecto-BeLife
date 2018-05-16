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

using System.Data.Linq;
using System.ComponentModel;
using System.Collections;
using BeLife.Negocio;

namespace BeLife.Interfaz
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class RegistraCliente : Window
    {

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

            LimpiaDatos();
            
        }

        private void LimpiaDatos()
        {
            txtRut.Text = "";
            txtNombres.Text = "";
            txtApellidos.Text = "";
            FechaNacimiento.SelectedDate = DateTime.Today ;
            cargaDatos();
        }

        private void cargaDatos()
        {
            Negocio.Sexo sexo = new Negocio.Sexo();
            SexoList.ItemsSource = sexo.ReadAll();
            SexoList.SelectedIndex = -1;

            Negocio.EstadoCivil estadoCivil = new Negocio.EstadoCivil();
            EstadoCivilList.ItemsSource = estadoCivil.ReadAll();
            EstadoCivilList.SelectedIndex = -1;
        }

        public RegistraCliente()
        {
            InitializeComponent();
        }

        private void btnRegistrar_Click(object sender, RoutedEventArgs e)
        {

            Negocio.Cliente cliente = new Negocio.Cliente()
            {
                Rut = txtRut.Text,
                Nombres = txtNombres.Text,
                Apellidos = txtApellidos.Text,
                FechaDeNacimiento = (DateTime)FechaNacimiento.SelectedDate,
                Sexo = AsignaSexo(),
                EstadoCivil = AsignaEstadoCivil(EstadoCivilList.SelectedIndex + 1)  
            };

            if (cliente.Create())
            {
                MessageBox.Show("Cliente agregado", "Información", MessageBoxButton.OK, MessageBoxImage.Information);
                LimpiaDatos();
            }
            else
            {
                MessageBox.Show("El Cliente no se pudo agregar", "Atención", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }
        }

        private EstadoCivil AsignaEstadoCivil(int id)
        {
            EstadoCivil estado = new EstadoCivil();

            estado.Read();

            return estado;
        }

        private Sexo AsignaSexo()
        {
            Sexo sexo = new Sexo();

            sexo.Read();

            return sexo;
        }

        private bool ValidaDatos(string rut, string nombres, string apellidos, DateTime fecha, int s, int est)
        {
            bool valida = true;

            if(!ValidaRut( rut ))
            {
                MessageBox.Show("Debe ingresar Rut", "Registro Cliente", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                valida = false;
            }
            else
            {
                if (!ValidaNombre( nombres))
                {
                    MessageBox.Show("Debe ingresar Nombre", "Registro Cliente", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                    valida = false;
                }
                else
                {
                    if (!ValidaApellido( apellidos ))
                    {
                        MessageBox.Show("Debe ingresar Apellido", "Registro Cliente", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                        valida = false;
                    }
                    else
                    {
                        if (!ValidaFechaNacimiento(fecha) )
                        {
                            MessageBox.Show("Debe ser mayor de edad para registrarse", "Registro Cliente", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                            valida = false;

                        }
                        else
                        {
                            if (!ValidaSexo(s))
                            {
                                MessageBox.Show("Debe seleccionar sexo para registrarse", "Registro Cliente", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                                valida = false;
                            }
                            else
                            {
                                if (!ValidaEstadoCivil(est))
                                {
                                    MessageBox.Show("Debe seleccionar estado civil para registrarse", "Registro Cliente", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                                    valida = false;
                                }
                            }
                        }
                    }
                }
            }
            
                

            return valida;
        }

        private bool ValidaEstadoCivil(int est)
        {
            bool valida = false;

            if (est != -1)
            {
                valida = true;
            }

            return valida;
        }

        private bool ValidaSexo(int s)
        {
            bool valida = false;

            if (s != -1)
            {
                valida = true;
            }

            return valida;
        }

        public bool ValidaFechaNacimiento(DateTime fechaNacimiento)
        {
            bool valida = false;
            DateTime date = DateTime.Today;

            if(CalcularEdad(fechaNacimiento, date) >= 18)
            {
                valida = true;
            }

            return valida;
        }

        public int CalcularEdad(DateTime birthDate, DateTime now)
        {
            int age = now.Year - birthDate.Year;
            if (now.Month < birthDate.Month || (now.Month == birthDate.Month && now.Day < birthDate.Day))
                age--;
            return age;
        }

        private bool ValidaApellido(string _apellido)
        {
            bool valida = false;

            //Tiene datos nombre
            if (String.IsNullOrEmpty(_apellido) == false)
            {
                valida = true;
            }

            return valida;
        }

        private bool ValidaNombre(string _nombre)
        {
            bool valida = false;

            //Tiene datos nombre
            if (String.IsNullOrEmpty(_nombre) == false)
            {
                valida = true;
            }

            return valida;
        }

        private bool ValidaRut(string _rut)
        {
            bool valida = false;

            //Tiene datos rut
            if(String.IsNullOrEmpty(_rut) == false)
            {
                valida = true;
            }

            return valida;
        }

        private void btnBuscarCliente_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void CargaEstado(int idEstadoCivil)
        {
            Negocio.EstadoCivil estado = new Negocio.EstadoCivil();
            estado.Id = idEstadoCivil;

            if (!estado.Read())
            {
                throw new Exception("Error al leer estado.");
            }

            EstadoCivilList.SelectedIndex = estado.Id - 1;

        }

        private void CargaSexo(int idSexo)
        {
            Negocio.Sexo sexo = new Negocio.Sexo();

            sexo.Id = idSexo ;

            if (!sexo.Read())
            {
                throw new Exception("Error al leer Sexo.");
            }

            SexoList.SelectedIndex = sexo.Id - 1;

        }


        private void btnActualizar_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void btnEliminar_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void btnIrPrincipal_Click(object sender, RoutedEventArgs e)
        {
            VentanaPrincipal ventanaPrincipal = new VentanaPrincipal();
            App.Current.MainWindow = ventanaPrincipal;
            this.Close();
            ventanaPrincipal.Show();
        }

        private void btnIrListaClientes_Click(object sender, RoutedEventArgs e)
        {
            ListadoClientes listadoClientes = new ListadoClientes();
            App.Current.MainWindow = listadoClientes;
            this.Close();
            listadoClientes.Show();
        }
    }
}
