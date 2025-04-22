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

namespace HelloWorldWinform
{
    public partial class FormMain : Form
    {
        private static string OriginalText;
        private const string DEFAUL_FILE_NAME = "제목없음";
        private const string DEFAULT_FILE_FILTER = "텍스트 문서(*.txt)|*.txt|csv 파일(*.csv)|*.csv|모든 파일(*.*)|*.*";

        public FormMain()
        {
            InitializeComponent();
            OriginalText = textBox1.Text;
            lblFileName.Text = DEFAUL_FILE_NAME;
        }

        private void FormMain_Load(object sender, EventArgs e)
        {

        }

        private void btnPush_Click(object sender, EventArgs e)
        {
            lblTitle.Text = "쾅~~~";
        }

        private void 끝내기ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void 프로그램정보ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form formAbout1 = new FormAbout();

            //for (int i = 0; i < 5; i++)
            //{
            //    Form formAbout2 = new FormAbout();
            //    // 모달리스(Modeless) 창
            //    formAbout2.Text = "모달리스 창";
            //    formAbout2.Show();
            //}

            // 모달(Modal) 창
            formAbout1.Text = "모달창";
            formAbout1.ShowDialog();
        }

        private void 파일열기ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = DEFAULT_FILE_FILTER;
            DialogResult result = openFileDialog.ShowDialog();

            //textBox1.Text = openFileDialog.FileName;

            switch (result)
            {
                case DialogResult.Cancel:
                    return;
                case DialogResult.OK:
                    lblFileName.Text = openFileDialog.FileName;
                    using (StreamReader sr = new StreamReader(openFileDialog.FileName))
                    {
                        textBox1.Text = sr.ReadToEnd();
                        sr.Close();
                    }
                    OriginalText = textBox1.Text;
                    lblTextChanged.Text = "";
                    break;
            }
        }

        private void 새로만들기ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            lblFileName.Text = DEFAUL_FILE_NAME;
            textBox1.Text = "글자를 입력해주세요";
            OriginalText = textBox1.Text;
            lblTextChanged.Text = "";
        }

        private void 저장ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (lblFileName.Text == DEFAUL_FILE_NAME)
            {
                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.Filter = DEFAULT_FILE_FILTER;
                DialogResult result = saveFileDialog.ShowDialog();

                switch (result)
                {
                    case DialogResult.Cancel:
                        return;
                        break;
                    case DialogResult.OK:
                        lblFileName.Text = saveFileDialog.FileName;
                        break;
                }
            }
            using (StreamWriter sw = new StreamWriter(lblFileName.Text))
            {
                sw.Write(textBox1.Text);
                lblTextChanged.Text = "";
                OriginalText = textBox1.Text;
                sw.Close();
            }
        }

        private void 다른이름으로저장ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = DEFAULT_FILE_FILTER;
            saveFileDialog.FileName = lblFileName.Text;
            DialogResult result = saveFileDialog.ShowDialog();

            switch (result)
            {
                case DialogResult.Cancel:
                    return;
                    break;
                case DialogResult.OK:
                    lblFileName.Text = saveFileDialog.FileName;
                    break;
            }
            using (StreamWriter sw = new StreamWriter(lblFileName.Text))
            {
                sw.Write(textBox1.Text);
                lblTextChanged.Text = "";
                OriginalText = textBox1.Text;
                sw.Close();
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.Text != OriginalText)
            {
                lblTextChanged.Text = "✔";
            }
            else
            {
                lblTextChanged.Text = "";
            }
        }
    }
}
