
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
    /// BaseErrorReportForm
    /// </summary>
    public partial class BaseErrorReportForm : ActionForm
    {
        override protected void BindControlEvents()
        {
            inventoryAddButton.Click += new TTControlEventDelegate(inventoryAddButton_Click);
            ErrorReportCategory.SelectedObjectChanged += new TTControlEventDelegate(ErrorReportCategory_SelectedObjectChanged);
            MainCategoryErrorReportCategory.SelectedObjectChanged += new TTControlEventDelegate(MainCategoryErrorReportCategory_SelectedObjectChanged);
            FromResource.SelectedObjectChanged += new TTControlEventDelegate(FromResource_SelectedObjectChanged);
            base.BindControlEvents();
        }

        override protected void UnBindControlEvents()
        {
            inventoryAddButton.Click -= new TTControlEventDelegate(inventoryAddButton_Click);
            ErrorReportCategory.SelectedObjectChanged -= new TTControlEventDelegate(ErrorReportCategory_SelectedObjectChanged);
            MainCategoryErrorReportCategory.SelectedObjectChanged -= new TTControlEventDelegate(MainCategoryErrorReportCategory_SelectedObjectChanged);
            FromResource.SelectedObjectChanged -= new TTControlEventDelegate(FromResource_SelectedObjectChanged);
            base.UnBindControlEvents();
        }

        private void inventoryAddButton_Click()
        {
#region BaseErrorReportForm_inventoryAddButton_Click
   TTObjectContext objectContext = new TTObjectContext(false);
            try
            {
                ErrorReportInventory newErrorReportInventory = (ErrorReportInventory)objectContext.CreateObject(typeof(ErrorReportInventory).Name);
                newErrorReportInventory.IsActive = true;
                newErrorReportInventory.LastUpdate = TTObjectDefManager.ServerTime;
                TTForm frm = TTForm.GetEditForm(newErrorReportInventory);
                if (frm != null)
                {
                    frm.ShowEdit(this, newErrorReportInventory);
                    if (frm.DialogResult == DialogResult.OK)
                    {
                        newErrorReportInventory.ObjectContext.Save();
                        this.ErrorReportInventory.SelectedObject = newErrorReportInventory;
                    }
                }
                else
                {
                    throw new TTCallAdminException(SystemMessage.GetMessage(1000));
                }

            }
            catch (Exception ex)
            {
                InfoBox.Show(ex);
            }
            finally
            {
                if (objectContext != null)
                    objectContext.Dispose();
            }
#endregion BaseErrorReportForm_inventoryAddButton_Click
        }

        private void ErrorReportCategory_SelectedObjectChanged()
        {
#region BaseErrorReportForm_ErrorReportCategory_SelectedObjectChanged
   this.Name.Text = "";
            this.ErrorReportInventory.SelectedObject = null;
            this.ErrorReportInventory.Enabled = false;
            this.ErrorReportInventory.ReadOnly = true;
            this.ErrorReportInventory.Required = false;

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
#endregion BaseErrorReportForm_ErrorReportCategory_SelectedObjectChanged
        }

        private void MainCategoryErrorReportCategory_SelectedObjectChanged()
        {
#region BaseErrorReportForm_MainCategoryErrorReportCategory_SelectedObjectChanged
   this.ErrorReportCategory.SelectedObject = null;
#endregion BaseErrorReportForm_MainCategoryErrorReportCategory_SelectedObjectChanged
        }

        private void FromResource_SelectedObjectChanged()
        {
#region BaseErrorReportForm_FromResource_SelectedObjectChanged
   if (FromResource.SelectedObject != null)
            {
                ResSection resSection = (ResSection)FromResource.SelectedObject;
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
                    this.FromUser.ListFilterExpression = filterExpression;
                }
            }
#endregion BaseErrorReportForm_FromResource_SelectedObjectChanged
        }

        protected override void PreScript()
        {
#region BaseErrorReportForm_PreScript
    base.PreScript();
    this.inventoryAddButton.Enabled = false;
#endregion BaseErrorReportForm_PreScript

            }
            
        protected override void PostScript(TTObjectStateTransitionDef transDef)
        {
#region BaseErrorReportForm_PostScript
    //this.DropStateButton(ErrorReportAction.States.Approved);
            //this.DropStateButton(ErrorReportAction.States.Assigned);
#endregion BaseErrorReportForm_PostScript

            }
                }
}