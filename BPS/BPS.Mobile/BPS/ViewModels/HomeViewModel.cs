﻿using BPS.Core.Contracts.Services.Data;
using BPS.Core.Contracts.Services.General;
using BPS.Core.Models;
using BPS.Core.ViewModels.Base;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using BPS.Core.Constants;
using BPS.Core.Extensions;
using Xamarin.Forms;

namespace BPS.Core.ViewModels
{
    public class HomeViewModel : ViewModelBase
    {
        private readonly ICatalogDataService _catalogDataService;
        private ObservableCollection<Pie> _piesOfTheWeek;

        public HomeViewModel(IConnectionService connectionService,
            INavigationService navigationService,
            IDialogService dialogService,
            ICatalogDataService catalogDataService) : base(connectionService, navigationService, dialogService)
        {
            _catalogDataService = catalogDataService;

            PiesOfTheWeek = new ObservableCollection<Pie>();
        }

        public ICommand PieTappedCommand => new Command<Pie>(OnPieTapped);
        public ICommand AddToCartCommand => new Command<Pie>(OnAddToCart);

        public ObservableCollection<Pie> PiesOfTheWeek
        {
            get => _piesOfTheWeek;
            set
            {
                _piesOfTheWeek = value;
                OnPropertyChanged();
            }
        }

        public override async Task InitializeAsync(object data)
        {
            PiesOfTheWeek = (await _catalogDataService.GetPiesOfTheWeekAsync()).ToObservableCollection();
        }

        private void OnPieTapped(Pie selectedPie)
        {
            _navigationService.NavigateToAsync<PieDetailViewModel>(selectedPie);
        }

        private async void OnAddToCart(Pie selectedPie)
        {
            MessagingCenter.Send(this, MessagingConstants.AddPieToBasket, selectedPie);
            await _dialogService.ShowDialog("Pie added to your cart", "Success", "OK");
        }
    }
}