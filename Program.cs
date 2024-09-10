
using Advanced;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Reflection.Metadata.Ecma335;
using System.Runtime;
namespace Advanced
{
    enum SceneType
    {
        BeginScene,
        PlayScene,
        EndScene,
        Quit
    }
    class Program
    {
        public static void Main()
        {
            Console.SetWindowSize(60, 40);
            Console.SetBufferSize(60, 40);
            BeginScene beginScene = new BeginScene();
            PlayScene playScene = new PlayScene();  
            EndScene endScene = new EndScene();
           SceneType sceneType= beginScene.Begin();

            while (true)
            {
                switch (sceneType)
                {
                    case SceneType.BeginScene:
                        sceneType = beginScene.Begin();
                        break;
                    case SceneType.PlayScene:
                        sceneType = playScene.Start();
                        break;
                    case SceneType.EndScene:
                        sceneType = endScene.Begin();
                        break;
                    case SceneType.Quit:
                        return;


                }
            }


        }
    }
}