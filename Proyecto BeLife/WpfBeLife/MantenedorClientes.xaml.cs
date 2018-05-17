﻿using System;
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
using BeLife.Negocio;

namespace WpfBeLife
{
    /// <summary>
    /// Lógica de interacción para MantenedorClientes.xaml
    /// </summary>
    public partial class MantenedorClientes : Page
    {

        public MantenedorClientes()
        {
            InitializeComponent();

            LimpiaDatos();
            
        }

        private void Button_IsMouseCapturedChanged(object sender, DependencyPropertyChangedEventArgs e)
        {

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

        private void BtnRegistrar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Cliente cliente = new Cliente()
                {
                    Rut = txtRut.Text,
                    Nombres = txtNombres.Text,
                    Apellidos = txtApellidos.Text,
                    FechaNacimiento = (DateTime)FechaNacimiento.SelectedDate
                };

                Sexo sexo = new Sexo();
                sexo.Id = cboSexo.SelectedIndex + 1;
                if (sexo.Read())
                {
                    cliente.Sexo = sexo;
                }

                EstadoCivil estado = new EstadoCivil();
                estado.Id = cboEstado.SelectedIndex + 1;
                if (estado.Read())
                {
                    cliente.EstadoCivil = estado;
                }

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
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Atención", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }

        }

        /// <summary>
        /// Limpia los Datos del formulario y carga los combobox
        /// </summary>
        private void LimpiaDatos()
        {
            txtRut.Text = "";
            txtNombres.Text = "";
            txtApellidos.Text = "";
            FechaNacimiento.SelectedDate = DateTime.Today;
            cargaDatos();
        }

        /// <summary>
        /// Carga los combobox Sexo y Estado con los datos de la BD
        /// </summary>
        private void cargaDatos()
        {
            Sexo sexo = new Sexo();
            cboSexo.ItemsSource = sexo.ReadAll();
            cboSexo.SelectedIndex = -1;

            EstadoCivil estadoCivil = new EstadoCivil();
            cboEstado.ItemsSource = estadoCivil.ReadAll();
            cboEstado.SelectedIndex = -1;
        }

        private void BtnMenuLateral_Click(object sender, RoutedEventArgs e)
        {
            FlyMenu.IsOpen = true;

        }

        private void btnElimina_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Cliente cliente = new Cliente()
                {
                    Rut = txtRut.Text
                };
                if (cliente.Delete())
                {
                    MessageBox.Show("El cliente con rut " + cliente.Rut + " fue eliminado.", "Información", MessageBoxButton.OK, MessageBoxImage.Information);
                    LimpiaDatos();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Atención", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }
        }

        private void btnActualiza_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Cliente cliente = new Cliente()
                {
                    Rut = txtRut.Text,
                    Nombres = txtNombres.Text,
                    Apellidos = txtApellidos.Text,
                    FechaNacimiento = (DateTime)FechaNacimiento.SelectedDate
                };

                Sexo sexo = new Sexo();
                sexo.Id = cboSexo.SelectedIndex + 1;
                if (sexo.Read())
                {
                    cliente.Sexo = sexo;
                }
                else
                {
                    throw new Exception("Sexo Invalido.");
                }

                EstadoCivil estado = new EstadoCivil();
                estado.Id = cboEstado.SelectedIndex + 1;
                if (estado.Read())
                {
                    cliente.EstadoCivil = estado;
                }
                else
                {
                    throw new Exception("Estado Invalido.");
                }

                if (cliente.Update())
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

        private void btnBuscar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Cliente cliente = new Cliente()
                {
                    Rut = txtRut.Text
                };
                if (cliente.Read())
                {
                    txtNombres.Text = cliente.Nombres;
                    txtApellidos.Text = cliente.Apellidos;
                    FechaNacimiento.SelectedDate = cliente.FechaNacimiento;
                    CargaSexo(cliente.Sexo.Id);
                    CargaEstado(cliente.EstadoCivil.Id);
                    MessageBox.Show("Datos del Cliente fueron cargados.", "Información", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Atención", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }
        }

        private void CargaEstado(int idEstadoCivil)
        {
            EstadoCivil estado = new EstadoCivil();
            estado.Id = idEstadoCivil;

            if (!estado.Read())
            {
                throw new Exception("Error al leer estado.");
            }

            cboEstado.SelectedIndex = estado.Id - 1;

        }

        private void CargaSexo(int idSexo)
        {
            Sexo sexo = new Sexo();

            sexo.Id = idSexo;

            if (!sexo.Read())
            {
                throw new Exception("Error al leer Sexo.");
            }

            cboSexo.SelectedIndex = sexo.Id - 1;

        }
    }
}