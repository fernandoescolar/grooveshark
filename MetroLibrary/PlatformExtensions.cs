using System;
using System.Reflection;
using GrooveSharp.Protocol;

namespace GrooveSharp
{
    internal static class PlatformExtensions
    {
        internal static bool HasAttribute(this Type theType, Type attributeType)
        {
            return theType.GetTypeInfo().GetCustomAttribute(attributeType) != null;
        }

        internal static void PrepareEnviroment(this ISession session)
        {
        }
    }
}
