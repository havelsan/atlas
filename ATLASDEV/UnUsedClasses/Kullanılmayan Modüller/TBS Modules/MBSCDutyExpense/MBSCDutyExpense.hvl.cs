
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="MBSCDutyExpense")] 

    /// <summary>
    /// Sürekli Görev Yolluk
    /// </summary>
    public  partial class MBSCDutyExpense : MBSTravelExpense
    {
        public class MBSCDutyExpenseList : TTObjectCollection<MBSCDutyExpense> { }
                    
        public class ChildMBSCDutyExpenseCollection : TTObject.TTChildObjectCollection<MBSCDutyExpense>
        {
            public ChildMBSCDutyExpenseCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildMBSCDutyExpenseCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
    /// <summary>
    /// Yurtiçi mi?
    /// </summary>
        public bool? isDomestic
        {
            get { return (bool?)this["ISDOMESTIC"]; }
            set { this["ISDOMESTIC"] = value; }
        }

    /// <summary>
    /// Sabit Unsur
    /// </summary>
        public double? FixPrice
        {
            get { return (double?)this["FIXPRICE"]; }
            set { this["FIXPRICE"] = value; }
        }

    /// <summary>
    /// Çıkış Tarihi
    /// </summary>
        public DateTime? SeperationDate
        {
            get { return (DateTime?)this["SEPERATIONDATE"]; }
            set { this["SEPERATIONDATE"] = value; }
        }

        public MBSPersonnelBase Personnel
        {
            get { return (MBSPersonnelBase)((ITTObject)this).GetParent("PERSONNEL"); }
            set { this["PERSONNEL"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected MBSCDutyExpense(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected MBSCDutyExpense(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected MBSCDutyExpense(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected MBSCDutyExpense(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected MBSCDutyExpense(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "MBSCDUTYEXPENSE", dataRow) { }
        protected MBSCDutyExpense(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "MBSCDUTYEXPENSE", dataRow, isImported) { }
        public MBSCDutyExpense(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public MBSCDutyExpense(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public MBSCDutyExpense() : base() { }

    }
}