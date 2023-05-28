using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise1.Family
{
    public class Grandfather
    {
        public string MyGrandpaProp1 { get; set; } = string.Empty;
        protected string MyGrandpaProp2 { get; set; } = string.Empty;
        private string MyGrandpaProp3 { get; set; } = string.Empty; 

        public void SetMyGrandpaProp3(string value)
        {
            MyGrandpaProp3 = value;
        }

        public string GetMyGrandpaProp3()
        {
            return MyGrandpaProp3;
        }
    }
}
