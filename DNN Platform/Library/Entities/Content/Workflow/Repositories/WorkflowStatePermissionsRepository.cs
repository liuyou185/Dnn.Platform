﻿// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information

using System;
using System.Collections.Generic;
using DotNetNuke.Common.Utilities;
using DotNetNuke.Data;
using DotNetNuke.Entities.Content.Workflow.Entities;
using DotNetNuke.Framework;

namespace DotNetNuke.Entities.Content.Workflow.Repositories
{
    internal class WorkflowStatePermissionsRepository : ServiceLocator<IWorkflowStatePermissionsRepository, WorkflowStatePermissionsRepository>, IWorkflowStatePermissionsRepository
    {
        #region Public Methods
        public IEnumerable<WorkflowStatePermission> GetWorkflowStatePermissionByState(int stateId)
        {
            return CBO.FillCollection<WorkflowStatePermission>(DataProvider.Instance().GetContentWorkflowStatePermissionsByStateID(stateId));
        }

        public int AddWorkflowStatePermission(WorkflowStatePermission permission, int lastModifiedByUserId)
        {
            return DataProvider.Instance().AddContentWorkflowStatePermission(permission.StateID,
                                                                       permission.PermissionID,
                                                                       permission.RoleID,
                                                                       permission.AllowAccess,
                                                                       permission.UserID,
                                                                       lastModifiedByUserId);
        }

        public void DeleteWorkflowStatePermission(int workflowStatePermissionId)
        {
            DataProvider.Instance().DeleteContentWorkflowStatePermission(workflowStatePermissionId);
        }
        #endregion

        #region Service Locator
        protected override Func<IWorkflowStatePermissionsRepository> GetFactory()
        {
            return () => new WorkflowStatePermissionsRepository();
        }
        #endregion
    }
}
