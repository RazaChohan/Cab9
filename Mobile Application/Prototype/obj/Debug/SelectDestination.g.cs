﻿#pragma checksum "C:\Users\Raza\Desktop\Prototype_new_29Oct\Prototype_new_29Oct\Prototype\Prototype\Prototype\SelectDestination.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "4BEBE995C6F20E6DBF7F118618CCB784"
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
using Microsoft.Phone.Controls.Maps;
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
using Telerik.Windows.Controls;


namespace Prototype {
    
    
    public partial class SelectDestination : Microsoft.Phone.Controls.PhoneApplicationPage {
        
        internal Microsoft.Phone.Shell.ApplicationBarIconButton OK;
        
        internal Microsoft.Phone.Shell.ApplicationBarIconButton writeAddress;
        
        internal Microsoft.Phone.Shell.ApplicationBarIconButton Help;
        
        internal System.Windows.Controls.Grid LayoutRoot;
        
        internal System.Windows.Controls.StackPanel TitlePanel;
        
        internal System.Windows.Controls.Grid ContentPanel;
        
        internal Microsoft.Phone.Controls.Maps.Map googlemap;
        
        internal Microsoft.Phone.Controls.Maps.MapTileLayer street;
        
        internal System.Windows.Controls.Grid ModePanel;
        
        internal System.Windows.Controls.StackPanel texts;
        
        internal System.Windows.Controls.TextBlock LatitudeTextBlock;
        
        internal System.Windows.Controls.TextBlock LongitudeTextBlock;
        
        internal System.Windows.Controls.TextBlock Address;
        
        internal Telerik.Windows.Controls.RadNumericUpDown zzoom;
        
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
            System.Windows.Application.LoadComponent(this, new System.Uri("/Prototype;component/SelectDestination.xaml", System.UriKind.Relative));
            this.OK = ((Microsoft.Phone.Shell.ApplicationBarIconButton)(this.FindName("OK")));
            this.writeAddress = ((Microsoft.Phone.Shell.ApplicationBarIconButton)(this.FindName("writeAddress")));
            this.Help = ((Microsoft.Phone.Shell.ApplicationBarIconButton)(this.FindName("Help")));
            this.LayoutRoot = ((System.Windows.Controls.Grid)(this.FindName("LayoutRoot")));
            this.TitlePanel = ((System.Windows.Controls.StackPanel)(this.FindName("TitlePanel")));
            this.ContentPanel = ((System.Windows.Controls.Grid)(this.FindName("ContentPanel")));
            this.googlemap = ((Microsoft.Phone.Controls.Maps.Map)(this.FindName("googlemap")));
            this.street = ((Microsoft.Phone.Controls.Maps.MapTileLayer)(this.FindName("street")));
            this.ModePanel = ((System.Windows.Controls.Grid)(this.FindName("ModePanel")));
            this.texts = ((System.Windows.Controls.StackPanel)(this.FindName("texts")));
            this.LatitudeTextBlock = ((System.Windows.Controls.TextBlock)(this.FindName("LatitudeTextBlock")));
            this.LongitudeTextBlock = ((System.Windows.Controls.TextBlock)(this.FindName("LongitudeTextBlock")));
            this.Address = ((System.Windows.Controls.TextBlock)(this.FindName("Address")));
            this.zzoom = ((Telerik.Windows.Controls.RadNumericUpDown)(this.FindName("zzoom")));
        }
    }
}

