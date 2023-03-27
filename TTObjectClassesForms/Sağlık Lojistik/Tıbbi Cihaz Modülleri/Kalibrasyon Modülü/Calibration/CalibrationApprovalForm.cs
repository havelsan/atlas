
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
    /// İstek Onay
    /// </summary>
    public partial class CalibrationApprovalForm : CalibrationBaseForm
    {
        override protected void BindControlEvents()
        {
            WorkShop.SelectedObjectChanged += new TTControlEventDelegate(WorkShop_SelectedObjectChanged);
            base.BindControlEvents();
        }

        override protected void UnBindControlEvents()
        {
            WorkShop.SelectedObjectChanged -= new TTControlEventDelegate(WorkShop_SelectedObjectChanged);
            base.UnBindControlEvents();
        }

        private void WorkShop_SelectedObjectChanged()
        {
#region CalibrationApprovalForm_WorkShop_SelectedObjectChanged
   this.ttobjectlistbox2.ListFilterExpression = " USERRESOURCES(RESOURCE='"+this.WorkShop.SelectedObject.ObjectID.ToString()+"').EXISTS" ;
#endregion CalibrationApprovalForm_WorkShop_SelectedObjectChanged
        }
    }
}