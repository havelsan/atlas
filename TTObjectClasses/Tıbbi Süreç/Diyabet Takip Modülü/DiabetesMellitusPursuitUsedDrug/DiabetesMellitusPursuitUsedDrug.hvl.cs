
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="DiabetesMellitusPursuitUsedDrug")] 

    /// <summary>
    /// Diabet Hastanın Kullandığı İlaç Bilgileri
    /// </summary>
    public  partial class DiabetesMellitusPursuitUsedDrug : TTObject
    {
        public class DiabetesMellitusPursuitUsedDrugList : TTObjectCollection<DiabetesMellitusPursuitUsedDrug> { }
                    
        public class ChildDiabetesMellitusPursuitUsedDrugCollection : TTObject.TTChildObjectCollection<DiabetesMellitusPursuitUsedDrug>
        {
            public ChildDiabetesMellitusPursuitUsedDrugCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildDiabetesMellitusPursuitUsedDrugCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
    /// <summary>
    /// Barkod
    /// </summary>
        public string barkod
        {
            get { return (string)this["BARKOD"]; }
            set { this["BARKOD"] = value; }
        }

    /// <summary>
    /// Günlük Doz
    /// </summary>
        public string gunlukDoz
        {
            get { return (string)this["GUNLUKDOZ"]; }
            set { this["GUNLUKDOZ"] = value; }
        }

        public DiabetesMellitusPursuit DiabetesMellitusPursuit
        {
            get { return (DiabetesMellitusPursuit)((ITTObject)this).GetParent("DIABETESMELLITUSPURSUIT"); }
            set { this["DIABETESMELLITUSPURSUIT"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected DiabetesMellitusPursuitUsedDrug(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected DiabetesMellitusPursuitUsedDrug(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected DiabetesMellitusPursuitUsedDrug(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected DiabetesMellitusPursuitUsedDrug(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected DiabetesMellitusPursuitUsedDrug(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "DIABETESMELLITUSPURSUITUSEDDRUG", dataRow) { }
        protected DiabetesMellitusPursuitUsedDrug(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "DIABETESMELLITUSPURSUITUSEDDRUG", dataRow, isImported) { }
        public DiabetesMellitusPursuitUsedDrug(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public DiabetesMellitusPursuitUsedDrug(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public DiabetesMellitusPursuitUsedDrug() : base() { }

    }
}