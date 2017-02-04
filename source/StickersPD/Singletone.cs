
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StickersPD
{
    [Serializable]
    public sealed class Singleton
    {
        private static readonly Singleton instance = new Singleton();

        public List<Label> Labels { get; private set; }
        public List<Sticker> Stickers { get; private set; }

        private Singleton()
        {
            Labels = new List<Label>();
            Stickers = new List<Sticker>();
            // Labels.Add(new Label() { Name = "Fish", Color = System.Drawing.Color.Blue });
        }

        public static Singleton Instance
        {
            get
            {
                return instance;
            }
        }

        public void AddLabel(Label sticker)
        {
            Labels.Add(sticker);
        }

        public void LoadLabels(Singleton singleton)
        {
            Labels = new List<Label>(singleton.Labels);
        }

        public int GetLabelIndex(Label label)
        {
            foreach (var label_tmp in Labels)
            {
                if (label_tmp.Name == label.Name)
                    return Labels.IndexOf(label_tmp);
            }
            return -1;
        }

        public void AddSticker(Sticker sticker)
        {
            Stickers.Add(sticker);
        }
    }
}
