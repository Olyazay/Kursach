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

                throw;
            }

       //         return BookCollection;
            
          
            //{
            //    new BookModel()
            //    {
            //        NameBook="Каренина",  Image=ImageConverterToArray(@"C:\Users\Olya Zaitceva\source\repos\InfoAboutBook\DAL\Images\27b2f6d9145632b4852a202ce86f3ced.jpg"), 
            //    },
            //                    new BookModel()
            //    {
            //        NameBook="Колобок",Image=ImageConverterToArray(@"C:\Users\Olya Zaitceva\source\repos\InfoAboutBook\DAL\Images\30c351950ef745ad4ed9e3aa541155af.jpg")
            //    },
            //                    new BookModel()
            //    {
            //        NameBook="Лол",  Image=ImageConverterToArray(@"C:\Users\Olya Zaitceva\source\repos\InfoAboutBook\DAL\Images\31da9a665cc54d00f927801ef9631426.jpg"), 
            //    },                new BookModel()
            //    {
            //        NameBook="Кек", Image=ImageConverterToArray(@"C:\Users\Olya Zaitceva\source\repos\InfoAboutBook\DAL\Images\8da8e78d2eb535ac6c52720267f8bfed.jpg")
            //    }
            //};
        //    return BookCollection; 

        }
        public void Ser()
        {
            BinaryFormatter formatter = new BinaryFormatter();

            using (FileStream fs = new FileStream("pic.dat", FileMode.OpenOrCreate))
            {
                // сериализуем весь массив people
                formatter.Serialize(fs, GetBookCollection());

                Console.WriteLine("Объект сериализован");
            }
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
