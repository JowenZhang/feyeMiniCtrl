using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace FeyeUav.Iaas.SocketPrototype.Client
{
    /// <summary>
    /// Interaction logic for SettingWindow.xaml
    /// </summary>
    public partial class SettingWindow : Window
    {
        public SettingWindow()
        {
            InitializeComponent();
        }

        private void ValidConfirm(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
            e.Handled = true;
        }

        private void Confirm(object sender, ExecutedRoutedEventArgs e)
        {
            bool tag = rbtSend.IsChecked.HasValue?rbtSend.IsChecked.Value:false;
            if (Setting != null)
            {
                Setting(tag);
            }
            Close();
        }

        public event Action<bool> Setting;
    }
}
