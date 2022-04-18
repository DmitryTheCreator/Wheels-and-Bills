using System;
using System.Collections.Generic;
using System.Text;
using Wheels_and_Bills.Views;
using Wheels_and_Bills.Infrastructure.Commands.Base;

namespace Wheels_and_Bills.Infrastructure.Commands
{
    internal class OpenFiltersCommand : CommandBase
    {
        public override bool CanExecute(object parameter) => true;

        public override void Execute(object parameter)
        {
            FiltersView filtersView = new FiltersView();
            filtersView.ShowDialog();
        }
    }
}
