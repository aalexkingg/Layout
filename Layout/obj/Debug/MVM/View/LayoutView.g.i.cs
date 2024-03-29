﻿#pragma checksum "..\..\..\..\MVM\View\LayoutView.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "D3A087572205E102AE4560BBB662E3C8E4EA5E4B7923597109E06CC446E4C093"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using Layout.MVM.View;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms.Integration;
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


namespace Layout.MVM.View {
    
    
    /// <summary>
    /// LayoutView
    /// </summary>
    public partial class LayoutView : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 38 "..\..\..\..\MVM\View\LayoutView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox LayoutNameInput;
        
        #line default
        #line hidden
        
        
        #line 51 "..\..\..\..\MVM\View\LayoutView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListBox ListOfFiles;
        
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
            System.Uri resourceLocater = new System.Uri("/Layout;component/mvm/view/layoutview.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\MVM\View\LayoutView.xaml"
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
            this.LayoutNameInput = ((System.Windows.Controls.TextBox)(target));
            return;
            case 2:
            this.ListOfFiles = ((System.Windows.Controls.ListBox)(target));
            
            #line 58 "..\..\..\..\MVM\View\LayoutView.xaml"
            this.ListOfFiles.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.ListOfFiles_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 3:
            
            #line 72 "..\..\..\..\MVM\View\LayoutView.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.SelectFilesButton_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            
            #line 81 "..\..\..\..\MVM\View\LayoutView.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.CaptureDesktopButton_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            
            #line 89 "..\..\..\..\MVM\View\LayoutView.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.RemoveSelectedButton_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            
            #line 97 "..\..\..\..\MVM\View\LayoutView.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.SaveLayoutButton_Click);
            
            #line default
            #line hidden
            return;
            case 7:
            
            #line 105 "..\..\..\..\MVM\View\LayoutView.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.SaveLayoutAsButton_Click);
            
            #line default
            #line hidden
            return;
            case 8:
            
            #line 113 "..\..\..\..\MVM\View\LayoutView.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.DeleteLayoutButton_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

