
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
    public partial class MIFDetail : TTObject
    {
        protected override void PreInsert()
        {
            Control();
        }

        protected override void PreUpdate()
        {
            throw new TTException("Muhasebe Ýþlem Fiþi Detayý güncellenemez.");
        }

        public void Control()
        {
            if (string.IsNullOrWhiteSpace(AccountCode))
                throw new TTException("Muhasebe Ýþlem Fiþi detayýnda Hesap Kodu boþ olamaz.");

            if (string.IsNullOrWhiteSpace(AccountName))
                throw new TTException("Muhasebe Ýþlem Fiþi detayýnda Hesap / Ayrýntý Adý boþ olamaz.");

            if (!Debt.HasValue && !Credit.HasValue)
                throw new TTException("Muhasebe Ýþlem Fiþi detayýnda Borç Tutarý ve Alacak Tutarý boþ olamaz.");

            if (Debt.HasValue && Credit.HasValue)
                throw new TTException("Muhasebe Ýþlem Fiþi detayýnda Borç Tutarý ve Alacak Tutarý dolu olamaz.");

            if (Debt.HasValue && Debt <= 0)
                throw new TTException("Muhasebe Ýþlem Fiþi detayýnda Borç Tutarý sýfýrdan büyük olmalýdýr.");

            if (Credit.HasValue && Credit <= 0)
                throw new TTException("Muhasebe Ýþlem Fiþi detayýnda Alacak Tutarý sýfýrdan büyük olmalýdýr.");
        }
    }
}