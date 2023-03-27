
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
    /// Gelir Gider hesap kodu tanýmlama
    /// </summary>
    public  partial class AccountVoucherCodeDefinition : TerminologyManagerDef
    {
        public static AccountVoucherCodeDefinition GetByCode(TTObjectContext context, string code)
        {
            AccountVoucherCodeDefinition accountVoucherCodeDefinition = context.QueryObjects<AccountVoucherCodeDefinition>("ISDEPT = 0 AND CODE = '" + code + "'").FirstOrDefault();
            if (accountVoucherCodeDefinition == null)
                throw new TTException("Gelir Ýþlemi oluþturmak için uygun Gelir/Gider Tanýmý bulunamadý. (" + code + ")");

            return accountVoucherCodeDefinition;
        }
    }
}