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
    public partial class ListControl : Form
    {
        JArray list;
        public ListControl()
        {
            InitializeComponent();
            this.comboBox1.Items.AddRange(new string[] {"벌점", "상점" });
            list = (JArray)Info.multiJson(Info.Server.GET_SCORE_DATA, "");
        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox com = (ComboBox)sender;
            this.listView2.Items.Clear();
            foreach (JObject obj in list)
            {
                if (Int32.Parse(obj["POINT_TYPE"].ToString()) == com.SelectedIndex)
                {
                    this.listView2.Items.Add(new ListViewItem(new string[]{ obj["POINT_MEMO"].ToString()
                        , obj["POINT_VALUE_MIN"].ToString(), obj["POINT_VALUE_MAX"].ToString() }));
                }
            }
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            if (!(typeBad.Checked | typeGood.Checked) | (pointName.Text.Length == 0) |
                (maxPoint.SelectedIndex == -1) | (minScore.SelectedIndex == -1))
                return;
            JObject obj = new JObject();
            if (typeBad.Checked)
                obj.Add("type", 0);
            else if (typeGood.Checked)
                obj.Add("type", 1);
            obj.Add("memo", pointName.Text);
            obj.Add("min", Int32.Parse(minScore.SelectedItem.ToString()));
            obj.Add("max", Int32.Parse(maxPoint.SelectedItem.ToString()));
            Info.multiJson(Info.Server.ADD_SCORE_INFO, obj);
            list = (JArray)Info.multiJson(Info.Server.GET_SCORE_DATA, "");
        }

        private void minScore_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.maxPoint.Items.Clear();
            for (int i = Int32.Parse(((ComboBox)sender).SelectedItem.ToString()); i <= 10; i++)
                this.maxPoint.Items.Add(i);
        }
        
    }
}
