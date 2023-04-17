using Addon;
using System.Collections.ObjectModel;
using System.Reflection;

namespace App.ViewModels
{
    public class MainPageViewModel
    {
        #region private members
        private readonly ObservableCollection<IAddon> addons;
        #endregion

        #region property
        public ObservableCollection<IAddon> Addons { get { return addons; } }
        #endregion

        internal MainPageViewModel()
        {
            addons = SetAddons();
        }

        private ObservableCollection<IAddon> SetAddons()
        {
            ObservableCollection<IAddon> addons = new();

            var path = AppDomain.CurrentDomain.BaseDirectory;
            path = Path.Combine(path, "plugins");

            if (Directory.Exists(path))
            {
                string[] filenames = Directory.GetFiles(path);
                foreach (string filename in filenames)
                {
                    Assembly assembly = Assembly.LoadFrom(filename);

                    Type pluginType = assembly.ExportedTypes.Single(t => typeof(IAddon).IsAssignableFrom(t));
                    var plugin = (IAddon)Activator.CreateInstance(pluginType);
                    addons.Add(plugin);
                }
            }

            return addons;
        }
    }
}
