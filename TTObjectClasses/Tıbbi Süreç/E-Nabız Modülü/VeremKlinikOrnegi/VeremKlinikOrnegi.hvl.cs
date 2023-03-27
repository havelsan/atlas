
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="VeremKlinikOrnegi")] 

    public  partial class VeremKlinikOrnegi : TTObject
    {
        public class VeremKlinikOrnegiList : TTObjectCollection<VeremKlinikOrnegi> { }
                    
        public class ChildVeremKlinikOrnegiCollection : TTObject.TTChildObjectCollection<VeremKlinikOrnegi>
        {
            public ChildVeremKlinikOrnegiCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildVeremKlinikOrnegiCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        public SKRSVeremHastasiKlinikOrnegi SKRSVeremHastasiKlinikOrnegi
        {
            get { return (SKRSVeremHastasiKlinikOrnegi)((ITTObject)this).GetParent("SKRSVEREMHASTASIKLINIKORNEGI"); }
            set { this["SKRSVEREMHASTASIKLINIKORNEGI"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public VeremVeriSeti VeremVeriSeti
        {
            get { return (VeremVeriSeti)((ITTObject)this).GetParent("VEREMVERISETI"); }
            set { this["VEREMVERISETI"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected VeremKlinikOrnegi(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected VeremKlinikOrnegi(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected VeremKlinikOrnegi(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected VeremKlinikOrnegi(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected VeremKlinikOrnegi(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "VEREMKLINIKORNEGI", dataRow) { }
        protected VeremKlinikOrnegi(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "VEREMKLINIKORNEGI", dataRow, isImported) { }
        public VeremKlinikOrnegi(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public VeremKlinikOrnegi(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public VeremKlinikOrnegi() : base() { }

    }
}