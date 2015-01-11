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
    public class MerkLijstVM : ViewModelBase {

        // ListProperties
        public ObservableCollection<MerkVM> Merken { get; set; }

        public ObservableCollection<MerkVM> AllMerken { get; set; }

        public ObservableCollection<MerkVM> ComboboxMerken { get; set; }

        // SelectedProperties
        private MerkVM _selectedMerk;
        public MerkVM SelectedMerk {
            get {
                return this._selectedMerk;
            }
            set {
                this._selectedMerk = value;
                this.RaisePropertyChanged(() => SelectedMerk);
            }
        }

        private MerkVM _selectedMerkProduct;
        public MerkVM SelectedMerkProduct {
            get {
                return this._selectedMerkProduct;
            }
            set {
                this._selectedMerkProduct = value;
                this.RaisePropertyChanged(() => SelectedMerkProduct);
            }
        }

        // Edit Properties
        private string _editMerkNaam;
        public string EditMerkNaam {
            get {
                return this._editMerkNaam;
            }
            set {
                this._editMerkNaam = value;
                RaisePropertyChanged(() => EditMerkNaam);
            }
        }

        // Create Properties
        private string _newMerkString;
        public string NewMerkString {
            get {
                return this._newMerkString;
            }
            set {
                this._newMerkString = value;
                this.RaisePropertyChanged(() => NewMerkString);
            }
        }

        // Search Properties
        private string _searchMerk;
        public string SearchMerk {
            get {
                return this._searchMerk;
            }
            set {
                this._searchMerk = value;
                this.RaisePropertyChanged(() => SearchMerk);
            }
        }


        // Repo Propertie
        private IMerkRepo merkRepo;

        // Commands
        public ICommand SearchMerkCommand { get; set; }

        public ICommand UpdateMerkCommand { get; set; }

        public ICommand DeleteMerkCommand { get; set; }

        public ICommand CreateMerkCommand { get; set; }

        public ICommand ToepassenCommand { get; set; }

        // Constuctor
        public MerkLijstVM() {

            if (ViewModelBase.IsInDesignModeStatic) {
                merkRepo = new DummyMerkRepo();
            } else {
                merkRepo = new EntityMerkRepo();
            }

            AllMerken = new ObservableCollection<MerkVM>(merkRepo.GetAll().ToList().Select(m => new MerkVM(m)));
            Merken = AllMerken;
            ComboboxMerken = new ObservableCollection<MerkVM>();
            ComboboxMerken.Add(new MerkVM { Naam = "Leeg" });
            foreach (MerkVM a in Merken) { ComboboxMerken.Add(a); }

            SearchMerk = "";

            SearchMerkCommand = new RelayCommand(ActionSearchMerk);
            UpdateMerkCommand = new RelayCommand(ActionUpdateMerk, CanUpdateMerk);
            DeleteMerkCommand = new RelayCommand(ActionDeleteMerk, CanDeleteMerk);
            CreateMerkCommand = new RelayCommand(ActionCreateMerk, CanCreateMerk);
            ToepassenCommand = new RelayCommand(ActionToepassen);
        }

        // Methods
        private void ActionSearchMerk() {
            var searchedlist = new ObservableCollection<MerkVM>();
            if (SearchMerk == "") {
                searchedlist = AllMerken;
            } else {
                foreach (var item in AllMerken) {
                    if (item.Naam.ToLower().Contains(SearchMerk.ToLower())) {
                        searchedlist.Add(item);
                    }
                }
            }
            Merken = searchedlist;
            RaisePropertyChanged(() => Merken);

        }

        private void ActionUpdateMerk() {
            merkRepo.Update(SelectedMerk._Merk, EditMerkNaam);
            SelectedMerk = new MerkVM();
            EditMerkNaam = "";
            AllMerken = new ObservableCollection<MerkVM>(merkRepo.GetAll().ToList().Select(m => new MerkVM(m)));
            Merken = AllMerken;
            ActionSearchMerk();
            RaisePropertyChanged(() => SelectedMerk);
        }

        private bool CanUpdateMerk() {
            if (SelectedMerk == null) {
                return false;
            } else if (SelectedMerk.Naam == null) {
                return false;
            } else if (SelectedMerk.Naam.Equals("")) {
                return false;
            } else if (EditMerkNaam == null) {
                return false;
            } else if (EditMerkNaam.Equals("")) {
                return false;
            } else if (SelectedMerk.Naam.Equals(EditMerkNaam)) {
                return false;
            } else {
                return true;
            }
        }

        private void ActionDeleteMerk() {
            this.AllMerken.Remove(this.SelectedMerk);
            SelectedMerk = new MerkVM();
            Merken = AllMerken;
            this.ActionSearchMerk();
            RaisePropertyChanged(() => SelectedMerk);
        }

        private bool CanDeleteMerk() {
            if (SelectedMerk == null) {
                return false;
            } else if (SelectedMerk.Naam == null) {
                return false;
            } else if (SelectedMerk.Naam.Equals("")) {
                return false;
            } else {
                return true;
            }
        }

        private void ActionCreateMerk() {
            this.AllMerken.Add(new MerkVM { Naam = this.NewMerkString });
            this.NewMerkString = "";
            Merken = AllMerken;
            this.ActionSearchMerk();
            RaisePropertyChanged(() => AllMerken);
        }

        private bool CanCreateMerk() {
            if (NewMerkString == null) {
                return false;
            } else if (NewMerkString.Equals("")) {
                return false;
            } else {
                return true;
            }
        }

        public void ActionToepassen() {
            var dbList = merkRepo.GetAll().ToList().Select(m => new MerkVM(m)).ToList();
            var myList = AllMerken.ToList();
            List<MerkVM> newDbList = dbList.ToList();
            List<MerkVM> newMyList = myList.ToList();

            foreach (MerkVM dbMerk in dbList) {
                foreach (MerkVM myMerk in myList) {
                    if (dbMerk.Naam == myMerk.Naam) {
                        newDbList.Remove(dbMerk);
                        newMyList.Remove(myMerk);
                        break;
                    }
                }
            }

            foreach (MerkVM dbMerk in newDbList) { merkRepo.Delete(dbMerk._Merk); }
            foreach (MerkVM myMerk in newMyList) { merkRepo.Create(myMerk._Merk); }
            merkRepo.SaveChanges();
        }

    }
}
