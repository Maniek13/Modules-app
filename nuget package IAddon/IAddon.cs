namespace Addon
{
    public interface IAddon
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public ContentPage Use();
    }
}
