namespace Dormitory {
    class PointItem {
        string schoolNumber { get; set; }
        string placeholder { get; set; }
        string name { get; set; }
        int point { get; set; }
        string memo { get; set; }

        bool isPlus { get {
                return (point > 0);
            }
        }
        bool isMinus {
            get {
                return (point > 0);
            }
        }
    }
}