using StickersPD.WhoIsYourPapka;
using System;
using System.Windows.Forms;

namespace StickersPD
{
    public partial class NoteForm : Form
    {
        Models.Label label;
        public NoteForm(Models.Label lbl)
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
            label = new Models.Label(label.Color, label.Name, NotesRtb.Text, label.Shown);
            iAmYourPapka.Serialize();
            this.Close();
        }
    }
}
