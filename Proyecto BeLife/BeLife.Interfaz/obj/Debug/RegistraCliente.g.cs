﻿#pragma checksum "..\..\RegistraCliente.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "169CFF09D8AFB6584957BD5B619723027B06D91C"
//------------------------------------------------------------------------------
// <auto-generated>
//     Este código fue generado por una herramienta.
//     Versión de runtime:4.0.30319.42000
//
//     Los cambios en este archivo podrían causar un comportamiento incorrecto y se perderán si
//     se vuelve a generar el código.
// </auto-generated>
//------------------------------------------------------------------------------

using BeLife.Entity;
using BeLife.Interfaz;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms.Integration;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Media.TextFormatting;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Shell;


namespace BeLife.Interfaz {
    
    
    /// <summary>
    /// RegistraCliente
    /// </summary>
    public partial class RegistraCliente : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 33 "..\..\RegistraCliente.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnRegistrar;
        
        #line default
        #line hidden
        
        
        #line 40 "..\..\RegistraCliente.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtRut;
        
        #line default
        #line hidden
        
        
        #line 42 "..\..\RegistraCliente.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtNombres;
        
        #line default
        #line hidden
        
        
        #line 45 "..\..\RegistraCliente.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtApellidos;
        
        #line default
        #line hidden
        
        
        #line 49 "..\..\RegistraCliente.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox EstadoCivilList;
        
        #line default
        #line hidden
        
        
        #line 52 "..\..\RegistraCliente.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox SexoList;
        
        #line default
        #line hidden
        
        
        #line 59 "..\..\RegistraCliente.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnBuscarCliente;
        
        #line default
        #line hidden
        
        
        #line 67 "..\..\RegistraCliente.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DatePicker FechaNacimiento;
        
        #line default
        #line hidden
        
        
        #line 68 "..\..\RegistraCliente.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnActualizar;
        
        #line default
        #line hidden
        
        
        #line 69 "..\..\RegistraCliente.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnEliminar;
        
        #line default
        #line hidden
        
        
        #line 71 "..\..\RegistraCliente.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnIrPrincipal;
        
        #line default
        #line hidden
        
        
        #line 74 "..\..\RegistraCliente.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnIrListaClientes;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/BeLife.Interfaz;component/registracliente.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\RegistraCliente.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            
            #line 9 "..\..\RegistraCliente.xaml"
            ((BeLife.Interfaz.RegistraCliente)(target)).Loaded += new System.Windows.RoutedEventHandler(this.Window_Loaded);
            
            #line default
            #line hidden
            return;
            case 2:
            this.btnRegistrar = ((System.Windows.Controls.Button)(target));
            
            #line 33 "..\..\RegistraCliente.xaml"
            this.btnRegistrar.Click += new System.Windows.RoutedEventHandler(this.btnRegistrar_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            this.txtRut = ((System.Windows.Controls.TextBox)(target));
            return;
            case 4:
            this.txtNombres = ((System.Windows.Controls.TextBox)(target));
            return;
            case 5:
            this.txtApellidos = ((System.Windows.Controls.TextBox)(target));
            return;
            case 6:
            this.EstadoCivilList = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 7:
            this.SexoList = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 8:
            this.btnBuscarCliente = ((System.Windows.Controls.Button)(target));
            
            #line 59 "..\..\RegistraCliente.xaml"
            this.btnBuscarCliente.Click += new System.Windows.RoutedEventHandler(this.btnBuscarCliente_Click);
            
            #line default
            #line hidden
            return;
            case 9:
            this.FechaNacimiento = ((System.Windows.Controls.DatePicker)(target));
            return;
            case 10:
            this.btnActualizar = ((System.Windows.Controls.Button)(target));
            
            #line 68 "..\..\RegistraCliente.xaml"
            this.btnActualizar.Click += new System.Windows.RoutedEventHandler(this.btnActualizar_Click);
            
            #line default
            #line hidden
            return;
            case 11:
            this.btnEliminar = ((System.Windows.Controls.Button)(target));
            
            #line 69 "..\..\RegistraCliente.xaml"
            this.btnEliminar.Click += new System.Windows.RoutedEventHandler(this.btnEliminar_Click);
            
            #line default
            #line hidden
            return;
            case 12:
            this.btnIrPrincipal = ((System.Windows.Controls.Button)(target));
            
            #line 71 "..\..\RegistraCliente.xaml"
            this.btnIrPrincipal.Click += new System.Windows.RoutedEventHandler(this.btnIrPrincipal_Click);
            
            #line default
            #line hidden
            return;
            case 13:
            this.btnIrListaClientes = ((System.Windows.Controls.Button)(target));
            
            #line 74 "..\..\RegistraCliente.xaml"
            this.btnIrListaClientes.Click += new System.Windows.RoutedEventHandler(this.btnIrListaClientes_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}
