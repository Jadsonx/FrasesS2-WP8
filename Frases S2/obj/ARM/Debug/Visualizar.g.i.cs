﻿#pragma checksum "D:\Visual Studio 2015\Projects\Frases S2\Frases S2\Visualizar.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "5591BB33092AD8AC4CCDCA94A59CD155"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using Microsoft.AdMediator.WindowsPhone8;
using Microsoft.Phone.Controls;
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


namespace Frases_S2 {
    
    
    public partial class Visualizar : Microsoft.Phone.Controls.PhoneApplicationPage {
        
        internal Microsoft.Phone.Controls.PhoneApplicationPage phoneApplicationPage;
        
        internal Microsoft.Phone.Shell.ApplicationBarMenuItem copiar;
        
        internal Microsoft.Phone.Shell.ApplicationBarMenuItem Whatsapp;
        
        internal Microsoft.Phone.Shell.ApplicationBarMenuItem relatar_erro;
        
        internal System.Windows.Controls.Grid LayoutRoot;
        
        internal System.Windows.Controls.Grid ContentPanel;
        
        internal System.Windows.Controls.TextBlock textBlockFrase;
        
        internal Microsoft.AdMediator.WindowsPhone8.AdMediatorControl S2;
        
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
            System.Windows.Application.LoadComponent(this, new System.Uri("/Frases%20S2;component/Visualizar.xaml", System.UriKind.Relative));
            this.phoneApplicationPage = ((Microsoft.Phone.Controls.PhoneApplicationPage)(this.FindName("phoneApplicationPage")));
            this.copiar = ((Microsoft.Phone.Shell.ApplicationBarMenuItem)(this.FindName("copiar")));
            this.Whatsapp = ((Microsoft.Phone.Shell.ApplicationBarMenuItem)(this.FindName("Whatsapp")));
            this.relatar_erro = ((Microsoft.Phone.Shell.ApplicationBarMenuItem)(this.FindName("relatar_erro")));
            this.LayoutRoot = ((System.Windows.Controls.Grid)(this.FindName("LayoutRoot")));
            this.ContentPanel = ((System.Windows.Controls.Grid)(this.FindName("ContentPanel")));
            this.textBlockFrase = ((System.Windows.Controls.TextBlock)(this.FindName("textBlockFrase")));
            this.S2 = ((Microsoft.AdMediator.WindowsPhone8.AdMediatorControl)(this.FindName("S2")));
        }
    }
}
