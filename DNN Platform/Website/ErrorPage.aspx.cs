﻿// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information

#region Usings

using System;
using System.Web;
using System.Web.UI;

using DotNetNuke.Common.Utilities;
using DotNetNuke.Entities.Portals;
using DotNetNuke.Security;
using DotNetNuke.Services.FileSystem;

#endregion

// ReSharper disable CheckNamespace
namespace DotNetNuke.Services.Exceptions
// ReSharper restore CheckNamespace
{
    /// -----------------------------------------------------------------------------
    /// Project	 : DotNetNuke
    /// Class	 : ErrorPage
    /// 
    /// -----------------------------------------------------------------------------
    /// <summary>
    /// Trapped errors are redirected to this universal error page, resulting in a 
    /// graceful display.
    /// </summary>
    /// <remarks>
    /// 'get the last server error
    /// 'process this error using the Exception Management Application Block
    /// 'add to a placeholder and place on page
    /// 'catch direct access - No exception was found...you shouldn't end up here unless you go to this aspx page URL directly
    /// </remarks>
    /// -----------------------------------------------------------------------------
    public partial class ErrorPage : Page
    {
        private void ManageError(string status)
        {
            string errorMode = Config.GetCustomErrorMode();

            string errorMessage = HttpUtility.HtmlEncode(Request.QueryString["error"]);
            string errorMessage2 = HttpUtility.HtmlEncode(Request.QueryString["error2"]);
            string localizedMessage = Localization.Localization.GetString(status + ".Error", Localization.Localization.GlobalResourceFile);
            if (localizedMessage != null)
            {
                localizedMessage = localizedMessage.Replace("src=\"images/403-3.gif\"", "src=\"" + ResolveUrl("~/images/403-3.gif") + "\"");

                if (!string.IsNullOrEmpty(errorMessage2) && ( (errorMode=="Off") || ( (errorMode=="RemoteOnly") && (Request.IsLocal) ) ))
                {
                    ErrorPlaceHolder.Controls.Add(new LiteralControl(string.Format(localizedMessage, errorMessage2)));
                }
                else
                {
                    ErrorPlaceHolder.Controls.Add(new LiteralControl(string.Format(localizedMessage, errorMessage)));
                }
            }

            int statusCode;
            Int32.TryParse(status, out statusCode);

            if (statusCode > -1)
            {
                Response.StatusCode = statusCode;
            }
        }

        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
            DefaultStylesheet.Attributes["href"] = ResolveUrl("~/Portals/_default/default.css");
            InstallStylesheet.Attributes["href"] = ResolveUrl("~/Install/install.css");
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            var portalSettings = PortalController.Instance.GetCurrentPortalSettings();
            if (portalSettings != null && !String.IsNullOrEmpty(portalSettings.LogoFile))
            {
                IFileInfo fileInfo = FileManager.Instance.GetFile(portalSettings.PortalId, portalSettings.LogoFile);
                if (fileInfo != null)
                {
                    headerImage.ImageUrl = FileManager.Instance.GetUrl(fileInfo);
                }
            }
            headerImage.Visible = !string.IsNullOrEmpty(headerImage.ImageUrl);

            string localizedMessage;
            var security = PortalSecurity.Instance;
            var status = security.InputFilter(Request.QueryString["status"],
                                                    PortalSecurity.FilterFlag.NoScripting |
                                                    PortalSecurity.FilterFlag.NoMarkup);
            if (!string.IsNullOrEmpty(status))
            {
                ManageError(status);
            }
            else
            {
                //get the last server error
                var exc = Server.GetLastError();
                try
                {
                    if (Request.Url.LocalPath.ToLowerInvariant().EndsWith("installwizard.aspx"))
                    {
                        ErrorPlaceHolder.Controls.Add(new LiteralControl(HttpUtility.HtmlEncode(exc.ToString())));
                    }
                    else
                    {
                        var lex = new PageLoadException(exc.Message, exc);
                        Exceptions.LogException(lex);
                        localizedMessage = Localization.Localization.GetString("Error.Text", Localization.Localization.GlobalResourceFile);
                        ErrorPlaceHolder.Controls.Add(new ErrorContainer(portalSettings, localizedMessage, lex).Container);
                    }
                }
                catch
                {
                    //No exception was found...you shouldn't end up here
                    //unless you go to this aspx page URL directly
                    localizedMessage = Localization.Localization.GetString("UnhandledError.Text", Localization.Localization.GlobalResourceFile);
                    ErrorPlaceHolder.Controls.Add(new LiteralControl(localizedMessage));
                }

                Response.StatusCode = 500;
            }
            localizedMessage = Localization.Localization.GetString("Return.Text", Localization.Localization.GlobalResourceFile);

            hypReturn.Text = localizedMessage;
        }
    }
}
