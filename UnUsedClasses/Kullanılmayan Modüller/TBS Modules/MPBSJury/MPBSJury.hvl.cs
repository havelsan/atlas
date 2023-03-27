
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="MPBSJury")] 

    /// <summary>
    /// Jüri
    /// </summary>
    public  partial class MPBSJury : MPBSPerson
    {
        public class MPBSJuryList : TTObjectCollection<MPBSJury> { }
                    
        public class ChildMPBSJuryCollection : TTObject.TTChildObjectCollection<MPBSJury>
        {
            public ChildMPBSJuryCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildMPBSJuryCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
    /// <summary>
    /// Jürilik Bitiş Tarihi
    /// </summary>
        public DateTime? EndDate
        {
            get { return (DateTime?)this["ENDDATE"]; }
            set { this["ENDDATE"] = value; }
        }

    /// <summary>
    /// Jürilik Başlangıç Tarihi
    /// </summary>
        public DateTime? StartDate
        {
            get { return (DateTime?)this["STARTDATE"]; }
            set { this["STARTDATE"] = value; }
        }

        protected MPBSJury(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected MPBSJury(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected MPBSJury(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected MPBSJury(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected MPBSJury(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "MPBSJURY", dataRow) { }
        protected MPBSJury(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "MPBSJURY", dataRow, isImported) { }
        public MPBSJury(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public MPBSJury(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public MPBSJury() : base() { }

    }
}