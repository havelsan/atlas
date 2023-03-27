
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
    /// Hemşire Takip Gözlem
    /// </summary>
    public partial class NursingOrderDetailForm : SubactionProcedureFlowableForm
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
#region NursingOrderDetailForm_PreScript
    base.PreScript();
              //this.SetTreatmentMaterialListFilter((TTObjectDef)TTObjectDefManager.Instance.ObjectDefs["NursingOrderDetailTreatmentMaterial"], (ITTGridColumn)this.UsedMaterial.Columns["MMaterial"]);
#endregion NursingOrderDetailForm_PreScript

            }
            
        protected override void ClientSidePostScript(TTObjectStateTransitionDef transDef)
        {
#region NursingOrderDetailForm_ClientSidePostScript
    base.ClientSidePostScript(transDef);
             if(transDef!=null)
            {
                if(transDef.ToStateDefID==NursingOrderDetail.States.Completed)
                {
                    if(this._NursingOrderDetail.TreatmentMaterials.Count>0)
                    {
                        if (ShowBox.Show(ShowBoxTypeEnum.Choice,"&Evet,&Hayır","E,H", "Emin misiniz?","Uyguluma yapılmamasına rağmen Sarf Girişi yapılmıştır.Devam etmek istediğinize emin misiniz?") == "H")
                            throw new Exception(SystemMessage.GetMessage(80));
                    }
                    if(this._NursingOrderDetail.Result==null)
                        throw new Exception(SystemMessage.GetMessage(1167));
                }
            }
#endregion NursingOrderDetailForm_ClientSidePostScript

        }
    }
}