namespace Epiphany.Core
{
    public abstract class ResettableLazy<T> where T : class, new()
    {
        protected static Auto<T> Lazy { get; private set; }

        static ResettableLazy()
        {
            Lazy = new Auto<T>(() => new T());
        }

        public static T Instance
        {
            get
            {
                return Lazy.Value;
            }
        }
    }
}