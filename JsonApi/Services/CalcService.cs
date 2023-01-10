using static JsonApi.Message.CalcMessage;
namespace JsonApi.Services

{
    public class CalcService
    {
        public static CalcOutput SolutionEquation(CalcInput input)
        {
            CalcOutput output = null;
            double a = input.a;
            double b = input.b;
            double c = input.c;
            if ((b*b-4*a*c) >= 0) //Если дискриминант больше или равен 0
            {
                double x1 = (-b + Math.Sqrt(b * b - 4 * a * c)) / (2 * a);
                double x2 = (-b - Math.Sqrt(b * b - 4 * a * c)) / (2 * a);
                output = new CalcOutput(true,x1, x2);
                return output;
            }
            else
            {
                return new CalcOutput(false,0,0);
            }
        }
    }
}
