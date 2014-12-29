using DomainModel;
using DomainModel.DummyRepos;
using DomainModel.IRepos;
using GalaSoft.MvvmLight;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace AppieProducten.ViewModel
{
    
    public class MainViewModel : ViewModelBase
    {
        /// <summary>
        /// Initializes a new instance of the MainViewModel class.
        /// </summary>
        /// 

        public ProductMerkListVM productMerkListVM { get; set; }
        public AfdelingLijstVM afdelingLijstVM { get; set; }
        public ProductListVM productListVM { get; set; }
        public MerkListVM merkListVM { get; set; }

        public MainViewModel()
        {
            this.productMerkListVM = new ProductMerkListVM();
            this.afdelingLijstVM = new AfdelingLijstVM();
            this.productListVM = new ProductListVM();
            this.merkListVM = new MerkListVM();
        }
    }
}