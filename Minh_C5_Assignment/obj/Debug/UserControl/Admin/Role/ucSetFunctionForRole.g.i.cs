﻿#pragma checksum "..\..\..\..\..\UserControl\Admin\Role\ucSetFunctionForRole.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "BDE1AD99C5E6F40663E2E8D2B82E2E6175196160"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using Minh_C5_Assignment;
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


namespace Minh_C5_Assignment {
    
    
    /// <summary>
    /// ucSetFunctionForRole
    /// </summary>
    public partial class ucSetFunctionForRole : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 17 "..\..\..\..\..\UserControl\Admin\Role\ucSetFunctionForRole.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label lbTrang;
        
        #line default
        #line hidden
        
        
        #line 33 "..\..\..\..\..\UserControl\Admin\Role\ucSetFunctionForRole.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox cbRole;
        
        #line default
        #line hidden
        
        
        #line 37 "..\..\..\..\..\UserControl\Admin\Role\ucSetFunctionForRole.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnSave;
        
        #line default
        #line hidden
        
        
        #line 45 "..\..\..\..\..\UserControl\Admin\Role\ucSetFunctionForRole.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TreeView tvFunction;
        
        #line default
        #line hidden
        
        
        #line 46 "..\..\..\..\..\UserControl\Admin\Role\ucSetFunctionForRole.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TreeViewItem NameParent;
        
        #line default
        #line hidden
        
        
        #line 50 "..\..\..\..\..\UserControl\Admin\Role\ucSetFunctionForRole.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.CheckBox ckbChild;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/Minh_C5_Assignment;component/usercontrol/admin/role/ucsetfunctionforrole.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\..\UserControl\Admin\Role\ucSetFunctionForRole.xaml"
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
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.lbTrang = ((System.Windows.Controls.Label)(target));
            return;
            case 2:
            this.cbRole = ((System.Windows.Controls.ComboBox)(target));
            
            #line 34 "..\..\..\..\..\UserControl\Admin\Role\ucSetFunctionForRole.xaml"
            this.cbRole.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.cbRole_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 3:
            this.btnSave = ((System.Windows.Controls.Button)(target));
            
            #line 38 "..\..\..\..\..\UserControl\Admin\Role\ucSetFunctionForRole.xaml"
            this.btnSave.Click += new System.Windows.RoutedEventHandler(this.btnSave_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.tvFunction = ((System.Windows.Controls.TreeView)(target));
            return;
            case 5:
            this.NameParent = ((System.Windows.Controls.TreeViewItem)(target));
            return;
            case 6:
            this.ckbChild = ((System.Windows.Controls.CheckBox)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

