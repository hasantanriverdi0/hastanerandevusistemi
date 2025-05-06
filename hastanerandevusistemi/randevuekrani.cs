using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace hastanerandevusistemi
{
    public partial class randevuekrani : Form
    {
        private Dictionary<string, List<string>> bolumler = new Dictionary<string, List<string>>();   
        public randevuekrani()
        {      
            InitializeComponent();
        }        
        private void randevuekrani_Load(object sender, EventArgs e)
        {           
            comboBox1.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
            comboBox2.Enabled = false;
            checkBox1.CheckedChanged += checkBox1_CheckedChanged;
            button1.Enabled = false;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            Form_giris.ActiveForm.Hide();
            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox2.DropDownStyle = ComboBoxStyle.DropDownList;
            bolumler.Add("Dahiliye (İç Hastalıkları)", new List<string> { "Ayşe Gün", "Hasan Bayrak", "Ahmet Can Çalışır" });
            bolumler.Add("Kulak Burun Boğaz (KBB)", new List<string> { "Feyzullah Tanrıverdi", "Kadriye Aslan", "Bahar Kazancı" });
            bolumler.Add("Cerrahi Bölüm", new List<string> { "Halime Kutlu", "Mustafa Bircan", "Hasan Tanrıverdi" });
            bolumler.Add("Kardiyoloji", new List<string> { "Ahmet Ali Cantürk", "Ali Vefa", "Kutay Mezarcı" });
            bolumler.Add("Çocuk Sağlığı ve Hastalıkları (Pediatri)", new List<string> { "Ersin Buyaka", "Gizem Aslan", "Zafer Dolu" });
            bolumler.Add("Nöroloji", new List<string> { "Deniz Alpboğa", "Murat Akyürek", "Cafer Elyürek" });
            bolumler.Add("Ortopedi", new List<string> { "Nursena Akkaya", "Şükran Boztepe", "Kemal Apaçık" });
            bolumler.Add("Kadın Hastalıkları ve Doğum (Kadın Doğum)", new List<string> { "Selin Kaya", "Özge Parlak", "Gülden Ün" });
            bolumler.Add("Göz Hastalıkları (Oftalmoloji)", new List<string> { "Ahmet Bal", "Hasan Akyurt", "Ali Cankaya" });
        }
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {         
            button1.Enabled = checkBox1.Checked;
        }
        public void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
            {
            if (comboBox1.SelectedIndex != -1)
            {          
                comboBox2.Enabled = true;
            }
            else
            {               
                comboBox2.Enabled = false;
            }
            string secilenBolum = comboBox1.SelectedItem.ToString();               
                List<string> doktorlar = bolumler[secilenBolum];               
                comboBox2.Items.Clear();
                foreach (string doktor in doktorlar)
                {
                    comboBox2.Items.Add(doktor);
                }
            }
        public void button1_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == -1 || comboBox2.SelectedIndex == -1)
            {
                MessageBox.Show("Lütfen bölümünüzü ve doktorunuzu eksiksiz seçiniz!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                this.Close();                              
                string veri1 = comboBox1.SelectedItem.ToString();
                string veri2 = comboBox2.SelectedItem.ToString();
                DateTime tarih = dateTimePicker1.Value;

                bilgiekrani bilgiekrani = new bilgiekrani(veri1, veri2, tarih);
                bilgiekrani.Show();
            }
        }
        public void comboBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex != -1)
            {
                comboBox2.Enabled = true;
                string secilenBolum = comboBox1.SelectedItem.ToString();
                List<string> doktorListesi = bolumler[secilenBolum];

                // Doktorların müsaitlik durumunu temsil eden liste
                List<string> doktorMüsaitlikleri = new List<string>();
                Random rnd = new Random();

                foreach (string doktor in doktorListesi)
                {
                    // Doktor için rastgele müsaitlik durumu oluştur
                    bool musaitMi = rnd.Next(0, 2) > 0; // 0 veya 1 döndürür, 1 ise müsait anlamına gelir
                    string doktorVeDurum = musaitMi ? $"{doktor} (Müsait)" : $"{doktor} (Dolu)";
                    doktorMüsaitlikleri.Add(doktorVeDurum);
                }

                // ComboBox2'yi güncelle
                comboBox2.Items.Clear();
                foreach (string doktorVeDurum in doktorMüsaitlikleri)
                {
                    comboBox2.Items.Add(doktorVeDurum);
                }
            }
            else
            {
                comboBox2.Enabled = false;
                comboBox2.Items.Clear();
            }
        }
        public void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
        }
        public void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
      }         
   }
}