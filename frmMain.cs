using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Security.Cryptography;
using System.Windows.Forms;
using static Steganography.LSB;

namespace Steganography
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        Bitmap bmpOriginal, bmpCoded, bmpOpenedCoded;

        private void btnOpenOriginalPic_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();

            ofd.Title = "Open Image";

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                bmpOriginal = new Bitmap(ofd.FileName);
                pbOriginalPic.Image = bmpOriginal;
            }
        }
        private void btnSaveCodedPic_Click(object sender, EventArgs e)
        {
            try
            {
                var file = tbInputText_filepath.Text;
                if (!File.Exists(file))
                {
                    MessageBox.Show("请先选择一个文件", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                var bytes = File.ReadAllBytes(file);
                var password = password_text_enc.Text;
                bmpCoded = new Bitmap(bmpOriginal);
                Encode(bmpCoded, bytes, password);

                SaveFileDialog sfd = new SaveFileDialog();
                sfd.Filter = "Images|*.bmp;*.jpg";
                ImageFormat format = ImageFormat.Bmp;
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    bmpCoded.Save(sfd.FileName, format);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"数据写入失败，错误：{ex}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnOpenCodedPic_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();

            ofd.Title = "Open Coded Image";

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                bmpOpenedCoded = new Bitmap(ofd.FileName);
                pbOpenedCodedPic.Image = bmpOpenedCoded;
            }
        }

        private void btnReadDataFromPic_Click(object sender, EventArgs e)
        {
            try
            {
                var password = password_text_dec.Text;
                byte[] messageBytes = Decode(bmpOpenedCoded, password);
                //弹窗将二进制数据存为用户指定的文件类型，任意文件类型
                SaveFileDialog sfd = new SaveFileDialog();
                sfd.Filter = "All files (*.*)|*.*";
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    if (!string.IsNullOrEmpty(sfd.FileName))
                    {
                        System.IO.File.WriteAllBytes(sfd.FileName, messageBytes);
                    }
                }

            }
            catch (Exception ex)
            {
                if (ex is CryptographicException)
                {
                    MessageBox.Show("数据写入失败，密码错误", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }else if(ex is DataTooLargeException)
                {
                    MessageBox.Show("数据写入失败，数据异常", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (ex is DataNotFoundException)
                {
                    MessageBox.Show("未找到数据", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    MessageBox.Show($"数据读取失败，错误：{ex}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // 选择一个文件并将其路径显示在文本框  tbInputText_filepath 中
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Title = "请选择一个需要被隐藏的文件";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                tbInputText_filepath.Text = ofd.FileName;
            }
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Bian Shanghai\n2024", "About", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void frmMain_Load(object sender, EventArgs e) => Icon = Properties.Resources.icon;
    }
}