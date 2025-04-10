using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using HtmlAgilityPack;

namespace search_engine
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            InitializePlaceholder();
        }
        private void InitializePlaceholder()
        {
            textBox1.ForeColor = System.Drawing.Color.Gray;
            textBox1.Text = "输入搜索内容";
        }
        private void txtUrl_Enter(object sender, EventArgs e)
        {
            if (textBox1.Text == "输入搜索内容")
            {
                textBox1.Text = "";
                textBox1.ForeColor = System.Drawing.Color.Black;
            }
        }

        // 当用户失去焦点时，如果 TextBox 为空，显示占位符文本
        private void txtUrl_Leave(object sender, EventArgs e)
        {
            if (textBox1.Text == ""&&textBox1.ForeColor!=System.Drawing.Color.Black)
            {
                textBox1.Text = "输入搜索内容";
                textBox1.ForeColor = System.Drawing.Color.Gray;
            }
        }
        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private async void button1_Click(object sender, EventArgs e)
        {
            string search = textBox1.Text;

            if (string.IsNullOrEmpty(search) || search == "输入搜索内容")
            {
                MessageBox.Show("请输入搜索内容");
                return;
            }

            string searchEngine = getSearchEngine();
            if (string.IsNullOrEmpty(searchEngine))
            {
                MessageBox.Show("请选择搜索引擎");
                return;
            }

            string result = await SearchAsync(search, searchEngine);
            textBox2.Text = result;

        }

        private string getSearchEngine()
        {
            if (comboBox1.Text == "baidu") return "https://www.baidu.com/s?wd=";
            else if (comboBox1.Text == "bing") return "https://www.bing.com/search?q=";
            else { return string.Empty; }
        }

        private async Task<string> SearchAsync(string search, string searchEngine)
        {
            string url = searchEngine + Uri.EscapeDataString(search);
            using (HttpClient client = new HttpClient())
            {
                try
                {
                    string response = await client.GetStringAsync(url);
                    var htmlDoc=new HtmlAgilityPack.HtmlDocument();
                    htmlDoc.LoadHtml(response);
                    string textContent = htmlDoc.DocumentNode.InnerText;

                    return textContent.Substring(0,Math.Min(400,textContent.Length));

                }
                catch (Exception ex)
                {
                    MessageBox.Show("请求失败: " + ex.Message);
                    return string.Empty;
                }
            }

        }
    }
}
