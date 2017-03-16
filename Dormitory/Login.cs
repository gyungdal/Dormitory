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
using System.IO;

namespace Dormitory
{
    public partial class Login : Form
    {
        private Main viewer = null;

        public Login()
        {
            InitializeComponent();
        }

        private static string sha1Encrypt(string input)
        {
            var hash = (new SHA1Managed()).ComputeHash(Encoding.UTF8.GetBytes(input));
            return string.Join("", hash.Select(b => b.ToString("x2")).ToArray());
        }

        private JObject getStringFromJSON(string url, JObject json)
        {
            try{
                var httpWebRequest = (HttpWebRequest)WebRequest.Create(url);
                httpWebRequest.ContentType = "application/json; charset=utf-8";
                httpWebRequest.Method = "POST";
                using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream())) {
                    streamWriter.Write(json);
                    streamWriter.Flush();
                }
                var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
                using (var streamReader = new StreamReader(httpResponse.GetResponseStream())) {
                    var responseText = streamReader.ReadToEnd();
                    return JObject.Parse(responseText);
                }
            } catch(Exception e) {
                MessageBox.Show(e.ToString());
            }
            return null;
        }
            
        private void loginBtn_Click(object sender, EventArgs e)
        {
            string id = this.idText.Text;
            string pw = sha1Encrypt(this.pwText.Text);
            JObject json = new JObject();
            json.Add("id", id);
            json.Add("password", pw);
            
            MessageBox.Show(getStringFromJSON("https://httpbin.org/post", json).ToString());
            bool status = true;
            // status = tryLogin(idText.Text, pwText.Text);
            string type = "teacher";
            if (status)
            {
                Thread viewerThread = new Thread(delegate ()
                {
                    viewer = new Dormitory.Main(type);
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
