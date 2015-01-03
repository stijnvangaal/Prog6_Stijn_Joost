using DomainModel.DummyRepos;
using DomainModel.IRepos;
using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace AppieProducten.ViewModel {
    public class KortingListVM :ViewModelBase{

        public ObservableCollection<KortingVM> kortingen;

        private IKortingRepo kortingRepo;

        public KortingListVM() {
            kortingRepo = new DummyKortingRepo();

            kortingen = new ObservableCollection<KortingVM>(kortingRepo.GetAll().ToList().Select(m => new KortingVM(m)));
        }
    }
}
