using System;
using System.Windows.Forms;

namespace StickersPD
{
    public partial class NoteForm : Form
    {
        Label label;
        public NoteForm(Label lbl)
        {
            InitializeComponent();
            if (lbl == null)
                return;
            NotesRtb.Text = lbl.Notes;
            label = lbl;
        }

        private void OkBtn_Click(object sender, EventArgs e)
        {
            if (label == null)
            {
                this.Close();
                return;
            }
            label = new StickersPD.Label(label.Color, label.Name, NotesRtb.Text);
            Serialization.Serialize();
            this.Close();
        }
    }
}
