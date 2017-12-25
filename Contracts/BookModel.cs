using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Windows.Media.Imaging;
using System.Drawing;

namespace Contracts
{
    [Serializable]
    public class BookModel:INotifyPropertyChanged
    {
        private string _nameBook;
        public string NameBook
        {
            get { return _nameBook; }
            set
            {
                _nameBook = value;
                OnPropertyChange("NameBook");
            }
        }

        private byte[] _image;
        public byte[] Image
        {
            get { return _image; }
            set
            {
               _image = value;
                OnPropertyChange("Image");
            }
        }
        public BookModel()
        {
                
        }
        private Bitmap _image1;
        public Bitmap Image1
        {
            get { return _image1; }
            set
            {
                _image1 = value;
                OnPropertyChange("Image1");
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChange(String propertyname)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyname));
            }
        }
    }
}
