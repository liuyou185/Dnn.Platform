﻿// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information

using System;
using System.Net.Http;
using DotNetNuke.Entities.Modules;
using DotNetNuke.Security;
using DotNetNuke.Security.Permissions;

namespace DotNetNuke.Web.Api
{
    public class DnnModuleAuthorizeAttribute : AuthorizeAttributeBase, IOverrideDefaultAuthLevel
    {
        public DnnModuleAuthorizeAttribute()
        {
            AccessLevel = SecurityAccessLevel.Host;
        }

        public string PermissionKey { get; set; }
        public SecurityAccessLevel AccessLevel { get; set; }

        public override bool IsAuthorized(AuthFilterContext context)
        {
            var activeModule = FindModuleInfo(context.ActionContext.Request);

            if (activeModule != null)
            {
                return ModulePermissionController.HasModuleAccess(AccessLevel, PermissionKey, activeModule);
            }

            return false;
        }

        protected virtual ModuleInfo FindModuleInfo(HttpRequestMessage request)
        {
            return request.FindModuleInfo();
        }
    }
}
