﻿#pragma checksum "C:\Users\QQ\source\repos\Final_Admin_Page\Final_Admin_Page\insertPage.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "278C15A0A5261D67501E67F1645FF65B18BB56B5B5978FB445E62463A6B5004C"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Final_Admin_Page
{
    partial class insertPage : 
        global::Windows.UI.Xaml.Controls.Page, 
        global::Windows.UI.Xaml.Markup.IComponentConnector,
        global::Windows.UI.Xaml.Markup.IComponentConnector2
    {
        /// <summary>
        /// Connect()
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 10.0.19041.685")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public void Connect(int connectionId, object target)
        {
            switch(connectionId)
            {
            case 2: // insertPage.xaml line 17
                {
                    this.tbUsername = (global::Windows.UI.Xaml.Controls.TextBox)(target);
                }
                break;
            case 3: // insertPage.xaml line 19
                {
                    this.tbName = (global::Windows.UI.Xaml.Controls.TextBox)(target);
                }
                break;
            case 4: // insertPage.xaml line 21
                {
                    this.tbEmail = (global::Windows.UI.Xaml.Controls.TextBox)(target);
                }
                break;
            case 5: // insertPage.xaml line 23
                {
                    this.tbNumber = (global::Windows.UI.Xaml.Controls.TextBox)(target);
                }
                break;
            case 6: // insertPage.xaml line 24
                {
                    this.btnUpdate = (global::Windows.UI.Xaml.Controls.Button)(target);
                    ((global::Windows.UI.Xaml.Controls.Button)this.btnUpdate).Click += this.btnUpdate_Click;
                }
                break;
            case 7: // insertPage.xaml line 26
                {
                    this.tbPass = (global::Windows.UI.Xaml.Controls.PasswordBox)(target);
                }
                break;
            default:
                break;
            }
            this._contentLoaded = true;
        }

        /// <summary>
        /// GetBindingConnector(int connectionId, object target)
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 10.0.19041.685")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public global::Windows.UI.Xaml.Markup.IComponentConnector GetBindingConnector(int connectionId, object target)
        {
            global::Windows.UI.Xaml.Markup.IComponentConnector returnValue = null;
            return returnValue;
        }
    }
}

