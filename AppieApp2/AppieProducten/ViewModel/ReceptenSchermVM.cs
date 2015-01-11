using DomainModel;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;

namespace AppieProducten.ViewModel {
    public class ReceptenSchermVM : ViewModelBase{

        private BoodschappenSchermVM Boodschappen;
        public ReceptListVM ReceptList { get; set; }
        public ReceptProductListVM ReceptProductList { get; set; }
        public ICommand AddRecept { get; set; }

        public ReceptenSchermVM(BoodschappenSchermVM boodschappen, ReceptListVM recepten, ReceptProductListVM receptProducten) {
            Boodschappen = boodschappen;
            ReceptList = recepten;
            ReceptProductList = receptProducten;

            AddRecept = new RelayCommand(DoAddRecept, CanAddRecept);
        }

        public void DoAddRecept() {
            foreach (ReceptProductVM r in ReceptProductList.ReceptProducten) {
                ProductMerkVM temp = new ProductMerkVM(r.ProductMerk);
                for (int aantal = r.Aantal; aantal > 0; aantal--) {
                    Boodschappen.BoodschappenProductLijstVM.addProduct(temp);
                }
            }
            RaisePropertyChanged(() => Boodschappen.BoodschappenProductLijstVM.BoodschappenLijst);
        }

        private bool CanAddRecept() {
            if (ReceptProductList.SelectedRecept == null) { return false; }
            return true;
        }
    }
}
