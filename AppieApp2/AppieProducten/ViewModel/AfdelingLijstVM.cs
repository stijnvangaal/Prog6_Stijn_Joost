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
using DomainModel.EntityRepos;

namespace AppieProducten.ViewModel {
    public class AfdelingLijstVM : ViewModelBase{

        // ListProperties
        public ObservableCollection<AfdelingVM> Afdelingen { get; set; }

        public ObservableCollection<AfdelingVM> AllAfdelingen { get; set; }

        public ObservableCollection<AfdelingVM> ComboboxAfdelingen { get; set; }

        // SelectedProperties
        private AfdelingVM _selectedAfdeling;
        public AfdelingVM SelectedAfdeling {
            get {
                return this._selectedAfdeling;
            }
            set {
                this._selectedAfdeling = value;
                this.RaisePropertyChanged("_selectedAfdeling");
            }
        }

        // Search Propertie
        private string _searchString;
        public string SearchString {
            get {
                return this._searchString;
            }
            set {
                this._searchString = value;
                this.RaisePropertyChanged("_searchString");
            }
        }

        // RepoPropertie
        private IAfdelingRepo afRepo;

        // Commands
        public ICommand Search { get; set; }

        // Constuctor
        public AfdelingLijstVM() {
            if (ViewModelBase.IsInDesignModeStatic) {
                afRepo = new DummyAfdelingRepo();
            }
            else {
                afRepo = new EntityAfdelingRepo();
            }


            AllAfdelingen = new ObservableCollection<AfdelingVM>(afRepo.GetAll().ToList().Select(m => new AfdelingVM(m)));
            Afdelingen = AllAfdelingen;
            ComboboxAfdelingen = new ObservableCollection<AfdelingVM>();
            ComboboxAfdelingen.Add(new AfdelingVM { Naam = "Leeg" });
            foreach (AfdelingVM a in Afdelingen) { ComboboxAfdelingen.Add(a); }

            Search = new RelayCommand(ActionSearch);
        }

        // Methods
        public void ActionSearch() {

        }
    }
}
