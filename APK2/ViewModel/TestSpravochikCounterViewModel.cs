using APK2.Entitys;
using APK2.Interfaces;
using APK2.ViewModel.Base;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APK2.ViewModel
{
  public  class TestSpravochikCounterViewModel: BaseViewModel
    {
        private IRepository<Counterparty> counter;
        private Invoce invoce;

       
        public TestSpravochikCounterViewModel(IRepository<Counterparty> counter)
        {
            this.counter = counter;
            Load();
        }

        public ObservableCollection<Counterparty> Counterpartys { get; } = new();

        private void Load()
        {
            Counterpartys.Clear();
            foreach (var item in counter.GetAll()) {
                Counterpartys.Add(item);
            }
        }

        private Counterparty selectedCounterparty;

        /// <summary>Выбранный элемент</summary>
        public Counterparty SelectedCounterparty {
            get => selectedCounterparty;
            set {
                Set(ref selectedCounterparty, value);
            }
        }

    }

}
