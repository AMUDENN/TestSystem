﻿using CommunityToolkit.Mvvm.ComponentModel;
using Microsoft.Win32;
using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using TestSystem.Models;
using TestSystem.Utilities;

namespace TestSystem.ViewModels
{
    public class HomeViewModel : ObservableObject
    {
        public UserModel userModel;
        public UserModel UserModel
        {
            private get => userModel;
            set => SetProperty(ref userModel, value);
        }
        private RelayCommand exportCommand;
        private RelayCommand importCommand;
        public ICommand ExportCommand
        {
            get
            {
                return exportCommand ??
                  (exportCommand = new RelayCommand(
                    (obj) =>
                    {
                        var context = Context.GetContext();
                        SaveFileDialog sfd = new SaveFileDialog();
                        sfd.Filter = "Text Files (*.txt)|*.txt";
                        string fileName = "";
                        if (sfd.ShowDialog() == true) fileName = sfd.FileName;
                        if (fileName == "") return;

                        StreamWriter sw = new StreamWriter(fileName);
                        var result = context.Users.AsEnumerable().Select(x => String.Join(":", x.id, x.name, x.surname, x.email, x.password));
                        string IDline = String.Join("\n", result);
                        sw.WriteLine(IDline);
                        sw.Close();
                        Process.Start("notepad.exe", fileName);
                    }
                  ));
            }
        }
        public ICommand ImportCommand
        {
            get
            {
                return importCommand ??
                  (importCommand = new RelayCommand(
                    (obj) =>
                    {
                        OpenFileDialog ofd = new OpenFileDialog();
                        ofd.ShowDialog();
                        if (string.IsNullOrEmpty(ofd.FileName))
                        {
                            UserMessages.Error("Файл для импорта не выбран!");
                            return;
                        }
                        StreamReader sr = new StreamReader(ofd.FileName);
                        string final = "";
                        while (!sr.EndOfStream)
                        {
                            string line = sr.ReadLine();
                            string[] data = line.Split(':');
                            final += $"Данные в файле: \nID: {data[0]}\nИмя: {data[1]}\nФамилия: {data[2]}\nПочта: {data[3]}\nПароль: {data[4]}\n";
                        }
                        sr.Close();
                        MessageBox.Show(final);
                    }
                  ));
            }
        }
        public HomeViewModel(UserModel userModel)
        {
            UserModel = userModel;
        }
    }
}
