using System.IO;
using System.Reflection;

namespace Alura.LeilaoOnline.Selenium.V2.Helpers
{
    public static class TestHelper
    {
        public static string ExecutableFolder => Path.GetDirectoryName(
            Assembly.GetExecutingAssembly().Location);
    }
}
