﻿#pragma checksum "C:\Users\QQ\source\repos\Final_Project\Final_Project\registerPage.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "11D36FD058F8B9CE8955C2EECA8E7D2ABA213F2E30CD0F20DE2925C08B72FDE5"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Final_Project
{
    partial class registerPage : 
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
            case 2: // registerPage.xaml line 16
                {
                    this.tbName = (global::Windows.UI.Xaml.Controls.TextBox)(target);
                }
                break;
            case 3: // registerPage.xaml line 17
                {
                    this.tbEmail = (global::Windows.UI.Xaml.Controls.TextBox)(target);
                }
                break;
            case 4: // registerPage.xaml line 18
                {
                    this.tbPhone = (global::Windows.UI.Xaml.Controls.TextBox)(target);
                }
                break;
            case 5: // registerPage.xaml line 20
                {
                    this.tbUsername = (global::Windows.UI.Xaml.Controls.TextBox)(target);
                }
                break;
            case 6: // registerPage.xaml line 22
                {
                    this.tbPassword = (global::Windows.UI.Xaml.Controls.PasswordBox)(target);
                }
                break;
            case 7: // registerPage.xaml line 23
                {
                    this.btnSubmit = (global::Windows.UI.Xaml.Controls.Button)(target);
                    ((global::Windows.UI.Xaml.Controls.Button)this.btnSubmit).Click += this.Button_Click;
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

