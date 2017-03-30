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
            setPermission();
            this.FormClosed += Permission_FormClosed;
        }

        private void setPermission()
        {
            JArray array = (JArray)Info.multiJson(Info.Server.GET_PERMISSION_URL, "");
            foreach(JObject obj in array)
            {
                switch (Int32.Parse(obj["PERMISSION_TYPE"].ToString()))
                {
                    case 0:
                        this.checkBox1.Checked = obj["SCORE_MANAGE"].ToString().Contains("1");
                        this.checkBox2.Checked = obj["STUDENT_MANAGE"].ToString().Contains("1");
                        break;
                    case 1:
                        this.checkBox3.Checked = obj["SCORE_MANAGE"].ToString().Contains("1");
                        this.checkBox4.Checked = obj["STUDENT_MANAGE"].ToString().Contains("1");
                        break;
                    case 2:
                        this.checkBox5.Checked = obj["SCORE_MANAGE"].ToString().Contains("1");
                        this.checkBox6.Checked = obj["STUDENT_MANAGE"].ToString().Contains("1");
                        break;
                }
            }
        }
        private void Permission_FormClosed(object sender, FormClosedEventArgs e)
        {
            JArray post = new JArray();
            JArray inner = new JArray();
            inner.Add(this.checkBox1.Checked ? 1 : 0);
            inner.Add(this.checkBox2.Checked ? 1 : 0);
            inner.Add(0);
            post.Add(inner);
            inner = new JArray();
            inner.Add(this.checkBox3.Checked ? 1 : 0);
            inner.Add(this.checkBox4.Checked ? 1 : 0);
            inner.Add(1);
            post.Add(inner);
            inner = new JArray();
            inner.Add(this.checkBox5.Checked ? 1 : 0);
            inner.Add(this.checkBox6.Checked ? 1 : 0);
            inner.Add(2);
            post.Add(inner);
            //MessageBox.Show(post.ToString());
            Info.multiJson(Info.Server.SET_PERMSSION_URL, post);
        }
    }

}
