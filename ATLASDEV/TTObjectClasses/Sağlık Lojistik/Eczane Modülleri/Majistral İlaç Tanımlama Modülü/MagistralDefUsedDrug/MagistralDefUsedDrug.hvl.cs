
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="MagistralDefUsedDrug")] 

    public  partial class MagistralDefUsedDrug : TTObject
    {
        public class MagistralDefUsedDrugList : TTObjectCollection<MagistralDefUsedDrug> { }
                    
        public class ChildMagistralDefUsedDrugCollection : TTObject.TTChildObjectCollection<MagistralDefUsedDrug>
        {
            public ChildMagistralDefUsedDrugCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildMagistralDefUsedDrugCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
    /// <summary>
    /// Birim Miktar
    /// </summary>
        public double? UnitAmount
        {
            get { return (double?)this["UNITAMOUNT"]; }
            set { this["UNITAMOUNT"] = value; }
        }

        public DrugDefinition Drug
        {
            get { return (DrugDefinition)((ITTObject)this).GetParent("DRUG"); }
            set { this["DRUG"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public MagistralPreparationDefinition Magistral
        {
            get { return (MagistralPreparationDefinition)((ITTObject)this).GetParent("MAGISTRAL"); }
            set { this["MAGISTRAL"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected MagistralDefUsedDrug(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected MagistralDefUsedDrug(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected MagistralDefUsedDrug(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected MagistralDefUsedDrug(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected MagistralDefUsedDrug(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "MAGISTRALDEFUSEDDRUG", dataRow) { }
        protected MagistralDefUsedDrug(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "MAGISTRALDEFUSEDDRUG", dataRow, isImported) { }
        public MagistralDefUsedDrug(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public MagistralDefUsedDrug(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public MagistralDefUsedDrug() : base() { }

    }
}