
namespace brioche
{
    /// <summary>
    /// Single point of contact (ok a singleton) for dependency injection.
    /// </summary>
    public static class DependencyInjection
    {
        private static IContainTypes _container = null;

        private readonly static object _objectLock = new object();

        public static IContainTypes Container
        {
            get
            {
                if (_container == null)
                {
                    lock (_objectLock)
                    {
                        if (_container == null)
                        {
                            _container = new DefaultTypeContainer();
                        }
                    }
                }

                return _container;
            }
            set
            {
                lock (_objectLock)
                {
                    _container = value;
                }
            }
        }
    }
}
