using Addon;

namespace CalculatorAddon
{
    public class Main : IAddon
    {
        public int Id { get; set; }
        public string Name { get; set; } = "Simply calculator";

        public ContentPage Use()
        {
            return new Calculator();
        }
    }
}
