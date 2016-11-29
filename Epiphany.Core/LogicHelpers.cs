using System;

namespace Epiphany.Core
{
    public static class LogicHelpers
    {
        /// <summary>
        ///     Returns the element if the predicate is true, the Type default otherwise.
        /// </summary>
        public static T If<T>(this T element, bool condition)
        {
            var output = condition
                ? element
                : default(T);

            return output;
        }

        /// <summary>
        ///     Returns the element if the object is not null, the Type default otherwise.
        /// </summary>
        public static T IfNotNull<T>(this T element, object obj)
        {
            return element.If(obj != null);
        }

        /// <summary>
        ///     Returns the element if the predicate is true, the Type default otherwise.
        /// </summary>
        public static T If<T>(this Func<T> func, bool condition)
        {
            var output = condition
                ? func.Invoke()
                : default(T);

            return output;
        }

        /// <summary>
        ///     Invoke the predicate and returns its return value if the object is not null.
        /// </summary>
        public static T IfNotNullThen<T>(this object @object, Func<T> predicate)
        {
            return (@object != null).IfTrueThen(predicate);
        }

        /// <summary>
        ///     Invoke the predicate and returns its return value if the string is not null or whitespace.
        /// </summary>
        public static T IfNotNullOrWhitespaceThen<T>(this string s, Func<T> predicate)
        {
            return (!string.IsNullOrWhiteSpace(s)).IfTrueThen(predicate);
        }

        /// <summary>
        ///     Invoke the predicate and returns its return value if the object is not null.
        /// </summary>
        public static void IfNotNullThen(this object @object, Action predicate)
        {
            (@object != null).IfTrueThen(predicate);
        }

        /// <summary>
        ///     Invoke the predicate and returns its return value if the condition is true.
        /// </summary>
        public static T IfTrueThen<T>(this bool condition, Func<T> predicate)
        {
            var output = condition
                ? predicate.Invoke()
                : default(T);

            return output;
        }

        /// <summary>
        ///     Invoke the predicate and returns its return value if the condition is true.
        /// </summary>
        public static void IfTrueThen(this bool condition, Action predicate)
        {
            if (condition)
            {
                predicate.Invoke();
            }
        }
    }
}