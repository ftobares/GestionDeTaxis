using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace GestorDeFlotasDesktop.Login
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void Login_Load(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string sNomUsu;
            sNomUsu = comboBox1.SelectedItem.ToString();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            string sPwd;
            //string sNomUsu;
            //sNomUsu = comboBox1.SelectedItem.ToString();/NO! se borra!

            sPwd = textBox1.Text.ToString();
            //ENC clave
            /*if(sPwd == "1234")
                MessageBox.Show("Validado!");
            else
                MessageBox.Show("No Validado!");*/
        }

        private void monthCalendar1_DateChanged(object sender, DateRangeEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            GestorDeFlotasDesktop.AbmAuto.AbmAuto abmAuto = new GestorDeFlotasDesktop.AbmAuto.AbmAuto();
            abmAuto.Show();
            Hide();
        }
    }
}
