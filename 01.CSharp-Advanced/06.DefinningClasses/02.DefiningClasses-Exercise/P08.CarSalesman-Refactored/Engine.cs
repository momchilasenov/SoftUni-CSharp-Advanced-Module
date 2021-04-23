using System.Text;

namespace DefiningClasses
{
    public class Engine
    {
        public Engine(string model, int power)
        {
            this.Model = model;
            this.Power = power;
        }

        public Engine(string model, int power, int displacement)
            :this(model, power)
        {
            this.Displacement = displacement;
        }

        public Engine(string model, int power, string efficiency)
            :this(model,power)
        {
            this.Efficiency = efficiency;
        }

        public Engine (string model, int power, int displacement, string efficiency)
            :this(model, power)
        {
            this.Displacement = displacement;
            this.Efficiency = efficiency;
        }

        public string Model { get; set; }

        public int Power { get; set; }

        public int? Displacement { get; set; } //nullable int


        public string Efficiency { get; set; }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            string displacementStr = 
                this.Displacement.HasValue ? this.Displacement.ToString() : "n/a";
            string efficiencyStr = 
                string.IsNullOrEmpty(this.Efficiency) ? this.Efficiency : "n/a";

            sb.AppendLine($"  {this.Model}:")
                .AppendLine($"    Power: {this.Power}")
                .AppendLine($"    Displacement: {displacementStr}")
                .AppendLine($"    Efficiency: {efficiencyStr}");

            return sb.ToString().TrimEnd();
        }
    }
}
