using Microsoft.VisualBasic;
using Newtonsoft.Json;
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
using Excel = Microsoft.Office.Interop.Excel;
using System.Reflection;

namespace DormitoryGUI
{
    public partial class Main : Form
    {
        private Info.PERMISSION permissionType;
        private int teacherUUID;
        private bool canEditStudent, canEditScore;
        private string name;
        private JArray studentList, scoreList;
       
        internal int TeacherUUID { get => teacherUUID; set => teacherUUID = value; }
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

        #region 메모리해제
        private static void releaseObject(object obj)
        {
            try
            {
                System.Runtime.InteropServices.Marshal.ReleaseComObject(obj);
                obj = null;
            }
            catch (Exception e)
            {
                obj = null;
            }
            finally
            {
                GC.Collect();
            }
        }
        #endregion

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
            this.comboBox3.Items.Clear();
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
                bool temp = false;
                foreach (ListViewItem deb in this.listView2.Items)
                {
                    if (deb.SubItems[1].ToString().Equals(item.SubItems[1].ToString()) &
                       deb.SubItems[2].ToString().Equals(item.SubItems[2].ToString())) {
                        temp = true;
                        break;
                    }
                }
                if (!temp)
                    this.listView2.Items.Add((ListViewItem)item.Clone());
            }
         }

        public void update()
        {
            this.date.Text = DateTime.Now.ToString("yyyy/MM/dd");
            this.teacherName.Text = name;
            this.teacherName.Enabled = this.date.Enabled = false;
            object obj = Info.multiJson(Info.Server.GET_MASTER_DATA, "");
            studentList = (JArray)obj;
            foreach(JObject json in studentList)
            {
                this.listView1.Items.Add(new ListViewItem(new string[] {
                    json["USER_SCHOOL_NUMBER"].ToString(),
                    json["USER_SCHOOL_ROOM_NUMBER"].ToString(),
                    json["USER_NAME"].ToString()}));
            }
            obj = Info.multiJson(Info.Server.GET_SCORE_DATA, "");
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
            list.FormClosed += (s, o) => {
                update();
            };
        }
        
        private void giveScoreButton_Click(object sender, EventArgs e)
        {
            if (this.comboBox3.SelectedItem != null)
            {
                JObject post = new JObject();
                string memo = Interaction.InputBox("메모를 입력하시겠습니까?", "메모", "");
                if (memo.Trim().Length == 0)
                    memo = comboBox2.Items[comboBox2.SelectedIndex].ToString();
                JArray uuids = new JArray();
                foreach (ListViewItem item in this.listView2.Items)
                {   
                    foreach (JObject json in studentList)
                    {
                        if (json["USER_SCHOOL_NUMBER"].ToString().Equals(item.SubItems[0].Text) &
                        json["USER_SCHOOL_ROOM_NUMBER"].ToString().Equals(item.SubItems[1].Text) &
                        json["USER_NAME"].ToString().Equals(item.SubItems[2].Text))
                        {
                            uuids.Add(Int32.Parse(json["USER_UUID"].ToString()));
                        }
                    }
                }
                post.Add("teacher", teacherUUID);
                post.Add("students", uuids);
                post.Add("type", this.comboBox1.SelectedIndex);
                post.Add("value", this.comboBox3.SelectedItem.ToString());
                post.Add("memo", memo);
                foreach (JObject obj in scoreList)
                {
                    if (obj["POINT_MEMO"].ToString().Equals(this.comboBox2.SelectedItem.ToString()))
                    {
                        post.Add("uuid", Int32.Parse(obj["POINT_UUID"].ToString()));
                    }
                }
                Info.multiJson(Info.Server.GIVE_SCORE, post);
            }
        }

        private void delListview2_Click(object sender, EventArgs e)
        {
            if(this.listView2.SelectedItems.Count != 0)
               this.listView2.Items.RemoveAt(this.listView2.SelectedItems[0].Index);
        }

        //학번 검색 기능
        private void button1_Click(object sender, EventArgs e)
        {
            string num = this.schoolNum.Text;
            if (num.Length != 0)
            {
                this.listView1.Items.Clear();
                foreach (JObject json in studentList)
                {
                    if (json["USER_SCHOOL_NUMBER"].ToString().Equals(num))
                    {
                        this.listView1.Items.Add(new ListViewItem(new string[] {
                        json["USER_SCHOOL_NUMBER"].ToString(),
                        json["USER_SCHOOL_ROOM_NUMBER"].ToString(),
                        json["USER_NAME"].ToString()}));
                    }
                }
            }
            else
            {
                this.listView1.Items.Clear();
                foreach (JObject json in studentList)
                {
                    this.listView1.Items.Add(new ListViewItem(new string[] {
                    json["USER_SCHOOL_NUMBER"].ToString(),
                    json["USER_SCHOOL_ROOM_NUMBER"].ToString(),
                    json["USER_NAME"].ToString()}));
                }
            }
        }

        //이름 검색 기능
        private void button2_Click(object sender, EventArgs e)
        {
            string name = this.schoolName.Text;
            if (name.Length != 0)
            {
                this.listView1.Items.Clear();
                foreach (JObject json in studentList)
                {
                    if (json["USER_NAME"].ToString().Equals(name))
                    {
                        this.listView1.Items.Add(new ListViewItem(new string[] {
                        json["USER_SCHOOL_NUMBER"].ToString(),
                        json["USER_SCHOOL_ROOM_NUMBER"].ToString(),
                        json["USER_NAME"].ToString()}));
                    }
                }
            }
            else
            {
                this.listView1.Items.Clear();
                foreach (JObject json in studentList)
                {
                    this.listView1.Items.Add(new ListViewItem(new string[] {
                    json["USER_SCHOOL_NUMBER"].ToString(),
                    json["USER_SCHOOL_ROOM_NUMBER"].ToString(),
                    json["USER_NAME"].ToString()}));
                }
            }
        }

        private void saveExcelButton_Click(object sender, EventArgs e)
        {
            Excel.Application app = new Excel.Application();
            Excel.Workbook wb = app.Workbooks.Add(true);
            Excel._Worksheet sheet = wb.Worksheets.Item[1] as Excel._Worksheet;
            sheet.Cells[1, 2] = "TEST";
            JArray array = (JArray)Info.multiJson(Info.Server.GET_EXCEL_DATA, "");
            List<ExcelItem> items = new List<ExcelItem>();
            foreach (JObject json in studentList)
            {
                ExcelItem item = new ExcelItem();
                item.num = Int32.Parse(json["USER_SCHOOL_NUMBER"].ToString());
                item.room_number = Int32.Parse(json["USER_SCHOOL_ROOM_NUMBER"].ToString());
                item.name = json["USER_NAME"].ToString();
                
                JObject jobj = new JObject();
                jobj.Add("user_uuid", json["USER_UUID"].ToString());
                JArray temp = (JArray)Info.multiJson(Info.Server.GET_DETAIL_DATA, jobj);
                int good = 0, bad = 0;
                foreach(JObject t in temp)
                {
                    if (t["POINT_TYPE"].ToString().Equals("1"))
                        good += Int32.Parse(t["POINT_VALUE"].ToString());
                    else
                        bad += Int32.Parse(t["POINT_VALUE"].ToString());
                }
                item.good_point = good;
                item.bad_point = bad;
                items.Add(item);
            }
           
            sheet.Cells[1, 1] = "학번";
            sheet.Cells[1, 2] = "이름";
            sheet.Cells[1, 3] = "호실";
            sheet.Cells[1, 4] = "상점";
            sheet.Cells[1, 5] = "벌점";
            int i = 2;
            foreach (ExcelItem ie in items)
            {
                sheet.Cells[i, 1] = ie.num;
                sheet.Cells[i, 2] = ie.name;
                sheet.Cells[i, 3] = ie.room_number;
                sheet.Cells[i, 4] = ie.good_point;
                sheet.Cells[i, 5] = ie.bad_point;
                i += 1;
            }
            ExcelDispose(app, wb, sheet);
            MessageBox.Show("저장 완료");
        }

        public static void ExcelDispose(Excel.Application excelApp, Excel.Workbook wb, Excel._Worksheet workSheet)
        {
            wb.SaveAs(@"D:\TEST.xls", Excel.XlFileFormat.xlWorkbookNormal, Type.Missing, Type.Missing, Type.Missing, Type.Missing,
                Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlExclusive, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing);

            wb.Close(Type.Missing, Type.Missing, Type.Missing);
            excelApp.Quit();
            releaseObject(excelApp);
            releaseObject(workSheet);
            releaseObject(wb);
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
            this.descText.Hide();
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
                        jobj.Add("user_uuid", uuid);
                        object temp = Info.multiJson(Info.Server.GET_DETAIL_DATA, jobj);
                        if(temp == null)
                            return;
                        
                        JArray result = (JArray)temp;
                        JArray view = new JArray();
                        int good = 0, bad = 0;
                        foreach(JObject obj in result)
                        {
                            JObject t = new JObject();
                            t.Add("항목명", obj["POINT_MEMO"].ToString());
                            t.Add("상/벌점 분류", obj["POINT_TYPE"].ToString().Equals("1") ? "상점" : "벌점");
                            t.Add("점수", obj["POINT_VALUE"].ToString());
                            if (obj["POINT_TYPE"].ToString().Equals("1"))
                                good += Int32.Parse(obj["POINT_VALUE"].ToString());
                            else
                                bad += Int32.Parse(obj["POINT_VALUE"].ToString());
                            t.Add("메모", obj["LOG_MEMO"].ToString());
                            t.Add("부여 시간", obj["CREATE_TIME"].ToString());
                            t.Add("총 상점", good);
                            t.Add("총 벌점", bad);
                            view.Add(t);
                        }
                        this.dataGridView1.DataSource = JsonConvert.DeserializeObject<JArray>(view.ToString());
                        this.dataGridView1.AllowUserToAddRows = false;
                        
                    }
                } 
            }
        }
    }
}
