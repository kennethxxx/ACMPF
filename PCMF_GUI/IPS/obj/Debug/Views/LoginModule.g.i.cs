﻿#pragma checksum "D:\VS_Project\本體論系統\AMCSystems20121106-更新MMbyXML\AMCSystems20121030-更新DAUserFriendly\IPS\Views\LoginModule.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "3B9BEC0DD3DB8910D665983FD6212D84"
//------------------------------------------------------------------------------
// <auto-generated>
//     這段程式碼是由工具產生的。
//     執行階段版本:4.0.30319.18052
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
    
    
    public partial class LoginModule : System.Windows.Controls.ChildWindow {
        
        internal System.Windows.Controls.Grid LayoutRoot;
        
        internal System.Windows.Controls.Image imgKey;
        
        internal System.Windows.Controls.TextBox ui_UserCompany;
        
        internal System.Windows.Controls.TextBox ui_UserName;
        
        internal System.Windows.Controls.PasswordBox ui_Password;
        
        internal System.Windows.Controls.Button ui_ButtonOK;
        
        internal System.Windows.Controls.TextBlock ui_LoginErrorString;
        
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
            System.Windows.Application.LoadComponent(this, new System.Uri("/IPS;component/Views/LoginModule.xaml", System.UriKind.Relative));
            this.LayoutRoot = ((System.Windows.Controls.Grid)(this.FindName("LayoutRoot")));
            this.imgKey = ((System.Windows.Controls.Image)(this.FindName("imgKey")));
            this.ui_UserCompany = ((System.Windows.Controls.TextBox)(this.FindName("ui_UserCompany")));
            this.ui_UserName = ((System.Windows.Controls.TextBox)(this.FindName("ui_UserName")));
            this.ui_Password = ((System.Windows.Controls.PasswordBox)(this.FindName("ui_Password")));
            this.ui_ButtonOK = ((System.Windows.Controls.Button)(this.FindName("ui_ButtonOK")));
            this.ui_LoginErrorString = ((System.Windows.Controls.TextBlock)(this.FindName("ui_LoginErrorString")));
        }
    }
}
