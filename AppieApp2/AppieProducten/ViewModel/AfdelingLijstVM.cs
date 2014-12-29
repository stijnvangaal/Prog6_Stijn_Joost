using DomainModel.IRepos;
using DomainModel.DummyRepos;
using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace AppieProducten.ViewModel {
    public class AfdelingLijstVM : ViewModelBase{

        public ObservableCollection<AfdelingVM> afdelingen { get; set; }

        private IAfdelingRepo afRepo;


        public AfdelingLijstVM() {
            afRepo = new DummyAfdelingRepo();
            afdelingen = new ObservableCollection<AfdelingVM>(afRepo.GetAll().ToList().Select(m => new AfdelingVM(m)));
        }
    }
}
