
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="MBSCOBCash")] 

    public  partial class MBSCOBCash : TTObject
    {
        public class MBSCOBCashList : TTObjectCollection<MBSCOBCash> { }
                    
        public class ChildMBSCOBCashCollection : TTObject.TTChildObjectCollection<MBSCOBCash>
        {
            public ChildMBSCOBCashCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildMBSCOBCashCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
    /// <summary>
    /// Kesinti toplamı
    /// </summary>
        public double? TotalReduction
        {
            get { return (double?)this["TOTALREDUCTION"]; }
            set { this["TOTALREDUCTION"] = value; }
        }

    /// <summary>
    /// Damga vergisi
    /// </summary>
        public double? StampTax
        {
            get { return (double?)this["STAMPTAX"]; }
            set { this["STAMPTAX"] = value; }
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
    /// Net tutarı
    /// </summary>
        public double? NetIncome
        {
            get { return (double?)this["NETINCOME"]; }
            set { this["NETINCOME"] = value; }
        }

    /// <summary>
    /// Gelir vergisi
    /// </summary>
        public double? IncomeTax
        {
            get { return (double?)this["INCOMETAX"]; }
            set { this["INCOMETAX"] = value; }
        }

        public MBSPerson Person
        {
            get { return (MBSPerson)((ITTObject)this).GetParent("PERSON"); }
            set { this["PERSON"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public MBSPeriod Period
        {
            get { return (MBSPeriod)((ITTObject)this).GetParent("PERIOD"); }
            set { this["PERIOD"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected MBSCOBCash(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected MBSCOBCash(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected MBSCOBCash(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected MBSCOBCash(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected MBSCOBCash(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "MBSCOBCASH", dataRow) { }
        protected MBSCOBCash(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "MBSCOBCASH", dataRow, isImported) { }
        public MBSCOBCash(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public MBSCOBCash(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public MBSCOBCash() : base() { }

    }
}