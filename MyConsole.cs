/*
 * Pavel Dev
 * GitHub: PavelDev91
 * E-mail: PavelDev1991@gmail.com
 */

using System;
using System.Globalization;
using System.Net.Http;

namespace _MyConsole
{
    class MyConsole
    {
        //-----------------------------------------------------
        private struct _MyConsole_Position
        {
            public int L;
            public int T;

            public int Width;
            public int Height;
        }
        //-----------------------------------------------------
        private _MyConsole_Position MyConsole_Position;

        private char?[,] WorkArray;
        private char?[,] BufferArray;
        //-----------------------------------------------------
        public MyConsole(int L, int T, int Width, int Height)
        {
            MyConsole_Position = new _MyConsole_Position();

            MyConsole_Position.L = L;
            MyConsole_Position.T = T;

            MyConsole_Position.Width = Width;
            MyConsole_Position.Height = Height;

            WorkArray = new char?[Width, Height];
            BufferArray = new char?[Width, Height];

            for (int x = 0; x < Width; x++)
            {
                for (int y = 0; y < Height; y++)
                {
                    WorkArray[x, y] = ' ';
                    BufferArray[x, y] = ' ';
                }
            }
        }
        //-----------------------------------------------------
        public void Draw()
        {
            for (int y = 0; y < MyConsole_Position.Height; y++)
            {
                for (int x = 0; x < MyConsole_Position.Width - 1; x++)
                {
                    if (WorkArray[x, y] == ' ' && WorkArray[x, y] != BufferArray[x, y])
                    {
                        Console.SetCursorPosition(MyConsole_Position.L + x, MyConsole_Position.T + y);
                        Console.Write(' ');

                        BufferArray[x, y] = ' ';

                        continue;
                    }

                    if (WorkArray[x, y] == BufferArray[x, y])
                    {
                        continue;
                    }

                    BufferArray[x, y] = WorkArray[x, y];

                    Console.SetCursorPosition(MyConsole_Position.L + x, MyConsole_Position.T + y);
                    Console.Write(WorkArray[x, y]);
                }
            }
        }
        //-----------------------------------------------------
        public void Write(int L, int T, string Value)
        {
            for (int i = 0; i < Value.Length; i++)
            {
                if (L + i > MyConsole_Position.Width - 1 | T > MyConsole_Position.Height - 1)
                {
                    break;
                }

                WorkArray[L + i, T] = Value[i];
            }
        }
        //-----------------------------------------------------
        public string WriteRead(int L, int T, string Mask, int MaxLength, string DefaultValue = "")
        {
            string res = DefaultValue;

            ConsoleKeyInfo PressKey;

            Console.CursorVisible = false;

            string buf;

            while (true)
            {
                //---------------------------------------------
                if (res.Length <= MaxLength && res.Length > MyConsole_Position.Width - (L + 4))
                {
                    ClearLine(T);

                    buf = String_CopyLastNChars(res, res.Length % (MyConsole_Position.Width - (L + 4)));
                }
                else
                {
                    buf = String_CopyLastNChars(res, res.Length);
                }

                LineSame(L, T, buf);

                Draw();

                Console.SetCursorPosition(L + buf.Length, T);
                Console.CursorVisible = true;
                //---------------------------------------------

                PressKey = Console.ReadKey(true);

                for (int i = 0; i < Mask.Length; i++)
                {
                    if (res.Length == MaxLength)
                    {
                        break;
                    }

                    if (CharUnicodeInfo.GetUnicodeCategory(PressKey.KeyChar) == CharUnicodeInfo.GetUnicodeCategory(Mask[i]))
                    {
                        res += PressKey.KeyChar;

                        break;
                    }
                }

                if (PressKey.Key == ConsoleKey.Backspace)
                {
                    if (res.Length > 0)
                    {
                        res = res.Substring(0, res.Length - 1);
                    }
                }

                if (PressKey.Key == ConsoleKey.Enter)
                {
                    break;
                }

                if (PressKey.Key == ConsoleKey.Escape)
                {
                    return "";
                }
            }

            return res;
        }
        //-----------------------------------------------------
        public void DrawList(int L, int T, int width, int height, string[] list, int? selIndex = null, string selIndexPrefix = null, string prefix = null)
        {
            if (list == null || list.Length == 0)
            {
                return;
            }

            if (selIndex == null || selIndex < 0 || selIndex >= list.Length)
            {
                selIndex = 0;
            }

            int x = 0;

            if (list.Length > height)
            {
                x = (int)selIndex;

                if (list.Length - x <= height)
                {
                    x = list.Length - height;
                }

                for (int i = 0; i < height; i++)
                {
                    ClearLine(T + i);
                }

                Draw();
            }

            for (int i = x; i < list.Length; i++)
            {
                if (i - x > height)
                {
                    break;
                }

                if (i == selIndex)
                {
                    if (selIndexPrefix == null && prefix != null)
                    {
                        selIndexPrefix = prefix;
                    }

                    LineSame(L, T + (i - x), selIndexPrefix + list[i]);
                }
                else
                {
                    LineSame(L, T + (i - x), prefix + list[i]);
                }
            }
        }
        //-----------------------------------------------------
        public string String_CopyLastNChars(string Value, int NChars)
        {
            string res = "";

            if (NChars > Value.Length)
            {
                NChars = Value.Length;
            }

            for (int i = Value.Length - NChars; i < Value.Length; i++)
            {
                res += Value[i];
            }

            return res;
        }
        //-----------------------------------------------------
        public void LineSame(int L, int LineIndex, string Value)
        {
            if (LineIndex >= MyConsole_Position.Height - 1)
            {
                return;
            }

            for (int i = 0; i < MyConsole_Position.Width; i++)
            {
                WorkArray[i, LineIndex] = ' ';
            }

            for (int i = 0; i < Value.Length; i++)
            {
                WorkArray[L + i, LineIndex] = Value[i];
            }
        }
        //-----------------------------------------------------
        public int GetWidth()
        {
            return MyConsole_Position.Width;
        }
        //-----------------------------------------------------
        public int GetHeight()
        {
            return MyConsole_Position.Height;
        }
        //-----------------------------------------------------
        public int GetLineCount()
        {
            int res = 0;

            for (int y = 0; y < MyConsole_Position.Height; y++)
            {
                for (int x = 0; x < MyConsole_Position.Width; x++)
                {
                    if (WorkArray[x, y] != ' ')
                    {
                        res = y + 1;

                        break;
                    }
                }
            }

            return res;
        }
        //-----------------------------------------------------
        public void ClearLine(int LineIndex)
        {
            for (int x = 0; x < MyConsole_Position.Width; x++)
            {
                WorkArray[x, LineIndex] = ' ';
            }
        }
        //-----------------------------------------------------
        public void Clear()
        {
            for (int x = 0; x < MyConsole_Position.Width; x++)
            {
                for (int y = 0; y < MyConsole_Position.Height; y++)
                {
                    WorkArray[x, y] = ' ';
                }
            }
        }
        //-----------------------------------------------------
        public enum eMessageType : byte
        {
            Info = 0,
            Error = 1,
            Dialog = 2,
        }
        //---------------------
        public enum eMessageBtn : byte
        {
            btnOk = 0,
            btnYesNo = 1,
            btnYesNoCancel = 2,
            btnCancel = 3,
        }
        //---------------------
        public void ShowMessage(string[] messageText, eMessageType messageType, eMessageBtn messageBtn, out ConsoleKey result)
        {
            Console.CursorVisible = false;

            string consoleTitle = Console.Title;
            //-------------------------------------------------
            char?[,] buf = new char?[GetWidth(), GetHeight()];

            for (int x = 0; x < GetWidth(); x++)
            {
                for (int y = 0; y < GetHeight(); y++)
                {
                    buf[x, y] = BufferArray[x, y];
                }
            }
            //-------------------------------------------------
            Clear();
            Draw();

            //-------------------------------------------------
            Write(2, GetLineCount(), new string('-', GetWidth() - 4));

            for (int i = 0; i < messageText.Length; i++)
            {
                Write((GetWidth() / 2) - (messageText[i].Length / 2), GetLineCount(), messageText[i]);
            }

            Write(2, GetLineCount(), new string('-', GetWidth() - 4));

            if (messageType == eMessageType.Info)
            {
                Console.Title = "| Message | Info!";
            }

            if (messageType == eMessageType.Error)
            {
                Console.Title = "| Message | Error!";
            }

            if (messageType == eMessageType.Dialog)
            {
                Console.Title = "| Message | Dialog!";
            }
            //-------------------------------------------------
            int btnL;

            if (messageBtn == eMessageBtn.btnYesNo)
            {
                btnL = GetWidth() / 2;
                btnL /= 2;
                btnL -= ("| Yes | Press Key: '" + ConsoleKey.Y.ToString() + "' |").Length / 2;

                Write(btnL, GetLineCount(), "| Yes | Press Key: '" + ConsoleKey.Y.ToString() + "' |");

                btnL = GetWidth() / 2;
                btnL += btnL / 2;
                btnL -= ("| No | Press Key: '" + ConsoleKey.N.ToString() + "' |").Length / 2;

                Write(btnL, GetLineCount() - 1, "| No | Press Key: '" + ConsoleKey.N.ToString() + "' |");
            }
            //-------------------------------------------------

            Draw();

            ConsoleKey pressKey;

            while(true)
            {
                pressKey = Console.ReadKey(true).Key;

                if (messageBtn == eMessageBtn.btnYesNo)
                {
                    if (pressKey == ConsoleKey.Y || pressKey == ConsoleKey.N)
                    {
                        result = pressKey;

                        break;
                    }
                }
            }

            //-------------------------------------------------
            for (int x = 0; x < GetWidth(); x++)
            {
                for (int y = 0; y < GetHeight(); y++)
                {
                    WorkArray[x, y] = buf[x, y];
                }
            }
            //-------------------------------------------------

            Draw();

            Console.Title = consoleTitle; 
        }
        //-----------------------------------------------------
    }
}
