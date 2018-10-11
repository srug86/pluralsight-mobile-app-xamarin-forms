using System.Threading.Tasks;
using System.Windows.Input;
using BPS.Core.Constants;
using BPS.Core.Contracts.Services.General;
using BPS.Core.Models;
using BPS.Core.ViewModels.Base;
using Xamarin.Forms;

namespace BPS.Core.ViewModels
{
    public class PieDetailViewModel: ViewModelBase
    {
        private Pie _selectedPie;

        public PieDetailViewModel(IConnectionService connectionService, 
            INavigationService navigationService, IDialogService dialogService) 
            : base(connectionService, navigationService, dialogService)
        { }

        public ICommand AddToCartCommand => new Command(OnAddToCart);
        public ICommand ReadDescriptionCommand => new Command(OnReadDescription);

        public Pie SelectedPie
        {
            get => _selectedPie;
            set
            {
                _selectedPie = value;
                OnPropertyChanged();
            }
        }

        public override async Task InitializeAsync(object pie)
        {
            SelectedPie = (Pie) pie;
        }

        private async void OnAddToCart()
        {
            MessagingCenter.Send(this, MessagingConstants.AddPieToBasket, SelectedPie);
            await _dialogService.ShowDialog("Pie added to your cart", "Success", "OK");
        }

        private void OnReadDescription()
        {
            DependencyService.Get<ITextToSpeech>().ReadText(SelectedPie.LongDescription);
        }
    }
}
