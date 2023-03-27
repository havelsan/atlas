
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="InpatientDrugOrderDetail")] 

    /// <summary>
    /// İlaç Direktifi Uygulamaları
    /// </summary>
    public  partial class InpatientDrugOrderDetail : DrugOrderDetail
    {
        public class InpatientDrugOrderDetailList : TTObjectCollection<InpatientDrugOrderDetail> { }
                    
        public class ChildInpatientDrugOrderDetailCollection : TTObject.TTChildObjectCollection<InpatientDrugOrderDetail>
        {
            public ChildInpatientDrugOrderDetailCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildInpatientDrugOrderDetailCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        new public static class States
        {
    /// <summary>
    /// Uygulandı
    /// </summary>
            public static Guid Apply { get { return new Guid("6613a06d-4359-46a2-9547-1413e80592a1"); } }
    /// <summary>
    /// İptal Edildi
    /// </summary>
            public static Guid Cancel { get { return new Guid("d20a8d9f-b209-476a-9448-875b66a11548"); } }
    /// <summary>
    /// Karşılandı
    /// </summary>
            public static Guid Supply { get { return new Guid("1d516c6e-4b74-46b6-b0f0-89e3402a3819"); } }
    /// <summary>
    /// İstendi
    /// </summary>
            public static Guid Request { get { return new Guid("e8c841da-d833-41fb-94dd-b17ad07ea603"); } }
    /// <summary>
    /// Planlandı
    /// </summary>
            public static Guid Planned { get { return new Guid("130b83ab-b2c7-4592-94c6-c4be2c9338df"); } }
        }

        protected InpatientDrugOrderDetail(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected InpatientDrugOrderDetail(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected InpatientDrugOrderDetail(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected InpatientDrugOrderDetail(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected InpatientDrugOrderDetail(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "INPATIENTDRUGORDERDETAIL", dataRow) { }
        protected InpatientDrugOrderDetail(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "INPATIENTDRUGORDERDETAIL", dataRow, isImported) { }
        public InpatientDrugOrderDetail(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public InpatientDrugOrderDetail(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public InpatientDrugOrderDetail() : base() { }

        override protected void RunPreTransition(TTObjectStateTransitionDef transDef)
        {
            if (MustCallBasePreScript(transDef))
                base.RunPreTransition(transDef.BaseTransDef);
            this.PreTransition(transDef);
        }
        override protected void RunPostTransition(TTObjectStateTransitionDef transDef)
        {
            if (MustCallBasePostScript(transDef))
                base.RunPostTransition(transDef.BaseTransDef);
            this.PostTransition(transDef);
        }
        override protected void RunUndoTransition(TTObjectStateTransitionDef transDef)
        {
            if (MustCallBaseUndoScript(transDef))
                base.RunUndoTransition(transDef.BaseTransDef);
            this.UndoTransition(transDef);
        }
    }
}