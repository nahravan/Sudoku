using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Sudoku
{
    public class SetLayout
    {

        // Import the necessary Windows API functions
        [DllImport("user32.dll")]
        private static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);

        [DllImport("kernel32.dll")]
        private static extern IntPtr GetConsoleWindow();

        // Constants for window state
        private const int SW_MAXIMIZE = 3;

        public void Set()
        {
            MaximizeWindow();
            CreateMenu();
        }

        private void MaximizeWindow()
        {
            Console.SetWindowSize(Console.LargestWindowWidth, Console.LargestWindowHeight);
            IntPtr consoleHandle = GetConsoleWindow();
            ShowWindow(consoleHandle, SW_MAXIMIZE);
        }

        private void CreateMenu()
        {
            int x = Console.CursorLeft;
            int y = Console.CursorTop;
            Console.CursorTop = Console.WindowTop + Console.WindowHeight - 1;

            var menu = new StringBuilder();
            menu.Append("New: F1");
            menu.Append("\t\t");
            menu.Append("Refresh: F5");
            menu.Append("\t\t");
            menu.Append("Resolve: F9");
            menu.Append("\t\t");

            Console.Write(menu);
            Console.SetCursorPosition(x, y);
        }
    }
}
