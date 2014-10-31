using System;
using System.Reflection;

namespace Xoqal.Utilities.Resource
{
    /// <summary>
    /// Helps to resolve the resource keys.
    /// </summary>
    public class ResourceHelper
    {
        /// <summary>
        /// Gets the resource value.
        /// </summary>
        /// <param name="resourceTypeName"> Name of the resource type. </param>
        /// <param name="name"> The name. </param>
        /// <returns> </returns>
        public static string GetResourceValue(string resourceTypeName, string name)
        {
            return GetResourceValue(Type.GetType(resourceTypeName), name);
        }

        /// <summary>
        /// Gets the resource value.
        /// </summary>
        /// <param name="resourceType"> Type of the resource. </param>
        /// <param name="name"> The name. </param>
        /// <returns> </returns>
        public static string GetResourceValue(Type resourceType, string name)
        {
            var property = resourceType.GetProperty(name, BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Static);
            return property != null ? property.GetValue(null, null).ToString() : string.Empty;
        }
    }
}
