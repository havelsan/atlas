
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
    /// Genel Üretim İşlemi
    /// </summary>
    public partial class GeneralProductionActionNewForm : BaseGeneralProductionActionFrom
    {
        protected override void PreScript()
        {
#region GeneralProductionActionNewForm_PreScript
    base.PreScript();


            if (_GeneralProductionAction.Store is MainStoreDefinition)
            {
                _GeneralProductionAction.MKYS_TeslimEden = ((MainStoreDefinition)_GeneralProductionAction.Store).GoodsAccountant.Name;
                _GeneralProductionAction.MKYS_TeslimEdenObjID = ((MainStoreDefinition)_GeneralProductionAction.Store).GoodsAccountant.ObjectID;
                _GeneralProductionAction.MKYS_TeslimAlan = ((MainStoreDefinition)_GeneralProductionAction.DestinationStore).GoodsAccountant.Name;
                _GeneralProductionAction.MKYS_TeslimAlanObjID = ((MainStoreDefinition)_GeneralProductionAction.DestinationStore).GoodsAccountant.ObjectID;
            }


            this._GeneralProductionAction.MKYS_CikisStokHareketTuru = MKYS_ECikisStokHareketTurEnum.ckTuketim;
            this._GeneralProductionAction.MKYS_ETedarikTuru = MKYS_ETedarikTurEnum.icImkanlarlaUretim;
            this._GeneralProductionAction.MKYS_EMalzemeGrup = MKYS_EMalzemeGrupEnum.tibbiSarf;

            ((ITTListBoxColumn)((ITTGridColumn)this.GeneralProductionOutDets.Columns["MaterialDet"])).ListFilterExpression = "STOCKS.STORE='" + this._GeneralProductionAction.Store.ObjectID.ToString() + "' AND STOCKS.INHELD>0";
#endregion GeneralProductionActionNewForm_PreScript

            }
                }
}