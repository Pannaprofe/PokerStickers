using System;
using System.Drawing;
using System.Windows.Forms;

namespace StickersPD
{
    public partial class NewLabelForm : Form
    {
        public NewLabelForm()
        {
            InitializeComponent();
            OkBtn.Click += (object sender, EventArgs e) =>
            {
                Label label = new Label(ColorTbx.BackColor, NameTbx.Text, String.Empty);
                Singleton.Instance.Labels.Add(label);
                Serialization.Serialize();
                Close();
            };
            MessageBox.Show("Убрал лишнюю кнопку, кликай просто на поле с цветом для выбора нового цвета.");
        }

        public NewLabelForm(Color color, string name, int indexOfLabel)
        {
            InitializeComponent();
            ColorTbx.BackColor = color;
            NameTbx.Text = name;
            OkBtn.Click += (object sender, EventArgs e) =>
            {
                try
                {
                    var prevLabel = Singleton.Instance.Labels[indexOfLabel];
                    prevLabel = new Label(ColorTbx.BackColor, NameTbx.Text, prevLabel.Notes);
                    Serialization.Serialize();
                    Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            };
            MessageBox.Show("Убрал лишнюю кнопку, кликай просто на поле с цветом для выбора нового цвета.");
        }
        
        private void OkBtn_Click(object sender, EventArgs e)
        {
            // Не трогай здесь ничего. 
            // Я автоматом генерю метод для каждого случая и прикрепляю его к кнопке при инициализации формы.
            // Т.к. этот метод пустой, можешь его удалить потом, как прочтёшь (создал чисто для тебя).
        }

        private void ColorTbx_Click(object sender, EventArgs e)
        {
            colorDialog1.ShowDialog();
            ColorTbx.BackColor = colorDialog1.Color;
        }
    }
}
