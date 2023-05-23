namespace EldenRing_WebApp.Data
{
    public class Weapon
    {

        public string _id { get; }
        public string name { get; set; }
        public string image { get; set; }
        public string description { get; set; }
        public List<Attribute> attack { get; set; }
        public List<Attribute> defence { get; set; }
        public List<Scaling> scalesWith { get; set; }
        public List<Attribute> requiredAttributes { get; set; }
        public string category { get; set; }
        public float? weight { get; set; }


        public Weapon()
        { }

        public Weapon(string name, string image, string description, List<Attribute> attack, List<Attribute> defence, List<Scaling> scalesWith, List<Attribute> requiredAttributes, string category, float weight)
        {
            this.name = name;
            this.image = image;
            this.description = description;
            this.attack = attack;
            this.defence = defence;
            this.scalesWith = scalesWith;
            this.requiredAttributes = requiredAttributes;
            this.category = category;
            this.weight = weight;

        }
    }
}
