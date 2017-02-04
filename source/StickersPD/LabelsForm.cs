using System;
using System.Windows.Forms;

namespace StickersPD
{
    public partial class LabelsForm : Form
    {
        public LabelsForm()
        {
            InitializeComponent();
            cboColored1.DataSource = Singleton.Instance.Labels;
            cboColored1.ValueMember = "Color";
            cboColored1.DisplayMember = "Name";
        }

        public void UpdateCbo(object sender, EventArgs neventArgs) { UpdateCbo(); }
        public void UpdateCbo()
        {
            cboColored1.DataSource = Singleton.Instance.Labels;
            BindingSource bSource = new BindingSource();
            bSource.DataSource = Singleton.Instance.Labels;
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
                Singleton.Instance.Labels[i].Color, 
                Singleton.Instance.Labels[i].Name,
                i);
            nlf.FormClosed += UpdateCbo;
            nlf.Show();
        }

        private void DeleteBtn_Click(object sender, EventArgs e)
        {
            try
            { 
                Singleton.Instance.Labels.RemoveAt(cboColored1.SelectedIndex);
                Serialization.Serialize();
                UpdateCbo();
            }
            catch { }
        }
    }
}
