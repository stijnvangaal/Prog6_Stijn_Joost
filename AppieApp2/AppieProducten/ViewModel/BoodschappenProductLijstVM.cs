using DomainModel.IRepos;
using DomainModel.DummyRepos;
using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Windows.Input;
using GalaSoft.MvvmLight.Command;
using DomainModel;

namespace AppieProducten.ViewModel {

    public class BoodschappenProductLijstVM : ViewModelBase{

        private IBoodschappenProductRepo boodschappenRepo;

        public int LijstId { get; set; }

        public double TotaalPrijs {
            get { return CalcTotaal(); } 
        }

        public ObservableCollection<BoodschappenProductVM> BoodschappenLijst { get; set; }

        public BoodschappenProductLijstVM() {
            boodschappenRepo = new DummyBoodschappenProductRepo();

            BoodschappenLijst = new ObservableCollection<BoodschappenProductVM>(boodschappenRepo.GetAllById(LijstId).ToList().Select(m => new BoodschappenProductVM(m)));
        }

        public Boolean addProduct(ProductMerkVM product) {
            foreach (BoodschappenProductVM b in BoodschappenLijst) {
                if (b.ProductMerkId == product.Id) { 
                    b.Aantal++;
                    RaisePropertyChanged(() => TotaalPrijs);
                    return true; }
            }
            BoodschappenLijst.Add(new BoodschappenProductVM { ProductMerkId = product.Id, BoodschappenLijstId = LijstId, ProductMerk = product, Aantal = 1 });
            RaisePropertyChanged(() => TotaalPrijs);
            return true;
        }

        private double CalcTotaal() {
            double totaal = 0;

            foreach (BoodschappenProductVM b in BoodschappenLijst) {
                totaal += b.PrijsProducten;
            }

            return totaal;
        }
    }
}
