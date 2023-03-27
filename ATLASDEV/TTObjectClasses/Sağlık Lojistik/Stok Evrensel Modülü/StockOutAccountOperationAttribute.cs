
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
    public partial class StockOutAccountOperationAttribute : TTAttributeInstance
    {

        // Sarf malzemeler stoktan düþerken ücretlensin diye eklenen attribute
        public override void Run(AttributeWhenEnum when)
        {
            #region Body

            foreach (StockActionDetail stockActionDetail in Interface.GetStockActionOutDetails())
            {
                if (stockActionDetail.SubActionMaterial != null)
                {
                    foreach (SubActionMaterial sm in stockActionDetail.SubActionMaterial)
                    {
                        if (sm is BaseTreatmentMaterial) // Sadece sarf malzemeler buradan ücretlenir, DrugOrderDetail ler buradan ücretlenmez
                            sm.AccountOperation();
                    }
                }
            }

            #endregion Body
        }

        public override void Check(TTAttribute attribute)
        {
            #region CheckBody

            #endregion CheckBody
        }
    }
}