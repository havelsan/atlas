
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="DistributionTermAction")] 

    /// <summary>
    /// Reçete Dağıtım Dönem Açma
    /// </summary>
    public  partial class DistributionTermAction : BaseAction
    {
        public class DistributionTermActionList : TTObjectCollection<DistributionTermAction> { }
                    
        public class ChildDistributionTermActionCollection : TTObject.TTChildObjectCollection<DistributionTermAction>
        {
            public ChildDistributionTermActionCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildDistributionTermActionCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        public static class States
        {
    /// <summary>
    /// Tamamlandı
    /// </summary>
            public static Guid Completed { get { return new Guid("d346a041-a6ac-4c50-892c-9e37bfa42d7c"); } }
    /// <summary>
    /// İptal Edildi
    /// </summary>
            public static Guid Cancelled { get { return new Guid("52e415ad-30f6-4751-a6de-baefb5c18a85"); } }
    /// <summary>
    /// Yeni
    /// </summary>
            public static Guid New { get { return new Guid("8c094698-b7c7-416d-99a1-0c95bfbb9b71"); } }
        }

    /// <summary>
    /// Acıklama
    /// </summary>
        public string Description
        {
            get { return (string)this["DESCRIPTION"]; }
            set { this["DESCRIPTION"] = value; }
        }

    /// <summary>
    /// Başlangıç Tarihi
    /// </summary>
        public DateTime? StartDate
        {
            get { return (DateTime?)this["STARTDATE"]; }
            set { this["STARTDATE"] = value; }
        }

    /// <summary>
    /// Bitiş Tarihi
    /// </summary>
        public DateTime? EndDate
        {
            get { return (DateTime?)this["ENDDATE"]; }
            set { this["ENDDATE"] = value; }
        }

        public ExternalPharmacyDistributionTerm CloseTerm
        {
            get { return (ExternalPharmacyDistributionTerm)((ITTObject)this).GetParent("CLOSETERM"); }
            set { this["CLOSETERM"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected DistributionTermAction(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected DistributionTermAction(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected DistributionTermAction(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected DistributionTermAction(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected DistributionTermAction(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "DISTRIBUTIONTERMACTION", dataRow) { }
        protected DistributionTermAction(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "DISTRIBUTIONTERMACTION", dataRow, isImported) { }
        public DistributionTermAction(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public DistributionTermAction(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public DistributionTermAction() : base() { }

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