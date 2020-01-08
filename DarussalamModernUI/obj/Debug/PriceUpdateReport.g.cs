﻿#pragma checksum "..\..\PriceUpdateReport.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "EF1837D6FDF350FEAF1923C0776183DE834BA042"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using FirstFloor.ModernUI.Presentation;
using FirstFloor.ModernUI.Windows;
using FirstFloor.ModernUI.Windows.Controls;
using FirstFloor.ModernUI.Windows.Converters;
using FirstFloor.ModernUI.Windows.Navigation;
using RootLibrary.WPF.Localization;
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


namespace DarussalamModernUI {
    
    
    /// <summary>
    /// PriceUpdateReport
    /// </summary>
    public partial class PriceUpdateReport : FirstFloor.ModernUI.Windows.Controls.ModernWindow, System.Windows.Markup.IComponentConnector {
        
        
        #line 43 "..\..\PriceUpdateReport.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DatePicker fromDateDatepicker;
        
        #line default
        #line hidden
        
        
        #line 51 "..\..\PriceUpdateReport.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DatePicker toDateDatepicker;
        
        #line default
        #line hidden
        
        
        #line 54 "..\..\PriceUpdateReport.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button bookSearchButton;
        
        #line default
        #line hidden
        
        
        #line 81 "..\..\PriceUpdateReport.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid posDatagrid;
        
        #line default
        #line hidden
        
        
        #line 143 "..\..\PriceUpdateReport.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button previewButton;
        
        #line default
        #line hidden
        
        
        #line 146 "..\..\PriceUpdateReport.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button closeButton;
        
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
            System.Uri resourceLocater = new System.Uri("/DarussalamModernUI;component/priceupdatereport.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\PriceUpdateReport.xaml"
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
            this.fromDateDatepicker = ((System.Windows.Controls.DatePicker)(target));
            return;
            case 2:
            this.toDateDatepicker = ((System.Windows.Controls.DatePicker)(target));
            return;
            case 3:
            this.bookSearchButton = ((System.Windows.Controls.Button)(target));
            
            #line 58 "..\..\PriceUpdateReport.xaml"
            this.bookSearchButton.Click += new System.Windows.RoutedEventHandler(this.bookSearchButton_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.posDatagrid = ((System.Windows.Controls.DataGrid)(target));
            return;
            case 5:
            this.previewButton = ((System.Windows.Controls.Button)(target));
            
            #line 144 "..\..\PriceUpdateReport.xaml"
            this.previewButton.Click += new System.Windows.RoutedEventHandler(this.previewButton_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            this.closeButton = ((System.Windows.Controls.Button)(target));
            
            #line 147 "..\..\PriceUpdateReport.xaml"
            this.closeButton.Click += new System.Windows.RoutedEventHandler(this.closeButton_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

