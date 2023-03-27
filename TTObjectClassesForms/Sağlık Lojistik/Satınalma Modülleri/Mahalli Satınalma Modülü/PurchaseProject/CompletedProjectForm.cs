
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
    /// Sonuçlanmış İhale Bilgileri
    /// </summary>
    public partial class CompletedProjectForm : TTForm
    {
        override protected void BindControlEvents()
        {
            cmdContractsForm.Click += new TTControlEventDelegate(cmdContractsForm_Click);
            cmdDetailingForm.Click += new TTControlEventDelegate(cmdDetailingForm_Click);
            ProjectDetailsGrid.CellContentClick += new TTGridCellEventDelegate(ProjectDetailsGrid_CellContentClick);
            base.BindControlEvents();
        }

        override protected void UnBindControlEvents()
        {
            cmdContractsForm.Click -= new TTControlEventDelegate(cmdContractsForm_Click);
            cmdDetailingForm.Click -= new TTControlEventDelegate(cmdDetailingForm_Click);
            ProjectDetailsGrid.CellContentClick -= new TTGridCellEventDelegate(ProjectDetailsGrid_CellContentClick);
            base.UnBindControlEvents();
        }

        private void cmdContractsForm_Click()
        {
#region CompletedProjectForm_cmdContractsForm_Click
   ContractEntryForm cf = new ContractEntryForm();
            cf.ShowReadOnly(this.FindForm(), _PurchaseProject);
#endregion CompletedProjectForm_cmdContractsForm_Click
        }

        private void cmdDetailingForm_Click()
        {
#region CompletedProjectForm_cmdDetailingForm_Click
   ProjectDetailingForm pdf = new ProjectDetailingForm();
            pdf.ShowReadOnly(this.FindForm(), _PurchaseProject);
#endregion CompletedProjectForm_cmdDetailingForm_Click
        }

        private void ProjectDetailsGrid_CellContentClick(Int32 rowIndex, Int32 columnIndex)
        {
#region CompletedProjectForm_ProjectDetailsGrid_CellContentClick
   if (ProjectDetailsGrid.CurrentCell == null)
                return;
            PurchaseProject myProject = _PurchaseProject;
            switch (ProjectDetailsGrid.CurrentCell.OwningColumn.Name)
            {
                case "Details":
                    ProjectRegistrationItemDetailsForm prid = new ProjectRegistrationItemDetailsForm();
                    prid.ShowEdit(this.FindForm(), myProject.PurchaseProjectDetails[ProjectDetailsGrid.CurrentCell.RowIndex]);
                    break;
                default:
                    break;
            }
#endregion CompletedProjectForm_ProjectDetailsGrid_CellContentClick
        }
    }
}