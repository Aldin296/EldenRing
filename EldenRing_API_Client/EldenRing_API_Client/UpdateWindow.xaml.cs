using EldenRing_API_Client.Modles;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
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
using Attribute = EldenRing_API_Client.Modles.Attribute;

namespace EldenRing_API_Client
{
    /// <summary>
    /// Interaktionslogik für UpdateWindow.xaml
    /// </summary>
    public partial class UpdateWindow : Window
    {
        List<Weapon> weapons = new List<Weapon>();
        Weapon weapon;
		HttpClient client = new HttpClient();
        string baseaddres = "http://localhost:8080/";
		string name_before_update = "";

		public UpdateWindow(object selectedWeapon)
        {
			client.BaseAddress = new Uri(baseaddres);

			InitializeComponent();
            weapon = selectedWeapon as Weapon;
			DataContext = selectedWeapon;

           
			weapons.Add(selectedWeapon as Weapon);
			AttackDataGrid.ItemsSource = weapons;
            DefenceDataGrid.ItemsSource = weapons;
            RequiredAttributeDataGrid.ItemsSource = weapons;
            ScalingDataGrid.ItemsSource = weapons;

            Console.WriteLine("Updated Weapon:"+ weapon.name);
        }


		private void UpdateButton_Click(object sender, RoutedEventArgs e)
		{
            UpdateCall();

		}

        private async void UpdateCall()
        {
			string json = JsonConvert.SerializeObject(weapon);
			Console.WriteLine(json);
			var content = new StringContent(json, Encoding.UTF8, "application/json");

			HttpResponseMessage response = await client.PutAsJsonAsync("updateWeapon/" + name_before_update, weapon);

			if (response.IsSuccessStatusCode)
			{
				Console.WriteLine("Weapon updated successfully.");
			}
			else
			{
				Console.WriteLine("Error updating weapon: " + response.StatusCode);
			}
		}

		private void txtName_GotFocus(object sender, RoutedEventArgs e)
		{
			name_before_update = txtName.Text;

		}
	}
}
