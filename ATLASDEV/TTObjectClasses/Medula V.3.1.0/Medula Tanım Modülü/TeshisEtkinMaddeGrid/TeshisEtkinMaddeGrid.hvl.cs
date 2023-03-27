
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="TeshisEtkinMaddeGrid")] 

    public  partial class TeshisEtkinMaddeGrid : TerminologyManagerDef
    {
        public class TeshisEtkinMaddeGridList : TTObjectCollection<TeshisEtkinMaddeGrid> { }
                    
        public class ChildTeshisEtkinMaddeGridCollection : TTObject.TTChildObjectCollection<TeshisEtkinMaddeGrid>
        {
            public ChildTeshisEtkinMaddeGridCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildTeshisEtkinMaddeGridCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        public Teshis Teshis
        {
            get { return (Teshis)((ITTObject)this).GetParent("TESHIS"); }
            set { this["TESHIS"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public EtkinMadde EtkinMadde
        {
            get { return (EtkinMadde)((ITTObject)this).GetParent("ETKINMADDE"); }
            set { this["ETKINMADDE"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected TeshisEtkinMaddeGrid(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected TeshisEtkinMaddeGrid(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected TeshisEtkinMaddeGrid(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected TeshisEtkinMaddeGrid(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected TeshisEtkinMaddeGrid(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "TESHISETKINMADDEGRID", dataRow) { }
        protected TeshisEtkinMaddeGrid(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "TESHISETKINMADDEGRID", dataRow, isImported) { }
        public TeshisEtkinMaddeGrid(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public TeshisEtkinMaddeGrid(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public TeshisEtkinMaddeGrid() : base() { }

    }
}