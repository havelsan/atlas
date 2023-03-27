
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="MPBSGuestMilitaryPersonnel")] 

    /// <summary>
    /// Misafir XXXXXX Personel
    /// </summary>
    public  partial class MPBSGuestMilitaryPersonnel : MPBSForeignPersonnel
    {
        public class MPBSGuestMilitaryPersonnelList : TTObjectCollection<MPBSGuestMilitaryPersonnel> { }
                    
        public class ChildMPBSGuestMilitaryPersonnelCollection : TTObject.TTChildObjectCollection<MPBSGuestMilitaryPersonnel>
        {
            public ChildMPBSGuestMilitaryPersonnelCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildMPBSGuestMilitaryPersonnelCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        protected MPBSGuestMilitaryPersonnel(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected MPBSGuestMilitaryPersonnel(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected MPBSGuestMilitaryPersonnel(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected MPBSGuestMilitaryPersonnel(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected MPBSGuestMilitaryPersonnel(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "MPBSGUESTMILITARYPERSONNEL", dataRow) { }
        protected MPBSGuestMilitaryPersonnel(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "MPBSGUESTMILITARYPERSONNEL", dataRow, isImported) { }
        public MPBSGuestMilitaryPersonnel(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public MPBSGuestMilitaryPersonnel(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public MPBSGuestMilitaryPersonnel() : base() { }

    }
}