using Wheels_and_Bills.Views.Windows;
using Wheels_and_Bills.Infrastructure.Commands.Base;

namespace Wheels_and_Bills.Infrastructure.Commands 
{
    internal class OpenRegistrationCommand : CommandBase
    {
        public override bool CanExecute(object parameter) => true;

        public override void Execute(object parameter)
        {
            RegistrationWindow registrationView = new RegistrationWindow();
            registrationView.ShowDialog();
        }
    }
}
