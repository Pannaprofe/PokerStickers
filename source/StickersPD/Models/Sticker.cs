using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StickersPD.Models
{
    [Serializable]
    public class Sticker
    {
        public Label Label { get; private set; }

        public string Note { get; private set; }

        public Sticker(Label label, string note)
        {
            Label = label;
            Note = note;
        }

        public void ChangeNote(string note)
        {
            Note = note;
        }

        public void ChangeLabel(Label label)
        {
            Label = label;
        }
    }
}
