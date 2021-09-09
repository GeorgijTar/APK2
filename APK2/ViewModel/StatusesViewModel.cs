using APK2.Command.Base;
using APK2.Entitys;
using APK2.Entitys.Base;
using APK2.Interfaces;
using APK2.View;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace APK2.ViewModel
{
    public class StatusesViewModel : Base.BaseViewModel

    {
        private string nameStatus;

        public string NameStatus { get => nameStatus; set => Set(ref nameStatus, value); }


        private readonly IRepository<Status> status;

        public StatusesViewModel(IRepository<Status> status)
        {
            this.status = status;
            LoadData();
        }

        public ObservableCollection<Status> Status { get; } = new();

        private void LoadData()
        {
            Load(Status, status);
        }

        private static void Load<T>(ObservableCollection<T> collection, IRepository<T> rep) where T : BaseEntity
        {
            collection.Clear();
            foreach (var item in rep.GetAll())
                collection.Add(item);
        }


        /// <summary>Выбранный получатель</summary>
        private Status _SelectedStatus;

        /// <summary>Выбранный получатель</summary>
        public Status SelectedStatus {
            get => _SelectedStatus;
            set {
                Set(ref _SelectedStatus, value);
                nameStatus = _SelectedStatus.Name;
            }
        }


        #region Команды
        StatusesView StatusesView;
        #region Открытие окна добавления статуса
        private ICommand openVindowAdd;

        public ICommand OpenVindowAdd => openVindowAdd
            ??= new DelegateCommand(OnOpenVindowAdd, CanOpenVindowAdd);
        private bool CanOpenVindowAdd(object p) => true;
        private int statAdd=0; 
        private void OnOpenVindowAdd(object p)

        {
            statAdd = 1;
            NameStatus = "";
            StatusesView = new StatusesView();
            StatusesView.ShowDialog();
        }
        #endregion

        #region Открытие окна редоктирования статуса

        private ICommand openVindowEdite;

        public ICommand OpenVindowEdite => openVindowEdite
            ??= new DelegateCommand(OnOpenVindowEdite, CanOpenVindowEdite);
        private bool CanOpenVindowEdite(object p) => SelectedStatus != null;

        private void OnOpenVindowEdite(object p)
        {
            statAdd = 0;
            StatusesView = new StatusesView();
            StatusesView.ShowDialog();
        }
        #endregion

        #region добавление/изменение статуса

        private ICommand addUpdateStatus;
        public ICommand AddStatus => addUpdateStatus
           ??= new DelegateCommand(OnCanAddStatus, CanAddStatus);

        private bool CanAddStatus(object p) => NameStatus.Length > 3;

        private void OnCanAddStatus(object p)

        {
            if (statAdd ==0) {
                SelectedStatus.Name = NameStatus;
                status.Update(SelectedStatus);
                StatusesView.Close();
            }
            else {
                Status newStatus = new();
                newStatus.Name = NameStatus;
                status.Add(newStatus);
                StatusesView.Close();
            }
        }
        #endregion
        #endregion

    }
}
