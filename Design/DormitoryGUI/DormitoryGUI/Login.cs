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
            this.Text = "로그인";
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
                            return JObject.Parse("{}");
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
                return JObject.Parse("{}");
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            JObject data = new JObject();
            data.Add("id", this.id.Text);
            data.Add("password", sha1Encrypt(this.pw.Text));
            JObject response = getStringFromJSON(Info.Server.LOGIN_URL, data);
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
            //{{  "TEACHER_UUID": 1,  "USER_NAME": "GyunWoong",  "PERMISSION_TYPE": 0,  "ID": "tester", 
            //"PASSWORD": "a94a8fe5ccb19ba61c4c0873d391e987982fbbd3",  "STUDENT_MANAGE": 1,  "SCORE_MANAGE": 1}}
            if (response["TEACHER_UUID"] != null)
            {
                Info.PERMISSION permission = getPermissionFromJson(Int32.Parse(response["PERMISSION_TYPE"].ToString()));
                Main main = new Main();
                main.PermissionType = permission;
                main.Name = response["USER_NAME"].ToString();
                main.PermissionData = new KeyValuePair<bool, bool>
                    (Int32.Parse(response["STUDENT_MANAGE"].ToString()) == 1
                    , Int32.Parse(response["SCORE_MANAGE"].ToString()) == 1);
                main.update();
                this.Hide();
                main.Closed += (s, args) =>
                {
                    this.Close();
                    System.Diagnostics.Process.GetCurrentProcess().Kill();
                };
                main.Show();
            }
            else
            {
                MessageBox.Show("Login fail...");
            }
        }
    }
}
