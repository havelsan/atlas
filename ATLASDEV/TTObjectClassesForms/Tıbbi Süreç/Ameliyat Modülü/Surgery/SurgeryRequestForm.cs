
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
    /// Ameliyat
    /// </summary>
    public partial class SurgeryRequestForm : EpisodeActionForm
    {
        override protected void BindControlEvents()
        {
            Emergency.CheckedChanged += new TTControlEventDelegate(Emergency_CheckedChanged);
            base.BindControlEvents();
        }

        override protected void UnBindControlEvents()
        {
            Emergency.CheckedChanged -= new TTControlEventDelegate(Emergency_CheckedChanged);
            base.UnBindControlEvents();
        }

        private void Emergency_CheckedChanged()
        {
#region SurgeryRequestForm_Emergency_CheckedChanged
   CheckAndEnableEmergencySurgeryBotton();
#endregion SurgeryRequestForm_Emergency_CheckedChanged
        }

        protected override void PreScript()
        {
#region SurgeryRequestForm_PreScript
    base.PreScript();
            if (this._Surgery.CurrentStateDefID == Surgery.States.SurgeryRequest)
            {
                foreach (Surgery surgery in this._Surgery.Episode.Surgeries)
                {
                    if (!surgery.IsCancelled && surgery != this._Surgery && surgery.CurrentStateDef.Status == StateStatusEnum.Uncompleted)
                    {
                        InfoBox.Show("Bu hastaya başlatılmış ancak henüz tamamlanmamış ameliyat işlemi bulunmaktadır");
                        break;
                    }
                }
                // Ayaktan hastalarda Kabul Sebebi Günübirlik ve Acil olan hastalar dışında Ameliyat işlemi başlatılamaz!
                
                if(this._Surgery.Episode != null && this._Surgery.Episode.PatientStatus != null && this._Surgery.Episode.PatientStatus == PatientStatusEnum.Outpatient)
                {
                    if(this._Surgery.SubEpisode.PatientAdmission != null && this._Surgery.SubEpisode.PatientAdmission.AdmissionType != null &&  this._Surgery.SubEpisode.PatientAdmission.AdmissionType != null)
                    {
                        if( !this._Surgery.SubEpisode.PatientAdmission.AdmissionType.Equals(AdmissionTypeEnum.Daily) && !this._Surgery.SubEpisode.PatientAdmission.AdmissionType.Equals(AdmissionTypeEnum.Emergency))
                        {
                            throw new Exception("Kabul Sebebi 'Günübirlik' veya 'Acil' olmayan ayaktan hasta kabullerinde 'Ameliyat İşlemi' başlatılamaz.");
                        }
                    }
                }
                
                //----------------------
                int consLimit = Convert.ToInt16(TTObjectClasses.SystemParameter.GetParameterValue("AnesthesiaConsultationAvailabilityDate", "30"));
                DateTime limitDate = ((DateTime)Common.RecTime()).AddDays(-1 * consLimit);
                TTObjectContext context = new TTObjectContext(true);
                IList<AnesthesiaConsultation> anestCons = AnesthesiaConsultation.GetByDateLimitAndPatient(context, limitDate, this._Surgery.Episode.Patient.ObjectID);
                if (anestCons.Count < 1)
                {
                    if (TTVisual.ShowBox.Show(ShowBoxTypeEnum.Message, "&Evet,&Hayır", "E,H", "Uyarı", "Uyarı", "Son " + consLimit + "gün içerisinde  hastaya yapılmış anestezi konsültasyonu bulunmamaktadır.Ameliyat işlemi başlatmak istediğinize emin misiniz?") == "H")
                    {
                        throw new Exception("İşlem İptal edildi");
                    }
                }

                //----------------------
                this.SetProcedureDoctorAsCurrentResource();
            }
            CheckAndEnableEmergencySurgeryBotton();
#endregion SurgeryRequestForm_PreScript

            }
            
        protected override void PostScript(TTObjectStateTransitionDef transDef)
        {
#region SurgeryRequestForm_PostScript
    base.PostScript(transDef);
            if (transDef != null)
            {
                if (transDef.ToStateDefID != Surgery.States.Cancelled && transDef.FromStateDefID == Surgery.States.SurgeryRequest)
                {
                    
                    if (this.ProcedureDoctor == null || this.ProcedureDoctor.SelectedObject == null)
                        throw new TTUtils.TTException("Sorumlu cerrah bilgisini giriniz!");                 

                    if (this._Surgery.MasterResource == null)
                        throw new Exception("Ameliyathane boş geçilemez");
                }
            }
#endregion SurgeryRequestForm_PostScript

            }
            
        protected override void ClientSidePostScript(TTObjectStateTransitionDef transDef)
        {
#region SurgeryRequestForm_ClientSidePostScript
    base.ClientSidePostScript(transDef);
            // if (transDef != null)
            //{
            //    if (transDef.ToStateDefID != Surgery.States.Cancelled && transDef.FromStateDefID == Surgery.States.SurgeryRequest)
            //    {

            //        if (this._Surgery.AnesthesiaAndReanimationMasterResource == null)
            //            this._Surgery.AnesthesiaAndReanimationMasterResource = GetSelectedAcionDefualtMasterResource(this._Surgery.ObjectContext, ActionTypeEnum.AnesthesiaAndReanimation, "Anestezi İsteği Yapılacak Birimi seçiniz");
            //    }
            //}
#endregion SurgeryRequestForm_ClientSidePostScript

        }

#region SurgeryRequestForm_Methods
        //        public void FireAnesthesiaAndReanimation(TTObjectStateTransitionDef transDef)
        //        {
        //            if(transDef!=null)
        //            {
        //                if(transDef.ToStateDefID!=Surgery.States.Cancelled && transDef.FromStateDefID==Surgery.States.SurgeryRequest)
        //                {
        //                    bool fire=false;
        //                    if (this._Surgery.AnesthesiaAndReanimation==null)
        //                    {
        //                        fire=true;
        //                    }
        //                    else if(this._Surgery.AnesthesiaAndReanimation.IsCancelled)
        //                    {
        //                        fire=true;
        //                    }
        //                    if(fire)
        //                    {
        //                        ResSection masterResource=GetSelectedAcionDefualtMasterResource(this._Surgery.ObjectContext,ActionTypeEnum.AnesthesiaAndReanimation,"Anestezi İsteği Yapılacak Birimi seçiniz");
        //                        if(masterResource!=null)
        //                        {
        //                            AnesthesiaAndReanimation anesthesiaAndReanimation = new AnesthesiaAndReanimation(this._Surgery.ObjectContext,(Surgery)this._Surgery,(ResSection)masterResource);
        //                        }
        //                        else
        //                        {
        //                            throw new Exception("Ameliyat isteği yapılabilmesi için 'Anestezi ve Reanimasyon işlemi' için İşlem Kaynak Eşleştirme Tanımı yapılması gerekmektedir");
        //                            
        //                        }
        //                    }
        //                    
        //                }
        //            }
        //        }
        //        
        public void CheckAndEnableEmergencySurgeryBotton()
        {
            //TODO:PanelButtons!
            //foreach (Control button in this.pnlButtons.Controls)
            //{
            //    if (button.Tag != null)
            //    {
            //        TTObjectStateTransitionDef myTransDef = (TTObjectStateTransitionDef)button.Tag;
            //        if (myTransDef.ToStateDefID.Equals(Surgery.States.Surgery))//Acil Ameliyata al buttonu
            //            button.Enabled = (bool)(this._Surgery.Emergency == null ? false : this._Surgery.Emergency);
            //    }
            //}
            var a = 1;
        }
        
#endregion SurgeryRequestForm_Methods
    }
}