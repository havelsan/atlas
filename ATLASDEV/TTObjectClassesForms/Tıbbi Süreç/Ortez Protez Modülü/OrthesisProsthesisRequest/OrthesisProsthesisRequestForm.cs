
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
    /// Ortez Protez
    /// </summary>
    public partial class OrthesisProsthesisRequestForm : EpisodeActionForm
    {
        override protected void BindControlEvents()
        {
            OrthesisProsthesisProcedures.CellValueChanged += new TTGridCellEventDelegate(OrthesisProsthesisProcedures_CellValueChanged);
            base.BindControlEvents();
        }

        override protected void UnBindControlEvents()
        {
            OrthesisProsthesisProcedures.CellValueChanged -= new TTGridCellEventDelegate(OrthesisProsthesisProcedures_CellValueChanged);
            base.UnBindControlEvents();
        }

        private void OrthesisProsthesisProcedures_CellValueChanged(Int32 rowIndex, Int32 columnIndex)
        {
#region OrthesisProsthesisRequestForm_OrthesisProsthesisProcedures_CellValueChanged
   if(columnIndex == 1 && this.OrthesisProsthesisProcedures.CurrentCell.Value != null)
            {
                if(this.OrthesisProsthesisProcedures.CurrentCell.Value.ToString () == "2")
                    this.OrthesisProsthesisProcedures.Rows[rowIndex].Cells[2].Value = 2;
            }
#endregion OrthesisProsthesisRequestForm_OrthesisProsthesisProcedures_CellValueChanged
        }

        protected override void PreScript()
        {
#region OrthesisProsthesisRequestForm_PreScript
    base.PreScript();
            
            if(_OrthesisProsthesisRequest.Episode.Diagnosis.Count == 0)
                throw new TTUtils.TTException("Bu işlem herhangi bir tanısı olmayan epizotlarda başlatılamaz.");

            this.SetProcedureDoctorAsCurrentResource();

            if (this._OrthesisProsthesisRequest.CurrentStateDefID.Value.Equals(OrthesisProsthesisRequest.States.Request))
            {
                this.IsPrintReport.Visible = true;
                // Hasta Payı ödenmeden işleme devam edilemeyeceği için FinancialDepartmentControl stebi kaldırıldı.
                this.DropStateButton(OrthesisProsthesisRequest.States.FinancialDepartmentControl);
            }
#endregion OrthesisProsthesisRequestForm_PreScript

            }
            
        protected override void ClientSidePreScript()
        {
#region OrthesisProsthesisRequestForm_ClientSidePreScript
    base.ClientSidePreScript();
#endregion OrthesisProsthesisRequestForm_ClientSidePreScript

        }

        protected override void PostScript(TTObjectStateTransitionDef transDef)
        {
#region OrthesisProsthesisRequestForm_PostScript
    base.PostScript(transDef);

             if (this.ProcedureDoctor.SelectedObject == null)
                    throw new Exception(SystemMessage.GetMessage(669));
#endregion OrthesisProsthesisRequestForm_PostScript

            }
            
        protected override void ClientSidePostScript(TTObjectStateTransitionDef transDef)
        {
#region OrthesisProsthesisRequestForm_ClientSidePostScript
    base.ClientSidePostScript(transDef);
            
            if(transDef != null && transDef.ToStateDefID != OrthesisProsthesisRequest.States.Cancelled)
            {
                this._OrthesisProsthesisRequest.IsInRequest = true;
                //Asagıdakı kod XXXXXX XXXXXX mantıgından kaldı. Bu nedenle commentlendı.
            //    OrthesisProsthesisRequest.RetiredEmployedData pData = this._OrthesisProsthesisRequest.GetIfRetiredOrEmployed();
            //    if(pData == OrthesisProsthesisRequest.RetiredEmployedData.Retired)
            //        ShowBox.Show(ShowBoxTypeEnum.Message,"&Tamam","T","Bilgi","Hastayı Bilgilendiriniz","Emekliler ve sivil hastalar, reçeteleri düzenlendikten sonra sağlık kurulu raporunu alıp, döner sermaye onayından geçtikten sonra ortez-protez teknisyenine başvurmalı",2);
            //    else
            //        ShowBox.Show(ShowBoxTypeEnum.Message,"&Tamam","T","Bilgi","Hastayı Bilgilendiriniz","XXXXXX hastalar,reçeteleri düzenlendikten sonra sağlık kurulu raporunu alıp, ortez-protez teknisyenine başvurmalı",2);
            }
#endregion OrthesisProsthesisRequestForm_ClientSidePostScript

        }
    }
}