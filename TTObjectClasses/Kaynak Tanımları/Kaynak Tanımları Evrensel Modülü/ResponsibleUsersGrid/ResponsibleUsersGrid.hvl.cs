
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="ResponsibleUsersGrid")] 

    /// <summary>
    /// Kaynaktan Sorumlu Kullanıcılar
    /// </summary>
    public  partial class ResponsibleUsersGrid : TTObject
    {
        public class ResponsibleUsersGridList : TTObjectCollection<ResponsibleUsersGrid> { }
                    
        public class ChildResponsibleUsersGridCollection : TTObject.TTChildObjectCollection<ResponsibleUsersGrid>
        {
            public ChildResponsibleUsersGridCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildResponsibleUsersGridCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        public ResSection ResSection
        {
            get { return (ResSection)((ITTObject)this).GetParent("RESSECTION"); }
            set { this["RESSECTION"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public ResUser ResUser
        {
            get { return (ResUser)((ITTObject)this).GetParent("RESUSER"); }
            set { this["RESUSER"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected ResponsibleUsersGrid(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected ResponsibleUsersGrid(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected ResponsibleUsersGrid(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected ResponsibleUsersGrid(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected ResponsibleUsersGrid(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "RESPONSIBLEUSERSGRID", dataRow) { }
        protected ResponsibleUsersGrid(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "RESPONSIBLEUSERSGRID", dataRow, isImported) { }
        public ResponsibleUsersGrid(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public ResponsibleUsersGrid(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public ResponsibleUsersGrid() : base() { }

    }
}