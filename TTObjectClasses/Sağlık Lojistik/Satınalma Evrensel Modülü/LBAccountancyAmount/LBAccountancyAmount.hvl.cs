
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="LBAccountancyAmount")] 

    /// <summary>
    /// Lojistik ikmal faaliyetleri modülünde kullanılan saymanlık mevcut bilgilerini tutmak için kullanılır
    /// </summary>
    public  partial class LBAccountancyAmount : TTObject
    {
        public class LBAccountancyAmountList : TTObjectCollection<LBAccountancyAmount> { }
                    
        public class ChildLBAccountancyAmountCollection : TTObject.TTChildObjectCollection<LBAccountancyAmount>
        {
            public ChildLBAccountancyAmountCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildLBAccountancyAmountCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        public static class States
        {
    /// <summary>
    /// Yeni
    /// </summary>
            public static Guid New { get { return new Guid("d8117b22-bf1b-4263-8cfa-fc98ebaba87d"); } }
    /// <summary>
    /// Beklemede
    /// </summary>
            public static Guid Waiting { get { return new Guid("fa82cfb8-626d-40c5-b129-ea677d4a821a"); } }
    /// <summary>
    /// Cvp Döndü
    /// </summary>
            public static Guid Returned { get { return new Guid("cede3e43-e4fa-45e8-ab2b-ff9e35ce8768"); } }
    /// <summary>
    /// İptal
    /// </summary>
            public static Guid Cancelled { get { return new Guid("140f02f7-5855-4e89-9963-b4c6d2cc6ec8"); } }
        }

        public Currency? Amount
        {
            get { return (Currency?)this["AMOUNT"]; }
            set { this["AMOUNT"] = value; }
        }

        public Guid? TTMessageID
        {
            get { return (Guid?)this["TTMESSAGEID"]; }
            set { this["TTMESSAGEID"] = value; }
        }

    /// <summary>
    /// İhtiyaç Fazlası Mevcut
    /// </summary>
        public Currency? SurplusAmount
        {
            get { return (Currency?)this["SURPLUSAMOUNT"]; }
            set { this["SURPLUSAMOUNT"] = value; }
        }

        public Accountancy Accountancy
        {
            get { return (Accountancy)((ITTObject)this).GetParent("ACCOUNTANCY"); }
            set { this["ACCOUNTANCY"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected LBAccountancyAmount(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected LBAccountancyAmount(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected LBAccountancyAmount(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected LBAccountancyAmount(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected LBAccountancyAmount(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "LBACCOUNTANCYAMOUNT", dataRow) { }
        protected LBAccountancyAmount(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "LBACCOUNTANCYAMOUNT", dataRow, isImported) { }
        public LBAccountancyAmount(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public LBAccountancyAmount(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public LBAccountancyAmount() : base() { }

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