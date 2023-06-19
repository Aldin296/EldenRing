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
	/// Interaktionslogik für PostPage.xaml
	/// </summary>
	public partial class PostPage : Window
	{
		List<Weapon> weapons = new List<Weapon>();
		public Weapon weapon;
		HttpClient client = new HttpClient();
		string baseaddres = "http://localhost:8080/";
		string name_before_update = "";
		public PostPage()
		{
			client.BaseAddress = new Uri(baseaddres);

			InitializeComponent();

			weapon = new Weapon()
			{
				name = "",
				image = "",
				attack = new List<Attribute>
				{
					new Attribute(name: "Phy", amount: 0),
					new Attribute(name: "Mag", amount: 0),
					new Attribute(name: "Fire", amount: 0),
					new Attribute(name: "Ligt", 0),
					new Attribute(name: "Holy", amount: 0),
					new Attribute(name: "Crit", amount: 0),
				},
				defence = new List<Attribute>
				{
					new Attribute(name: "Phy", amount: 0),
					new Attribute(name: "Mag", amount: 0),
					new Attribute(name: "Fire", amount: 0),
					new Attribute(name: "Ligt", 0),
					new Attribute(name: "Holy", amount: 0),
					new Attribute(name: "Crit", amount: 0),
				},

				requiredAttributes = new List<Attribute>
				{
					new Attribute(name: "Phy", amount: 0),
					new Attribute(name: "Mag", amount: 0),
					new Attribute(name: "Fire", amount: 0),
					new Attribute(name: "Ligt", 0),
					new Attribute(name: "Holy", amount: 0),
					new Attribute(name: "Crit", amount: 0),
				},

				scalesWith = new List<Scaling>
				{
					new Scaling(name: "Str", scaling: " "),
					new Scaling(name: "Dex", scaling: " "),
					new Scaling(name: "Int", scaling: " "),
					new Scaling(name: "Fai", scaling: " "),
					new Scaling(name: "Arc", scaling: " "),
				},
				description = "",
				weight = 0.0f,
				category = "",
			};

			DataContext = weapon;
			weapons.Add(weapon);
			AttackDataGrid.ItemsSource = weapons;
			DefenceDataGrid.ItemsSource = weapons;
			RequiredAttributeDataGrid.ItemsSource = weapons;
			ScalingDataGrid.ItemsSource = weapons;

		}

		private void PostButton_Click(object sender, RoutedEventArgs e)
		{
			string json = JsonConvert.SerializeObject(weapon);
			Console.WriteLine(json);
			var content = new StringContent(json, Encoding.UTF8, "application/json");

			try
			{
				var response = client.PostAsync("addWeapon", content).Result;
				if (response.IsSuccessStatusCode)
				{
					Console.WriteLine("Weapon posting successfully.");
				}
				else
				{
					Console.WriteLine("Error posting weapon: " + response.StatusCode);
				}
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.Message);
			}
		}
	}
}
