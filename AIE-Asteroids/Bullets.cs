using System;
using System.Collections.Generic;
using System.Text;
using System.Numerics;
using Raylib_cs;

namespace AIE_Asteroids
{
    class Bullet
    {
        Program program;

        public Vector2 pos = new Vector2();
        public Vector2 dir = new Vector2();
        public float speed = 10;



        public Bullet(Program program, Vector2 pos, Vector2 dir)
        {
            this.program = program;
            this.pos = pos;
            this.dir = dir;

        }

        public void Update()
        {
            pos += dir * speed;

            if (pos.Y > program.windowH) pos.Y = 0;
            if (pos.Y < 0) pos.Y = program.windowH;
            if (pos.X > program.windowW) pos.X = 0;
            if (pos.X < 0) pos.X = program.windowW;
        }

        public void Draw()
        {
            Random rand = new Random();
            Color col = new Color(
               rand.Next(0, 255), // rand red value
               rand.Next(0, 255), // random green value
               rand.Next(0, 255), // random blue value
               255); // alpha

            Raylib.DrawLine((int)pos.X, (int)pos.Y, (int)(pos.X - dir.X * speed), (int)(pos.Y - dir.Y * speed), col);

        }
    }
}
