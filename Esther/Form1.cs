using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Esther
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.ExitThread();
        }

        private async void button2_Click(object sender, EventArgs e)
        {
            if (Uri.IsWellFormedUriString(url_txt.Text, UriKind.Absolute))
            {
                if (Get.Checked)
                {
                    if (json_txt.Text.Length == 0)
                    {
                        System.Net.Http.HttpRequestMessage requestMessage = new System.Net.Http.HttpRequestMessage(System.Net.Http.HttpMethod.Get, url_txt.Text);
                        System.Net.Http.HttpClient http = new System.Net.Http.HttpClient();
                        System.Net.Http.HttpResponseMessage httpResponse = await http.SendAsync(requestMessage);
                        preview_txt.Text = httpResponse.Content.ReadAsStringAsync().Result;
                        label8.Text = httpResponse.StatusCode.ToString();
                    }
                    else
                    {
                        MessageBox.Show("You can not send json-query to GET method","Info",MessageBoxButtons.OK,MessageBoxIcon.Information);
                    }
                }
                if (Post.Checked)
                {
                    var data = new System.Net.Http.StringContent(json_txt.Text, Encoding.UTF8, "application/json");
                    System.Net.Http.HttpClient http = new System.Net.Http.HttpClient();
                    System.Net.Http.HttpResponseMessage httpResponse = await http.PostAsync(url_txt.Text, data);
                    preview_txt.Text = httpResponse.Content.ReadAsStringAsync().Result;
                }
                if (Put.Checked)
                {
                    var data = new System.Net.Http.StringContent(json_txt.Text, Encoding.UTF8, "application/json");
                    System.Net.Http.HttpClient http = new System.Net.Http.HttpClient();
                    System.Net.Http.HttpResponseMessage httpResponse = await http.PutAsync(url_txt.Text, data);
                    preview_txt.Text = httpResponse.Content.ReadAsStringAsync().Result;
                }
                if (Delete.Checked)
                {
                    System.Net.Http.HttpRequestMessage requestMessage = new System.Net.Http.HttpRequestMessage(System.Net.Http.HttpMethod.Delete, url_txt.Text);
                    System.Net.Http.HttpClient http = new System.Net.Http.HttpClient();
                    System.Net.Http.HttpResponseMessage httpResponse = await http.SendAsync(requestMessage);
                    preview_txt.Text = httpResponse.Content.ReadAsStringAsync().Result;
                }
            }
        }
    }
}
