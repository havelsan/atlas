
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
    public partial class StockOutCancelAttribute : TTAttributeInstance
    {
        public override void Run(AttributeWhenEnum when)
        {
#region Body
            foreach (BaseTreatmentMaterial baseTreatmentMaterial in Interface.GetTreatmentMaterials())
            {
                if (baseTreatmentMaterial.StockActionDetail != null)
                {
                    if (baseTreatmentMaterial.StockActionDetail.StockAction is StockOut)
                    {
                        if (((StockOut)baseTreatmentMaterial.StockActionDetail.StockAction).CurrentStateDefID != StockOut.States.Cancelled)
                        {
                            ((StockOut)baseTreatmentMaterial.StockActionDetail.StockAction).CurrentStateDefID = StockOut.States.Cancelled;
                        }
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