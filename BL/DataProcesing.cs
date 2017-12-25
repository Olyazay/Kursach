using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using System.Collections.ObjectModel;
using Contracts; 

namespace BL
{
    public class DataProcesing
    {
        public DataReader reader { get; set; }
        public ObservableCollection<BookModel> BookCollection { get; set; }
        public ObservableCollection<BookModel> GetCollection()
        {
            BookCollection = new ObservableCollection<BookModel>(); 

            reader = new DataReader();
            foreach (var t in reader.GetBookCollection())
            {
                BookCollection.Add(t); 
            }
            return BookCollection; 
        }
    }
}
