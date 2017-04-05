using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DormitoryGUI
{
    class ScoreListItem
    {
        public string 항목명 { get; set; }
        public string 상벌점_분류 { get; set; }
        public string 점수 { get; set; }
        public string 메모 { get; set; }
        public int 총_상점 { get; set; }
        public int 총_벌점 { get; set; }
        public DateTime 부여시간 { get; set; }
    }
}
