
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
    /// Hizmet Talimat Detayı
    /// </summary>
    public partial class ProcedureOrderDetailForm : SubactionProcedureFlowableForm
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
#region ProcedureOrderDetailForm_PreScript
    base.PreScript();
            this.SetTreatmentMaterialListFilter((TTObjectDef)TTObjectDefManager.Instance.ObjectDefs["ProcedureOrderTreatmentMaterial"], (ITTGridColumn)this.UsedMaterial.Columns["MMaterial"]);
#endregion ProcedureOrderDetailForm_PreScript

            }
            
        protected override void PostScript(TTObjectStateTransitionDef transDef)
        {
#region ProcedureOrderDetailForm_PostScript
    base.PostScript(transDef);
#endregion ProcedureOrderDetailForm_PostScript

            }
            
        protected override void ClientSidePostScript(TTObjectStateTransitionDef transDef)
        {
#region ProcedureOrderDetailForm_ClientSidePostScript
    base.ClientSidePostScript(transDef);
             bool IsExecuted=false;
            if(transDef!=null)
                if(transDef.ToStateDefID==ProcedureOrderDetail.States.Completed)
                IsExecuted=true;
            
            if (IsExecuted==false && this._ProcedureOrderDetail.ProcedureOrderTreatmentMaterials.Count>0)
            {
                if (ShowBox.Show(ShowBoxTypeEnum.Choice,"&Evet,&Hayır","E,H", "Emin misiniz?","Uygulama yapılmamasına rağmen Sarf Girişi yapılmıştır.Devam etmek istediğinize emin misiniz?") == "H")
                    throw new Exception("İşlemden vazgeçildi");
            }
#endregion ProcedureOrderDetailForm_ClientSidePostScript

        }
    }
}