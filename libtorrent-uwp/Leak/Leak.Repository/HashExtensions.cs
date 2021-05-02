using System;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography;

namespace Leak.Data.Store
{
    public static class HashExtensions
    {
        private static readonly MethodInfo hashCore;
        private static readonly MethodInfo hashFinal;

        static HashExtensions()
        {
            Type target = typeof(HashAlgorithm);
            BindingFlags flags = BindingFlags.Instance | BindingFlags.NonPublic;

            hashCore = target.GetMethods(flags)
                .Where(x => x.Name == "HashCore" && x.IsAbstract)
                .FirstOrDefault();
            hashFinal = target.GetMethod("HashFinal", flags);
        }

        public static void Push(this HashAlgorithm algorithm, byte[] data, int offset, int count)
        {
            //try
            //{
                hashCore.Invoke(algorithm, new object[] { data, offset, count });
            //}
            //catch (Exception ex)
            //{
            //    Debug.WriteLine("Hash Exception: " + ex.Message);
            //}
        }

        public static byte[] Complete(this HashAlgorithm algorithm)
        {
            return (byte[])hashFinal.Invoke(algorithm, new object[] { });
        }
    }
}