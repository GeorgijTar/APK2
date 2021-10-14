using APK2.Command.Base;
using APK2.Entitys;
using APK2.Entitys.Base;
using APK2.Interfaces;
using APK2.ViewModel.Base;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace APK2.ViewModel
{
    public class TestSpravochikCounterViewModel : BaseViewModel
    {

        private readonly IRepository<Counterparty> counterparty;
        private readonly IRepository<Account> account;

        public TestSpravochikCounterViewModel(IRepository<Counterparty> counterpartys, IRepository<Account> account, IRepository<Status> status)
        {
            this.counterparty = counterpartys;
            this.account = account;
            this.status = status;
            LoadData();
        }

        public TestSpravochikCounterViewModel()
        {
        }

        public ObservableCollection<Counterparty> Counterpartys { get; } = new();
        public ObservableCollection<Account> Account { get; } = new();

        private readonly IRepository<Status> status;


        public List<Status> Status { get; set; }

        private void LoadData()
        {
            Load(Counterpartys, counterparty);
            Load(Account, account);

        }

        private static void Load<T>(ObservableCollection<T> collection, IRepository<T> rep) where T : BaseEntity
        {
            collection.Clear();
            foreach (var item in rep.GetAll())
                collection.Add(item);
        }

        private Counterparty selectedCounterparty;

        /// <summary>Выбранный элемент</summary>
        public Counterparty SelectedCounterparty {
            get => selectedCounterparty;
            set {
                SetProperty(ref selectedCounterparty, value);
            }
        }

        private Account selectedAccount;

        /// <summary>Выбранный элемент</summary>
        public Account SelectedAccount {
            get => selectedAccount;
            set {
                SetProperty(ref selectedAccount, value);
            }
        }


        private Counterparty itemCounterparty;

        public Counterparty ItemCounterparty {
            get => itemCounterparty;
            set {
                SetProperty(ref itemCounterparty, value);
            }
        }


        private ICommand selectCommand;
        public ICommand SelectCommand => selectCommand
           ??= new DelegateCommand(OnOpenAccountView);

        private void OnOpenAccountView(object p)
        {
            ViewModelLocator.Instance.TestViewModel.Counterparty = SelectedCounterparty;
        }
    }


}
