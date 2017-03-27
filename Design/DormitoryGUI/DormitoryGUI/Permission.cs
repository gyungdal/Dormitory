using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DormitoryGUI
{
    public partial class Permission : Form
    {
        public Permission()
        {
            InitializeComponent();
            this.FormClosed += Permission_FormClosed;
        }

        private void Permission_FormClosed(object sender, FormClosedEventArgs e)
        {
            JArray post = new JArray();
            JArray inner = new JArray();
            inner.Add(0);
            inner.Add(this.checkBox1.Checked ? 1 : 0);
            inner.Add(this.checkBox2.Checked ? 1 : 0);
            post.Add(inner);
            inner = new JArray();
            inner.Add(1);
            inner.Add(this.checkBox3.Checked ? 1 : 0);
            inner.Add(this.checkBox4.Checked ? 1 : 0);
            post.Add(inner);
            inner = new JArray();
            inner.Add(2);
            inner.Add(this.checkBox5.Checked ? 1 : 0);
            inner.Add(this.checkBox6.Checked ? 1 : 0);
            post.Add(inner);
            MessageBox.Show(post.ToString());
            multiJson(Info.Server.SET_PERMSSION_URL, post);
        }
        private object multiJson(string url, object json)
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
                        using (StreamReader streamReader = new StreamReader(httpResponse.GetResponseStream()))
                        {
                            string result = streamReader.ReadToEnd();
                            if (result.StartsWith("["))
                                return JArray.Parse(result);
                            return JObject.Parse(result);
                        }
                    }
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }
            return null;
        }
    }

}
