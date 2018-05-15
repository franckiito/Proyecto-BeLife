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
            SexoList.ItemsSource = sexo.retornaSexos();
            SexoList.SelectedIndex = -1;

            Negocio.EstadoCivil estadoCivil = new Negocio.EstadoCivil();
            EstadoCivilList.ItemsSource = estadoCivil.RetornaEstadosCiviles();
            EstadoCivilList.SelectedIndex = -1;
        }

        public RegistraCliente()
        {
            InitializeComponent();
        }

        private void btnRegistrar_Click(object sender, RoutedEventArgs e)
        {
            DateTime fecha = DateTime.Today;

            string rut = txtRut.Text;
            string nombres = txtNombres.Text;
            string apellidos = txtApellidos.Text;
            Negocio.Sexo s = new Negocio.Sexo();
            Negocio.EstadoCivil est = new Negocio.EstadoCivil();

            if (FechaNacimiento.SelectedDate.ToString() == "")
            {
                MessageBox.Show("Debe ingresar Fecha", "Registro Cliente", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }
            else
            {
                fecha = (DateTime)FechaNacimiento.SelectedDate;

                if (ValidaDatos(rut, nombres, apellidos, fecha, SexoList.SelectedIndex, EstadoCivilList.SelectedIndex))
                {
                    Negocio.Cliente cliente = new Negocio.Cliente();
                    if (cliente.BuscarCliente(rut) == null)
                    {
                        s = (Negocio.Sexo)SexoList.SelectionBoxItem;
                        est = (Negocio.EstadoCivil)EstadoCivilList.SelectionBoxItem;
                        cliente.Rut = rut;
                        cliente.Nombres = nombres;
                        cliente.Apellidos = apellidos;
                        cliente.FechaNacimiento = fecha;
                        cliente.sexo = s;
                        cliente.estadoCivil = est;

                        if (cliente.AgregaCliente(cliente))
                        {
                            MessageBox.Show("El Cliente fue registrado exitosamente!!!", "Registro Cliente", MessageBoxButton.OK, MessageBoxImage.Information);
                            LimpiaDatos();
                        }
                        else
                        {
                            MessageBox.Show("Hubo un error al registrar el cliente", "Registro Cliente", MessageBoxButton.OK, MessageBoxImage.Error);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Ya existe el cliente ingresado", "Registro Cliente", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                   
                }
            }       
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
            string rut = txtRut.Text;

            if (ValidaRut(rut) )
            {

                Negocio.Cliente cliente = new Negocio.Cliente();
                cliente = cliente.BuscarCliente(rut);
                if(cliente != null )
                {
                    txtNombres.Text = cliente.Nombres.ToString();
                    txtApellidos.Text = cliente.Apellidos.ToString();
                    FechaNacimiento.SelectedDate = cliente.FechaNacimiento;

                    CargaSexo(cliente.sexo.IdSexo);
                    CargaEstado(cliente.estadoCivil.IdEstadoCivil);

                }
                else
                {
                    MessageBox.Show("El rut ingresado no existe.", "Busca Cliente", MessageBoxButton.OK, MessageBoxImage.Information);
                    LimpiaDatos();
                }
                

            }
            else
            {
                MessageBox.Show("Debe ingresar Rut", "Registro Cliente", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }
        }

        private void CargaEstado(int idEstadoCivil)
        {
            Negocio.EstadoCivil estado = new Negocio.EstadoCivil();
            estado = estado.BuscarEstado(idEstadoCivil);

            EstadoCivilList.SelectedIndex = estado.IdEstadoCivil - 1;
            //for (int i = 0; i < EstadoCivilList.Items.Count; i++)
            //{
            //    SexoList.SelectedIndex = i;
            //    if (EstadoCivilList.SelectionBoxItem.Equals(estado))
            //    {
            //        EstadoCivilList.SelectedIndex = i;
            //    }
            //}
        }

        private void CargaSexo(int idSexo)
        {
            Negocio.Sexo sexo = new Negocio.Sexo();
            sexo = sexo.buscarSexo(idSexo);

            SexoList.SelectedIndex = sexo.IdSexo - 1;
            //for (int i = 0; i < SexoList.Items.Count; i++)
            //{
            //    SexoList.SelectedIndex = i;
            //    if (SexoList.SelectionBoxItem.Equals(sexo))
            //    {
            //        SexoList.SelectedIndex = i;
            //    }
            //}
        }


        private void btnActualizar_Click(object sender, RoutedEventArgs e)
        {
            DateTime fecha = DateTime.Today;

            string rut = txtRut.Text;
            string nombres = txtNombres.Text;
            string apellidos = txtApellidos.Text;
            Negocio.Sexo s = (Negocio.Sexo)SexoList.SelectionBoxItem;
            Negocio.EstadoCivil est = (Negocio.EstadoCivil)EstadoCivilList.SelectionBoxItem;

            if (FechaNacimiento.SelectedDate.ToString() == "")
            {
                MessageBox.Show("Debe ingresar Fecha", "Actualiza Cliente", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }
            else
            {
                fecha = (DateTime)FechaNacimiento.SelectedDate;

                if (ValidaDatos(rut, nombres, apellidos, fecha, s.IdSexo, est.IdEstadoCivil))
                {
                    Negocio.Cliente cliente = new Negocio.Cliente();

                    if(cliente.BuscarCliente(rut) != null)
                    {
                        //Cliente con los datos capturados para actualizar
                        cliente.Rut = rut;
                        cliente.Nombres = nombres;
                        cliente.Apellidos = apellidos;
                        cliente.FechaNacimiento = fecha;
                        
                        cliente.sexo = s;
                        cliente.estadoCivil = est;

                        if (cliente.ActualizarCliente(cliente))
                        {
                            MessageBox.Show("El Cliente fue actualizado exitosamente!!!", "Actualiza Cliente", MessageBoxButton.OK, MessageBoxImage.Information);
                            LimpiaDatos();
                        }
                        else
                        {
                            MessageBox.Show("Hubo un error al actualiar el cliente", "Actualiza Cliente", MessageBoxButton.OK, MessageBoxImage.Information);
                        }
                    }
                    else
                    {
                        MessageBox.Show("El rut ingresado no existe.", "Actualiza Cliente", MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                    
                }
            }
        }

        private void btnEliminar_Click(object sender, RoutedEventArgs e)
        {
            string rut = txtRut.Text;

            if(ValidaRut(rut))
            {
                Negocio.Cliente cliente = new Negocio.Cliente();

                //Existe Cliente, se puede eliminar
                if(cliente.BuscarCliente(rut) != null)
                {
                    if (cliente.EliminaCliente(rut))
                    {
                        MessageBox.Show("El cliente a sido eliminado correctamente.", "Elimina Cliente", MessageBoxButton.OK, MessageBoxImage.Information);
                        LimpiaDatos();
                    }
                    else
                    {
                        MessageBox.Show("Hubo un error al eliminar el cliente", "Elimina Cliente", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
                else{
                    MessageBox.Show("El cliente no existe", "Elimina Cliente", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
            else
            {
                MessageBox.Show("Debe ingresar Rut", "Elimina Cliente", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }
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
