using System;

class Forecast
{
    
    public static double PredictFutureValue(double iniamount, double growthRate, int years)
    {
        if (years == 0)
        {
            return iniamount;
        }

        return PredictFutureValue(iniamount * (1 + growthRate), growthRate, years - 1);
    }

    static void Main(string[] args)
    {
        double startingAmount = 2000;        
        double annualGrowthRate = 0.14;       
        int yearsToForecast = 5;

        double futureValue = PredictFutureValue(startingAmount, annualGrowthRate, yearsToForecast);

        Console.WriteLine($"Future value after {yearsToForecast} years: ₹{futureValue:F2}");
    }
}
