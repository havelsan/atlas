
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
    /// Banka Hesap Listesi
    /// </summary>
    public partial class TTList_BankAccountListDefinition : TTList
    {
        public TTList_BankAccountListDefinition(TTListDef listDef, string listFilterExpression) : base(listDef, listFilterExpression)
        {
        }

        public TTList_BankAccountListDefinition(TTObjectContext objectContext, TTListDef listDef, string listFilterExpression) : base(objectContext, listDef, listFilterExpression)
        {
        }

        override public string GetDisplayText(TTObject ttObj)
        {
            BankAccountDefinition o = ttObj as BankAccountDefinition;
            if (o == null)
                throw new TTException("Invalid object type.");
            return o.BankBranch.Bank.Name + " " + o.BankBranch.Code + " " + o.BankBranch.Name + " " + o.AccountNo;
        }
    }
}