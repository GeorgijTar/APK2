using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace APK2.ViewModel.Base
{
    public abstract class BaseViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string PropertyName=null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(PropertyName));

        }

        protected virtual bool Set<T> (ref T fild, T value, [CallerMemberName] string PropertyName = null) 
        {
            if (Equals(fild, value)) return false;
            fild = value;
            OnPropertyChanged(PropertyName);
            return true;
        }
    }
}
