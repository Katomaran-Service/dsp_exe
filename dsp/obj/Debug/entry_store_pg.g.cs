﻿#pragma checksum "..\..\entry_store_pg.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "57B4784124C66078C8CC9650F8DABD8F40538357"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

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
using dsp;


namespace dsp {
    
    
    /// <summary>
    /// entry_store_pg
    /// </summary>
    public partial class entry_store_pg : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector, System.Windows.Markup.IStyleConnector {
        
        
        #line 23 "..\..\entry_store_pg.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button backbut;
        
        #line default
        #line hidden
        
        
        #line 31 "..\..\entry_store_pg.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid inventory_table;
        
        #line default
        #line hidden
        
        
        #line 94 "..\..\entry_store_pg.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox searchbox;
        
        #line default
        #line hidden
        
        
        #line 95 "..\..\entry_store_pg.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button issue_but;
        
        #line default
        #line hidden
        
        
        #line 99 "..\..\entry_store_pg.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock textBlock123;
        
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
            System.Uri resourceLocater = new System.Uri("/dsp;component/entry_store_pg.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\entry_store_pg.xaml"
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
            this.backbut = ((System.Windows.Controls.Button)(target));
            
            #line 23 "..\..\entry_store_pg.xaml"
            this.backbut.Click += new System.Windows.RoutedEventHandler(this.backbut_Click);
            
            #line default
            #line hidden
            return;
            case 2:
            this.inventory_table = ((System.Windows.Controls.DataGrid)(target));
            return;
            case 4:
            this.searchbox = ((System.Windows.Controls.TextBox)(target));
            
            #line 94 "..\..\entry_store_pg.xaml"
            this.searchbox.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.searchbox_TextChanged);
            
            #line default
            #line hidden
            
            #line 94 "..\..\entry_store_pg.xaml"
            this.searchbox.IsKeyboardFocusedChanged += new System.Windows.DependencyPropertyChangedEventHandler(this.searchbox_IsKeyboardFocusedChanged);
            
            #line default
            #line hidden
            return;
            case 5:
            this.issue_but = ((System.Windows.Controls.Button)(target));
            
            #line 95 "..\..\entry_store_pg.xaml"
            this.issue_but.Click += new System.Windows.RoutedEventHandler(this.issue_but_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            this.textBlock123 = ((System.Windows.Controls.TextBlock)(target));
            return;
            }
            this._contentLoaded = true;
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        void System.Windows.Markup.IStyleConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 3:
            
            #line 88 "..\..\entry_store_pg.xaml"
            ((System.Windows.Controls.TextBox)(target)).TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.qtxt_TextChanged);
            
            #line default
            #line hidden
            break;
            }
        }
    }
}

