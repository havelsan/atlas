
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
    /// Konsültasyon
    /// </summary>
    public partial class ConsultationProcedure : SubActionProcedure
    {
        public partial class OLAP_GetConsultationProcedure_Class : TTReportNqlObject
        {
        }

        public partial class GetConsultationProcedureNQL_Class : TTReportNqlObject
        {
        }

        public partial class GetByMasterActionNQL_Class : TTReportNqlObject
        {
        }

        public partial class OLAP_GetCancelledConsultationProcedure_Class : TTReportNqlObject
        {
        }

        public partial class GetConsultationProcedureByEpisodeNQL_Class : TTReportNqlObject
        {
        }

        public partial class OLAP_GetConsultationProcedureNew_Class : TTReportNqlObject
        {
        }

        public partial class VEM_KONSULTASYON_Class : TTReportNqlObject
        {
        }

        protected override void PreInsert()
        {
            #region PreInsert

            base.PreInsert();
            OlapLastUpdate = DateTime.Now;

            #endregion PreInsert
        }

        protected override void PreUpdate()
        {
            #region PreUpdate
            base.PreUpdate();
            OlapLastUpdate = DateTime.Now;

            #endregion PreUpdate
        }

        protected override void PostUpdate()
        {
            #region PostUpdate





            base.PostUpdate();

            if (ProcedureSpeciality != null)
            {
                if (ProcedureSpeciality.Name != null)
                {
                    foreach (AccountTransaction AccTrx in AccountTransactions)
                    {
                        if (AccTrx.ExternalCode == "520010" && AccTrx.CurrentStateDefID != AccountTransaction.States.Cancelled)
                        {
                            if (AccTrx.Description.IndexOf(ProcedureSpeciality.Name) == -1)
                                AccTrx.Description = AccTrx.Description + " (" + ProcedureSpeciality.Name + ")";
                        }
                    }

                    ExtraDescription = "(" + ProcedureSpeciality.Name + ")";
                }
            }

            if (CurrentStateDefID == ConsultationProcedure.States.Completed)
            {
                if (SubEpisode != null && SendToENabiz(true))
                    new SendToENabiz(ObjectContext, SubEpisode, SubEpisode.ObjectID, SubEpisode.ObjectDef.Name, "252", Common.RecTime());
            }
            //Doktor ya da diş hekimi olmayan birinden istenen konsültasyon hizmetinin Medulaya gönderilmemesi için yazıldı. Aksi taktirde Medula dan Doktor Tescil numarası boş olamaz hatası alınıyor.
            if (Consultation.ProcedureDoctor != null && Consultation.ProcedureDoctor.UserType != UserTypeEnum.Doctor && Consultation.ProcedureDoctor.UserType != UserTypeEnum.Dentist)
            {
                foreach (AccountTransaction AccTrx in AccountTransactions)
                {
                    if (AccTrx.ExternalCode == "520010" && AccTrx.IsMedulaAccountTransaction() && (AccTrx.CurrentStateDefID == AccountTransaction.States.New || AccTrx.CurrentStateDefID == AccountTransaction.States.ToBeNew))
                    {
                        AccTrx.CurrentStateDefID = AccountTransaction.States.MedulaDontSend;
                    }
                }
            }


            #endregion PostUpdate
        }

        #region Methods
        public ConsultationProcedure(Consultation consultation, string guid) : this(consultation.ObjectContext)
        {
            Guid procedureGuid = new Guid(guid);
            //YAPILACAKLAR//Standart procedürler kod içinde nasıl çekilecek hangi özelliği ortak olacak Guidi ortak olacak mı?
            ProcedureObject = (ProcedureDefinition)consultation.ObjectContext.GetObject(procedureGuid, "PROCEDUREDEFINITION");
            ProcedureDoctor = consultation.ProcedureDoctor;
            ProcedureByUser = consultation.ProcedureDoctor;
            consultation.ConsultationProcedures.Add(this);
        }

        public override bool GetProcedureDoctorFromMyEpisodeAction()
        {
            return false;
        }

        public override void SetProcedureDoctorAsCurrentResource()
        {
            if (CurrentStateDef.Status == StateStatusEnum.Uncompleted)
            {
                if (ProcedureDoctor == null)
                {
                    if (Common.CurrentResource.UserType == UserTypeEnum.Doctor || Common.CurrentResource.UserType == UserTypeEnum.Dentist || Common.CurrentResource.UserType == UserTypeEnum.Dietician || Common.CurrentResource.UserType == UserTypeEnum.Psychologist)
                    {
                        IList userResources = UserResource.GetByUserAndResource(ObjectContext, Common.CurrentResource.ObjectID, Consultation.MasterResource.ObjectID);
                        if (userResources.Count > 0)
                            ProcedureDoctor = Common.CurrentResource;
                    }
                }
            }
        }

        public override void SetPerformedDate()// İşlemin yapıldığı tarihi set edecek şekilde override edilmeli
        {
            if (CreationDate == null || (CreationDate != null && Consultation.ProcessDate != null && CreationDate > Consultation.ProcessDate))
                CreationDate = Consultation.ProcessDate;
            if (PerformedDate == null && Consultation.ProcessEndDate != null)
                PerformedDate = Consultation.ProcessEndDate;
            if (PerformedDate != null && CreationDate != null && CreationDate >= PerformedDate)
                PerformedDate = CreationDate.Value.AddMinutes(1);
            //Geçmişe dönük hizmet girildiğinde saat - dakika farkıyla subepisode un açılış tarihinden önceye hizmet girilemesin diye eklendi.
            if (PerformedDate != null && PerformedDate <= SubEpisode.OpeningDate)
            {
                CreationDate = SubEpisode.OpeningDate.Value.AddMinutes(1);
                PerformedDate = SubEpisode.OpeningDate.Value.AddMinutes(2);
            }
        }

        public override bool SendToENabiz(bool isNewInserted)
        {
            if (IsOldAction == true)
                return false;
            if (CurrentStateDefID == ConsultationProcedure.States.Completed)
                return true;
            return isNewInserted;
        }

        #endregion Methods

    }
}