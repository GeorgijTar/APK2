using APK2.Entitys;
using APK2.ViewModel.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APK2.Interfaces
{
  public  class TestInvose:BaseViewModel
    {
        private Invoce invoce;

        public Invoce Invoce {
            get => invoce;

            set { Set(ref invoce, value); }
        }

        private Counterparty counterparty;

        public Counterparty Counterparty {
            get => counterparty;

            set { Set(ref counterparty, value); }
        }



    }
}
