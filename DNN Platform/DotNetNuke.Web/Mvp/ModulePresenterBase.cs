﻿// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information

#region Usings

using System;
using System.Collections.Generic;
using System.Web.UI;

using DotNetNuke.Common.Internal;
using DotNetNuke.Common.Utilities;
using DotNetNuke.Entities.Modules;
using DotNetNuke.Services.Localization;
using DotNetNuke.UI.Modules;
using DotNetNuke.UI.Skins.Controls;
using DotNetNuke.Web.Validators;

using WebFormsMvp;

#endregion

namespace DotNetNuke.Web.Mvp
{
    [Obsolete("Deprecated in DNN 9.2.0. Replace WebFormsMvp and DotNetNuke.Web.Mvp with MVC or SPA patterns instead. Scheduled removal in v11.0.0.")]
    public abstract class ModulePresenterBase<TView> : Presenter<TView> where TView : class, IModuleViewBase
    {
        #region Constructors

        protected ModulePresenterBase(TView view) : base(view)
        {
            //Try and cast view to Control to get common control properties
            var control = view as Control;
            if (control != null && control.Page != null)
            {
                IsPostBack = control.Page.IsPostBack;
            }

            //Try and cast view to IModuleControl to get the Context
            var moduleControl = view as IModuleControl;
            if (moduleControl != null)
            {
                LocalResourceFile = moduleControl.LocalResourceFile;
                ModuleContext = moduleControl.ModuleContext;
            }
            Validator = new Validator(new DataAnnotationsObjectValidator());

            view.Initialize += InitializeInternal;
            view.Load += LoadInternal;
        }

        #endregion

        #region Protected Properties

        protected internal virtual bool AllowAnonymousAccess
        {
            get
            {
                return true;
            }
        }

        protected internal virtual bool IsUserAuthorized
        {
            get
            {
                return true;
            }
        }

        #endregion

        #region Public Properties

        public bool AutoDataBind { get; set; }

        public ModuleInfo ModuleInfo { get; set; }

        public bool IsEditable { get; set; }

        public bool IsPostBack { get; set; }

        public bool IsSuperUser { get; set; }

        public string LocalResourceFile { get; set; }

        public ModuleInstanceContext ModuleContext { get; set; }

        public int ModuleId { get; set; }

        public int PortalId { get; set; }

        public int TabId { get; set; }

        public int UserId { get; set; }

        public Dictionary<string, string> Settings { get; set; }

        public Validator Validator { get; set; }

        #endregion

        #region Event Handlers

        private void InitializeInternal(object sender, EventArgs e)
        {
            LoadFromContext();
            OnInit();
        }

        private void LoadInternal(object sender, EventArgs e)
        {
            if (CheckAuthPolicy())
            {
                OnLoad();
            }
        }

        #endregion

        #region Protected Methods

        protected internal virtual bool CheckAuthPolicy()
        {
            if ((UserId == Null.NullInteger && !AllowAnonymousAccess))
            {
                OnNoCurrentUser();
                return false;
            }

            if ((!IsUserAuthorized))
            {
                OnUnauthorizedUser();
                return false;
            }

            return true;
        }

        protected virtual void LoadFromContext()
        {
            if (ModuleContext != null)
            {
                ModuleInfo = ModuleContext.Configuration;
                IsEditable = ModuleContext.IsEditable;
                IsSuperUser = ModuleContext.PortalSettings.UserInfo.IsSuperUser;
                ModuleId = ModuleContext.ModuleId;
                PortalId = ModuleContext.PortalId;
                Settings = new Dictionary<string, string>();
                foreach (object key in ModuleContext.Settings.Keys)
                {
                    Settings[key.ToString()] = (string) ModuleContext.Settings[key];
                }
                TabId = ModuleContext.TabId;
                UserId = ModuleContext.PortalSettings.UserInfo.UserID;
            }
        }

        protected virtual string LocalizeString(string key)
        {
            string localizedString;
            if (!string.IsNullOrEmpty(key) && !string.IsNullOrEmpty(LocalResourceFile))
            {
                localizedString = Localization.GetString(key, LocalResourceFile);
            }
            else
            {
                localizedString = Null.NullString;
            }
            return localizedString;
        }

        protected virtual void OnInit()
        {
        }

        protected virtual void OnLoad()
        {
        }

        protected virtual void OnNoCurrentUser()
        {
            RedirectToLogin();
        }

        protected virtual void OnUnauthorizedUser()
        {
            RedirectToAccessDenied();
        }

        protected void RedirectToAccessDenied()
        {
            Response.Redirect(TestableGlobals.Instance.AccessDeniedURL(), true);
        }

        protected void RedirectToCurrentPage()
        {
            Response.Redirect(TestableGlobals.Instance.NavigateURL(), true);
        }

        protected void RedirectToLogin()
        {
            Response.Redirect(TestableGlobals.Instance.LoginURL(Request.RawUrl, false), true);
        }

        protected void ProcessModuleLoadException(Exception ex)
        {
            View.ProcessModuleLoadException(ex);
        }

        protected void ShowMessage(string messageHeader, string message, ModuleMessage.ModuleMessageType messageType)
        {
            ShowMessage(messageHeader, message, messageType, true);
        }

        protected void ShowMessage(string message, ModuleMessage.ModuleMessageType messageType)
        {
            ShowMessage(message, messageType, true);
        }

        protected void ShowMessage(string message, ModuleMessage.ModuleMessageType messageType, bool localize)
        {
            ShowMessage(string.Empty, message, messageType, localize);
        }

        protected void ShowMessage(string messageHeader, string message, ModuleMessage.ModuleMessageType messageType, bool localize)
        {
            if (!string.IsNullOrEmpty(message))
            {
                if (localize)
                {
                    messageHeader = LocalizeString(messageHeader);
                    message = LocalizeString(message);
                }
                View.ShowMessage(messageHeader, message, messageType);
            }
        }

        #endregion

        #region Public Methods

        public virtual void RestoreState(StateBag stateBag)
        {
            AttributeBasedViewStateSerializer.DeSerialize(this, stateBag);
        }

        public virtual void SaveState(StateBag stateBag)
        {
            AttributeBasedViewStateSerializer.Serialize(this, stateBag);
        }

        #endregion
    }
}
