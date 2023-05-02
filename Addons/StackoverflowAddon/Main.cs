using Addon;
using StackoverflowAddon.Views;

namespace StackoverflowAddon
{
    public class Main : IAddon
    {
        public int Id { get; set; }
        public string Name { get; set; } = "Stackoverflow addon";

        public ContentPage Use()
        {
            return new MainPage();
        }
    }
}