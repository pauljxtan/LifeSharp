using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Windows.Media;
using System.Globalization;

namespace LifeSharp.ViewModel.Tests
{
    [TestClass()]
    public class IntToColorConverterTests
    {
        [TestMethod()]
        public void ConvertTest()
        {
            var converter = new IntToColorConverter();

            int value = 0;
            Color expected = Colors.White;
            Color actual = (Color)converter.Convert(value, typeof(Color), null, CultureInfo.CurrentCulture);

            Assert.AreEqual(expected, actual);

            value = 1;
            expected = Colors.Black;
            actual = (Color)converter.Convert(value, typeof(Color), null, CultureInfo.CurrentCulture);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void ConvertBackTest()
        {
            var converter = new IntToColorConverter();

            Color value = Colors.White;
            int expected = 0;
            int actual = (int)converter.ConvertBack(value, typeof(int), null, CultureInfo.CurrentCulture);

            Assert.AreEqual(expected, actual);

            value = Colors.Black;
            expected = 1;
            actual = (int)converter.ConvertBack(value, typeof(int), null, CultureInfo.CurrentCulture);

            Assert.AreEqual(expected, actual);
        }
    }
}