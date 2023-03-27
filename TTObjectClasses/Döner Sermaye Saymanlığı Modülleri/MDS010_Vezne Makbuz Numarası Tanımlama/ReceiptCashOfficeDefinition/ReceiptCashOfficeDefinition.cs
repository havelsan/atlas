
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
    /// Sayman Mutemetliği / Vezne Alındı Numarası Tanımlama
    /// </summary>
    public partial class ReceiptCashOfficeDefinition : TTDefinitionSet
    {
        public partial class GetReceiptCashOfficeDefinitions_Class : TTReportNqlObject
        {
        }

        protected override void PreInsert()
        {
            #region PreInsert

            base.PreInsert();
            OrderNo.GetNextValue(CashOffice.ObjectID.ToString());

            #endregion PreInsert
        }
        protected override void PreUpdate()
        {
            #region PreUpdate
            base.PreUpdate();

            #endregion PreUpdate
        }

        protected override void PreDelete()
        {
            #region PreDelete
            throw new TTUtils.TTException(TTUtils.CultureService.GetText("M27038", "Tanımlanmış Koçan Silinemez! Lütfen koçanın durumunu 'Pasif' yapınız."));
            //base.PreDelete();

            #endregion PreDelete
        }

        protected override void PostDelete()
        {
            #region PostDelete

            base.PostDelete();

            #endregion PostDelete
        }
        public static long SkipUnusedReceiptNoAndGetCurrentNo(ReceiptCashOfficeDefinition receiptCashOfficeDefinition)
        {
            List<UnusedReceiptNoDefinition> unusedReceiptDefList = receiptCashOfficeDefinition.UnusedReceiptNoDef.Where(x => x.ReceiptCashOfficeDefinition.ObjectID == receiptCashOfficeDefinition.ObjectID).ToList();
            if (unusedReceiptDefList != null && unusedReceiptDefList.Count() > 0)
            {
                UnusedReceiptNoDefinition findRange = unusedReceiptDefList.OrderBy(x => x.UnusedReceiptStartNo).ToList().FindLast(x => x.UnusedReceiptStartNo <= receiptCashOfficeDefinition.CurrentReceiptNumber && x.UnusedReceiptEndNo >= receiptCashOfficeDefinition.CurrentReceiptNumber);
                if (findRange != null)
                {
                    return findRange.UnusedReceiptEndNo.Value + 1;
                }
            }
            return receiptCashOfficeDefinition.CurrentReceiptNumber.Value;
        }

        public static string GetCurrentReceiptNumber(ReceiptCashOfficeDefinition receiptCashOfficeDefinition)
        {
            receiptCashOfficeDefinition.CurrentReceiptNumber = SkipUnusedReceiptNoAndGetCurrentNo(receiptCashOfficeDefinition);
            //AutoActiveDeActivateReceiptCashOffice();
            return receiptCashOfficeDefinition.ReceiptSeriesNo + receiptCashOfficeDefinition.CurrentReceiptNumber;
        }

        public static void SetNextReceiptNumber(ReceiptCashOfficeDefinition receiptCashOfficeDefinition)
        {
            receiptCashOfficeDefinition.CurrentReceiptNumber = SkipUnusedReceiptNoAndGetCurrentNo(receiptCashOfficeDefinition) + 1;
            //AutoActiveDeActivateReceiptCashOffice();
        }
        public static string GetCurrentCreditCardReceiptNumber(ReceiptCashOfficeDefinition receiptCashOfficeDefinition)
        {
            if (receiptCashOfficeDefinition.UseDifferentNumberForCC.HasValue == false || receiptCashOfficeDefinition.UseDifferentNumberForCC == false)
                return GetCurrentReceiptNumber(receiptCashOfficeDefinition);
            else
                return receiptCashOfficeDefinition.CreditCardSeriesNo + receiptCashOfficeDefinition.CurrentCreditCardNumber;
        }

        public static void SetNextCreditCardReceiptNumber(ReceiptCashOfficeDefinition receiptCashOfficeDefinition)
        {
            if (receiptCashOfficeDefinition.UseDifferentNumberForCC.HasValue == false || receiptCashOfficeDefinition.UseDifferentNumberForCC == false)
                SetNextReceiptNumber(receiptCashOfficeDefinition);
            else
                receiptCashOfficeDefinition.CurrentCreditCardNumber = receiptCashOfficeDefinition.CurrentCreditCardNumber + 1;
        }
        #region Methods
        //public static string GetCurrentReceiptNumber(ReceiptCashOfficeDefinition receiptCashOfficeDefinition)
        //{
        //    //ReceiptCashOfficeDefinition.AutoActiveDeActivateReceiptCashOfficeDef(receiptCashOfficeDefinition, cashOffice);
        //    return receiptCashOfficeDefinition.ReceiptSeriesNo + receiptCashOfficeDefinition.CurrentReceiptNumber;
        //}

        //public static void SetNextReceiptNumber(ReceiptCashOfficeDefinition receiptCashOfficeDefinition)
        //{
        //    receiptCashOfficeDefinition.CurrentReceiptNumber = receiptCashOfficeDefinition.CurrentReceiptNumber + 1;
        //}

        //public static string GetCurrentCreditCardReceiptNumber(ReceiptCashOfficeDefinition receiptCashOfficeDefinition)
        //{
        //    if (receiptCashOfficeDefinition.UseDifferentNumberForCC == false)
        //        return ReceiptCashOfficeDefinition.GetCurrentReceiptNumber(receiptCashOfficeDefinition);
        //    else
        //        return receiptCashOfficeDefinition.CreditCardSeriesNo + receiptCashOfficeDefinition.CurrentCreditCardNumber;
        //}

        //public static void SetNextCreditCardReceiptNumber(ReceiptCashOfficeDefinition receiptCashOfficeDefinition)
        //{
        //    if (receiptCashOfficeDefinition.UseDifferentNumberForCC == false)
        //        ReceiptCashOfficeDefinition.SetNextReceiptNumber(receiptCashOfficeDefinition);
        //    else
        //        receiptCashOfficeDefinition.CurrentCreditCardNumber = receiptCashOfficeDefinition.CurrentCreditCardNumber + 1;
        //}
        public static ReceiptCashOfficeDefinition AutoActiveDeActivateReceiptCashOfficeDef(ReceiptCashOfficeDefinition receiptCashOfficeDefinition)
        {
            ReceiptCashOfficeDefinition receiptCODef;
            if (receiptCashOfficeDefinition.CurrentReceiptNumber > receiptCashOfficeDefinition.ReceiptEndNumber)
            {
                //InfoBox.Alert("Yeni koçana geçilecek!", MessageIconEnum.WarningMessage);
                //receiptCODef = ReceiptCashOfficeDefinition.GetByCashOffice(receiptCashOfficeDefinition.ObjectContext, receiptCashOfficeDefinition.CashOffice.ObjectID.ToString()).OrderBy(x => x.OrderNo.Value).Where(x => x.IsActive == true).FirstOrDefault();
                //if (receiptCODef != null)
                //return receiptCODef;
                //else
                throw new TTUtils.TTException(TTUtils.CultureService.GetText("M26880", "Sıradaki vezne alındı numarası son numaradan büyüktür. Kontrol ediniz!"));
            }
            else if (receiptCashOfficeDefinition.CurrentReceiptNumber == receiptCashOfficeDefinition.ReceiptEndNumber)
            {
                //receiptCODef = ReceiptCashOfficeDefinition.GetByCashOffice(receiptCashOfficeDefinition.ObjectContext, receiptCashOfficeDefinition.CashOffice.ObjectID.ToString()).OrderBy(x => x.OrderNo.Value).Where(x => x.IsActive == true).FirstOrDefault();
                receiptCashOfficeDefinition.IsActive = false;
                return receiptCashOfficeDefinition;
            }
            else
                return receiptCashOfficeDefinition;
        }

        public static ReceiptCashOfficeDefinition GetActiveCashOfficeDefinition(TTObjectContext objContext, Guid cashOfficeGuid)
        {
            IList<ReceiptCashOfficeDefinition> receiptCashOfficeDefList = GetByCashOffice(objContext, cashOfficeGuid.ToString());

            if (receiptCashOfficeDefList.Where(x => x.IsActive == true).Count() == 0)
                throw new TTUtils.TTException(TTUtils.CultureService.GetText("M27195", "Vezne için aktif vezne alındı numarası bulunmamaktadır."));

            ReceiptCashOfficeDefinition receiptCODef = receiptCashOfficeDefList.OrderBy(x => x.OrderNo.Value).Where(x => x.IsActive == true).FirstOrDefault();

            if (ReceiptCashOfficeDefinition.SkipUnusedReceiptNoAndGetCurrentNo(receiptCODef) >  receiptCODef.ReceiptEndNumber)
                throw new TTException(TTUtils.CultureService.GetText("M26880", "Sıradaki vezne alındı numarası son numaradan büyüktür. Kontrol ediniz!"));

            return receiptCODef;
        }
        /*
        public string GetCurrentBankDeliveryNumber()
        {
            return BankDeliverySeriesNo + CurrentBankDeliveryNumber;
        }
        
        public void SetNextBankDeliveryNumber()
        {
            CurrentBankDeliveryNumber = CurrentBankDeliveryNumber + 1;
        }
         */

        #endregion Methods

    }
}