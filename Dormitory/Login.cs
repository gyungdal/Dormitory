using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Dormitory
{
    public partial class Login : Form
    {
        private Main viewer = null;

        public Login()
        {
            InitializeComponent();
        }

        private void loginBtn_Click(object sender, EventArgs e)
        {
            bool status = true;
            // status = tryLogin(idText.Text, pwText.Text);

            if (status)
            {
                Thread viewerThread = new Thread(delegate ()
                {
                    viewer = new Dormitory.Main();
                    viewer.Show();
                    System.Windows.Threading.Dispatcher.Run();
                });

                viewerThread.SetApartmentState(ApartmentState.STA); // needs to be STA or throws exception
                viewerThread.Start();
                this.Close();
            }
        }
    }
}
