
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using StickersPD.Models;

namespace StickersPD.WhoIsYourPapka
{
    [Serializable]
    public sealed class iAmYourPapka
    {
        private static readonly iAmYourPapka instance = new iAmYourPapka();

        public List<Label> Labels { get; private set; }
        public List<Sticker> Stickers { get; private set; }

        private iAmYourPapka()
        {
            Labels = new List<Label>();
            Stickers = new List<Sticker>();
            // Labels.Add(new Label() { Name = "Fish", Color = System.Drawing.Color.Blue });
        }

        public static iAmYourPapka Instance
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

        public void LoadLabels(iAmYourPapka singleton)
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

        #region Serialize methods

        private static string dataFileName = "user.dat";
        public static void Serialize()
        {
            using (Stream fStream = new FileStream(dataFileName,
                   FileMode.Create, FileAccess.Write, FileShare.None))
                new BinaryFormatter().Serialize(fStream, iAmYourPapka.Instance);
        }
        public static void Deserialize()
        {
            if (File.Exists(dataFileName))
                using (Stream fStream = new FileStream(dataFileName, FileMode.Open))
                    try { iAmYourPapka.Instance.LoadLabels((iAmYourPapka)new BinaryFormatter().Deserialize(fStream)); }
                    catch (Exception) { }
        }

        #endregion

    }
}
