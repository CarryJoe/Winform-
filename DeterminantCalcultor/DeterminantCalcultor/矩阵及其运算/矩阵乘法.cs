using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DeterminantCalcultor.行列式;
namespace DeterminantCalcultor.矩阵及其运算
{
    public partial class 矩阵乘法 : Form
    {
        public 矩阵乘法()
        {
            InitializeComponent();
        }
        int n, p, m, i, j, k, cnt, x = 0, y = 0, x2, x3;
        bool f, f1, f2;
        private void button2_Click(object sender, EventArgs e)
        {
            int i, length;
            button1.Enabled = true;
            button3.Enabled = true;
            length = LTB.Count();
            for (i = 0; i < length; i++) this.Controls.Remove(LTB[i]);
            length = LTB1.Count();
            for (i = 0; i < length; i++) this.Controls.Remove(LTB1[i]);
            length = LTB2.Count();
            for (i = 0; i < length; i++) this.Controls.Remove(LTB2[i]);

        }

        private void 矩阵乘法_Load(object sender, EventArgs e)
        {
            skinEngine1.SkinFile = Application.StartupPath + @"\DiamondBlue.ssk";
        }

        int[,] A = new int[10, 10];
        int[,] B = new int[10, 10];
        int[,] C = new int[10, 10];
        private void button3_Click(object sender, EventArgs e)
        {
            cnt = 0;
            for (i = 0; i < n; i++)
            {
                for (j = 0; j < p; j++)
                {
                    f = int.TryParse(LTB[cnt].Text.ToString(), out A[i, j]);
                    if (f == false) break;
                    cnt++;
                }
                if (f==false) break;
            }
            cnt = 0;
            for (i = 0; i < p; i++)
            {
                for (j = 0; j < m; j++)
                {
                    f1 = int.TryParse(LTB1[cnt].Text.ToString(), out B[i, j]);
                    if (f1 == false) break;
                    cnt++;
                }
                if (f1 == false) break;
            }
            if (f==false||f1==false) MessageBox.Show("请输入正确的整数值");
            else
            {
                Det.Matrix_Mul(A, B, C, n, p, m);
                x = x3 + 30; y = 90;
                for (i = 0; i < n; i++)
                {
                    for (j = 0; j < m; j++)
                    {
                        TextBox textbox = new TextBox();
                        textbox.Width = 25;
                        textbox.Height = 15;
                        textbox.Location = new Point(x, y);
                        LTB.Add(textbox);                                  //加到控件列表中
                        textbox.TextAlign = HorizontalAlignment.Center;    //数值居中
                        this.Controls.Add(textbox);      //添加新控件
                        textbox.Text = C[i, j].ToString();
                        x += 30;
                    }
                    x = x3 + 30;
                    y += 30;
                }
            }
            this.button3.Enabled = false;
        }

        List<TextBox> LTB = new List<TextBox>();
        List<TextBox> LTB1 = new List<TextBox>();

        List<TextBox> LTB2 = new List<TextBox>();
        private void button1_Click(object sender, EventArgs e)
        {
            button1.Enabled = false;
            x = 20; y = 90;
            x2 = 0;
            f = int.TryParse(textBox1.Text.ToString(), out n);
            f1 = int.TryParse(textBox2.Text.ToString(), out p);
            f2 = int.TryParse(textBox3.Text.ToString(), out m);
            if (!f || !f1 || !f2) MessageBox.Show("请输入正确的阶数");
            else
            {
                for (i = 0; i < n; i++)
                {
                    for (j = 0; j < p; j++)
                    {
                        TextBox textbox = new TextBox();
                        textbox.Width = 25;
                        textbox.Height = 15;
                        textbox.Location = new Point(x, y);
                        LTB.Add(textbox);                                  //加到控件列表中
                        textbox.TextAlign = HorizontalAlignment.Center;    //数值居中
                        this.Controls.Add(textbox);      //添加新控件
                        x += 30;
                    }
                    x2 = x;
                    x = 20;
                    y += 30;
                }
                x = x2 + 30;
                y = 90;
                for (i = 0; i < p; i++)
                {
                    for (j = 0; j < m; j++)
                    {
                        TextBox textbox = new TextBox();
                        textbox.Width = 25;
                        textbox.Height = 15;
                        textbox.Location = new Point(x, y);
                        LTB1.Add(textbox);                                  //加到控件列表中
                        textbox.TextAlign = HorizontalAlignment.Center;    //数值居中
                        this.Controls.Add(textbox);      //添加新控件
                        x += 30;
                    }
                    x3 = x;
                    x = x2 + 30;
                    y += 30;

                }


            }
        }
    }
}
