using APK2.Entitys;
using APK2.Interfaces;
using APK2.ViewModel.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APK2.ViewModel
{
  public  class InvoceViewModel:BaseViewModel
    {
      
        private  Counterparty counterparty;
        public Counterparty Counterparty {
            get => counterparty;

            set {
                SetProperty(ref counterparty, value);
                if (Counterparty.Name.Length > 3) {
                    
                }
            }
        }
    }
}
