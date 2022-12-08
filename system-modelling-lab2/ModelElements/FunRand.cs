using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace system_modelling_lab2.ModelElements;

public class FunRand
{
    /**
    * Generates a random value according to an exponential
        distribution
    *
    * @param timeMean mean value
    * @return a random value according to an exponential
        distribution
    */
    public static double Exp(double timeMean)
    {
        double a = 0;
        Random r = new Random();
        while (a == 0)
        {
            a = r.NextDouble();
        }
        a = -timeMean * Math.Log(a);
        return a;
    }
    /**
    * Generates a random value according to a uniform
        distribution
    *
    * @param timeMin
    * @param timeMax
    * @return a random value according to a uniform distribution
    */
    public static double Unif(double timeMin, double timeMax)
    {
        double a = 0;
        Random r = new Random();
        while (a == 0)
        {
            a = r.NextDouble();
        }
        a = timeMin + a * (timeMax - timeMin);
        return a;
    }
    /**
    * Generates a random value according to a normal (Gauss)
        distribution
    *
    * @param timeMean
    * @param timeDeviation
    * @return a random value according to a normal (Gauss)
        distribution
    */
    public static double Norm(double timeMean, double
    timeDeviation)
    {
        double a;
        Random r = new Random();
        double u1 = 1.0 - r.NextDouble();
        double u2 = 1.0 - r.NextDouble();
        double randStdNormal = Math.Sqrt(-2.0 * Math.Log(u1)) *
                     Math.Sin(2.0 * Math.PI * u2);
        a = timeMean + timeDeviation * randStdNormal;
        return a;
    }
}
