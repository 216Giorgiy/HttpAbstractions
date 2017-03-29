// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;
using System.Reflection;

namespace Microsoft.AspNetCore.Authentication
{
    /// <summary>
    /// AuthenticationSchemes are basically a name for a specific <see cref="IAuthenticationHandler"/>
    /// handlerType.
    /// </summary>
    public class AuthenticationScheme
    {
        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="name">The name for the authentication scheme.</param>
        /// <param name="handlerType">The <see cref="IAuthenticationHandler"/> type that handles this scheme.</param>
        public AuthenticationScheme(string name, Type handlerType)
        {
            if (name == null)
            {
                throw new ArgumentNullException(nameof(name));
            }
            if (handlerType == null)
            {
                throw new ArgumentNullException(nameof(handlerType));
            }
            if (!typeof(IAuthenticationHandler).IsAssignableFrom(handlerType))
            {
                throw new ArgumentException("handlerType must implement IAuthenticationSchemeHandler.");
            }

            Name = name;
            HandlerType = handlerType;
        }

        // TODO: add display name?
        /// <summary>
        /// The name of the authentication scheme.
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// The <see cref="IAuthenticationHandler"/> type that handles this scheme.
        /// </summary>
        public Type HandlerType { get; }
    }
}
