
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
    public partial class AccountPeriodDefinition : TerminologyManagerDef
    {
        public partial class AccountPeriodDefinitionNQL_Class : TTReportNqlObject
        {
            public AccountPeriodDefinitionNQL_Class(string injectionNql)
            {

            }
        }

        public static AccountPeriodDefinition GetByDate(TTObjectContext context, DateTime date)
        {
            AccountPeriodDefinition accountPeriodDefinition = context.QueryObjects<AccountPeriodDefinition>("YEAR = " + date.Year + " AND MONTH = " + date.Month).FirstOrDefault();
            if (accountPeriodDefinition == null)
                throw new TTException("Gelir Ýþlemi oluþturmak için uygun Dönem Tanýmý bulunamadý. (" + date.Year + "/" + date.Month + ")");

            return accountPeriodDefinition;
        }
    }
}