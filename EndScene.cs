using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advanced
{
    internal class EndScene
    {

        ConsoleKeyInfo keyInfo;
        SceneType sceneType;
        public SceneType Begin()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Black;
            PrintTitle();
            while (true)
            {
                keyInfo = Console.ReadKey(true);
                if (keyInfo.Key == ConsoleKey.W)
                {
                    Console.SetCursorPosition(27, 21);
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.Write("结束游戏");
                    Console.SetCursorPosition(27, 18);
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write("返回主页");
                    sceneType = SceneType.BeginScene;
                }
                else if (keyInfo.Key == ConsoleKey.S)
                {
                    Console.SetCursorPosition(27, 18);
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.Write("返回主页");
                    Console.SetCursorPosition(27, 21);
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write("结束游戏");
                    sceneType = SceneType.Quit;
                }

                if (keyInfo.Key == ConsoleKey.Enter)
                {
                    return sceneType;
                }


            }

        }
        private void PrintTitle()
        {
            Console.SetCursorPosition(27, 10);
            Console.Write("~你输了~");
            Console.SetCursorPosition(27, 18);
            Console.Write("返回主页");
            Console.SetCursorPosition(27, 21);
            Console.Write("结束游戏");
        }
    }
}
