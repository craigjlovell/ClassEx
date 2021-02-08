using System;
using Raylib_cs;

namespace AIE_Game_Settings
{
    class Program
    {
        static void Main(string[] args)
        {

            GameSetting gs = new GameSetting(800, 450, "hello");
            Sprite ST = new Sprite();



            Raylib.InitWindow(gs.windowW, gs.windowH, gs.windowT);

            Texture2D SText = Raylib.LoadTexture("./assets/sprite.png");



            while (!Raylib.WindowShouldClose())
            {
                Raylib.BeginDrawing();
                Raylib.ClearBackground(Color.BLUE);
                //Raylib.DrawTexture(SText, 100, 100, Color.WHITE);
                RayLibExt.DrawTexture(SText, 400, 200, 32, 32, Color.WHITE);
                Raylib.EndDrawing();
            }

            Raylib.CloseWindow();
        }
    }

}
