﻿#pragma checksum "..\..\ReceiveDueReport.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "BD995A787031EEC14E60AD904872B78403F4FDBF"
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
    /// ReceiveDueReport
    /// </summary>
    public partial class ReceiveDueReport : FirstFloor.ModernUI.Windows.Controls.ModernWindow, System.Windows.Markup.IComponentConnector {
        
        
        #line 44 "..\..\ReceiveDueReport.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DatePicker fromDateDatepicker;
        
        #line default
        #line hidden
        
        
        #line 52 "..\..\ReceiveDueReport.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DatePicker toDateDatepicker;
        
        #line default
        #line hidden
        
        
        #line 76 "..\..\ReceiveDueReport.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button closeButton;
        
        #line default
        #line hidden
        
        
        #line 91 "..\..\ReceiveDueReport.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid posDatagrid;
        
        #line default
        #line hidden
        
        
        #line 160 "..\..\ReceiveDueReport.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button bookSummaryReportButton;
        
        #line default
        #line hidden
        
        
        #line 163 "..\..\ReceiveDueReport.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button summaryReportButton;
        
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
            System.Uri resourceLocater = new System.Uri("/DarussalamModernUI;component/receiveduereport.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\ReceiveDueReport.xaml"
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
            
            #line 74 "..\..\ReceiveDueReport.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Button_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.closeButton = ((System.Windows.Controls.Button)(target));
            
            #line 80 "..\..\ReceiveDueReport.xaml"
            this.closeButton.Click += new System.Windows.RoutedEventHandler(this.closeButton_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.posDatagrid = ((System.Windows.Controls.DataGrid)(target));
            return;
            case 6:
            this.bookSummaryReportButton = ((System.Windows.Controls.Button)(target));
            
            #line 161 "..\..\ReceiveDueReport.xaml"
            this.bookSummaryReportButton.Click += new System.Windows.RoutedEventHandler(this.bookSummaryReportButton_Click);
            
            #line default
            #line hidden
            return;
            case 7:
            this.summaryReportButton = ((System.Windows.Controls.Button)(target));
            
            #line 164 "..\..\ReceiveDueReport.xaml"
            this.summaryReportButton.Click += new System.Windows.RoutedEventHandler(this.summaryReportButton_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

