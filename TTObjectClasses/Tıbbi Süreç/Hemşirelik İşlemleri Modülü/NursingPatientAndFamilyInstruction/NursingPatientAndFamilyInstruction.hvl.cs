
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="NursingPatientAndFamilyInstruction")] 

    public  partial class NursingPatientAndFamilyInstruction : TTObject
    {
        public class NursingPatientAndFamilyInstructionList : TTObjectCollection<NursingPatientAndFamilyInstruction> { }
                    
        public class ChildNursingPatientAndFamilyInstructionCollection : TTObject.TTChildObjectCollection<NursingPatientAndFamilyInstruction>
        {
            public ChildNursingPatientAndFamilyInstructionCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildNursingPatientAndFamilyInstructionCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
    /// <summary>
    /// Not
    /// </summary>
        public string Note
        {
            get { return (string)this["NOTE"]; }
            set { this["NOTE"] = value; }
        }

    /// <summary>
    /// Tarih
    /// </summary>
        public DateTime? ActionDate
        {
            get { return (DateTime?)this["ACTIONDATE"]; }
            set { this["ACTIONDATE"] = value; }
        }

    /// <summary>
    /// Eğitimi Hasta Aldı
    /// </summary>
        public bool? PatientGetInstruction
        {
            get { return (bool?)this["PATIENTGETINSTRUCTION"]; }
            set { this["PATIENTGETINSTRUCTION"] = value; }
        }

    /// <summary>
    /// Hasta Yakını
    /// </summary>
        public bool? CompanionGetInstruction
        {
            get { return (bool?)this["COMPANIONGETINSTRUCTION"]; }
            set { this["COMPANIONGETINSTRUCTION"] = value; }
        }

    /// <summary>
    /// Hasta ve Aile Eğitimi
    /// </summary>
        public PatientAndFamilyInstructionDefinition PatientAndFamilyInstruction
        {
            get { return (PatientAndFamilyInstructionDefinition)((ITTObject)this).GetParent("PATIENTANDFAMILYINSTRUCTION"); }
            set { this["PATIENTANDFAMILYINSTRUCTION"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public ResUser Instructor
        {
            get { return (ResUser)((ITTObject)this).GetParent("INSTRUCTOR"); }
            set { this["INSTRUCTOR"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public BaseNursingPatientAndFamilyInstruction BasePatAndFamInstruction
        {
            get { return (BaseNursingPatientAndFamilyInstruction)((ITTObject)this).GetParent("BASEPATANDFAMINSTRUCTION"); }
            set { this["BASEPATANDFAMINSTRUCTION"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected NursingPatientAndFamilyInstruction(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected NursingPatientAndFamilyInstruction(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected NursingPatientAndFamilyInstruction(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected NursingPatientAndFamilyInstruction(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected NursingPatientAndFamilyInstruction(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "NURSINGPATIENTANDFAMILYINSTRUCTION", dataRow) { }
        protected NursingPatientAndFamilyInstruction(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "NURSINGPATIENTANDFAMILYINSTRUCTION", dataRow, isImported) { }
        public NursingPatientAndFamilyInstruction(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public NursingPatientAndFamilyInstruction(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public NursingPatientAndFamilyInstruction() : base() { }

    }
}