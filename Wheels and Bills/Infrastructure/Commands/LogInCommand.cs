using Wheels_and_Bills.Views.Windows;
using Wheels_and_Bills.Infrastructure.Commands.Base;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Microsoft.Data.Sqlite;
using System;
using System.IO;

namespace Wheels_and_Bills.Infrastructure.Commands
{
    internal class LogInCommand : CommandBase
    {
        public override bool CanExecute(object parameter) => true;

        public override void Execute(object parameter)
        {
            bool auth = false;
            var values = (object[])parameter;
            var login = (string)values[0];
            var password = (string)values[1];
            string path = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName;
            using (var connection = new SqliteConnection($"Data Source={path}\\DataBase\\Auto.db"))
            {
                connection.Open();
                SqliteCommand command = connection.CreateCommand();
                command.CommandText = "SELECT COUNT(*) FROM workers WHERE  id = @id and password = @pass";
                command.Parameters.AddWithValue("@id", login);
                command.Parameters.AddWithValue("@pass", password);
                auth = Convert.ToBoolean(command.ExecuteScalar());
                connection.Close();
            }
            if (!auth) return;
            MainWindow mainwindow = new MainWindow();
            mainwindow.ShowDialog();
        }
    }
}
