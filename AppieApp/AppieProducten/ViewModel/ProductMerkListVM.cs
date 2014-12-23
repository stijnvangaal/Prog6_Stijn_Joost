using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace AppieProducten.ViewModels {
    class ProductMerkListVM : ViewModelBase{

        public ObservableCollection<ProductMerkVM> boodschappen { get; set; }
    }
}
