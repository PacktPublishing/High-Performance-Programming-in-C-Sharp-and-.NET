using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CH04_WeakReferences
{
    /// <summary>
    /// Measures the execution of actions.
    /// </summary>
    internal static class Instrumentation
    {
        /// <summary>
        /// Measures the minimum, average, and maximum ticks it takes to
        /// iterate x amount of times and perform the past in action.
        /// </summary>
        /// <param name="description">The description of what is being measured.</param>
        /// <param name="repetitions">How many times the action will be performed.</param>
        /// <param name="action">The action to be performed.</param>
        public static void Measure(string description, int repetitions, Action action)
        {
            Stopwatch stopwatch = new Stopwatch();
            WarmUp(action);
            double[] results = new double[repetitions];
            for(var repetition = 0; repetition < repetitions; repetition++)
            {
                stopwatch.Restart();
                action();
                results[repetition] = stopwatch.ElapsedTicks;
            }
            Console.WriteLine($"{description}");
            Console.WriteLine($"- Minimum Ticks: {results.Min()}");
            Console.WriteLine($"- Average Ticks: {results.Average()}");
            Console.WriteLine($"- Maximum Ticks: {results.Max()}");
        }

        /// <summary>
        /// The first operation may take some time due to initial warm up. And so
        /// we don't measure it. It will simply be discarded.
        /// </summary>
        /// <param name="action">The action to warm up.</param>
        private static void WarmUp(Action action)
        {
            action();
        }
    }
}
