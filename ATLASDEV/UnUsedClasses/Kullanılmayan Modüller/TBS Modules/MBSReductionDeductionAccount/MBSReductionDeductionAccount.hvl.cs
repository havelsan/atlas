
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="MBSReductionDeductionAccount")] 

    /// <summary>
    /// Kesinti / İstihkak Hesapları
    /// </summary>
    public  partial class MBSReductionDeductionAccount : TTObject
    {
        public class MBSReductionDeductionAccountList : TTObjectCollection<MBSReductionDeductionAccount> { }
                    
        public class ChildMBSReductionDeductionAccountCollection : TTObject.TTChildObjectCollection<MBSReductionDeductionAccount>
        {
            public ChildMBSReductionDeductionAccountCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildMBSReductionDeductionAccountCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
    /// <summary>
    /// Tutar
    /// </summary>
        public double? Total
        {
            get { return (double?)this["TOTAL"]; }
            set { this["TOTAL"] = value; }
        }

        public MBSReductionDeductionDefinition ReductionDeduction
        {
            get { return (MBSReductionDeductionDefinition)((ITTObject)this).GetParent("REDUCTIONDEDUCTION"); }
            set { this["REDUCTIONDEDUCTION"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public MBSPayroll Payroll
        {
            get { return (MBSPayroll)((ITTObject)this).GetParent("PAYROLL"); }
            set { this["PAYROLL"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected MBSReductionDeductionAccount(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected MBSReductionDeductionAccount(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected MBSReductionDeductionAccount(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected MBSReductionDeductionAccount(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected MBSReductionDeductionAccount(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "MBSREDUCTIONDEDUCTIONACCOUNT", dataRow) { }
        protected MBSReductionDeductionAccount(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "MBSREDUCTIONDEDUCTIONACCOUNT", dataRow, isImported) { }
        public MBSReductionDeductionAccount(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public MBSReductionDeductionAccount(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public MBSReductionDeductionAccount() : base() { }

    }
}