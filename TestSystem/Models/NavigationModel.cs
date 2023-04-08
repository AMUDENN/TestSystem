﻿using CommunityToolkit.Mvvm.ComponentModel;

namespace TestSystem.Models
{
    public class NavigationModel
    {
        public string Name { get; set; }
        public ObservableObject DestinationVM { get; set; }
    }
}
