namespace DCOM.WPF.MVVM.Tabs.Tests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Moq;
    using Tabs;

    [TestClass]
    public class MainViewModelTests
    {
        private Mock<Tab> mock;
        private MainWindowViewModel viewModel;

        [TestInitialize]
        public void TestInitialize()
        {
            mock = new Mock<Tab>();
            viewModel = new MainWindowViewModel();
        }

        [TestMethod]
        public void RemovesTab()
        {
            viewModel.Tabs.Add(mock.Object);

            mock.Object.CloseCommand.Execute(null);

            Assert.AreEqual(0, viewModel.Tabs.Count);
        }
    }
}