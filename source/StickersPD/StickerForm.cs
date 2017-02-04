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

        public StickerForm()
        {
            InitializeComponent();
        }

        private void StickerForm_DoubleClick(object sender, EventArgs e)
        {
            new NoteForm().Show();
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
                menIt.Text = "Exit";
                menIt.Click +=
                    (object esender, EventArgs ee) =>
                    {
                        this.Close();
                    };
                cm.MenuItems.Add(menIt);

                cm.Show(this, new Point(me.X, me.Y));
            }
        }
        private void menuItem1_DrawItem(object sender, System.Windows.Forms.DrawItemEventArgs e)
        {
            MenuItem mi = (MenuItem)sender;
            Font menuFont = SystemInformation.MenuFont;
            SolidBrush menuBrush = null;
            if (mi.Enabled == false)
            {
                menuBrush = new SolidBrush(SystemColors.GrayText);
            }
            else
            {
                if ((e.State & DrawItemState.Selected) != 0)
                {
                    // Text color when selected (highlighted)
                    menuBrush = new SolidBrush(SystemColors.HighlightText);
                }
                else
                {
                    // Text color during normal drawing
                    menuBrush = new SolidBrush(SystemColors.MenuText);
                }
            }

            // Center the text portion (out to side of image portion)
            StringFormat strfmt = new StringFormat();
            strfmt.LineAlignment = System.Drawing.StringAlignment.Center;

            // Get image associated with this menu item
            Image bmMenuImage = Image.FromFile("c:\\icon_cut.gif");

            // Rectangle for image portion
            Rectangle rectImage = e.Bounds;

            // Set image rectangle same dimensions as image
            rectImage.Width = bmMenuImage.Width;
            rectImage.Height = bmMenuImage.Height;

            // Rectanble for text portion
            Rectangle rectText = e.Bounds;

            // set wideth to x value of text portion
            rectText.X += rectImage.Width;
            if ((e.State & DrawItemState.Selected) != 0)
            {
                // Selected color
                e.Graphics.FillRectangle(SystemBrushes.Highlight,
                e.Bounds);
            }
            else
            {
                e.Graphics.FillRectangle(SystemBrushes.Menu,
                e.Bounds);
            }
            e.Graphics.DrawImage(bmMenuImage, rectImage);
            e.Graphics.DrawString(mi.Text,
            menuFont,
            menuBrush,
            e.Bounds.Left + bmMenuImage.Width,
            e.Bounds.Top + ((e.Bounds.Height - menuFont.Height) / 2),
            strfmt);
        }

        private void menuItem1_MeasureItem(object sender, System.Windows.Forms.MeasureItemEventArgs e)
        {
            MenuItem mi = (MenuItem)sender;
            Font menuFont = SystemInformation.MenuFont;

            StringFormat strfmt = new StringFormat();

            SizeF sizef = e.Graphics.MeasureString(mi.Text, menuFont, 1000, strfmt);
            Image bmMenuImage = Image.FromFile("c:\\icon_cut.gif");
            e.ItemWidth = (int)Math.Ceiling(sizef.Width) + bmMenuImage.Width;
            e.ItemHeight = (int)Math.Ceiling(sizef.Height) + bmMenuImage.Height;
        }




    }
}
