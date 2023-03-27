
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
    public partial class SingleNursingOrderDetailForm : SubactionProcedureFlowableForm
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
            #region SingleNursingOrderDetailForm_PreScript
            base.PreScript();
            this.SetTreatmentMaterialListFilter((TTObjectDef)TTObjectDefManager.Instance.ObjectDefs["SingleNursingOrderTreatmentMaterial"], (ITTGridColumn)this.UsedMaterial.Columns["MMaterial"]);
            #endregion SingleNursingOrderDetailForm_PreScript

        }

        protected override void ClientSidePostScript(TTObjectStateTransitionDef transDef)
        {
            #region SingleNursingOrderDetailForm_ClientSidePostScript
            base.ClientSidePostScript(transDef);
            bool IsExecuted = false;
            if (transDef != null)
                if (transDef.ToStateDefID == SingleNursingOrderDetail.States.Completed)
                    IsExecuted = true;

            if (IsExecuted == false && this._SingleNursingOrderDetail.SingleNursingOrderTreatmentMaterials.Count > 0)
            {
                if (ShowBox.Show(ShowBoxTypeEnum.Message, "&Evet,&Hay�r", "E,H", "Uyar�", "Hem�irelik Uygulamalar�", "Uygulama yap�lmamas�na ra�men Sarf Giri�i yap�lm��t�r. Devam etmek istedi�inize emin misiniz?") == "H")
                    throw new Exception("��lemden vazge�ildi");
            }

            if (IsExecuted == true && String.IsNullOrEmpty(this.Result.Text))
            {
                if (ShowBox.Show(ShowBoxTypeEnum.Message, "&Evet,&Hay�r", "E,H", "Uyar�", "Hem�irelik Uygulamalar�", "Sonu� girmeden uygulamay� tamaml�yorsunuz. Devam etmek istedi�inize emin misiniz?") == "H")
                    throw new Exception("��lemden vazge�ildi");
                //throw new Exception("'Sonu�' alan� bo� ge�ilemez.");
            }
            #endregion SingleNursingOrderDetailForm_ClientSidePostScript

        }
    }
}