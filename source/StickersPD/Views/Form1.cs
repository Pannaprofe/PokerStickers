using StickersPD.WhoIsYourPapka;
using System;
using System.Windows.Forms;

namespace StickersPD
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            iAmYourPapka.Deserialize();
            var msg = String.Format("{0}{1}{2}{3}{4}{5}",
                "Паш, я залил твой проект в репозиторий на GitHub, а исходники переместил в папку C:\\Repos\\PokerStickers.\n\n",
                "Так же скачал и установил тебе SourceTree, сделал первый коммит, можешь и дальше пользоваться.\n\n",
                "В LabelsForm реализовал метод редактирования твоих меток.\n\n",
                "Все изменения в коде отправлены в репозиторий.\n\n",
                "Так же начал реализовывать изменение текста для ярлыков, но тебе надо создать какой-то массив стикеров в синглтоне, в котором всех их держать что-ли.\n\n",
                "Это сообщение можно убрать в классе Form1."
                );
            MessageBox.Show(msg);
        }

        private void AddBtn_Click(object sender, EventArgs e)
        {
            StickerForm sf = new StickerForm(null);
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
