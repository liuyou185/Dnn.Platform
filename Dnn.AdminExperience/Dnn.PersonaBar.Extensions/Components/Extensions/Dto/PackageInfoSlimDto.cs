﻿// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information

#region Usings

using DotNetNuke.Common.Utilities;
using DotNetNuke.Entities.Portals;
using DotNetNuke.Services.Authentication;
using DotNetNuke.Services.Installer.Packages;
using Newtonsoft.Json;

#endregion

namespace Dnn.PersonaBar.Extensions.Components.Dto
{
    [JsonObject]
    public class PackageInfoSlimDto
    {
        [JsonProperty("packageId")]
        public int PackageId { get; set; }

        [JsonProperty("friendlyName")]
        public string FriendlyName { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("fileName")]
        public string FileName { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("version")]
        public string Version { get; set; }

        [JsonProperty("inUse")]
        public string IsInUse { get; set; }

        [JsonProperty("upgradeUrl")]
        public string UpgradeUrl { get; set; }

        [JsonProperty("upgradeIndicator")]
        public string UpgradeIndicator { get; set; }

        [JsonProperty("packageIcon")]
        public string PackageIcon { get; set; }

        [JsonProperty("canDelete")]
        public bool CanDelete { get; set; }

        [JsonProperty("readOnly")]
        public bool ReadOnly { get; set; }

        public PackageInfoSlimDto()
        {

        }

        public PackageInfoSlimDto(int portalId, PackageInfo package)
        {
            PackageId = package.PackageID;
            FriendlyName = package.FriendlyName;
            Name = package.Name;
            FileName = package.FileName;
            Description = package.Description;
            Version = package.Version.ToString(3);
            IsInUse = ExtensionsController.IsPackageInUse(package, portalId);
            UpgradeUrl = ExtensionsController.UpgradeRedirect(package.Version, package.PackageType, package.Name);
            UpgradeIndicator = ExtensionsController.UpgradeIndicator(package.Version, package.PackageType, package.Name);
            PackageIcon = ExtensionsController.GetPackageIcon(package);
            CanDelete = package.PackageID != Null.NullInteger && !package.IsSystemPackage && PackageController.CanDeletePackage(package, PortalSettings.Current);

            if (package.PackageID != Null.NullInteger)
            {
                var authService = AuthenticationController.GetAuthenticationServiceByPackageID(PackageId);
                ReadOnly = authService != null && authService.AuthenticationType == Constants.DnnAuthTypeName;
            }
        }
    }
}
