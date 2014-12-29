using DomainModel.DummyRepos;
using DomainModel.IRepos;
using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace AppieProducten.ViewModel {
    public class ProductListVM : ViewModelBase{

        public ObservableCollection<ProductVM> producten;

        private IProductRepo proRepo;

        public ProductListVM() {
            proRepo = new DummyProductRepo();

            producten = new ObservableCollection<ProductVM>(proRepo.GetAll().ToList().Select(m => new ProductVM(m)));
        }
    }
}
