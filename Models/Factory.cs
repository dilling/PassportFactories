using System.Collections.Generic;

namespace PassportCodeChallenge.Models
{
    public class Factory
    {
        public int FactoryId { get; set; }
        public string Name { get; set; }
        public int[] Children { get; set; }
    }
}