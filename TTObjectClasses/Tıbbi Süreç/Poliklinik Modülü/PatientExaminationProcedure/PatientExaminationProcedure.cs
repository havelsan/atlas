
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
    /// Hasta Muayenesi Prosedürü
    /// </summary>
    public partial class PatientExaminationProcedure : SubActionProcedure
    {
        #region Methods
        /// <summary>
        /// PatientExaminationdan otomatik olarak verilen Guide ait ProcedürDefitiondan (örnek Özel muayene farkı)  yeni bir   PateintExaminationProcedure yaratmak için kullanılır
        /// </summary>
        /// <param name="patientExamination">Yaratılacak PatientExaminationProcedure'ün  PatientExamination alanına atanır </param>
        /// <param name="guid">Yaratılacak PatientExaminationProcedure'ün ProsedürObject'ine atanacak ProcedureDefinition'ın Guidi </param>
        public PatientExaminationProcedure(PatientExamination patientExamination, string guid) : this(patientExamination.ObjectContext)
        {
            Guid procedureGuid = new Guid(guid);
            //YAPILACAKLAR//Standart procedürler kod içinde nasıl çekilecek hangi özelliği ortak olacak Guidi ortak olacak mı?
            ProcedureObject = (ProcedureDefinition)patientExamination.ObjectContext.GetObject(procedureGuid, "PROCEDUREDEFINITION");
            ProcedureDoctor = patientExamination.ProcedureDoctor;
            ProcedureByUser = patientExamination.ProcedureDoctor;
            PerformedDate = Common.RecTime();
            patientExamination.PatientExaminationProcedures.Add(this);
        }
        public OzelDurum GetOzelDurum()
        {
            // Kontrol muayenesinin Vakabaşı ve muayene hizmetinin özel durum bilgisi "1 İşlem Tutarını Talep Etmiyorum" olacak
            if (PatientExamination.SubEpisode.PatientAdmission.AdmissionStatus == AdmissionStatusEnum.Kontrol)
                return OzelDurum.GetOzelDurum("1");

            foreach (DiagnosisGrid diagnosis in PatientExamination.Diagnosis)
            {
                if (diagnosis.Diagnose.DiagnosisDefOzelDurumlar.Count > 0)
                {
                    bool hasExistsReport = false;
                    TTObjectContext objectContext = new TTObjectContext(true);
                    BindingList<ParticipatnFreeDrugReport> reportList = ParticipatnFreeDrugReport.GetCompletedBySubEpisode(objectContext, PatientExamination.SubEpisode.ObjectID);
                    if (reportList.Count > 0)
                        hasExistsReport = true;
                    foreach (DiagnosisDefOzelDurum diagnosisDefOzelDurum in diagnosis.Diagnose.DiagnosisDefOzelDurumlar)
                    {
                        //Muayene katılım payından muaf olması için gerekli sağlık kurulu raporu var.
                        if (diagnosisDefOzelDurum.OzelDurum.ozelDurumKodu == "6" && hasExistsReport)
                            return diagnosisDefOzelDurum.OzelDurum;
                        //Muayene katılım payından muaf olması için gerekli sağlık kurulu raporu yok
                        if (diagnosisDefOzelDurum.OzelDurum.ozelDurumKodu == "8" && !hasExistsReport)
                            return diagnosisDefOzelDurum.OzelDurum;
                    }
                }
            }
            return null;
        }
           
        public override string GetDVOBransKodu(AccountTransaction accTrx)
        {
            if (accTrx != null)
                return accTrx.SubEpisodeProtocol.Brans.Code;

            return null;
        }

        public override string GetDVODrTescilNo(string branchCode)
        {
            if (ProcedureDoctor != null)
                return ProcedureDoctor.DiplomaRegisterNo;

            if (PatientExamination != null && PatientExamination.ResponsibleDoctor != null)
                return PatientExamination.ResponsibleDoctor.DiplomaRegisterNo;

            if (PatientExamination != null && PatientExamination.ProcedureDoctor != null)
                return PatientExamination.ProcedureDoctor.DiplomaRegisterNo;

            return Common.GetDoctorRegisterNoByBranchCode(branchCode);
        }

        public override string GetDVOOzelDurum(AccountTransaction accTrx)
        {
            if (accTrx.OzelDurum == null)
            {
                OzelDurum ozelDurum = GetOzelDurum();
                if (ozelDurum != null)
                {
                    if (!accTrx.ObjectContext.IsReadOnly)
                        accTrx.OzelDurum = ozelDurum;

                    return ozelDurum.ozelDurumKodu;
                }
            }

            return null;
        }

        public override void SetPerformedDate()// İşlemin yapıldığı tarihi set edecek şekilde override edilmeli
        {
            if (CreationDate == null || (CreationDate != null && PatientExamination.ProcessDate != null && CreationDate > PatientExamination.ProcessDate))
                CreationDate = PatientExamination.ProcessDate;
            if (PerformedDate == null && PatientExamination.ProcessEndDate != null)
                PerformedDate = PatientExamination.ProcessEndDate;
            if (PerformedDate != null && CreationDate != null && CreationDate >= PerformedDate)
                PerformedDate = CreationDate.Value.AddMinutes(1);
        }

        public override bool SendToENabiz(bool isNewInserted)
        {
            if (IsOldAction == true)
                return false;
            if (CurrentStateDefID == PatientExaminationProcedure.States.Completed)
                return true;
            return isNewInserted;
        }

        #endregion Methods

    }
}