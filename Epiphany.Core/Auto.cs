using System;
using System.Security.Permissions;
using System.Threading;

namespace Epiphany.Core
{
    [HostProtection(Action = SecurityAction.LinkDemand, Resources = HostProtectionResource.Synchronization | HostProtectionResource.SharedState)]
    public class Auto<T> where T : class
    {
        public Auto(Func<T> create, LazyThreadSafetyMode safetyMode = LazyThreadSafetyMode.ExecutionAndPublication)
        {
            _syncRoot = new object();
            ThreadSafety = safetyMode;
            Create = create;
        }

        protected LazyThreadSafetyMode ThreadSafety { get; private set; }
        protected Func<T> Create { get; private set; }
        private readonly object _syncRoot;

        public T Value
        {
            get
            {
                if (_value == null)
                {
                    switch (ThreadSafety)
                    {
                        case LazyThreadSafetyMode.PublicationOnly:
                            var value = Create();
                            lock (_syncRoot)
                            {
                                if (_value == null)
                                {
                                    _value = value;
                                }
                            }
                            break;

                        case LazyThreadSafetyMode.ExecutionAndPublication:
                            lock (_syncRoot)
                            {
                                if (_value == null)
                                {
                                    _value = Create();
                                }
                            }
                            break;

                        default:
                            _value = Create();
                            break;
                    }
                }
                return _value;
            }
        }

        private T _value;

        public bool IsValueCreated
        {
            get { return _value != null; }
        }

        public void ResetValue()
        {
            if (ThreadSafety != LazyThreadSafetyMode.None)
            {
                lock (_syncRoot)
                {
                    _value = null;
                }
            }
            else
            {
                _value = null;
            }
        }
    }
}