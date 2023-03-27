
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="AccountPeriod")] 

    /// <summary>
    /// Hesap Dönem Tanımı
    /// </summary>
    public  partial class AccountPeriod : TTObject
    {
        public class AccountPeriodList : TTObjectCollection<AccountPeriod> { }
                    
        public class ChildAccountPeriodCollection : TTObject.TTChildObjectCollection<AccountPeriod>
        {
            public ChildAccountPeriodCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildAccountPeriodCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
    /// <summary>
    /// Yıl
    /// </summary>
        public int? Year
        {
            get { return (int?)this["YEAR"]; }
            set { this["YEAR"] = value; }
        }

    /// <summary>
    /// Ay
    /// </summary>
        public MonthsEnum? Month
        {
            get { return (MonthsEnum?)(int?)this["MONTH"]; }
            set { this["MONTH"] = value; }
        }

        protected AccountPeriod(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected AccountPeriod(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected AccountPeriod(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected AccountPeriod(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected AccountPeriod(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "ACCOUNTPERIOD", dataRow) { }
        protected AccountPeriod(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "ACCOUNTPERIOD", dataRow, isImported) { }
        public AccountPeriod(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public AccountPeriod(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public AccountPeriod() : base() { }

    }
}