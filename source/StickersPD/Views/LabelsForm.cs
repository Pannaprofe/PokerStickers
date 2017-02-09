using StickersPD.WhoIsYourPapka;
using System;
using System.Windows.Forms;


namespace StickersPD
{
    public partial class LabelsForm : Form
    {
        public LabelsForm()
        {
            InitializeComponent();
            cboColored1.DataSource = iAmYourPapka.Instance.Labels;
            cboColored1.ValueMember = "Color";
            cboColored1.DisplayMember = "Name";
        }

        public void UpdateCbo(object sender, EventArgs neventArgs) { UpdateCbo(); }
        public void UpdateCbo()
        {
            cboColored1.DataSource = iAmYourPapka.Instance.Labels;
            BindingSource bSource = new BindingSource();
            bSource.DataSource = iAmYourPapka.Instance.Labels;
            cboColored1.DataSource = bSource;
        }

        private void OkBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void AddBtn_Click(object sender, EventArgs e)
        {
            var nlf = new NewLabelForm();
            nlf.FormClosed += UpdateCbo;
            nlf.Show();
        }


        private void EditBtn_Click(object sender, EventArgs e)
        {
            int i = cboColored1.SelectedIndex;
            
            NewLabelForm nlf = new NewLabelForm(
                iAmYourPapka.Instance.Labels[i].Color, 
                iAmYourPapka.Instance.Labels[i].Name,
                i);
            nlf.FormClosed += UpdateCbo;
            nlf.Show();
        }

        private void DeleteBtn_Click(object sender, EventArgs e)
        {
            try
            { 
                iAmYourPapka.Instance.Labels.RemoveAt(cboColored1.SelectedIndex);
                iAmYourPapka.Serialize();
                UpdateCbo();
            }
            catch { }
        }
    }
}
