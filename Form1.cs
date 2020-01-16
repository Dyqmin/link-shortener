﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WitProjekt
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            // Utworzenie klienta API
            Api.InitializeClient();

        }

        private async void button1_Click(object sender, EventArgs e)
        {
            string inputLink = inputBox.Text;
            try
            {
                var relink = await RelinkProcessor.PostLink(inputLink);
                outputBox.Text = relink.convertOutputHash();
                outputError.Text = "";

            }
            catch (Exception err)
            {
                outputError.Text = err.Message;
            }
        }

    }
}
