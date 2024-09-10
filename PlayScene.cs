using Advanced.PlaySceneClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Advanced
{
    struct Pos
    {
        public int x;
        public int y;
        public Pos(int x, int y)
        {
            this.x = x;
            this.y = y;
        }
        public static Pos operator +(Pos p, Pos p1)
        {
            Pos pos=new Pos(p.x + p1.x,p.y+p1.y);
           
            return pos;
        }
        public static bool operator ==(Pos p, Pos p1)
        {
            if (p.x == p1.x && p.y == p1.y)
                return true;
            else 
                return false;
        }
        public static bool operator !=(Pos p, Pos p1)
        {
            if (p.x == p1.x && p.y == p1.y)
                return false ;
            else
                return true;
        }
    }
    internal class PlayScene
    {
        Map map ;
        Block Block=new Block();
       

        public PlayScene()
        {
            InputThread.inputThread.Func += DetectInput;
        }
        public void DetectInput()
        {
           
                if (Console.KeyAvailable)
                {
                    lock (Block) 
                    {
                        
                        switch (Console.ReadKey(true).Key)
                        {
                            case ConsoleKey.LeftArrow:
                                Block.Weap();
                                if (Block.CanChange(E_ChangeType.Left, map))
                                    Block.ChangeType(E_ChangeType.Left);
                                break;
                            case ConsoleKey.RightArrow:
                                Block.Weap();
                                if (Block.CanChange(E_ChangeType.Right, map))
                                    Block.ChangeType(E_ChangeType.Right);
                                break;
                            case ConsoleKey.A:
                                if (Block.CanMove(E_ChangeType.Left, map))
                                    Block.HorizontalMove(E_ChangeType.Left);
                                break;
                            case ConsoleKey.D:
                                if (Block.CanMove(E_ChangeType.Right, map))
                                    Block.HorizontalMove(E_ChangeType.Right);
                                break;
                                case ConsoleKey.S:
                                
                                if (Block.CanVerticalMove(map))
                                {
                                    Block.VerticalMove();
                                }
                                break;
                        }
                        Block.Draw();

                    }
                    
                
            }
        }
        public void StopThread()
        {
            InputThread.inputThread.Func -= DetectInput;
        }

        public SceneType Start()
        {
            
            Console.Clear();
            map = new Map();
            while (true)
            {
                lock (Block)
                {


                    
                    if (Block.CanVerticalMove(map))
                    {
                        Block.VerticalMove();
                        
                       Block.Draw();
                    }
            
                    map.DrawMap();
                    
                    

                }

                Thread.Sleep(500);

                if (map.IsOver())
                {
                    StopThread();
                    return SceneType.EndScene;
                }

            }
        }
    }
}
