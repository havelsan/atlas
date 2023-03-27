
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="MBSTDutyExpense")] 

    /// <summary>
    /// Geçici Görev Yolluk
    /// </summary>
    public  partial class MBSTDutyExpense : MBSTravelExpense
    {
        public class MBSTDutyExpenseList : TTObjectCollection<MBSTDutyExpense> { }
                    
        public class ChildMBSTDutyExpenseCollection : TTObject.TTChildObjectCollection<MBSTDutyExpense>
        {
            public ChildMBSTDutyExpenseCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildMBSTDutyExpenseCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        public MBSPeriod Period
        {
            get { return (MBSPeriod)((ITTObject)this).GetParent("PERIOD"); }
            set { this["PERIOD"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected MBSTDutyExpense(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected MBSTDutyExpense(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected MBSTDutyExpense(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected MBSTDutyExpense(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected MBSTDutyExpense(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "MBSTDUTYEXPENSE", dataRow) { }
        protected MBSTDutyExpense(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "MBSTDUTYEXPENSE", dataRow, isImported) { }
        public MBSTDutyExpense(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public MBSTDutyExpense(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public MBSTDutyExpense() : base() { }

    }
}