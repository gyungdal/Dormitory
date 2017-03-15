using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GemBox.Spreadsheet;
using GemBox.Spreadsheet.WinFormsUtilities;


namespace Dormitory
{
    public partial class Main : Form
    {
        string permissionPrev = "";
        private enum permission { ADMIN, DORMITORY_TEACHER, NORMAL_TEACHER, ERROR};
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
                for(int i = 0;i<this.checkedListBox1.Items.Count;i++) {
                    prevItems.Add(new KeyValuePair<string, bool>(this.checkedListBox1.Items[i].ToString(), this.checkedListBox1.GetItemChecked(i)));
                }
            }
            this.checkedListBox1.Items.Clear();
            List<KeyValuePair<string, bool>> items = getListBoxResource(getPermissionSeleted(this.comboBox1.Text));
            if(items != null) {
                foreach(KeyValuePair<string ,bool> item in items) {
                    this.checkedListBox1.Items.Add(item.Key, item.Value);
                }
            }
            this.permissionPrev = this.comboBox1.Text;
        }

        public Main(){
            InitializeComponent();
            SpreadsheetInfo.SetLicense("FREE-LIMITED-KEY");
            isSuperAdmin();
        }

        private void LoadExcelToDataGridView(string excelFile) {
            ExcelFile ef = ExcelFile.Load(excelFile);
            ExcelWorksheet ws = ef.Worksheets[0];

            // From ExcelFile to DataGridView.
            DataGridViewConverter.ExportToDataGridView(
                ws,
                this.dataGridView1,
                new ExportToDataGridViewOptions() { ColumnHeaders = true });
        }
        

        private void SaveExcelFromDataGridView(string excelFile) {
            ExcelFile ef = new ExcelFile();
            ExcelWorksheet ws = ef.Worksheets.Add("DGW Sheet");

            // From DataGridView to ExcelFile.
            DataGridViewConverter.ImportFromDataGridView(
                ws,
                this.dataGridView1,
                new ImportFromDataGridViewOptions() { ColumnHeaders = true });

            ef.Save(excelFile);
        }
        private void excelSaveButton_Click(object sender, EventArgs e) {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "XLS files (*.xls)|*.xls|XLT files (*.xlt)|*.xlt|XLSX files (*.xlsx)|*.xlsx|XLSM files (*.xlsm)|*.xlsm|XLTX (*.xltx)|*.xltx|XLTM (*.xltm)|*.xltm|ODS (*.ods)|*.ods|OTS (*.ots)|*.ots|CSV (*.csv)|*.csv|TSV (*.tsv)|*.tsv|HTML (*.html)|*.html|MHTML (.mhtml)|*.mhtml|PDF (*.pdf)|*.pdf|XPS (*.xps)|*.xps|BMP (*.bmp)|*.bmp|GIF (*.gif)|*.gif|JPEG (*.jpg)|*.jpg|PNG (*.png)|*.png|TIFF (*.tif)|*.tif|WMP (*.wdp)|*.wdp";
            saveFileDialog.FilterIndex = 3;

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
                this.SaveExcelFromDataGridView(saveFileDialog.FileName);
        }

        private void excelLoadButton_Click(object sender, EventArgs e) {

            var openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "XLS files (*.xls, *.xlt)|*.xls;*.xlt|XLSX files (*.xlsx, *.xlsm, *.xltx, *.xltm)|*.xlsx;*.xlsm;*.xltx;*.xltm|ODS files (*.ods, *.ots)|*.ods;*.ots|CSV files (*.csv, *.tsv)|*.csv;*.tsv|HTML files (*.html, *.htm)|*.html;*.htm";
            openFileDialog.FilterIndex = 2;

            if (openFileDialog.ShowDialog() == DialogResult.OK)
                this.LoadExcelToDataGridView(openFileDialog.FileName);
        }

        private void test() {
            this.admin.Add(new KeyValuePair<string, bool>("YO", false));
            this.admin.Add(new KeyValuePair<string, bool>("HOME", false));
            this.admin.Add(new KeyValuePair<string, bool>(".?", false));
        }
        
        private void isSuperAdmin() {
            //최고 관리자인지 확인하는 부분
            bool isAdmin = true; // test code

            if (!isAdmin) {
                this.tabControl1.TabPages.RemoveAt(2);
                this.admin = this.teacher = this.dormitoryTeacher = null;
            } else {
                this.admin = new List<KeyValuePair<string, bool>>();
                this.teacher = new List<KeyValuePair<string, bool>>();
                this.dormitoryTeacher = new List<KeyValuePair<string, bool>>();
                this.tabPage3.Enter += (s, e) => {
                    this.comboBox1.Items.AddRange(new string[] { "최고 관리자", "사감 선생님", "일반 교사" });
                    test();
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

    }
}
