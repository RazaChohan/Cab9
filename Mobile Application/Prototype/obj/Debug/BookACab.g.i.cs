﻿#pragma checksum "C:\Users\walee_000\Documents\Cab9\Mobile Application\Prototype\BookACab.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "63B3FAFC086B202B7288623839B51254"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.18408
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using Microsoft.Phone.Controls;
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
    
    
    public partial class BookACab : Microsoft.Phone.Controls.PhoneApplicationPage {
        
        internal System.Windows.Controls.Grid LayoutRoot;
        
        internal Microsoft.Phone.Controls.Panorama PanoramaControl;
        
        internal Microsoft.Phone.Controls.PanoramaItem item1;
        
        internal Microsoft.Phone.Controls.ListPicker cab_type;
        
        internal Microsoft.Phone.Controls.TimePicker timePicker;
        
        internal Microsoft.Phone.Controls.DatePicker datePicker;
        
        internal Microsoft.Phone.Controls.PanoramaItem item2;
        
        internal System.Windows.Controls.WatermarkTextBox currentLocationtxt;
        
        internal Microsoft.Phone.Controls.PanoramaItem item3;
        
        internal System.Windows.Controls.WatermarkTextBox DestinationLocationtxt;
        
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
            System.Windows.Application.LoadComponent(this, new System.Uri("/Prototype;component/BookACab.xaml", System.UriKind.Relative));
            this.LayoutRoot = ((System.Windows.Controls.Grid)(this.FindName("LayoutRoot")));
            this.PanoramaControl = ((Microsoft.Phone.Controls.Panorama)(this.FindName("PanoramaControl")));
            this.item1 = ((Microsoft.Phone.Controls.PanoramaItem)(this.FindName("item1")));
            this.cab_type = ((Microsoft.Phone.Controls.ListPicker)(this.FindName("cab_type")));
            this.timePicker = ((Microsoft.Phone.Controls.TimePicker)(this.FindName("timePicker")));
            this.datePicker = ((Microsoft.Phone.Controls.DatePicker)(this.FindName("datePicker")));
            this.item2 = ((Microsoft.Phone.Controls.PanoramaItem)(this.FindName("item2")));
            this.currentLocationtxt = ((System.Windows.Controls.WatermarkTextBox)(this.FindName("currentLocationtxt")));
            this.item3 = ((Microsoft.Phone.Controls.PanoramaItem)(this.FindName("item3")));
            this.DestinationLocationtxt = ((System.Windows.Controls.WatermarkTextBox)(this.FindName("DestinationLocationtxt")));
        }
    }
}

