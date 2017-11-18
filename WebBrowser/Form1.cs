using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WebBrowser
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        /// <summary>
        /// This function is called when the exit menu item is selected
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        /// <summary>
        /// This 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("This is my sample browser application.");
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// On click of this button webBrowser object will navigate to provided url in textBox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            NavigateToPage(textBox1.Text);
        }

        private void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            button1.Enabled = true;
            textBox1.Enabled = true;
            //Todo This shows prior to full completion (see youtube.com)
            toolStripStatusLabel2.Text = "Navigation Complete";
        }

        /// <summary>
        /// This function will fire on keypress
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            //If Enter key is pressed
            if(e.KeyChar == (char)ConsoleKey.Enter)
            {
                NavigateToPage(textBox1.Text);
            }
        }

        /// <summary>
        /// Re-usable navigation function
        /// </summary>
        private void NavigateToPage(string address)
        {
            if (String.IsNullOrEmpty(address)) return;
            if ((!address.StartsWith("https://")) && (!address.StartsWith("https://")))
            {
                address = "http://" + address;
            }
            if (!address.EndsWith("com"))
            {
                address = address + ".com";
            }

            try
            { 
                //Use uri object for exception
                webBrowser1.Navigate(new Uri(address));
            }
            catch (System.UriFormatException)
            {
                return;
            }

            toolStripStatusLabel2.Text = "Navigation Start";
            button1.Enabled = false;
            textBox1.Enabled = false;

            //Display full url
           textBox1.Text = address;
        }

        private void toolStripStatusLabel1_Click_1(object sender, EventArgs e)
        {

        }

        private void webBrowser1_ProgressChanged(object sender, WebBrowserProgressChangedEventArgs e)
        {
            if (e.CurrentProgress > 0 && e.MaximumProgress > 0)
            {
                toolStripProgressBar1.ProgressBar.Value = (int)((e.CurrentProgress / e.MaximumProgress) * 100);
                //toolStripStatusLabel2.Text = toolStripProgressBar1.ProgressBar.Value.ToString() + "% Completed";
            }
        }

        private void toolStripStatusLabel2_Click(object sender, EventArgs e)
        {

        }
    }
}
