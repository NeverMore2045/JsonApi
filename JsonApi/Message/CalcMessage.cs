namespace JsonApi.Message
{
    public class CalcMessage
    {
        public record CalcInput(double a, double b, double c);
        public record CalcOutput(double x1, double x2);
    }
}
