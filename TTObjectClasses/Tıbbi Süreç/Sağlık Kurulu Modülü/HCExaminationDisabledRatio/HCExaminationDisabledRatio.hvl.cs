
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="HCExaminationDisabledRatio")] 

    /// <summary>
    /// Sağlık Kurulu muayenesi çoklu engel oranı girilmesini sağlayan nesnedir
    /// </summary>
    public  partial class HCExaminationDisabledRatio : TTObject
    {
        public class HCExaminationDisabledRatioList : TTObjectCollection<HCExaminationDisabledRatio> { }
                    
        public class ChildHCExaminationDisabledRatioCollection : TTObject.TTChildObjectCollection<HCExaminationDisabledRatio>
        {
            public ChildHCExaminationDisabledRatioCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildHCExaminationDisabledRatioCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        public string DisabledRatio
        {
            get { return (string)this["DISABLEDRATIO"]; }
            set { this["DISABLEDRATIO"] = value; }
        }

        public HCExaminationComponent HCExaminationComponent
        {
            get { return (HCExaminationComponent)((ITTObject)this).GetParent("HCEXAMINATIONCOMPONENT"); }
            set { this["HCEXAMINATIONCOMPONENT"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected HCExaminationDisabledRatio(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected HCExaminationDisabledRatio(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected HCExaminationDisabledRatio(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected HCExaminationDisabledRatio(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected HCExaminationDisabledRatio(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "HCEXAMINATIONDISABLEDRATIO", dataRow) { }
        protected HCExaminationDisabledRatio(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "HCEXAMINATIONDISABLEDRATIO", dataRow, isImported) { }
        public HCExaminationDisabledRatio(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public HCExaminationDisabledRatio(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public HCExaminationDisabledRatio() : base() { }

    }
}