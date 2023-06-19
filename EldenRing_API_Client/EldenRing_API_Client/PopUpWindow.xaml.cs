using EldenRing_API_Client.Modles;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
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

namespace EldenRing_API_Client
{
	/// <summary>
	/// Interaktionslogik für PopUpWindow.xaml
	/// </summary>
	public partial class PopUpWindow : Window
	{
		Weapon selectedweapon = new Weapon();
		ListView lw = new ListView();
		ObservableCollection<Weapon> weaponsList;
		HttpClient client = new HttpClient();
		string baseaddres = "http://localhost:8080/";
		public PopUpWindow(object weapon, ListView listView, ObservableCollection<Weapon> weapons)
		{
			client.BaseAddress = new Uri(baseaddres);

			DataContext = weapon;
			selectedweapon = weapon as Weapon;
			lw = listView;
			weaponsList = weapons;
			InitializeComponent();
		}

		private void Details_Button_Click(object sender, RoutedEventArgs e)
		{
			DetailsWindow details = new DetailsWindow(selectedweapon);
			details.Show();
			Close();
		}

		private void Update_Button_Click(object sender, RoutedEventArgs e)
		{
			UpdateWindow updateWindow = new UpdateWindow(selectedweapon);
			updateWindow.Show();
			Close();
		}

		private async void Delete_Button_Click(object sender, RoutedEventArgs e)
		{
			if (lw.SelectedItem != null)
			{
				Weapon selectedWeapon = lw.SelectedItem as Weapon;


				HttpResponseMessage response = await client.DeleteAsync("deleteWeapon/" + selectedWeapon.name);
				if (response.IsSuccessStatusCode)
				{
					weaponsList.Remove(selectedWeapon);
					Console.WriteLine("Weapon deleted successfully.");
				}
				else
				{
					Console.WriteLine("Error deleting weapon: " + response.StatusCode);
				}

			}
			Close();

		}
	}
}
