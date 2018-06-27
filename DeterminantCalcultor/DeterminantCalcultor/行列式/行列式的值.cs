using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DeterminantCalcultor.行列式
{
    public partial class 行列式的值 : Form
    {
        public 行列式的值()
        {
            InitializeComponent();
        }
        bool f;
        private int order = 0;         //阶数
        List<TextBox> LBT;             //存放新增的控件
        int[,] a = new int[10, 10];    //保存控件值
        private void button2_Click(object sender, EventArgs e)     //点击添加新的控件
        {
            int n = 1, i, j, x = 20, y = 55;
            f = int.TryParse(this.textBox1.Text.ToString(), out n);
            if (f == false)
                MessageBox.Show("请输入正确的阶数");
            else
            {
                order = n;
                this.button2.Enabled = false;
                LBT = new List<TextBox>();
                for (i = 0; i < n; i++)
                {
                    for (j = 0; j < n; j++)
                    {
                        TextBox textbox = new TextBox();
                        textbox.Width = 25;
                        textbox.Height = 15;
                        textbox.Location = new Point(x, y);
                        LBT.Add(textbox);                                  //加到控件列表中
                        textbox.TextAlign = HorizontalAlignment.Center;    //数值居中
                        this.Controls.Add(textbox);      //添加新控件
                        x += 35;
                    }
                    x = 20;
                    y += 35;
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)    //计算行列式的值
        {
            if (order == 0)
                MessageBox.Show("请输入正确的数值");
            else
            {
                int cnt = 0, Sum = 0;
                for (int i = 0; i < order; i++)
                {
                    for (int j = 0; j < order; j++)
                    {
                        // a[i, j] = int.Parse(LBT[cnt].Text.ToString());
                        //  Sum += a[i, j];
                        f = int.TryParse(LBT[cnt].Text.ToString(), out a[i, j]);
                        if (f == false)
                            break;
                        cnt++;
                    }
                    if (f == false) break;
                }
                if (f == false)
                {
                    MessageBox.Show("请按要求输入合理整数！");
                }
                else
                {
                    int[] b = new int[order];
                    for (int i = 0; i < order; i++) b[i] = i;
                    Det.Resove(0, order, b, a, ref Sum);
                    textBox2.Text = Sum.ToString();
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.button2.Enabled = true;
            this.textBox2.Text = "";
            if (order != 0)
            {
                int length = LBT.Count();
                for (int i = 0; i < length; i++)
                {
                    this.Controls.Remove(LBT[i]);
                }
                textBox1.Text = "[1,10]";
                order = 0;
                LBT = null;
            }
        }

        private void 行列式的值_Load(object sender, EventArgs e)
        {
            skinEngine1.SkinFile = Application.StartupPath + @"\DiamondBlue.ssk";
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
