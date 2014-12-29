using DomainModel.DummyRepos;
using DomainModel.IRepos;
using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace AppieProducten.ViewModel {
    public class ProductMerkListVM : ViewModelBase {

        public ObservableCollection<ProductMerkVM> allProducten { get; set; }

        public ObservableCollection<ProductMerkVM> SortedProducten { get; set; }

        private IProductMerkRepo PMRepo;

        //sorteerStrings
        public string AfdelingNaam { get; set; }
        public string ProductNaam { get; set; }
        public string MerkNaam { get; set; }

        public ProductMerkListVM() {
            PMRepo = new DummyProductMerkRepo();

            allProducten = new ObservableCollection<ProductMerkVM>(PMRepo.GetAll().ToList().Select(m => new ProductMerkVM(m)));
            SortedProducten = allProducten;
        }
    }
}
