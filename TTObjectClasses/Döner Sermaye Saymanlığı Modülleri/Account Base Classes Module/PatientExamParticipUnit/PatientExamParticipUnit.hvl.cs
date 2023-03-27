
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="PatientExamParticipUnit")] 

    /// <summary>
    /// Muayene Katılım Payından Muaf Olan Birimler
    /// </summary>
    public  partial class PatientExamParticipUnit : TTDefinitionSet
    {
        public class PatientExamParticipUnitList : TTObjectCollection<PatientExamParticipUnit> { }
                    
        public class ChildPatientExamParticipUnitCollection : TTObject.TTChildObjectCollection<PatientExamParticipUnit>
        {
            public ChildPatientExamParticipUnitCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildPatientExamParticipUnitCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
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
        public ResSection ResSection
        {
            get { return (ResSection)((ITTObject)this).GetParent("RESSECTION"); }
            set { this["RESSECTION"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected PatientExamParticipUnit(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected PatientExamParticipUnit(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected PatientExamParticipUnit(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected PatientExamParticipUnit(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected PatientExamParticipUnit(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "PATIENTEXAMPARTICIPUNIT", dataRow) { }
        protected PatientExamParticipUnit(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "PATIENTEXAMPARTICIPUNIT", dataRow, isImported) { }
        public PatientExamParticipUnit(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public PatientExamParticipUnit(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public PatientExamParticipUnit() : base() { }

    }
}