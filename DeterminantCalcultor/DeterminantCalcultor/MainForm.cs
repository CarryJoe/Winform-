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
using DeterminantCalcultor.矩阵及其运算;
using System.Runtime.InteropServices;
namespace DeterminantCalcultor
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
           
        }
        List<Form> PanelChildFormList = new List<Form>();
        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            TreeNode node = this.treeView1.SelectedNode;
            if (node.Level == 2&&node.Text== "行列式的值")                                       //显示计算行列式的值的窗体
            {
                行列式的值 f = new 行列式的值();
                PanelChildFormList.Add(f);         //将新建的窗体加入到list中

                f.TopLevel = false;    //设置成非顶级控件

                //设置窗体最大化
                f.WindowState = FormWindowState.Maximized;

                //去掉窗体边框
                //  f.FormBorderStyle = FormBorderStyle.None;

                //将窗口嵌入到panel中
                f.MdiParent = this;
                f.Parent=this.panelForm;

                f.Show();
                //f.Dock = DockStyle.Fill;
            }
            if (node.Level == 2&&node.Text=="n阶矩阵")                                          //显示计算伴随矩阵的窗体
            {
                矩阵运算 f = new 矩阵运算();

                PanelChildFormList.Add(f);         //将新建的窗体加入到list中
                f.TopLevel = false;    //设置成非顶级控件

                //设置窗体最大化
                f.WindowState = FormWindowState.Maximized;

                //去掉窗体边框
                //  f.FormBorderStyle = FormBorderStyle.None;

                //将窗口嵌入到panel中
                f.Parent = this.panelForm;

                f.Show();
                //f.Dock = DockStyle.Fill;
            }
            if (node.Level == 2&&node.Text=="矩阵乘法")                                          //显示计算伴随矩阵的窗体
            {
                矩阵乘法 f = new 矩阵乘法();

                PanelChildFormList.Add(f);         //将新建的窗体加入到list中
                f.TopLevel = false;    //设置成非顶级控件

                //设置窗体最大化
                f.WindowState = FormWindowState.Maximized;

                //去掉窗体边框
                //  f.FormBorderStyle = FormBorderStyle.None;

                //将窗口嵌入到panel中
                f.Parent = this.panelForm;

                f.Show();
                //f.Dock = DockStyle.Fill;
            }
            if (node.Level == 2 && node.Text == "矩阵的秩")                                          //显示计算伴随矩阵的窗体
            {
                矩阵的秩 f = new 矩阵的秩();

                PanelChildFormList.Add(f);         //将新建的窗体加入到list中
                f.TopLevel = false;    //设置成非顶级控件

                //设置窗体最大化
                f.WindowState = FormWindowState.Maximized;

                //去掉窗体边框
                //  f.FormBorderStyle = FormBorderStyle.None;

                //将窗口嵌入到panel中
                f.Parent = this.panelForm;

                f.Show();
                //f.Dock = DockStyle.Fill;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            skinEngine1.SkinFile = Application.StartupPath + @"\DiamondBlue.ssk";
        }

        private void treeView1_ItemDrag(object sender, ItemDragEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                DoDragDrop(e.Item, DragDropEffects.Move | DragDropEffects.Copy);
            }
        }

        private void 关闭所有文件ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form form in PanelChildFormList)
            {
                //this.Controls.Remove(form);
                panelForm.Controls.Remove(form);
            }
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
        
        }

        private void treeView1_DragDrop(object sender, DragEventArgs e)
        {
            TreeNode OriginationNode = (TreeNode)e.Data.GetData("System.Windows.Forms.TreeNode");
         
            if (e.Data.GetDataPresent("System.Windows.Forms.TreeNode", false))
            {
                Point pt = ((TreeView)sender).PointToClient(new Point(e.X, e.Y));
                TreeNode DestinationNode = ((TreeView)sender).GetNodeAt(pt);
                if (DestinationNode.Level - OriginationNode.Level == -1) //限制移动条件
                {
                  
                    DestinationNode.Nodes.Add((TreeNode)OriginationNode.Clone());
                    DestinationNode.Expand();
                    if ((e.KeyState & (int)Keys.Control) != (int)Keys.Control)
                    {
                        OriginationNode.Remove();
                    }
                }
                else
                {
                    MessageBox.Show("移动失败");
                }
            }
        }

        private void treeView1_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent("System.Windows.Forms.TreeNode"))
            {
                if ((e.KeyState & (int)Keys.Control) != (int)Keys.Control)
                {
                    e.Effect = DragDropEffects.Copy;
                }
                else
                {
                    e.Effect = DragDropEffects.Move;
                }
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }

        private void 关闭当前窗口ToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
        }

        private void 关闭当前窗体ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form currentform = this;
            currentform.Close();
        }

        //public static extern bool ReleaseCapture();

        //public static extern bool SendMessage(IntPtr hwnd, int wMsg, int wParam, int lParam);
        //public const int WM_SYSCOMMAND = 0x0112;
        //public const int SC_MOVE = 0xF010;
        //public const int HTCAPTION = 0x0002;
    }
}


