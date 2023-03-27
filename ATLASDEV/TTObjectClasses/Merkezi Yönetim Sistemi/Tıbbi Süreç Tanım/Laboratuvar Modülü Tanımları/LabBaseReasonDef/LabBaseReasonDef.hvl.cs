
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="LabBaseReasonDef")] 

    public  partial class LabBaseReasonDef : TerminologyManagerDef
    {
        public class LabBaseReasonDefList : TTObjectCollection<LabBaseReasonDef> { }
                    
        public class ChildLabBaseReasonDefCollection : TTObject.TTChildObjectCollection<LabBaseReasonDef>
        {
            public ChildLabBaseReasonDefCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildLabBaseReasonDefCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
    /// <summary>
    /// Aktif
    /// </summary>
        public bool? Active
        {
            get { return (bool?)this["ACTIVE"]; }
            set { this["ACTIVE"] = value; }
        }

    /// <summary>
    /// Kodu
    /// </summary>
        public string Code
        {
            get { return (string)this["CODE"]; }
            set { this["CODE"] = value; }
        }

    /// <summary>
    /// Açıklama
    /// </summary>
        public string Description
        {
            get { return (string)this["DESCRIPTION"]; }
            set { this["DESCRIPTION"] = value; }
        }

    /// <summary>
    /// Sebep
    /// </summary>
        public string Reason
        {
            get { return (string)this["REASON"]; }
            set { this["REASON"] = value; }
        }

        protected LabBaseReasonDef(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected LabBaseReasonDef(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected LabBaseReasonDef(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected LabBaseReasonDef(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected LabBaseReasonDef(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "LABBASEREASONDEF", dataRow) { }
        protected LabBaseReasonDef(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "LABBASEREASONDEF", dataRow, isImported) { }
        public LabBaseReasonDef(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public LabBaseReasonDef(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public LabBaseReasonDef() : base() { }

    }
}