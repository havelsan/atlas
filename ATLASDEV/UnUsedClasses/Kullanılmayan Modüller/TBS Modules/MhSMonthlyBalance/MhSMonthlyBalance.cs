
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
    /// Aylık Durum
    /// </summary>
    public  partial class MhSMonthlyBalance : TTDefinitionSet
    {
#region Methods
        public void AddDebit(double amount){
            Debit += amount;
            Balance = Math.Abs((double)Debit - (double)Credit);
        }
        public void AddCredit(double amount){
            Credit += amount;
            Balance = Math.Abs((double)Debit - (double)Credit);
        }
        
#endregion Methods

    }
}