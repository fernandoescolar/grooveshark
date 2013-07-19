using System;
using System.Linq;
using System.Net;
using GrooveSharp.Protocol;

namespace GrooveSharp
{
    internal static class PlatformExtensions
    {
        internal static bool HasAttribute(this Type theType, Type attributeType)
        {
            var attributes = theType.GetCustomAttributes(false);
            return attributes.Any(attribute => attribute.GetType() == attributeType);
        }

        internal static void PrepareEnviroment(this ISession session)
        {
            ServicePointManager.Expect100Continue = true;
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Ssl3;
            ServicePointManager.ServerCertificateValidationCallback = delegate { return true; };
        }
    }
}
