using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Http;
using System.Text.RegularExpressions;

namespace url_get_content
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
            textBox1.Text = "请输入网址..."; // 设置占位符文本
        }

        // 当用户点击 TextBox 时，清除占位符
        private void txtUrl_Enter(object sender, EventArgs e)
        {
            if (textBox1.Text == "请输入网址...")
            {
                textBox1.Text = "";
                textBox1.ForeColor = System.Drawing.Color.Black;
            }
        }

        // 当用户失去焦点时，如果 TextBox 为空，显示占位符文本
        private void txtUrl_Leave(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                textBox1.Text = "请输入网址...";
                textBox1.ForeColor = System.Drawing.Color.Gray;
            }
        }

           private async void btnSearch_Click(object sender, EventArgs e)
        {
            string url = textBox1.Text.Trim();
            if (string.IsNullOrEmpty(url))
            {
                MessageBox.Show("请输入有效的URL");
                return;
            }

            try
            {
                // 使用 HttpClient 获取网页内容
                using (HttpClient client = new HttpClient())
                {
                    string pageContent = await client.GetStringAsync(url);

                    // 正则表达式匹配手机号码和邮箱
                    string emailPattern = @"[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}";
                    string phonePattern = @"\(?\d{3}\)?[-.\s]?\d{3}[-.\s]?\d{4}";

                    // 使用正则表达式查找匹配项
                    MatchCollection emailMatches = Regex.Matches(pageContent, emailPattern);
                    MatchCollection phoneMatches = Regex.Matches(pageContent, phonePattern);

                    string result = "找到的内容：\n\n";

                    // 显示找到的邮箱
                    if (emailMatches.Count > 0)
                    {
                        result += "邮箱地址：\n";
                        foreach (Match match in emailMatches)
                        {
                            result += match.Value + "\n";
                        }
                    }

                    // 显示找到的手机号码
                    if (phoneMatches.Count > 0)
                    {
                        result += "\n手机号码：\n";
                        foreach (Match match in phoneMatches)
                        {
                            result += match.Value + "\n";
                        }
                    }

                    // 如果没有找到任何邮箱或手机号码
                    if (emailMatches.Count == 0 && phoneMatches.Count == 0)
                    {
                        result = "没有找到任何邮箱或手机号码。";
                    }

                    // 显示结果
                    MessageBox.Show(result);
                }
            }
            catch (Exception ex)
            {
                // 网页访问失败时显示错误信息
                MessageBox.Show($"网页访问失败: {ex.Message}");
            }
        }

    }
}
