﻿#pragma checksum "..\..\TeamIndex.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "B098708DE51F09FA89EB430974CB96ED"
//------------------------------------------------------------------------------
// <auto-generated>
//     此代码由工具生成。
//     运行时版本:4.0.30319.42000
//
//     对此文件的更改可能会导致不正确的行为，并且如果
//     重新生成代码，这些更改将会丢失。
// </auto-generated>
//------------------------------------------------------------------------------

using DocExamineSystem;
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


namespace DocExamineSystem {
    
    
    /// <summary>
    /// TeamIndex
    /// </summary>
    public partial class TeamIndex : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 15 "..\..\TeamIndex.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button uploadDocButton;
        
        #line default
        #line hidden
        
        
        #line 16 "..\..\TeamIndex.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button oldAllDocButton;
        
        #line default
        #line hidden
        
        
        #line 17 "..\..\TeamIndex.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListBox examineProblemListBox;
        
        #line default
        #line hidden
        
        
        #line 20 "..\..\TeamIndex.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label userNameLabel;
        
        #line default
        #line hidden
        
        
        #line 23 "..\..\TeamIndex.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DocumentViewer documentViewer;
        
        #line default
        #line hidden
        
        
        #line 26 "..\..\TeamIndex.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label docStateLabel;
        
        #line default
        #line hidden
        
        
        #line 28 "..\..\TeamIndex.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button openDocInWordButton;
        
        #line default
        #line hidden
        
        
        #line 29 "..\..\TeamIndex.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button toIndexButton;
        
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
            System.Uri resourceLocater = new System.Uri("/DocExamineSystem;component/teamindex.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\TeamIndex.xaml"
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
            this.uploadDocButton = ((System.Windows.Controls.Button)(target));
            
            #line 15 "..\..\TeamIndex.xaml"
            this.uploadDocButton.Click += new System.Windows.RoutedEventHandler(this.UploadDoc_ButtonClick);
            
            #line default
            #line hidden
            return;
            case 2:
            this.oldAllDocButton = ((System.Windows.Controls.Button)(target));
            
            #line 16 "..\..\TeamIndex.xaml"
            this.oldAllDocButton.Click += new System.Windows.RoutedEventHandler(this.AllDoc_ButtonClick);
            
            #line default
            #line hidden
            return;
            case 3:
            this.examineProblemListBox = ((System.Windows.Controls.ListBox)(target));
            return;
            case 4:
            this.userNameLabel = ((System.Windows.Controls.Label)(target));
            return;
            case 5:
            this.documentViewer = ((System.Windows.Controls.DocumentViewer)(target));
            return;
            case 6:
            this.docStateLabel = ((System.Windows.Controls.Label)(target));
            return;
            case 7:
            this.openDocInWordButton = ((System.Windows.Controls.Button)(target));
            
            #line 28 "..\..\TeamIndex.xaml"
            this.openDocInWordButton.Click += new System.Windows.RoutedEventHandler(this.OpenDocInWord_ButtonClick);
            
            #line default
            #line hidden
            return;
            case 8:
            this.toIndexButton = ((System.Windows.Controls.Button)(target));
            
            #line 29 "..\..\TeamIndex.xaml"
            this.toIndexButton.Click += new System.Windows.RoutedEventHandler(this.ToIndex_ButtonClick);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

