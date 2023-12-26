public struct Indicator
{
    public double number;
    public string name;
    public string unit_measure;
    public double value;

    public Indicator(double number, string name, string unit_measure, double value)
    {
        this.number = number;
        this.name = name;
        this.unit_measure = unit_measure;
        this.value = value;
    }
}