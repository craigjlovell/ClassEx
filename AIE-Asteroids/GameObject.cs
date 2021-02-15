using System;
using System.Collections.Generic;
using System.Text;
using Raylib_cs;
using System.Numerics;

namespace AIE_Asteroids
{
    class GameObject
    {
        public Program program;
        public Vector2 pos = new Vector2();
        public Vector2 direction = new Vector2();

        // A Getter function to calculate our rotation
        public float GetRotation()
        {
            return MathF.Atan2(direction.Y, direction.X);
        }

        public void SetRotation(float rot)
        {
            direction = new Vector2(
                MathF.Cos(rot * (MathF.PI / 180 / .0f)),
                MathF.Sin(rot * (MathF.PI / 180 / .0f)));
        }

        public void Rotate(float amount)
        {
            float rot = GetRotation() + amount;
            SetRotation(rot);
        }





        public GameObject(Program program, Vector2 pos)
        {
            this.program = program;
            this.pos = pos;
        }

        public virtual void Update()
        {

        }

        public virtual void Draw()
        {

        }
    }

}
