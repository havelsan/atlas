
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="DiabetesMellitusPursuitInstruction")] 

    /// <summary>
    /// Diabet Eğitimi Bilgisi
    /// </summary>
    public  partial class DiabetesMellitusPursuitInstruction : TTObject
    {
        public class DiabetesMellitusPursuitInstructionList : TTObjectCollection<DiabetesMellitusPursuitInstruction> { }
                    
        public class ChildDiabetesMellitusPursuitInstructionCollection : TTObject.TTChildObjectCollection<DiabetesMellitusPursuitInstruction>
        {
            public ChildDiabetesMellitusPursuitInstructionCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildDiabetesMellitusPursuitInstructionCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
    /// <summary>
    /// Bireysel Eğitim Sayısı
    /// </summary>
        public int? bireyselEgitimSayisi
        {
            get { return (int?)this["BIREYSELEGITIMSAYISI"]; }
            set { this["BIREYSELEGITIMSAYISI"] = value; }
        }

    /// <summary>
    /// Grup Eğitim Sayısı
    /// </summary>
        public int? grupEgitimiSayisi
        {
            get { return (int?)this["GRUPEGITIMISAYISI"]; }
            set { this["GRUPEGITIMISAYISI"] = value; }
        }

    /// <summary>
    /// DM Eğitim almış Mı
    /// </summary>
        public EvetHayirDurumEnum? dmEgitimiAlmisMi
        {
            get { return (EvetHayirDurumEnum?)(int?)this["DMEGITIMIALMISMI"]; }
            set { this["DMEGITIMIALMISMI"] = value; }
        }

        public DiabetesMellitusPursuit DiabetesMellitusPursuit
        {
            get { return (DiabetesMellitusPursuit)((ITTObject)this).GetParent("DIABETESMELLITUSPURSUIT"); }
            set { this["DIABETESMELLITUSPURSUIT"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected DiabetesMellitusPursuitInstruction(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected DiabetesMellitusPursuitInstruction(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected DiabetesMellitusPursuitInstruction(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected DiabetesMellitusPursuitInstruction(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected DiabetesMellitusPursuitInstruction(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "DIABETESMELLITUSPURSUITINSTRUCTION", dataRow) { }
        protected DiabetesMellitusPursuitInstruction(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "DIABETESMELLITUSPURSUITINSTRUCTION", dataRow, isImported) { }
        public DiabetesMellitusPursuitInstruction(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public DiabetesMellitusPursuitInstruction(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public DiabetesMellitusPursuitInstruction() : base() { }

    }
}