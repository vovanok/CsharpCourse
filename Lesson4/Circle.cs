using System;

namespace Lesson4
{
    class Circle : Shape
    {
        private float radius;

        public Circle(float radius)
        {
            this.radius = radius;
        }

        public override string GetName()
        {
            return "Круг";
        }

        public override float GetArea()
        {
            return (float)(Math.PI * Math.Pow(radius, 2));
        }

        public override float GetPerimeter()
        {
            return (float)(2f * Math.PI * radius);
        }
    }
}
