namespace EldenRing_WebApp.Data
{
    public class Scaling
    {
        public string name { get; set; }
        public string scaling { get; set; }

        public Scaling(string name, string scaling)
        {
            this.name = name;
            this.scaling = scaling;
        }
    }
}
