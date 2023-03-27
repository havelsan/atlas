
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
    /// Onarım [Stok Numaralı]
    /// </summary>
    public partial class MaterialRepairForm : RepairBaseForm
    {
        override protected void BindControlEvents()
        {
            base.BindControlEvents();
        }

        override protected void UnBindControlEvents()
        {
            base.UnBindControlEvents();
        }

        protected override void PreScript()
        {
#region MaterialRepairForm_PreScript
    base.PreScript();
            
            this.DropStateButton(MaterialRepair.States.MobileTeam);
            this.DropStateButton(MaterialRepair.States.UpperStage);
            
            if(_MaterialRepair.UnitWorkLoadPrice == null)
            {
                IList loadPrices = _MaterialRepair.ObjectContext.QueryObjects("WORKLOADPRICEDEFINITION",string.Empty);
                if(loadPrices.Count > 0)
                {
                    WorkLoadPriceDefinition workLoadPriceDefinition = (WorkLoadPriceDefinition)loadPrices[0];
                    if(_MaterialRepair.ResponsibleUser.UserType == UserTypeEnum.BiomedicalEngineer)
                        _MaterialRepair.UnitWorkLoadPrice = workLoadPriceDefinition.EngineerWorkLoadPrice;
                    else
                        _MaterialRepair.UnitWorkLoadPrice = workLoadPriceDefinition.TechnicianWorkLoadPrice;
                }
            }
#endregion MaterialRepairForm_PreScript

            }
                }
}