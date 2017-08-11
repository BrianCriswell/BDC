using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BDC.CSharp_Objects
{
    public class Probability
    {
        /// <summary>
        /// Calculates the probability that exactly x successes will occur in n trials.
        /// </summary>
        /// <param name="n">The total number of trials.</param>
        /// <param name="x">The required number of successes.</param>
        /// <param name="p">The probability of success in 1 trial.</param>
        /// <returns>The probability of x successes occurring in n trials.</returns>
        public static double BinomialProbability(int n, int x, double p)
        {
            if (n < 0)
            {
                throw new InvalidOperationException("'n' must be greater than 0.");
            }
            else if (x < 0 || x > n)
            {
                throw new InvalidOperationException("'x' must be between 0 and 'n' inclusive.");
            }
            else if (p < 0.0d || p > 1.0d)
            {
                throw new InvalidOperationException("'p' must be between 0.0 and 1.0 inclusive.");
            }

            return Combination(n, x) * Math.Pow(p, x) * Math.Pow(1 - p, n - x);
        }

        /// <summary>
        /// Calculates the number of distinct combinations of k elements out of a total n elements.
        /// </summary>
        /// <param name="n">The total number of elements.</param>
        /// <param name="k">The number of elements in a combination.</param>
        /// <returns>
        /// The number of distinct combinations of k elements out of a total n elements.
        /// </returns>
        public static double Combination(int n, int k)
        {
            if(n <= 0)
            {
                throw new InvalidOperationException("'n' must be greater than 0.");
            }
            else if (k < 0 || k > n)
            {
                throw new InvalidOperationException("'k' must be between 0 and 'n' inclusive.");
            }

            double numerator = 1.0d;
            double denominator = 1.0d;

            for (int i = k + 1; i <= n; i++)
            {
                numerator *= i;
            }

            for (int i = 2; i <= n - k; i++)
            {
                denominator *= i;
            }

            return numerator / denominator;
        }
    }
}
