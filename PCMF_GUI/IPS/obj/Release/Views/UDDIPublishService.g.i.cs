﻿#pragma checksum "C:\研究所\AMCSystems20121106-更新MMbyXML\AMCSystems20121106-更新MMbyXML\AMCSystems20121030-更新DAUserFriendly\IPS\Views\UDDIPublishService.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "B3DD88A45CA62DE6191CAB00E344DBA3"
//------------------------------------------------------------------------------
// <auto-generated>
//     這段程式碼是由工具產生的。
//     執行階段版本:4.0.30319.18444
//
//     對這個檔案所做的變更可能會造成錯誤的行為，而且如果重新產生程式碼，
//     變更將會遺失。
// </auto-generated>
//------------------------------------------------------------------------------

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


namespace IPS.Views {
    
    
    public partial class UDDIPublishService : System.Windows.Controls.ChildWindow {
        
        internal System.Windows.Controls.Grid LayoutRoot;
        
        internal System.Windows.Controls.ComboBox cmbProvider;
        
        internal System.Windows.Controls.TextBox txtServiceName;
        
        internal System.Windows.Controls.ComboBox cmbServiceGroup;
        
        internal System.Windows.Controls.TextBox txtEndpoint;
        
        internal System.Windows.Controls.Button CancelButton;
        
        internal System.Windows.Controls.Button OKButton;
        
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
            System.Windows.Application.LoadComponent(this, new System.Uri("/IPS;component/Views/UDDIPublishService.xaml", System.UriKind.Relative));
            this.LayoutRoot = ((System.Windows.Controls.Grid)(this.FindName("LayoutRoot")));
            this.cmbProvider = ((System.Windows.Controls.ComboBox)(this.FindName("cmbProvider")));
            this.txtServiceName = ((System.Windows.Controls.TextBox)(this.FindName("txtServiceName")));
            this.cmbServiceGroup = ((System.Windows.Controls.ComboBox)(this.FindName("cmbServiceGroup")));
            this.txtEndpoint = ((System.Windows.Controls.TextBox)(this.FindName("txtEndpoint")));
            this.CancelButton = ((System.Windows.Controls.Button)(this.FindName("CancelButton")));
            this.OKButton = ((System.Windows.Controls.Button)(this.FindName("OKButton")));
        }
    }
}

