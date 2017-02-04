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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            Serialization.Deserialize();
        }

        private void AddBtn_Click(object sender, EventArgs e)
        {
            StickerForm sf = new StickerForm();
            sf.Show();
        }

        private void LabelsBtn_Click(object sender, EventArgs e)
        {
            LabelsForm lf = new LabelsForm();
            lf.Show();
        }

        private void TablesBtn_Click(object sender, EventArgs e)
        {

        }
    }
}
