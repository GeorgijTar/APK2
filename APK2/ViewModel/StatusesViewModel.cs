using APK2.Command.Base;
using APK2.Entitys;
using APK2.Entitys.Base;
using APK2.Interfaces;
using APK2.View;
using APK2.ViewModel.Base;
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
    public class StatusesViewModel :BaseViewModel

    {
       private readonly IRepository<BaseEntity> status;

        public StatusesViewModel(IRepository<BaseEntity> status)
        {
            this.status = status;
            LoadData();
        }

        public ObservableCollection<BaseEntity> Status { get; } = new();

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


        /// <summary>Выбранный элемент</summary>
        private Status selectedStatus;

        /// <summary>Выбранный элемент</summary>
        public Status SelectedStatus {
            get => selectedStatus;
            set {
                Set(ref selectedStatus, value);
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
            selectedStatus = new();           
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
            StatusesView = new StatusesView();
            StatusesView.ShowDialog();
        }
        #endregion

        #region добавление/изменение статуса

        private ICommand addUpdateStatus;
        public ICommand AddStatus => addUpdateStatus
           ??= new DelegateCommand(OnCanAddStatus, CanAddStatus);

        private bool CanAddStatus(object p)
        {  if (SelectedStatus != null) {

            return SelectedStatus.Name != null;
            }
        else {
                return false;
            }
            
        }

        private void OnCanAddStatus(object p)
        {
            if (SelectedStatus.Id != 0) {
                status.Update(SelectedStatus);
                StatusesView.Close();
            }
            else {               
                status.Add(SelectedStatus);
                StatusesView.Close();
                LoadData();
            }
        }
        #endregion
        #endregion

    }
}
