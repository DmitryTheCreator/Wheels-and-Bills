using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Wheels_and_Bills.ViewModels.Base;
using Wheels_and_Bills.Models;
using System.Windows.Input;

namespace Wheels_and_Bills.ViewModels
{
    internal class MainWindowViewModel : ViewModelBase
    {
        #region Заголовок окна

        private string _title = "Wheels and Bills";

        /// <summary>
        /// Заголовок окна
        /// </summary>       
        public string Title
        {
            get => _title;
            set => Set(ref _title, value);
        }

        #endregion

        #region SelectedCar : Car - Выбранный автомобиль

        private Car _SelectedCar;

        /// <summary>Выбранныцй автомобиль</summary>
        public Car SelectedCar
        {
            get => _SelectedCar;
            set => Set(ref _SelectedCar, value);
        }

        #endregion



        public ObservableCollection<Car> CarRegister { get; }

        public MainWindowViewModel()
        {
            var Renault_Kaptur = new Car
            {
                Mark = "Renault",
                Model = "Kaptur",
                Amount = 5,
                BodyShape = "Хетчбэк",
                EnginePower = 149,
                TypeOfDrive = "Передний",
                IssueYear = 2022,
                Price = 1570900,
                Transmission = "МКПП",
                Photo = "/Resources/Images/Cars/renault-kaptur.jpg"
            };
            
            var Renault_Logan = new Car
            {
                Mark = "Renault",
                Model = "Logan",
                Amount = 3,
                BodyShape = "Седан 5-дв.",
                EnginePower = 113,
                TypeOfDrive = "Передний",
                IssueYear = 2022,
                Price = 1124000,
                Transmission = "МКПП",
                Photo = "/Resources/Images/Cars/renault-logan.jpg"
            };
                  
            var cars = new List<Car>
            {
                Renault_Kaptur,
                Renault_Logan
            };

            CarRegister = new ObservableCollection<Car>(cars);
            SelectedCar = cars.First();
        }
    }
}
