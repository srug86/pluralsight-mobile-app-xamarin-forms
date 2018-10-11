using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using BPS.Core.Contracts.Services.Data;
using BPS.Core.Contracts.Services.General;
using BPS.Core.Extensions;
using BPS.Core.Models;
using BPS.Core.ViewModels.Base;
using Xamarin.Forms;

namespace BPS.Core.ViewModels
{
    public class PieCatalogViewModel : ViewModelBase
    {
        private readonly ICatalogDataService _catalogDataService;

        private ObservableCollection<Pie> _pies;

        public PieCatalogViewModel(IConnectionService connectionService,
            INavigationService navigationService, IDialogService dialogService,
            ICatalogDataService catalogDataService)
            : base(connectionService, navigationService, dialogService)
        {
            _catalogDataService = catalogDataService;
        }

        public ICommand PieTappedCommand => new Command<Pie>(OnPieTapped);

        public ObservableCollection<Pie> Pies
        {
            get => _pies;
            set
            {
                _pies = value;
                OnPropertyChanged();
            }
        }
 
        private void OnPieTapped(Pie selectedPie)
        {
            _navigationService.NavigateToAsync<PieDetailViewModel>(selectedPie);
        }

        public override async Task InitializeAsync(object data)
        {
            IsBusy = true;

            Pies = (await _catalogDataService.GetAllPiesAsync()).ToObservableCollection();

            IsBusy = false;
        }
    }
}
