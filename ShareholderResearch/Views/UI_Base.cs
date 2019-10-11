using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ShareholderResearch.Views
{
    public partial class UI_Base : UserControl
    {
        public string Title { get => labelTitle.Text; set => labelTitle.Text = value; }
        public Image Icon { get => pictureBoxIcon.BackgroundImage; set => pictureBoxIcon.BackgroundImage = value; }
        public Action ActionBeforeClosed { get; set; }

        public UI_Base()
        {
            InitializeComponent();
        }



        // systemm ui
        private const int WM_NCHITTEST = 0x84;
        private const int HT_CAPTION = 0x2;
        public const int WM_NCLBUTTONDOWN = 0xA1;
        const UInt32 HTBOTTOMRIGHT = 17;
        const UInt32 HTBOTTOM = 15;
        const int RESIZE_HANDLE_SIZE = 10;

        protected override void WndProc(ref Message m)
        {
            base.WndProc(ref m);
            
            if (m.Msg == WM_NCHITTEST)
            {
                Size formSize = Size;
                Point screenPoint = new Point(m.LParam.ToInt32());
                Point clientPoint = PointToClient(screenPoint);
                Rectangle hitBox = new Rectangle(formSize.Width - RESIZE_HANDLE_SIZE, formSize.Height - RESIZE_HANDLE_SIZE, RESIZE_HANDLE_SIZE, RESIZE_HANDLE_SIZE);
                Rectangle hitBottomBox = new Rectangle(0, formSize.Height - RESIZE_HANDLE_SIZE, formSize.Width - RESIZE_HANDLE_SIZE, RESIZE_HANDLE_SIZE);
                if (hitBox.Contains(clientPoint))
                {
                    
                }
                else
                {
                    m.Result = (IntPtr)(HT_CAPTION);
                }
            }
        }

        private void labelClose_MouseEnter(object sender, EventArgs e)
        {
            labelClose.ForeColor = Color.Red;
        }

        private void labelClose_MouseLeave(object sender, EventArgs e)
        {
            labelClose.ForeColor = Color.Silver;
        }

        private void labelClose_Click(object sender, EventArgs e)
        {
            ActionBeforeClosed?.Invoke();
            this.Dispose();
        }
    }
}
