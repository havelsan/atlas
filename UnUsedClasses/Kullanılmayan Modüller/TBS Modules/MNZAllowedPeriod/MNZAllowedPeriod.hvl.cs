
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="MNZAllowedPeriod")] 

    /// <summary>
    /// Firma İzin Tarihleri
    /// </summary>
    public  partial class MNZAllowedPeriod : TTObject
    {
        public class MNZAllowedPeriodList : TTObjectCollection<MNZAllowedPeriod> { }
                    
        public class ChildMNZAllowedPeriodCollection : TTObject.TTChildObjectCollection<MNZAllowedPeriod>
        {
            public ChildMNZAllowedPeriodCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildMNZAllowedPeriodCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
    /// <summary>
    /// Başlangıç Saati
    /// </summary>
        public DateTime? StartTime
        {
            get { return (DateTime?)this["STARTTIME"]; }
            set { this["STARTTIME"] = value; }
        }

    /// <summary>
    /// İzin Sebebi
    /// </summary>
        public string PermissiontReason
        {
            get { return (string)this["PERMISSIONTREASON"]; }
            set { this["PERMISSIONTREASON"] = value; }
        }

    /// <summary>
    /// İzin Günü
    /// </summary>
        public DateTime? AllowDate
        {
            get { return (DateTime?)this["ALLOWDATE"]; }
            set { this["ALLOWDATE"] = value; }
        }

    /// <summary>
    /// BitişSaati
    /// </summary>
        public DateTime? EndTime
        {
            get { return (DateTime?)this["ENDTIME"]; }
            set { this["ENDTIME"] = value; }
        }

    /// <summary>
    /// Fimanın İzin Günleri
    /// </summary>
        public MNZFirm Firm
        {
            get { return (MNZFirm)((ITTObject)this).GetParent("FIRM"); }
            set { this["FIRM"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected MNZAllowedPeriod(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected MNZAllowedPeriod(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected MNZAllowedPeriod(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected MNZAllowedPeriod(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected MNZAllowedPeriod(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "MNZALLOWEDPERIOD", dataRow) { }
        protected MNZAllowedPeriod(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "MNZALLOWEDPERIOD", dataRow, isImported) { }
        public MNZAllowedPeriod(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public MNZAllowedPeriod(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public MNZAllowedPeriod() : base() { }

    }
}