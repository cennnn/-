using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advanced.PlaySceneClass
{
    internal class SmallBlock
    {
        public Pos pos;

        public SmallBlock()
        { 
        }

        public SmallBlock(int x,int y)
        {
            pos .x = x; 
            pos .y = y; 
        }

        public void DrawMap()
        {
            if (pos.y < 0)
            {
                return;
            }
            Console.SetCursorPosition(pos.x, pos.y);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("■");
        }
        public void DrawBlock(E_BlockType blockType)
        {
            if (pos.y < 0)
            {
                return;
            }
            Console.SetCursorPosition(pos.x, pos.y);
            switch (blockType)
            {
                case E_BlockType.square:
                    Console.ForegroundColor = ConsoleColor.Black ;
                    break;
                case E_BlockType.Bar:
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    break;
                case E_BlockType.L_shaped_left:
                case E_BlockType.L_shaped_right:
                    Console.ForegroundColor = ConsoleColor.Green;
                    break;
                case E_BlockType.Z_shaped_left:
                case E_BlockType.Z_shaped_right:
                    Console.ForegroundColor = ConsoleColor.Blue;
                    break;
                case E_BlockType.Tu_shaped:
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    break;

            }
            Console.Write("■");
        }
    }
}
