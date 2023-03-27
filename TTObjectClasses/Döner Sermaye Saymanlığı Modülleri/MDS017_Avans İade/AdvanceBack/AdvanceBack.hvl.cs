
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="AdvanceBack")] 

    /// <summary>
    /// Avans İade İşlemi
    /// </summary>
    public  partial class AdvanceBack : EpisodeAccountAction
    {
        public class AdvanceBackList : TTObjectCollection<AdvanceBack> { }
                    
        public class ChildAdvanceBackCollection : TTObject.TTChildObjectCollection<AdvanceBack>
        {
            public ChildAdvanceBackCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildAdvanceBackCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        public static class States
        {
            public static Guid Paid { get { return new Guid("984c3575-c5b1-4700-a257-7232d60c3e14"); } }
            public static Guid New { get { return new Guid("f548fd32-0c26-41d0-a6a9-ae40e1202033"); } }
        }

        public static BindingList<AdvanceBack> GetByEpisode(TTObjectContext objectContext, string PARAMEPISODE, string PARAMSTATE)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["ADVANCEBACK"].QueryDefs["GetByEpisode"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("PARAMEPISODE", PARAMEPISODE);
            paramList.Add("PARAMSTATE", PARAMSTATE);

            return ((ITTQuery)objectContext).QueryObjects<AdvanceBack>(queryDef, paramList);
        }

    /// <summary>
    /// Toplam Avans Tutarı
    /// </summary>
        public Currency? ADVANCETOTAL
        {
            get { return (Currency?)this["ADVANCETOTAL"]; }
            set { this["ADVANCETOTAL"] = value; }
        }

    /// <summary>
    /// Verilen Hizmet Toplamı
    /// </summary>
        public Currency? SERVICETOTAL
        {
            get { return (Currency?)this["SERVICETOTAL"]; }
            set { this["SERVICETOTAL"] = value; }
        }

    /// <summary>
    /// İade Edilen Avans Toplam Tutarı
    /// </summary>
        public Currency? ADVANCEBACKTOTAL
        {
            get { return (Currency?)this["ADVANCEBACKTOTAL"]; }
            set { this["ADVANCEBACKTOTAL"] = value; }
        }

    /// <summary>
    /// İade Sebebi
    /// </summary>
        public string REASONOFRETURN
        {
            get { return (string)this["REASONOFRETURN"]; }
            set { this["REASONOFRETURN"] = value; }
        }

    /// <summary>
    /// Hizmet Karşılığı Makbuz Toplamı
    /// </summary>
        public Currency? RECEIPTTOTAL
        {
            get { return (Currency?)this["RECEIPTTOTAL"]; }
            set { this["RECEIPTTOTAL"] = value; }
        }

    /// <summary>
    /// İade Edilen Makbuz Toplam Tutarı
    /// </summary>
        public Currency? RECEIPTBACKTOTAL
        {
            get { return (Currency?)this["RECEIPTBACKTOTAL"]; }
            set { this["RECEIPTBACKTOTAL"] = value; }
        }

    /// <summary>
    /// Senet Toplamı
    /// </summary>
        public Currency? BONDTOTAL
        {
            get { return (Currency?)this["BONDTOTAL"]; }
            set { this["BONDTOTAL"] = value; }
        }

    /// <summary>
    /// Avans İade Dökümanıyla İlişkisi
    /// </summary>
        public AdvanceBackDocument AdvanceBackDocument
        {
            get { return (AdvanceBackDocument)((ITTObject)this).GetParent("ADVANCEBACKDOCUMENT"); }
            set { this["ADVANCEBACKDOCUMENT"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        virtual protected void CreateAdvanceBackAdvanceDetailCollection()
        {
            _AdvanceBackAdvanceDetail = new AdvanceBackAdvanceDetail.ChildAdvanceBackAdvanceDetailCollection(this, new Guid("5bba6319-cbba-4233-8501-a7716706a042"));
            ((ITTChildObjectCollection)_AdvanceBackAdvanceDetail).GetChildren();
        }

        protected AdvanceBackAdvanceDetail.ChildAdvanceBackAdvanceDetailCollection _AdvanceBackAdvanceDetail = null;
    /// <summary>
    /// Child collection for Avans İade İşlemiyle İlişkisi
    /// </summary>
        public AdvanceBackAdvanceDetail.ChildAdvanceBackAdvanceDetailCollection AdvanceBackAdvanceDetail
        {
            get
            {
                if (_AdvanceBackAdvanceDetail == null)
                    CreateAdvanceBackAdvanceDetailCollection();
                return _AdvanceBackAdvanceDetail;
            }
        }

        override protected void CreateAccountDocumentsCollection()
        {
            _AccountDocuments = new AccountDocument.ChildAccountDocumentCollection(this, new Guid("a37d61a6-3b5c-4762-b68a-c6a0c06e2b84"));
            ((ITTChildObjectCollection)_AccountDocuments).GetChildren();
        }

        protected AdvanceBack(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected AdvanceBack(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected AdvanceBack(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected AdvanceBack(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected AdvanceBack(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "ADVANCEBACK", dataRow) { }
        protected AdvanceBack(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "ADVANCEBACK", dataRow, isImported) { }
        public AdvanceBack(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public AdvanceBack(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public AdvanceBack() : base() { }

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