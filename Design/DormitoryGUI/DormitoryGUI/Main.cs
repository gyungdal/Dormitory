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
        private JArray studentList, scoreList;
       
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
            this.listView1.DoubleClick += ListView1_DoubleClick;
            this.comboBox1.Items.Add("벌점");
            this.comboBox1.Items.Add("상점");
            this.comboBox1.SelectedIndexChanged += ComboBox1_SelectedIndexChanged;
            this.comboBox2.SelectedIndexChanged += ComboBox2_SelectedIndexChanged;
            
        }

        private void ComboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox comboBox = (ComboBox)sender;
            string select = comboBox.SelectedItem.ToString();
            int max = 0, min = 0;
            foreach (JObject obj in scoreList)
            {
                if (obj["POINT_MEMO"].ToString().Equals(select))
                {
                    min = Int32.Parse(obj["POINT_VALUE_MIN"].ToString());
                    max = Int32.Parse(obj["POINT_VALUE_MAX"].ToString());
                }
            }
            comboBox3.Items.Clear();
            for(int i = min; i <= max; )
            {
                comboBox3.Items.Add(i++);
            }
        }

        private void ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox comboBox = (ComboBox)sender;
            int select = comboBox.SelectedIndex;
            this.comboBox2.Items.Clear();
            foreach(JObject obj in scoreList)
            {
                if(Int32.Parse(obj["POINT_TYPE"].ToString()) == select)
                    this.comboBox2.Items.Add(obj["POINT_MEMO"].ToString());
            }
        }

        private void ListView1_DoubleClick(object sender, EventArgs e)
        {
            ListView.SelectedListViewItemCollection items =  this.listView1.SelectedItems;
            foreach(ListViewItem item in items)
            {
                this.listView2.Items.Add((ListViewItem)item.Clone());
            }
         }

        public void update()
        {
            this.date.Text = DateTime.Now.ToString("yyyy/MM/dd");
            this.teacherName.Text = name;
            this.teacherName.Enabled = this.date.Enabled = false;
            object obj = multiJson(Info.Server.GET_MASTER_DATA, "");
            studentList = (JArray)obj;
            foreach(JObject json in studentList)
            {
                this.listView1.Items.Add(new ListViewItem(new string[] {
                    json["USER_SCHOOL_NUMBER"].ToString(),
                    json["USER_SCHOOL_ROOM_NUMBER"].ToString(),
                    json["USER_NAME"].ToString()}));
            }
            obj = multiJson(Info.Server.GET_SCORE_DATA, "");
            scoreList = (JArray)obj;
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

        //보내기도 하고 받기도하는 함수인데 이름 정하기 고민된다.
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

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            ListView.SelectedListViewItemCollection selects = this.listView1.SelectedItems;
            foreach(ListViewItem item in selects)
            {
                foreach (JObject json in studentList)
                {
                    if (json["USER_SCHOOL_NUMBER"].ToString().Equals(item.SubItems[0].Text) &
                    json["USER_SCHOOL_ROOM_NUMBER"].ToString().Equals(item.SubItems[1].Text) &
                    json["USER_NAME"].ToString().Equals(item.SubItems[2].Text))
                    {
                        int uuid = Int32.Parse(json["USER_UUID"].ToString());
                        JObject jobj = new JObject();
                        jobj.Add("uuid", uuid);
                        object temp = multiJson(Info.Server.GET_DETAIL_DATA, jobj);
                        if(temp == null)
                            return;
                        
                        JArray result = (JArray)temp;
                        foreach (JObject dbg in result)
                        {
                            MessageBox.Show(dbg.ToString());
                        }
                    }
                } 
                MessageBox.Show(item.SubItems[0].Text);
            }
        }
    }
}
