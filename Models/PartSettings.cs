namespace Apibim.Plugins.BuiltUpColumn.Models
{
    /// <summary>
    /// Универсальный контейнер атрибутов для любой детали колонны (Ветвь, Решетка, Диафрагма)
    /// </summary>
    public class PartSettings
    {
        public string Profile { get; set; }
        public string Material { get; set; }
        public string PartPrefix { get; set; }
        public int PartStartNo { get; set; }
        public string AssemblyPrefix { get; set; }
        public int AssemblyStartNo { get; set; }
        public string Name { get; set; }
        public string Class { get; set; }
        public string UDA { get; set; }
    }
}