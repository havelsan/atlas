
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="BaseNursingPatientAndFamilyInstruction")] 

    /// <summary>
    /// Hasta Eğitim Formu
    /// </summary>
    public  partial class BaseNursingPatientAndFamilyInstruction : BaseNursingDataEntry
    {
        public class BaseNursingPatientAndFamilyInstructionList : TTObjectCollection<BaseNursingPatientAndFamilyInstruction> { }
                    
        public class ChildBaseNursingPatientAndFamilyInstructionCollection : TTObject.TTChildObjectCollection<BaseNursingPatientAndFamilyInstruction>
        {
            public ChildBaseNursingPatientAndFamilyInstructionCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildBaseNursingPatientAndFamilyInstructionCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        new public static class States
        {
            public static Guid Yeni { get { return new Guid("2f6b2d75-fb0e-43c9-a964-af59bb71f8b9"); } }
    /// <summary>
    /// Yanlış veriyi silmek için
    /// </summary>
            public static Guid Cancelled { get { return new Guid("c9a1ec5b-749a-4cff-9a32-d66e3b0d807b"); } }
        }

    /// <summary>
    /// Note alanı
    /// </summary>
        public string InstructionNote
        {
            get { return (string)this["INSTRUCTIONNOTE"]; }
            set { this["INSTRUCTIONNOTE"] = value; }
        }

    /// <summary>
    /// Eğitim verilen yakın refakatçi mi?
    /// </summary>
        public bool? CompanionInstruction
        {
            get { return (bool?)this["COMPANIONINSTRUCTION"]; }
            set { this["COMPANIONINSTRUCTION"] = value; }
        }

        virtual protected void CreateNursingPatientAndFamilyInstructionsCollection()
        {
            _NursingPatientAndFamilyInstructions = new NursingPatientAndFamilyInstruction.ChildNursingPatientAndFamilyInstructionCollection(this, new Guid("8112821c-9c81-449d-b0a0-ad751e8d90b0"));
            ((ITTChildObjectCollection)_NursingPatientAndFamilyInstructions).GetChildren();
        }

        protected NursingPatientAndFamilyInstruction.ChildNursingPatientAndFamilyInstructionCollection _NursingPatientAndFamilyInstructions = null;
        public NursingPatientAndFamilyInstruction.ChildNursingPatientAndFamilyInstructionCollection NursingPatientAndFamilyInstructions
        {
            get
            {
                if (_NursingPatientAndFamilyInstructions == null)
                    CreateNursingPatientAndFamilyInstructionsCollection();
                return _NursingPatientAndFamilyInstructions;
            }
        }

        protected BaseNursingPatientAndFamilyInstruction(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected BaseNursingPatientAndFamilyInstruction(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected BaseNursingPatientAndFamilyInstruction(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected BaseNursingPatientAndFamilyInstruction(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected BaseNursingPatientAndFamilyInstruction(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "BASENURSINGPATIENTANDFAMILYINSTRUCTION", dataRow) { }
        protected BaseNursingPatientAndFamilyInstruction(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "BASENURSINGPATIENTANDFAMILYINSTRUCTION", dataRow, isImported) { }
        public BaseNursingPatientAndFamilyInstruction(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public BaseNursingPatientAndFamilyInstruction(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public BaseNursingPatientAndFamilyInstruction() : base() { }

    }
}