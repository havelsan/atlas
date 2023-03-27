
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
    /// Muayene Tedavi Sonuç
    /// </summary>
    public partial class TreatmentDischargeForm : EpisodeActionForm
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
            #region TreatmentDischargeNewForm_PreScript
            base.PreScript();


        /*    this.SetProcedureDoctorAsCurrentResource(); */// Server Preye Taşınacak

            #endregion TreatmentDischargeNewForm_PreScript

        }

        protected override void PostScript(TTObjectStateTransitionDef transDef)
        {
            #region TreatmentDischargeNewForm_PostScript
            base.PostScript(transDef);
            //this.CheckRequiredPropertyAndRelations(this._TreatmentDischarge);

            #endregion TreatmentDischargeNewForm_PostScript

        }

        protected override void ClientSidePostScript(TTObjectStateTransitionDef transDef)
        {
            #region TreatmentDischargeNewForm_ClientSidePostScript
            base.ClientSidePostScript(transDef);


            // yatan medula hastaları için MTS de taburcu tipi 'Tedaviden Vazgeçme' seçildiğinde uyarı verilmesi istendi
            if (SubEpisode.IsSGKSubEpisode(_TreatmentDischarge.SubEpisode) && this._TreatmentDischarge.InPatientTreatmentClinicApp != null && Convert.ToDateTime(this._TreatmentDischarge.InPatientTreatmentClinicApp.ClinicInpatientDate) != null && this._TreatmentDischarge.GetMyDischargeTypeEnum() == DischargeTypeEnum.RejectTreatment)
            {
                if (transDef.FromStateDefID == TreatmentDischarge.States.New && (transDef.ToStateDefID == TreatmentDischarge.States.PreDischarge))
                {
                    string result = ShowBox.Show(ShowBoxTypeEnum.Message, "&Evet,&Hayır", "E,H", "Uyarı", "Emin misiniz?", "Taburcu Tipi 'TIBBİ ÖNERİLERİ/TEDAVİLERİ REDDEREDEK ÇIKIŞ' seçildiği takdirde Medula hizmet fiyatlarında %10 kesinti yapacaktır.Devam etmek istediğinize emin misiniz?", 1);
                    if (result == "H")
                    {
                        throw new Exception(SystemMessage.GetMessage(678));
                    }
                }
            }



            #endregion TreatmentDischargeNewForm_ClientSidePostScript

        }

        #region TreatmentDischargeNewForm_Methods





        protected override void AfterContextSavedScript(TTObjectStateTransitionDef transDef)
        {
            base.AfterContextSavedScript(transDef);
            //StartOutPatientPrescription(transDef); Serkanla konuş

        }

        #endregion TreatmentDischargeNewForm_Methods

        #region TreatmentDischargeNewForm_ClientSideMethods
        public void StartOutPatientPrescription(TTObjectStateTransitionDef transDef)
        {

            //TODO:ShowEdit!
            //if (this._TreatmentDischarge.Episode.PatientStatus == PatientStatusEnum.Outpatient)
            //{
            //    if(transDef != null && transDef.ToStateDef.Status == StateStatusEnum.CompletedSuccessfully)
            //    {
            //        string result = ShowBox.Show(ShowBoxTypeEnum.Message,"&Evet,&Hayır","E,H","Uyarı","Muayene Tedavi Sonuç","Hastaya 'Ayaktan Hasta Reçetesi' başlatmak ister misiniz?");
            //        if(result == "E")
            //        {
            //            OutPatientPrescription outPatientPrescription;
            //            TTObjectContext objectContext = new TTObjectContext(false);
            //            Guid savePointGuid = objectContext.BeginSavePoint();
            //            try
            //            {
            //                outPatientPrescription = new OutPatientPrescription(objectContext, this._EpisodeAction);
            //                TTForm frm = TTForm.GetEditForm(outPatientPrescription);
            //                this.PrapareFormToShow(frm);
            //                if(frm.ShowEdit(this.FindForm(), outPatientPrescription) == DialogResult.OK)
            //                    objectContext.Save();
            //            }
            //            catch (Exception ex)
            //            {
            //                objectContext.RollbackSavePoint(savePointGuid);
            //                InfoBox.Alert(ex);

            //            }
            //            finally
            //            {
            //                objectContext.Dispose();
            //            }
            //        }
            //    }
            //}
            var a = 1;
        }



       

        #endregion TreatmentDischargeNewForm_ClientSideMethods
    }
}