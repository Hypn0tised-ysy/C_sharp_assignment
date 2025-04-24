using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Data.SQLite;

namespace reciteEnglish
{
    public partial class Form1 : Form
    {
        private SQLiteConnection conn;
        private SQLiteCommand cmd;
        private SQLiteDataAdapter adapter;

        private DataTable wordsTable;
        private int currentIndex = 0;
        private string correctAnswer = "";
        public Form1()
        {
            initializeComponent();
            InitializeDatabase();
            LoadWords();
            ShowNextWord();
        }

        private void InitializeDatabase()
        {
            conn = new SQLiteConnection("Data Source=words.db;Version=3;");
            conn.Open();
            string sql = "CREATE TABLE IF NOT EXISTS Words (Id INTEGER PRIMARY KEY, English TEXT, Chinese TEXT, PartOfSpeech TEXT);";
            string sqlWrong = "CREATE TABLE IF NOT EXISTS WrongWords (Id INTEGER PRIMARY KEY AUTOINCREMENT, English TEXT, Chinese TEXT, PartOfSpeech TEXT);";
            cmd = new SQLiteCommand(sql, conn);
            cmd.ExecuteNonQuery();
            cmd = new SQLiteCommand(sqlWrong, conn);
            cmd.ExecuteNonQuery();
            // 如果单词表为空，插入初始数据
            string checkSql = "SELECT COUNT(*) FROM Words;";
            cmd = new SQLiteCommand(checkSql, conn);
            long count = (long)cmd.ExecuteScalar();

            if (count == 0)
            {
                string insertSql = "INSERT INTO Words (English, Chinese, PartOfSpeech) VALUES (@eng, @chi, @pos);";
                cmd = new SQLiteCommand(insertSql, conn);

                void AddWord(string eng, string chi, string pos)
                {
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@eng", eng);
                    cmd.Parameters.AddWithValue("@chi", chi);
                    cmd.Parameters.AddWithValue("@pos", pos);
                    cmd.ExecuteNonQuery();
                }

                AddWord("university", "大学", "n");
                AddWord("computer", "计算机", "n");
                AddWord("scientific", "科学的", "adj");
            }
            string clearWrongBook = "DELETE FROM WrongWords;";
            cmd = new SQLiteCommand(clearWrongBook, conn);
            cmd.ExecuteNonQuery();

        }

        private void LoadWords()
        {
            adapter = new SQLiteDataAdapter("SELECT * FROM Words", conn);
            wordsTable = new DataTable();
            adapter.Fill(wordsTable);
        }

        private void ShowNextWord()
        {
            if (currentIndex >= wordsTable.Rows.Count)
            {
                MessageBox.Show("已完成所有单词！");
                return;
            }

            DataRow row = wordsTable.Rows[currentIndex];
            lblChinese.Text = row["Chinese"].ToString();
            lblPart.Text = row["PartOfSpeech"].ToString();
            correctAnswer = row["English"].ToString();
            txtAnswer.Text = "";
        }

        private void txtAnswer_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                string userAnswer = txtAnswer.Text.Trim();
                if (userAnswer.Equals(correctAnswer, StringComparison.OrdinalIgnoreCase))
                {
                    lblResult.Text = "正确！";
                }
                else
                {
                    lblResult.Text = $"错误，正确答案：{correctAnswer}";
                    AddToWrongBook();
                }
                currentIndex++;
                ShowNextWord();
            }
        }

        private void AddToWrongBook()
        {
            var row = wordsTable.Rows[currentIndex];
            string sql = "INSERT INTO WrongWords (English, Chinese, PartOfSpeech) VALUES (@eng, @chi, @pos)";
            SQLiteCommand insertCmd = new SQLiteCommand(sql, conn);
            insertCmd.Parameters.AddWithValue("@eng", row["English"]);
            insertCmd.Parameters.AddWithValue("@chi", row["Chinese"]);
            insertCmd.Parameters.AddWithValue("@pos", row["PartOfSpeech"]);
            insertCmd.ExecuteNonQuery();
        }

        private void btnShowWrongBook_Click(object sender, EventArgs e)
        {
            SQLiteDataAdapter wrongAdapter = new SQLiteDataAdapter("SELECT * FROM WrongWords", conn);
            DataTable wrongTable = new DataTable();
            wrongAdapter.Fill(wrongTable);
            string output = "错题本：\n";
            foreach (DataRow row in wrongTable.Rows)
            {
                output += $"{row["English"]} - {row["Chinese"]} ({row["PartOfSpeech"]})\n";
            }
            MessageBox.Show(output);
        }
        private Label lblChinese;
        private Label lblPart;
        private TextBox txtAnswer;
        private Label lblResult;
        private Button btnShowWrongBook;

        private void initializeComponent()
        {
            this.lblChinese = new System.Windows.Forms.Label();
            this.lblPart = new System.Windows.Forms.Label();
            this.txtAnswer = new System.Windows.Forms.TextBox();
            this.lblResult = new System.Windows.Forms.Label();
            this.btnShowWrongBook = new System.Windows.Forms.Button();
            this.SuspendLayout();

            // lblChinese
            this.lblChinese.AutoSize = true;
            this.lblChinese.Font = new System.Drawing.Font("Microsoft YaHei", 14F);
            this.lblChinese.Location = new System.Drawing.Point(30, 30);
            this.lblChinese.Name = "lblChinese";
            this.lblChinese.Size = new System.Drawing.Size(100, 30);
            this.lblChinese.Text = "中文词义";

            // lblPart
            this.lblPart.AutoSize = true;
            this.lblPart.Font = new System.Drawing.Font("Microsoft YaHei", 10F);
            this.lblPart.Location = new System.Drawing.Point(30, 70);
            this.lblPart.Name = "lblPart";
            this.lblPart.Size = new System.Drawing.Size(50, 23);
            this.lblPart.Text = "词性";

            // txtAnswer
            this.txtAnswer.Font = new System.Drawing.Font("Microsoft YaHei", 12F);
            this.txtAnswer.Location = new System.Drawing.Point(30, 110);
            this.txtAnswer.Name = "txtAnswer";
            this.txtAnswer.Size = new System.Drawing.Size(300, 34);
            this.txtAnswer.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtAnswer_KeyDown);

            // lblResult
            this.lblResult.AutoSize = true;
            this.lblResult.Font = new System.Drawing.Font("Microsoft YaHei", 12F);
            this.lblResult.Location = new System.Drawing.Point(30, 160);
            this.lblResult.Name = "lblResult";
            this.lblResult.Size = new System.Drawing.Size(70, 27);
            this.lblResult.Text = "结果";

            // btnShowWrongBook
            this.btnShowWrongBook.Font = new System.Drawing.Font("Microsoft YaHei", 10F);
            this.btnShowWrongBook.Location = new System.Drawing.Point(30, 200);
            this.btnShowWrongBook.Name = "btnShowWrongBook";
            this.btnShowWrongBook.Size = new System.Drawing.Size(180, 35);
            this.btnShowWrongBook.Text = "显示错题本";
            this.btnShowWrongBook.UseVisualStyleBackColor = true;
            this.btnShowWrongBook.Click += new System.EventHandler(this.btnShowWrongBook_Click);

            // MainForm
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(400, 270);
            this.Controls.Add(this.lblChinese);
            this.Controls.Add(this.lblPart);
            this.Controls.Add(this.txtAnswer);
            this.Controls.Add(this.lblResult);
            this.Controls.Add(this.btnShowWrongBook);
            this.Name = "MainForm";
            this.Text = "背单词小程序";
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}
