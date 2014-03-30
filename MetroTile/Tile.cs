using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace ODSControl
{
    /// <summary>
    /// 
    /// </summary>
    public class TileItem
    {
        public Image Image;

        public Point Point;
    }

    /// <summary>
    /// 磁贴
    /// </summary>
    public class Tile
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="control">用于绘制磁贴的控件</param>
        /// <param name="tileItemList">用于磁贴显示的内容</param>
        public Tile(Control control, LinkedList<TileItem> tileItemList)
        {

            this.control = control;
            this.tileItemList = tileItemList;
            int y = 0;
            foreach (TileItem item in tileItemList)
            {
                item.Point = new Point(0, y);
                y += this.control.Height;
            }
            Random r = new Random();
            System.Threading.Thread.Sleep(10);
            this.timer.Interval = r.Next(10000, 20000);
            this.tepmImage = new Bitmap(this.control.Width, this.control.Height);
            this.bufferGraphics = Graphics.FromImage(tepmImage);
            this.control.Paint += new PaintEventHandler(control_Paint);
            timer.Tick += new EventHandler(timer_Tick);
            timer2.Tick += new EventHandler(timer2_Tick);
        }

        void control_Paint(object sender, PaintEventArgs e)
        {
            this.Draw(e.Graphics);
        }


        #region 私有属性

        private System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer()
        {
            Enabled = true,
            Interval = 200,
        };
        private System.Windows.Forms.Timer timer2 = new System.Windows.Forms.Timer()
        {
            Enabled = false,
            Interval = 10,
        };

        Bitmap tepmImage = null;
        Point p = new Point(0, 0);
        int speed = 1;//速度

        private Graphics bufferGraphics;



        #endregion

        #region 私有事件

        void timer_Tick(object sender, EventArgs e)
        {
            this.timer2.Enabled = true;
        }

        void timer2_Tick(object sender, EventArgs e)
        {
            TileItem firstItem = this.tileItemList.First.Value;
            TileItem lastItem = this.tileItemList.Last.Value;
            if (Math.Abs(firstItem.Point.Y) > this.control.Height / 8)//如果移动的位置大于 分之一开始加速
            {
                this.timer2.Interval = 10;
                speed = 10;
            }
            else
            {
                this.timer2.Interval = 30;
                speed = 1;
            }
            if (firstItem.Point.Y - speed < 0 - this.control.Height)
            {
                speed = this.control.Height + firstItem.Point.Y;
            }
            foreach (TileItem item in this.tileItemList)
            {
                int y = item.Point.Y;
                y = y - 1 * speed;
                item.Point = new Point(item.Point.X, y);
            }

            if (firstItem.Point.Y + this.control.Height <= 0)//如果第一个已经越界了，那么将其移至最后一个，并修改坐标
            {
                firstItem.Point = new Point(firstItem.Point.X, lastItem.Point.Y + this.control.Height);//修改坐标
                this.tileItemList.RemoveFirst();//删除第一个
                this.tileItemList.AddLast(firstItem);//将第一个移至最后一个
                timer2.Enabled = false;
            }
            this.control.Refresh();
            //Draw();
        }

        #endregion

        #region 私有方法

        private void Draw(Graphics g)
        {
            #region 绘图逻辑




            #endregion

            //清空并绘制临时图
            bufferGraphics.Clear(this.control.BackColor);

            foreach (TileItem item in this.tileItemList)
            {
                bufferGraphics.DrawImage(item.Image, item.Point);
            }
            SolidBrush sb=new SolidBrush(this.control.ForeColor);
            bufferGraphics.DrawString(this.control.Text, this.control.Font, sb, new PointF(3, this.control.Height - 20));
            g.DrawImage(tepmImage, p);//将绘制好的临时图绘制到界面

        }

        #endregion

        #region 公开属性

        private LinkedList<TileItem> tileItemList = new LinkedList<TileItem>();


        private Control control;

        private int interval;

        /// <summary>
        /// 设置或获取图片切换的间隔事件，以毫秒计算，默认随机产生
        /// </summary>
        public int Interval
        {
            get { return interval; }
            set
            {
                interval = value;
                this.timer.Interval = value;
            }
        }

        #endregion

    }
}
