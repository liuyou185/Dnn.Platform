﻿// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information

using System;
using System.Web.UI;
using DotNetNuke.Entities.Modules;
using DotNetNuke.Framework;

namespace DotNetNuke.UI.Modules
{
    public class ReflectedModuleControlFactory : BaseModuleControlFactory
    {
        public override Control CreateControl(TemplateControl containerControl, string controlKey, string controlSrc)
        {
            // load from a typename in an assembly ( ie. server control)
            var objType = Reflection.CreateType(controlSrc);
            return (containerControl.LoadControl(objType, null));
        }

        public override Control CreateModuleControl(TemplateControl containerControl, ModuleInfo moduleConfiguration)
        {
            return CreateControl(containerControl, String.Empty, moduleConfiguration.ModuleControl.ControlSrc);
        }

        public override Control CreateSettingsControl(TemplateControl containerControl, ModuleInfo moduleConfiguration, string controlSrc)
        {
            return CreateControl(containerControl, String.Empty, controlSrc);
        }
    }
}
