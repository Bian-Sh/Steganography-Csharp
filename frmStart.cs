using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Steganography
{
    public partial class frmStart : Form
    {
        private Timer fadeOutTimer;

        public frmStart()
        {
            InitializeComponent();
            // 初始化 Timer
            fadeOutTimer = new Timer();
            fadeOutTimer.Interval = 50; // 设置间隔时间，单位为毫秒
            fadeOutTimer.Tick += new EventHandler(FadeOutTimer_Tick);

            // 开始渐隐效果
            fadeOutTimer.Start();
        }

        private void FadeOutTimer_Tick(object sender, EventArgs e)
        {
            // 减少不透明度
            if (this.Opacity > 0)
            {
                this.Opacity -= 0.05;
            }
            else
            {
                // 停止 Timer 并关闭窗体
                fadeOutTimer.Stop();
                this.Hide();
                // 显示 frmMain 窗体
                var form = new frmMain();
                form.Closed += (s, args) => this.Close();
                form.Show();
            }
        }

        private void frmStart_Load(object sender, EventArgs e)
        {
            this.Icon = Steganography.Properties.Resources.icon;
        }
    }
}