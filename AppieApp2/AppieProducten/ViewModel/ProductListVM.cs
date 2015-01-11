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

        public ObservableCollection<ProductVM> producten { get; set; }

        public ObservableCollection<ProductVM> ComboBoxProducten { get; set; }

        private IProductRepo proRepo;

        public ProductListVM() {
            proRepo = new DummyProductRepo();

            producten = new ObservableCollection<ProductVM>(proRepo.GetAll().ToList().Select(m => new ProductVM(m)));
            ComboBoxProducten = new ObservableCollection<ProductVM>();
            ComboBoxProducten.Add(new ProductVM { Naam = "Leeg" });
            foreach (ProductVM p in producten) { ComboBoxProducten.Add(p); }
        }

        internal void sort(AfdelingVM value) {
            ComboBoxProducten = new ObservableCollection<ProductVM>();
            ComboBoxProducten.Add(new ProductVM { Naam = "Leeg" });
            if (value.Naam != "Leeg") {
                foreach (ProductVM p in producten) {
                    if (p.AfdelingNaam == value.Naam) {
                        ComboBoxProducten.Add(p);
                    }
                }
            }
            else {
                foreach (ProductVM p in producten) { ComboBoxProducten.Add(p); }
            }
            RaisePropertyChanged(() => ComboBoxProducten);
        }
    }
}
