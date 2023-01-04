using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MessagingToolkit.QRCode.Codec;
using MessagingToolkit.QRCode.Codec.Data;

namespace qrcode_enter
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
     

        private void button1_Click(object sender, EventArgs e)
        {
            this.Height = 366; //высота формы
            pictureBox1.Visible = !pictureBox1.Visible; //смена отображения pictureBox'a
            this.button1.Visible = false; //скрываем button1
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Random rand = new Random(); //создаём новый генератор рандомных чисел
            int i = rand.Next(100000, 999999); // в переменную i заносим рандомное число в пределах от 100000 до 999999 (все шестизначные числа)
            string qrimage = Convert.ToString(i); //конвеорируем i в string и  записываем его значение в переменную qrimage
            QRCodeEncoder encoder = new QRCodeEncoder(); // создаём новое кодирование qr-кода
            Bitmap qrcode = encoder.Encode(qrimage); // получаем закодированное изображение в классе работы с изображением bitmap.
            pictureBox1.Image = qrcode as Image; // выводит полученное изображение как рисунок в pictureBox1.
        }

        private void button3_Click(object sender, EventArgs e)
        {
            QRCodeDecoder decoder = new QRCodeDecoder(); // создаём новое раскодирование qr-кода
            string s = decoder.decode(new QRCodeBitmapImage(pictureBox1.Image as Bitmap)); //добавляем в стринговскую переменную s результат раскодирования изображения из pictureBox1
            if (textBox1.Text == s) //если строка, которую введёт пользователь, равна раскодированной с pictureBox1 строке.
            {
                this.Height = 101; //уменьшаем высоту окна формы до изначальной
                pictureBox1.Visible = !pictureBox1.Visible; //скрываем pictureBox1
                label2.Visible = !label2.Visible; //показываем текст "Вы успешно авторизировались".
            }
            else //иначе
            {
                MessageBox.Show("Вы ввели неверное число. Авторизируйтесь заново."); //появится MessageBox с данным сообщением
                this.Height = 101; //уменьшаем высоту окна формы до изначальной
                pictureBox1.Visible = !pictureBox1.Visible; //скрываем pictureBox1
                button1.Visible = !button1.Visible; //отображаем кнопку "Авторизироваться", чтобы начать авторизацию заново, пользователю снова придётся её нажать, и снова сработает код из button1_Click
                Random rand = new Random(); //снова создаём генератор рандомных чисел и переводим это число в изображение qr-кода
                int i = rand.Next(100000, 999999);
                string qrimage = Convert.ToString(i);
                QRCodeEncoder encoder = new QRCodeEncoder();
                Bitmap qrcode = encoder.Encode(qrimage);
                pictureBox1.Image = qrcode as Image;
                textBox1.Text = ""; //стираем прошлое значение, которое заносил в textBox пользователь.
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
