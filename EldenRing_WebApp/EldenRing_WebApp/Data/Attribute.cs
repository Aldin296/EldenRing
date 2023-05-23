namespace EldenRing_WebApp.Data
{
    public class Attribute
    {
        public string name { get; set; }
        public int amount { get; set; }

        public Attribute(string name, int amount)
        {
            this.name = name;
            this.amount = amount;
        }
    }
}
