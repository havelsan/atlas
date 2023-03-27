
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="MagistralPreparationUsedDetail")] 

    /// <summary>
    /// Kullanılan Malzeme Sekmesi
    /// </summary>
    public  partial class MagistralPreparationUsedDetail : StockActionDetailOut
    {
        public class MagistralPreparationUsedDetailList : TTObjectCollection<MagistralPreparationUsedDetail> { }
                    
        public class ChildMagistralPreparationUsedDetailCollection : TTObject.TTChildObjectCollection<MagistralPreparationUsedDetail>
        {
            public ChildMagistralPreparationUsedDetailCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildMagistralPreparationUsedDetailCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        protected MagistralPreparationUsedDetail(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected MagistralPreparationUsedDetail(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected MagistralPreparationUsedDetail(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected MagistralPreparationUsedDetail(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected MagistralPreparationUsedDetail(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "MAGISTRALPREPARATIONUSEDDETAIL", dataRow) { }
        protected MagistralPreparationUsedDetail(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "MAGISTRALPREPARATIONUSEDDETAIL", dataRow, isImported) { }
        public MagistralPreparationUsedDetail(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public MagistralPreparationUsedDetail(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public MagistralPreparationUsedDetail() : base() { }

    }
}