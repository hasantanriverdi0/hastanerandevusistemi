using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace hastanerandevusistemi
{
    public partial class Form_giris : Form
    {
        public Form_giris()
        {
            InitializeComponent();
        }
        randevuekrani randevuekrani = new randevuekrani();
        private void label1_Click(object sender, EventArgs e)
        {
        }
        private void label2_Click(object sender, EventArgs e)
        {
        }
        private void button1_Click(object sender, EventArgs e)
        {
            string ad = textBox_adsoyad.Text;
            string tc = textBox_tc.Text;
            string numara = textBox_numara.Text;

            if (!string.IsNullOrEmpty(ad) && !string.IsNullOrEmpty(tc) && !string.IsNullOrEmpty(numara))
            {
                bool tcSadeceSayiMi = tc.All(char.IsDigit) && numara.All(char.IsDigit);
                bool adSadeceHarfMi = ad.All(c => char.IsLetter(c) || c == ' ');

                if (tcSadeceSayiMi && adSadeceHarfMi)
                {
                    if (textBox_tc.Text.Length < 11)
                    {
                        MessageBox.Show("TC Kimlik en az 11 haneli olmalı!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else if (textBox_numara.Text.Length < 10)
                    {
                        MessageBox.Show("Telefon numarası en az 10 haneli olmalı!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else // TC Kimlik ve telefon numarası uygunsa randevu ekranını aç
                    {
                        if (randevuekrani == null)
                        {
                            randevuekrani = new randevuekrani();
                        }
                        randevuekrani.Show();
                    }
                }
                else
                {
                    MessageBox.Show("Ad Soyad, TC Kimlik ve Telefon Numarası uygun formatta olmalıdır.");
                }
            }
            else
            {
                MessageBox.Show("Lütfen Ad Soyad, TC Kimlik ve Telefon Numarası bölümlerini eksiksiz doldurun.");
            }
        }

        private void Form_giris_Load(object sender, EventArgs e)
        {
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
        }
        private void label3_Click(object sender, EventArgs e)
        {
        }

        private void textBox_tc_TextChanged(object sender, EventArgs e)
        {

        }
    }
}