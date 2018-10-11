using BPS.Core.Contracts.Services.General;
using BPS.Core.ViewModels;
using BethanysPieShop.Mobile.Test.Mocks;
using Moq;
using System.Threading.Tasks;
using Xunit;

namespace BethanysPieShop.Mobile.Test.ViewModel
{
    public class HomeViewModelTest
    {
        [Fact]
        public async Task PiesOfTheWeek_Not_Null_After_InitializeAsync_Test()
        {
            var mockConnectionService = new Mock<IConnectionService>();
            var mockNavigationService = new Mock<INavigationService>();
            var mockDialogService = new Mock<IDialogService>();
            var mockCatalogDataService = new MockCatalogDataService();

            var homeViewModel = new HomeViewModel(
                mockConnectionService.Object,
                mockNavigationService.Object,
                mockDialogService.Object,
                mockCatalogDataService);

            await homeViewModel.InitializeAsync(null);

            Assert.NotNull(homeViewModel.PiesOfTheWeek);
        }

        [Fact]
        public async Task PiesOfTheWeek_All_Get_Loaded_After_InitializeAsync_Test()
        {
            var mockConnectionService = new Mock<IConnectionService>();
            var mockNavigationService = new Mock<INavigationService>();
            var mockDialogService = new Mock<IDialogService>();
            var mockCatalogDataService = new MockCatalogDataService();

            var homeViewModel = new HomeViewModel(
                 mockConnectionService.Object,
                 mockNavigationService.Object,
                 mockDialogService.Object,
                 mockCatalogDataService);
            await homeViewModel.InitializeAsync(null);

            Assert.Equal(3, homeViewModel.PiesOfTheWeek.Count);
        }

        [Fact]
        public void AddToCartCommand_Not_Null_Test()
        {
            var mockConnectionService = new Mock<IConnectionService>();
            var mockNavigationService = new Mock<INavigationService>();
            var mockDialogService = new Mock<IDialogService>();
            var mockCatalogDataService = new MockCatalogDataService();

            var homeViewModel = new HomeViewModel(
                 mockConnectionService.Object,
                 mockNavigationService.Object,
                 mockDialogService.Object,
                 mockCatalogDataService);
            Assert.NotNull(homeViewModel.AddToCartCommand);
        }

        [Fact]
        public void PieTappedCommand_Not_Null_Test()
        {
            var mockConnectionService = new Mock<IConnectionService>();
            var mockNavigationService = new Mock<INavigationService>();
            var mockDialogService = new Mock<IDialogService>();
            var mockCatalogDataService = new MockCatalogDataService();

            var homeViewModel = new HomeViewModel(mockConnectionService.Object, mockNavigationService.Object, mockDialogService.Object, mockCatalogDataService);

            Assert.NotNull(homeViewModel.PieTappedCommand);
        }
    }
}
