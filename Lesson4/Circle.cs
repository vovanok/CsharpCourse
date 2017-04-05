namespace Lesson4
{
    class Circle : Sector
    {
        private const float CIRCLE_ANGLE = 360;

        public override string Name
        {
            get
            {
                return "Круг";
            }
        }

        public Circle(float radius)
            : base(radius, CIRCLE_ANGLE)
        {
        }
    }
}
