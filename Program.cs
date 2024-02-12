/*
 * Pavel Dev
 * GitHub: PavelDev91
 * E-mail: PavelDev1991@gmail.com
 */

using System;

using _MyConsole;
using _MyFunc;

namespace MyProject_4
{
    internal class Program
    {
        //-----------------------------------------------------
        enum eMenuPos : byte
        {
            StartMenu = 0,
            EditDataBase = 1,
        }
        //-----------------------------------------------------
        struct sMyList
        {
            public int L;
            public int T;
            public int Height;
            public int Width;

            public int index;

            public string[] List;
        }
        //-----------------------------------------------------
        struct sProductData
        {
            public string Name;
            public int? Price;
            public int? Count;
        }
        //-----------------------------------------------------
        private static MyConsole workConsole;

        private static ConsoleKey pressKey;

        private static ProductInventorySystem pis;

        private static eMenuPos menuPos;

        private static sMyList myList;
        private static sProductData productData;
        //---------------------------------------------------------------------------------------------------------------------
        private static void Draw_Menu()
        {
            menuPos = eMenuPos.StartMenu;

            Console.Title = "GitHub: PavelDev91";
            Console.CursorVisible = false;

            workConsole.Clear();
            workConsole.Draw();

            workConsole.Write(2, workConsole.GetLineCount(), new string('-', workConsole.GetWidth() - 4));
            workConsole.Write((workConsole.GetWidth() / 2) - 12, workConsole.GetLineCount(), "Product Inventory System");
            workConsole.Write(2, workConsole.GetLineCount(), new string('-', workConsole.GetWidth() - 4));

            workConsole.Write(2, workConsole.GetLineCount(), "| Create Product's Data Base | Press Key: '" + ConsoleKey.C.ToString() + "'");

            workConsole.Write(2, workConsole.GetLineCount(), new string('-', workConsole.GetWidth() - 4));
            workConsole.Write(2, workConsole.GetLineCount(), "| Exit                       | Press Key: '" + ConsoleKey.Escape.ToString() + "'");
            workConsole.Write(2, workConsole.GetLineCount(), new string('-', workConsole.GetWidth() - 4));

            workConsole.Draw();
        }
        //-----------------------------------------------------
        private static void Draw_EditDataBase()
        {
            menuPos = eMenuPos.EditDataBase;

            Console.Title = "GitHub: PavelDev91";
            Console.CursorVisible = false;

            workConsole.Clear();
            workConsole.Draw();

            workConsole.Write(2, workConsole.GetLineCount(), new string('-', workConsole.GetWidth() - 4));
            workConsole.Write((workConsole.GetWidth() / 2) - 12, workConsole.GetLineCount(), "Product Inventory System");
            workConsole.Write(2, workConsole.GetLineCount(), new string('-', workConsole.GetWidth() - 4));

            workConsole.Write(2, workConsole.GetLineCount(), "| Add Product          | Press Key: '" + ConsoleKey.A.ToString() + "'");
            workConsole.Write(2, workConsole.GetLineCount(), "| Delete Product       | Press Key: '" + ConsoleKey.D.ToString() + "'");
            workConsole.Write(2, workConsole.GetLineCount(), "| Delete All Product's | Press Key: '" + ConsoleKey.C.ToString() + "'");

            workConsole.Write(2, workConsole.GetLineCount(), new string('-', workConsole.GetWidth() - 4));
            workConsole.Write(2, workConsole.GetLineCount(), "| Back to Menu         | Press Key: '" + ConsoleKey.Escape.ToString() + "'");
            workConsole.Write(2, workConsole.GetLineCount(), new string('-', workConsole.GetWidth() - 4));

            workConsole.Draw();
            //-------------------------------------------------
            if (pis.Get_DataCount() > 0)
            {
                myList = new sMyList();
                myList.L = 2;
                myList.T = workConsole.GetLineCount();
                myList.Width = workConsole.GetWidth() - 4;
                myList.Height = 6;

                myList.index = 0;
                myList.List = new string[pis.Get_DataCount()];

                for (int i = 0; i < myList.List.Length; i++)
                {
                    myList.List[i] = pis.Get_ProductName(i);
                }
            }
            else
            {
                myList.List = null;
            }
        }
        //---------------------------------------------------------------------------------------------------------------------
        static void Main(string[] args)
        {
            void DrawList()
            {
                if (myList.List == null || myList.List.Length == 0)
                {
                    return;
                }

                workConsole.DrawList(myList.L, myList.T, myList.Width, myList.Height, myList.List, myList.index, "* ", "- ");
                workConsole.Write(2, myList.T + myList.Height, new string('-', workConsole.GetWidth() - 4));

                workConsole.LineSame(2, myList.T + 1 + myList.Height, "| ID:                       | " + pis.Get_ProductID(myList.index));
                workConsole.LineSame(2, myList.T + 2 + myList.Height, "| Название продукта:        | " + pis.Get_ProductName(myList.index));
                workConsole.LineSame(2, myList.T + 3 + myList.Height, "| Цена за единицу:          | " + pis.Get_ProductPrice(myList.index));
                workConsole.LineSame(2, myList.T + 4 + myList.Height, "| Кол-во единиц (штук):     | " + pis.Get_ProductCount(myList.index));

                int x = pis.Get_ProductPrice(myList.index) * pis.Get_ProductCount(myList.index);

                workConsole.LineSame(2, myList.T + 5 + myList.Height, "| Общая стоимость:          | " + x.ToString());

                //---------------------------------------------
                int priceSum = 0;

                for (int i = 0; i < pis.Get_DataCount(); i++)
                {
                    priceSum += pis.Get_ProductPrice(i) * pis.Get_ProductCount(i);
                }
                //---------------------------------------------

                workConsole.Write(2, myList.T + 6 + myList.Height, new string('-', workConsole.GetWidth() - 4));
                workConsole.LineSame(2, myList.T + 7 + myList.Height, "| Стоимость всех продуктов: | " + priceSum.ToString());
                workConsole.Write(2, myList.T + 8 + myList.Height, new string('-', workConsole.GetWidth() - 4));

                workConsole.Draw();
            }
            //-------------------------------------------------
            Console.SetWindowSize(128, 40);
            Console.SetBufferSize(128, 40);
            Console.SetWindowPosition(0, 0);

            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.Blue;

            Console.CursorVisible = false;

            workConsole = new MyConsole(0, 0, Console.WindowWidth, Console.WindowHeight);

            pis = new ProductInventorySystem();

            Draw_Menu();
            //-------------------------------------------------
            while (true)
            {
                pressKey = Console.ReadKey(true).Key;

                //---------------------------------------------
                if (menuPos == eMenuPos.StartMenu)
                {
                    if (pressKey == ConsoleKey.C)
                    {
                        Draw_EditDataBase();

                        continue;
                    }
                    //-----------------------------------------
                    if (pressKey == ConsoleKey.Escape)
                    {
                        return;
                    }
                }
                //---------------------------------------------
                if (menuPos == eMenuPos.EditDataBase)
                {
                    //-----------------------------------------
                    if (pis.Get_DataCount() > 0)
                    {
                        //-------------------------------------
                        if (pressKey == ConsoleKey.DownArrow)
                        {
                            myList.index++;

                            if (myList.index >= myList.List.Length)
                            {
                                myList.index = 0;
                            }

                            DrawList();

                            continue;
                        }
                        //-------------------------------------
                        if (pressKey == ConsoleKey.UpArrow)
                        {
                            myList.index--;

                            if (myList.index < 0)
                            {
                                myList.index = myList.List.Length - 1;
                            }

                            DrawList();

                            continue;
                        }
                        //-------------------------------------
                    }
                    //-----------------------------------------
                    if (pressKey == ConsoleKey.A)
                    {
                        while(true)
                        {
                            Draw_EditDataBase();

                            workConsole.Write(2, workConsole.GetLineCount(), "| Введите название продукта (Max Length: 32):");

                            productData.Name = workConsole.WriteRead(4, workConsole.GetLineCount(), "Az Ая 09 =+-*/ `~_ !? ;: @#$%& []{}<>^ /\\|()", 32);

                            if (pis.FindProduct(productData.Name) == true)
                            {
                                workConsole.LineSame(4, workConsole.GetLineCount() - 2, "Ошибка: Запись с таким именем уже существует!");
                                workConsole.LineSame(4, workConsole.GetLineCount() - 1, "Press any Key!");

                                workConsole.Draw();

                                Console.CursorVisible = false;
                                Console.ReadKey(true);

                                workConsole.ClearLine(workConsole.GetLineCount() - 1);
                                workConsole.ClearLine(workConsole.GetLineCount() - 1);

                                continue;
                            }

                            if (productData.Name.Length != 0 && pis.FindProduct(productData.Name) == false)
                            {
                                break;
                            }

                            if (Console.ReadKey(true).Key == ConsoleKey.Escape)
                            {
                                productData.Name = "";

                                break;
                            }
                        }

                        if (productData.Name == "")
                        {
                            Draw_EditDataBase();
                            DrawList();

                            continue;
                        }

                        Draw_EditDataBase();

                        workConsole.Write(2, workConsole.GetLineCount(), "| Введите цену за единицу (Max Length: 16):");
                        productData.Price = MyFunc.StringToInt(workConsole.WriteRead(4, workConsole.GetLineCount(), "09", 16));

                        Draw_EditDataBase();

                        workConsole.Write(2, workConsole.GetLineCount(), "| Введите кол-во единиц (штук) (Max Length: 16):");
                        productData.Count = MyFunc.StringToInt(workConsole.WriteRead(4, workConsole.GetLineCount(), "09", 16));

                        pis.Product_Add(productData.Name, productData.Price, productData.Count);

                        Draw_EditDataBase();

                        DrawList();
                    }
                    //-----------------------------------------
                    if (pressKey == ConsoleKey.D)
                    {
                        if (pis.Get_DataCount() == 0)
                        {
                            continue;
                        }

                        string value;

                        while(true)
                        {
                            workConsole.Write(2, workConsole.GetLineCount(), "| Удаление продукта! (Введите ID продукта):");

                            value = workConsole.WriteRead(4, workConsole.GetLineCount(), "Az/09", 16);

                            if (pis.FindID(value) != -1)
                            {
                                string[] messageText = new string[2];

                                messageText[0] = "Вы действительно хотите удалить запись?";
                                messageText[1] = "'" + pis.Get_ProductName(pis.FindID(value)) + "'";

                                workConsole.ShowMessage(messageText, MyConsole.eMessageType.Dialog, MyConsole.eMessageBtn.btnYesNo, out pressKey);

                                if (pressKey == ConsoleKey.Y)
                                {
                                    pis.DeleteProduct(value);
                                }

                                Draw_EditDataBase();
                                DrawList();

                                break;
                            }
                            else
                            {
                                workConsole.LineSame(2, workConsole.GetLineCount() - 2, "Ошибка: Запись с таким ID не сушествует!");
                                workConsole.LineSame(2, workConsole.GetLineCount() - 1, "Press any Key!");

                                workConsole.Draw();

                                Console.CursorVisible = false;
                                Console.ReadKey(true);

                                workConsole.ClearLine(workConsole.GetLineCount() - 1);
                                workConsole.ClearLine(workConsole.GetLineCount() - 1);

                                Draw_EditDataBase();
                                DrawList();

                                break;
                            }
                        }
                    }
                    //-----------------------------------------
                    if (pressKey == ConsoleKey.C)
                    {
                        string[] messageText = new string[1];

                        messageText[0] = "Вы действительно хотите очистить список продуктов?";

                        workConsole.ShowMessage(messageText, MyConsole.eMessageType.Dialog, MyConsole.eMessageBtn.btnYesNo, out pressKey);

                        if (pressKey == ConsoleKey.Y)
                        {
                            pis.Clear();
                            myList.List = null;

                            Draw_EditDataBase();

                            continue;
                        }
                    }
                    //-----------------------------------------
                    if (pressKey == ConsoleKey.Escape)
                    {
                        Draw_Menu();

                        continue;
                    }
                    //-----------------------------------------
                }
                //---------------------------------------------
            }
            //-------------------------------------------------
        }
    }
}
