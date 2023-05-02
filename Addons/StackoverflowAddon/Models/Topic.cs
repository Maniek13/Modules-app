using StackoverflowAddon.Interfaces;

namespace StackoverflowAddon.Models
{
    public class Topic : ITopic
    {
        public bool HasSynonyms { get; set; }
        public bool IsModeratorOnly { get; set; }
        public bool IsRequired { get; set; }
        public int Count { get; set; }
        public string Name { get; set; }
    }
}
