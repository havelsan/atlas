
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="MPBSForeignPersonnel")] 

    public  partial class MPBSForeignPersonnel : MPBSPersonnel
    {
        public class MPBSForeignPersonnelList : TTObjectCollection<MPBSForeignPersonnel> { }
                    
        public class ChildMPBSForeignPersonnelCollection : TTObject.TTChildObjectCollection<MPBSForeignPersonnel>
        {
            public ChildMPBSForeignPersonnelCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildMPBSForeignPersonnelCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
    /// <summary>
    /// Geliş Tarihi
    /// </summary>
        public DateTime? ComeInDate
        {
            get { return (DateTime?)this["COMEINDATE"]; }
            set { this["COMEINDATE"] = value; }
        }

    /// <summary>
    /// Pasaport No
    /// </summary>
        public string PassportNo
        {
            get { return (string)this["PASSPORTNO"]; }
            set { this["PASSPORTNO"] = value; }
        }

    /// <summary>
    /// Gidiş Tarihi
    /// </summary>
        public DateTime? GoOutDate
        {
            get { return (DateTime?)this["GOOUTDATE"]; }
            set { this["GOOUTDATE"] = value; }
        }

        protected MPBSForeignPersonnel(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected MPBSForeignPersonnel(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected MPBSForeignPersonnel(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected MPBSForeignPersonnel(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected MPBSForeignPersonnel(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "MPBSFOREIGNPERSONNEL", dataRow) { }
        protected MPBSForeignPersonnel(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "MPBSFOREIGNPERSONNEL", dataRow, isImported) { }
        public MPBSForeignPersonnel(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public MPBSForeignPersonnel(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public MPBSForeignPersonnel() : base() { }

    }
}