using System;
using System.Collections.Generic;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace APK2.Interfaces.Controls
{
    /// <summary>
    /// Логика взаимодействия для CounterpartySelectControl.xaml
    /// </summary>
    public partial class CounterpartySelectControl : UserControl
    {
        public CounterpartySelectControl()
        {
            InitializeComponent();
        }

        private void TextChangedEventHandler(object sender, TextChangedEventArgs args)
        {
            if(SerchString.Text.Length>3) 
                {
                CounterpatyPopupGrid.IsOpen=true;
            }
        }

        private void lb_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            SerchString.Text = LbCounterparty.SelectedValue.ToString();
        }
             
    }
}
