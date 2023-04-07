﻿using System;
using System.ComponentModel;
using System.Windows;
using System.Windows.Navigation;
using TestSystem.Pages;

namespace TestSystem
{
    public partial class MainWindow : Window
    {
        public static MainWindow Instance;
        public MainWindow()
        {
            InitializeComponent();
            Closing += ShowCloseMessage;
            Instance = this;
        }
        private void ShowCloseMessage(object sender, CancelEventArgs e)
        {
            if (!Assets.UserMessages.ActionConfirmation("Вы уверены, что хотите закрыть приложение?")) e.Cancel = true;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            //Какая-то логика загрузки дефолтного стиля
            MainWindowStyle.WindowStyle.ChangeDefaultTheme(MainWindowStyle.WindowStyle.Themes.Dark);

            //Логика загрузки дефолтной страницы
            Assets.Navigation.ChangePage(new AuthorizationPage());
        }
    }
}
