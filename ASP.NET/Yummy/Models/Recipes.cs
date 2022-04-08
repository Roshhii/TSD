using System.ComponentModel.DataAnnotations;

namespace Yummy.Models
{
    public class Recipes
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public double Time { get; set; }
        public string? Difficulty { get; set; }
        public int LikesNumber { get; set; }
        public string? Ingredients { get; set; }
        public string? Process { get; set; }
        public string? TipsTricks { get; set; }
    }
}