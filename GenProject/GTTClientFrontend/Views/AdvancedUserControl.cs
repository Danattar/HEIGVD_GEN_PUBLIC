using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;

namespace GTTClientFrontend.Views
{
    public class AdvancedUserControl : UserControl
    {
        public void TextBox_Loaded(object sender, RoutedEventArgs e)
        {
            var self = sender as TextBox;

            if (self != null) self.Focus();
        }
    }
}
