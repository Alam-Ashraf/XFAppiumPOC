using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace XFAppiumPOC
{
    public partial class MainPage : ContentPage, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private List<string> _deviceTypes = new List<string>() { "RPOC","EDGE I", "Item 1" };
        public List<string> DeviceTypes
        {
            get => _deviceTypes;
            set
            {
                _deviceTypes = value;
                OnPropertyChanged();
            }
        }

        private bool isDeviceTypeOpen;

        public bool IsDeviceTypeOpen
        {
            get => isDeviceTypeOpen;
            set
            {
                isDeviceTypeOpen = value;
                OnPropertyChanged();
            }
        }

        private string _deviceTypeSelected;

        public string DeviceTypeSelected
        {
            get => _deviceTypeSelected;
            set
            {
                _deviceTypeSelected = value;
                OnPropertyChanged();
            }
        }

        public void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public MainPage()
        {
            InitializeComponent();

            BindingContext = this;

            //DeviceTypeSelected = "Japanese Macaque";
        }

        private async void LoginButton_Clicked(object sender, EventArgs e)
        {
            StatusLabel.Text = "Logging in " + DateTime.Now.ToString("HH:mm:ss");

            await Task.Delay(2000);

            await Navigation.PushAsync(new HomePage());
        }
    }
}

