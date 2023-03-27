
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="MBSFeeding")] 

    /// <summary>
    /// İaşe
    /// </summary>
    public  partial class MBSFeeding : TTObject
    {
        public class MBSFeedingList : TTObjectCollection<MBSFeeding> { }
                    
        public class ChildMBSFeedingCollection : TTObject.TTChildObjectCollection<MBSFeeding>
        {
            public ChildMBSFeedingCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildMBSFeedingCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
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
    /// Gelir vergisi matrahı
    /// </summary>
        public double? IncomeTaxAssessment
        {
            get { return (double?)this["INCOMETAXASSESSMENT"]; }
            set { this["INCOMETAXASSESSMENT"] = value; }
        }

    /// <summary>
    /// İşletim
    /// </summary>
        public bool? Operation
        {
            get { return (bool?)this["OPERATION"]; }
            set { this["OPERATION"] = value; }
        }

    /// <summary>
    /// Gelir vergisi
    /// </summary>
        public double? IncomeTax
        {
            get { return (double?)this["INCOMETAX"]; }
            set { this["INCOMETAX"] = value; }
        }

    /// <summary>
    /// Kesinti toplamı
    /// </summary>
        public double? TotalReduction
        {
            get { return (double?)this["TOTALREDUCTION"]; }
            set { this["TOTALREDUCTION"] = value; }
        }

        protected MBSFeeding(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected MBSFeeding(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected MBSFeeding(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected MBSFeeding(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected MBSFeeding(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "MBSFEEDING", dataRow) { }
        protected MBSFeeding(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "MBSFEEDING", dataRow, isImported) { }
        public MBSFeeding(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public MBSFeeding(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public MBSFeeding() : base() { }

    }
}