
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
    public partial class PMAddingProcedure : SubActionProcedure
    {
        #region Methods

        protected override void PreInsert()
        {
            base.PreInsert();

            if (SubEpisode != null && PricingDate < SubEpisode.OpeningDate) // E-Nabız için eklendi.
                PricingDate = SubEpisode.OpeningDate;

            if (PricingDate.HasValue)
                CreationDate = PricingDate.Value.AddMinutes(1);   // E-Nabiz tarih kontrolüne takılmasın diye
        }

        public override void SetPerformedDate()
        {
            if (SubEpisode != null && PricingDate < SubEpisode.OpeningDate) // E-Nabız için eklendi.
                PricingDate = SubEpisode.OpeningDate;

            if (PricingDate.HasValue)
            {
                CreationDate = PricingDate.Value.AddMinutes(1);   // E-Nabiz tarih kontrolüne takılmasın diye
                PerformedDate = PricingDate.Value.AddMinutes(2);  // E-Nabiz tarih kontrolüne takılmasın diye
            }
        }

        public override string GetDVOBransKodu(AccountTransaction accTrx)
        {
            if (accTrx != null)
                return accTrx.SubEpisodeProtocol.Brans.Code;

            return null;
        }

        public override string GetDVOAciklama(AccountTransaction accTrx)
        {
            return accTrx.Description;
        }

        public override string GetDVORefakatciGunSayisi(AccountTransaction accTrx, string yatisBaslangicTarihi = null, string yatisBitisTarihi = null)
        {
            DateTime baslangicTarihi;
            DateTime bitisTarihi;

            if (!string.IsNullOrEmpty(yatisBaslangicTarihi))
                baslangicTarihi = Convert.ToDateTime(yatisBaslangicTarihi);
            else
                baslangicTarihi = Convert.ToDateTime(GetDVOYatisBaslangicTarihi(accTrx));

            if (!string.IsNullOrEmpty(yatisBitisTarihi))
                bitisTarihi = Convert.ToDateTime(yatisBitisTarihi);
            else
                bitisTarihi = Convert.ToDateTime(GetDVOYatisBitisTarihi(accTrx));

            return BaseBedProcedure.GetCompanionDayCount(accTrx, baslangicTarihi, bitisTarihi);
        }

        //public override bool CheckSubepisodeClosingDate()
        //{
        //    return false;
        //}

        #endregion Methods
    }
}