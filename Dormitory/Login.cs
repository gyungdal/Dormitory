﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Security.Cryptography;
using Newtonsoft.Json.Linq;
using System.Net;
using System.IO;

namespace Dormitory
{
    public partial class Login : Form
    {
        private Main viewer = null;
        private bool isOnline {
            get {
                try {
                    using (var client = new WebClient()) {
                        using (var stream = client.OpenRead("http://www.google.com")) {
                            return true;
                        }
                    }
                } catch (Exception e) {
                    return false;
                }
            }
        }

        public Login()
        {
            InitializeComponent();

            if (!isOnline) {
                MessageBox.Show("온라인 상태가 아닙니다");
                System.Diagnostics.Process.GetCurrentProcess().Kill();
            }
        }

        private static string sha1Encrypt(string input)
        {
            var hash = (new SHA1Managed()).ComputeHash(Encoding.UTF8.GetBytes(input));
            return string.Join("", hash.Select(b => b.ToString("x2")).ToArray());
        }
        
        private JObject getStringFromJSON(string url, JObject json)
        {
            try{
                HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(url);
                httpWebRequest.ContentType = "application/json";
                httpWebRequest.Method = "POST";
                byte[] postBody = Encoding.ASCII.GetBytes(json.ToString());
                using (Stream stream = httpWebRequest.GetRequestStream()) {
                    stream.Write(postBody, 0, postBody.Length);
                    using (HttpWebResponse httpResponse = (HttpWebResponse)httpWebRequest.GetResponse()) {
                        using (StreamReader streamReader = new StreamReader(httpResponse.GetResponseStream())) {
                            string result = streamReader.ReadToEnd();
                            MessageBox.Show(result);
                        }
                    }
                }
            } catch(Exception e) {
                MessageBox.Show(e.ToString());
            }
            return JObject.Parse("{}");
        }
            
        private void loginBtn_Click(object sender, EventArgs e)
        {
            string id = this.idText.Text;
            string pw = sha1Encrypt(this.pwText.Text);
            JObject json = new JObject();
            json.Add("id", id);
            json.Add("password", pw);
            
            MessageBox.Show(getStringFromJSON("http://192.168.137.102:3141/login", json).ToString());
            bool status = true;
            // status = tryLogin(idText.Text, pwText.Text);
            string type = "teacher";
            if (status)
            {
                Thread viewerThread = new Thread(delegate ()
                {
                    viewer = new Dormitory.Main(type);
                    viewer.Show();
                    System.Windows.Threading.Dispatcher.Run();
                });

                viewerThread.SetApartmentState(ApartmentState.STA); // needs to be STA or throws exception
                viewerThread.Start();
                this.Close();
            }
        }
    }
}
