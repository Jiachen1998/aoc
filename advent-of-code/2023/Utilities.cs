namespace aoc._2023
{
    internal static class Utilities
    {
        internal static List<string> StringToLines(string str)
        {
            return str.Split("\r\n").ToList();
        }

        /// <summary>
        /// Iteration to calculate LCM of multiple numbers
        /// </summary>
        /// <param name="numbers"></param>
        /// <returns></returns>
        internal static long CalculateLcmMultiple(long[] nums)
        {
            long lcm = nums[0];
            for (int i = 1; i < nums.Length; i++)
            {
                lcm = CalculateLcm(lcm, nums[i]);
            }
            return lcm;
        }

        /// <summary>
        /// Formula to calculate LCM of two numbers
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        internal static long CalculateLcm(long a, long b)
        {
            return a / CalculateGcd(a, b) * b;
        }

        /// <summary>
        /// Formula to calculate GCD
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        internal static long CalculateGcd(long a, long b)
        {
            while (b != 0)
            {
                long temp = b;
                b = a % b;
                a = temp;
            }
            return a;
        }
    }
}
