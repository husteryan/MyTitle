using System;
using System.Windows.Forms;
namespace MetroTile
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.Width = Screen.PrimaryScreen.Bounds.Width;
            this.Height = Screen.PrimaryScreen.Bounds.Height;


            num = new int[row, col];

            Random rnd = new Random();
            int number = rnd.Next(col * row / 6) + col * row / 3;
            
            int n = 0;
            while (n < number)//1×2 色块
            {
                int i = rnd.Next(row);
                int j = rnd.Next(col - 1);

                if (num[i, j] == 0 && num[i, j + 1] == 0) 
                {
                    n++;
                    num[i, j] = n;
                    num[i, j + 1] = n;   
                }
            }


            btn_height = this.Height / (row + 2) - emptywidth;
            btn_width = this.Width / (col + 2) - emptywidth;
            colcolorunit = 256 / col;
            rowcolorunit = 256 / row;


            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();

            btn_num = new System.Windows.Forms.Button[row, col];

            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < col; j++)
                {

                    this.btn_num[i, j] = new System.Windows.Forms.Button();
                    this.btn_num[i, j].BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(j * colcolorunit)))),
                                                                                   ((int)(((byte)(i * rowcolorunit)))),
                                                                                   ((int)(((byte)(Math.Sqrt(i * j * colcolorunit * rowcolorunit)))))
                                                                                   );
                    this.btn_num[i, j].FlatAppearance.BorderSize = 0;

                    this.btn_num[i, j].Font = new System.Drawing.Font("微软雅黑", 12F);
                    this.btn_num[i, j].ForeColor = System.Drawing.Color.White;
                    this.btn_num[i, j].Location = new System.Drawing.Point((btn_width + emptywidth) * (j + 1), (btn_height + emptywidth) * (i + 1));


                    this.btn_num[i, j].Size = new System.Drawing.Size(btn_width, btn_height);
                    this.btn_num[i, j].TabIndex = 0;
                    //this.btn_num[i, j].Text = "btn_num[" + i + "," + j + "]";
                    this.btn_num[i, j].TextAlign = System.Drawing.ContentAlignment.BottomLeft;
                    this.btn_num[i, j].UseVisualStyleBackColor = false;
                    this.Controls.Add(this.btn_num[i, j]);

                    if (j > 0 && num[i, j - 1] == num[i, j] && num[i, j] != 0) 
                    {
                        this.btn_num[i, j].Size = new System.Drawing.Size(btn_width * 2 + emptywidth, btn_height);
                        this.btn_num[i, j].Location = new System.Drawing.Point((btn_width + emptywidth) * (j), (btn_height + emptywidth) * (i + 1));
                        this.Controls.Remove(this.btn_num[i, j - 1]);
                    }
                }
            } 
            
            // 
            // btn_num[row, col]
            //


            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 45F);
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(btn_width, btn_height / 3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(btn_width / 2, btn_height / 2);
            this.label1.TabIndex = 1;
            this.label1.Text = "开始";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Blue;
            
            this.Controls.Add(this.label1);
          
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "Form1";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private int row = 3;//行
        private int col = 7;//列

        private int btn_height;
        private int btn_width;

        private int emptywidth = 5;
        private int rowcolorunit;
        private int colcolorunit;

        private int[,] num;

        private System.Windows.Forms.Button[,] btn_num;
        private System.Windows.Forms.Label label1;
    }
}

