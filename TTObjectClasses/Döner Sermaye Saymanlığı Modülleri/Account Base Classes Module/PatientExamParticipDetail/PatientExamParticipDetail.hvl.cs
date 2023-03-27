
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="PatientExamParticipDetail")] 

    /// <summary>
    /// Muayene Katkı Payından Muaf Olan Yakınlık Dereceleri
    /// </summary>
    public  partial class PatientExamParticipDetail : TerminologyManagerDef
    {
        public class PatientExamParticipDetailList : TTObjectCollection<PatientExamParticipDetail> { }
                    
        public class ChildPatientExamParticipDetailCollection : TTObject.TTChildObjectCollection<PatientExamParticipDetail>
        {
            public ChildPatientExamParticipDetailCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildPatientExamParticipDetailCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
    /// <summary>
    /// Hasta Yakınlık Dereceleri Tanım Ekranı ile ilişki
    /// </summary>
        public PatientExamParticipationDefinition PatientExamParticipationDef
        {
            get { return (PatientExamParticipationDefinition)((ITTObject)this).GetParent("PATIENTEXAMPARTICIPATIONDEF"); }
            set { this["PATIENTEXAMPARTICIPATIONDEF"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Muayene Katkı Payından Muaf olan Yakınlık Dereceleri ilişkisi
    /// </summary>
        public RelationshipDefinition Relationship
        {
            get { return (RelationshipDefinition)((ITTObject)this).GetParent("RELATIONSHIP"); }
            set { this["RELATIONSHIP"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected PatientExamParticipDetail(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected PatientExamParticipDetail(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected PatientExamParticipDetail(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected PatientExamParticipDetail(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected PatientExamParticipDetail(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "PATIENTEXAMPARTICIPDETAIL", dataRow) { }
        protected PatientExamParticipDetail(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "PATIENTEXAMPARTICIPDETAIL", dataRow, isImported) { }
        public PatientExamParticipDetail(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public PatientExamParticipDetail(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public PatientExamParticipDetail() : base() { }

    }
}