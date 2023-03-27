
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="HalfDoseDestructionDetail")] 

    public  partial class HalfDoseDestructionDetail : TTObject
    {
        public class HalfDoseDestructionDetailList : TTObjectCollection<HalfDoseDestructionDetail> { }
                    
        public class ChildHalfDoseDestructionDetailCollection : TTObject.TTChildObjectCollection<HalfDoseDestructionDetail>
        {
            public ChildHalfDoseDestructionDetailCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildHalfDoseDestructionDetailCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
    /// <summary>
    /// İlaç
    /// </summary>
        public string DrugName
        {
            get { return (string)this["DRUGNAME"]; }
            set { this["DRUGNAME"] = value; }
        }

    /// <summary>
    /// Kabul Edilen Miktar
    /// </summary>
        public double? Amount
        {
            get { return (double?)this["AMOUNT"]; }
            set { this["AMOUNT"] = value; }
        }

    /// <summary>
    /// İlaç Formu
    /// </summary>
        public string NFCType
        {
            get { return (string)this["NFCTYPE"]; }
            set { this["NFCTYPE"] = value; }
        }

        public HalfDoseDestruction HalfDoseDestruction
        {
            get { return (HalfDoseDestruction)((ITTObject)this).GetParent("HALFDOSEDESTRUCTION"); }
            set { this["HALFDOSEDESTRUCTION"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public UnitDefinition UnitDefinition
        {
            get { return (UnitDefinition)((ITTObject)this).GetParent("UNITDEFINITION"); }
            set { this["UNITDEFINITION"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected HalfDoseDestructionDetail(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected HalfDoseDestructionDetail(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected HalfDoseDestructionDetail(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected HalfDoseDestructionDetail(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected HalfDoseDestructionDetail(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "HALFDOSEDESTRUCTIONDETAIL", dataRow) { }
        protected HalfDoseDestructionDetail(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "HALFDOSEDESTRUCTIONDETAIL", dataRow, isImported) { }
        public HalfDoseDestructionDetail(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public HalfDoseDestructionDetail(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public HalfDoseDestructionDetail() : base() { }

    }
}