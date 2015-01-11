using DomainModel.DummyRepos;
using DomainModel.EntityRepos;
using DomainModel.IRepos;
using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace AppieProducten.ViewModel {
    public class ReceptProductListVM : ViewModelBase{

        private IReceptProductRepo productenRepo;

        public ObservableCollection<ReceptProductVM> ReceptProducten { get; set; }

        private ReceptVM _SelectedRecept;
        public ReceptVM SelectedRecept {
            get { return _SelectedRecept; }
            set { 
                _SelectedRecept = value;
                selectionChanged();
            }
        }

        public double TotalPrice { get; set; }

        public ReceptProductListVM() {
            if (ViewModelBase.IsInDesignModeStatic) {
                productenRepo = new DummyReceptProductRepo();
            }
            else {
                productenRepo = new EntityReceptProductRepo();
            }
        }

        private void selectionChanged() {
            ReceptProducten = new ObservableCollection<ReceptProductVM>(productenRepo.GetAll(SelectedRecept.Id).ToList().Select(m => new ReceptProductVM(m)));
            Calculate();
            RaisePropertyChanged(() => ReceptProducten);
        }

        private void Calculate() {
            TotalPrice = 0;
            foreach (ReceptProductVM r in ReceptProducten) {
                TotalPrice += r.Total;
            }
            RaisePropertyChanged(() => TotalPrice);
        }
    }
}
