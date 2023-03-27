
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
    /// Refakatçi Hizmeti
    /// </summary>
    public partial class CompanionProcedure : SubActionProcedure
    {
        /// <summary>
        /// Açıklama
        /// </summary>
        public string GetMedulaDescription()
        {
            if (CompanionApplication != null && CompanionApplication.MedicalReasonForCompanion != null)
            {
                if (CompanionApplication.MedicalReasonForCompanion.Length > 255)
                    return CompanionApplication.MedicalReasonForCompanion.Substring(0, 255);
                else
                    return CompanionApplication.MedicalReasonForCompanion;
            }

            return null;
        }

        #region Methods
        // Refakatçi hizmetinin, yatak hizmetinin Refakatçi Gün Sayısı ile gönderilmesi gerekiyor.
        //public override object GetDVO(AccountTransaction AccTrx)
        //{
        //    HizmetKayitIslemleri.hastaYatisBilgisiDVO hastaYatisBilgisiDVO= new HizmetKayitIslemleri.hastaYatisBilgisiDVO();

        //    if(this.CompanionApplication != null && this.CompanionApplication.InpatientAdmission != null && this.CompanionApplication.InpatientAdmission.MasterResource != null)
        //    {
        //        foreach (ResourceSpecialityGrid resSpeciality in this.CompanionApplication.InpatientAdmission.MasterResource.ResourceSpecialities)
        //        {
        //            if(resSpeciality.Speciality != null)
        //            {
        //                hastaYatisBilgisiDVO.bransKodu = resSpeciality.Speciality.Code;
        //                break;
        //            }
        //        }
        //    }

        //    if(this.CompanionApplication != null && this.CompanionApplication.InpatientAdmission != null && this.CompanionApplication.InpatientAdmission.ProcedureDoctor != null )
        //    {
        //        if (this.CompanionApplication.InpatientAdmission.ProcedureDoctor.DiplomaRegisterNo != null)
        //            hastaYatisBilgisiDVO.drTescilNo = this.CompanionApplication.InpatientAdmission.ProcedureDoctor.DiplomaRegisterNo;
        //    }

        //    if(string.IsNullOrEmpty(hastaYatisBilgisiDVO.drTescilNo))
        //        hastaYatisBilgisiDVO.drTescilNo = Common.GetDoctorRegisterNoByBranchCode(hastaYatisBilgisiDVO.bransKodu);

        //    hastaYatisBilgisiDVO.sutKodu = AccTrx.MedulaProcedureCode;
        //    hastaYatisBilgisiDVO.hizmetSunucuRefNo = AccTrx.MedulaReferenceNumber;
        //    //hastaYatisBilgisiDVO.islemSiraNo = AccTrx.MedulaProcessNo;
        //    hastaYatisBilgisiDVO.refakatciGunSayisi = null;

        //    if(AccTrx.TransactionDate != null)
        //    {
        //        hastaYatisBilgisiDVO.yatisBaslangicTarihi = ((DateTime)AccTrx.TransactionDate).ToString("dd.MM.yyyy");
        //        hastaYatisBilgisiDVO.yatisBitisTarihi = (((DateTime)AccTrx.TransactionDate).AddDays(1)).ToString("dd.MM.yyyy");
        //    }
        //    else
        //    {
        //        hastaYatisBilgisiDVO.yatisBaslangicTarihi = null;
        //        hastaYatisBilgisiDVO.yatisBitisTarihi = null;
        //    }

        //    hastaYatisBilgisiDVO.ozelDurum = null;
        //    hastaYatisBilgisiDVO.aciklama = this.GetMedulaDescription();
        //    hastaYatisBilgisiDVO.cokluOzelDurum = null;

        //    return hastaYatisBilgisiDVO;
        //}

        public override void SetPerformedDate()
        {
            if (CreationDate.HasValue)
            {
                PerformedDate = CreationDate.Value.AddMinutes(1);
            }

            //Geçmişe dönük hizmet girildiğinde saat - dakika farkıyla subepisode un açılış tarihinden önceye hizmet girilemesin diye eklendi.
            if (PerformedDate != null && PerformedDate <= SubEpisode.OpeningDate)
            {
                CreationDate = SubEpisode.OpeningDate.Value.AddMinutes(1);
                PerformedDate = SubEpisode.OpeningDate.Value.AddMinutes(2);
            }
        }


        #endregion Methods

    }
}