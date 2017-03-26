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
    public partial class Main : Form
    {
        private Info.PERMISSION permissionType;
        private bool canEditStudent, canEditScore;
        private string name;
       
        internal KeyValuePair<bool, bool> PermissionData {
            get => new KeyValuePair<bool, bool>(canEditStudent, canEditScore);
            set {
                canEditStudent = value.Key;
                canEditScore = value.Value;
            }
        }

        internal Info.PERMISSION PermissionType { get => permissionType; set => permissionType = value; }
        internal new string Name { get => name; set => name = value; }
        public Main()
        {
            InitializeComponent();
            this.Text = "메인페이지";
        }

        public void update()
        {
            this.date.Text = DateTime.Now.ToString("yyyy/MM/dd");
            this.teacherName.Text = name;
            this.teacherName.Enabled = this.date.Enabled = false;
            //this.listView1.Items.Add(new ListViewItem("??", "", ""))
        }

        private void button9_Click(object sender, EventArgs e)
        {
            Permission permission = new Permission();
            permission.Show();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            ListControl list = new ListControl();
            list.Show();
        }

        private JObject getJson(string url, object json)
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
                            return JObject.Parse(result);
                        }
                    }
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }
            return JObject.Parse("{}");
        }

        public void limitFunctionWithPermssion()
        {
            if (permissionType != Info.PERMISSION.ADMIN)
                this.permissionManagerButton.Enabled = false;
            if (!canEditScore)
            {
                this.ScoreManagerButton.Enabled = false;
                this.giveScoreButton.Enabled = false;
            }
            if (!canEditStudent)
            {
                this.loadExcelButton.Enabled = false;
                this.saveExcelButton.Enabled = false;
            }
        }
        private void postJson(string url, object json)
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
                        if (httpResponse.StatusCode == HttpStatusCode.OK)
                            return;
                    }
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            ListView.SelectedListViewItemCollection selects = this.listView1.SelectedItems;
            foreach(ListViewItem item in selects)
            {
                MessageBox.Show(item.SubItems[0].Text);
            }
        }
    }
}
