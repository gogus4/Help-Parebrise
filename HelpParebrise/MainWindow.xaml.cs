﻿using FirstFloor.ModernUI.Windows.Controls;
using HelpParebrise;
using HelpParebrise.Common;
using HelpParebrise.Data;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace FirstFloor.ModernUI.App
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : ModernWindow
    {
        public MainWindow()
        {
            InitializeComponent();

            if (ConfigurationManager.AppSettings["Univers"] != "Production")
            {
                IncrementBuildNumber incrementBuildNumber = new IncrementBuildNumber();
            }

            else
            {
                IncrementBuildNumber.Version = ConfigurationManager.AppSettings["Version"];
            }

            this.Version = "version " + IncrementBuildNumber.Version;

            // SQLDataHelper.Instance.getInterventions();
        }
    }
}
