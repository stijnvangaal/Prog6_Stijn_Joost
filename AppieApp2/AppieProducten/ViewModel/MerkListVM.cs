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
    public class MerkListVM : ViewModelBase{

        public ObservableCollection<MerkVM> merken { get; set; }

        public ObservableCollection<MerkVM> ComboBoxMerken { get; set; }

        private IMerkRepo merkRepo;

        public MerkListVM() {
            if (ViewModelBase.IsInDesignModeStatic) {
                merkRepo = new DummyMerkRepo();
            }
            else {
                merkRepo = new EntityMerkRepo();
            }

            merken = new ObservableCollection<MerkVM>(merkRepo.GetAll().ToList().Select(m => new MerkVM(m)));
            ComboBoxMerken = new ObservableCollection<MerkVM>();
            ComboBoxMerken.Add(new MerkVM { Naam = "Leeg" });
            foreach (MerkVM m in merken) { ComboBoxMerken.Add(m); }
        }
    }
}
