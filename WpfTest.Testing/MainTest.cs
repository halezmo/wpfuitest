using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TestStack.White.Factory;
using TestStack.White;
using TestStack.White.UIItems;
using System.Threading;

namespace WpfTest.Testing
{
    [TestClass]
    public class MainTest : UITestBase
    {
        [TestInitialize]
        public void Init()
        {

        }

        [TestMethod]
        public void TestMethod1()
        {
            var window = App.GetWindow("MainWindow", InitializeOption.WithCache);
            window.WaitWhileBusy();

            var tBox = window.Get<TextBox>("textBox");
            Assert.AreEqual(tBox.Text, "TextBox");

            var cName = window.Get<Button>("button");
            cName.Click();

            Assert.AreEqual(tBox.Text, "Clicked");

            Thread.Sleep(5000);

            tBox.Text = "TestMethod2";

            Thread.Sleep(5000);

            tBox.Text = "TestMethod2 + 5";
        }
    }


    public abstract class UITestBase : IDisposable
    {
        public Application App { get; private set; }

        protected UITestBase()
        {
            App = Application.Launch("C:\\WpfTest.exe");
        }

        public void Dispose()
        {
            App.Dispose();
        }
    }
}
