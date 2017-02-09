using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace StickersPD.Models
{
    [Serializable]
    public class Label
    {
        public Color Color { get; private set; }
        public string Name { get; private set; }
        public string Notes { get; private set; }
        public bool Shown { get; private set; }

        public Label(Color color, string name, string notes, bool showSticker)
        {
            Color = color;
            Name = name;
            Notes = notes;
            Shown = showSticker;
        }

        public void ChangeColor(Color color)
        {
            Color = color;
        }

        private void ChangeName(string name)
        {
            Name = name;
        }
    }
}
