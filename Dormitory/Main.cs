using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json.Linq;
using System.Net;
using System.IO;
using System.Net.Http;
using Newtonsoft.Json;

namespace Dormitory
{
    public partial class Main : Form {
        private const string studentGetURL = "http://gyungdal.iptime.org:3141/student/get";
        private const string studentSetURL = "http://gyungdal.iptime.org:3141/student/set";
        private const string pointGetURL = "http://gyungdal.iptime.org:3141/point/get";
        private const string pointSetURL = "http://gyungdal.iptime.org:3141/point/set";
        private const string permissionGetURL = "http://gyungdal.iptime.org:3141/permission/get";
        private const string permissionSetURL = "http://gyungdal.iptime.org:3141/permission/set";
        private string userId;
        private bool isAdmin;
        private permission userPermission;
        private int prevTab = 0;
        private JArray student, score, jsonData; 
        string permissionPrev = "";
        public enum permission { ADMIN, DORMITORY_TEACHER, NORMAL_TEACHER, ERROR };
        private List<KeyValuePair<string, bool>> admin, teacher, dormitoryTeacher;

        private void button1_Click(object sender, EventArgs e) {
            string userType = this.comboBox1.Text;
            MessageBox.Show(userType);
        }

        
        private List<KeyValuePair<string, bool>> getListBoxResource(permission p) {
            switch (p) {
                case permission.ADMIN:
                    return this.admin;
                case permission.NORMAL_TEACHER:
                    return this.teacher;
                case permission.DORMITORY_TEACHER:
                    return this.dormitoryTeacher;
                default:
                    MessageBox.Show("WTF?");
                    break;
            }
            return null;
        }

        private void Main_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e) {
            if (e.Control && e.KeyCode == Keys.S) {
                MessageBox.Show("Save!");
                e.SuppressKeyPress = true; 
            }
        }

        private void Main_FormClosed(object sender, System.Windows.Forms.FormClosedEventArgs e){
            MessageBox.Show("CLOSE");
            System.Diagnostics.Process.GetCurrentProcess().Kill();
        }
        
        
        private void TabControl1_Selected(object sender, System.Windows.Forms.TabControlEventArgs e) {
            switch(e.TabPageIndex) {
                case 0:
                    string data = new StreamReader(((HttpWebRequest)WebRequest.Create(studentGetURL))
                        .GetResponse().GetResponseStream(), Encoding.UTF8, true).ReadToEnd().Trim();
                    MessageBox.Show(data);
                    //score = 
                    jsonData = JsonConvert.DeserializeObject<JArray>(data);
                    this.dataGridView1.DataSource = jsonData;
                    this.dataGridView1.AutoGenerateColumns = true;
                    this.dataGridView1.AllowUserToAddRows = false;

                    break;

                case 1:
                    data = new StreamReader(((HttpWebRequest)WebRequest.Create(studentGetURL))
                        .GetResponse().GetResponseStream(), Encoding.UTF8, true).ReadToEnd().Trim();
                    MessageBox.Show(data);
                    //score = 
                    jsonData = JsonConvert.DeserializeObject<JArray>(data);
                    this.dataGridView2.DataSource = jsonData;
                    this.dataGridView2.AutoGenerateColumns = true;
                    this.dataGridView1.AllowUserToAddRows = false;

                    break;
                case 2:
                    getPermissionData();
                    break;
            }
            if (prevTab != -1 || prevTab != e.TabPageIndex)
            {
                switch (prevTab)
                {
                    case 0:
                        student = gridParser(this.dataGridView1);
                        MessageBox.Show(student.ToString());
                        break;
                    case 1:
                        score = gridParser(this.dataGridView2);
                        MessageBox.Show(score.ToString());
                        break;
                    case 2:
                        if (this.permissionPrev.Length != 0)
                        {
                            List<KeyValuePair<string, bool>> prevItems = getListBoxResource(getPermissionSeleted(permissionPrev));
                            prevItems.Clear();
                            for (int i = 0; i < this.checkedListBox1.Items.Count; i++)
                            {
                                prevItems.Add(new KeyValuePair<string, bool>(this.checkedListBox1.Items[i].ToString(), this.checkedListBox1.GetItemChecked(i)));
                            }
                        }
                        setPermissionData();
                        break;
                    default:
                        break;
                }
            }
            prevTab = e.TabPageIndex;
        }
        
        private permission getPermissionSeleted(string text) {
            switch (text) {
                case "최고 관리자":
                    return permission.ADMIN;
                case "사감 선생님":
                    return permission.DORMITORY_TEACHER;
                case "일반 교사":
                    return permission.NORMAL_TEACHER;
                default:
                    return permission.ERROR;
            }
        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e) {
            //이전에 선택한 항목이 있는 경우
            if (this.permissionPrev.Length != 0) {
                List<KeyValuePair<string, bool>> prevItems = getListBoxResource(getPermissionSeleted(permissionPrev));
                prevItems.Clear();
                for (int i = 0; i < this.checkedListBox1.Items.Count; i++) {
                    prevItems.Add(new KeyValuePair<string, bool>(this.checkedListBox1.Items[i].ToString(), this.checkedListBox1.GetItemChecked(i)));
                }
            }
            this.checkedListBox1.Items.Clear();
            List<KeyValuePair<string, bool>> items = getListBoxResource(getPermissionSeleted(this.comboBox1.Text));
            if (items != null) {
                foreach (KeyValuePair<string, bool> item in items) {
                    this.checkedListBox1.Items.Add(item.Key, item.Value);
                }
            }
            this.permissionPrev = this.comboBox1.Text;
        }
        public Main(string id, permission type) {
            this.userId = id;
            this.userPermission = type;
            //MessageBox.Show(type.ToString());
            InitializeComponent();
            isSuperAdmin();
            this.searchType.Items.Add("학번");
            this.searchType.Items.Add("이름");
            this.searchType.SelectedIndex = 1;
            this.tabControl1.Selected += TabControl1_Selected;
            this.FormClosed += Main_FormClosed;
            this.KeyDown += Main_KeyDown;
            string data = new StreamReader(((HttpWebRequest)WebRequest.Create(studentGetURL))
                         .GetResponse().GetResponseStream(), Encoding.UTF8, true).ReadToEnd().Trim();
            MessageBox.Show(data);
            //score = 
            jsonData = JsonConvert.DeserializeObject<JArray>(data);
            this.dataGridView1.DataSource = jsonData;
            this.dataGridView1.AutoGenerateColumns = true;
            this.dataGridView1.AllowUserToAddRows = false;
        }
        

        private JObject getJson(string url, object json) {
            try {
                HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(url);
                httpWebRequest.ContentType = "application/json";
                httpWebRequest.Method = "POST";
                byte[] postBody = Encoding.ASCII.GetBytes(json.ToString());
                using (Stream stream = httpWebRequest.GetRequestStream()) {
                    stream.Write(postBody, 0, postBody.Length);
                    using (HttpWebResponse httpResponse = (HttpWebResponse)httpWebRequest.GetResponse()) {
                        using (StreamReader streamReader = new StreamReader(httpResponse.GetResponseStream())) {
                            string result = streamReader.ReadToEnd();
                            return JObject.Parse(result);
                        }
                    }
                }
            } catch (Exception e) {
                MessageBox.Show(e.ToString());
            }
            return JObject.Parse("{}");
        }

        private void postJson(string url, object json) {
            try {
                HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(url);
                httpWebRequest.ContentType = "application/json";
                httpWebRequest.Method = "POST";
                byte[] postBody = Encoding.ASCII.GetBytes(json.ToString());
                using (Stream stream = httpWebRequest.GetRequestStream()) {
                    stream.Write(postBody, 0, postBody.Length);
                    using (HttpWebResponse httpResponse = (HttpWebResponse)httpWebRequest.GetResponse()) {
                        if (httpResponse.StatusCode == HttpStatusCode.OK)
                            return;
                    }
                }
            } catch (Exception e) {
                MessageBox.Show(e.ToString());
            }
        }

        private JArray gridParser(DataGridView grid)
        {
            JArray result = new JArray();

            for (int i = 0;i < grid.Rows.Count; i++)
            {
                JObject jarray = new JObject();
                for (int j = 0; j < grid.Rows[i].Cells.Count; j++)
                {
                   if (grid.Rows[i].Cells[j].Value != null) {
                        jarray.Add(j.ToString(), grid.Rows[i].Cells[j].Value.ToString());
                   }
                }
                result.Add(jarray);
            }
            
            return result;
//            MessageBox.Show(result.ToString());
        }

        private void searchButton_Click(object sender, EventArgs e) {
            
            string type = this.searchType.Text;
            List<JObject> array = new List<JObject>();
            switch (type) {
                case "이름":
                    foreach(JObject obj in jsonData) {
                        if (obj.GetValue("name").Value<string>().Contains(this.searchText.Text)) {
                            array.Add(obj);
                        }
                    }
                    break;
                case "학번":
                    foreach (JObject obj in jsonData) {
                        if (obj.GetValue("school_num").Value<string>().Contains(this.searchText.Text)) {
                            array.Add(obj);
                        }
                    }
                    break;
            }
            this.dataGridView2.DataSource = array;
        }

        private void delButton_Click(object sender, EventArgs e) {
            foreach(DataGridViewRow item in this.dataGridView1.SelectedRows) {
                dataGridView1.Rows.RemoveAt(item.Index);
            }
        }

        private void AddButton_Click(object sender, EventArgs e) {
            JObject obj = new JObject();
            obj.Add("name", this.nameInput.Text);
            obj.Add("school_num", this.schoolNumInput.Text);
            this.jsonData.Add(obj);
            this.dataGridView1.Refresh();
        }

        private void getPermissionData() {
            string permissionData = new WebClient().DownloadString(permissionGetURL);
            JArray permissionJson = JArray.Parse(permissionData);

            this.admin.Clear();
            this.admin.Add(new KeyValuePair<string, bool>("상/벌점 관리", Int16.Parse(permissionJson[0]["m_point"].ToString()) == 1));
            this.admin.Add(new KeyValuePair<string, bool>("학생 관리", Int16.Parse(permissionJson[0]["m_student"].ToString()) == 1));
            this.dormitoryTeacher.Clear();
            this.dormitoryTeacher.Add(new KeyValuePair<string, bool>("상/벌점 관리", Int16.Parse(permissionJson[1]["m_point"].ToString()) == 1));
            this.dormitoryTeacher.Add(new KeyValuePair<string, bool>("학생 관리", Int16.Parse(permissionJson[1]["m_student"].ToString()) == 1));
            this.teacher.Clear();
            this.teacher.Add(new KeyValuePair<string, bool>("상/벌점 관리", Int16.Parse(permissionJson[2]["m_point"].ToString()) == 1));
            this.teacher.Add(new KeyValuePair<string, bool>("학생 관리", Int16.Parse(permissionJson[2]["m_student"].ToString()) == 1));
        }
        
        private void setPermissionData() {
            JArray data = new JArray();
            JArray json = new JArray();
            json.Add(this.admin[0].Value ? 1 : 0);
            json.Add(this.admin[1].Value ? 1 : 0);
            json.Add(0);
            data.Add(json);
            json = new JArray();
            json.Add(this.dormitoryTeacher[0].Value ? 1 : 0);
            json.Add(this.dormitoryTeacher[1].Value ? 1 : 0);
            json.Add(1);
            data.Add(json);
            json = new JArray();
            json.Add(this.teacher[0].Value ? 1 : 0);
            json.Add(this.teacher[1].Value ? 1 : 0);
            json.Add(2);
            data.Add(json);
            MessageBox.Show("data : " + data.ToString());
            postJson(permissionSetURL, data);
        }

        private void isSuperAdmin() {
            //최고 관리자인지 확인하는 부분
            isAdmin = (userPermission == permission.ADMIN);
            this.comboBox1.Items.Clear();
            if (!isAdmin) {
                this.tabControl1.TabPages.RemoveAt(2);
                this.admin = this.teacher = this.dormitoryTeacher = null;
            } else {
                this.admin = new List<KeyValuePair<string, bool>>();
                this.teacher = new List<KeyValuePair<string, bool>>();
                this.dormitoryTeacher = new List<KeyValuePair<string, bool>>();
                this.tabPage3.Enter += (s, e) => {
                    this.comboBox1.Items.Clear();
                    this.comboBox1.Items.AddRange(new string[] { "최고 관리자", "사감 선생님", "일반 교사" });
                    getPermissionData();
                    this.comboBox1.SelectedIndex = 0;
                    this.button1.Text = "저장";
                };
            }
         }


        /*
         * 1. 학생 명부 관리
         *      Excel 데이터에서 학생 명부 (학번, 이름, 등등) 저번에 짰던거 이쪽에서 불러와서 표 형태 (DataGridView 같은거)로 출력
         *      직접 바로 수정도 가능하게
         *      여기에는 벌점이랑 무관하게 학생들 정보들만 들어감
         * 2. 벌점 관리
         *      여기가 메인 기능임
         *      일단 검색 기능. 이름 학번 등 저번에 나왔던 내용들 토대로 검색하는 기능 넣는 것
         *      벌점 및 상점을 주는 방식은 일단 마음대로해도 됨 (콤보박스, 버튼, 직접입력 등등) 일단 우리 마음대로 해놓고 나중에 수정해줘도 힘들거 없음
         *      학년별, 벌점별 정렬 같은거 기능 하나 추가
         * 3. 권한 관리
         *      이건 교사 측에서 해당되는 내용임
         *      최고 관리자 / 사감 / 일반교사 -> 이렇게 되어야 할 거 같음
         *      최고 관리자만 사용 및 접근 가능한 폼(버튼)을 추가해서 대상별 권한 설정 가능하게 부여할 수 있도록 함
         * 
         *      미안하다 경식아 치킨 살게
         *      
         * */

        //yuki no youni

    }
}
