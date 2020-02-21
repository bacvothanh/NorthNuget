using System.Collections.Generic;

namespace NN.Standard.Common.Extensions
{
    public static class ListExtension
    {
        /// <summary>
        /// Separate group become many small groups in dictionary
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="values"></param>
        /// <param name="maxNumberInGroup"></param>
        /// <param name="maxGroup"></param>
        /// <returns></returns>
        public static Dictionary<int, IList<T>> Group<T>(this IList<T> values, int maxNumberInGroup = 4, int? maxGroup = null)
        {
            var index = 0;
            var result = new Dictionary<int, IList<T>>();
            foreach (var value in values)
            {
                if (result.ContainsKey(index))
                {
                    if (result[index].Count + 1 > maxNumberInGroup)
                    {
                        index++;
                        result.Add(index, new List<T> { value });
                    }
                    else
                    {
                        result[index].Add(value);
                    }
                }
                else
                {
                    result.Add(index, new List<T> {value});
                }

                if (maxGroup.HasValue && index == maxGroup && result[index].Count >= maxNumberInGroup)
                {
                    return result;
                }
            }

            return result;
        }
    }
}
