using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Fliapy_Bird_Game
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        int ground = 20; // التحكم بالنزول الخاص بالطائر
        int speed = 15;
        Random r=new Random();
        int score = 0;
        private void timer1_Tick(object sender, EventArgs e)
        {
            pictureBox1.Top += ground;
            pictureBox3.Left -= speed;
            pictureBox4.Left -= speed;
            label1.Text = $"قيمة نقاطك هي : {score}";
            // تظهر الانابيب بشكل عشوائي في حال تم تجاوزها
            if (pictureBox3.Left < 0) {
                pictureBox3.Left = r.Next(500, 600);
                score++;
            }
            if (pictureBox4.Left < 0)
            {
                pictureBox4.Left=r.Next(500, 600);
                score++;
            }
            // في حال تم التداخل او الاصطدام بالارض او بالانابيب تتوقف اللعبة وتحسب عدد النقاط التي تم تجاوز تثناء اللعبة للانابيب
            if(pictureBox1.Bounds.IntersectsWith(pictureBox2.Bounds)|| pictureBox1.Bounds.IntersectsWith(pictureBox3.Bounds)|| pictureBox1.Bounds.IntersectsWith(pictureBox4.Bounds))
            {
                timer1.Enabled = false;
                label1.Text = $"انتهت اللعبة قيمة نقاطك هي : {score}";
            }
        }

        // عند النقر بالكيبورد على المسطرة يبداء الطائر بالارتفاع
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            // يتم تشغيل اللعبة عندما يتم الضغط من الكيبورد على المفتاح Enter
            if (timer1.Enabled == false)
            {
                if (e.KeyCode == Keys.Enter)
                {
                    timer1.Enabled = true;
                    pictureBox3.Left = r.Next(500, 600);
                    pictureBox4.Left = r.Next(500, 600);
                    pictureBox1.Top = 40;
                }
            }
            if (e.KeyCode == Keys.Space)
            { // يبداء الطائر بالرتفاع ولكن بشكل بطيء
                ground = -15;
            }
            // الطائر لايمكن ان يتجاوز قمة التوب للاعلى
            if (pictureBox1.Top < 2) { pictureBox1.Top = 15; }
        }

        // عند ازالة الضغط عن مفتاح المسطرة يعود الطائر للانخفاض
        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space)
            {
                // يبداء الطائر بالرجوع للاسفل عند ازالة الضغط على الممسطرة
                ground = 15;
            }
        }
    }
}
