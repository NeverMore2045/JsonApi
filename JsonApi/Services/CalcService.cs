using static JsonApi.Message.CalcMessage;
namespace JsonApi.Services

{
    public class CalcService
    {
        public CalcOutput SolutionEquation(CalcInput input)
        {
            CalcOutput output = null;
            double a = input.a;
            double b = input.b;
            double c = input.c;
            if ((b*b-4*a*c) >= 0) //Если дискриминант больше или равен 0
            {
                double x1 = (-1 * b + Math.Sqrt(((b * b - 4 * a * c))) / (2 * a));
                double x2 = (-1 * b - Math.Sqrt(((b * b - 4 * a * c))) / (2 * a));
                output = new CalcOutput(x1, x2);
            }
            return output;
        }
    }
}
