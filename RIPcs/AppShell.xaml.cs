using RIPcs.View.Laba_2;

namespace RIPcs
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(NotePage), typeof(NotePage));
        }
    }
}
