﻿#pragma checksum "C:\Users\walee_000\Documents\Cab9\Mobile Application\Prototype\Register.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "4D2E95A35C8EF58E9FDD6E68DEA9F4B2"
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
    
    
    public partial class Register : Microsoft.Phone.Controls.PhoneApplicationPage {
        
        internal System.Windows.Controls.Grid LayoutRoot;
        
        internal System.Windows.Controls.Grid ContentPanel;
        
        internal System.Windows.Controls.WatermarkTextBox AgeTxt;
        
        internal System.Windows.Controls.WatermarkTextBox UserNametxt;
        
        internal System.Windows.Controls.WatermarkTextBox Nictxt;
        
        internal System.Windows.Controls.WatermarkTextBox emailtxt;
        
        internal System.Windows.Controls.WatermarkTextBox phnetxt;
        
        internal System.Windows.Controls.WatermarkTextBox adresstxt;
        
        internal Microsoft.Phone.Controls.ListPicker Gender;
        
        internal Microsoft.Phone.Controls.ListPicker user;
        
        internal System.Windows.Controls.PasswordBox PasswordTxt;
        
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
            System.Windows.Application.LoadComponent(this, new System.Uri("/Prototype;component/Register.xaml", System.UriKind.Relative));
            this.LayoutRoot = ((System.Windows.Controls.Grid)(this.FindName("LayoutRoot")));
            this.ContentPanel = ((System.Windows.Controls.Grid)(this.FindName("ContentPanel")));
            this.AgeTxt = ((System.Windows.Controls.WatermarkTextBox)(this.FindName("AgeTxt")));
            this.UserNametxt = ((System.Windows.Controls.WatermarkTextBox)(this.FindName("UserNametxt")));
            this.Nictxt = ((System.Windows.Controls.WatermarkTextBox)(this.FindName("Nictxt")));
            this.emailtxt = ((System.Windows.Controls.WatermarkTextBox)(this.FindName("emailtxt")));
            this.phnetxt = ((System.Windows.Controls.WatermarkTextBox)(this.FindName("phnetxt")));
            this.adresstxt = ((System.Windows.Controls.WatermarkTextBox)(this.FindName("adresstxt")));
            this.Gender = ((Microsoft.Phone.Controls.ListPicker)(this.FindName("Gender")));
            this.user = ((Microsoft.Phone.Controls.ListPicker)(this.FindName("user")));
            this.PasswordTxt = ((System.Windows.Controls.PasswordBox)(this.FindName("PasswordTxt")));
        }
    }
}

