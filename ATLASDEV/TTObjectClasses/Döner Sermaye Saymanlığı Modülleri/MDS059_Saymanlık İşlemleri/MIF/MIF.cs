
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
    public partial class MIF : TTObject
    {
        protected override void PreInsert()
        {
            Control();
        }

        protected override void PreUpdate()
        {
            throw new TTException("Muhasebe Ýþlem Fiþi güncellenemez.");
        }

        public void Control()
        {
            // Ayný bilgilere sahip iki MIF olmamalý
            if (InvoiceTerm != null && CreateUser != null && MIFType.HasValue && CreateDate.HasValue)
            {
                if (InvoiceTerm.MIFs.Select("").Any(x => x.ObjectID != ObjectID &&
                                                    x.InvoiceTerm.ObjectID == InvoiceTerm.ObjectID &&
                                                    x.CreateUser.ObjectID == CreateUser.ObjectID &&
                                                    x.MIFType == MIFType &&
                                                    x.CreateDate == CreateDate))
                    throw new TTException("Ayný Dönem, MÝF türü, Kullanýcý ve Tarih bilgilerine sahip ikinci MÝF kaydedilemez.");
            }

            if (MIFDetails.Count < 2)
                throw new TTException("Muhasebe Ýþlem Fiþinin en az 2 hesap detayý olmalýdýr.");

            List<PayerDefinition> payerList = MIFDetails.Select(x => x.Payer).Distinct().ToList();

            foreach (PayerDefinition payer in payerList)
            {
                List<MIFDetail> payerMIFDetails = MIFDetails.Where(x => x.Payer.ObjectID == payer.ObjectID).ToList();

                // En az bir borç ve bir alacak detayý olmalýdýr
                if (payerMIFDetails.Count < 2)
                    throw new TTException("Muhasebe Ýþlem Fiþinde '" + payer.Name + "' kurumunun en az 2 hesap detayý olmalýdýr.");

                // Detaylarda ayný hesap kodu tekrar edemez
                List<string> accountCodes = payerMIFDetails.Select(x => x.AccountCode).ToList();
                if (accountCodes.Distinct().Count() < accountCodes.Count)
                    throw new TTException("Muhasebe Ýþlem Fiþinde '" + payer.Name + "' kurumu için ayný Hesap Kodu birden fazla olamaz.");

                // Detaylarda ayný açýklama tekrar edemez
                //List<string> descriptions = payerMIFDetails.Select(x => x.AccountName).ToList();
                //if (descriptions.Distinct().Count() < descriptions.Count)
                //    throw new TTException("Muhasebe Ýþlem Fiþinde '" + payer.Name + "' kurumu için ayný Hesap Adý birden fazla olamaz.");

                // Borç ve alacak toplamlarý eþit olmalýdýr
                decimal totalDebt = payerMIFDetails.Sum(x => x.Debt.HasValue ? (decimal)x.Debt.Value : 0);
                decimal totalCredit = payerMIFDetails.Sum(x => x.Credit.HasValue ? (decimal)x.Credit.Value : 0);
                if (totalDebt != totalCredit)
                    throw new TTException("Muhasebe Ýþlem Fiþinde '" + payer.Name + "' kurumunun Borç Tutarý ve Alacak Tutarý toplamlarý eþit olmalýdýr.");
            }
        }

        public string Name
        {
            get
            {
                return InvoiceTerm.Name + " > " + Common.GetDisplayTextOfDataTypeEnum(MIFType) + " > " + CreateDate.ToString() + " (" + CreateUser.Name + ")";
            }
        }
    }
}