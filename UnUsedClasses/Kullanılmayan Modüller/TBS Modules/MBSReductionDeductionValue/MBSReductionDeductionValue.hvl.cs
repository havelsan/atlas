
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="MBSReductionDeductionValue")] 

    /// <summary>
    /// Kesinti / İstihkak Değerleri
    /// </summary>
    public  partial class MBSReductionDeductionValue : TTObject
    {
        public class MBSReductionDeductionValueList : TTObjectCollection<MBSReductionDeductionValue> { }
                    
        public class ChildMBSReductionDeductionValueCollection : TTObject.TTChildObjectCollection<MBSReductionDeductionValue>
        {
            public ChildMBSReductionDeductionValueCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildMBSReductionDeductionValueCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
    /// <summary>
    /// Değer
    /// </summary>
        public string Value
        {
            get { return (string)this["VALUE"]; }
            set { this["VALUE"] = value; }
        }

        public MBSPeriod Period
        {
            get { return (MBSPeriod)((ITTObject)this).GetParent("PERIOD"); }
            set { this["PERIOD"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public MBSPersonnel Personnel
        {
            get { return (MBSPersonnel)((ITTObject)this).GetParent("PERSONNEL"); }
            set { this["PERSONNEL"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public MBSReductionDeductionDefinition ReductionDeduction
        {
            get { return (MBSReductionDeductionDefinition)((ITTObject)this).GetParent("REDUCTIONDEDUCTION"); }
            set { this["REDUCTIONDEDUCTION"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected MBSReductionDeductionValue(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected MBSReductionDeductionValue(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected MBSReductionDeductionValue(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected MBSReductionDeductionValue(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected MBSReductionDeductionValue(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "MBSREDUCTIONDEDUCTIONVALUE", dataRow) { }
        protected MBSReductionDeductionValue(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "MBSREDUCTIONDEDUCTIONVALUE", dataRow, isImported) { }
        public MBSReductionDeductionValue(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public MBSReductionDeductionValue(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public MBSReductionDeductionValue() : base() { }

    }
}