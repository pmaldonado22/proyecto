﻿#pragma checksum "E:\Udla\Quinto Semestre\Programación IV\Proyectos UWP\panaderiaUWP\panaderiaUWP\Vistas\EditarPan.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "1E8D3EB7BB342E7C58372347EF4F576B3905810A120EEC90341E178C347F35FE"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace panaderiaUWP.Vistas
{
    partial class EditarPan : 
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
            case 2: // Vistas\EditarPan.xaml line 13
                {
                    global::Windows.UI.Xaml.Controls.AppBarButton element2 = (global::Windows.UI.Xaml.Controls.AppBarButton)(target);
                    ((global::Windows.UI.Xaml.Controls.AppBarButton)element2).Click += this.AppBarButton_Click;
                }
                break;
            case 3: // Vistas\EditarPan.xaml line 14
                {
                    global::Windows.UI.Xaml.Controls.AppBarButton element3 = (global::Windows.UI.Xaml.Controls.AppBarButton)(target);
                    ((global::Windows.UI.Xaml.Controls.AppBarButton)element3).Click += this.AppBarButton_Click2;
                }
                break;
            case 4: // Vistas\EditarPan.xaml line 19
                {
                    this.ID = (global::Windows.UI.Xaml.Controls.TextBox)(target);
                }
                break;
            case 5: // Vistas\EditarPan.xaml line 20
                {
                    this.nombrePan = (global::Windows.UI.Xaml.Controls.TextBox)(target);
                }
                break;
            case 6: // Vistas\EditarPan.xaml line 21
                {
                    this.precio = (global::Windows.UI.Xaml.Controls.TextBox)(target);
                }
                break;
            case 7: // Vistas\EditarPan.xaml line 22
                {
                    this.cantidad = (global::Windows.UI.Xaml.Controls.TextBox)(target);
                }
                break;
            case 8: // Vistas\EditarPan.xaml line 24
                {
                    this.Imagen1 = (global::Windows.UI.Xaml.Controls.Image)(target);
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

