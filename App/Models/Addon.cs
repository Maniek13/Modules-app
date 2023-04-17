using Addon;

namespace App.Models
{
    public class Addon : IAddon
    {
        public int Id { get; set; }
        public string Name { get; set; } = "test";

        public ContentPage Use()
        {
            ContentPage page = new ContentPage();
            page.Title = Name;
            return page;
        }
    }
}
