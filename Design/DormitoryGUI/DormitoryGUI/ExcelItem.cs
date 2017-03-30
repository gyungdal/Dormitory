using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DormitoryGUI
{
    class ExcelItem
    {
        public string name { get; set; }
        public int num { get; set; }
        public int room_number { get; set; }
        public int good_point { get; set; }
        public int bad_point { get; set; }

        public override string ToString()
        {
            string result = "Name : " + name;
            result += "\nNum : " + num;
            result += "\nRoom : " + room_number;
            result += "\nGood : " + good_point;
            result += "\nBad : " + bad_point;
            return result;
        }
    }
}
