using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Contracts;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Windows.Media.Imaging;
using System.Runtime.Serialization.Formatters.Binary;
using System.Windows;

namespace DAL
{
    public class DataReader
    {
        public ObservableCollection<BookModel> BookCollection { get; set; }
        public ObservableCollection<BookModel> GetBookCollection()
        {
            BinaryFormatter formatter = new BinaryFormatter();
            BookCollection = new ObservableCollection<BookModel>();
            try
            {
                using (FileStream fs = new FileStream("pic.dat", FileMode.OpenOrCreate))
                {
                    ObservableCollection<BookModel> BookCollection = (ObservableCollection<BookModel>)formatter.Deserialize(fs);
                    return BookCollection;
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Файл не найден"); 
            }
            return null;
        }

        public byte[] ImageConverterToArray(string path)
        {

            Bitmap image = new Bitmap(path);
            ImageFormat format = image.RawFormat;
            using (MemoryStream ms = new MemoryStream())
            {
                image.Save(ms, format);
                return ms.ToArray();
            }

        }
    }
}
