
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
    /// Parçalı ödeme detayı
    /// </summary>
    public partial class PatientPaymentDetail : TTObject
    {
        public void CreatePPDetail(AccountTransaction accTrx, AccountDocument accDoc, Currency paidPrice, PaymentTypeEnum paymentType, bool? isParticipationShare = null)
        {
            AccountTransaction = accTrx;
            AccountDocument = accDoc;
            IsBack = false;
            IsCancel = false;
            PaymentType = paymentType;
            Date = Common.RecTime();
            PaymentPrice = paidPrice;
            IsParticipationShare = isParticipationShare;
        }
    }
}