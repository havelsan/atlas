
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
    /// Sayım Tarti Çizelgesi
    /// </summary>
    public  partial class STCAction : TTObject
    {
        public partial class STCReportQuery_Class : TTReportNqlObject 
        {
        }

        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        override protected void RunSetMemberValueScript(string memberName, object newValue)
        {
            switch (memberName)
            {
                case "MATERIAL":
                    {
                        Material value = (Material)newValue;
#region MATERIAL_SetParentScript
                        if(value.StockCard.StockMethod == StockMethodEnum.ExpirationDated)
                SKTarihi = Common.GetLastDayOfMounth(Common.MinDateTime());
#endregion MATERIAL_SetParentScript
                    }
                    break;

            }
        }

    }
}