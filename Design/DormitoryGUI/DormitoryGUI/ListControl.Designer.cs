namespace DormitoryGUI
{
    partial class ListControl
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
            this.listView2 = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.maxPoint = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.minScore = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.pointName = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.typeBad = new System.Windows.Forms.RadioButton();
            this.typeGood = new System.Windows.Forms.RadioButton();
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // listView2
            // 
            this.listView2.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3});
            this.listView2.Location = new System.Drawing.Point(12, 61);
            this.listView2.Name = "listView2";
            this.listView2.Size = new System.Drawing.Size(571, 339);
            this.listView2.TabIndex = 0;
            this.listView2.UseCompatibleStateImageBehavior = false;
            this.listView2.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "항목명";
            this.columnHeader1.Width = 365;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "최소 점수";
            this.columnHeader2.Width = 100;
            // 
            // comboBox1
            // 
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "상점",
            "벌점"});
            this.comboBox1.Location = new System.Drawing.Point(12, 21);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(571, 23);
            this.comboBox1.TabIndex = 3;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.maxPoint);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.minScore);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.pointName);
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Location = new System.Drawing.Point(621, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(499, 388);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "항목 추가";
            // 
            // maxPoint
            // 
            this.maxPoint.FormattingEnabled = true;
            this.maxPoint.Location = new System.Drawing.Point(253, 316);
            this.maxPoint.Name = "maxPoint";
            this.maxPoint.Size = new System.Drawing.Size(121, 23);
            this.maxPoint.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(250, 286);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(72, 15);
            this.label3.TabIndex = 5;
            this.label3.Text = "최대 점수";
            // 
            // minScore
            // 
            this.minScore.FormattingEnabled = true;
            this.minScore.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10",
            "사용자 입력"});
            this.minScore.Location = new System.Drawing.Point(30, 316);
            this.minScore.Name = "minScore";
            this.minScore.Size = new System.Drawing.Size(121, 23);
            this.minScore.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(27, 286);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 15);
            this.label2.TabIndex = 3;
            this.label2.Text = "최소 점수";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(27, 187);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 15);
            this.label1.TabIndex = 3;
            this.label1.Text = "항목명";
            // 
            // pointName
            // 
            this.pointName.Location = new System.Drawing.Point(30, 217);
            this.pointName.Name = "pointName";
            this.pointName.Size = new System.Drawing.Size(452, 25);
            this.pointName.TabIndex = 1;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.typeBad);
            this.groupBox2.Controls.Add(this.typeGood);
            this.groupBox2.Location = new System.Drawing.Point(30, 49);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(452, 100);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "분류";
            // 
            // typeBad
            // 
            this.typeBad.AutoSize = true;
            this.typeBad.Location = new System.Drawing.Point(103, 43);
            this.typeBad.Name = "typeBad";
            this.typeBad.Size = new System.Drawing.Size(58, 19);
            this.typeBad.TabIndex = 0;
            this.typeBad.TabStop = true;
            this.typeBad.Text = "벌점";
            this.typeBad.UseVisualStyleBackColor = true;
            // 
            // typeGood
            // 
            this.typeGood.AutoSize = true;
            this.typeGood.Location = new System.Drawing.Point(25, 43);
            this.typeGood.Name = "typeGood";
            this.typeGood.Size = new System.Drawing.Size(58, 19);
            this.typeGood.TabIndex = 0;
            this.typeGood.TabStop = true;
            this.typeGood.Text = "상점";
            this.typeGood.UseVisualStyleBackColor = true;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "최대 점수";
            this.columnHeader3.Width = 100;
            // 
            // ListControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1137, 424);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.listView2);
            this.Name = "ListControl";
            this.Text = "ListControl";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ListView listView2;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox pointName;
        private System.Windows.Forms.RadioButton typeGood;
        private System.Windows.Forms.RadioButton typeBad;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox minScore;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox maxPoint;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ColumnHeader columnHeader3;
    }
}