﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HelloWorldWinform
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
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
    }
}
