
using System;
using System.Xml;
using System.Data;
using System.Text;
using System.Drawing;
using System.Reflection;
using System.Collections;
using System.Linq;
using System.ComponentModel;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Collections.ObjectModel;
using System.Runtime.InteropServices;

using TTUtils;
using TTObjectClasses;
using TTDataDictionary;
using TTCoreDefinitions;
using TTConnectionManager;
using TTInstanceManagement;
using TTDefinitionManagement;
using TTStorageManager.Security;

using SmartCardWrapper;

using TTStorageManager;
using System.Runtime.Versioning;
using System.Windows.Forms;
using TTVisual;
namespace TTFormClasses
{
    /// <summary>
    /// Problem / Hata Bildirimi
    /// </summary>
    public partial class ErrorReportApproveForm : BaseErrorReportForm
    {
        override protected void BindControlEvents()
        {
            OwnerResource.SelectedObjectChanged += new TTControlEventDelegate(OwnerResource_SelectedObjectChanged);
            base.BindControlEvents();
        }

        override protected void UnBindControlEvents()
        {
            OwnerResource.SelectedObjectChanged -= new TTControlEventDelegate(OwnerResource_SelectedObjectChanged);
            base.UnBindControlEvents();
        }

        private void OwnerResource_SelectedObjectChanged()
        {
#region ErrorReportApproveForm_OwnerResource_SelectedObjectChanged
   if (this.OwnerResource.SelectedObject != null)
            {
                ResSection resSection = (ResSection)this.OwnerResource.SelectedObject;
                if (resSection.ResourceUsers.Count > 0)
                {
                    string filterExpression = " OBJECTID IN (";
                    int i = 1;
                    foreach (UserResource userResource in resSection.ResourceUsers)
                    {
                        if (userResource.User != null)
                        {
                            filterExpression += ConnectionManager.GuidToString(userResource.User.ObjectID);
                            if (i < resSection.ResourceUsers.Count)
                                filterExpression += ",";
                        }
                        i++;
                    }
                    filterExpression += ")";
                    this.OwnerUser.ListFilterExpression = filterExpression;
                }
            }
#endregion ErrorReportApproveForm_OwnerResource_SelectedObjectChanged
        }

        protected override void PreScript()
        {
#region ErrorReportApproveForm_PreScript
    if (_ErrorReportAction.ToResource != null)
            {
                if (((ResCommandership)_ErrorReportAction.ToResource).ResCommandershipSubUnits.Count > 0)
                {
                    string filterExpression = " OBJECTID IN (";
                    int i = 1;
                    foreach (ResCommandershipSubUnit ResCommandershipSubUnit in ((ResCommandership)_ErrorReportAction.ToResource).ResCommandershipSubUnits)
                    {
                        filterExpression += ConnectionManager.GuidToString(ResCommandershipSubUnit.ObjectID);
                        if (i < ((ResCommandership)_ErrorReportAction.ToResource).ResCommandershipSubUnits.Count)
                            filterExpression += ",";
                        i++;
                    }
                    filterExpression += ")";
                    this.OwnerResource.ListFilterExpression = filterExpression;
                }
            }
            
            this.inventoryAddButton.Enabled = false;
#endregion ErrorReportApproveForm_PreScript

            }
                }
}