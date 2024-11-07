using InteractiveTerminalAPI.UI;
using InteractiveTerminalAPI.UI.Application;
using InteractiveTerminalAPI.UI.Screen;
using Nachito.LunarRework.Patches;
namespace Nachito.LunarRework.Plugin.UI.Application
{
    internal class GainTerminalApplication : InteractiveTerminalApplication
    {
        public override void Initialization()
        {

            IScreen screen = new BoxedScreen()
            {

                Title = "Moon Gains",
                elements =
                [
                new TextElement()
                  {
                     Text = "Moon Gains \n" + MoonsPage(),
                  },
                ]
            };

            currentScreen = screen;
        }

        private string MoonsPage()
        {
            var str = string.Empty;
            foreach (Moons moons in Nachito_LunarRework.ModMoons)
            {
                str += "\n" + moons.Name + " (+" + moons.TimesNotVisited + "/" + moons.Cap + ")";
            }
            return str;
        }
    }
}
