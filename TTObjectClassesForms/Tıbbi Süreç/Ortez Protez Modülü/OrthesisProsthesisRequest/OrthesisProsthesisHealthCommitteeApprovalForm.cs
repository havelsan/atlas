
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
    public partial class OrthesisProsthesisHealthCommitteeApprovalForm : EpisodeActionForm
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
#region OrthesisProsthesisHealthCommitteeApprovalForm_PreScript
    base.PreScript();

            //Üç İmza Onay ve Sağlık Kurullu onay stepleri açılırken başlatılan sağlık kurulu yada üç imza stepleri bitmemeişse uyarı verilir.
            /* if(this._OrthesisProsthesisRequest.CurrentStateDefID==OrthesisProsthesisRequest.States.HealthCommitteeWithThreeSpecialistApproval)
             {
                 ArrayList arrUnCompletedActions = this._OrthesisProsthesisRequest.UnCompletedLinkedActions();
                 if (arrUnCompletedActions.Count > 0)
                 {
                     //YAPILACAKLAR//?Bu işleme bağlı olarak başlatılmış (İşlem No : ... fakat tamamlanmamış Üç İmza İşlemi var uyarısı verilmeli tamam derse işleme devam edebilmeli.//YAPILDI..YY
                     string sID = "";
                     foreach(EpisodeAction eaction in arrUnCompletedActions)
                     {
                         if(eaction is HealthCommitteeWithThreeSpecialist)
                             sID += eaction.ID.Value.ToString() + " ";
                     }

                     string result=ShowBox.Show(ShowBoxTypeEnum.Message, "&Evet,&Hayır", "E,H", "Uyarı", "İşleme devam edilsin mi?", "Bu işleme bağlı olarak başlatılmış (İşlem No : " + sID + ") fakat tamamlanmamış Üç İmza İşlemi var, devam edilsin mi?", 1);
                     //DialogResult res = MessageBox.Show(this,"Bu işleme bağlı olarak başlatılmış (İşlem No : " + sID + ") fakat tamamlanmamış Üç İmza İşlemi var, devam edilsin mi?","Uyarı", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                     //if(res != DialogResult.Yes)
                     if(result == "H")
                         throw new Exception(SystemMessage.GetMessage(80));
                 }
             }

             if(this._OrthesisProsthesisRequest.CurrentStateDefID==OrthesisProsthesisRequest.States.HealthCommitteeApproval)
             {
                 ArrayList arrUnCompletedActions = this._OrthesisProsthesisRequest.UnCompletedLinkedActions();
                 if (arrUnCompletedActions.Count > 0)
                 {
                     //YAPILACAKLAR//?Bu işleme bağlı olarak başlatılmış (İşlem No : ... fakat tamamlanmamış Sağlık Kurulu  İşlemi var uyarısı verilmeli tamam derse işleme devam edebilmeli.//YAPILDI...YY
                     string sID = "";
                     foreach(EpisodeAction eaction in arrUnCompletedActions)
                     {
                         if(eaction is HealthCommittee)
                             sID += eaction.ID.Value.ToString() + " ";
                     }

                     string result = ShowBox.Show(ShowBoxTypeEnum.Message, "&Evet,&Hayır", "E,H", "Uyarı", "İşleme devam edilsin mi?", "Bu işleme bağlı olarak başlatılmış (İşlem No : " + sID + ") fakat tamamlanmamış Sağlık Kurulu İşlemi var, devam edilsin mi?", 1);
                     //DialogResult res = MessageBox.Show(this,"Bu işleme bağlı olarak başlatılmış (İşlem No : " + sID + ") fakat tamamlanmamış Sağlık Kurulu İşlemi var, devam edilsin mi?","Uyarı", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                     //if(res != DialogResult.Yes)
                     if(result == "H")
                         throw new Exception(SystemMessage.GetMessage(80));
                 }
             }
             */
            this.SetProcedureDoctorAsCurrentResource();

            this.SetTreatmentMaterialListFilter((TTObjectDef)TTObjectDefManager.Instance.ObjectDefs["BaseTreatmentMaterial"], (ITTGridColumn)this.TreatmentMaterials.Columns["MMaterial"]);
#endregion OrthesisProsthesisHealthCommitteeApprovalForm_PreScript

            }
            
        protected override void ClientSidePreScript()
        {
#region OrthesisProsthesisHealthCommitteeApprovalForm_ClientSidePreScript
    base.ClientSidePreScript();
             //Üç İmza Onay ve Sağlık Kurullu onay stepleri açılırken başlatılan sağlık kurulu yada üç imza stepleri bitmemeişse uyarı verilir.
            if(this._OrthesisProsthesisRequest.CurrentStateDefID==OrthesisProsthesisRequest.States.HealthCommitteeWithThreeSpecialistApproval)
            {
                ArrayList arrUnCompletedActions = OrthesisProsthesisRequest.UnCompletedLinkedActions(this._OrthesisProsthesisRequest);
                if (arrUnCompletedActions.Count > 0)
                {
                    //YAPILACAKLAR//?Bu işleme bağlı olarak başlatılmış (İşlem No : ... fakat tamamlanmamış Üç İmza İşlemi var uyarısı verilmeli tamam derse işleme devam edebilmeli.//YAPILDI..YY
                    string sID = "";
                    foreach(EpisodeAction eaction in arrUnCompletedActions)
                    {
                        if(eaction is HealthCommitteeWithThreeSpecialist)
                            sID += eaction.ID.Value.ToString() + " ";
                    }
                    
                    string result=ShowBox.Show(ShowBoxTypeEnum.Message, "&Evet,&Hayır", "E,H", "Uyarı", "İşleme devam edilsin mi?", "Bu işleme bağlı olarak başlatılmış (İşlem No : " + sID + ") fakat tamamlanmamış Üç İmza İşlemi var, devam edilsin mi?", 1);
                    //DialogResult res = MessageBox.Show(this,"Bu işleme bağlı olarak başlatılmış (İşlem No : " + sID + ") fakat tamamlanmamış Üç İmza İşlemi var, devam edilsin mi?","Uyarı", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    //if(res != DialogResult.Yes)
                    if(result == "H")
                        throw new Exception(SystemMessage.GetMessage(80));
                }
            }
            
            if(this._OrthesisProsthesisRequest.CurrentStateDefID==OrthesisProsthesisRequest.States.HealthCommitteeApproval)
            {
                ArrayList arrUnCompletedActions = OrthesisProsthesisRequest.UnCompletedLinkedActions(this._OrthesisProsthesisRequest);
                if (arrUnCompletedActions.Count > 0)
                {
                    //YAPILACAKLAR//?Bu işleme bağlı olarak başlatılmış (İşlem No : ... fakat tamamlanmamış Sağlık Kurulu  İşlemi var uyarısı verilmeli tamam derse işleme devam edebilmeli.//YAPILDI...YY
                    string sID = "";
                    foreach(EpisodeAction eaction in arrUnCompletedActions)
                    {
                        if(eaction is HealthCommittee)
                            sID += eaction.ID.Value.ToString() + " ";
                    }
                    
                    string result = ShowBox.Show(ShowBoxTypeEnum.Message, "&Evet,&Hayır", "E,H", "Uyarı", "İşleme devam edilsin mi?", "Bu işleme bağlı olarak başlatılmış (İşlem No : " + sID + ") fakat tamamlanmamış Sağlık Kurulu İşlemi var, devam edilsin mi?", 1);
                    //DialogResult res = MessageBox.Show(this,"Bu işleme bağlı olarak başlatılmış (İşlem No : " + sID + ") fakat tamamlanmamış Sağlık Kurulu İşlemi var, devam edilsin mi?","Uyarı", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    //if(res != DialogResult.Yes)
                    if(result == "H")
                        throw new Exception(SystemMessage.GetMessage(80));
                }
            }
#endregion OrthesisProsthesisHealthCommitteeApprovalForm_ClientSidePreScript

        }

        protected override void PostScript(TTObjectStateTransitionDef transDef)
        {
#region OrthesisProsthesisHealthCommitteeApprovalForm_PostScript
    base.PostScript(transDef);

            if (this.ProcedureDoctor.SelectedObject == null)
                    throw new Exception(SystemMessage.GetMessage(669));
#endregion OrthesisProsthesisHealthCommitteeApprovalForm_PostScript

            }
            
        protected override void ClientSidePostScript(TTObjectStateTransitionDef transDef)
        {
#region OrthesisProsthesisHealthCommitteeApprovalForm_ClientSidePostScript
    base.ClientSidePostScript(transDef);
            if(transDef != null)
            {    
                if((transDef.FromStateDefID.Value.Equals(OrthesisProsthesisRequest.States.HealthCommitteeWithThreeSpecialistApproval) || transDef.FromStateDefID.Value.Equals(OrthesisProsthesisRequest.States.HealthCommitteeApproval)) && 
                   transDef.ToStateDefID.Equals(OrthesisProsthesisRequest.States.Procedure))
                {
                    if(this._OrthesisProsthesisRequest.AuthorizedUsers.Count == 0)
                        this.SetAuthorizedUserBySelecting(this._OrthesisProsthesisRequest.MasterResource, UserTypeEnum.Technician, false);
                }
            }
#endregion OrthesisProsthesisHealthCommitteeApprovalForm_ClientSidePostScript

        }
    }
}