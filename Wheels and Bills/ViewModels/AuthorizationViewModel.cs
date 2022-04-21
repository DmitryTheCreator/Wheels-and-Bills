using System;
using System.Collections.Generic;
using System.Text;
using Wheels_and_Bills.ViewModels.Base;
using System.Collections.ObjectModel;
using System.Linq;
using Wheels_and_Bills.Models;
using Microsoft.Data.Sqlite;
using System.Windows.Input;
using System.IO;
using System.ComponentModel;
using System.Windows.Data;

namespace Wheels_and_Bills.ViewModels
{
    internal class AuthorizationViewModel : ViewModelBase
    {
        #region AuthorizationText : string - Логин

        private string _AuthorizationText;

        /// <summary>Текст фильтра автомобилей</summary>
        public string AuthorizationText
        {
            get => _AuthorizationText;
            set => Set(ref _AuthorizationText, value);
        }

        #endregion
    }
}
