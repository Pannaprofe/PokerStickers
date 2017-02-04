using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace StickersPD
{
    public partial class cboColored : ComboBox
    {
        protected override void OnCreateControl()
        {
            base.OnCreateControl();

            this.DrawMode = DrawMode.OwnerDrawFixed;
            this.DropDownStyle = ComboBoxStyle.DropDownList;
            this.MaxDropDownItems = 11;
        }

        protected override void OnDrawItem(DrawItemEventArgs e)
        {
            base.OnDrawItem(e);

            e.DrawBackground();
            if (e.Index >= 0)
            {
                object current = this.Items[e.Index];
                object currentValue = current.GetType().GetProperty(this.ValueMember).GetGetMethod().Invoke(current, null);
                object currentDisplay = current.GetType().GetProperty(this.DisplayMember).GetValue(current, null);
                Color clr = currentValue is Color ? (Color)currentValue : Color.Black;
                using (Brush brush = new SolidBrush(clr))
                {
                    e.Graphics.FillRectangle(brush, e.Bounds.X + 1, e.Bounds.Y + 1, 13, 13);
                }
                using (Brush brush = new SolidBrush(e.ForeColor))
                {
                    e.Graphics.DrawString(currentDisplay.ToString(), e.Font, brush, e.Bounds.Left + 16, e.Bounds.Top);
                }
                e.DrawFocusRectangle();
            }
        }
    }
}
