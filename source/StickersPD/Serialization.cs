using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace StickersPD
{
    public static class Serialization
    {
        public static void Serialize()
        {
            BinaryFormatter binFormat = new BinaryFormatter();
            // Сохранить объект в локальном файле.
            using (Stream fStream = new FileStream("user.dat",
               FileMode.Create, FileAccess.Write, FileShare.None))
            {
                binFormat.Serialize(fStream, Singleton.Instance);
            }
        }

        public static void Deserialize()
        {
            if (File.Exists("user.dat"))
            {
                BinaryFormatter binFormat = new BinaryFormatter();
                Singleton x;

                using (Stream fStream = new FileStream("user.dat", FileMode.Open))
                {
                    try
                    {
                        x = (Singleton)binFormat.Deserialize(fStream);
                        Singleton.Instance.LoadLabels(x);
                    }
                    catch (Exception e)
                    {

                        // smth wrong with the file
                    }
                }

            }

        }
    }
}
