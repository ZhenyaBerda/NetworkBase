using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Data.Entity;
using System.Windows.Data;
using System.Windows.Input;
using System.Data.SqlClient;

namespace NetworkBase
{
	/// <summary>
	/// Логика взаимодействия для MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		public NetworkBaseEntities db = new NetworkBaseEntities();
		Table selectedTable = new Table();

		public MainWindow()
		{
			InitializeComponent();
			//OpenLogin();
		}

		void OpenLogin()
		{
			login login = new login();
			login.ShowDialog();
		}

		
		/// <summary>
		/// Функция для представления выбранной таблицы
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void ShowButton_Click(object sender, RoutedEventArgs e)
		{
			tablesGrid.ItemsSource = null ;

			if (tablesBox.SelectedIndex == 0)
			{
				selectedTable = Table.device;
				SelectDevices();
			}

			if (tablesBox.SelectedIndex == 1)
			{
				selectedTable = Table.department;
				SelectDeparments();
			}

			if (tablesBox.SelectedIndex == 2)
			{
				selectedTable = Table.user;
				SelectUsers();
			}
			if (tablesBox.SelectedIndex == 3)
			{
				selectedTable = Table.deviceNateworks;
				SelectDeviceNetworks();
			}
			if (tablesBox.SelectedIndex == 4)
			{
				selectedTable = Table.network;
				SelectNetworks();
			}

		}


		/// <summary>
		/// Запрос SELECT для таблицы Devices
		/// </summary>
		private void SelectDevices()
		{
			int linesNumber = -1;
			
			if (numberBox.Text.Length>0)
				linesNumber=Int32.Parse(numberBox.Text);

			if (linesNumber == -1)
			{
				var query = db.Database.SqlQuery<Devices>("SELECT * FROM Devices");
				
				tablesGrid.ItemsSource = query.ToList();
			}
			else
			{
				SqlParameter sqlParameter = new SqlParameter("@top", linesNumber);
				var query = db.Database.SqlQuery<Devices>("SELECT * FROM dbo_top_devices(@top)", sqlParameter);

				tablesGrid.ItemsSource = query.ToList();
			}

		}

		/// <summary>
		/// Запрос SELECT для Users
		/// </summary>
		private void SelectUsers()
		{
			int linesNumber = -1;

			if (numberBox.Text.Length > 0)
				linesNumber = Int32.Parse(numberBox.Text);

			if (linesNumber == -1)
			{
				var query = db.Database.SqlQuery<Users>("SELECT * FROM Users");

				tablesGrid.ItemsSource = query.ToList();
			}
			else
			{
				SqlParameter sqlParameter = new SqlParameter("@top", linesNumber);
				var query = db.Database.SqlQuery<Users>("SELECT * FROM dbo_top_users(@top)", sqlParameter);

				tablesGrid.ItemsSource = query.ToList();
			}
		}

		private void SelectDeparments()
		{
			int linesNumber = -1;

			if (numberBox.Text.Length > 0)
				linesNumber = Int32.Parse(numberBox.Text);

			if (linesNumber == -1)
			{
				var query = db.Database.SqlQuery<Departments>("SELECT * FROM Departments");

				tablesGrid.ItemsSource = query.ToList();
			}
			else
			{
				SqlParameter sqlParameter = new SqlParameter("@top", linesNumber);
				var query = db.Database.SqlQuery<Departments>("SELECT * FROM dbo_top_departments(@top)", sqlParameter);

				tablesGrid.ItemsSource = query.ToList();
			}
		}
		private void SelectDeviceNetworks()
		{
			int linesNumber = -1;

			if (numberBox.Text.Length > 0)
				linesNumber = Int32.Parse(numberBox.Text);

			if (linesNumber == -1)
			{
				var query = db.Database.SqlQuery<DeviceNetworks>("SELECT * FROM DeviceNetworks");

				tablesGrid.ItemsSource = query.ToList();
			}
			else
			{
				SqlParameter sqlParameter = new SqlParameter("@top", linesNumber);
				var query = db.Database.SqlQuery<DeviceNetworks>("SELECT * FROM dbo_top_deviceNetworks(@top)", sqlParameter);

				tablesGrid.ItemsSource = query.ToList();
			}
		}
		private void SelectNetworks()
		{
			int linesNumber = -1;

			if (numberBox.Text.Length > 0)
				linesNumber = Int32.Parse(numberBox.Text);

			if (linesNumber == -1)
			{
				var query = db.Database.SqlQuery<Networks>("SELECT * FROM Networks");

				tablesGrid.ItemsSource = query.ToList();
			}
			else
			{
				SqlParameter sqlParameter = new SqlParameter("@top", linesNumber);
				var query = db.Database.SqlQuery<Networks>("SELECT * FROM dbo_top_networks(@top)", sqlParameter);

				tablesGrid.ItemsSource = query.ToList();
			}
		}

		/// <summary>
		/// Проверка ввода цифр в numberBox
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void NumberBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
		{
			if (!Char.IsDigit(e.Text, 0)) e.Handled = true;
		}

		private void InsertButtn_Click(object sender, RoutedEventArgs e)
		{
			if (selectedTable == Table.device)
			{
				DevicesWin devicesWin = new DevicesWin(db);

				devicesWin.Show();
			}
		}
	}
}
/*query =
				from device in db.Devices
				select new
				{
					device.deviceID,
					device.deviceName,
					device.deviceType,
					device.deviceOS,
					device.deviceSNumber,
					device.departmentID
				};

				tablesGrid.ItemsSource = query.ToList();*/
