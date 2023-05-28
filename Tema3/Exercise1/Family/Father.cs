using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise1.Family
{
    public class Father : Grandfather
    {
        public string MyFatherProp1 { get; set; } = string.Empty;
        protected string MyFatherProp2 { get; set; } = string.Empty;
        private string MyFatherProp3 { get; set; } = string.Empty;

        public void SetMyFatherProp3(string value)
        {
            MyFatherProp3 = value;
        }

        public string GetMyFatherProp3()
        {
            return MyFatherProp3;
        }
    }
}
