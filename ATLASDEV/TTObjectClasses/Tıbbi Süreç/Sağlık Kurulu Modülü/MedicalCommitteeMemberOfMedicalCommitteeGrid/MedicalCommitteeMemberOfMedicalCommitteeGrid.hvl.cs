
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="MedicalCommitteeMemberOfMedicalCommitteeGrid")] 

    /// <summary>
    /// Kurul Üyeleri
    /// </summary>
    public  partial class MedicalCommitteeMemberOfMedicalCommitteeGrid : TTObject
    {
        public class MedicalCommitteeMemberOfMedicalCommitteeGridList : TTObjectCollection<MedicalCommitteeMemberOfMedicalCommitteeGrid> { }
                    
        public class ChildMedicalCommitteeMemberOfMedicalCommitteeGridCollection : TTObject.TTChildObjectCollection<MedicalCommitteeMemberOfMedicalCommitteeGrid>
        {
            public ChildMedicalCommitteeMemberOfMedicalCommitteeGridCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildMedicalCommitteeMemberOfMedicalCommitteeGridCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
    /// <summary>
    /// Uzmanlık Dalı
    /// </summary>
        public string ExpertiseBranch
        {
            get { return (string)this["EXPERTISEBRANCH"]; }
            set { this["EXPERTISEBRANCH"] = value; }
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
    /// Katılmıyor
    /// </summary>
        public bool? NotAttend
        {
            get { return (bool?)this["NOTATTEND"]; }
            set { this["NOTATTEND"] = value; }
        }

    /// <summary>
    /// Uzmanlık Dalı
    /// </summary>
        public SpecialityDefinition Speciality
        {
            get { return (SpecialityDefinition)((ITTObject)this).GetParent("SPECIALITY"); }
            set { this["SPECIALITY"] = (value==null ? null : (Guid?)value.ObjectID); }
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
    /// Kurul Üyeleri
    /// </summary>
        public MedicalCommittee MedicalCommittee
        {
            get { return (MedicalCommittee)((ITTObject)this).GetParent("MEDICALCOMMITTEE"); }
            set { this["MEDICALCOMMITTEE"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected MedicalCommitteeMemberOfMedicalCommitteeGrid(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected MedicalCommitteeMemberOfMedicalCommitteeGrid(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected MedicalCommitteeMemberOfMedicalCommitteeGrid(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected MedicalCommitteeMemberOfMedicalCommitteeGrid(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected MedicalCommitteeMemberOfMedicalCommitteeGrid(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "MEDICALCOMMITTEEMEMBEROFMEDICALCOMMITTEEGRID", dataRow) { }
        protected MedicalCommitteeMemberOfMedicalCommitteeGrid(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "MEDICALCOMMITTEEMEMBEROFMEDICALCOMMITTEEGRID", dataRow, isImported) { }
        public MedicalCommitteeMemberOfMedicalCommitteeGrid(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public MedicalCommitteeMemberOfMedicalCommitteeGrid(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public MedicalCommitteeMemberOfMedicalCommitteeGrid() : base() { }

    }
}