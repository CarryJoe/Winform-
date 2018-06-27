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
using DeterminantCalcultor.相关数学函数;
namespace DeterminantCalcultor.矩阵及其运算
{
    public partial class 矩阵运算 : Form
    {
        public 矩阵运算()
        {
            InitializeComponent();
        }
        int order = 0;
        bool f;
        List<TextBox> LBT;             //存放新增的控件
        List<TextBox> LBT1;             //存放新增的控件
        int location2 = 0;                  // 显示伴随矩阵的x首位置
        private void button2_Click(object sender, EventArgs e)
        {
            int n = 1, i, j, x = 20, y = 55;
            this.button2.Enabled = false;


            f = int.TryParse(this.textBox1.Text.ToString(), out n);
            if (f == false)
                MessageBox.Show("请输入正确的阶数");
            //   if(!(n>0&&n<=10))
            else
            {
                order = n;
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
                location2 = x + 35 * n;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.button2.Enabled = true;
            this.button1.Enabled = true;
            this.逆矩阵.Enabled = true;
            this.转置矩阵.Enabled = true;
            if (order != 0)
            {
                int length = LBT.Count();
                for (int i = 0; i < length; i++)
                {
                    if (LBT != null)
                        this.Controls.Remove(LBT[i]);
                    if (LBT1 != null)
                        this.Controls.Remove(LBT1[i]);
                }
                textBox1.Text = "[1,10]";
                order = 0;
                LBT = null;
            }
        }
        int[,] D = new int[10, 10];
        int[,] A = new int[10, 10];
        private void button1_Click(object sender, EventArgs e)
        {
            if (order == 0)
                MessageBox.Show("请输入正确的数值");
            else
            {
                this.逆矩阵.Enabled = false;
                this.转置矩阵.Enabled = false;
                int cnt = 0, i, j;
                for (i = 0; i < order; i++)
                {
                    for (j = 0; j < order; j++)
                    {
                        //D[i, j] = int.Parse(LBT[cnt].Text.ToString());
                        f = int.TryParse(LBT[cnt].Text.ToString(), out D[i, j]);
                        if (f == false)
                            break;
                        //  Sum += a[i, j];
                        cnt++;

                    }
                    if (f == false)
                        break;
                }
                if (f == false) MessageBox.Show("请输入正确的数值");

                else
                {
                    LBT1 = new List<TextBox>();
                    Det.Algebraic_Complement(D, A, order);                     //求伴随矩阵
                    int x = location2 + 50, y = 55;
                    for (i = 0; i < order; i++)
                    {
                        for (j = 0; j < order; j++)
                        {
                            TextBox textbox = new TextBox();
                            textbox.Width = 25;
                            textbox.Height = 15;
                            textbox.Location = new Point(x, y);
                            LBT1.Add(textbox);                                  //加到控件列表中

                            textbox.TextAlign = HorizontalAlignment.Center;    //数值居中
                            this.Controls.Add(textbox);      //添加新控件
                            textbox.Text = A[i, j].ToString();
                            x += 35;
                        }
                        x = location2 + 50;
                        y += 35;
                    }

                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {

            //    Det.Resove(0,length,arr,A,ref Sum);
            if (order == 0)
                MessageBox.Show("请输入正确的数值");
            else
            {
                this.button1.Enabled = false;
                this.转置矩阵.Enabled = false;
                int cnt = 0, Sum = 0, i, j;
                for (i = 0; i < order; i++)
                {
                    for (j = 0; j < order; j++)
                    {
                        f = int.TryParse(LBT[cnt].Text.ToString(), out D[i, j]);
                        if (f == false)
                            break;
                        //  Sum += a[i, j];
                        cnt++;

                    }
                    if (f == false)
                        break;
                }

                if (f == false) MessageBox.Show("请输入合理整数！");
                else
                {

                    #region                                    求矩阵D的行列式的值
                    int[] arr = new int[10];
                    for (i = 0; i < order; i++) arr[i] = i;
                    Det.Resove(0, order, arr, D, ref Sum);
                    #endregion

                    if (Sum == 0)
                    {
                        MessageBox.Show("当前矩阵行列式的值为0，矩阵不可逆");
                    }
                    else
                    {
                        LBT1 = new List<TextBox>();

                        Det.Algebraic_Complement(D, A, order);                     //求伴随矩阵
                        int x = location2 + 50, y = 55;
                        for (i = 0; i < order; i++)
                        {
                            for (j = 0; j < order; j++)
                            {
                                TextBox textbox = new TextBox();
                                textbox.Width = 40;
                                textbox.Height = 15;
                                textbox.Location = new Point(x, y);
                                LBT1.Add(textbox);                                  //加到控件列表中

                                textbox.TextAlign = HorizontalAlignment.Center;    //数值居中
                                this.Controls.Add(textbox);      //添加新控件

                                if (A[i, j] % Sum == 0)
                                    textbox.Text = A[i, j].ToString();
                                else
                                {
                                    textbox.Text = string.Format("{0}/{1}", Math.Abs(A[i, j]) / 自定义函数.gcd(Math.Abs(A[i, j]), Math.Abs(Sum)), Math.Abs(Sum) / 自定义函数.gcd(Math.Abs(A[i, j]), Math.Abs(Sum)));

                                    //         
                                    if (A[i, j] * Sum < 0)
                                        textbox.Text = "-" + textbox.Text;

                                }
                                x += 50;
                            }
                            x = location2 + 50;
                            y += 35;
                        }
                    }
                }
            }
        }

        private void 转置矩阵_Click(object sender, EventArgs e)
        {
            if (order == 0)
                MessageBox.Show("请输入正确的数值");
            else
            {
                this.button1.Enabled = false;
                this.逆矩阵.Enabled = false;
                int cnt = 0, i, j;
                for (i = 0; i < order; i++)
                {
                    for (j = 0; j < order; j++)
                    {
                        D[i, j] = int.Parse(LBT[cnt].Text.ToString());
                        f = int.TryParse(LBT[cnt].Text.ToString(), out D[i, j]);
                        if (f == false) break;
                        //  Sum += a[i, j];
                        cnt++;

                    }
                    if (f == false) break;
                }
                if (f == false) MessageBox.Show("请输入正确的数值");
                else
                {

                    LBT1 = new List<TextBox>();

                    //   Det.Algebraic_Complement(D, A, order);                     //求伴随矩阵
                    Det.Transposition(D, A, order);
                    int x = location2 + 50, y = 55;
                    for (i = 0; i < order; i++)
                    {
                        for (j = 0; j < order; j++)
                        {
                            TextBox textbox = new TextBox();
                            textbox.Width = 25;
                            textbox.Height = 15;
                            textbox.Location = new Point(x, y);
                            LBT1.Add(textbox);                                  //加到控件列表中

                            textbox.TextAlign = HorizontalAlignment.Center;    //数值居中
                            this.Controls.Add(textbox);      //添加新控件

                            textbox.Text = A[i, j].ToString();
                            x += 50;
                        }
                        x = location2 + 50;
                        y += 35;
                    }

                }
            }
        }

        private void 伴随矩阵_Load(object sender, EventArgs e)
        {

            skinEngine1.SkinFile = Application.StartupPath + @"\DiamondBlue.ssk";
        }
    }
}
