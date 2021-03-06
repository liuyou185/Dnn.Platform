﻿// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information

using System;

namespace DotNetNuke.Services.Connections
{
    public class ConnectorArgumentException : ApplicationException
    {
        public ConnectorArgumentException()
        {
            
        }

        public ConnectorArgumentException(string message) : base(message)
        {
            
        }

        public ConnectorArgumentException(string message, Exception innerException) : base(message, innerException)
        {

        }
    }
}
