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
    public class ReceptListVM : ViewModelBase {

        // ListProperties
        public ObservableCollection<ReceptVM> Recepten { get; set; }

        public ObservableCollection<ReceptVM> AllRecepten { get; set; }

        public ObservableCollection<ReceptVM> ComboboxRecepten { get; set; }

        // SelectedProperties
        private ReceptVM _selectedRecept;
        public ReceptVM SelectedRecept {
            get {
                return this._selectedRecept;
            }
            set {
                this._selectedRecept = value;
                this.RaisePropertyChanged(() => SelectedRecept);
            }
        }

        private ReceptVM _selectedReceptProduct;
        public ReceptVM SelectedReceptProduct {
            get {
                return this._selectedReceptProduct;
            }
            set {
                this._selectedReceptProduct = value;
                this.RaisePropertyChanged(() => SelectedReceptProduct);
            }
        }

        // Edit Properties
        private string _editReceptNaam;
        public string EditReceptNaam {
            get {
                return this._editReceptNaam;
            }
            set {
                this._editReceptNaam = value;
                RaisePropertyChanged(() => EditReceptNaam);
            }
        }

        // Create Properties
        private string _newReceptString;
        public string NewReceptString {
            get {
                return this._newReceptString;
            }
            set {
                this._newReceptString = value;
                this.RaisePropertyChanged(() => NewReceptString);
            }
        }

        // Search Properties
        private string _searchRecept;
        public string SearchRecept {
            get {
                return this._searchRecept;
            }
            set {
                this._searchRecept = value;
                this.RaisePropertyChanged(() => SearchRecept);
            }
        }


        // Repo Propertie
        private IReceptRepo ReceptRepo;

        // Commands
        public ICommand SearchReceptCommand { get; set; }

        public ICommand UpdateReceptCommand { get; set; }

        public ICommand DeleteReceptCommand { get; set; }

        public ICommand CreateReceptCommand { get; set; }

        public ICommand ToepassenCommand { get; set; }

        // Constuctor
        public ReceptListVM() {

            if (ViewModelBase.IsInDesignModeStatic) {
                ReceptRepo = new DummyReceptRepo();
            } else {
                ReceptRepo = new EntityReceptRepo();
            }

            AllRecepten = new ObservableCollection<ReceptVM>(ReceptRepo.GetAll().ToList().Select(m => new ReceptVM(m)));
            Recepten = AllRecepten;
            ComboboxRecepten = new ObservableCollection<ReceptVM>();
            ComboboxRecepten.Add(new ReceptVM { Naam = "Leeg" });
            foreach (ReceptVM a in AllRecepten) { ComboboxRecepten.Add(a); }

            SearchRecept = "";

            SearchReceptCommand = new RelayCommand(ActionSearchRecept);
            UpdateReceptCommand = new RelayCommand(ActionUpdateRecept, CanUpdateRecept);
            DeleteReceptCommand = new RelayCommand(ActionDeleteRecept, CanDeleteRecept);
            CreateReceptCommand = new RelayCommand(ActionCreateRecept, CanCreateRecept);
            ToepassenCommand = new RelayCommand(ActionToepassen);
        }

        // Methods
        private void ActionSearchRecept() {
            var searchedlist = new ObservableCollection<ReceptVM>();
            if (SearchRecept == "") {
                searchedlist = AllRecepten;
            } else {
                foreach (var item in AllRecepten) {
                    if (item.Naam.ToLower().Contains(SearchRecept.ToLower())) {
                        searchedlist.Add(item);
                    }
                }
            }
            Recepten = searchedlist;
            RaisePropertyChanged(() => Recepten);

        }

        private void ActionUpdateRecept() {
            ReceptRepo.Update(SelectedRecept._Recept, EditReceptNaam);
            SelectedRecept = new ReceptVM();
            EditReceptNaam = "";
            AllRecepten = new ObservableCollection<ReceptVM>(ReceptRepo.GetAll().ToList().Select(m => new ReceptVM(m)));
            Recepten = AllRecepten;
            ActionSearchRecept();
            RaisePropertyChanged(() => SelectedRecept);
        }

        private bool CanUpdateRecept() {
            if (SelectedRecept == null) {
                return false;
            } else if (SelectedRecept.Naam == null) {
                return false;
            } else if (SelectedRecept.Naam.Equals("")) {
                return false;
            } else if (EditReceptNaam == null) {
                return false;
            } else if (EditReceptNaam.Equals("")) {
                return false;
            } else if (SelectedRecept.Naam.Equals(EditReceptNaam)) {
                return false;
            } else {
                return true;
            }
        }

        private void ActionDeleteRecept() {
            this.AllRecepten.Remove(this.SelectedRecept);
            SelectedRecept = new ReceptVM();
            Recepten = AllRecepten;
            this.ActionSearchRecept();
            RaisePropertyChanged(() => SelectedRecept);
        }

        private bool CanDeleteRecept() {
            if (SelectedRecept == null) {
                return false;
            } else if (SelectedRecept.Naam == null) {
                return false;
            } else if (SelectedRecept.Naam.Equals("")) {
                return false;
            } else {
                return true;
            }
        }

        private void ActionCreateRecept() {
            this.AllRecepten.Add(new ReceptVM { Naam = this.NewReceptString });
            this.NewReceptString = "";
            Recepten = AllRecepten;
            this.ActionSearchRecept();
            RaisePropertyChanged(() => AllRecepten);
        }

        private bool CanCreateRecept() {
            if (NewReceptString == null) {
                return false;
            } else if (NewReceptString.Equals("")) {
                return false;
            } else {
                return true;
            }
        }

        public void ActionToepassen() {
            var dbList = ReceptRepo.GetAll().ToList().Select(m => new ReceptVM(m)).ToList();
            var myList = AllRecepten.ToList();
            List<ReceptVM> newDbList = dbList.ToList();
            List<ReceptVM> newMyList = myList.ToList();

            foreach (ReceptVM dbRecept in dbList) {
                foreach (ReceptVM myRecept in myList) {
                    if (dbRecept.Naam == myRecept.Naam) {
                        newDbList.Remove(dbRecept);
                        newMyList.Remove(myRecept);
                        break;
                    }
                }
            }

            foreach (ReceptVM dbRecept in newDbList) { ReceptRepo.delete(dbRecept.Id); }
            foreach (ReceptVM myRecept in newMyList) { ReceptRepo.Add(myRecept.Naam); }
            ReceptRepo.SaveChanges();
        }

    }
}
