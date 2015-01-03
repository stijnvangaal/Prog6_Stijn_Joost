/*
  In App.xaml:
  <Application.Resources>
      <vm:ViewModelLocator xmlns:vm="clr-namespace:AppieProducten"
                           x:Key="Locator" />
  </Application.Resources>
  
  In the View:
  DataContext="{Binding Source={StaticResource Locator}, Path=ViewModelName}"

  You can also use Blend to do all this with the tool's support.
  See http://www.galasoft.ch/mvvm
*/

using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Ioc;
using Microsoft.Practices.ServiceLocation;

namespace AppieProducten.ViewModel
{
    /// <summary>
    /// This class contains static references to all the view models in the
    /// application and provides an entry point for the bindings.
    /// </summary>
    public class ViewModelLocator
    {
        /// <summary>
        /// Initializes a new instance of the ViewModelLocator class.
        /// </summary>
        public ViewModelLocator()
        {
            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);

            if (ViewModelBase.IsInDesignModeStatic) {
                //get dummy
            }
            else {
                //get entity
            }

            //lijsten
            //SimpleIoc.Default.Register<BoodschappenProductLijstVM>();

            //windows
            SimpleIoc.Default.Register<MainViewModel>();
            SimpleIoc.Default.Register<BoodschappenSchermVM>();
            SimpleIoc.Default.Register<BeheerSchermVM>();
        }

        public MainViewModel Main
        {
            get
            {
                return ServiceLocator.Current.GetInstance<MainViewModel>();
            }
        }

        public BoodschappenSchermVM Boodschappen {
            get { return ServiceLocator.Current.GetInstance<BoodschappenSchermVM>(); }
        }

        public BeheerSchermVM Beheer {
            get { return ServiceLocator.Current.GetInstance<BeheerSchermVM>(); }
        }

        public static void Cleanup()
        {
            // TODO Clear the ViewModels
        }
    }
}