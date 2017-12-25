using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using BL;
using Contracts; 


namespace InfoAboutBook
{
    public class ViewModel:INotifyPropertyChanged
    {
        public ViewModel()
        {
            Position = -1;
            if (data.GetCollection().Count>0)
            {
                PhotoPathShop = data.GetCollection()[0].Image;
                NameBook = data.GetCollection()[0].NameBook;
            }

            
        }
        private String _nameBook;
        public String NameBook
        {
            get
            {
                return _nameBook;
            }
            set
            {
               _nameBook = value;
                OnPropertyChange("NameBook");
            }
        }
        private byte[] _photoPathBook;
        public byte[] PhotoPathShop
        {
            get
            {
                return _photoPathBook;
            }
            set
            {
                _photoPathBook = value;
                OnPropertyChange("PhotoPathShop");
            }
        }
        public int Position { get; set; }
        DataProcesing data = new DataProcesing(); 
        private Command _registrateNewUser;
        public Command RegistrateNewUser => _registrateNewUser ?? (_registrateNewUser = new Command(obj =>
        {
                if ((Position < data.GetCollection().Count - 1)&&(data.GetCollection().Count > 0))
                {
                    Position++;
                    PhotoPathShop = data.GetCollection().ElementAt(Position).Image;
                    NameBook = data.GetCollection().ElementAt(Position).NameBook;
                }
        }
        ));
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
