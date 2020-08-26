using System.ComponentModel.DataAnnotations;

namespace OlavWebsite.Core
{
    public class Cookie
    {
        public int Id { get; set; }
        [Required, StringLength(80)]
        public string Name { get; set; }
        public float Diameter { get; set; }
        public CookieType Type{ get; set; }
    }
}
