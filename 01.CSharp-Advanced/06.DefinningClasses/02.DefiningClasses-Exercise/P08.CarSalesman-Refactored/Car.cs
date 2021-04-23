using System.Text;

namespace DefiningClasses
{
    class Car
    {
        public Car(string model, Engine engine)
        {
            this.Model = model;
            this.Engine = engine;
        }

        public Car(string model, Engine engine, int weight)
            : this(model, engine)
        {
            this.Weight = weight;
        }

        public Car(string model, Engine engine, string color)
            : this(model, engine)
        {
            this.Color = color;
        }

        public Car(string model, Engine engine, int weight, string color)
            : this(model, engine)
        {
            this.Weight = weight;
            this.Color = color;
        }


        public string Model { get; set; }

        public Engine Engine { get; set; }

        public int? Weight { get; set; }

        public string Color { get; set; }


        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            string weightStr = this.Weight.HasValue ? this.Weight.ToString() : "n/a";
            string colorStr = string.IsNullOrEmpty(this.Color) ? this.Color : "n/a";

            sb.AppendLine(this.Model)
                .AppendLine($"  {this.Engine}:")
                .AppendLine($"  Weight: {weightStr}")
                .AppendLine($"  Color: {colorStr}");

            return sb.ToString().TrimEnd();
                
        }
    }
}
