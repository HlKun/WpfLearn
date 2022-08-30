using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPattern
{
    public class Singleton
    {
        private Singleton() { }

        private static readonly object locker = new object();
        private static Singleton _instance;

        // without lock
        public static Singleton GetSingleton()
        {
            if (_instance == null)
                _instance = new Singleton();

            return _instance;
        }

        // with one lock
        public static Singleton GetSingletonWithOneLock()
        {
            lock (locker)
            {
                if (_instance == null)
                    _instance = new Singleton();
            }

            return _instance;
        }

        // with double lock
        public static Singleton GetSingletonWithDoubleLock()
        {
            if (_instance == null)
            {
                lock (locker)
                {
                    if (_instance == null)
                        _instance = new Singleton();
                }
            }

            return _instance;
        }
    }
}
