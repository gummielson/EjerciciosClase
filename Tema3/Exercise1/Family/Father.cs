using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise1.Family
{
    public class Father : Grandfather
    {
        public int MyFatherProp1 { get; set; }
        protected int MyFatherProp2 { get; set; }
        private int MyFatherProp3 { get; set; }
    }
}
