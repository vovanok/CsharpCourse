namespace Lesson4
{
    class Rectangle : Shape
    {
        private float width;
        private float height;

        public Rectangle(float width, float height)
        {
            this.width = width;
            this.height = height;
        }

        public override string GetName()
        {
            return "Прямоугольник";
        }

        public override float GetArea()
        {
            return width * height;
        }

        public override float GetPerimeter()
        {
            return width + height;
        }
    }
}
