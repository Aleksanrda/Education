namespace BabyLifeMobile.Core.Models
{
    using System.ComponentModel;
    using System.Runtime.CompilerServices;

    public abstract class ObservableObject : INotifyPropertyChanged
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
