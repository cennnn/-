using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Advanced.PlaySceneClass
{
    enum E_ChangeType
    {
        Left,
        Right,
    }
  

    internal class Block
    {
        Map Map;
        SmallBlock[] Blocks;
        E_BlockType type;
        Random rand= new Random();
        BlockShapsInfo shapsInfo;
        int nowIndex;

        public Block()
        {
            //设置原点位置在屏幕中间
            
            RandomSpawnBlock();
            
        }
        
        //随机生成方块
        public void RandomSpawnBlock()
        {
            Blocks = new SmallBlock[4];
            Blocks[0] = new SmallBlock(30, -2);
            
            nowIndex = 0;
            type= (E_BlockType) rand.Next(nowIndex,5);
            shapsInfo =new BlockShapsInfo(type);

           
           Pos OPos = Blocks[nowIndex].pos;

            Pos[] pos;
            if (shapsInfo.BlockInfos.Count < 4)
            {
                pos = shapsInfo[nowIndex];//shapsInfo通过索引器返回出一个Pos数组
            }
            else 
            {
                pos = shapsInfo[nowIndex=rand.Next(nowIndex, shapsInfo.BlockInfos.Count)];
            }
            for (int i = 1; i < Blocks.Length; i++)
            {
                Blocks[i]=new SmallBlock(OPos.x+pos[i-1].x,OPos.y+pos[i-1].y);
            }
        }
        //根据类中的type来打印Blocks数组里的方块
        public void Draw()
        {
            for (int i = 0; i < Blocks.Length; i++)
            {
                Blocks[i].DrawBlock(type);
            }
        }
        //根据检测输入的左右箭头来进行方块变形信息改写
        public void ChangeType(E_ChangeType changType)
        {
            switch (changType)
            {
                case E_ChangeType.Right:
                    nowIndex++;
                    if (nowIndex > 3)
                    {
                        nowIndex = 0;
                    }

                    break;
                case E_ChangeType.Left:
                    nowIndex--;
                    if (nowIndex <0)
                    {
                        nowIndex = 3;
                    }
                    break;
                   
            }

            Pos OPos = Blocks[0].pos;
            Pos[] pos;
            if (shapsInfo.BlockInfos.Count < 4)
            {
                pos = shapsInfo[0];//shapsInfo通过索引器返回出一个Pos数组
            }
            else
            {
                pos = shapsInfo[nowIndex]; 
            }
           
            for (int i = 1; i < Blocks.Length; i++)
            {
                Blocks[i] = new SmallBlock(OPos.x + pos[i - 1].x, OPos.y + pos[i - 1].y);
            }
            
        }
        //擦除方块
        public void Weap()
        {


            for (int i = 0; i < Blocks.Length; i++)
            {
                if (Blocks[i].pos.y >= 0)
                {
                    Console.SetCursorPosition(Blocks[i].pos.x, Blocks[i].pos.y);
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write("  ");
                    
                }
               
            }
        }
        //判断能不能变形
        public bool CanChange(E_ChangeType changType, Map map)
        {
            if (type == E_BlockType.square)
            {
                return false;
            }
            int temp=nowIndex;
            switch (changType)
            {
                case E_ChangeType.Right:
                    temp++;
                    if (temp > 3)
                    {
                        temp = 0;
                    }

                    break;
                case E_ChangeType.Left:
                    temp--;
                    if (temp < 0)
                    {
                        temp = 3;
                    }
                    break;
            }
            Pos[] pos = shapsInfo[temp];


            //for (int i = 0; i < map.mp.Count; i++)
            //{
            //    for (int j = 0; j < Blocks.Length; j++)
            //    {
            //        if (map.mp[i].pos.x == pos[j].x && map.mp[i].pos.y == pos[j].y)
            //        {
            //            return false;
            //        }
            //    }
            //}

            //判断是否超出地图边界
            for (int i = 0; i < Blocks.Length-1; i++)
            {
                
                if ((Blocks[0].pos + pos[i]).x <2 || (Blocks[0].pos + pos[i]).x >=58 || (Blocks[0].pos + pos[i]).y >= 39)
                {
                    return false;
                }
            }
            //判断是否和地图动态方块重合
            for (int i = 0; i < map.Dynamicmp.Count; i++)
            {
                for (int j = 0; j < Blocks.Length-1; j++)
                {
                    if (map.Dynamicmp[i].pos == Blocks[0].pos + pos[j])
                        return false;
                }
            }

            return true;
        }
        //左右移动方块
        public void HorizontalMove(E_ChangeType type)
        {
            Weap();
            Pos pos = new Pos(type == E_ChangeType.Right ?2:-2,0);
            for (int i = 0; i < Blocks.Length; i++)
            {
                Blocks[i].pos += pos;
            }
        }
        public bool CanMove(E_ChangeType type, Map map)
        {
            Pos pos = new Pos(type == E_ChangeType.Right ? 2 : -2, 0);
       
            
            for (int i = 0; i < Blocks.Length; i++)
            {
               
                if ((Blocks[i].pos+pos).x < 2 || (Blocks[i].pos + pos).x >= 58 || (Blocks[i].pos + pos).y >= 39)
                {
                    return false;

                }
            }
            for (int i = 0; i < map.Dynamicmp.Count; i++)
            {
                for (int j = 0; j < Blocks.Length; j++)
                {
                    if (map.Dynamicmp[i].pos == (Blocks[j].pos + pos))
                        return false;
                }
            }
            return true;
        }
        //竖直移动方块
        public void VerticalMove()
        {
            
          
            Weap();
            Pos p=new Pos(0,1);

            for (int i = 0; i < Blocks.Length; i++)
            {
                Blocks[i].pos += p;
            }
        }
        public bool CanVerticalMove(Map map)
        {
            
            Pos p = new Pos(0, 1);
            Pos temppos ;
            for (int i = 0; i < Blocks.Length; i++)
            {
                temppos = Blocks[i].pos + p;
               if (temppos.y >= 39)
                {
                    map.AddDynamicMap(Blocks);
                    map.DrawMap();
                    if (map.IsFull(Blocks))
                    {
                        map.ChangeDynamicMap();
                    }
                    RandomSpawnBlock();
                    return false;
                }
            }

            for (int i = 0; i < map.Dynamicmp.Count; i++)
            {
                for (int j = 0; j < Blocks.Length; j++)
                {
                    if (map.Dynamicmp[i].pos == (Blocks[j].pos + p))
                    {
                        map.AddDynamicMap(Blocks);
                        map.DrawMap();
                        if (map.IsFull(Blocks))
                        {
                            map.ChangeDynamicMap();
                        }
                        RandomSpawnBlock();
                        return false;
                    }
                    
                }
            }


            return true;
        }

    }
}
