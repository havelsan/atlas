
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="MPBSLeaveBase")] 

    public  partial class MPBSLeaveBase : TTObject
    {
        public class MPBSLeaveBaseList : TTObjectCollection<MPBSLeaveBase> { }
                    
        public class ChildMPBSLeaveBaseCollection : TTObject.TTChildObjectCollection<MPBSLeaveBase>
        {
            public ChildMPBSLeaveBaseCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildMPBSLeaveBaseCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
    /// <summary>
    /// Başlangıç Tarihi
    /// </summary>
        public DateTime? StartDate
        {
            get { return (DateTime?)this["STARTDATE"]; }
            set { this["STARTDATE"] = value; }
        }

    /// <summary>
    /// Bitiş Tarihi
    /// </summary>
        public DateTime? EndDate
        {
            get { return (DateTime?)this["ENDDATE"]; }
            set { this["ENDDATE"] = value; }
        }

    /// <summary>
    /// Süre
    /// </summary>
        public int? Duration
        {
            get { return (int?)this["DURATION"]; }
            set { this["DURATION"] = value; }
        }

    /// <summary>
    /// Personel
    /// </summary>
        public MPBSPersonnel Personnel
        {
            get { return (MPBSPersonnel)((ITTObject)this).GetParent("PERSONNEL"); }
            set { this["PERSONNEL"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected MPBSLeaveBase(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected MPBSLeaveBase(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected MPBSLeaveBase(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected MPBSLeaveBase(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected MPBSLeaveBase(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "MPBSLEAVEBASE", dataRow) { }
        protected MPBSLeaveBase(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "MPBSLEAVEBASE", dataRow, isImported) { }
        public MPBSLeaveBase(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public MPBSLeaveBase(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public MPBSLeaveBase() : base() { }

    }
}