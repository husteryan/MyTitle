using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ODSControl;

namespace MetroTile
{
    public partial class Form1 : Form
    {
        // <summary>
        /// 程序目录（无需斜杠）
        /// </summary>
        public static string ApplicationDirectory = AppDomain.CurrentDomain.BaseDirectory;

        public Form1()
        {
            InitializeComponent();


            /*
             * 使用方法
             * 原理：
             * 1.一个磁贴（Tile）包含多个磁贴项目（TileItem）
             * 2.TileItem其实封装的图片和坐标
             * 3.当调用Tile的构造方法时就会启动计时（间隔时间后开始滚动图片）
             * 使用：
             * 1.声明一个LinkedList<TileItem> tileItemList
             * 2.向tileItemList里添加元素 （TileItem 只需要指定Image属性就可以了）
             * 3.调用磁贴的构造方法 new Tile(btn, tileItemList);
             */



            Image img1 = Image.FromFile(ApplicationDirectory + "1.png");
            Image img2 = Image.FromFile(ApplicationDirectory + "2.png");
            Image img3 = Image.FromFile(ApplicationDirectory + "3.png");
            Image img4 = Image.FromFile(ApplicationDirectory + "4.png");            

            Image[] images = new Image[] { img1, img2, img3, img4 };
            foreach (Control c in this.Controls)
            {
                Button btn = c as Button;
                if (btn != null)
                {
                    LinkedList<TileItem> tileItemList = new LinkedList<TileItem>();
                    Random random = new Random();
                    for (int i = 0; i < images.Length; i++)
                    {
                        tileItemList.AddLast(new TileItem(){ Image = images[random.Next(0, images.Length)] });
                        btn.Click += new EventHandler(btn_Click);
                    }
                    //申明磁贴
                   Tile tile= new Tile(btn, tileItemList);
                   
                    //设置图片切换间隔时间
                    //tile.Interval = 5000;
                }
            }
        }

        void btn_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            this.BackColor = btn.BackColor;
        }
    }
}
