using Soccer.ViewModels;

namespace Soccer.Infrastructure
{
    public class IntanceLocator
    {
        public MainViewModel Main { get; set; }

        public IntanceLocator()
        {
            Main = new MainViewModel();
        }
    }
}
