
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="HealthCommittee_ReturnDescriptionsGrid")] 

    public  partial class HealthCommittee_ReturnDescriptionsGrid : ReturnDescriptionsGrid
    {
        public class HealthCommittee_ReturnDescriptionsGridList : TTObjectCollection<HealthCommittee_ReturnDescriptionsGrid> { }
                    
        public class ChildHealthCommittee_ReturnDescriptionsGridCollection : TTObject.TTChildObjectCollection<HealthCommittee_ReturnDescriptionsGrid>
        {
            public ChildHealthCommittee_ReturnDescriptionsGridCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildHealthCommittee_ReturnDescriptionsGridCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
    /// <summary>
    /// İlgili state
    /// </summary>
        public string RelatedStateID
        {
            get { return (string)this["RELATEDSTATEID"]; }
            set { this["RELATEDSTATEID"] = value; }
        }

        public HealthCommitteeWithThreeSpecialist HCommitteeWithThreeSpecialist
        {
            get { return (HealthCommitteeWithThreeSpecialist)((ITTObject)this).GetParent("HCOMMITTEEWITHTHREESPECIALIST"); }
            set { this["HCOMMITTEEWITHTHREESPECIALIST"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public HealthCommittee HealthCommittee
        {
            get { return (HealthCommittee)((ITTObject)this).GetParent("HEALTHCOMMITTEE"); }
            set { this["HEALTHCOMMITTEE"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public HealthCommitteeOfProfessors HealthCommitteeOfProfessors
        {
            get { return (HealthCommitteeOfProfessors)((ITTObject)this).GetParent("HEALTHCOMMITTEEOFPROFESSORS"); }
            set { this["HEALTHCOMMITTEEOFPROFESSORS"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public HealthCommitteeOfProfessorsApproval HCOfProfessorsApproval
        {
            get { return (HealthCommitteeOfProfessorsApproval)((ITTObject)this).GetParent("HCOFPROFESSORSAPPROVAL"); }
            set { this["HCOFPROFESSORSAPPROVAL"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected HealthCommittee_ReturnDescriptionsGrid(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected HealthCommittee_ReturnDescriptionsGrid(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected HealthCommittee_ReturnDescriptionsGrid(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected HealthCommittee_ReturnDescriptionsGrid(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected HealthCommittee_ReturnDescriptionsGrid(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "HEALTHCOMMITTEE_RETURNDESCRIPTIONSGRID", dataRow) { }
        protected HealthCommittee_ReturnDescriptionsGrid(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "HEALTHCOMMITTEE_RETURNDESCRIPTIONSGRID", dataRow, isImported) { }
        public HealthCommittee_ReturnDescriptionsGrid(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public HealthCommittee_ReturnDescriptionsGrid(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public HealthCommittee_ReturnDescriptionsGrid() : base() { }

    }
}