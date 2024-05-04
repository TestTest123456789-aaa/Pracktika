using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Практика_27.Models
{
    public class Kinoteatr
    {
        public int id { get; set; }
        public string Name { get; set; }
        public int CountZal { get; set; }
        public int Count { get; set; }

        public Kinoteatr(int Id, string Name, int CountZal, int Count)
        {
            this.id = Id;
            this.Name = Name;
            this.CountZal = CountZal;
            this.Count = Count;
        }
    }
}
