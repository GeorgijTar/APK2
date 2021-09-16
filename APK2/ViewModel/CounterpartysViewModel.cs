using APK2.Command.Base;
using APK2.Entitys;
using APK2.Entitys.Base;
using APK2.Interfaces;
using APK2.View;
using APK2.ViewModel.Base;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace APK2.ViewModel
{
    public class CounterpartysViewModel : BaseViewModel
    {
        private readonly IRepository<Counterparty> counterpartys;
        private readonly IRepository<Account> account;

        public CounterpartysViewModel(IRepository<Counterparty> counterpartys, IRepository<Account> account)
        {
            this.counterpartys = counterpartys;
            this.account = account;
            LoadData();
        }
        public ObservableCollection<Counterparty> Counterparty { get; } = new();
        public ObservableCollection<Account> Account { get; } = new();

        private void LoadData()
        {
            Load(Counterparty, counterpartys);
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
                Set(ref selectedCounterparty, value);
            }
        }

        private Account selectedAccount;

        /// <summary>Выбранный элемент</summary>
        public Account SelectedAccount {
            get => selectedAccount;
            set {
                Set(ref selectedAccount, value);
            }
        }

        #region Команды
        #region Команды CounterpartysView
        CounterpartyView counterpartyView;
        private ICommand openVindowAdd;

        public ICommand OpenVindowAdd => openVindowAdd
            ??= new DelegateCommand(OnOpenVindowAdd);

        private void OnOpenVindowAdd(object p)

        {
            selectedCounterparty = new();
            selectedCounterparty.Guid = new System.Guid();
            selectedCounterparty.Status = new Status { Id = 12, Name = "Актуально" };
            selectedCounterparty.TimeSpan = new System.TimeSpan();
            counterpartyView = new CounterpartyView();
            counterpartyView.ShowDialog();
        }

        private ICommand openVindowEdite;

        public ICommand OpenVindowEdite => openVindowEdite
            ??= new DelegateCommand(OnOpenVindowEdite, CanOpenVindowEdite);
        private bool CanOpenVindowEdite(object p) => SelectedCounterparty != null;

        private void OnOpenVindowEdite(object p)
        {
            counterpartyView = new CounterpartyView();
            counterpartyView.ShowDialog();
        }

        private ICommand deleteCounterparty;
        public ICommand DeleteCounterparty => deleteCounterparty
            ??= new DelegateCommand(OnDeleteCounterparty, CanOpenVindowEdite);

        private void OnDeleteCounterparty(object p)
        {
            counterpartys.Remove(SelectedCounterparty.Id);

        }
        #endregion

        #region добавление/изменение 

        private ICommand addUpdateClose;
        public ICommand AddUpdateClose => addUpdateClose
           ??= new DelegateCommand(OnCanAddCounterparty, CanAddCounterparty);

        private bool CanAddCounterparty(object p)
        {
            if (SelectedCounterparty == null) {
                return false;
            }
            else {

                return SelectedCounterparty.Name
                    != null;
            }

        }

        private void OnCanAddCounterpartyClose(object p)
        {
            if (SelectedCounterparty.Id != 0) {
                counterpartys.Update(SelectedCounterparty);
                counterpartyView.Close();
            }
            else {
                counterpartys.Add(SelectedCounterparty);
                counterpartyView.Close();

            }

        }


        private ICommand addUpdate;
        public ICommand AddUpdate => addUpdate
           ??= new DelegateCommand(OnCanAddCounterparty, CanAddCounterparty);

        private void OnCanAddCounterparty(object p)
        {
            if (SelectedCounterparty.Id != 0) {
                counterpartys.Update(SelectedCounterparty);
            }
            else {
                counterpartys.Add(SelectedCounterparty);

            }

        }
        #endregion
        #region Коменды AccountView
        private ICommand openAccountView;
        public ICommand OpenAccountView => openAccountView
           ??= new DelegateCommand(OnOpenAccountView, CanOpenAccountView);


        private bool CanOpenAccountView(object p)
        {
            if (SelectedCounterparty == null) {
                return false;
            }
            else {
                return SelectedCounterparty.Id > 0;
            }
        }

        AccountView accountView;
        private void OnOpenAccountView(object p)
        {
            selectedAccount = new();
            accountView = new AccountView();
            accountView.ShowDialog();

        }

        private ICommand editeAccount;
        public ICommand EditeAccount => editeAccount
           ??= new DelegateCommand(OnEditeAccount, CanEditeAccount);


        private bool CanEditeAccount(object p)
        {
            if (SelectedAccount == null) {
                return false;
            }
            else {
                return SelectedAccount.Id > 0;
            }
        }
        private void OnEditeAccount(object p)
        {            
            accountView = new AccountView();
            accountView.ShowDialog();
        }


        private ICommand deleteAccount;
        public ICommand DeleteAccount => deleteAccount
           ??= new DelegateCommand(OnDeleteAccount, CanDeleteAccount);


        private bool CanDeleteAccount(object p)
        {
            if (SelectedAccount == null) {
                return false;
            }
            else {
                return SelectedAccount.Id > 0;
            }
        }
        private void OnDeleteAccount(object p)
        {
            account.Remove(SelectedAccount.Id);
        }


        #endregion
        #endregion
    }
}
