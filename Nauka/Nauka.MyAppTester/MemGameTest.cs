using System.Diagnostics;
using System.Drawing;
using System.Reflection;
using System.Windows.Forms;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Nauka.MemoryGame.MemoryClass;

namespace Nauka.MyAppTester
{
    [TestClass]
    public class MemGameTest
    {
        [TestMethod]
        public void GetSize()
        {
            var memField = new MemField(default(int),default(int),default(Control));
            var size = typeof(MemField).GetField("_fSize", BindingFlags.NonPublic | BindingFlags.Instance);
            Debug.WriteLine(size.GetValue(null));
        }
    }
}