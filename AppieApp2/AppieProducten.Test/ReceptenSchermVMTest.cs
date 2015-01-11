using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using AppieProducten.ViewModel;

namespace AppieProducten.Test {
    [TestClass]
    public class ReceptenSchermVMTest {
        [TestMethod]
        public void ReceptenSchermVMTest_DoAddRecept_Succes() {
            //Arrange
            //BoodschappenSchermVM boodschappen = new BoodschappenSchermVM();

            //ReceptenSchermVM testRecepten = new ReceptenSchermVM(boodschappen, new ReceptListVM(), new ReceptProductListVM());
            //testRecepten.ReceptProductList.ReceptProducten = new System.Collections.ObjectModel.ObservableCollection<ReceptProductVM>() {
            //    new ReceptProductVM{ ReceptId = 1, ProductId = 1, Aantal = 1, ProductMerk = new DomainModel.ProductMerk{ Id = 1}},
            //    new ReceptProductVM{ ReceptId = 1, ProductId = 2, Aantal = 1, ProductMerk = new DomainModel.ProductMerk{ Id = 2}},
            //    new ReceptProductVM{ ReceptId = 1, ProductId = 2, Aantal = 3, ProductMerk = new DomainModel.ProductMerk{ Id = 2}},
            //    new ReceptProductVM{ ReceptId = 1, ProductId = 3, Aantal = 3, ProductMerk = new DomainModel.ProductMerk{ Id = 3}}
            //};

            var listAssert = new System.Collections.ObjectModel.ObservableCollection<BoodschappenProductVM>() {
                new BoodschappenProductVM{ProductMerkId = 1, Aantal = 1},
                new BoodschappenProductVM{ProductMerkId = 2, Aantal = 4},
                new BoodschappenProductVM{ProductMerkId = 3, Aantal = 3}
            };
            
            //Act
            //testRecepten.DoAddRecept();

            //Assert
           // CollectionAssert.AreEqual(listAssert, boodschappen.BoodschappenProductLijstVM.BoodschappenLijst);

        }
    }
}
