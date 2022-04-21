using Wheels_and_Bills.Views.Windows;
using Wheels_and_Bills.Infrastructure.Commands.Base;

namespace Wheels_and_Bills.Infrastructure.Commands
{
    internal class OpenContractCommand : CommandBase
    {
        public override bool CanExecute(object parameter) => true;

        public override void Execute(object parameter)
        {
            ContractWindow contractView = new ContractWindow();
            contractView.ShowDialog();
        }
    }
}
