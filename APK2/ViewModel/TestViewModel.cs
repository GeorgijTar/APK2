using APK2.Command.Base;
using APK2.Entitys;
using APK2.Interfaces;
using APK2.View;
using APK2.ViewModel.Base;
using System;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace APK2.ViewModel
{
    public class TestViewModel : BaseViewModel
    {

        private readonly IRepository<Invoce> invoce;

        public Invoce Invoce { get; set; }

        public Counterparty Counterparty { get; set; }


        #region Команды

        private TestSpravochikCounter testSpr;
        private ICommand openSpr;
        public ICommand OpenSpr => openSpr
           ??= new DelegateCommand(OnOpenAccountView);

        private void OnOpenAccountView(object p)
        {
            testSpr = new();
            testSpr.ShowDialog();

        }
        #endregion

    }
}
