using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DormitoryGUI
{
    public partial class Login : Form
    {
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
            try
            {
                HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(url);
                httpWebRequest.ContentType = "application/json";
                httpWebRequest.Method = "POST";
                byte[] postBody = Encoding.UTF8.GetBytes(json.ToString());
                using (Stream stream = httpWebRequest.GetRequestStream())
                {
                    stream.Write(postBody, 0, postBody.Length);
                    using (HttpWebResponse httpResponse = (HttpWebResponse)httpWebRequest.GetResponse())
                    {
                        if (httpResponse.StatusCode != HttpStatusCode.OK)
                            return JObject.Parse("{\"status\":false}");
                        using (StreamReader streamReader = new StreamReader(httpResponse.GetResponseStream()))
                        {
                            string result = streamReader.ReadToEnd();
                            return JObject.Parse(result);
                        }
                    }
                }
            }
            catch (Exception e)
            {
                return JObject.Parse("{\"status\":false}");
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            JObject data = new JObject();
            data.Add("id", this.id.Text);
            data.Add("password", sha1Encrypt(this.pw.Text));
            JObject response = getStringFromJSON(Info.Server.LOGIN_URL, data);
            bool status = Boolean.Parse(response["status"].ToString());
            Info.PERMISSION getPermissionFromJson(int tt)
            {
                switch (tt)
                {
                    case 0:
                        return Info.PERMISSION.ADMIN;
                    case 1:    
                        return Info.PERMISSION.DORMITORY_TEACHER;
                    case 2:    
                        return Info.PERMISSION.NORMAL_TEACHER;
                    default:  
                        return Info.PERMISSION.ERROR;
                }
            }
            if (status)
            {
                Info.PERMISSION permission = getPermissionFromJson(Int32.Parse(response["permission"].ToString()));
                Main main = new Main();
                main.Permission = permission;
                this.Hide();
                main.Closed += (s, args) => this.Close();
                main.Show();
            }
            else
            {
                MessageBox.Show("Login fail...");
            }
        }
    }
}
