using DomainModel.IRepos;
using DomainModel.DummyRepos;
using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace AppieProducten.ViewModel {
    public class BoodschappenProductLijstVM : ViewModelBase{

        private IBoodschappenProductRepo boodschappenRepo;

        public ObservableCollection<BoodschappenProductVM> BoodschappenLijst { get; set; }

        public BoodschappenProductLijstVM() {
            int id = 1;
            boodschappenRepo = new DummyBoodschappenProductRepo();

            BoodschappenLijst = new ObservableCollection<BoodschappenProductVM>(boodschappenRepo.GetAllById(id).ToList().Select(m => new BoodschappenProductVM(m)));
        }
    }
}
