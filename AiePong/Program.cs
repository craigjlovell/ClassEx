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
        public float speed = 4.0f;
        public int score = 0;

    }
    
    class Program
    {
        int windowW = 800;
        int windowH = 400;


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

                if (leftPaddle.pos.Y > windowH)
                {
                    leftPaddle.pos.Y = 0;
                }
                if (leftPaddle.pos.Y < 0)
                {
                    leftPaddle.pos.Y = windowH;
                }
                if (rightPaddle.pos.Y > windowH)
                { 
                    rightPaddle.pos.Y = 0;
                }
                if (rightPaddle.pos.Y < 0)
                {
                    rightPaddle.pos.Y = windowH;
                }

            }

            Raylib.CloseWindow();
            
        }

        void LoadGame()
        {
            ball = new Ball();
            ResetBall();
            ball.dir.X = 0.707f;
            ball.dir.Y = 0.707f;


            leftPaddle = new Paddle();
            leftPaddle.pos.X = 50;
            leftPaddle.pos.Y = windowH / 2.0f;
            leftPaddle.upKey = KeyboardKey.KEY_W;
            leftPaddle.downKey = KeyboardKey.KEY_S;

            rightPaddle = new Paddle();
            rightPaddle.pos.X = windowW - 50;
            rightPaddle.pos.Y = windowH / 2.0f;
            rightPaddle.upKey = KeyboardKey.KEY_UP;
            rightPaddle.downKey = KeyboardKey.KEY_DOWN;

        }

        void ResetBall() 
        {

            ball.pos.X = windowW / 2;
            ball.pos.Y = windowH / 2;

        }

        void ResetPaddle()
        {
            leftPaddle.pos.X = 50;
            leftPaddle.pos.Y = windowH / 2.0f;

            rightPaddle.pos.X = windowW - 50;
            rightPaddle.pos.Y = windowH / 2.0f;
        }

        void Update()
        {
            UpdateBall(ball);
            UpdatePaddle(leftPaddle);
            UpdatePaddle(rightPaddle);
            HandlePaddleBallCollision(leftPaddle, ball);
            HandlePaddleBallCollision(rightPaddle, ball);
        }

        void UpdateBall(Ball b)
        {
            b.pos += b.dir * b.speed;

            if (b.pos.X < 0)
            {
                ResetBall();

                rightPaddle.score += 1;

                if (rightPaddle.score >= 5)
                {
                    rightPaddle.score = 0;
                    ResetPaddle();
                }

            }
            if (b.pos.X > windowW)
            {
                ResetBall();

                leftPaddle.score += 1;

                if (leftPaddle.score >= 5)
                {
                    leftPaddle.score = 0;
                    ResetPaddle();
                }
            }
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
            float bottom = p.pos.Y + p.size.Y / 2;
            float right = p.pos.X + p.size.X / 2;
            float left = p.pos.X - p.size.X / 2;

            if (b.pos.Y > top && b.pos.Y < bottom && b.pos.X > left && b.pos.X < right) 
            {

                b.dir.X = -b.dir.X;
                b.speed = b.speed * 1.05f;

            }
        }

        void Draw() 
        {

            Raylib.BeginDrawing();
            Raylib.ClearBackground(Color.SKYBLUE);

            DrawBall(ball);
            DrawPaddle(leftPaddle);
            DrawPaddle(rightPaddle);

            Raylib.DrawText(leftPaddle.score.ToString(), windowW / 4, 20, 20, Color.BLACK);
            Raylib.DrawText(rightPaddle.score.ToString(), windowW - (windowW / 4), 20, 20, Color.BLACK);

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
