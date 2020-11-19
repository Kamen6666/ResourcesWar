using System;
namespace Utilty
{
    public class Singleton<T>
    {
        private static T instance;
        public static T GetInstance()
        {
            if (instance == null)
            {
                //反射new一个私有构造函数(非公有为true)
                instance = (T)Activator.CreateInstance(typeof(T), true);
            }
            return instance;
        }
    }
}