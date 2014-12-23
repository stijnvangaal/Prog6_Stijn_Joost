using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AppieProducten.ViewModel {
    public class BoodschappenSchermVM : ViewModelBase{

        public BoodschappenProductLijstVM BoodschappenProductLijstVM { get; set; }

        public BoodschappenSchermVM() {
            BoodschappenProductLijstVM = new BoodschappenProductLijstVM();
        }
    }
}
