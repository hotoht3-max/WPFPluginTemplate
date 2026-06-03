using System;
using Tekla.Structures.Dialog.UIControls;

namespace Apibim.Plugins.BuiltUpColumn.Services
{
    public static class TeklaCatalogService
    {
        public static void OpenProfileCatalog(string current, Action<string> onSelect)
        {
            var catalog = new ProfileCatalog();
            catalog.SelectedProfile = current;
            catalog.SelectClicked += (s, args) => onSelect?.Invoke(catalog.SelectedProfile);
            catalog.Show();
        }

        public static void OpenMaterialCatalog(string current, Action<string> onSelect)
        {
            var catalog = new MaterialCatalog();
            catalog.SelectedMaterial = current;
            catalog.SelectClicked += (s, args) => onSelect?.Invoke(catalog.SelectedMaterial);
            catalog.Show();
        }
    }
}