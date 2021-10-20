using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EsempioEntityFramework.Models
{
    public class SuperEroe
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Strength { get; set; }
        public bool CanFly { get; set; }
    }
}
