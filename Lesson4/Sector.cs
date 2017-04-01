using System;

namespace Lesson4
{
    class Sector : Shape
    {
        private float radius;
        private float angleGrad;

        public Sector(float radius, float angleGrad)
        {
            this.radius = radius;
            this.angleGrad = angleGrad;
        }

        public override string GetName()
        {
            return "Сектор";
        }

        public override float GetArea()
        {
            return (float)(Math.PI * Math.Pow(radius, 2)) * (angleGrad / 360);
        }

        public override float GetPerimeter()
        {
            return (float)(2f * Math.PI * radius) * (angleGrad / 360);
        }
    }
}
