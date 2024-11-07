
namespace Nachito.LunarRework.Plugin
{
    public class Moons(int timesNotVisited, int cap, int mult, int price, string name, int defaultCap, int defaultMult)
    {
        public int TimesNotVisited = timesNotVisited;
        public int Cap = cap;
        public int Mult = mult;
        public string Name = name;
        public int Price = price;

        public int DefaultCap = defaultCap;
        public int DefaultMult = defaultMult;
    }
}
