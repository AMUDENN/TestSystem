﻿using System.Windows;
using System;
using System.Windows.Controls;

namespace TestSystem.Pages
{
    public partial class AuthorizationPage : Page
    {
        public AuthorizationPage()
        {
            InitializeComponent();

            DataContext = new ViewModels.AuthorizationVM();
        }
    }
}
