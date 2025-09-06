using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace CurvaMusicBar.NativeInterop
{
    internal class PInvoke
    {
        public const int GWL_EXSTYLE = -20;

        /// <summary>
        ///     Sends an appbar message to the system.
        ///     <para>
        ///     Go to https://msdn.microsoft.com/en-us/library/windows/desktop/bb762108%28v=vs.85%29.aspx for more
        ///     information.
        ///     </para>
        /// </summary>
        /// <param name="dwMessage">
        ///     C++ ( dwMessage [in] Type: DWORD )<br />Appbar message value to send. This parameter can be one of the following
        ///     values.<br />
        ///     <list type="table">
        ///     <listheader>
        ///         <term>Possible AppBar Values</term>
        ///         <description>Any possible app bar value used int he function</description>
        ///     </listheader>
        ///     <item>
        ///         <term>ABM_NEW (0x00000000)</term>
        ///         <description>
        ///         Registers a new appbar and specifies the message identifier that the system should use to
        ///         send notification messages to the appbar.
        ///         </description>
        ///     </item>
        ///     <item>
        ///         <term>ABM_REMOVE (0x00000001)</term>
        ///         <description>Unregisters an appbar, removing the bar from the system's internal list.</description>
        ///     </item>
        ///     <item>
        ///         <term>ABM_QUERYPOS (0x00000002)</term>
        ///         <description>Requests a size and screen position for an appbar.</description>
        ///     </item>
        ///     <item>
        ///         <term>ABM_SETPOS (0x00000003)</term>
        ///         <description>Sets the size and screen position of an appbar.</description>
        ///     </item>
        ///     <item>
        ///         <term>ABM_GETSTATE (0x00000004)</term>
        ///         <description>Retrieves the autohide and always-on-top states of the Windows taskbar.</description>
        ///     </item>
        ///     <item>
        ///         <term>ABM_GETTASKBARPOS (0x00000005)</term>
        ///         <description>
        ///         Retrieves the bounding rectangle of the Windows taskbar. Note that this applies only to the
        ///         system taskbar. Other objects, particularly toolbars supplied with third-party software, also can be
        ///         present. As a result, some of the screen area not covered by the Windows taskbar might not be visible
        ///         to the user. To retrieve the area of the screen not covered by both the taskbar and other app bars—the
        ///         working area available to your application—, use the GetMonitorInfo function.
        ///         </description>
        ///     </item>
        ///     <item>
        ///         <term>ABM_ACTIVATE (0x00000006)</term>
        ///         <description>
        ///         Notifies the system to activate or deactivate an appbar. The lParam member of the APPBARDATA
        ///         pointed to by pData is set to TRUE to activate or FALSE to deactivate.
        ///         </description>
        ///     </item>
        ///     <item>
        ///         <term>ABM_GETAUTOHIDEBAR (0x00000007)</term>
        ///         <description>Retrieves the handle to the autohide appbar associated with a particular edge of the screen.</description>
        ///     </item>
        ///     <item>
        ///         <term>ABM_SETAUTOHIDEBAR (0x00000008)</term>
        ///         <description>Registers or unregisters an autohide appbar for an edge of the screen.</description>
        ///     </item>
        ///     <item>
        ///         <term>ABM_WINDOWPOSCHANGED (0x00000009)</term>
        ///         <description>Notifies the system when an appbar's position has changed.</description>
        ///     </item>
        ///     <item>
        ///         <term>ABM_SETSTATE (0x0000000A)</term>
        ///         <description>Windows XP and later: Sets the state of the appbar's autohide and always-on-top attributes.</description>
        ///     </item>
        ///     </list>
        /// </param>
        /// <param name="pData">
        ///     C++ ( pData [in, out] Type: PAPPBARDATA )<br /> A pointer to an APPBARDATA structure. The content
        ///     of the structure on entry and on exit depends on the value set in the dwMessage parameter. See the individual
        ///     message pages for specifics.
        /// </param>
        /// <returns>
        ///     C++ ( Type: UINT_PTR )<br />This function returns a message-dependent value. For more information, see the
        ///     Windows SDK documentation for thespecific appbar message sent.
        /// </returns>
        [DllImport("shell32.dll")]
        public static extern IntPtr SHAppBarMessage(uint dwMessage,
           [In] ref APPBARDATA pData);

        [DllImport("user32.dll")]
        public static extern int GetSystemMetrics(SystemMetric smIndex);

        [DllImport("user32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool SetWindowPos(IntPtr hWnd, IntPtr hWndInsertAfter, int x, int y, int cx, int cy, uint uFlags);

        [DllImport("user32.dll", EntryPoint = "GetWindowLongPtr")]
        public static extern IntPtr GetWindowLongPtr(IntPtr hWnd, int nIndex);

        [DllImport("user32.dll", EntryPoint = "SetWindowLongPtr")]
        public static extern IntPtr SetWindowLongPtr(IntPtr hWnd, int nIndex, IntPtr dwNewLong);

        [DllImport("user32.dll")]
        public static extern IntPtr FindWindow(string lpClassName, string? lpWindowName);
        [DllImport("user32.dll")]
        public static extern IntPtr SetParent(IntPtr hWndChild, IntPtr hWndNewParent);
    }
}
