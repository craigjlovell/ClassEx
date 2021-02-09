using System;
using System.Collections.Generic;
using System.Text;
using System.Numerics;
using Raylib_cs;


namespace AIE_Asteroids
{
    class Asteroid
    {
        Program program;

        public Vector2 pos = new Vector2();
        public Vector2 dir = new Vector2();
        public float radious = 40;


        public Asteroid(Program program, Vector2 pos, Vector2 dir)
        {
            this.program = program;

            this.pos = pos;
            this.dir = dir;


        }

        public void Update()
        {

            pos += dir;

            if (pos.Y > program.windowH) pos.Y = 0;
            if (pos.Y < 0) pos.Y = program.windowH;
            if (pos.X > program.windowW) pos.X = 0;
            if (pos.X < 0) pos.X = program.windowW;

        }


        public void Draw()
        {


            Raylib.DrawCircleLines((int)pos.X, (int)pos.Y, radious, Color.WHITE);
        }

    }
}
