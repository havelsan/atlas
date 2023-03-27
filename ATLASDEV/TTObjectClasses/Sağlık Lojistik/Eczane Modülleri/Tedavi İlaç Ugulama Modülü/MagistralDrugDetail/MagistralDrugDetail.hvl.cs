
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="MagistralDrugDetail")] 

    public  partial class MagistralDrugDetail : TTObject
    {
        public class MagistralDrugDetailList : TTObjectCollection<MagistralDrugDetail> { }
                    
        public class ChildMagistralDrugDetailCollection : TTObject.TTChildObjectCollection<MagistralDrugDetail>
        {
            public ChildMagistralDrugDetailCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildMagistralDrugDetailCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
    /// <summary>
    /// Miktar
    /// </summary>
        public double? PreparatAmount
        {
            get { return (double?)this["PREPARATAMOUNT"]; }
            set { this["PREPARATAMOUNT"] = value; }
        }

        public Material Material
        {
            get { return (Material)((ITTObject)this).GetParent("MATERIAL"); }
            set { this["MATERIAL"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public DrugOrder DrugOrder
        {
            get { return (DrugOrder)((ITTObject)this).GetParent("DRUGORDER"); }
            set { this["DRUGORDER"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected MagistralDrugDetail(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected MagistralDrugDetail(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected MagistralDrugDetail(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected MagistralDrugDetail(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected MagistralDrugDetail(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "MAGISTRALDRUGDETAIL", dataRow) { }
        protected MagistralDrugDetail(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "MAGISTRALDRUGDETAIL", dataRow, isImported) { }
        public MagistralDrugDetail(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public MagistralDrugDetail(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public MagistralDrugDetail() : base() { }

    }
}