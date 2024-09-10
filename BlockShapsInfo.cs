using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advanced.PlaySceneClass
{
    enum E_BlockType
    {
        square,
        Bar,
        L_shaped_left,
        L_shaped_right,
        Z_shaped_left,
        Z_shaped_right,
        Tu_shaped,
    }
    internal class BlockShapsInfo
    {
        //存放4个形状里的三个偏差信息
        //如果是square就只有一个形状，三个偏差信息
        List<Pos[]> BlockInfo;
        public BlockShapsInfo(E_BlockType type)
        {
            switch (type)
            {

                case E_BlockType.square:
                    BlockInfo = new List<Pos[]> { new Pos[3] { new Pos(2, 0), new Pos(0, 1), new Pos(2, 1) } };
                    break;
                case E_BlockType.Bar:
                    BlockInfo = new List<Pos[]> { new Pos[3] { new Pos(0,-1), new Pos(0, 1), new Pos(0, 2) },
                                                  new Pos[3] { new Pos(-4, 0), new Pos(-2, 0), new Pos(2, 0) },
                                                  new Pos[3] { new Pos(0, -2), new Pos(0, -1), new Pos(0, 1) },
                                                  new Pos[3] { new Pos(-2, 0), new Pos(2, 0), new Pos(4, 0) },
                                                                };
                    break;
                case E_BlockType.L_shaped_left:
                    BlockInfo = new List<Pos[]> { new Pos[3] { new Pos(-2,-1), new Pos(0, -1), new Pos(0, 1) },
                                                        new Pos[3] { new Pos(2, -1), new Pos(-2, 0), new Pos(2, 0) },
                                                        new Pos[3] { new Pos(0, -1), new Pos(2, 1), new Pos(0, 1) },
                                                        new Pos[3] { new Pos(2, 0), new Pos(-2, 0), new Pos(-2, 1) },
                                                          };
                    break;
                case E_BlockType.L_shaped_right:
                    BlockInfo = new List<Pos[]> { new Pos[3] { new Pos(0,-1), new Pos(0, 1), new Pos(2,-1) },
                                                        new Pos[3] { new Pos(2, 0), new Pos(-2, 0), new Pos(2, 1) },
                                                        new Pos[3] { new Pos(0, -1), new Pos(-2, 1), new Pos(0, 1) },
                                                        new Pos[3] { new Pos(-2, -1), new Pos(-2, 0), new Pos(2, 0) },
                                                          };
                    break;
                case E_BlockType.Z_shaped_left:
                    BlockInfo = new List<Pos[]> {       new Pos[3] { new Pos(0, -1), new Pos(-2, 0), new Pos(-2, 1) },
                                                        new Pos[3] { new Pos(-2,-1), new Pos(0, -1), new Pos(2, 0) },
                                                        new Pos[3] { new Pos(2, -1), new Pos(2, 0), new Pos(0, 1) },
                                                       
                                                         new Pos[3] { new Pos(0, 1), new Pos(2, 1), new Pos(-2, 0) },




                                                          };
                    break;
                case E_BlockType.Z_shaped_right://you
                    BlockInfo = new List<Pos[]> { new Pos[3] { new Pos(-2,1), new Pos(0, 1), new Pos(2, 0) },
                                                        new Pos[3] { new Pos(-2, -1), new Pos(-2, 0), new Pos(0, 1) },
                                                   
                                                       
                                                        new Pos[3] { new Pos(0, -1), new Pos(2, -1), new Pos(-2, 0) },
                                                         new Pos[3] { new Pos(0, -1), new Pos(2, 0), new Pos(2, 1) },
                                                          };

                    break;
                case E_BlockType.Tu_shaped:
                    BlockInfo = new List<Pos[]> { new Pos[3] { new Pos(-2,0), new Pos(2, 0), new Pos (0, 1) },
                                                        new Pos[3] { new Pos(0, -1), new Pos(-2, 0), new Pos(0, 1) },
                                                        new Pos[3] { new Pos(0, -1), new Pos(-2, 0), new Pos(2, 0) },
                                                        new Pos[3] { new Pos(0, -1), new Pos(2, 0), new Pos(0, 1) },
                                                          };

                    break;


            }




        }
        public List<Pos[]> BlockInfos { get { return BlockInfo; } }
        public Pos[] this[int index]
        {
            get { return BlockInfo[index]; }
            
        }
    }
}
