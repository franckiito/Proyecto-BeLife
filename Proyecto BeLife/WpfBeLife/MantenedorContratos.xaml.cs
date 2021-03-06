﻿using BeLife.Negocio;
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
        Validaciones validaciones = new Validaciones();
        public MantenedorContratos()
        {
            InitializeComponent();
            txtNumeroContrato.Text = validaciones.GeneraNumeroContrato();
            InicioVigencia.SelectedDate = DateTime.Today;
            CargaPlanes();
        }

        private void CargaPlanes()
        {
            Plan plan = new Plan();
            cboPlan.ItemsSource = plan.ReadAll();
            cboPlan.Items.Refresh();

            cboPlan.SelectedIndex = -1;
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
                if (ValidaDatosContrato())
                {

                    Contrato contrato = new Contrato()
                    {
                        Numero = txtNumeroContrato.Text,
                        Creacion = DateTime.Today,
                        InicioVigencia = (DateTime)InicioVigencia.SelectedDate,
                        Observaciones = txtObservacion.Text,
                        PrimaAnual = float.Parse(txtPrimaAnual.Text),
                        PrimaMensual = float.Parse(txtPrimaMensual.Text),
                        ConDeclaracionDeSalud = (bool)CheckDeclaracionSalud.IsChecked
                    };

                    contrato.Termino = validaciones.GeneraTermino(contrato.InicioVigencia);
                    contrato.FinVigencia = validaciones.GeneraTermino(contrato.InicioVigencia);

                    Cliente cliente = new Cliente()
                    {
                        Rut = txtRut.Text
                    };

                    if (cliente.Read())
                    {
                        contrato.Titular = cliente;

                        Plan plan = new Plan();
                        plan = (Plan)cboPlan.SelectedItem;

                        if (plan.Read())
                        {
                            contrato.PlanAsociado = plan;

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
                        else
                        {
                            MessageBox.Show("Error al cargar plan.", "Atención", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                        }
                    }
                    else
                    {
                        MessageBox.Show("El Rut :" + cliente.Rut + " no existe, no se puede crear el contrato.", "Atención", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                    }
                    
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
            InicioVigencia.SelectedDate = DateTime.Today;
            cboPlan.SelectedIndex = -1;
            txtPrimaAnual.Text = "";
            txtPrimaMensual.Text = "";
            txtObservacion.Text = "";
            txtNombre.Text = "";
            txtApellido.Text = "";
            txtPoliza.Text = "";
            txtRut.Text = "";
            CheckDeclaracionSalud.IsChecked = false;
        }

        private void BtnBuscarContr_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (validaciones.ValidaNumeroContrato(txtNumeroContrato.Text)) 
                {
                    Contrato con = new Contrato()
                    {
                        Numero = txtNumeroContrato.Text
                    };
                    if (con.Read())
                    {
                        txtNumeroContrato.Text = con.Numero;
                        InicioVigencia.SelectedDate = con.Creacion;
                        cboPlan.SelectedValue = con.PlanAsociado.Id;
                        txtPrimaAnual.Text = con.PrimaAnual + "";
                        txtPrimaMensual.Text = con.PrimaMensual + "";
                        txtObservacion.Text = con.Observaciones;
                        txtRut.Text = con.Titular.Rut;
                        txtNombre.Text = con.Titular.Nombres;
                        txtApellido.Text = con.Titular.Apellidos;
                        CheckDeclaracionSalud.IsChecked = con.ConDeclaracionDeSalud;


                        MessageBox.Show("Datos del Contrato fueron cargados correctamente.", "Información", MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                    else
                    {
                        MessageBox.Show("Datos del contrato no fueron encontrados.", "Información", MessageBoxButton.OK, MessageBoxImage.Information);
                    }
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
                if (validaciones.ValidaNumeroContrato(txtNumeroContrato.Text))
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
                if (ValidaDatosContrato())
                {
                    Contrato contrato = new Contrato()
                    {
                        Numero = txtNumeroContrato.Text,
                        InicioVigencia = (DateTime)InicioVigencia.SelectedDate,
                        PrimaAnual = float.Parse(txtPrimaAnual.Text),
                        PrimaMensual = float.Parse(txtPrimaMensual.Text),
                        Observaciones = txtObservacion.Text
                    };

                    if (contrato.Update())
                    {
                        MessageBox.Show("Contrato Actualizado correctamente.", "Información", MessageBoxButton.OK, MessageBoxImage.Information);
                        LimpiaDatos();
                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Atención", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }
        }

        private void txtRut_LostFocus(object sender, RoutedEventArgs e)
        {

            try
            {
                if (validaciones.ValidaRut(txtRut.Text))
                {
                    Cliente cliente = new Cliente()
                    {
                        Rut = txtRut.Text
                    };
                    if (cliente.Read())
                    {
                        txtNombre.Text = cliente.Nombres;
                        txtApellido.Text = cliente.Apellidos;
                        txtRut.BorderBrush = new SolidColorBrush(Colors.Green);

                        Tarificador tarificador = new Tarificador()
                        {
                            Cliente = cliente
                        };
                        Contrato contrato = new Contrato();
                        contrato.Tarificar();

                        txtPrimaAnual.Text = contrato.PrimaAnual.ToString();

                        //Carga los datos del plan y hace la suma del recargo mas la prima, asigna valor a primaMensual
                        CargaDatosPlan();

                    }
                    else
                    {
                        txtRut.BorderBrush = new SolidColorBrush(Colors.Red);
                        RutMensaje.Content = "No existe el rut ingresado en la Base de datos";
                    }
                }
                else
                {
                    txtRut.BorderBrush = new SolidColorBrush(Colors.Red);
                    RutMensaje.Content = "Rut Invalido";
                }
                
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }

        }

        public bool ValidaDatosContrato()
        {
            bool valida = true;
            try
            { 

                if (!validaciones.ValidaNumeroContrato(txtNumeroContrato.Text))
                {
                    valida = false;
                }
                if (!validaciones.ValidaInicioVigencia((DateTime)InicioVigencia.SelectedDate))
                {
                    valida = false;
                }
                if (!validaciones.ValidaRut(txtRut.Text))
                {
                    valida = false;
                }
                if (!validaciones.ValidaComboBoxPlan(cboPlan.SelectedIndex))
                {
                    valida = false;
                }
                if (!validaciones.ValidaPolizaAnual(txtPrimaAnual.Text))
                {
                    valida = false;
                }
                if (!validaciones.ValidaPolizaMensual(txtPrimaMensual.Text))
                {
                    valida = false;
                }
                if (!validaciones.ValidaObservaciones(txtObservacion.Text))
                {
                    valida = false;
                }
                
            }
            catch (Exception ex)
            {
                valida = false;
                MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            return valida;
        }

        private void cboPlan_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {

                CargaDatosPlan();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        public void CargaDatosPlan() {
            if (cboPlan.SelectedIndex != -1)
            {
                Plan plan = new Plan();
                plan = (Plan)cboPlan.SelectedItem;

                if (plan.Read())
                {
                    txtPoliza.Text = plan.PolizaActual;
                    txtNombrePlan.Text = plan.Nombre;
                    txtPrimaBase.Text = plan.PrimaBase.ToString();

                    //Se considera que primero tiene que estar calculado el recargo para sumarle la prima.
                    if (!string.IsNullOrEmpty(txtPrimaAnual.Text))
                    {
                        float recargo;
                        recargo = float.Parse(txtPrimaAnual.Text);

                        txtPrimaAnual.Text = Math.Round((plan.PrimaBase + recargo),3).ToString();
                        txtPrimaMensual.Text = Math.Round(((plan.PrimaBase + recargo) / 12),3).ToString();
                    }
                }
            }
        }
    }
}
