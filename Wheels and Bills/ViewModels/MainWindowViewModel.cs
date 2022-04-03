using Wheels_and_Bills.ViewModels.Base;

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
    }
}
