using GalaSoft.MvvmLight.Ioc;
using Microsoft.Practices.ServiceLocation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manager.ViewModels {
    public class ViewModelLocator {
        static ViewModelLocator() {

            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);
        }

        public static void Cleanup() {

        }
    }
}
