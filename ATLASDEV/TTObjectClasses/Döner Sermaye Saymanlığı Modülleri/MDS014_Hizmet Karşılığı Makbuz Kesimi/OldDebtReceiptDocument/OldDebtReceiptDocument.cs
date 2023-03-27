
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
    public  partial class OldDebtReceiptDocument : AccountDocument
    {
        public void CreateAccountVoucher()
        {
            if (SystemParameter.GetParameterValue("CREATEACCOUNTVOUCHERFORCASHOFFICE", "TRUE") == "TRUE")
            {
                const string code = "600.01.99"; // Eski Borç Tahsilatı için muhasebe kodu

                AccountPeriodDefinition accountPeriodDefinition = AccountPeriodDefinition.GetByDate(ObjectContext, DocumentDate.Value);
                AccountVoucherCodeDefinition accountVoucherCodeDefinition = AccountVoucherCodeDefinition.GetByCode(ObjectContext, code);
                AccountVoucher accountVoucher = AccountVoucher.GetOrCreateForCashOffice(ObjectContext, accountPeriodDefinition, accountVoucherCodeDefinition);
                accountVoucher.AddDetail(TotalPrice, this);
            }
        }
    }
}