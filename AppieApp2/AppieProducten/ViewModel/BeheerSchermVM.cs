using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AppieProducten.ViewModel{
    public class BeheerSchermVM : ViewModelBase{

        public AfdelingLijstVM AfdelingLijstVM { get; set; }
        public ProductListVM ProductListVM { get; set; }
        public ProductMerkListVM ProductMerkListVM { get; set; }
        public MerkListVM MerkListVM { get; set; }

        public BeheerSchermVM() {
            this.AfdelingLijstVM = new AfdelingLijstVM();
            this.ProductListVM = new ProductListVM();
            this.ProductMerkListVM = new ProductMerkListVM();
            this.MerkListVM = new MerkListVM();

        }

    }
}
