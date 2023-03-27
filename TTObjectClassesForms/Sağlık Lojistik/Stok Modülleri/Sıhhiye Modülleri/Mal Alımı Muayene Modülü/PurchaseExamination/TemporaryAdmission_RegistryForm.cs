
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
    /// Geçici Kabul Kayıt
    /// </summary>
    public partial class TemporaryAdmission_RegistryForm : StockActionBaseForm
    {
        override protected void BindControlEvents()
        {
            cmdAddItem.Click += new TTControlEventDelegate(cmdAddItem_Click);
            base.BindControlEvents();
        }

        override protected void UnBindControlEvents()
        {
            cmdAddItem.Click -= new TTControlEventDelegate(cmdAddItem_Click);
            base.UnBindControlEvents();
        }

        private void cmdAddItem_Click()
        {
#region TemporaryAdmission_RegistryForm_cmdAddItem_Click
   OrderTrackingForm frm = new OrderTrackingForm();
                frm.ShowEdit(this.FindForm(), _PurchaseExamination);
#endregion TemporaryAdmission_RegistryForm_cmdAddItem_Click
        }

        protected override void PreScript()
        {
#region TemporaryAdmission_RegistryForm_PreScript
    base.PreScript();
            
            Guid hospGuid = new Guid(TTObjectClasses.SystemParameter.GetParameterValue("HOSPITAL", Guid.Empty.ToString()));
            if(hospGuid == null)
                throw new TTUtils.TTException("SITE Sistem parametresi boş olmamalıdır.");
            
            ResHospital hosp = (ResHospital)_PurchaseExamination.ObjectContext.GetObject(hospGuid, "RESHOSPITAL");
            if(hosp == null)
                throw new TTUtils.TTException("XXXXXXnin bağlı olduğu birlik tanımlanmadan işlem devam ettirilemez.");
            
            Accountancy.ListFilterExpression = "ACCOUNTANCYMILITARYUNIT = '" + hosp.MilitaryUnit.ObjectID.ToString() + "'";
            
            if(_PurchaseExamination.ManuelEntry == false)
                cmdAddItem.ReadOnly = true;
#endregion TemporaryAdmission_RegistryForm_PreScript

            }
                }
}