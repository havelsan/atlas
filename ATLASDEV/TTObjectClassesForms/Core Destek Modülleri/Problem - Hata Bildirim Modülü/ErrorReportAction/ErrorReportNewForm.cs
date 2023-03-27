
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
    public partial class ErrorReportNewForm : BaseErrorReportForm
    {
        protected override void PreScript()
        {
#region ErrorReportNewForm_PreScript
    this.ErrorReportTabcontrol.HideTabPage(SolutionTabpage);
            if (Common.CurrentResource.SelectedResources.Count > 0)
            {
                string filterExpression = " OBJECTID IN (";
                int i = 1;
                foreach (UserResource userResource in Common.CurrentResource.UserResources)
                {
                    if (userResource.Resource != null)
                    {
                        filterExpression += ConnectionManager.GuidToString(userResource.Resource.ObjectID);
                        if (i < Common.CurrentResource.UserResources.Count)
                            filterExpression += ",";
                    }
                    i++;
                }
                filterExpression += ")";
                this.FromResource.ListFilterExpression = filterExpression;
            }

            if (this.ErrorReportCategory.SelectedObject != null)
            {
                ErrorReportCategory reportCat = (ErrorReportCategory)this.ErrorReportCategory.SelectedObject;
                this.ErrorReportInventory.Enabled = reportCat.InventoryRequired.Value;
                this.ErrorReportInventory.ReadOnly = !reportCat.InventoryRequired.Value;
                this.ErrorReportInventory.Required = reportCat.InventoryRequired.Value;
                this.inventoryAddButton.Enabled = reportCat.InventoryRequired.Value;
                this.Name.Text = reportCat.MainCategory.Code.ToString() + reportCat.Code.ToString() + " - " + reportCat.MainCategory.Name.ToString() + " / " + reportCat.Name.ToString();

                //otomatik onay durumuna göre butonları drop edelim ya da gösterelim
                if (reportCat.OwnerResource != null)
                {
                    this.DropStateButton(ErrorReportAction.States.Approved);
                    this.AddStateButton(ErrorReportAction.States.Assigned);
                }
                else
                {
                    this.DropStateButton(ErrorReportAction.States.Assigned);
                    this.AddStateButton(ErrorReportAction.States.Approved);
                }
            }
            else
            {
                this.DropStateButton(ErrorReportAction.States.Assigned);
                this.DropStateButton(ErrorReportAction.States.Approved);
                this.inventoryAddButton.Enabled = false;
            }
#endregion ErrorReportNewForm_PreScript

            }
            
        protected override void PostScript(TTObjectStateTransitionDef transDef)
        {
#region ErrorReportNewForm_PostScript
    base.PostScript(transDef);
#endregion ErrorReportNewForm_PostScript

            }
                }
}