﻿#pragma checksum "F:\Study\FYP\Prototype\Prototype_new_29Oct\Prototype_new_29Oct\Prototype\Prototype\Prototype\EmergencyServices.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "974EA531AADC1D2CA50E20261F92D2EB"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.18331
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using Microsoft.Phone.Controls;
using Microsoft.Phone.Maps.Controls;
using Microsoft.Phone.Shell;
using System;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Automation.Peers;
using System.Windows.Automation.Provider;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Interop;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Resources;
using System.Windows.Shapes;
using System.Windows.Threading;


namespace Prototype {
    
    
    public partial class EmergencyServices : Microsoft.Phone.Controls.PhoneApplicationPage {
        
        internal Microsoft.Phone.Shell.ApplicationBarIconButton appBarOkButton;
        
        internal Microsoft.Phone.Shell.ApplicationBarIconButton appBarCancelButton;
        
        internal System.Windows.Controls.Grid LayoutRoot;
        
        internal System.Windows.Controls.Grid ContentPanel;
        
        internal System.Windows.Controls.WatermarkTextBox currentLocation;
        
        internal Microsoft.Phone.Maps.Controls.Map mapWithMyLocation;
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Windows.Application.LoadComponent(this, new System.Uri("/Prototype;component/EmergencyServices.xaml", System.UriKind.Relative));
            this.appBarOkButton = ((Microsoft.Phone.Shell.ApplicationBarIconButton)(this.FindName("appBarOkButton")));
            this.appBarCancelButton = ((Microsoft.Phone.Shell.ApplicationBarIconButton)(this.FindName("appBarCancelButton")));
            this.LayoutRoot = ((System.Windows.Controls.Grid)(this.FindName("LayoutRoot")));
            this.ContentPanel = ((System.Windows.Controls.Grid)(this.FindName("ContentPanel")));
            this.currentLocation = ((System.Windows.Controls.WatermarkTextBox)(this.FindName("currentLocation")));
            this.mapWithMyLocation = ((Microsoft.Phone.Maps.Controls.Map)(this.FindName("mapWithMyLocation")));
        }
    }
}

