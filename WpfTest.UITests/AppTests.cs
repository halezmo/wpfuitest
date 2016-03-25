using NUnit.Framework;
using System;
using System.IO;
using System.Reflection;
using TestStack.White;
using TestStack.White.Configuration;
using TestStack.White.Factory;
using TestStack.White.ScreenObjects.Services;
using TestStack.White.ScreenObjects.Sessions;

namespace WpfTest.UITests
{
    [TestFixture]
    public class AppTests : UITestBase
    {
        [Test]
        public void AutomateTest()
        {
            var workPath = Path.GetDirectoryName(new Uri(Assembly.GetExecutingAssembly().CodeBase).AbsolutePath);
            var workConfiguration = new WorkConfiguration
            {
                ArchiveLocation = workPath,
                Name = "WpfTodo"
            };

            CoreAppXmlConfiguration.Instance.WorkSessionLocation = new DirectoryInfo(workPath);
            using (var workSession = new WorkSession(workConfiguration, new NullWorkEnvironment()))
            {
                var screenRepository = workSession.Attach(Application);
               
            }
        }

    }

    public abstract class UITestBase : IDisposable
    {
        public Application Application { get; private set; }

        protected UITestBase()
        {
            var directoryName = Path.GetDirectoryName(new Uri(Assembly.GetExecutingAssembly().CodeBase).AbsolutePath);
            var markpadLocation = Path.Combine(directoryName, @"WpfTest.exe");
            Application = Application.Launch(markpadLocation);
        }

        public void Dispose()
        {
            Application.Dispose();
        }
    }
}
