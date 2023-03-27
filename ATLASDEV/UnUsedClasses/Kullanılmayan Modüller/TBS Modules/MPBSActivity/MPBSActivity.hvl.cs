
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="MPBSActivity")] 

    /// <summary>
    /// Faaliyet
    /// </summary>
    public  partial class MPBSActivity : TTObject
    {
        public class MPBSActivityList : TTObjectCollection<MPBSActivity> { }
                    
        public class ChildMPBSActivityCollection : TTObject.TTChildObjectCollection<MPBSActivity>
        {
            public ChildMPBSActivityCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildMPBSActivityCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
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
    /// Faaliyet Adı
    /// </summary>
        public string Name
        {
            get { return (string)this["NAME"]; }
            set { this["NAME"] = value; }
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
    /// Başlangıç Tarihi
    /// </summary>
        public DateTime? StartDate
        {
            get { return (DateTime?)this["STARTDATE"]; }
            set { this["STARTDATE"] = value; }
        }

        protected MPBSActivity(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected MPBSActivity(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected MPBSActivity(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected MPBSActivity(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected MPBSActivity(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "MPBSACTIVITY", dataRow) { }
        protected MPBSActivity(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "MPBSACTIVITY", dataRow, isImported) { }
        public MPBSActivity(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public MPBSActivity(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public MPBSActivity() : base() { }

    }
}