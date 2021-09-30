using APK2.Command.Base;
using APK2.View;
using APK2.ViewModel.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace APK2.ViewModel
{
  public  class InvoicesViewModel: BaseViewModel
    {
        #region Команды
        private InvoceView invoceView;
        private ICommand openInvoceView;
        public ICommand OpenInvoceView => openInvoceView
           ??= new DelegateCommand(OnOpenInvoceView);

        private void OnOpenInvoceView(object p)
        {
            invoceView = new ();
            invoceView.ShowDialog();

        }


        #endregion

    }
}
