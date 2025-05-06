using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;

namespace hastanerandevusistemi
{
    public partial class bilgiekrani : Form
    {
        randevuekrani randevuekrani = new randevuekrani();
        public bilgiekrani()
        {
            InitializeComponent();
        }

        private void bilgiekrani_Load(object sender, EventArgs e)
        {
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            checkBox1.CheckedChanged += checkbox1_CheckedChanged;          
            button1.Enabled = checkBox1.Checked;
            button2.Enabled = checkBox1.Checked;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            randevuekrani.Show();
        }
        private void checkbox1_CheckedChanged(object sender, EventArgs e)
        {
            button1.Enabled = checkBox1.Checked;
            button2.Enabled = checkBox1.Checked;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            bilgiekrani.ActiveForm.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Randevunuz iptal edildi, sağlıcakla kalın.");
            listBox1.Items.Clear();
        }
    }
}
