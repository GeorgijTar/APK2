using APK2.Entitys;
using APK2.Entitys.Base;
using APK2.Interfaces;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APK2.ViewModel
{
   public class IndividualsViewModel:Base.BaseViewModel
    {
        private readonly IRepository<Individual> individual;

        public IndividualsViewModel(IRepository<Individual> individual)
        {
            this.individual = individual;
            LoadData();
        }

        public ObservableCollection<Individual> Individual { get; } = new();

        private void LoadData()
        {
            Load(Individual, individual);
        }

        private static void Load<T>(ObservableCollection<T> collection, IRepository<T> rep) where T : BaseEntity
        {
            collection.Clear();
            foreach (var item in rep.GetAll())
                collection.Add(item);
        }

    }
}
