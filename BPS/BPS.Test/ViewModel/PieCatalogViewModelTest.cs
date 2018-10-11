using BPS.Core.Contracts.Services.General;
using BPS.Core.ViewModels;
using BethanysPieShop.Mobile.Test.Mocks;
using Moq;
using System.Threading.Tasks;
using Xunit;

namespace BethanysPieShop.Mobile.Test.ViewModel
{
    public class PieCatalogViewModelTest
    {
        public PieCatalogViewModelTest()
        {

        }

        [Fact]
        public async Task Pies_Not_Null_After_InitializeAsync_Test()
        {
            var mockConnectionService = new Mock<IConnectionService>();
            var mockNavigationService = new Mock<INavigationService>();
            var mockDialogService = new Mock<IDialogService>();
            var mockCatalogDataService = new MockCatalogDataService();

            var pieCatalogViewModel = 
                new PieCatalogViewModel(
                    mockConnectionService.Object, 
                    mockNavigationService.Object, 
                    mockDialogService.Object, 
                    mockCatalogDataService);

            await pieCatalogViewModel.InitializeAsync(null);

            Assert.NotNull(pieCatalogViewModel.Pies);
        }

        [Fact]
        public async Task Pies_All_Get_Loaded_After_InitializeAsync_Test()
        {
            var mockConnectionService = new Mock<IConnectionService>();
            var mockNavigationService = new Mock<INavigationService>();
            var mockDialogService = new Mock<IDialogService>();
            var mockCatalogDataService = new MockCatalogDataService();

            var pieCatalogViewModel =
                new PieCatalogViewModel(
                    mockConnectionService.Object,
                    mockNavigationService.Object,
                    mockDialogService.Object,
                    mockCatalogDataService);
            await pieCatalogViewModel.InitializeAsync(null);

            Assert.Equal(10, pieCatalogViewModel.Pies.Count);
        }

        [Fact]
        public void PieTappedCommand_Not_Null_Test()
        {
            var mockConnectionService = new Mock<IConnectionService>();
            var mockNavigationService = new Mock<INavigationService>();
            var mockDialogService = new Mock<IDialogService>();
            var mockCatalogDataService = new MockCatalogDataService();

            var pieCatalogViewModel =
                new PieCatalogViewModel(
                    mockConnectionService.Object,
                    mockNavigationService.Object,
                    mockDialogService.Object,
                    mockCatalogDataService);

            Assert.NotNull(pieCatalogViewModel.PieTappedCommand);
        }
    }
}
