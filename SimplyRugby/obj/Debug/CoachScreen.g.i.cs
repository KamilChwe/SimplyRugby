// Updated by XamlIntelliSenseFileGenerator 09/05/2021 13:09:06
#pragma checksum "..\..\CoachScreen.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "D50D759238BDD8BD2B40CE7DB50E639AA888C832C54F4861808929878725C6B2"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using SimplyRugby;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Media.TextFormatting;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Shell;


namespace SimplyRugby
{


    /// <summary>
    /// CoachScreen
    /// </summary>
    public partial class CoachScreen : System.Windows.Window, System.Windows.Markup.IComponentConnector
    {


#line 10 "..\..\CoachScreen.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnLogout;

#line default
#line hidden


#line 12 "..\..\CoachScreen.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnSubmit;

#line default
#line hidden


#line 13 "..\..\CoachScreen.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListBox lstDisplay;

#line default
#line hidden


#line 19 "..\..\CoachScreen.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtTackling;

#line default
#line hidden


#line 20 "..\..\CoachScreen.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtRunning;

#line default
#line hidden


#line 21 "..\..\CoachScreen.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtThrowing;

#line default
#line hidden


#line 22 "..\..\CoachScreen.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtPassing;

#line default
#line hidden


#line 23 "..\..\CoachScreen.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtComment;

#line default
#line hidden

        private bool _contentLoaded;

        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        public void InitializeComponent()
        {
            if (_contentLoaded)
            {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/SimplyRugby;component/coachscreen.xaml", System.UriKind.Relative);

#line 1 "..\..\CoachScreen.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);

#line default
#line hidden
        }

        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target)
        {
            switch (connectionId)
            {
                case 1:
                    this.btnLogout = ((System.Windows.Controls.Button)(target));

#line 10 "..\..\CoachScreen.xaml"
                    this.btnLogout.Click += new System.Windows.RoutedEventHandler(this.btnLogout_Click);

#line default
#line hidden
                    return;
                case 2:
                    this.btnSubmit = ((System.Windows.Controls.Button)(target));

#line 12 "..\..\CoachScreen.xaml"
                    this.btnSubmit.Click += new System.Windows.RoutedEventHandler(this.btnSubmit_Click);

#line default
#line hidden
                    return;
                case 3:
                    this.lstDisplay = ((System.Windows.Controls.ListBox)(target));

#line 13 "..\..\CoachScreen.xaml"
                    this.lstDisplay.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.lstDisplay_SelectionChanged);

#line default
#line hidden
                    return;
                case 4:
                    this.txtTackling = ((System.Windows.Controls.TextBox)(target));
                    return;
                case 5:
                    this.txtRunning = ((System.Windows.Controls.TextBox)(target));
                    return;
                case 6:
                    this.txtThrowing = ((System.Windows.Controls.TextBox)(target));
                    return;
                case 7:
                    this.txtPassing = ((System.Windows.Controls.TextBox)(target));
                    return;
                case 8:
                    this.txtComment = ((System.Windows.Controls.TextBox)(target));
                    return;
            }
            this._contentLoaded = true;
        }

        internal System.Windows.Controls.Button btnHelp;
    }
}

