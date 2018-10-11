using System.Threading.Tasks;
using BPS.Core.Contracts.Services.General;
using BPS.Core.ViewModels.Base;

namespace BPS.Core.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        private MenuViewModel _menuViewModel;

        public MainViewModel(IConnectionService connectionService, 
            INavigationService navigationService, IDialogService dialogService, 
            MenuViewModel menuViewModel) 
            : base(connectionService, navigationService, dialogService)
        {
            _menuViewModel = menuViewModel;
        }

        public MenuViewModel MenuViewModel
        {
            get => _menuViewModel;
            set
            {
                _menuViewModel = value;
                OnPropertyChanged();
            }
        }

        public override async Task InitializeAsync(object data)
        {
            await Task.WhenAll
            (
                _menuViewModel.InitializeAsync(data),
                _navigationService.NavigateToAsync<HomeViewModel>()
            );
        }
    }
}