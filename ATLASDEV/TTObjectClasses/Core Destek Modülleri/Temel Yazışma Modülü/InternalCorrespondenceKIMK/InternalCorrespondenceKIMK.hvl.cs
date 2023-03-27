
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="InternalCorrespondenceKIMK")] 

    /// <summary>
    /// Karargah İçi Mütalaa
    /// </summary>
    public  partial class InternalCorrespondenceKIMK : TTObject
    {
        public class InternalCorrespondenceKIMKList : TTObjectCollection<InternalCorrespondenceKIMK> { }
                    
        public class ChildInternalCorrespondenceKIMKCollection : TTObject.TTChildObjectCollection<InternalCorrespondenceKIMK>
        {
            public ChildInternalCorrespondenceKIMKCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildInternalCorrespondenceKIMKCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class InternalCorrespondenceKIMKNQL_Class : TTReportNqlObject 
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

            public string NumberLiteral
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["NUMBERLITERAL"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["INTERNALCORRESPONDENCEKIMK"].AllPropertyDefs["NUMBERLITERAL"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Caption
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["CAPTION"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["INTERNALCORRESPONDENCEKIMK"].AllPropertyDefs["CAPTION"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string To
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["TO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["INTERNALCORRESPONDENCEKIMK"].AllPropertyDefs["TO"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Addition
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ADDITION"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["INTERNALCORRESPONDENCEKIMK"].AllPropertyDefs["ADDITION"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Number
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["NUMBER"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["INTERNALCORRESPONDENCEKIMK"].AllPropertyDefs["NUMBER"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string From
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["FROM"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["INTERNALCORRESPONDENCEKIMK"].AllPropertyDefs["FROM"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Coordinator
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["COORDINATOR"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["INTERNALCORRESPONDENCEKIMK"].AllPropertyDefs["COORDINATOR"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string RelatedList
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["RELATEDLIST"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["INTERNALCORRESPONDENCEKIMK"].AllPropertyDefs["RELATEDLIST"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Subject
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["SUBJECT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["INTERNALCORRESPONDENCEKIMK"].AllPropertyDefs["SUBJECT"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string DocumentDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DOCUMENTDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["INTERNALCORRESPONDENCEKIMK"].AllPropertyDefs["DOCUMENTDATE"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Reference
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["REFERENCE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["INTERNALCORRESPONDENCEKIMK"].AllPropertyDefs["REFERENCE"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string ReportText
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["REPORTTEXT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["INTERNALCORRESPONDENCEKIMK"].AllPropertyDefs["REPORTTEXT"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public ClassificationDegreeForDocuments? ClassificationDegree
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["CLASSIFICATIONDEGREE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["INTERNALCORRESPONDENCEKIMK"].AllPropertyDefs["CLASSIFICATIONDEGREE"].DataType;
                    return (ClassificationDegreeForDocuments?)(int)dataType.ConvertValue(val);
                }
            }

            public InternalCorrespondenceKIMKNQL_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public InternalCorrespondenceKIMKNQL_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected InternalCorrespondenceKIMKNQL_Class() : base() { }
        }

        public static class States
        {
    /// <summary>
    /// Yeni
    /// </summary>
            public static Guid New { get { return new Guid("2f94a580-f09d-4eb0-a4c5-3e4839d41f49"); } }
    /// <summary>
    /// İptal
    /// </summary>
            public static Guid Cancelled { get { return new Guid("d5f5e971-8936-41ce-8e6d-8b8025910268"); } }
        }

        public static BindingList<InternalCorrespondenceKIMK.InternalCorrespondenceKIMKNQL_Class> InternalCorrespondenceKIMKNQL(string OBJECTID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["INTERNALCORRESPONDENCEKIMK"].QueryDefs["InternalCorrespondenceKIMKNQL"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("OBJECTID", OBJECTID);

            return TTReportNqlObject.QueryObjects<InternalCorrespondenceKIMK.InternalCorrespondenceKIMKNQL_Class>(queryDef, paramList, pi);
        }

        public static BindingList<InternalCorrespondenceKIMK.InternalCorrespondenceKIMKNQL_Class> InternalCorrespondenceKIMKNQL(TTObjectContext objectContext, string OBJECTID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["INTERNALCORRESPONDENCEKIMK"].QueryDefs["InternalCorrespondenceKIMKNQL"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("OBJECTID", OBJECTID);

            return TTReportNqlObject.QueryObjects<InternalCorrespondenceKIMK.InternalCorrespondenceKIMKNQL_Class>(objectContext, queryDef, paramList, pi);
        }

    /// <summary>
    /// Sayı Adı
    /// </summary>
        public string NumberLiteral
        {
            get { return (string)this["NUMBERLITERAL"]; }
            set { this["NUMBERLITERAL"] = value; }
        }

    /// <summary>
    /// Başlık
    /// </summary>
        public string Caption
        {
            get { return (string)this["CAPTION"]; }
            set { this["CAPTION"] = value; }
        }

    /// <summary>
    /// Nereye
    /// </summary>
        public string To
        {
            get { return (string)this["TO"]; }
            set { this["TO"] = value; }
        }

    /// <summary>
    /// Ekler
    /// </summary>
        public string Addition
        {
            get { return (string)this["ADDITION"]; }
            set { this["ADDITION"] = value; }
        }

    /// <summary>
    /// Sayı
    /// </summary>
        public string Number
        {
            get { return (string)this["NUMBER"]; }
            set { this["NUMBER"] = value; }
        }

    /// <summary>
    /// Nereden
    /// </summary>
        public string From
        {
            get { return (string)this["FROM"]; }
            set { this["FROM"] = value; }
        }

    /// <summary>
    /// Koordinatör
    /// </summary>
        public string Coordinator
        {
            get { return (string)this["COORDINATOR"]; }
            set { this["COORDINATOR"] = value; }
        }

    /// <summary>
    /// Liste
    /// </summary>
        public string RelatedList
        {
            get { return (string)this["RELATEDLIST"]; }
            set { this["RELATEDLIST"] = value; }
        }

    /// <summary>
    /// Konu
    /// </summary>
        public string Subject
        {
            get { return (string)this["SUBJECT"]; }
            set { this["SUBJECT"] = value; }
        }

    /// <summary>
    /// Döküman Tarihi
    /// </summary>
        public string DocumentDate
        {
            get { return (string)this["DOCUMENTDATE"]; }
            set { this["DOCUMENTDATE"] = value; }
        }

    /// <summary>
    /// İlgi
    /// </summary>
        public string Reference
        {
            get { return (string)this["REFERENCE"]; }
            set { this["REFERENCE"] = value; }
        }

    /// <summary>
    /// Rapor Metni
    /// </summary>
        public string ReportText
        {
            get { return (string)this["REPORTTEXT"]; }
            set { this["REPORTTEXT"] = value; }
        }

    /// <summary>
    /// Gizlilik Derecesi
    /// </summary>
        public ClassificationDegreeForDocuments? ClassificationDegree
        {
            get { return (ClassificationDegreeForDocuments?)(int?)this["CLASSIFICATIONDEGREE"]; }
            set { this["CLASSIFICATIONDEGREE"] = value; }
        }

        public PurchaseOrder PurchaseOrder
        {
            get { return (PurchaseOrder)((ITTObject)this).GetParent("PURCHASEORDER"); }
            set { this["PURCHASEORDER"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public ResUser ReportSender
        {
            get { return (ResUser)((ITTObject)this).GetParent("REPORTSENDER"); }
            set { this["REPORTSENDER"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        virtual protected void CreateParaphsCollection()
        {
            _Paraphs = new Paraph.ChildParaphCollection(this, new Guid("c1031356-42bc-4fc2-8f26-3e2c07ef047b"));
            ((ITTChildObjectCollection)_Paraphs).GetChildren();
        }

        protected Paraph.ChildParaphCollection _Paraphs = null;
        public Paraph.ChildParaphCollection Paraphs
        {
            get
            {
                if (_Paraphs == null)
                    CreateParaphsCollection();
                return _Paraphs;
            }
        }

        protected InternalCorrespondenceKIMK(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected InternalCorrespondenceKIMK(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected InternalCorrespondenceKIMK(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected InternalCorrespondenceKIMK(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected InternalCorrespondenceKIMK(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "INTERNALCORRESPONDENCEKIMK", dataRow) { }
        protected InternalCorrespondenceKIMK(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "INTERNALCORRESPONDENCEKIMK", dataRow, isImported) { }
        public InternalCorrespondenceKIMK(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public InternalCorrespondenceKIMK(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public InternalCorrespondenceKIMK() : base() { }

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