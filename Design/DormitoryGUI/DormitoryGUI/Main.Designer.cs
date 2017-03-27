namespace DormitoryGUI
{
    partial class Main
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.permissionManagerButton = new System.Windows.Forms.Button();
            this.ScoreManagerButton = new System.Windows.Forms.Button();
            this.punishmentLookupButton = new System.Windows.Forms.Button();
            this.saveExcelButton = new System.Windows.Forms.Button();
            this.loadExcelButton = new System.Windows.Forms.Button();
            this.teacherName = new System.Windows.Forms.TextBox();
            this.date = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.listView1 = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.schoolName = new System.Windows.Forms.TextBox();
            this.schoolNum = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.descText = new System.Windows.Forms.Label();
            this.delListview2 = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.listView2 = new System.Windows.Forms.ListView();
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.panel4 = new System.Windows.Forms.Panel();
            this.giveScoreButton = new System.Windows.Forms.Button();
            this.comboBox3 = new System.Windows.Forms.ComboBox();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.panel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.permissionManagerButton);
            this.panel1.Controls.Add(this.ScoreManagerButton);
            this.panel1.Controls.Add(this.punishmentLookupButton);
            this.panel1.Controls.Add(this.saveExcelButton);
            this.panel1.Controls.Add(this.loadExcelButton);
            this.panel1.Controls.Add(this.teacherName);
            this.panel1.Controls.Add(this.date);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(1, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1089, 95);
            this.panel1.TabIndex = 0;
            // 
            // permissionManagerButton
            // 
            this.permissionManagerButton.Location = new System.Drawing.Point(589, 19);
            this.permissionManagerButton.Name = "permissionManagerButton";
            this.permissionManagerButton.Size = new System.Drawing.Size(113, 56);
            this.permissionManagerButton.TabIndex = 5;
            this.permissionManagerButton.Text = "권한 관리";
            this.permissionManagerButton.UseVisualStyleBackColor = true;
            this.permissionManagerButton.Click += new System.EventHandler(this.button9_Click);
            // 
            // ScoreManagerButton
            // 
            this.ScoreManagerButton.Location = new System.Drawing.Point(471, 20);
            this.ScoreManagerButton.Name = "ScoreManagerButton";
            this.ScoreManagerButton.Size = new System.Drawing.Size(112, 56);
            this.ScoreManagerButton.TabIndex = 4;
            this.ScoreManagerButton.Text = "상ㆍ벌 항목";
            this.ScoreManagerButton.UseVisualStyleBackColor = true;
            this.ScoreManagerButton.Click += new System.EventHandler(this.button8_Click);
            // 
            // punishmentLookupButton
            // 
            this.punishmentLookupButton.Location = new System.Drawing.Point(353, 20);
            this.punishmentLookupButton.Name = "punishmentLookupButton";
            this.punishmentLookupButton.Size = new System.Drawing.Size(112, 56);
            this.punishmentLookupButton.TabIndex = 3;
            this.punishmentLookupButton.Text = "징계 대상자 조회";
            this.punishmentLookupButton.UseVisualStyleBackColor = true;
            // 
            // saveExcelButton
            // 
            this.saveExcelButton.Location = new System.Drawing.Point(709, 51);
            this.saveExcelButton.Name = "saveExcelButton";
            this.saveExcelButton.Size = new System.Drawing.Size(368, 25);
            this.saveExcelButton.TabIndex = 2;
            this.saveExcelButton.Text = "현재 내용 엑셀로 저장하기";
            this.saveExcelButton.UseVisualStyleBackColor = true;
            // 
            // loadExcelButton
            // 
            this.loadExcelButton.Location = new System.Drawing.Point(709, 20);
            this.loadExcelButton.Name = "loadExcelButton";
            this.loadExcelButton.Size = new System.Drawing.Size(368, 25);
            this.loadExcelButton.TabIndex = 2;
            this.loadExcelButton.Text = "학생 목록 엑셀에서 불러오기";
            this.loadExcelButton.UseVisualStyleBackColor = true;
            // 
            // teacherName
            // 
            this.teacherName.Location = new System.Drawing.Point(75, 51);
            this.teacherName.Name = "teacherName";
            this.teacherName.ReadOnly = true;
            this.teacherName.Size = new System.Drawing.Size(272, 25);
            this.teacherName.TabIndex = 1;
            this.teacherName.Text = "(자동)";
            this.teacherName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // date
            // 
            this.date.Location = new System.Drawing.Point(75, 20);
            this.date.Name = "date";
            this.date.ReadOnly = true;
            this.date.Size = new System.Drawing.Size(272, 25);
            this.date.TabIndex = 1;
            this.date.Text = "(자동)";
            this.date.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 55);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 15);
            this.label2.TabIndex = 0;
            this.label2.Text = "교사명";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(37, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "날짜";
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.listView1);
            this.panel2.Controls.Add(this.button2);
            this.panel2.Controls.Add(this.button1);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.schoolName);
            this.panel2.Controls.Add(this.schoolNum);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Location = new System.Drawing.Point(1, 94);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(286, 440);
            this.panel2.TabIndex = 2;
            // 
            // listView1
            // 
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3});
            this.listView1.FullRowSelect = true;
            this.listView1.Location = new System.Drawing.Point(3, 106);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(278, 329);
            this.listView1.TabIndex = 3;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            this.listView1.SelectedIndexChanged += new System.EventHandler(this.listView1_SelectedIndexChanged);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "학번";
            this.columnHeader1.Width = 80;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "호실";
            this.columnHeader2.Width = 50;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "이름";
            this.columnHeader3.Width = 110;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(192, 74);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(74, 26);
            this.button2.TabIndex = 3;
            this.button2.Text = "검색";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(192, 43);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(74, 26);
            this.button1.TabIndex = 3;
            this.button1.Text = "검색";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("굴림", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label5.Location = new System.Drawing.Point(130, 8);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(44, 17);
            this.label5.TabIndex = 2;
            this.label5.Text = "검색";
            // 
            // schoolName
            // 
            this.schoolName.Location = new System.Drawing.Point(53, 75);
            this.schoolName.Name = "schoolName";
            this.schoolName.Size = new System.Drawing.Size(133, 25);
            this.schoolName.TabIndex = 1;
            this.schoolName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // schoolNum
            // 
            this.schoolNum.Location = new System.Drawing.Point(53, 44);
            this.schoolNum.Name = "schoolNum";
            this.schoolNum.Size = new System.Drawing.Size(133, 25);
            this.schoolNum.TabIndex = 1;
            this.schoolNum.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(10, 80);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(37, 15);
            this.label3.TabIndex = 0;
            this.label3.Text = "성명";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(10, 48);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(37, 15);
            this.label4.TabIndex = 0;
            this.label4.Text = "학번";
            // 
            // panel3
            // 
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.descText);
            this.panel3.Controls.Add(this.delListview2);
            this.panel3.Controls.Add(this.dataGridView1);
            this.panel3.Controls.Add(this.listView2);
            this.panel3.Location = new System.Drawing.Point(286, 94);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(804, 309);
            this.panel3.TabIndex = 2;
            // 
            // descText
            // 
            this.descText.AutoSize = true;
            this.descText.Location = new System.Drawing.Point(33, 80);
            this.descText.Name = "descText";
            this.descText.Size = new System.Drawing.Size(407, 105);
            this.descText.TabIndex = 5;
            this.descText.Text = "이쪽에는 DataGridView로 검색해서 선택한 녀석의 로그 표시\r\n컬럼은 { 날짜, 상점, 벌점, 메모, 교사명, 총상점, 총벌점 }\r\n이렇게" +
    "\r\n\r\nrow 더블클릭하면 오른쪽 list에 추가 됨.\r\n밑의 콤보박스 + 버튼으로 일괄 점수부여 가능\r\n(급식상점, 청결상점 등에 응용 가능)" +
    "";
            // 
            // delListview2
            // 
            this.delListview2.Location = new System.Drawing.Point(499, 279);
            this.delListview2.Name = "delListview2";
            this.delListview2.Size = new System.Drawing.Size(304, 29);
            this.delListview2.TabIndex = 4;
            this.delListview2.Text = "제외하기";
            this.delListview2.UseVisualStyleBackColor = true;
            this.delListview2.Click += new System.EventHandler(this.delListview2_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(-1, -1);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 27;
            this.dataGridView1.Size = new System.Drawing.Size(501, 309);
            this.dataGridView1.TabIndex = 3;
            // 
            // listView2
            // 
            this.listView2.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader4,
            this.columnHeader6,
            this.columnHeader5});
            this.listView2.FullRowSelect = true;
            this.listView2.Location = new System.Drawing.Point(499, -1);
            this.listView2.Name = "listView2";
            this.listView2.Size = new System.Drawing.Size(304, 281);
            this.listView2.TabIndex = 1;
            this.listView2.UseCompatibleStateImageBehavior = false;
            this.listView2.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "학번";
            this.columnHeader4.Width = 90;
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "호실";
            this.columnHeader6.Width = 90;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "이름";
            this.columnHeader5.Width = 120;
            // 
            // panel4
            // 
            this.panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel4.Controls.Add(this.giveScoreButton);
            this.panel4.Controls.Add(this.comboBox3);
            this.panel4.Controls.Add(this.comboBox2);
            this.panel4.Controls.Add(this.comboBox1);
            this.panel4.Controls.Add(this.label8);
            this.panel4.Controls.Add(this.label7);
            this.panel4.Controls.Add(this.label6);
            this.panel4.Location = new System.Drawing.Point(286, 402);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(804, 132);
            this.panel4.TabIndex = 3;
            // 
            // giveScoreButton
            // 
            this.giveScoreButton.Location = new System.Drawing.Point(590, 23);
            this.giveScoreButton.Name = "giveScoreButton";
            this.giveScoreButton.Size = new System.Drawing.Size(202, 91);
            this.giveScoreButton.TabIndex = 2;
            this.giveScoreButton.Text = "점수 부여";
            this.giveScoreButton.UseVisualStyleBackColor = true;
            this.giveScoreButton.Click += new System.EventHandler(this.giveScoreButton_Click);
            // 
            // comboBox3
            // 
            this.comboBox3.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox3.FormattingEnabled = true;
            this.comboBox3.Location = new System.Drawing.Point(113, 91);
            this.comboBox3.Name = "comboBox3";
            this.comboBox3.Size = new System.Drawing.Size(461, 23);
            this.comboBox3.TabIndex = 1;
            // 
            // comboBox2
            // 
            this.comboBox2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Location = new System.Drawing.Point(113, 57);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(461, 23);
            this.comboBox2.TabIndex = 1;
            // 
            // comboBox1
            // 
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(113, 23);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(461, 23);
            this.comboBox1.TabIndex = 1;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(20, 94);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(87, 15);
            this.label8.TabIndex = 0;
            this.label8.Text = "점 수  선 택";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(20, 60);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(87, 15);
            this.label7.TabIndex = 0;
            this.label7.Text = "상ㆍ벌 내용";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(20, 27);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(87, 15);
            this.label6.TabIndex = 0;
            this.label6.Text = "상ㆍ벌 분류";
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1091, 535);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "Main";
            this.Text = "Form1";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox teacherName;
        private System.Windows.Forms.TextBox date;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TextBox schoolName;
        private System.Windows.Forms.TextBox schoolNum;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button delListview2;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.ListView listView2;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.Label descText;
        private System.Windows.Forms.ComboBox comboBox3;
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Button saveExcelButton;
        private System.Windows.Forms.Button loadExcelButton;
        private System.Windows.Forms.Button giveScoreButton;
        private System.Windows.Forms.Button permissionManagerButton;
        private System.Windows.Forms.Button ScoreManagerButton;
        private System.Windows.Forms.Button punishmentLookupButton;
    }
}