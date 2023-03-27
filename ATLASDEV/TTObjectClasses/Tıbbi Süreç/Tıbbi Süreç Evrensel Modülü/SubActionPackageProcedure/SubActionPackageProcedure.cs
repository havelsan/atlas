
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
    public partial class SubActionPackageProcedure : SubActionProcedure
    {
        #region Methods
        // Medula property lerini Paket Giriş işleminden set edilir
        public void SetMedulaPropertiesFromPackageAdding(PackageAdding packageAdding)
        {
            Brans = packageAdding.Brans;
            Doktor = packageAdding.Doktor;
            AyniFarkliKesi = packageAdding.AyniFarkliKesi;
            SagSol = packageAdding.SagSol;
            MedulaReportNo = packageAdding.RaporTakipNo;
            MedulaEuroScore = packageAdding.MedulaEuroScore;
            RefakatciGunSayisi = packageAdding.RefakatciGunSayisi;
            Birim = packageAdding.Birim;
            Sonuc = packageAdding.Sonuc;
            Aciklama = packageAdding.Aciklama;
            OzelDurum = packageAdding.OzelDurum;
            AnesteziDoktor = packageAdding.AnesteziDoktor;
        }

        public override string GetDVOAciklama(AccountTransaction accTrx)
        {
            if (!string.IsNullOrEmpty(Aciklama))
            {
                if (ProcedureObject.MedulaProcedureType == MedulaSUTGroupEnum.ameliyatveGirisimBilgileri && Aciklama.Length > 254)
                    return Aciklama.Substring(0, 254);

                if (ProcedureObject.MedulaProcedureType == MedulaSUTGroupEnum.tetkikveRadyolojiBilgileri && Aciklama.Length > 199)
                    return Aciklama.Substring(0, 199);
            }

            return Aciklama;
        }

        public override string GetDVORefakatciGunSayisi(AccountTransaction accTrx, string yatisBaslangicTarihi = null, string yatisBitisTarihi = null)
        {
            if (RefakatciGunSayisi.HasValue)
                return RefakatciGunSayisi.Value.ToString();

            return null;
        }

        public override string GetDVOBirim()
        {
            return Birim;
        }

        public override string GetDVOSonuc()
        {
            return Sonuc;
        }

        //public override string GetDVOAyniFarkliKesi()
        //{
        //    return AyniFarkliKesi?.ayniFarkliKesiKodu;
        //}

        //public override string GetDVOSagSol()
        //{
        //    if (ProcedureObject.MedulaProcedureType == MedulaSUTGroupEnum.ameliyatveGirisimBilgileri)
        //        return SagSol?.sagSolKodu;

        //    return SagSol?.getSagSol_LR();
        //}

        public override string GetDVOEuroscore()
        {
            if (MedulaEuroScore != null)
                return MedulaEuroScore.ToString();

            return ((int)MedulaEuroScoreEnum.Empty).ToString();
        }

        public override void SetPerformedDate()
        {
            if (CreationDate.HasValue)
            {
                PerformedDate = CreationDate.Value.AddMinutes(1);
            }
        }
        protected override void PostInsert()
        {
            base.PostInsert();
            SetPerformedDate();
        }

        protected override void PostUpdate()
        {
            base.PostUpdate();
            SetPerformedDate();
        }

        #endregion Methods

    }
}