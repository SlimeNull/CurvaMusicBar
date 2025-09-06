using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using CurvaMusicBar.NativeInterop;

namespace CurvaMusicBar
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        protected override unsafe void OnSourceInitialized(EventArgs e)
        {
            base.OnSourceInitialized(e);

            // App Bar Size
            var appBarSize = 100;

            // Screen size
            var screenWidth = PInvoke.GetSystemMetrics(SystemMetric.SM_CXFULLSCREEN);
            var screenHeight = PInvoke.GetSystemMetrics(SystemMetric.SM_CYFULLSCREEN);

            // Handle of current window
            IntPtr hWnd = new System.Windows.Interop.WindowInteropHelper(this).Handle;

            // Register the taskbar appbar
            PInvoke.SHAppBarMessage(0x00000000, new APPBARDATA()
            {
                cbSize = sizeof(APPBARDATA),
                hWnd = hWnd,
            });

            // Set the taskbar appbar position
            PInvoke.SHAppBarMessage(0x00000003, new APPBARDATA()
            {
                cbSize = sizeof(APPBARDATA),
                hWnd = hWnd,
                uEdge = 1, // ABE_TOP
                rc = new RECT()
                {
                    Left = 0,
                    Top = 0,
                    Right = screenWidth,
                    Bottom = appBarSize
                }
            });

            // Set window position
            PInvoke.SetWindowPos(hWnd, 0, 0, 0, screenWidth, appBarSize, 0);
        }
    }
}