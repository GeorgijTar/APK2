using APK2.Command.Base;
using APK2.Entitys;
using APK2.Interfaces;
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
    public class TestViewModel : BaseViewModel
    {

        private IRepository<Invoce> invoces;
        private Invoce invoce;

        public TestViewModel(IRepository<Invoce> invoces)
        {
            this.invoces = invoces;
        }

        public IRepository<Invoce> Invoces {
            get => invoces;

            set { Set(ref invoces, value); }
        }


        public Invoce Invoce {
            get => invoce;

            set { Set(ref invoce, value); }
        }



        private TestSpravochikCounter spravochikCounter;
        private ICommand openSpr;        

        public ICommand OpenSpr => openSpr
       ??= new DelegateCommand(OnOpenSpr);

        private void OnOpenSpr(object p)
        {
            TestInvose testInvose = new();

            spravochikCounter = new();            
            spravochikCounter.ShowDialog();
        }


    }
}
