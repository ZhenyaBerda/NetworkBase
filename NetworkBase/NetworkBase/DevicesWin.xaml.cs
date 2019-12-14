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
using System.Windows.Shapes;

namespace NetworkBase
{
    /// <summary>
    /// Логика взаимодействия для DevicesWin.xaml
    /// </summary>
    public partial class DevicesWin : Window
    {
		Table selectedTable;

        public DevicesWin(Table table)
        {
			selectedTable = table;

			InitializeComponent();
        }

		private void Button_Click(object sender, RoutedEventArgs e)
		{


		}
	}
}
