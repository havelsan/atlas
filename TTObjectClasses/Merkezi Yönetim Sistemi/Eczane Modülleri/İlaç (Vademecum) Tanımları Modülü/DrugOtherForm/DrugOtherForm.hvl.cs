
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="DrugOtherForm")] 

    /// <summary>
    /// İlacın Diğer Şekli
    /// </summary>
    public  partial class DrugOtherForm : TTObject
    {
        public class DrugOtherFormList : TTObjectCollection<DrugOtherForm> { }
                    
        public class ChildDrugOtherFormCollection : TTObject.TTChildObjectCollection<DrugOtherForm>
        {
            public ChildDrugOtherFormCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildDrugOtherFormCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        public DrugDefinition DrugDefinition
        {
            get { return (DrugDefinition)((ITTObject)this).GetParent("DRUGDEFINITION"); }
            set { this["DRUGDEFINITION"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public DrugDefinition OtherForm
        {
            get { return (DrugDefinition)((ITTObject)this).GetParent("OTHERFORM"); }
            set { this["OTHERFORM"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected DrugOtherForm(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected DrugOtherForm(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected DrugOtherForm(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected DrugOtherForm(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected DrugOtherForm(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "DRUGOTHERFORM", dataRow) { }
        protected DrugOtherForm(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "DRUGOTHERFORM", dataRow, isImported) { }
        public DrugOtherForm(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public DrugOtherForm(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public DrugOtherForm() : base() { }

    }
}