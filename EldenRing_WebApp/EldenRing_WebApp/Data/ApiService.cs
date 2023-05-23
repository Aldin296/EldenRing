namespace EldenRing_WebApp.Data
{
	public class ApiService
	{
		public Weapon selectedWeapon { get; set; }
		public ApiService() { }

		public async Task<List<Weapon>> GetWeaponData()
		{
			string link = "http://localhost:8080/weapons";
			HttpClient client = new HttpClient();
			try
			{
				return await client.GetFromJsonAsync<List<Weapon>>(link);

			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.Message);
			}
			return new List<Weapon>();
		}
	}
}
