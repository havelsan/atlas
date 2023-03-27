
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
    public partial class OrthesisProsthesisHealthCommitteeForm : EpisodeActionForm
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
#region OrthesisProsthesisHealthCommitteeForm_PreScript
    base.PreScript();
            this.SetProcedureDoctorAsCurrentResource();
            //            //Üç İmza Onay ve Sağlık Kurullu onay stepleri açılırken başlatılan sağlık kurulu yada üç imza stepleri bitmemeişse uyarı verilir.
            //            if(this._OrthesisProsthesisRequest.CurrentStateDefID==OrthesisProsthesisRequest.States.HealthCommitteeWithThreeSpecialistApproval)
            //            {
            //                ArrayList arrUnCompletedActions = this._OrthesisProsthesisRequest.UnCompletedLinkedActions();
            //                if (arrUnCompletedActions.Count > 0)
            //                {
            //                    //YAPILACAKLAR//?Bu işleme bağlı olarak başlatılmış (İşlem No : ... fakat tamamlanmamış Üç İmza İşlemi var uyarısı verilmeli tamam derse işleme devam edebilmeli.//YAPILDI..YY
            //                    string sID = "";
            //                    foreach(EpisodeAction eaction in arrUnCompletedActions)
            //                    {
            //                        if(eaction is HealthCommitteeWithThreeSpecialist)
            //                            sID += eaction.ID.Value.ToString() + " ";
            //                    }
            //                    
            //                    string result=ShowBox.Show(ShowBoxTypeEnum.Message, "&Evet,&Hayır", "E,H", "Uyarı", "İşleme devam edilsin mi?", "Bu işleme bağlı olarak başlatılmış (İşlem No : " + sID + ") fakat tamamlanmamış Üç İmza İşlemi var, devam edilsin mi?", 1);
            //                    //DialogResult res = MessageBox.S how(this,"Bu işleme bağlı olarak başlatılmış (İşlem No : " + sID + ") fakat tamamlanmamış Üç İmza İşlemi var, devam edilsin mi?","Uyarı", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            //                    //if(res != DialogResult.Yes)
            //                    if(result == "H")
            //                        throw new Exception("İşlemden vazgeçildi.");
            //                }
            //            }
            //            
            //            if(this._OrthesisProsthesisRequest.CurrentStateDefID==OrthesisProsthesisRequest.States.HealthCommitteeApproval)
            //            {
            //                ArrayList arrUnCompletedActions = this._OrthesisProsthesisRequest.UnCompletedLinkedActions();
            //                if (arrUnCompletedActions.Count > 0)
            //                {
            //                    //YAPILACAKLAR//?Bu işleme bağlı olarak başlatılmış (İşlem No : ... fakat tamamlanmamış Sağlık Kurulu  İşlemi var uyarısı verilmeli tamam derse işleme devam edebilmeli.//YAPILDI...YY
            //                    string sID = "";
            //                    foreach(EpisodeAction eaction in arrUnCompletedActions)
            //                    {
            //                        if(eaction is HealthCommittee)
            //                            sID += eaction.ID.Value.ToString() + " ";
            //                    }
            //                    
            //                    string result = ShowBox.Show(ShowBoxTypeEnum.Message, "&Evet,&Hayır", "E,H", "Uyarı", "İşleme devam edilsin mi?", "Bu işleme bağlı olarak başlatılmış (İşlem No : " + sID + ") fakat tamamlanmamış Sağlık Kurulu İşlemi var, devam edilsin mi?", 1);
            //                    //DialogResult res = MessageBox.S how(this,"Bu işleme bağlı olarak başlatılmış (İşlem No : " + sID + ") fakat tamamlanmamış Sağlık Kurulu İşlemi var, devam edilsin mi?","Uyarı", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            //                    //if(res != DialogResult.Yes)
            //                    if(result == "H")
            //                        throw new Exception("İşlemden vazgeçildi.");
            //                }
            //            }

            //if (this._OrthesisProsthesisRequest.CurrentStateDefID == OrthesisProsthesisRequest.States.HealthCommittee || this._OrthesisProsthesisRequest.CurrentStateDefID == OrthesisProsthesisRequest.States.HealthCommitteeWithThreeSpecialist)
            //{
            //    if (this._OrthesisProsthesisRequest.HospitalsUnits.Count==0)
            //    {
            //        OrthesisProsthesisRequest.FillHospitalsUnitsGridDueToReasonForExamination(this._OrthesisProsthesisRequest);
            //    }
                
            //}
#endregion OrthesisProsthesisHealthCommitteeForm_PreScript

            }
            
        protected override void PostScript(TTObjectStateTransitionDef transDef)
        {
#region OrthesisProsthesisHealthCommitteeForm_PostScript
    base.PostScript(transDef);
            if (this.ProcedureDoctor.SelectedObject == null)
                    throw new Exception(SystemMessage.GetMessage(669));
#endregion OrthesisProsthesisHealthCommitteeForm_PostScript

            }
            
        protected override void ClientSidePostScript(TTObjectStateTransitionDef transDef)
        {
#region OrthesisProsthesisHealthCommitteeForm_ClientSidePostScript
    base.ClientSidePostScript(transDef);
             if(transDef != null)
            {
                if((transDef.FromStateDefID.Value.Equals(OrthesisProsthesisRequest.States.HealthCommittee) || transDef.FromStateDefID.Value.Equals(OrthesisProsthesisRequest.States.HealthCommitteeWithThreeSpecialist)) &&
                   transDef.ToStateDefID.Equals(OrthesisProsthesisRequest.States.RequestAcception))
                {
                    this.AddReturnDescriptionInput(this._OrthesisProsthesisRequest);
                }
                
//                if((transDef.FromStateDefID.Value.Equals(OrthesisProsthesisRequest.States.HealthCommitteeWithThreeSpecialistApproval) || transDef.FromStateDefID.Value.Equals(OrthesisProsthesisRequest.States.HealthCommitteeApproval)) && 
//                   transDef.ToStateDefID.Equals(OrthesisProsthesisRequest.States.Procedure))
//                {
//                    if(this._OrthesisProsthesisRequest.AuthorizedUsers.Count == 0)
//                        this.SetAuthorizedUserBySelecting(this._OrthesisProsthesisRequest.MasterResource, UserTypeEnum.Technician, false);
//                }
            }
#endregion OrthesisProsthesisHealthCommitteeForm_ClientSidePostScript

        }

#region OrthesisProsthesisHealthCommitteeForm_Methods
        /* private void ReturnDescriptionInput()
        {
            StringEntryForm pReturnForm = new StringEntryForm();
            DialogResult res = pReturnForm.ShowStringDialog(this, "İade Açıklamasını Giriniz");
            if(res == DialogResult.OK)
            {
                OrthesisProsthesis_ReturnDescriptionsGrid theGrid = null;
                theGrid = new OrthesisProsthesis_ReturnDescriptionsGrid(this._OrthesisProsthesisRequest.ObjectContext);
                theGrid.Description = pReturnForm.StringContent;
                theGrid.EntryDate = Common.RecTime();
                theGrid.UserName = Common.CurrentResource == null ? "" : Common.CurrentResource.Name;
                
                this._OrthesisProsthesisRequest.ReturnDescriptions.Add(theGrid);
            }
        }*/
        
#endregion OrthesisProsthesisHealthCommitteeForm_Methods
    }
}