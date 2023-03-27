
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="PurchasingDocumentState")] 

    /// <summary>
    /// Mahalli Satınalmada İhale İçin Gerekli Olup Firmaların Getirmesi Gereken Belgeler İçin Kullanılan Sınıftır. Her Firmanın Getirmesi Gereken Her Belge İçin Ayrı Bir Instance Yaratılarak Durumları Bu Sınıf Üzerinden Takip Edilir
    /// </summary>
    public  partial class PurchasingDocumentState : TTObject
    {
        public class PurchasingDocumentStateList : TTObjectCollection<PurchasingDocumentState> { }
                    
        public class ChildPurchasingDocumentStateCollection : TTObject.TTChildObjectCollection<PurchasingDocumentState>
        {
            public ChildPurchasingDocumentStateCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildPurchasingDocumentStateCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetUnEligibleDocuments_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public Guid? ObjectDefID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTDEFID"]);
                }
            }

            public Guid? CurrentStateDefID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["CURRENTSTATEDEFID"]);
                }
            }

            public DateTime? LastUpdate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["LASTUPDATE"]);
                    if (val == null)
                        return null;
                    return (DateTime)Convert.ChangeType(val, typeof(DateTime)); 
                }
            }

            public string DocName
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DOCNAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PURCHASINGDOCUMENTSTATE"].AllPropertyDefs["DOCNAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public bool? Approved
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["APPROVED"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PURCHASINGDOCUMENTSTATE"].AllPropertyDefs["APPROVED"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public bool? Needed
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["NEEDED"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PURCHASINGDOCUMENTSTATE"].AllPropertyDefs["NEEDED"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public string DenyDesc
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DENYDESC"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PURCHASINGDOCUMENTSTATE"].AllPropertyDefs["DENYDESC"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public bool? Bringed
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["BRINGED"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PURCHASINGDOCUMENTSTATE"].AllPropertyDefs["BRINGED"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public string Supplier
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["SUPPLIER"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SUPPLIER"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public GetUnEligibleDocuments_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetUnEligibleDocuments_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetUnEligibleDocuments_Class() : base() { }
        }

        public static class States
        {
            public static Guid Cancelled { get { return new Guid("7eeda171-273d-4f51-afa3-4cb4cfa6d75f"); } }
            public static Guid New { get { return new Guid("d7aeee1c-166c-4cf2-b864-2d1722c85c01"); } }
        }

        public static BindingList<PurchasingDocumentState.GetUnEligibleDocuments_Class> GetUnEligibleDocuments(string TTOBJECTID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PURCHASINGDOCUMENTSTATE"].QueryDefs["GetUnEligibleDocuments"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("TTOBJECTID", TTOBJECTID);

            return TTReportNqlObject.QueryObjects<PurchasingDocumentState.GetUnEligibleDocuments_Class>(queryDef, paramList, pi);
        }

        public static BindingList<PurchasingDocumentState.GetUnEligibleDocuments_Class> GetUnEligibleDocuments(TTObjectContext objectContext, string TTOBJECTID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PURCHASINGDOCUMENTSTATE"].QueryDefs["GetUnEligibleDocuments"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("TTOBJECTID", TTOBJECTID);

            return TTReportNqlObject.QueryObjects<PurchasingDocumentState.GetUnEligibleDocuments_Class>(objectContext, queryDef, paramList, pi);
        }

    /// <summary>
    /// Döküman Adı
    /// </summary>
        public string DocName
        {
            get { return (string)this["DOCNAME"]; }
            set { this["DOCNAME"] = value; }
        }

    /// <summary>
    /// Geçerli
    /// </summary>
        public bool? Approved
        {
            get { return (bool?)this["APPROVED"]; }
            set { this["APPROVED"] = value; }
        }

    /// <summary>
    /// Zorunlu
    /// </summary>
        public bool? Needed
        {
            get { return (bool?)this["NEEDED"]; }
            set { this["NEEDED"] = value; }
        }

    /// <summary>
    /// Uygun Sayılmama Gerekçesi
    /// </summary>
        public string DenyDesc
        {
            get { return (string)this["DENYDESC"]; }
            set { this["DENYDESC"] = value; }
        }

    /// <summary>
    /// Getirdi
    /// </summary>
        public bool? Bringed
        {
            get { return (bool?)this["BRINGED"]; }
            set { this["BRINGED"] = value; }
        }

        public PurchasingDocumentsForFirmsDefinition PurchasingDocsForFirmsDef
        {
            get { return (PurchasingDocumentsForFirmsDefinition)((ITTObject)this).GetParent("PURCHASINGDOCSFORFIRMSDEF"); }
            set { this["PURCHASINGDOCSFORFIRMSDEF"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public PurchaseProjectProposalFirm PurchaseProjectProposalFirm
        {
            get { return (PurchaseProjectProposalFirm)((ITTObject)this).GetParent("PURCHASEPROJECTPROPOSALFIRM"); }
            set { this["PURCHASEPROJECTPROPOSALFIRM"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected PurchasingDocumentState(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected PurchasingDocumentState(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected PurchasingDocumentState(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected PurchasingDocumentState(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected PurchasingDocumentState(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "PURCHASINGDOCUMENTSTATE", dataRow) { }
        protected PurchasingDocumentState(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "PURCHASINGDOCUMENTSTATE", dataRow, isImported) { }
        public PurchasingDocumentState(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public PurchasingDocumentState(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public PurchasingDocumentState() : base() { }

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