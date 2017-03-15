using System;

namespace Dormitory {
    public class DormitoryScore {
        public DateTime time { get; set; }
        public string name { get; set; }
        public short score { get; set; }

        public bool isGroup(DormitoryScore ds) => ds.name.Equals(name);
        public bool isBadScore { get => score < 0; }


    }
}   