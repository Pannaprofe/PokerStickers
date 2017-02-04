using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace StickersPD
{
    public static class Serialization
    {
        private static string dataFileName = "user.dat";
        public static void Serialize()
        {
            using (Stream fStream = new FileStream(dataFileName,
                   FileMode.Create, FileAccess.Write, FileShare.None))
                new BinaryFormatter().Serialize(fStream, Singleton.Instance);
        }
        public static void Deserialize()
        {
            if (File.Exists(dataFileName))
                using (Stream fStream = new FileStream(dataFileName, FileMode.Open))
                    try { Singleton.Instance.LoadLabels((Singleton)new BinaryFormatter().Deserialize(fStream)); }
                    catch (Exception) { }
        }
    }
}
