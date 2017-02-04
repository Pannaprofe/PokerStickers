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
    public partial class NewLabelForm : Form
    {
        public NewLabelForm()
        {
            InitializeComponent();
        }

        public NewLabelForm(Color color, string name)
        {
            InitializeComponent();
            ColorTbx.BackColor = color;
            NameTbx.Text = name;
            
        }

        private void PaletteBtn_Click(object sender, EventArgs e)
        {
            colorDialog1.ShowDialog();
            ColorTbx.BackColor = colorDialog1.Color;
        }

        private void OkBtn_Click(object sender, EventArgs e)
        {
            Label label = new Label(ColorTbx.BackColor, NameTbx.Text);
            Singleton.Instance.Labels.Add(label);
            Serialization.Serialize();
            this.Close();
        }
    }
}
