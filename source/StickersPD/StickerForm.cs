using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StickersPD
{
    public partial class StickerForm : Form
    {
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        [System.Runtime.InteropServices.DllImportAttribute("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [System.Runtime.InteropServices.DllImportAttribute("user32.dll")]
        public static extern bool ReleaseCapture();

        private void StickerForm_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        protected override void WndProc(ref Message m)
        {
            const int wmNcHitTest = 0x84;
            const int htBottomLeft = 16;
            const int htBottomRight = 17;
            if (m.Msg == wmNcHitTest)
            {
                int x = (int)(m.LParam.ToInt64() & 0xFFFF);
                int y = (int)((m.LParam.ToInt64() & 0xFFFF0000) >> 16);
                Point pt = PointToClient(new Point(x, y));
                Size clientSize = ClientSize;
                if (pt.X >= clientSize.Width - 16 && pt.Y >= clientSize.Height - 16 && clientSize.Height >= 16)
                {
                    m.Result = (IntPtr)(IsMirrored ? htBottomLeft : htBottomRight);
                    return;
                }
            }
            base.WndProc(ref m);
        }
        Label label;
        public StickerForm(Label lbl)
        {
            InitializeComponent();
            label = lbl;
        }

        private void StickerForm_DoubleClick(object sender, EventArgs e)
        {
            new NoteForm(label).Show();
        }

        private void StickerForm_Click(object sender, EventArgs e)
        {
            MouseEventArgs me = (MouseEventArgs) e;

            if (me.Button == MouseButtons.Right)
            {
                ContextMenu cm = new ContextMenu();

                foreach (var lbl in Singleton.Instance.Labels)
                {
                    var menuItem = new MenuItem();
                    menuItem.Text = lbl.Name;
                    menuItem.Click += 
                        (object esender, EventArgs ee) => 
                        {
                            try { BackColor = lbl.Color; }
                            catch { BackColor = Color.ForestGreen; }
                        };
                    cm.MenuItems.Add(menuItem);
                }

                cm.MenuItems.Add("         ");
                var menIt = new MenuItem();
                menIt.Text = "Close sticker";
                menIt.Click +=
                    (object esender, EventArgs ee) =>
                    {
                        this.Close();
                    };
                cm.MenuItems.Add(menIt);

                cm.Show(this, new Point(me.X, me.Y));
            }
        }
    }
}
