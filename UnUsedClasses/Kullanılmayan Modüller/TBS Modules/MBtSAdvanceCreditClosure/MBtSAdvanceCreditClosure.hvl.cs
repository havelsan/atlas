
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="MBtSAdvanceCreditClosure")] 

    public  partial class MBtSAdvanceCreditClosure : TTObject
    {
        public class MBtSAdvanceCreditClosureList : TTObjectCollection<MBtSAdvanceCreditClosure> { }
                    
        public class ChildMBtSAdvanceCreditClosureCollection : TTObject.TTChildObjectCollection<MBtSAdvanceCreditClosure>
        {
            public ChildMBtSAdvanceCreditClosureCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildMBtSAdvanceCreditClosureCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
    /// <summary>
    /// Açıklama
    /// </summary>
        public string Comment
        {
            get { return (string)this["COMMENT"]; }
            set { this["COMMENT"] = value; }
        }

    /// <summary>
    /// Tarih
    /// </summary>
        public DateTime? Date
        {
            get { return (DateTime?)this["DATE"]; }
            set { this["DATE"] = value; }
        }

    /// <summary>
    /// Toplam Tutar
    /// </summary>
        public double? Total
        {
            get { return (double?)this["TOTAL"]; }
            set { this["TOTAL"] = value; }
        }

    /// <summary>
    /// Tür
    /// </summary>
        public DateTime? Type
        {
            get { return (DateTime?)this["TYPE"]; }
            set { this["TYPE"] = value; }
        }

        public MBtSAdvanceCredit AdvanceCredit
        {
            get { return (MBtSAdvanceCredit)((ITTObject)this).GetParent("ADVANCECREDIT"); }
            set { this["ADVANCECREDIT"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected MBtSAdvanceCreditClosure(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected MBtSAdvanceCreditClosure(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected MBtSAdvanceCreditClosure(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected MBtSAdvanceCreditClosure(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected MBtSAdvanceCreditClosure(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "MBTSADVANCECREDITCLOSURE", dataRow) { }
        protected MBtSAdvanceCreditClosure(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "MBTSADVANCECREDITCLOSURE", dataRow, isImported) { }
        public MBtSAdvanceCreditClosure(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public MBtSAdvanceCreditClosure(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public MBtSAdvanceCreditClosure() : base() { }

    }
}