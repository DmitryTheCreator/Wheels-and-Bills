using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Microsoft.Data.Sqlite;

namespace Wheels_and_Bills.Services
{
    internal class DataService
    {
        //private void Update_Table()
        //{
        //    string SqlExpression = "SELECT cars.id, makes.make, cars.model, cars.color, tipes_dog.tipe_dog, categories_dog.category_dog, cars.reg_znak, cars.year_dog, fuel_tipes.fuel_tipe, cars.doors_num, body_styles.body_style, drive_wheels.drive_wheel, transmissions.transmission, engine_tipes.engine_tipe, cars.cylinders_num, fuel_systems.fuel_system, cars.horsepower, cars.city_mpg, cars.highway_mpg, cars.price, cars.count_cars FROM cars INNER JOIN makes, tipes_dog, categories_dog, fuel_tipes, body_styles, drive_wheels, transmissions, engine_tipes, fuel_systems ON cars.make = makes.id AND cars.tipe_dog = tipes_dog.id AND cars.category_dog = categories_dog.id AND cars.fuel_tipe = fuel_tipes.id AND cars.body_style = body_styles.id AND cars.drive_wheel = drive_wheels.id AND cars.transmission = transmissions.id AND cars.engine_tipe = engine_tipes.id AND cars.fuel_system = fuel_systems.id";
        //    //string SqlExpression = "SELECT* FROM cars";
        //    using (var connection = new SqliteConnection("Data Source=C:\\Users\\zamor\\Downloads\\Auto.db"))
        //    {
        //        connection.Open();

        //        SqliteCommand command = new SqliteCommand(SqlExpression, connection);

        //        using (SqliteDataReader reader = command.ExecuteReader())
        //        {
        //            if (reader.HasRows) // если есть данные
        //            {
        //                richTextBox1.Text = "";
        //                while (reader.Read())   // построчно считываем данные
        //                {
        //                    var id = reader.GetValue(0);
        //                    var make = reader.GetValue(1);
        //                    var model = reader.GetValue(2);
        //                    var color = reader.GetValue(3);
        //                    var tipe_dog = reader.GetValue(4);
        //                    var category_dog = reader.GetValue(5);
        //                    var reg_znak = reader.GetValue(6);
        //                    var year_dog = reader.GetValue(7);
        //                    var fuel_tipe = reader.GetValue(8);
        //                    var doors_num = reader.GetValue(9);
        //                    var body_style = reader.GetValue(10);
        //                    var drive_wheel = reader.GetValue(11);
        //                    var transmission = reader.GetValue(12);
        //                    var engine_tipe = reader.GetValue(13);
        //                    var cylinders_num = reader.GetValue(14);
        //                    var fuel_system = reader.GetValue(15);
        //                    var horsepower = reader.GetValue(16);
        //                    var city_mpg = reader.GetValue(17);
        //                    var highway_mpg = reader.GetValue(18);
        //                    var price = reader.GetValue(19);
        //                    var count_cars = reader.GetValue(20);

        //                    richTextBox1.Text += ($"{id} \t {make} \t {model} \t {color} \t {tipe_dog} \t {category_dog} \t {reg_znak} \t {year_dog} \t {fuel_tipe} \t {doors_num} \t {body_style} \t {drive_wheel} \t {transmission} \t {engine_tipe} \t {cylinders_num} \t {fuel_system} \t {horsepower} \t {city_mpg} \t {highway_mpg} \t {price} \t {count_cars}\n");
        //                    richTextBox1.Text += "--------------------------------------------------------------------------------------------------------------------------------------------\n";
        //                }
        //            }
        //        }
        //        connection.Close();
        //    }

        //    List<byte[]> _imageList = new List<byte[]>(); // изображение в байтах
        //    List<string> _imgFormatList = new List<string>(); // расширения изображений
        //    using (SqliteConnection Connect = new SqliteConnection(@"Data Source=C:\\Users\zamor\\Downloads\\Auto.db"))
        //    {
        //        Connect.Open();
        //        SqliteCommand Command = new SqliteCommand
        //        {
        //            Connection = Connect,
        //            CommandText = @"SELECT images.image1, images.name1, images.format1, images.image2, images.name2, images.format2, images.image3, images.name3, images.format3 , images.image4, images.name4, images.format4 FROM cars INNER JOIN images ON cars.image = images.id" // выборка записей с заполненной ячейкой формата изображения, можно другой запрос составить
        //        };
        //        SqliteDataReader SqlReader = Command.ExecuteReader();
        //        byte[] _dbImageByte = null;
        //        string _dbImageFormat = null;
        //        while (SqlReader.Read()) // считываем и вносим в лист все параметры
        //        {
        //            if ((Convert.ToInt32(comboBox12.SelectedItem) == 0) || (Convert.ToInt32(comboBox12.SelectedItem) == 1))
        //            {
        //                _dbImageByte = (byte[])SqlReader["image1"]; // читаем строки с изображениями, которые хранятся в байтовом формате
        //                _dbImageFormat = SqlReader["format1"].ToString().TrimStart().TrimEnd(); // читаем строки с форматом изображений
        //            }
        //            else if (Convert.ToInt32(comboBox12.SelectedItem) == 2)
        //            {
        //                _dbImageByte = (byte[])SqlReader["image2"]; // читаем строки с изображениями, которые хранятся в байтовом формате
        //                _dbImageFormat = SqlReader["format2"].ToString().TrimStart().TrimEnd(); // читаем строки с форматом изображений
        //            }
        //            else if (Convert.ToInt32(comboBox12.SelectedItem) == 3)
        //            {
        //                _dbImageByte = (byte[])SqlReader["image3"]; // читаем строки с изображениями, которые хранятся в байтовом формате
        //                _dbImageFormat = SqlReader["format3"].ToString().TrimStart().TrimEnd(); // читаем строки с форматом изображений
        //            }
        //            else if (Convert.ToInt32(comboBox12.SelectedItem) == 4)
        //            {
        //                _dbImageByte = (byte[])SqlReader["image4"]; // читаем строки с изображениями, которые хранятся в байтовом формате
        //                _dbImageFormat = SqlReader["format4"].ToString().TrimStart().TrimEnd(); // читаем строки с форматом изображений
        //            }
        //            _imageList.Add(_dbImageByte); // добавляем в List
        //            _imgFormatList.Add(_dbImageFormat); // добавляем в List
        //        }
        //        Connect.Close();
        //    }
        //    if (_imageList.Count == 0) // если в базе нет записей с изображениями (пустой список), то...
        //    {
        //        return; // завершить работу метода
        //    }
        //    // конвертируем бинарные данные в изображение
        //    byte[] _imageBytes;
        //    if (Convert.ToInt32(comboBox11.SelectedIndex) >= 0)
        //        _imageBytes = _imageList[Convert.ToInt32(comboBox11.SelectedIndex)]; // так как Sqlite вернёт список изображений из БД, то из листа берём первое с индексом '0'
        //    else
        //        _imageBytes = _imageList[0];
        //    MemoryStream ms = new MemoryStream(_imageBytes);
        //    Image _newImg = Image.FromStream(ms);
        //    pictureBox1.Image = _newImg;
        //}
    }
}
