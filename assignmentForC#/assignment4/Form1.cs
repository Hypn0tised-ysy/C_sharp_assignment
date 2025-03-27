using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace fileIntegrate
{
    public partial class Form1 : Form
    {
        string filePath1 = "";
        string filePath2 = "";

        public Form1()
        {
            InitializeComponent();
        }

        private void chooseFile1_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog
            {
                Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*"
            };

            if (dlg.ShowDialog() == DialogResult.OK)
            {
                filePath1 = dlg.FileName;
                label1.Text = Path.GetFileName(filePath1); // 显示文件名
            }
        }

        private void chooseFile2_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog
            {
                Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*"
            };

            if (dlg.ShowDialog() == DialogResult.OK)
            {
                filePath2 = dlg.FileName;
                label3.Text = Path.GetFileName(filePath2); // 显示文件名
            }
        }

        private void merge_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(filePath1) || string.IsNullOrEmpty(filePath2))
            {
                label2.Text = "请先选择两个文件！";
                return;
            }

            try
            {
                string content1 = File.ReadAllText(filePath1);
                string content2 = File.ReadAllText(filePath2);
                string merged = content1 + Environment.NewLine + content2;

                string dataDir = Path.Combine(Application.StartupPath, "Data");
                Directory.CreateDirectory(dataDir);
                string outputPath = Path.Combine(dataDir, "merged.txt");

                File.WriteAllText(outputPath, merged); // 自动覆盖
                label2.Text = $"合并成功，保存于 Data/merged.txt";
            }
            catch (Exception ex)
            {
                label2.Text = "合并失败：" + ex.Message;
            }
        }
    }
}
