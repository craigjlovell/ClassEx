using System;
using System.Numerics;
using Raylib_cs;

namespace AIE_Asteroids
{
    class Program
    {
        public int windowH = 1050;
        public int windowW = 1650;
        public string windowT = "Asteroids";

        Player player;
        Bullet[] bullets = new Bullet[100];
        Asteroid[] asteroids = new Asteroid[150];

        float asteroidSpawnCooldown = 4.0f;
        float asteroidSpawnCooldownReset = 4.0f;



        static void Main(string[] args)
        {
            Program p = new Program();
            p.RunGame();

            Random rand = new Random();
            Color col = new Color(
               rand.Next(0, 255), // rand red value
               rand.Next(0, 255), // random green value
               rand.Next(0, 255), // random blue value
               255); // alpha
        }

        void RunGame()
        {
            Raylib.InitWindow(windowW, windowH, windowT);
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

            Assets.LoadAssets();

            player = new Player(
                this,
                new Vector2(windowW / 2, windowH / 2),
                new Vector2(64, 64)
            );

            for(int i = 0; i < bullets.Length; i++)
            {
                bullets[i] = null;
            }

            for(int i = 0; i < asteroids.Length; i++)
            {
                asteroids[i] = null;
            }

        }

        void Update()
        {
            asteroidSpawnCooldown -= Raylib.GetFrameTime();
            if(asteroidSpawnCooldown < 0.0f)
            {

                SpawnNewAsteroid();
                asteroidSpawnCooldown = asteroidSpawnCooldownReset;
            }

            player.Update();

            for(int i = 0; i < bullets.Length; i++)
            {
                if(bullets[i] != null)
                {
                    bullets[i].Update();
                }
            }

            for (int i = 0; i < asteroids.Length; i++)
            {
                if (asteroids[i] != null)
                {
                    asteroids[i].Update();
                }
            }

            foreach(var bullet in bullets)
            {
                foreach(var asteroid in asteroids)
                {
                    DoBulletAsteroidCollision(bullet, asteroid);
                }
            }
        }

        void Draw()
        {
            Raylib.BeginDrawing();
            Raylib.ClearBackground(Color.BLACK);

            player.Draw();

            for (int i = 0; i < bullets.Length; i++)
            {
                if (bullets[i] != null)
                {
                    bullets[i].Draw();
                }
                    
            }

            for (int i = 0; i < asteroids.Length; i++)
            {
                if (asteroids[i] != null)
                {
                    asteroids[i].Draw();
                }
            }

            Raylib.EndDrawing();
        }

       public void SpawnBullet(Vector2 pos, Vector2 dir)
        {
            Bullet bullet = new Bullet(this, pos, dir);

            for(int i = 0; i < bullets.Length; i++)
            {
                if(bullets[i] == null)
                {
                    bullets[i] = bullet;
                    break;
                }
            }

        }

        void SpawnNewAsteroid()
        {
            Random rand = new Random();
            int side = rand.Next(0, 4);

            float rot = (float)rand.NextDouble() * MathF.PI * 2.0f;
            Vector2 dir = new Vector2(MathF.Cos(rot), MathF.Sin(rot));

            float radius = 40;

            if (side == 0) SpawnAsteroid(new Vector2(0, rand.Next(0, windowH)), dir, radius);

            if (side == 1) SpawnAsteroid(new Vector2(rand.Next(0, windowW), 0), dir, radius);

            if (side == 2) SpawnAsteroid(new Vector2(windowW, rand.Next(0, windowH)), dir, radius);

            if (side == 3) SpawnAsteroid(new Vector2(rand.Next(0, windowW), windowH), dir, radius);

        }

        void SpawnAsteroid(Vector2 pos, Vector2 dir, float radius)
        {
            Asteroid asteroid = new Asteroid(this, pos, dir);
            asteroid.radius = radius;
            for (int i = 0; i < asteroids.Length; i++)
            {
                if (asteroids[i] == null)
                {
                    asteroids[i] = asteroid;
                    break;
                }
            }
        }


        void DoBulletAsteroidCollision(Bullet bullet, Asteroid asteroid)
        {
            if (bullet == null || asteroid == null)
                return;

            float distance = (bullet.pos - asteroid.pos).Length();
            if (distance < asteroid.radius)
            {

                if (asteroid.radius > 10)
                {
                    SpawnAsteroid(asteroid.pos, asteroid.dir, asteroid.radius / 2);
                    SpawnAsteroid(asteroid.pos, -asteroid.dir, asteroid.radius / 2);
                }

                for (int i = 0; i < bullets.Length; i++)
                {
                    if (bullets[i] == bullet)
                    {
                        bullets[i] = null;
                        break;
                    }
                }

                for (int i = 0; i < asteroids.Length; i++)
                {
                    if (asteroids[i] == asteroid)
                    {
                        asteroids[i] = null;
                        break;
                    }
                }
            }
        }
    }
    
}
