using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace StickersPD
{
    [Serializable]
    public class Label
    {
        public Color Color { get; private set; }
        public string Name { get; private set; }

        public Label(Color color, string name)
        {
            Color = color;
            Name = name;
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
