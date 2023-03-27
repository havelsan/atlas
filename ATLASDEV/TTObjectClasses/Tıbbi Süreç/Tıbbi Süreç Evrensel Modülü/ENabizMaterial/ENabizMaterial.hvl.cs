
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="ENabizMaterial")] 

    public  partial class ENabizMaterial : TTObject
    {
        public class ENabizMaterialList : TTObjectCollection<ENabizMaterial> { }
                    
        public class ChildENabizMaterialCollection : TTObject.TTChildObjectCollection<ENabizMaterial>
        {
            public ChildENabizMaterialCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildENabizMaterialCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        public static class States
        {
    /// <summary>
    /// Tamamlandı
    /// </summary>
            public static Guid Completed { get { return new Guid("73947974-45f8-4b89-a2f3-ef4c5f806834"); } }
    /// <summary>
    /// İptal Edildi
    /// </summary>
            public static Guid Cancelled { get { return new Guid("1cfccd69-0396-4b76-96b1-2f3363c0189a"); } }
        }

    /// <summary>
    /// İstek Tarihi
    /// </summary>
        public DateTime? RequestDate
        {
            get { return (DateTime?)this["REQUESTDATE"]; }
            set { this["REQUESTDATE"] = value; }
        }

    /// <summary>
    /// Hasta Payı
    /// </summary>
        public double? PatientPrice
        {
            get { return (double?)this["PATIENTPRICE"]; }
            set { this["PATIENTPRICE"] = value; }
        }

    /// <summary>
    /// Kurum Payı
    /// </summary>
        public double? PayerPrice
        {
            get { return (double?)this["PAYERPRICE"]; }
            set { this["PAYERPRICE"] = value; }
        }

    /// <summary>
    /// Uygulama Tarihi
    /// </summary>
        public DateTime? ApplicationDate
        {
            get { return (DateTime?)this["APPLICATIONDATE"]; }
            set { this["APPLICATIONDATE"] = value; }
        }

        public SubActionMaterial SubActionMaterial
        {
            get { return (SubActionMaterial)((ITTObject)this).GetParent("SUBACTIONMATERIAL"); }
            set { this["SUBACTIONMATERIAL"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public AccountTransaction AccountTransaction
        {
            get { return (AccountTransaction)((ITTObject)this).GetParent("ACCOUNTTRANSACTION"); }
            set { this["ACCOUNTTRANSACTION"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected ENabizMaterial(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected ENabizMaterial(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected ENabizMaterial(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected ENabizMaterial(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected ENabizMaterial(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "ENABIZMATERIAL", dataRow) { }
        protected ENabizMaterial(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "ENABIZMATERIAL", dataRow, isImported) { }
        public ENabizMaterial(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public ENabizMaterial(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public ENabizMaterial() : base() { }

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