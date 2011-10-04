﻿// Copyright 2011 Denis Markelov
// This code is distributed under Microsoft Public License 
// (for details please see \docs\Ms-PL)

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Windows.Media.Animation;
using AssemblyVisualizer.Controls.ZoomControl;
using AssemblyVisualizer.Model;
using AssemblyVisualizer.Behaviors;

namespace AssemblyVisualizer.TypeBrowser
{   
    partial class TypeBrowserWindow : Window
    {
        public TypeBrowserWindow(IEnumerable<TypeInfo> types)
        {
            InitializeComponent();

            Loaded += new RoutedEventHandler(LoadedHandler);
            Unloaded += new RoutedEventHandler(UnloadedHandler);

            ViewModel = new TypeBrowserWindowViewModel(types);

            ViewModel.FillGraphRequest += FillGraphRequestHandler;
            ViewModel.OriginalSizeRequest += OriginalSizeRequestHandler;    

            WindowManager.AddTypeBrowser(this); 
        }

        private void LoadedHandler(object sender, RoutedEventArgs e)
        {
            gridTypeSelector.SetValue(VisibilityAnimation.AnimationTypeProperty, VisibilityAnimation.AnimationType.Fade);
        }

        private void UnloadedHandler(object sender, RoutedEventArgs e)
        {
            gridTypeSelector.SetValue(VisibilityAnimation.AnimationTypeProperty, VisibilityAnimation.AnimationType.None);
        }

        public TypeBrowserWindowViewModel ViewModel
        {
            get
            {
                return DataContext as TypeBrowserWindowViewModel;
            }
            set
            {
                DataContext = value;
            }
        }

        protected override void OnClosed(EventArgs e)
        {
            base.OnClosed(e);

            WindowManager.RemoveTypeBrowser(this);
        }        
                
        private void FillGraphRequestHandler()
        {
            zoomControl.ZoomToFill();
        }

        private void OriginalSizeRequestHandler()
        {
            var animation = new DoubleAnimation(1, TimeSpan.FromSeconds(0.5));
            zoomControl.BeginAnimation(ZoomControl.ZoomProperty, animation);
        }  
    }
}