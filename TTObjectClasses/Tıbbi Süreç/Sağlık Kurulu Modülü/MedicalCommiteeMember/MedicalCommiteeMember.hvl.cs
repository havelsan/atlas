
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="MedicalCommiteeMember")] 

    public  partial class MedicalCommiteeMember : TTObject
    {
        public class MedicalCommiteeMemberList : TTObjectCollection<MedicalCommiteeMember> { }
                    
        public class ChildMedicalCommiteeMemberCollection : TTObject.TTChildObjectCollection<MedicalCommiteeMember>
        {
            public ChildMedicalCommiteeMemberCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildMedicalCommiteeMemberCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
    /// <summary>
    /// Kurul Yazıcısı
    /// </summary>
        public bool? CommitteeWriter
        {
            get { return (bool?)this["COMMITTEEWRITER"]; }
            set { this["COMMITTEEWRITER"] = value; }
        }

    /// <summary>
    /// Uzmanlık
    /// </summary>
        public SpecialityDefinition Speciality
        {
            get { return (SpecialityDefinition)((ITTObject)this).GetParent("SPECIALITY"); }
            set { this["SPECIALITY"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public MemberOfMedicalCommitteeDefinition MemberOfMedicalCommitteeDef
        {
            get { return (MemberOfMedicalCommitteeDefinition)((ITTObject)this).GetParent("MEMBEROFMEDICALCOMMITTEEDEF"); }
            set { this["MEMBEROFMEDICALCOMMITTEEDEF"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Doktor
    /// </summary>
        public ResUser Doctor
        {
            get { return (ResUser)((ITTObject)this).GetParent("DOCTOR"); }
            set { this["DOCTOR"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected MedicalCommiteeMember(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected MedicalCommiteeMember(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected MedicalCommiteeMember(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected MedicalCommiteeMember(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected MedicalCommiteeMember(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "MEDICALCOMMITEEMEMBER", dataRow) { }
        protected MedicalCommiteeMember(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "MEDICALCOMMITEEMEMBER", dataRow, isImported) { }
        protected MedicalCommiteeMember(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public MedicalCommiteeMember(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public MedicalCommiteeMember() : base() { }

    }
}