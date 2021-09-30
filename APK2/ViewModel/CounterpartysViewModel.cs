using APK2.Command.Base;
using APK2.Entitys;
using APK2.Entitys.Base;
using APK2.Interfaces;
using APK2.View;
using APK2.ViewModel.Base;
using Dadata;
using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Net;
using System.Windows.Input;
using Newtonsoft.Json.Linq;
using static System.Net.Mime.MediaTypeNames;
using System.Collections.Generic;

namespace APK2.ViewModel
{
    public class CounterpartysViewModel : BaseViewModel
    {
        private readonly IRepository<Counterparty> counterpartys;
        private readonly IRepository<Account> account;

        public CounterpartysViewModel(IRepository<Counterparty> counterpartys, IRepository<Account> account, IRepository<Status> status)
        {
            this.counterpartys = counterpartys;
            this.account = account;
            this.status = status;
            LoadData();
        }
        public ObservableCollection<Counterparty> Counterparty { get; } = new();
        public ObservableCollection<Account> Account { get; } = new();

        private readonly IRepository<Status> status;

        
        public List<Status> Status { get; set; }

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


        private Counterparty itemCounterparty;

        public Counterparty ItemCounterparty {
            get => itemCounterparty;
            set {
                Set(ref itemCounterparty, value);
            }
        }




        #region Команды
        #region Команды CounterpartysView
        #region Команда обновления списка Контрагентов
        private ICommand updateCounterparty;
        public ICommand UpdateCounterparty => updateCounterparty
       ??= new DelegateCommand(OnUpdateCounterparty);

        private void OnUpdateCounterparty(object p)
        {
            LoadData();
        }
        #endregion
        #region Вызов окна добавления Контрагента
        private CounterpartyView counterpartyView;
        private ICommand openVindowAdd;

        public ICommand OpenVindowAdd => openVindowAdd
            ??= new DelegateCommand(OnOpenVindowAdd);

        private void OnOpenVindowAdd(object p)
        {
            ItemCounterparty = new Counterparty {
                Guid = Guid.NewGuid(),
                Status = new Status { Id = 12, Name = "Актуально" },
                TimeSpan = DateTime.Now
            };           
            counterpartyView = new CounterpartyView();
            counterpartyView.ShowDialog();
        }
        #endregion
        #region Вызов окна редактирования Контрагента
        private ICommand openVindowEdite;

        public ICommand OpenVindowEdite => openVindowEdite
            ??= new DelegateCommand(OnOpenVindowEdite, CanOpenVindowEdite);
        private bool CanOpenVindowEdite(object p) => SelectedCounterparty != null;

        private void OnOpenVindowEdite(object p)
        {
            ItemCounterparty = SelectedCounterparty;
            counterpartyView = new CounterpartyView();
            counterpartyView.ShowDialog();
        }
        #endregion
        #region Удаление контрагента
        private ICommand deleteCounterparty;
        public ICommand DeleteCounterparty => deleteCounterparty
            ??= new DelegateCommand(OnDeleteCounterparty, CanOpenVindowEdite);

        private void OnDeleteCounterparty(object p)
        {           
            SelectedCounterparty.Status = new Status { Id = 3, Name = "Удален" };
            counterpartys.Update(SelectedCounterparty);             
        }
        #endregion
       
        #region Команда добавление/изменение Котрагента

        private ICommand addUpdateClose;
        public ICommand AddUpdateClose => addUpdateClose
           ??= new DelegateCommand(OnCanAddCounterpartyClose, CanAddCounterparty);

        private bool CanAddCounterparty(object p)
        {
            if (ItemCounterparty == null) {
                return false;
            }
            else {
                return ItemCounterparty.Name
                    != null;
            }       
        }

        private void OnCanAddCounterpartyClose(object p)
        {
            if (ItemCounterparty.Id != 0) {
                counterpartys.Update(ItemCounterparty);
                counterpartyView.Close();
            }
            else {
                counterpartys.Add(ItemCounterparty);
                counterpartyView.Close();
            }
            LoadData();
            SelectedCounterparty = ItemCounterparty;
        }


        private ICommand addUpdate;
        public ICommand AddUpdate => addUpdate
           ??= new DelegateCommand(OnCanAddCounterparty, CanAddCounterparty);

        private void OnCanAddCounterparty(object p)
        {
            if (ItemCounterparty.Id != 0) {
                counterpartys.Update(ItemCounterparty);
            }
            else {
                counterpartys.Add(SelectedCounterparty);
            }
            LoadData();
            SelectedCounterparty = ItemCounterparty;
        }
        #endregion
        #endregion
        #region Коменды AccountView
        private AccountView accountView;
        #region Команда вызова акна добавления новых банковских реквезитов Контрагента
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
        private void OnOpenAccountView(object p)
        {
            SelectedAccount = new();
            SelectedAccount.Guid = Guid.NewGuid();
            SelectedAccount.Status= new Status { Id = 0, Name = "Новый" };
            SelectedAccount.Counterparty = selectedCounterparty;
            accountView = new AccountView();
            accountView.ShowDialog();

        }
        #endregion
        #region Команда вызова окна редактирования банковских реквизитов Контрагента
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
        #endregion
        #region Команда удаления акаунта
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
            SelectedAccount.Status = new() { Id = 3, Name = "Удален" };            
            account.Update(SelectedAccount);
        }
        #endregion
        #region Команда заполнить по БИК

        private ICommand getBank;
        public ICommand GetBank => getBank
           ??= new DelegateCommand(OnGetBank, CanGetBank);

        private bool CanGetBank(object p)
        {
            if (SelectedAccount == null) {
                return false;
            }
            else if (SelectedAccount.BIK == null) {
              return false;
            }
            else {
                return SelectedAccount.BIK.Length == 9;
            }
        }
        private void OnGetBank(object p)
        {
            var request = WebRequest.Create(@"http://www.bik-info.ru/api.html?type=json&bik=" + SelectedAccount.BIK);
            var response = request.GetResponse();
            var dataStream = response.GetResponseStream();
            StreamReader reader = new(dataStream);
            var responseFromServer = reader.ReadToEnd();
            var resalt = JObject.Parse(responseFromServer);
            SelectedAccount.KorShet = resalt.SelectToken("ks").ToString();
            SelectedAccount.NameBank = resalt.SelectToken("name").ToString().Replace("&quot;", "");
        }

      
        #endregion

        #endregion

        #endregion
    }
}
