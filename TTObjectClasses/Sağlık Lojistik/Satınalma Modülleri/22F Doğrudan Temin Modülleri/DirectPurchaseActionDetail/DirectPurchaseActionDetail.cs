
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



using TTStorageManager;
using System.Runtime.Versioning;


namespace TTObjectClasses
{
    /// <summary>
    /// 22F Doğrudan Temin Malzemeler
    /// </summary>
    public  partial class DirectPurchaseActionDetail : TTObject
    {
        public partial class MaterialRequestFormReportNQL_Class : TTReportNqlObject 
        {
        }

        public partial class MaterielInspectionAndReceivingReportNQL_Class : TTReportNqlObject 
        {
        }

        public partial class GetPiyasaArastirmaTutanagiReport_Class : TTReportNqlObject 
        {
        }

        public partial class GetDirectPurchaseActionDetail_Class : TTReportNqlObject 
        {
        }

    /// <summary>
    /// KDV enumundan dönen değeri double a çevirir
    /// </summary>
        public double? KDVdbl
        {
            get
            {
                try
                {
#region KDVdbl_GetScript                    
                    if (KDV.HasValue == true)
                    {
                        if (KDV.Value == VatrateEnum.Eight)
                            return 8;
                        else if (KDV.Value == VatrateEnum.Eighteen)
                            return 18;
                    }
                return 0;
#endregion KDVdbl_GetScript
                }
                catch (Exception ex)
                {
                    throw new TTException(TTUtils.CultureService.GetText("M148", "Error getting property '{0}'", "KDVdbl") + " : " + ex.Message, ex);
                }
            }
        }

        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        override protected void RunSetMemberValueScript(string memberName, object newValue)
        {
            switch (memberName)
            {
                case "CANCELLED":
                    {
                        bool? value = (bool?)Convert.ToBoolean(newValue);
#region CANCELLED_SetScript
                        if (value.HasValue == true && value.Value == true)
                        {
                            if (HasUsed.HasValue == true && HasUsed.Value == true)
                            {
                                TTUtils.InfoMessageService.Instance.ShowMessage(TTUtils.CultureService.GetText("M25885", "Hastaya kullanılmış malzeme iptal edilemez."));
                                Cancelled = false;
                            }
                        }
#endregion CANCELLED_SetScript
                    }
                    break;

            }
        }

#region Methods
        override protected void OnConstruct()
        {
            base.OnConstruct();
            ITTObject ttObject = (ITTObject)this;
            if (ttObject.IsNew)
            {
                OrderNo.GetNextValue();
            }
        }
        
#endregion Methods

    }
}