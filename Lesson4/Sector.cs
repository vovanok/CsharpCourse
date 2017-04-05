using System;

namespace Lesson4
{
    class Sector : Shape, IGivableRadius
    {
        private float radius;
        private float angleGrad;

        public override string Name
        {
            get { return "Сектор"; }
        }

        public float Radius
        {
            get { return radius; }
        }

        public Sector(float radius, float angleGrad)
        {
            this.radius = radius;
            this.angleGrad = angleGrad;
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
