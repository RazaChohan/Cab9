﻿#pragma checksum "C:\Users\walee_000\Documents\Cab9\Mobile Application\Prototype\Login.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "2EFBAE5D85BE46F8B47D5B200BD78991"
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
    
    
    public partial class Login : Microsoft.Phone.Controls.PhoneApplicationPage {
        
        internal System.Windows.Controls.Grid LayoutRoot;
        
        internal System.Windows.Controls.Grid ContentPanel;
        
        internal Microsoft.Phone.Controls.ListPicker user;
        
        internal System.Windows.Controls.WatermarkTextBox usertxt;
        
        internal System.Windows.Controls.PasswordBox Password1;
        
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
            System.Windows.Application.LoadComponent(this, new System.Uri("/Prototype;component/Login.xaml", System.UriKind.Relative));
            this.LayoutRoot = ((System.Windows.Controls.Grid)(this.FindName("LayoutRoot")));
            this.ContentPanel = ((System.Windows.Controls.Grid)(this.FindName("ContentPanel")));
            this.user = ((Microsoft.Phone.Controls.ListPicker)(this.FindName("user")));
            this.usertxt = ((System.Windows.Controls.WatermarkTextBox)(this.FindName("usertxt")));
            this.Password1 = ((System.Windows.Controls.PasswordBox)(this.FindName("Password1")));
        }
    }
}

