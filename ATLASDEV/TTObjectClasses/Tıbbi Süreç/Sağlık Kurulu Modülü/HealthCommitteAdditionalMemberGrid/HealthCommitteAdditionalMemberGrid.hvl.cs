
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="HealthCommitteAdditionalMemberGrid")] 

    /// <summary>
    /// İlave İmzacı Üyeler
    /// </summary>
    public  partial class HealthCommitteAdditionalMemberGrid : TTObject
    {
        public class HealthCommitteAdditionalMemberGridList : TTObjectCollection<HealthCommitteAdditionalMemberGrid> { }
                    
        public class ChildHealthCommitteAdditionalMemberGridCollection : TTObject.TTChildObjectCollection<HealthCommitteAdditionalMemberGrid>
        {
            public ChildHealthCommitteAdditionalMemberGridCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildHealthCommitteAdditionalMemberGridCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
    /// <summary>
    /// Görevi
    /// </summary>
        public string Work
        {
            get { return (string)this["WORK"]; }
            set { this["WORK"] = value; }
        }

    /// <summary>
    /// Doktor
    /// </summary>
        public ResUser Doctor
        {
            get { return (ResUser)((ITTObject)this).GetParent("DOCTOR"); }
            set { this["DOCTOR"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Bölümü
    /// </summary>
        public ResSection Unit
        {
            get { return (ResSection)((ITTObject)this).GetParent("UNIT"); }
            set { this["UNIT"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected HealthCommitteAdditionalMemberGrid(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected HealthCommitteAdditionalMemberGrid(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected HealthCommitteAdditionalMemberGrid(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected HealthCommitteAdditionalMemberGrid(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected HealthCommitteAdditionalMemberGrid(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "HEALTHCOMMITTEADDITIONALMEMBERGRID", dataRow) { }
        protected HealthCommitteAdditionalMemberGrid(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "HEALTHCOMMITTEADDITIONALMEMBERGRID", dataRow, isImported) { }
        public HealthCommitteAdditionalMemberGrid(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public HealthCommitteAdditionalMemberGrid(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public HealthCommitteAdditionalMemberGrid() : base() { }

    }
}