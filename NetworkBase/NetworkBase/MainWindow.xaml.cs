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
using System.Data;

namespace NetworkBase
{
	/// <summary>
	/// Логика взаимодействия для MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		public NetworkBaseEntities db;
		Table selectedTable = new Table();
		Table shownTable = new Table();

		public MainWindow()
		{

			InitializeComponent();
			//OpenLogin();
			db = new NetworkBaseEntities();
			selectedTable = Table.device;
			shownTable = Table.nope;
			insertButtn.IsEnabled = false;
			updateButton.IsEnabled = false;
			deleteButton.IsEnabled = false;
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
			insertButtn.IsEnabled = true;
			updateButton.IsEnabled = true;
			deleteButton.IsEnabled = true;
			tablesGrid.ItemsSource = null ;

			if (selectedTable == Table.device)
			{
				shownTable = selectedTable;
				SelectDevices();
			}

			if (selectedTable == Table.department)
			{
				shownTable = selectedTable;
				SelectDeparments();
			}

			if (selectedTable == Table.user)
			{
				shownTable = selectedTable;
				SelectUsers();
			}
			if (selectedTable == Table.deviceNateworks)
			{
				shownTable = selectedTable;
				SelectDeviceNetworks();
			}
			if (selectedTable == Table.network)
			{
				shownTable = selectedTable;
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

		/// <summary>
		/// Реулизация Insert
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void InsertButtn_Click(object sender, RoutedEventArgs e)
		{
			if (selectedTable == Table.device)
			{
				DevicesWin devicesWin = new DevicesWin(db);

				devicesWin.ShowDialog();
				SelectDevices();
			}

			if (selectedTable == Table.department)
			{
				DepartmentWindow department = new DepartmentWindow(db);

				department.ShowDialog();
				SelectDeparments();
			}

			if (selectedTable == Table.user)
			{
				UsersWindow usersWindow = new UsersWindow(db);
				usersWindow.ShowDialog();
				SelectUsers();
			}

			if (selectedTable == Table.deviceNateworks)
			{
				DeviceNetworksWindow deviceNetworks = new DeviceNetworksWindow(db);
				deviceNetworks.ShowDialog();
				SelectDeviceNetworks();
			}

			if (selectedTable == Table.network)
			{
				NetworksWindow networks = new NetworksWindow(db);
				networks.ShowDialog();
				SelectNetworks();
			}
		}

		/// <summary>
		/// Резервное копирование
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void BackupButton_Click(object sender, RoutedEventArgs e)
		{
			try
			{
				db.Database.ExecuteSqlCommand(TransactionalBehavior.DoNotEnsureTransaction, "EXEC dbo_backup");
				backupLabel.Content = "Резервная копия успешно сделана";
			}
			catch
			{
				MessageBox.Show("Ошибка резервного копирования");
			}
		}

		private void TablesBox_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
		{
			if (tablesBox.SelectedIndex == 0)
			{
				selectedTable = Table.device;
			}

			if (tablesBox.SelectedIndex == 1)
			{
				selectedTable = Table.department;
			}

			if (tablesBox.SelectedIndex == 2)
			{
				selectedTable = Table.user;
			}
			if (tablesBox.SelectedIndex == 3)
			{
				selectedTable = Table.deviceNateworks;
			}
			if (tablesBox.SelectedIndex == 4)
			{
				selectedTable = Table.network;
			}

		}

		/// <summary>
		/// Реализация Update
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void UpdateButton_Click(object sender, RoutedEventArgs e)
		{
			//Устройства
			if (shownTable == Table.device)
			{
				Devices device = tablesGrid.SelectedItem as Devices;
				var uDevice = db.Devices.Where(d => d.deviceID == device.deviceID).FirstOrDefault();

				DevicesWin window = new DevicesWin(db, uDevice);

				window.ShowDialog();

				SelectDevices();
			}

			//Отделы
			if (shownTable == Table.department)
			{
				Departments department = tablesGrid.SelectedItem as Departments;
				var udepartment = db.Departments.Where(d => d.departmentID == department.departmentID).FirstOrDefault();

				DepartmentWindow window = new DepartmentWindow(db, udepartment);

				window.ShowDialog();

				SelectDeparments();
			}

			//Пользователи
			if (shownTable == Table.user)
			{
				Users user = tablesGrid.SelectedItem as Users;
				var uUser = db.Users.Where(u => u.userID == user.userID).FirstOrDefault();

				UsersWindow window = new UsersWindow(db, uUser);

				window.ShowDialog();

				SelectUsers();
			}

			//Сети устройства
			if (shownTable == Table.deviceNateworks)
			{
				DeviceNetworks network = tablesGrid.SelectedItem as DeviceNetworks;
				var uNetwork = db.DeviceNetworks.Where(n => n.networkID == network.networkID && n.deviceID == network.deviceID).FirstOrDefault();

				DeviceNetworksWindow window = new DeviceNetworksWindow(db, uNetwork);

				window.ShowDialog();

				SelectDeviceNetworks();
			}

			//Сети
			if (shownTable == Table.network)
			{
				Networks network = tablesGrid.SelectedItem as Networks;
				var uNetwork = db.Networks.Where(n => n.networkID == network.networkID).FirstOrDefault();

				NetworksWindow window = new NetworksWindow(db, uNetwork);

				window.ShowDialog();

				SelectNetworks();
			}



		}

		/// <summary>
		/// Реализация Delete
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void DeleteButton_Click(object sender, RoutedEventArgs e)
		{
			if (MessageBox.Show("Вы уверены, что хотите удалить этот элемент?", "Удаление элемента", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
			{
				if (shownTable == Table.device)
				{
					DeleteDevice();
					SelectDevices();
				}
				if (shownTable == Table.department)
				{
					DeleteDepartment();
					SelectDeparments();
				}
				if (shownTable == Table.user)
				{
					DeleteUser();
					SelectUsers();
				}
				if (shownTable == Table.deviceNateworks)
				{
					DeleteDeviceNetworks();
					SelectDeviceNetworks();	
				}
				if (shownTable == Table.network)
				{
					DeleteNetworks();
					SelectNetworks();
				}
			}
		}

		/// <summary>
		/// Удаление устройства
		/// </summary>
		private void DeleteDevice()
		{
			try
			{
				Devices device = tablesGrid.SelectedItem as Devices;
				var dDevice = db.Devices.Where(d => d.deviceID == device.deviceID).FirstOrDefault();


				db.Devices.Remove(dDevice);
				db.SaveChanges();
			}
			catch
			{
				MessageBox.Show("Ошибка удаления данных из базы");
			}
		}

		/// <summary>
		/// Удаление отдела
		/// </summary>
		private void DeleteDepartment()
		{
			try
			{
				Departments department = tablesGrid.SelectedItem as Departments;
				var dDepartment = db.Departments.Where(u => u.departmentID == department.departmentID).FirstOrDefault();


				db.Departments.Remove(dDepartment);
				db.SaveChanges();
			}
			catch
			{
				MessageBox.Show("Ошибка удаления данных из базы");
			}
		}

		/// <summary>
		/// Удаление пользователя
		/// </summary>
		private void DeleteUser()
		{
			try
			{
				Users user = tablesGrid.SelectedItem as Users;
				var dUser = db.Users.Where(u => u.userID == user.userID).FirstOrDefault();


				db.Users.Remove(dUser);
				db.SaveChanges();
			}
			catch
			{
				MessageBox.Show("Ошибка удаления данных из базы");
			}
		}


		/// <summary>
		/// Удаление сетей устройства
		/// </summary>
		private void DeleteDeviceNetworks()
		{
			try
			{
				DeviceNetworks network = tablesGrid.SelectedItem as DeviceNetworks;
				var dNetwork = db.DeviceNetworks.Where(n => n.networkID == network.networkID && n.deviceID == network.deviceID).FirstOrDefault();


				db.DeviceNetworks.Remove(dNetwork);
				db.SaveChanges();
			}
			catch
			{
				MessageBox.Show("Ошибка удаления данных из базы");
			}
		}


		/// <summary>
		/// Удаление сети
		/// </summary>
		private void DeleteNetworks()
		{
			try
			{
				Networks network = tablesGrid.SelectedItem as Networks;
				var dNetwork = db.Networks.Where(n => n.networkID == network.networkID).FirstOrDefault();


				db.Networks.Remove(dNetwork);
				db.SaveChanges();
			}
			catch
			{
				MessageBox.Show("Ошибка удаления данных из базы");
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
