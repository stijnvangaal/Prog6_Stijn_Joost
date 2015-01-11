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
                this.RaisePropertyChanged(()=> SelectedAfdeling);
            }
        }

        private AfdelingVM _selectedAfdelingProduct;
        public AfdelingVM SelectedAfdelingProduct {
            get {
                return this._selectedAfdelingProduct;
            }
            set {
                this._selectedAfdelingProduct = value;
                this.RaisePropertyChanged(()=> SelectedAfdelingProduct);
            }
        }

        // Create Properties
        private string _newAfdelingString;
        public string NewAfdelingString {
            get {
                return this._newAfdelingString;
            }
            set {
                this._newAfdelingString = value;
                this.RaisePropertyChanged(()=> NewAfdelingString);
            }
        }

        // Search Properties
        private string _searchAfdeling;
        public string SearchAfdeling {
            get {
                return this._searchAfdeling;
            }
            set {
                this._searchAfdeling = value;
                this.RaisePropertyChanged(()=> SearchAfdeling);
            }
        }


        // Repo Propertie
        private IAfdelingRepo afRepo;

        // Commands
        public ICommand SearchAfdelingCommand { get; set; }

        public ICommand UpdateAfdelingCommand { get; set; }

        public ICommand DeleteAfdelingCommand { get; set; }

        public ICommand CreateAfdelingCommand { get; set; }

        public ICommand ToepassenCommand { get; set; }

        // Constuctor
        public AfdelingLijstVM() {
            
            if (ViewModelBase.IsInDesignModeStatic) {
                afRepo = new DummyAfdelingRepo();
            } else {
                afRepo = new EntityAfdelingRepo();
            }

            AllAfdelingen = new ObservableCollection<AfdelingVM>(afRepo.GetAll().ToList().Select(m => new AfdelingVM(m)));
            Afdelingen = AllAfdelingen;
            ComboboxAfdelingen = new ObservableCollection<AfdelingVM>();
            ComboboxAfdelingen.Add(new AfdelingVM { Naam = "Leeg" });
            foreach (AfdelingVM a in Afdelingen) { ComboboxAfdelingen.Add(a); }

            SearchAfdeling = "";

            SearchAfdelingCommand = new RelayCommand(ActionSearchAfdeling);
            UpdateAfdelingCommand = new RelayCommand(ActionUpdateAfdeling);
            DeleteAfdelingCommand = new RelayCommand(ActionDeleteAfdeling);
            CreateAfdelingCommand = new RelayCommand(ActionCreateAfdeling);
            ToepassenCommand = new RelayCommand(ActionToepassen);
        }

        // Methods
        private void ActionSearchAfdeling() {
            var searchedlist = new ObservableCollection<AfdelingVM>();
            if (SearchAfdeling == "") {
                searchedlist = AllAfdelingen;
            } else {
                foreach (var item in AllAfdelingen) {
                    if (item.Naam.ToLower().Contains(SearchAfdeling.ToLower())) {
                        searchedlist.Add(item);
                    }
                }
            }
            Afdelingen = searchedlist;
            RaisePropertyChanged(() => Afdelingen);

        }

        private void ActionUpdateAfdeling() {
            RaisePropertyChanged(() => SelectedAfdeling);
        }

        private void ActionDeleteAfdeling() {
            this.AllAfdelingen.Remove(this.SelectedAfdeling);
            SelectedAfdeling = new AfdelingVM();
            Afdelingen = AllAfdelingen;
            this.ActionSearchAfdeling();
            RaisePropertyChanged(() => SelectedAfdeling);
        }

        private void ActionCreateAfdeling() {
            this.AllAfdelingen.Add(new AfdelingVM { Naam = this.NewAfdelingString });
            Afdelingen = AllAfdelingen;
            this.ActionSearchAfdeling();
            RaisePropertyChanged(() => AllAfdelingen);
        }

        public void ActionToepassen() {
            var dbList = afRepo.GetAll().ToList().Select(m => new AfdelingVM(m)).ToList();
            var myList = AllAfdelingen.ToList();
            List<AfdelingVM> newDbList = dbList.ToList();
            List<AfdelingVM> newMyList = myList.ToList();

            foreach (AfdelingVM dbAfdeling in dbList) {
                foreach (AfdelingVM myAfdeling in myList) {
                    if (dbAfdeling.Naam == myAfdeling.Naam) {
                        newDbList.Remove(dbAfdeling);
                        newMyList.Remove(myAfdeling);
                        break;
                    }
                }
            }

            foreach (AfdelingVM dbAfdeling in newDbList) { afRepo.Delete(dbAfdeling._Afdeling); }
            foreach (AfdelingVM myAfdeling in newMyList) { afRepo.Create(myAfdeling._Afdeling); }
            afRepo.SaveChanges();
        }

    }
}
