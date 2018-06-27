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
    public partial class 矩阵的秩 : Form
    {
        public 矩阵的秩()
        {
            InitializeComponent();
        }

        private void 矩阵的秩_Load(object sender, EventArgs e)
        {
            skinEngine1.SkinFile = Application.StartupPath + @"\DiamondBlue.ssk";
        }
        int n, m, x, y, i, j;

        int[][] A = new int[10][];
        int[][] B = new int[10][];

        int cnt;
        private void button1_Click(object sender, EventArgs e)
        {
            cnt = 0;
            for (i = 0; i < 10; i++)
            {
                A[i] = new int[10];
                B[i] = new int[10];
                for (j = 0; j < 10; j++)
                {
                    A[i][j] = 0;
                }
            }
            for (i = 0; i < n; i++)
            {
                for (j = 0; j < m; j++)
                {
                    f = int.TryParse(LTB[cnt].Text.ToString(), out A[i][j]);
                    if (f == false) break;
                    cnt++;
                }
                if (f == false) break;
            }
            if (f == false) MessageBox.Show("请输入合理的整数值");
            else
            {
                Det.Transposition(A, B, n, m);
                int Rank;
                if (n <= m)
                    Rank = Det.Rank(A);
                else
                    Rank = Det.Rank(B);
                this.textBox2.Text = Rank.ToString();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.button2.Enabled = true;

            if (LTB != null)
            {
                int length = LTB.Count();
                for (int i = 0; i < length; i++)
                {
                    this.Controls.Remove(LTB[i]);
                }


                LTB = null;
            }
        }
        bool f, f1;
        List<TextBox> LTB;
        private void button2_Click(object sender, EventArgs e)
        {
            this.button2.Enabled = false;
            f = int.TryParse(textBox1.Text.ToString(), out n);
            f1 = int.TryParse(textBox3.Text.ToString(), out m);
            if (!f1 || !f) MessageBox.Show("请输入正确的阶数");
            else
            {
                LTB = new List<TextBox>();

                x = 20; y = 75;
                for (i = 0; i < n; i++)
                {
                    for (j = 0; j < m; j++)
                    {
                        TextBox textbox = new TextBox();
                        textbox.Width = 20;
                        textbox.Height = 15;
                        textbox.Location = new Point(x, y);
                        LTB.Add(textbox);                                  //加到控件列表中
                        textbox.TextAlign = HorizontalAlignment.Center;    //数值居中
                        this.Controls.Add(textbox);      //添加新控件
                        x += 30;
                    }

                    x = 20;
                    y += 30;
                }

            }
        }
    }
}
