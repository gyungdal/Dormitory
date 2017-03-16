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
using System.Security.Cryptography;
using Newtonsoft.Json.Linq;
using System.Net;

namespace Dormitory
{
    public partial class Login : Form
    {
        private Main viewer = null;

        public Login()
        {
            InitializeComponent();
        }

        private static string Hash(string input)
        {
            var hash = (new SHA1Managed()).ComputeHash(Encoding.UTF8.GetBytes(input));
            return string.Join("", hash.Select(b => b.ToString("x2")).ToArray());
        }

        private JObject getStringFromJSON(string url, List<KeyValuePair<string, string>> param)
        {
            using (WebClient client = new WebClient())
            {
                var reqparm = new System.Collections.Specialized.NameValueCollection();
                foreach (var item in param)
                {
                    reqparm.Add(item.Key, item.Value);
                }
                byte[] responsebytes = client.UploadValues("???", "POST", reqparm);
                string responsebody = Encoding.UTF8.GetString(responsebytes);
                return JObject.Parse(responsebody);
            }
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
