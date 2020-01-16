using System;
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
            Api.InitializeClient();
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            string inputLink = inputBox.Text;
            try
            {
                var relink = await RelinkProcessor.PostLink(inputLink);
                this.setResponseMessage(relink.convertOutputHash());
            }
            catch (Exception err)
            {
                this.printError(err.Message);
            }
        }

        // Sets error message to the error textbox
        public void printError(string errMessage)
        {
            outputError.Text = errMessage;
        }

        // Sets response the result textbox
        public void setResponseMessage(string response)
        {
            outputBox.Text = response;
            this.clearLogsBox();
        }

        // Cleans logbox
        public void clearLogsBox()
        {
            if (outputError.Text != "")
            {
                outputError.Text = "";
            }
        }
    }
}
