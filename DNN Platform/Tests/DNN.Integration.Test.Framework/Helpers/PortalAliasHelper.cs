﻿// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information

using System.Collections.Generic;
using System.Linq;
using DotNetNuke.Entities.Portals;

namespace DNN.Integration.Test.Framework.Helpers
{
    public class PortalAliasHelper
    {
        public static PortalAliasInfo GetPrimaryPortalAlias(int portalId = 0)
        {
            return DatabaseHelper.ExecuteStoredProcedure<PortalAliasInfo>("GetPortalAliases").First(p => p.PortalID == portalId && p.IsPrimary);
        }

        public static IEnumerable<PortalAliasInfo> GetPortalAliaes(int portalId = 0)
        {
            return DatabaseHelper.ExecuteStoredProcedure<PortalAliasInfo>("GetPortalAliases").Where(p => p.PortalID == portalId);
        }

        public static IEnumerable<PortalAliasInfo> GetAllPortalAliaes()
        {
            return DatabaseHelper.ExecuteStoredProcedure<PortalAliasInfo>("GetPortalAliases");
        }

        public static void AddPortalAlias(PortalAliasInfo portal)
        {
            DatabaseHelper.ExecuteStoredProcedure("AddPortalAlias",
                portal.PortalID,
                portal.HTTPAlias,
                portal.CultureCode,
                portal.Skin,
                portal.BrowserType,
                portal.IsPrimary,
                -1);
        }
    }
}
