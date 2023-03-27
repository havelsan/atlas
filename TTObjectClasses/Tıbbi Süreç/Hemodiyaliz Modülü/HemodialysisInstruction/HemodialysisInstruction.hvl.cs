
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="HemodialysisInstruction")] 

    /// <summary>
    /// Hemodiyaliz Eğitimleri
    /// </summary>
    public  partial class HemodialysisInstruction : BaseMultipleDataEntry
    {
        public class HemodialysisInstructionList : TTObjectCollection<HemodialysisInstruction> { }
                    
        public class ChildHemodialysisInstructionCollection : TTObject.TTChildObjectCollection<HemodialysisInstruction>
        {
            public ChildHemodialysisInstructionCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildHemodialysisInstructionCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
    /// <summary>
    /// Tarih
    /// </summary>
        public DateTime? InstructionDate
        {
            get { return (DateTime?)this["INSTRUCTIONDATE"]; }
            set { this["INSTRUCTIONDATE"] = value; }
        }

    /// <summary>
    /// Eğitim Konusu
    /// </summary>
        public string Subject
        {
            get { return (string)this["SUBJECT"]; }
            set { this["SUBJECT"] = value; }
        }

    /// <summary>
    /// Eğitim Amacı
    /// </summary>
        public string Purpose
        {
            get { return (string)this["PURPOSE"]; }
            set { this["PURPOSE"] = value; }
        }

    /// <summary>
    /// Eğitim Süresi
    /// </summary>
        public int? Duration
        {
            get { return (int?)this["DURATION"]; }
            set { this["DURATION"] = value; }
        }

        protected HemodialysisInstruction(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected HemodialysisInstruction(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected HemodialysisInstruction(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected HemodialysisInstruction(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected HemodialysisInstruction(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "HEMODIALYSISINSTRUCTION", dataRow) { }
        protected HemodialysisInstruction(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "HEMODIALYSISINSTRUCTION", dataRow, isImported) { }
        public HemodialysisInstruction(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public HemodialysisInstruction(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public HemodialysisInstruction() : base() { }

    }
}