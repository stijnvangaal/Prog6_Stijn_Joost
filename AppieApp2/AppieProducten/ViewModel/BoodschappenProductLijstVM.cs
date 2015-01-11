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

    public class BoodschappenProductLijstVM : ViewModelBase {


        //properties
        private IBoodschappenProductRepo boodschappenRepo;

        public int LijstId { get; set; }
        public string KortingCode { get; set; }

        public double TotaalPrijs {
            get { return CalcTotaal(); }
        }
        public int KortingAantal { get { return MyKortingen.Count; } }

        //list props
        public ObservableCollection<BoodschappenProductVM> BoodschappenLijst { get; set; }
        private KortingListVM allkortingen;
        public List<KortingVM> MyKortingen { get; set; }

        //command props
        public ICommand AddKorting { get; set; }

        //constructor
        public BoodschappenProductLijstVM() {
            boodschappenRepo = new DummyBoodschappenProductRepo();
            allkortingen = new KortingListVM();
            MyKortingen = new List<KortingVM>();

            BoodschappenLijst = new ObservableCollection<BoodschappenProductVM>(boodschappenRepo.GetAllById(LijstId).ToList().Select(m => new BoodschappenProductVM(m)));
            AddKorting = new RelayCommand(TryAddKorting);
        }

        //methods
        public Boolean addProduct(ProductMerkVM product) {
            if (product == null) { return false; }
            foreach (BoodschappenProductVM b in BoodschappenLijst) {
                if (b.ProductMerkId == product.Id) {
                    b.Aantal++;
                    RaisePropertyChanged(() => TotaalPrijs);
                    RaisePropertyChanged(() => b.PrijsProducten);
                    return true;
                }
            }
            product.Prijs = checkProductKorting(product);
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

        private double checkProductKorting(ProductMerkVM product) {
            foreach (KortingVM k in MyKortingen) {
                if (k.ProductMerkId == product.Id) { return (product.Prijs * k.Percentage); }
            }
            return product.Prijs;
        }

        private void checkKorting(KortingVM korting) {
            foreach (BoodschappenProductVM b in BoodschappenLijst) {
                if (b.ProductMerkId == korting.ProductMerkId) { 
                    b.ProductMerk.Prijs = b.ProductMerk.Prijs * korting.Percentage;
                    RaisePropertyChanged(() => b.PrijsProducten);
                    break; 
                }
            }
        }

        public void TryAddKorting() {
            bool doAdd = true;

            //check if already used
            foreach (KortingVM k in MyKortingen) {
                if (k.KortingCode == this.KortingCode) { doAdd = false; break; }
            }
            if (doAdd) {
                KortingVM korting = null;
                //check if existing code
                foreach (KortingVM k in allkortingen.kortingen) {
                    if (k.KortingCode == this.KortingCode) { korting = k; break; }
                }
                if (korting != null) {
                    //check if korting stil available
                    DateTime now = DateTime.Now;
                    if (korting.BeginDatum <= now && korting.EindDatum >= now) {
                        //add korting
                        MyKortingen.Add(korting);
                        this.KortingCode = "";
                        checkKorting(korting);
                        RaisePropertyChanged(string.Empty);
                    }
                }
            }
        }
    }
}
