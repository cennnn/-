using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advanced.PlaySceneClass
{
    internal class Map
    {
        List<SmallBlock> map;
        List<SmallBlock> dynamicMap;
        int Targetline;
        int miniHeight;

        public Map()
        {
            map = new List<SmallBlock>();
            dynamicMap = new List<SmallBlock>();
        }
        public List<SmallBlock> mp
        {
            get { return map; }
        }
        public List<SmallBlock> Dynamicmp
        {
            get { return dynamicMap; }
        }

        public void DrawMap()
        {

            int i;
            int j = 0;
            for (i = 0; i < 39; i++)
            {
                map.Add(new SmallBlock(0, i));
                map[j].DrawMap();
                j++;

            }
            for (i = 0; i < 60; i += 2)
            {
                map.Add(new SmallBlock(i, 39));
                map[j].DrawMap();
                j++;
            }
            for (i = 0; i < 39; i++)
            {
                map.Add(new SmallBlock(58, i));
                map[j].DrawMap();
                j++;
            }
            for (i = 0; i < dynamicMap.Count; i++)
            {
                dynamicMap[i].DrawMap();
            }
        }

        public void AddDynamicMap(SmallBlock[] smallBlocks)
        {
            dynamicMap.AddRange(smallBlocks);
        }

        public bool IsFull(SmallBlock[] smallBlocks)

        {

         int   maxHeight = smallBlocks[0].pos.y;
            miniHeight = smallBlocks[0].pos.y;
            List<SmallBlock> line = new List<SmallBlock>();
            //找当前砖块所在的那几行

            for (int i = 0; i < smallBlocks.Length - 1; i++)
            {
                if (smallBlocks[i].pos.y < smallBlocks[i + 1].pos.y)
                {
                    maxHeight = smallBlocks[i + 1].pos.y;
                }
                if (smallBlocks[i].pos.y > smallBlocks[i + 1].pos.y)
                {
                    miniHeight = smallBlocks[i + 1].pos.y;
                }
            }

            //遍历数组找出各个行的元素再判断每行是否满了

            for (Targetline = miniHeight; Targetline <= maxHeight; Targetline++)
            {
                line.Clear();
                for (int i = 0; i < dynamicMap.Count; i++)
                {
                    if (dynamicMap[i].pos.y == Targetline)
                    {
                        line.Add(dynamicMap[i]);
                    }
                }

                if (line.Count == 28)
                {
                    return true;
                }

            }


            return false;

        }

        //如果满了调用这个方法
        //把满的那一行删掉，把整体坐标的高+1
        public void WeapMap()
        {
            for (int i = 0; i < dynamicMap.Count; i++)
            {
                Console.SetCursorPosition(dynamicMap[i].pos.x, dynamicMap[i].pos.y);
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write("  ");
            }
        }
        public void ChangeDynamicMap()
        {
            List<SmallBlock> templist = new List<SmallBlock>();
            templist.Clear();
            WeapMap();
            for (int i = 0; i < dynamicMap.Count; i++)
            {
                if (dynamicMap[i].pos.y == Targetline)
                {
                    templist.Add(dynamicMap[i]);
                }
            }
            for (int i = 0; i < templist.Count; i++)
            {
                dynamicMap.Remove(templist[i]);
            }


            for (int i = 0; i < dynamicMap.Count; i++)
            {
                if (dynamicMap[i].pos.y <= Targetline)
                    dynamicMap[i].pos.y++;
            }
        }

        //通过动态地图判断是否结束
        public bool IsOver()
        {
            if (miniHeight < 0)
            {
                return true;
            }
            return false;   
        }

    }
}
