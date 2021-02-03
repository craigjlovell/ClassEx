using System;
using System.Numerics;
using Raylib_cs;

namespace AiePong
{
    
    class Ball
    {
        public Vector2 pos = new Vector2();
        public Vector2 dir = new Vector2();
        public float speed = 3.0f;
        public float radius = 10.0f;

    }

    class Paddle
    {
        public Vector2 pos = new Vector2();
        public Vector2 size = new Vector2(10, 100);
        public KeyboardKey upKey;
        public KeyboardKey downKey;
        public float speed = 3.0f;

    }
    
    class Program
    {
        int windowW = 800;
        int windowH = 450;


        Ball ball;
        Paddle leftPaddle;
        Paddle rightPaddle;

        static void Main(string[] args)
        {

            Program p = new Program();
            p.RunProgram();

        }

        void RunProgram()
        {

            Raylib.InitWindow(windowW, windowH, "Pong");
            Raylib.SetTargetFPS(100);

            LoadGame();

            while (!Raylib.WindowShouldClose())
            {

                Update();
                Draw();

            }

            Raylib.CloseWindow();
            
        }

        void LoadGame()
        {
            ball = new Ball();
            ball.pos.X = windowW / 2;
            ball.pos.Y = windowH / 2;
            ball.dir.X = 0.707f;
            ball.dir.Y = 0.707f;


            leftPaddle = new Paddle();
            leftPaddle.pos.X = 10;
            leftPaddle.pos.Y = windowH / 2.0f;
            leftPaddle.upKey = KeyboardKey.KEY_W;
            leftPaddle.downKey = KeyboardKey.KEY_S;

            rightPaddle = new Paddle();
            rightPaddle.pos.X = windowW - 10;
            rightPaddle.pos.Y = windowH / 2.0f;
            rightPaddle.upKey = KeyboardKey.KEY_UP;
            rightPaddle.downKey = KeyboardKey.KEY_DOWN;

        }

        void Update()
        {
            UpdateBall(ball);
            UpdatePaddle(leftPaddle);
            UpdatePaddle(rightPaddle);
        }

        void UpdateBall(Ball b)
        {
            b.pos += b.dir * b.speed;

            if (b.pos.X < 0)       b.dir.X = -b.dir.X;
            if (b.pos.X > windowW) b.dir.X = -b.dir.X;
            if (b.pos.Y < 0)       b.dir.Y = -b.dir.Y;
            if (b.pos.Y > windowH) b.dir.Y = -b.dir.Y;

        }

        void UpdatePaddle(Paddle p)
        {
            if (Raylib.IsKeyDown(p.upKey))
            {
                p.pos -= new Vector2(0, p.speed);
            }

            if (Raylib.IsKeyDown(p.downKey))
            {
                p.pos += new Vector2(0, p.speed);
            }
        }

        void HandlePaddleBallCollision(Paddle p, Ball b)
        {
            float top = p.pos.Y - p.size.Y / 2;
        }

        void Draw() 
        {

            Raylib.BeginDrawing();
            Raylib.ClearBackground(Color.SKYBLUE);

            DrawBall(ball);
            DrawPaddle(leftPaddle);
            DrawPaddle(rightPaddle);

            Raylib.DrawFPS(10, 10);

            Raylib.EndDrawing();

        }
        void DrawBall(Ball b)
        {
            Raylib.DrawCircle((int)b.pos.X, (int)b.pos.Y, b.radius, Color.RED);
        }

        void DrawPaddle(Paddle p)
        {
            Raylib.DrawRectanglePro(new Rectangle(p.pos.X, p.pos.Y, p.size.X, p.size.Y), p.size / 2, 0.0f, Color.GOLD);
        }

    }
}
