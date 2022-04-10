using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using TestOnWPF.ViewModels.Base;
using TestOnWPF.Models;

namespace TestOnWPF.ViewModels
{
    internal class MainWindowViewModel : ViewModelBase
    {
        #region Заголовок окна

        private string _title = "Wheels and Bills";

        /// <summary>Заголовок окна</summary>

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
            //var car_index = 1;

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
                Photo = "/Cars/renault-kaptur-vnedorozhnik-siniy-goluboy-fioletovyy-10.jpg"
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
                Photo = "/Cars/renault-logan-sedan-seryy-10.png"
            };
            var Renault_Logan1 = new Car
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
                Photo = "/Cars/renault-logan-sedan-seryy-10.png"
            };
            //var cars = Enumerable.Range(1, 20).Select(i => new Car
            //{
            //    Mark = $"Car {car_index}",
            //    Amount = car_index * 10,
            //    BodyShape = car_index.ToString(),
            //    EnginePower = car_index * 100,
            //    TypeOfDrive = car_index.ToString(),
            //    IssueYear = car_index + 2000,
            //    Price = car_index * 100000,
            //    Transmission = car_index++.ToString(),
            //    Photo = new CarPhoto
            //    {
            //        MainPhoto = "Data/Pictures/Main_Renault_Logan.jpg",
            //        BackPhoto = "Data/Pictures/Back_Renault_Logan.jpg",
            //        SidePhoto = "Data/Pictures/Side-Back_Renault_Logan.jpg",          
            //    }      
            //});
            var cars = new List<Car>
            {
                Renault_Kaptur,
                Renault_Logan,
                Renault_Logan1
            };


            CarRegister = new ObservableCollection<Car>(cars);
            SelectedCar = cars.First();
        }
    }
}
