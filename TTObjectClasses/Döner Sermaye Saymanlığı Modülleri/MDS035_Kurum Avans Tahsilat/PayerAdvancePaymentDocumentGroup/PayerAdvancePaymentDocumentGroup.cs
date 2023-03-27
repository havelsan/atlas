﻿
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
    /// Kurum Avans Tahsilat Döküman Grubu
    /// </summary>
    public  partial class PayerAdvancePaymentDocumentGroup : AccountDocumentGroup
    {
#region Methods
        public void AddDocumentDetail(string pDesc, int pAmount, double pUnitPrice)
        {
            PayerAdvancePaymentDocumentDetail paymentDet = new PayerAdvancePaymentDocumentDetail(ObjectContext);

            paymentDet.Description = pDesc;
            paymentDet.Amount = pAmount;
            paymentDet.UnitPrice = pUnitPrice;
            paymentDet.AccountDocumentGroup = this;
            PayerAdvancePaymentDocumentDetails.Add(paymentDet);
        }
        
#endregion Methods

    }
}