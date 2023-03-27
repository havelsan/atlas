
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="MagistralPrescription")] 

    /// <summary>
    /// Eczacılık Bilimleri İstek
    /// </summary>
    public  partial class MagistralPrescription : EpisodeAction
    {
        public class MagistralPrescriptionList : TTObjectCollection<MagistralPrescription> { }
                    
        public class ChildMagistralPrescriptionCollection : TTObject.TTChildObjectCollection<MagistralPrescription>
        {
            public ChildMagistralPrescriptionCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildMagistralPrescriptionCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        public static class States
        {
    /// <summary>
    /// Kayıt
    /// </summary>
            public static Guid Record { get { return new Guid("0652d3ea-fd0f-4078-87a7-1295ae09c9f6"); } }
    /// <summary>
    /// Tamamlandı
    /// </summary>
            public static Guid Completed { get { return new Guid("d3251f6d-75c9-403c-961b-10ee824a1c31"); } }
    /// <summary>
    /// İptal Edildi
    /// </summary>
            public static Guid Cancelled { get { return new Guid("1d9f2211-5e64-4f10-8cc6-c017c43f5a22"); } }
    /// <summary>
    /// Ecz. Blm. Karşılama
    /// </summary>
            public static Guid Approval { get { return new Guid("a31b8740-d63c-491f-a554-fc2d4f4a24cf"); } }
        }

    /// <summary>
    /// Doldurma Tarihi
    /// </summary>
        public DateTime? FillingDate
        {
            get { return (DateTime?)this["FILLINGDATE"]; }
            set { this["FILLINGDATE"] = value; }
        }

        public DrugOrder DrugOrder
        {
            get { return (DrugOrder)((ITTObject)this).GetParent("DRUGORDER"); }
            set { this["DRUGORDER"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected MagistralPrescription(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected MagistralPrescription(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected MagistralPrescription(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected MagistralPrescription(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected MagistralPrescription(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "MAGISTRALPRESCRIPTION", dataRow) { }
        protected MagistralPrescription(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "MAGISTRALPRESCRIPTION", dataRow, isImported) { }
        public MagistralPrescription(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public MagistralPrescription(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public MagistralPrescription() : base() { }

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