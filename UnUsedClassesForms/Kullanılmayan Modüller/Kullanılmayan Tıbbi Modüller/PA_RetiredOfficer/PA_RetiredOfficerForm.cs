
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
    /// Emekli Subay Kabulü
    /// </summary>
    public partial class PA_RetiredOfficerForm : PA_MilitaryRetiredForm
    {
        protected override void PreScript()
        {
#region PA_RetiredOfficerForm_PreScript
    base.PreScript();
            // Faturalama Yöntemindeki Hasta Grubuna göre Kurumların filtreli gelmesi
            /*
            string payerTypeList = null;
            PatientGroupDefinition pGroup = Common.PatientGroupDefinitionByEnum(this._PA_RetiredOfficer.ObjectContext,this._PA_RetiredOfficer.Episode.PatientGroup.Value);
            
            foreach (InvoiceAccountPayerType pType in pGroup.InvoiceAccountDefinition.PayerTypes)
            {
                payerTypeList = payerTypeList + "TYPE = '" + pType.PayerType.ObjectID.ToString() + "' OR ";
            }
            
            if (payerTypeList != null)
            {
                payerTypeList = payerTypeList.Substring(0, (payerTypeList.Length - 3));
                this.Payer.ListFilterExpression = payerTypeList;
            }
            else
                this.Payer.ListFilterExpression = "TYPE is null ";
                */
#endregion PA_RetiredOfficerForm_PreScript

            }
                }
}