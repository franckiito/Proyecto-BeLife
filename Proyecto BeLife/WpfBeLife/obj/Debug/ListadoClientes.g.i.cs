﻿#pragma checksum "..\..\ListadoClientes.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "E9B2A42562213ADD8597847A5D4E1B7C"
//------------------------------------------------------------------------------
// <auto-generated>
//     Este código fue generado por una herramienta.
//     Versión de runtime:4.0.30319.42000
//
//     Los cambios en este archivo podrían causar un comportamiento incorrecto y se perderán si
//     se vuelve a generar el código.
// </auto-generated>
//------------------------------------------------------------------------------

using MahApps.Metro;
using MahApps.Metro.Controls;
using MahApps.Metro.Controls.Dialogs;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
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
using WpfBeLife;


namespace WpfBeLife {
    
    
    /// <summary>
    /// ListadoClientes
    /// </summary>
    public partial class ListadoClientes : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector {
        
        
        #line 49 "..\..\ListadoClientes.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button BtnMenuLateral;
        
        #line default
        #line hidden
        
        
        #line 52 "..\..\ListadoClientes.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtRut;
        
        #line default
        #line hidden
        
        
        #line 54 "..\..\ListadoClientes.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox cboEstado;
        
        #line default
        #line hidden
        
        
        #line 56 "..\..\ListadoClientes.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox cboSexo;
        
        #line default
        #line hidden
        
        
        #line 58 "..\..\ListadoClientes.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid grdClientes;
        
        #line default
        #line hidden
        
        
        #line 64 "..\..\ListadoClientes.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal MahApps.Metro.Controls.Flyout FlyMenu;
        
        #line default
        #line hidden
        
        
        #line 71 "..\..\ListadoClientes.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button BtnClientes;
        
        #line default
        #line hidden
        
        
        #line 72 "..\..\ListadoClientes.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button BtnMantCliMenu;
        
        #line default
        #line hidden
        
        
        #line 74 "..\..\ListadoClientes.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button BtnListContr;
        
        #line default
        #line hidden
        
        
        #line 75 "..\..\ListadoClientes.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button BtnListCliMenu;
        
        #line default
        #line hidden
        
        
        #line 76 "..\..\ListadoClientes.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button BtnMantContr;
        
        #line default
        #line hidden
        
        
        #line 92 "..\..\ListadoClientes.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnFiltrar;
        
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
            System.Uri resourceLocater = new System.Uri("/WpfBeLife;component/listadoclientes.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\ListadoClientes.xaml"
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
            this.BtnMenuLateral = ((System.Windows.Controls.Button)(target));
            
            #line 49 "..\..\ListadoClientes.xaml"
            this.BtnMenuLateral.Click += new System.Windows.RoutedEventHandler(this.BtnMenuLateral_Click);
            
            #line default
            #line hidden
            return;
            case 2:
            this.txtRut = ((System.Windows.Controls.TextBox)(target));
            return;
            case 3:
            this.cboEstado = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 4:
            this.cboSexo = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 5:
            this.grdClientes = ((System.Windows.Controls.DataGrid)(target));
            return;
            case 6:
            this.FlyMenu = ((MahApps.Metro.Controls.Flyout)(target));
            return;
            case 7:
            this.BtnClientes = ((System.Windows.Controls.Button)(target));
            return;
            case 8:
            this.BtnMantCliMenu = ((System.Windows.Controls.Button)(target));
            
            #line 72 "..\..\ListadoClientes.xaml"
            this.BtnMantCliMenu.Click += new System.Windows.RoutedEventHandler(this.BtnMantCliMenu_Click);
            
            #line default
            #line hidden
            return;
            case 9:
            this.BtnListContr = ((System.Windows.Controls.Button)(target));
            
            #line 74 "..\..\ListadoClientes.xaml"
            this.BtnListContr.Click += new System.Windows.RoutedEventHandler(this.BtnListContr_Click);
            
            #line default
            #line hidden
            return;
            case 10:
            this.BtnListCliMenu = ((System.Windows.Controls.Button)(target));
            
            #line 75 "..\..\ListadoClientes.xaml"
            this.BtnListCliMenu.Click += new System.Windows.RoutedEventHandler(this.BtnListCliMenu_Click);
            
            #line default
            #line hidden
            return;
            case 11:
            this.BtnMantContr = ((System.Windows.Controls.Button)(target));
            
            #line 76 "..\..\ListadoClientes.xaml"
            this.BtnMantContr.Click += new System.Windows.RoutedEventHandler(this.BtnMantContr_Click);
            
            #line default
            #line hidden
            return;
            case 12:
            this.btnFiltrar = ((System.Windows.Controls.Button)(target));
            
            #line 92 "..\..\ListadoClientes.xaml"
            this.btnFiltrar.Click += new System.Windows.RoutedEventHandler(this.btnFiltrar_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

