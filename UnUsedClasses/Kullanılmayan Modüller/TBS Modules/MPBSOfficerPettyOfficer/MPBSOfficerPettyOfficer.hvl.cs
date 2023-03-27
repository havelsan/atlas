
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="MPBSOfficerPettyOfficer")] 

    /// <summary>
    /// Subay Astsubay
    /// </summary>
    public  partial class MPBSOfficerPettyOfficer : MPBSPermanentTurkishMilitaryPersonnel
    {
        public class MPBSOfficerPettyOfficerList : TTObjectCollection<MPBSOfficerPettyOfficer> { }
                    
        public class ChildMPBSOfficerPettyOfficerCollection : TTObject.TTChildObjectCollection<MPBSOfficerPettyOfficer>
        {
            public ChildMPBSOfficerPettyOfficerCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildMPBSOfficerPettyOfficerCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
    /// <summary>
    /// Tabanca No
    /// </summary>
        public string RevolverNo
        {
            get { return (string)this["REVOLVERNO"]; }
            set { this["REVOLVERNO"] = value; }
        }

    /// <summary>
    /// XXXXXXlik Kimlik No
    /// </summary>
        public string MilitaryIdentityNo
        {
            get { return (string)this["MILITARYIDENTITYNO"]; }
            set { this["MILITARYIDENTITYNO"] = value; }
        }

    /// <summary>
    /// Kurmay mı
    /// </summary>
        public YesNoEnum? IsGeneral
        {
            get { return (YesNoEnum?)(int?)this["ISGENERAL"]; }
            set { this["ISGENERAL"] = value; }
        }

        protected MPBSOfficerPettyOfficer(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected MPBSOfficerPettyOfficer(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected MPBSOfficerPettyOfficer(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected MPBSOfficerPettyOfficer(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected MPBSOfficerPettyOfficer(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "MPBSOFFICERPETTYOFFICER", dataRow) { }
        protected MPBSOfficerPettyOfficer(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "MPBSOFFICERPETTYOFFICER", dataRow, isImported) { }
        public MPBSOfficerPettyOfficer(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public MPBSOfficerPettyOfficer(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public MPBSOfficerPettyOfficer() : base() { }

    }
}