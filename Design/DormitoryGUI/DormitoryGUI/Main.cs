using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DormitoryGUI
{
    public partial class Main : Form
    {
        private Info.PERMISSION permission;

        internal Info.PERMISSION Permission { get => permission; set => permission = value; }

        public Main()
        {
            InitializeComponent();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            Permission permission = new Permission();
            permission.Show();
        }
    }
}
