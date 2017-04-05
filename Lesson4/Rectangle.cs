namespace Lesson4
{
    class Rectangle : Shape
    {
        private float width;
        private float height;

        public override string Name
        {
            get { return "Прямоугольник"; }
        }

        public Rectangle(float width, float height)
        {
            this.width = width;
            this.height = height;
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
