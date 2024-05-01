using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace MathAlternatif
{

    
    public partial class Form1 : Form
    {   
        MathAlternative math = new MathAlternative();
        
        public Form1()
        {
            InitializeComponent();
        }

        string yazi_alan = "";
        private void button7_Click(object sender, EventArgs e)
        {
            yazi_alan = textBox2.Text;
            double num = Convert.ToDouble(textBox2.Text);
            double sonuc = math.mutlakDeger_hesapla(num);
            textBox2.Text = "+" + Convert.ToString(sonuc);
        }

        private void button8_Click(object sender, EventArgs e)
        {
            yazi_alan = textBox2.Text;
            double num = Convert.ToDouble(textBox2.Text);
            if (num < 0)
            {
                MessageBox.Show("0 dan büyük sayı giriniz");
            }
            else {

                double sonuc = math.sqrt(num);
                textBox2.Text = Convert.ToString(sonuc);
                

            } 
        }

        private void button11_Click(object sender, EventArgs e)
        {
            yazi_alan = textBox2.Text;
            string[] dizi = textBox2.Text.Split(' ');
            double[] sayi_dizi = new double[dizi.Length];
            for (int i = 0; i < dizi.Length; i++)
            {
                sayi_dizi[i] = Convert.ToDouble(dizi[i]);
            }

            double sonuc = math.max_hesapla(sayi_dizi);
            textBox2.Text = Convert.ToString(sonuc);
            
        }

        private void button9_Click(object sender, EventArgs e)
        {
            yazi_alan = textBox2.Text;
            double num = Convert.ToDouble(textBox2.Text)%360;
            double aci = math.DereceToRadyan(num);
            double sonuc = math.sin(aci);

            textBox2.Text = Convert.ToString(sonuc);
            
        }

        private void button10_Click(object sender, EventArgs e)
        {
            yazi_alan = textBox2.Text;
            double num = Convert.ToDouble(textBox2.Text)%360;
            double aci = math.DereceToRadyan(num);
            double sonuc = math.cos(aci);

            textBox2.Text = Convert.ToString(sonuc);
        }

        private void button12_Click(object sender, EventArgs e)
        {
            textBox2.Text = yazi_alan;
        }
    }
    internal class MathAlternative
    {
        public MathAlternative() { }
        public double sqrt(double sayi)
        //   NEWTON - RAPHSON METHOD  \\ 
        {
            if (sayi > 0)
            {
                double yedek = sayi;
                while (true)
                {
                    double kok = yedek - ((yedek * yedek) - sayi) / (2 * yedek);
                    if (yedek - kok < 0.0000000001)
                    {
                        return kok; ;
                    }
                    yedek = kok;
                }
            }
            else
            {
                MessageBox.Show("Sayı sıfırdan büyük olmalı");
                return 0; 
            }

        }
        public double mutlakDeger_hesapla(double sayi)
        {
            if (sayi < 0)
            {
                return -1 * sayi;
            }
            else
            {
                return sayi;
            }

        }
        public double max_hesapla(params double[] sayi)
        {
            double max = sayi[0];
            for (int i = 1; i < sayi.Length; i++)
            {
                if (max < sayi[i])
                {
                    max = sayi[i];
                }
            }
            return max;
        }

        double power(double taban, int us)
        {
            double sonuc = 1;
            for (int i = 0; i < us; i++)
            {
                sonuc *= taban;
            }
            return sonuc;
        }
        double factorial(int sayi)
        {
            double sonuc = 1;

            for (int i = 1; i <= sayi; i++)
            {
                sonuc *= i;
            }
            return sonuc;
        }
        public double sin(double aci)
        //  TAYLOR AND MACLAURİN SERİES  \\
        {
            double sonuc = 0;

            if (aci == 180 * Math.PI / 180.0 || aci == 360 * Math.PI / 180.0 || aci == 0)
            {
                return 0;
            }
            else
            {
                for (int i = 0; i < 20; i++)
                {
                    sonuc += (power(-1, i) * power(aci, (2 * i + 1)) / factorial(2 * i + 1));
                }
                return sonuc;
            }
        }
        public double cos(double aci)
        //  TAYLOR AND MACLAURİN SERİES  \\
        {
            double sonuc = 0;
            if (aci == 90 * Math.PI / 180.0 || aci == 270 * Math.PI / 180.0)
            {
                return 0;
            }
            else
            {
                for (int i = 0; i < 20; i++)
                {
                    sonuc += (power(-1, i) * power(aci, (2 * i)) / factorial(2 * i));
                }
                return sonuc;
            }
        }
        public double DereceToRadyan(double derece)
        {
            return derece * (Math.PI / 180.0);
        }

    }
}
