
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="MagistralChemicalDetail")] 

    public  partial class MagistralChemicalDetail : TTObject
    {
        public class MagistralChemicalDetailList : TTObjectCollection<MagistralChemicalDetail> { }
                    
        public class ChildMagistralChemicalDetailCollection : TTObject.TTChildObjectCollection<MagistralChemicalDetail>
        {
            public ChildMagistralChemicalDetailCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildMagistralChemicalDetailCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
    /// <summary>
    /// Miktar
    /// </summary>
        public double? ChemicalAmount
        {
            get { return (double?)this["CHEMICALAMOUNT"]; }
            set { this["CHEMICALAMOUNT"] = value; }
        }

        public MagistralChemicalDefinition MagistralChemicalDefinition
        {
            get { return (MagistralChemicalDefinition)((ITTObject)this).GetParent("MAGISTRALCHEMICALDEFINITION"); }
            set { this["MAGISTRALCHEMICALDEFINITION"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public DrugOrder DrugOrder
        {
            get { return (DrugOrder)((ITTObject)this).GetParent("DRUGORDER"); }
            set { this["DRUGORDER"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected MagistralChemicalDetail(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected MagistralChemicalDetail(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected MagistralChemicalDetail(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected MagistralChemicalDetail(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected MagistralChemicalDetail(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "MAGISTRALCHEMICALDETAIL", dataRow) { }
        protected MagistralChemicalDetail(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "MAGISTRALCHEMICALDETAIL", dataRow, isImported) { }
        public MagistralChemicalDetail(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public MagistralChemicalDetail(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public MagistralChemicalDetail() : base() { }

    }
}