namespace Lesson4
{
    public class Shape
    {
        public virtual string GetName()
        {
            return "Я какая то неопределенная фигура";
        }

        public virtual float GetArea()
        {
            return 0;
        }

        public virtual float GetPerimeter()
        {
            return 0;
        }
    }
}
