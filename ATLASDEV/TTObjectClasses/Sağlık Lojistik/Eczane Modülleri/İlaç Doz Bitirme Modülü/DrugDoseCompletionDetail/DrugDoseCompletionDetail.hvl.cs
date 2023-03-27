
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="DrugDoseCompletionDetail")] 

    public  partial class DrugDoseCompletionDetail : DrugOrderDetail
    {
        public class DrugDoseCompletionDetailList : TTObjectCollection<DrugDoseCompletionDetail> { }
                    
        public class ChildDrugDoseCompletionDetailCollection : TTObject.TTChildObjectCollection<DrugDoseCompletionDetail>
        {
            public ChildDrugDoseCompletionDetailCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildDrugDoseCompletionDetailCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        new public static class States
        {
    /// <summary>
    /// Uygulandı
    /// </summary>
            public static Guid Apply { get { return new Guid("5f906bd2-a280-4228-b5ee-b3dad052c827"); } }
    /// <summary>
    /// İptal Edildi
    /// </summary>
            public static Guid Cancel { get { return new Guid("828d726e-8406-48a8-b642-d89b807830bb"); } }
    /// <summary>
    /// Dış Eczane Tarafından Karşılandı
    /// </summary>
            public static Guid ExPharmacySupply { get { return new Guid("d9faeb33-7c2a-4792-94a0-0beb9e7d9e3e"); } }
    /// <summary>
    /// Hastaya Teslim Edildi
    /// </summary>
            public static Guid PatientDelivery { get { return new Guid("3622d9e8-40b0-476d-8596-8e94cd5def22"); } }
    /// <summary>
    /// Eczacılık Brm. İstendi
    /// </summary>
            public static Guid PharmacologyRequest { get { return new Guid("c9c367f3-44ae-47d6-b600-e4b616d241db"); } }
    /// <summary>
    /// Planlandı
    /// </summary>
            public static Guid Planned { get { return new Guid("c6f1e258-79da-403a-9035-6bf79d1b8173"); } }
    /// <summary>
    /// İstendi
    /// </summary>
            public static Guid Request { get { return new Guid("15afef0b-e845-46e3-bbbd-1e8f7fe01eff"); } }
    /// <summary>
    /// Durduruldu
    /// </summary>
            public static Guid Stop { get { return new Guid("6ec6acaa-52b3-4657-b7ab-2932531b1376"); } }
    /// <summary>
    /// Karşılandı
    /// </summary>
            public static Guid Supply { get { return new Guid("1442c9f0-0f38-4617-9aca-431b00b2e0a6"); } }
    /// <summary>
    /// Hastanın Üzerinde
    /// </summary>
            public static Guid UseRestDose { get { return new Guid("d95b1f46-a7e6-4ec6-8d5a-627ff782d190"); } }
        }

        public DrugDoseCompletion DrugDoseCompletion
        {
            get { return (DrugDoseCompletion)((ITTObject)this).GetParent("DRUGDOSECOMPLETION"); }
            set { this["DRUGDOSECOMPLETION"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected DrugDoseCompletionDetail(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected DrugDoseCompletionDetail(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected DrugDoseCompletionDetail(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected DrugDoseCompletionDetail(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected DrugDoseCompletionDetail(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "DRUGDOSECOMPLETIONDETAIL", dataRow) { }
        protected DrugDoseCompletionDetail(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "DRUGDOSECOMPLETIONDETAIL", dataRow, isImported) { }
        public DrugDoseCompletionDetail(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public DrugDoseCompletionDetail(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public DrugDoseCompletionDetail() : base() { }

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