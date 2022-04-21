using Wheels_and_Bills.Infrastructure.Commands.Base;
using Microsoft.Data.Sqlite;
using Wheels_and_Bills.Views.Windows;
using System;
using System.IO;

namespace Wheels_and_Bills.Infrastructure.Commands
{
    internal class RegistrCommand : CommandBase
    {
        public override bool CanExecute(object parameter) => true;

        public override void Execute(object parameter)
        {
            bool auth = false;
            var values = (object[])parameter;
            var surname = (string)values[0];
            var name = (string)values[1];
            var patronymic = (string)values[2];
            var date = (string)values[3];
            var passport_series = (string)values[4];
            var passport_number = (string)values[5];
            var e_mail = (string)values[6];
            var phone_number = (string)values[7];
            var password = (string)values[8];

            if (surname == "" || name == "" || patronymic == "" || date == "" ||
                passport_series == "" || passport_number == "" || e_mail == "" ||
                password == "")
                return;

            string path = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName;
            using (var connection = new SqliteConnection($"Data Source={path}\\DataBase\\Auto.db"))
            {
                connection.Open();
                SqliteCommand command = connection.CreateCommand();
                command.CommandText = "INSERT INTO workers (fam, im, otch, burth_date, pasport_seria, pasport_num, " +
                    "mail, phone_number,  password) VALUES (@fam, @im, @otch, @burth_date, @pasport_seria, @pasport_num, " +
                    "@mail, @phone_number, @password)";
                command.Parameters.AddWithValue("@fam", surname);
                command.Parameters.AddWithValue("@im", name);
                command.Parameters.AddWithValue("@otch", patronymic);
                command.Parameters.AddWithValue("@burth_date", date);
                command.Parameters.AddWithValue("@pasport_seria", passport_series);
                command.Parameters.AddWithValue("@pasport_num", passport_number);
                command.Parameters.AddWithValue("@mail", e_mail);
                command.Parameters.AddWithValue("@phone_number", phone_number);
                command.Parameters.AddWithValue("@password", password);
                command.ExecuteNonQuery();
                connection.Close();
            }
            AuthorizationWindow mainwindow = new AuthorizationWindow();            
            mainwindow.ShowDialog();
          
        }
    }
}
