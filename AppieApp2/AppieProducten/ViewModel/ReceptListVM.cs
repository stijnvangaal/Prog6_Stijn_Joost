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
    public class ReceptListVM : ViewModelBase{

        private IReceptRepo receptRepo;

        public ObservableCollection<ReceptVM> recepten { get; set; }

        public ReceptListVM() {
            if (ViewModelBase.IsInDesignModeStatic) {
                receptRepo = new DummyReceptRepo();
            }
            else {
                receptRepo = new EntityReceptRepo();
            }

            recepten = new ObservableCollection<ReceptVM>(receptRepo.GetAll().ToList().Select(m => new ReceptVM(m)));
        }
    }
}
