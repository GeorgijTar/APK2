using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APK2.ViewModel
{
    public class ViewModelLocator
    {

        public AutentificationViewModel AutentificationWindowModel {
            get {
                var model = App.Services.GetRequiredService<AutentificationViewModel>();
                return model;
            }
        }
               
        public StatusesViewModel StatusViewModel {
            get {
                var model = App.Services.GetRequiredService<StatusesViewModel>();
                return model;
            }
        }


        public CounterpartysViewModel CounterpartysViewModel {
            get {
                var model = App.Services.GetRequiredService<CounterpartysViewModel>();
                return model;
            }
        }

    }
}
