
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



using TTStorageManager;
using System.Runtime.Versioning;


namespace TTObjectClasses
{
    /// <summary>
    /// DentalConsultation
    /// </summary>
    public partial class DentalConsultation : DentalExamination, ICreateSubEpisode
    {
        public partial class OLAP_GetDentalConsultation_Class : TTReportNqlObject
        {
        }

        protected override void PostInsert()
        {
            #region PostInsert

            base.PostInsert();

            #endregion PostInsert
        }

        protected void PreTransition_Examination2Cancelled()
        {
            // From State : Examination   To State : Cancelled
            #region PreTransition_Examination2Cancelled
            CheckDentalLinkActionsIsCompleted();
            #endregion PreTransition_Examination2Cancelled
        }

        protected void PostTransition_Examination2Cancelled()
        {
            // From State : Examination   To State : Cancelled
            #region PostTransition_Examination2Cancelled
            Cancel();
            CancelMyExaminationQueueItems();
            #endregion PostTransition_Examination2Cancelled
        }

        protected void UndoTransition_Examination2Cancelled(TTObjectStateTransitionDef transitionDef)
        {
            // From State : Examination   To State : Cancelled
            #region UndoTransition_Examination2Cancelled
            NoBackStateBack();
            #endregion UndoTransition_Examination2Cancelled
        }

        protected void PostTransition_Examination2Completed()
        {
            // From State : Examination   To State : Completed
            #region PostTransition_Examination2Completed

            if (!Paid())
                throw new TTUtils.TTException(SystemMessage.GetMessage(141));

            //            FireDentalTreatmentRequestBySuggestedTreatments();
            //            FireDentalProsthesisRequestBySuggestedProsthesis();
            /* kpayi --- UpdateMedulaPatientParticipationToSentServer();*/
            CompleteMyExaminationQueueItems();
            #endregion PostTransition_Examination2Completed
        }

        protected void UndoTransition_Examination2Completed(TTObjectStateTransitionDef transitionDef)
        {
            // From State : Examination   To State : Completed
            #region UndoTransition_Examination2Completed
            double limit = CheckIfDayLimitExceeded();
            if (limit != 0)
                throw new Exception(SystemMessage.GetMessageV3(1143, new string[] { limit.ToString() }));
            //if (this.MuayeneGiris != null)
            //{
            //    if (this.MuayeneGiris.CurrentStateDefID == MuayeneGiris.States.SentServer)
            //        this.MuayeneGiris.CurrentStateDefID = MuayeneGiris.States.New;
            //}
            //Episode un açılış tarihi 10 günden önceyse vaka açık hale gelir.
            if (SubEpisode.IsOpenedInTenDays() == true)
                UndoCloseEpisode();
            #endregion UndoTransition_Examination2Completed
        }

        protected void PostTransition_Examination2PatientNoShown()
        {
            // From State : Examination   To State : PatientNoShown
            #region PostTransition_Examination2PatientNoShown

            Cancel();
            CancelMyExaminationQueueItems();
            #endregion PostTransition_Examination2PatientNoShown
        }

        protected void UndoTransition_Examination2PatientNoShown(TTObjectStateTransitionDef transitionDef)
        {
            // From State : Examination   To State : PatientNoShown
            #region UndoTransition_Examination2PatientNoShown
            NoBackStateBack();
            #endregion UndoTransition_Examination2PatientNoShown
        }

        protected void UndoTransition_New2Appointment(TTObjectStateTransitionDef transitionDef)
        {
            // From State : New   To State : Appointment
            #region UndoTransition_New2Appointment
            NoBackStateBack();
            #endregion UndoTransition_New2Appointment
        }

        protected void PreTransition_New2Cancelled()
        {
            // From State : New   To State : Cancelled
            #region PreTransition_New2Cancelled
            CheckDentalLinkActionsIsCompleted();
            #endregion PreTransition_New2Cancelled
        }

        protected void PostTransition_New2Cancelled()
        {
            // From State : New   To State : Cancelled
            #region PostTransition_New2Cancelled
            Cancel();
            #endregion PostTransition_New2Cancelled
        }

        protected void UndoTransition_New2Cancelled(TTObjectStateTransitionDef transitionDef)
        {
            // From State : New   To State : Cancelled
            #region UndoTransition_New2Cancelled
            NoBackStateBack();
            #endregion UndoTransition_New2Cancelled
        }

        protected void PreTransition_New2Examination()
        {
            // From State : New   To State : Examination
            #region PreTransition_New2Examination

            //if(this.OlapDate == null)
            //    this.OlapDate = DateTime.Now ;

            //this.AddDentalConsultationProcedure();

            #endregion PreTransition_New2Examination
        }

        protected void PostTransition_New2Examination()
        {
            // From State : New   To State : Examination
            #region PostTransition_New2Examination

            //GetMedulaProvision();            


            #endregion PostTransition_New2Examination
        }

        protected void PostTransition_New2PatientNoShown()
        {
            // From State : New   To State : PatientNoShown
            #region PostTransition_New2PatientNoShown
            Cancel();
            #endregion PostTransition_New2PatientNoShown
        }

        protected void UndoTransition_New2PatientNoShown(TTObjectStateTransitionDef transitionDef)
        {
            // From State : New   To State : PatientNoShown
            #region UndoTransition_New2PatientNoShown
            NoBackStateBack();
            #endregion UndoTransition_New2PatientNoShown
        }

        #region Methods
        private void FireDentalTreatmentRequestBySuggestedTreatments()
        {
            int sTCount = 0;
            ArrayList suggestedTreatmentArray = new ArrayList();
            //Tedavi Önerilerine girilen her bir satırdaki departmentlar(Birimler) bir ArrayListe doldurulur(bir department yalnız bir kez eklenir)
            foreach (DentalExaminationSuggestedTreatment st in SuggestedTreatments)
            {
                if (st.SuggestedTreatmentProcedure != null)
                {
                    if (suggestedTreatmentArray.Contains(st.Department) == false)
                    {
                        suggestedTreatmentArray.Add(st.Department);
                    }
                }
            }
            sTCount = suggestedTreatmentArray.Count;
            sTCount--;
            //Array lise doldurulan birimlerin her biri için bir diş tedavi fire edilir.
            for (int k = 0; k <= sTCount; k++)
            {
                DentalTreatmentRequest dentalTreatmentRequest = new DentalTreatmentRequest(ObjectContext, this, (TTObjectClasses.ResSection)suggestedTreatmentArray[k]);
                //Önarilen Tedaviler fire edilen diş tedaviye atanır.
                foreach (DentalExaminationSuggestedTreatment st in SuggestedTreatments)
                {
                    if (st.Department == (TTObjectClasses.ResSection)suggestedTreatmentArray[k])
                    {
                        DentalTreatmentRequestSuggestedTreatment dentalTreatmentRequestSuggestedTreatment = new DentalTreatmentRequestSuggestedTreatment(ObjectContext, (DentalTreatmentRequestSuggestedTreatment)st);
                        dentalTreatmentRequest.SuggestedTreatments.Add(dentalTreatmentRequestSuggestedTreatment);
                    }
                }
            }
        }
        /// <summary>
        /// Diş Muayeneden girilen Önerilen Protezler için  aynı bölümdekiler bir arada olacak şekilde Diş protez işlemi fire edilmesi sağlanır.
        /// </summary>
        private void FireDentalProsthesisRequestBySuggestedProsthesis()
        {
            int sPCount = 0;
            ArrayList suggestedProsthesistArray = new ArrayList();
            //Önerilen Proteze girilen her bir satırdaki departmentlar bir ArrayListe doldurulur(bir department yalnız bir kez eklenir)
            foreach (DentalExaminationSuggestedProsthesis sp in SuggestedProsthesis)
            {
                if (sp.SuggestedProsthesisProcedure != null)
                {
                    if (suggestedProsthesistArray.Contains(sp.Department) == false)
                    {
                        suggestedProsthesistArray.Add(sp.Department);
                    }
                }
            }
            sPCount = suggestedProsthesistArray.Count;
            sPCount--;
            //Array lise doldurulan birimlerin her biri için bir diş protez fire edilir .
            for (int k = 0; k <= sPCount; k++)
            {
                DentalProsthesisRequest dentalProsthesisRequest = new DentalProsthesisRequest(ObjectContext, this, (TTObjectClasses.ResSection)suggestedProsthesistArray[k]);
                //Önerilen Protezler fire edilen diş proteze atanır.
                foreach (DentalExaminationSuggestedProsthesis sp in SuggestedProsthesis)
                {
                    if (sp.Department == (TTObjectClasses.ResSection)suggestedProsthesistArray[k])
                    {
                        DentalProsthesisRequestSuggestedProsthesis dentalProsthesisRequestSuggestedProsthesis = new DentalProsthesisRequestSuggestedProsthesis(ObjectContext, (DentalProsthesisRequestSuggestedProsthesis)sp);
                        dentalProsthesisRequest.SuggestedProsthesis.Add(dentalProsthesisRequestSuggestedProsthesis);

                    }

                }
            }
        }

        public override bool IsNewSubEpisodeNeeded()
        {
            if (base.IsNewSubEpisodeNeeded() == false)
                return false;

            if (SubEpisode.IsSGK && Episode.PatientStatus == PatientStatusEnum.Inpatient)
            {
                foreach (EpisodeAction ea in Episode.EpisodeActions)
                {
                    DentalConsultation dc = ea as DentalConsultation;
                    if (dc != null)
                    {
                        SubEpisode se = dc.GetSubEpisodeCreatedByMe();
                        if (se != null)
                        {
                            SubEpisodeProtocol sep = se.SGKSEP;
                            if (sep != null)
                            {
                                if (!string.IsNullOrEmpty(sep.MedulaTakipNo) && (sep.MedulaProvizyonTipi.provizyonTipiKodu.Equals("A") || sep.Brans.Code.Equals(MasterResource.ResourceSpecialities[0].Speciality.Code)))
                                    return false;
                            }
                        }
                    }
                }

                return true;
            }

            return false;
        }

        // SEP in değiştirilmesi gereken propertyleri varsa bu metodda set edilmeli
        public override void FillLocalSEPProperties(ref SubEpisodeProtocol sep)
        {
            //Tedavi Tipi (Zorunlu)
            TedaviTipi tedaviTipi = TedaviTipi.GetTedaviTipi("13");

            // Provizyon Tipi Acil olan hastalarda sadece 5700 branşı ile takip alınabiliyor.
            if (sep.MedulaProvizyonTipi.provizyonTipiKodu.Equals("A"))
                sep.Brans = SpecialityDefinition.GetBrans("5700");

            // Bağlı Takip
            SubEpisodeProtocol parentSEP = Episode.GetLastSGKSEP();
            if (parentSEP != null)
                sep.ParentSEP = parentSEP;
        }

        private void CheckDentalLinkActionsIsCompleted()
        {
            if (HasUnCompletedLinkedAction())
            {
                throw new TTException(SystemMessage.GetMessage(1144));
            }
        }

        private void AddDentalConsultationProcedure()
        {
            // Normal muayene ücreti oluşması için normal muayene procedürü atar
            //            bool konsultasyonEkle = true;
            //            Guid konsultasyonGuid = ProcedureDefinition.DentalConsultationProcedureObjectId;
            //            RelationshipDefinition relationshipDefinition = null;
            //
            //            foreach (SubActionProcedure sp in this.SubactionProcedures)
            //            {
            //                if (sp.CurrentStateDef.Status != StateStatusEnum.Cancelled)
            //                {
            //                    if (sp.ProcedureObject.ObjectID == konsultasyonGuid)
            //                        konsultasyonEkle = false;
            //                }
            //            }
            //
            //            if (konsultasyonEkle == true)
            //            {
            //                DentalConsultationProcedure dentalConsultationProcedure = null;
            //                dentalConsultationProcedure = new DentalConsultationProcedure(this, konsultasyonGuid.ToString());
            //                dentalConsultationProcedure.AccountOperation(AccountOperationTimeEnum.PREPOST);
            //            }
        }

        #endregion Methods

        protected void PreTransition(TTObjectStateTransitionDef transDef)
        {
            if (transDef.ObjectDef.CodeName != typeof(DentalConsultation).Name)
                return;

            var fromState = transDef.FromStateDefID;
            var toState = transDef.ToStateDefID;

            if (fromState == DentalConsultation.States.Examination && toState == DentalConsultation.States.Cancelled)
                PreTransition_Examination2Cancelled();
            else if (fromState == DentalConsultation.States.New && toState == DentalConsultation.States.Cancelled)
                PreTransition_New2Cancelled();
            else if (fromState == DentalConsultation.States.New && toState == DentalConsultation.States.Examination)
                PreTransition_New2Examination();
        }

        protected void PostTransition(TTObjectStateTransitionDef transDef)
        {
            if (transDef.ObjectDef.CodeName != typeof(DentalConsultation).Name)
                return;

            var fromState = transDef.FromStateDefID;
            var toState = transDef.ToStateDefID;

            if (fromState == DentalConsultation.States.Examination && toState == DentalConsultation.States.Cancelled)
                PostTransition_Examination2Cancelled();
            else if (fromState == DentalConsultation.States.Examination && toState == DentalConsultation.States.Completed)
                PostTransition_Examination2Completed();
            else if (fromState == DentalConsultation.States.Examination && toState == DentalConsultation.States.PatientNoShown)
                PostTransition_Examination2PatientNoShown();
            else if (fromState == DentalConsultation.States.New && toState == DentalConsultation.States.Cancelled)
                PostTransition_New2Cancelled();
            else if (fromState == DentalConsultation.States.New && toState == DentalConsultation.States.Examination)
                PostTransition_New2Examination();
            else if (fromState == DentalConsultation.States.New && toState == DentalConsultation.States.PatientNoShown)
                PostTransition_New2PatientNoShown();

            //if (toState == States.Examination)
            //    this.SubEpisode.ArrangeMeOrCreateNewSubEpisode(this, false);  // SubEpisode ve SubEpisodeProtocol oluşturup meduladan takip alan metod
        }

        protected void UndoTransition(TTObjectStateTransitionDef transDef)
        {
            if (transDef.ObjectDef.CodeName != typeof(DentalConsultation).Name)
                return;

            var fromState = transDef.FromStateDefID;
            var toState = transDef.ToStateDefID;

            if (fromState == DentalConsultation.States.Examination && toState == DentalConsultation.States.Cancelled)
                UndoTransition_Examination2Cancelled(transDef);
            else if (fromState == DentalConsultation.States.Examination && toState == DentalConsultation.States.Completed)
                UndoTransition_Examination2Completed(transDef);
            else if (fromState == DentalConsultation.States.Examination && toState == DentalConsultation.States.PatientNoShown)
                UndoTransition_Examination2PatientNoShown(transDef);
            else if (fromState == DentalConsultation.States.New && toState == DentalConsultation.States.Appointment)
                UndoTransition_New2Appointment(transDef);
            else if (fromState == DentalConsultation.States.New && toState == DentalConsultation.States.Cancelled)
                UndoTransition_New2Cancelled(transDef);
            else if (fromState == DentalConsultation.States.New && toState == DentalConsultation.States.PatientNoShown)
                UndoTransition_New2PatientNoShown(transDef);
        }

    }
}