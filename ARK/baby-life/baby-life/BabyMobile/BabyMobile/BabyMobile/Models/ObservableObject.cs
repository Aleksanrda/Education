using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace BabyMobile.Models
{
    public class ObservableObject : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            var handler = this.PropertyChanged;

            if (handler != null)
            {
                handler?.Invoke(this, new PropertyChangedEventArgs(prop));
            }
        }
    }
}
