﻿#pragma checksum "..\..\..\Pages\Reservation_Add.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "C40EC092CCB61C2B0BF451EA46B0830C174989CD"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using Parking.Pages;
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


namespace Parking.Pages {
    
    
    /// <summary>
    /// Reservation_Add
    /// </summary>
    public partial class Reservation_Add : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector {
        
        
        #line 25 "..\..\..\Pages\Reservation_Add.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Calendar CalendarControl;
        
        #line default
        #line hidden
        
        
        #line 33 "..\..\..\Pages\Reservation_Add.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnAddReservation;
        
        #line default
        #line hidden
        
        
        #line 42 "..\..\..\Pages\Reservation_Add.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.CheckBox checkBoxAddInfoToCalendar;
        
        #line default
        #line hidden
        
        
        #line 60 "..\..\..\Pages\Reservation_Add.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListBox freeSpacesNumber;
        
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
            System.Uri resourceLocater = new System.Uri("/Parking;component/pages/reservation_add.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\Pages\Reservation_Add.xaml"
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
            
            #line 9 "..\..\..\Pages\Reservation_Add.xaml"
            ((Parking.Pages.Reservation_Add)(target)).Loaded += new System.Windows.RoutedEventHandler(this.Page_Loaded);
            
            #line default
            #line hidden
            return;
            case 2:
            this.CalendarControl = ((System.Windows.Controls.Calendar)(target));
            return;
            case 3:
            this.btnAddReservation = ((System.Windows.Controls.Button)(target));
            
            #line 34 "..\..\..\Pages\Reservation_Add.xaml"
            this.btnAddReservation.Click += new System.Windows.RoutedEventHandler(this.btnAddReservation_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.checkBoxAddInfoToCalendar = ((System.Windows.Controls.CheckBox)(target));
            return;
            case 5:
            this.freeSpacesNumber = ((System.Windows.Controls.ListBox)(target));
            
            #line 52 "..\..\..\Pages\Reservation_Add.xaml"
            this.freeSpacesNumber.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.freeSpacesNumber_SelectionChanged);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

