using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Wheels_and_Bills.ViewModels.Base;
using Wheels_and_Bills.Models;
using Microsoft.Data.Sqlite;
using System.Windows.Input;
using System;
using System.IO;

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
            var cars = new List<Car>();
            string SqlExpression = "SELECT cars.id, makes.make, cars.model, cars.color, tipes_dog.tipe_dog, categories_dog.category_dog," +
                "cars.reg_znak, cars.year_dog, fuel_tipes.fuel_tipe, cars.doors_num, body_styles.body_style, drive_wheels.drive_wheel," +
                "transmissions.transmission, engine_tipes.engine_tipe, cars.cylinders_num, fuel_systems.fuel_system, cars.horsepower," +
                "cars.city_mpg, cars.highway_mpg, cars.price, cars.count_cars FROM cars INNER JOIN makes, tipes_dog, categories_dog, fuel_tipes," +
                "body_styles, drive_wheels, transmissions, engine_tipes, fuel_systems ON cars.make = makes.id AND cars.tipe_dog = tipes_dog.id AND " +
                "cars.category_dog = categories_dog.id AND cars.fuel_tipe = fuel_tipes.id AND cars.body_style = body_styles.id AND cars.drive_wheel " +
                "= drive_wheels.id AND cars.transmission = transmissions.id AND cars.engine_tipe = engine_tipes.id AND cars.fuel_system = fuel_systems.id";

            string path = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName;
           
            using (var connection = new SqliteConnection($"Data Source={path}\\DataBase\\Auto.db"))
            {           
                connection.Open();

                string CommandText = @"SELECT images.image1, images.name1, images.format1, images.image2, images.name2, 
                    images.format2, images.image3, images.name3, images.format3 , images.image4, images.name4, images.format4 FROM cars 
                    INNER JOIN images ON cars.image = images.id"; // выборка записей с заполненной ячейкой формата изображения, можно другой запрос составить
                var mainPhotos = new List<byte[]>();
                var cardPhotos = new List<byte[]>();
                var frontPhotos = new List<byte[]>();
                var backPhotos = new List<byte[]>();

                var command = new SqliteCommand(CommandText, connection);
                using (SqliteDataReader sqlReader = command.ExecuteReader())
                {
                    while (sqlReader.Read()) // считываем и вносим в лист все параметры
                    {
                        var mainPhoto = (byte[])sqlReader["image1"]; // читаем строки с изображениями, которые хранятся в байтовом формате               
                        var frontPhoto = (byte[])sqlReader["image2"]; // читаем строки с изображениями, которые хранятся в байтовом формате
                        var backPhoto = (byte[])sqlReader["image3"]; // читаем строки с изображениями, которые хранятся в байтовом формате
                        var cardPhoto = (byte[])sqlReader["image4"]; // читаем строки с изображениями, которые хранятся в байтовом формате
                        mainPhotos.Add(mainPhoto);
                        cardPhotos.Add(cardPhoto);
                        frontPhotos.Add(frontPhoto);
                        backPhotos.Add(backPhoto);
                    }
                }

                command = new SqliteCommand(SqlExpression, connection);
              
                using (SqliteDataReader reader = command.ExecuteReader())
                {                
                    if (reader.HasRows) // если есть данные
                    {
                        int index = 0;
                        while (reader.Read())   // построчно считываем данные
                        {
                            var car = new Car
                            {
                                Mark = (string)reader.GetValue(1),
                                Model = (string)reader.GetValue(2),
                                Color = (string)reader.GetValue(3),
                                TypeOfCar = (string)reader.GetValue(4),
                                Category = Convert.ToChar(reader.GetValue(5)),
                                RegistrationNumber = (string)reader.GetValue(6),
                                IssueYear = Convert.ToInt32(reader.GetValue(7)),
                                FuelType = (string)reader.GetValue(8),
                                AmountOfDoors = Convert.ToInt32(reader.GetValue(9)),
                                BodyShape = (string)reader.GetValue(10),
                                DriveWheel = (string)reader.GetValue(11),
                                Transmission = (string)reader.GetValue(12),
                                EngineType = (string)reader.GetValue(13),
                                AmountOfCilinders = (string)reader.GetValue(14),
                                FuelSystem = (string)reader.GetValue(15),
                                EnginePower = Convert.ToInt32(reader.GetValue(16)),
                                CityMPG = (string)reader.GetValue(17),
                                OffRoadMPG = (string)reader.GetValue(18),
                                Price = Convert.ToInt32(reader.GetValue(19)),
                                Amount = Convert.ToInt32(reader.GetValue(20)),
                                Photos = new CarPhotos
                                {
                                    MainPhoto = mainPhotos[index],
                                    FrontPhoto = frontPhotos[index],
                                    BackPhoto = backPhotos[index],
                                    CardPhoto = cardPhotos[index]
                                }
                            };
                            cars.Add(car);
                            index++;
                        }
                    }               
                }             
                connection.Close();
            }
         
            CarRegister = new ObservableCollection<Car>(cars);
            SelectedCar = cars.First();
        }
    }
}
