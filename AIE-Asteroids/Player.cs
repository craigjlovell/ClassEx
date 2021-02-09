using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;
using Raylib_cs;

namespace AIE_Asteroids
{
    class Player
    {

        Program program;

        public Vector2 pos = new Vector2();
        public Vector2 size = new Vector2(64, 64);

        public float rotation = 0.0f;
        public float rotationSpeed = 5.0f;

        public float accspeed = 0.050f;
        public Vector2 Velocity = new Vector2();



        public Player(Program program, Vector2 pos, Vector2 size)
        {
            this.program = program;
            this.pos = pos;
            this.size = size;
        }

        public void Update()
        {
            if (Raylib.IsKeyDown(KeyboardKey.KEY_LEFT))//a
                rotation -= rotationSpeed;

            if (Raylib.IsKeyDown(KeyboardKey.KEY_RIGHT))//d
                rotation += rotationSpeed;

            if(Raylib.IsKeyDown(KeyboardKey.KEY_UP))//w
            {
                var dir = GetFacingDirection();
                Velocity += dir * accspeed;
            }
            if (Raylib.IsKeyDown(KeyboardKey.KEY_DOWN))//d
            {
                var dir = GetFacingDirection();
                Velocity -= dir * accspeed;
            }

            pos += Velocity;

            if (pos.Y > program.windowH) pos.Y = 0;
            if (pos.Y < 0) pos.Y = program.windowH;
            if (pos.X > program.windowW) pos.X = 0;
            if (pos.X < 0) pos.X = program.windowW;

            if(Raylib.IsKeyPressed(KeyboardKey.KEY_SPACE))
            {
                program.SpawnBullet(pos, GetFacingDirection());
            }
        }

        public Vector2 GetFacingDirection ()
        {
            return new Vector2(
                MathF.Cos((MathF.PI / 180) * rotation),
                MathF.Sin((MathF.PI / 180) * rotation)
                
                );
        }


       public void Draw()
        {

            var texture = Assets.shipTexture;

            Raylib.DrawTexturePro(
                texture,
                new Rectangle(0, 0, texture.width, texture.height),
                new Rectangle(pos.X, pos.Y, size.X, size.Y),
                new Vector2(0.5f * size.X, 0.5f * size.Y),
                rotation,
                Color.GOLD);

        }


    }
}
