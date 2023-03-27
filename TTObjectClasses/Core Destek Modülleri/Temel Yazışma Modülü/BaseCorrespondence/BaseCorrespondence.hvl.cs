
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="BaseCorrespondence")] 

    /// <summary>
    /// Temel Yazışma
    /// </summary>
    public  partial class BaseCorrespondence : TTObject
    {
        public class BaseCorrespondenceList : TTObjectCollection<BaseCorrespondence> { }
                    
        public class ChildBaseCorrespondenceCollection : TTObject.TTChildObjectCollection<BaseCorrespondence>
        {
            public ChildBaseCorrespondenceCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildBaseCorrespondenceCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class NonMilitaryCorrespondenceNQL_Class : TTReportNqlObject 
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

            public string DocumentDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DOCUMENTDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["BASECORRESPONDENCE"].AllPropertyDefs["DOCUMENTDATE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["BASECORRESPONDENCE"].AllPropertyDefs["SUBJECT"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["BASECORRESPONDENCE"].AllPropertyDefs["CAPTION"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["BASECORRESPONDENCE"].AllPropertyDefs["REPORTTEXT"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["BASECORRESPONDENCE"].AllPropertyDefs["ADDITION"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["BASECORRESPONDENCE"].AllPropertyDefs["CLASSIFICATIONDEGREE"].DataType;
                    return (ClassificationDegreeForDocuments?)(int)dataType.ConvertValue(val);
                }
            }

            public string Reference
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["REFERENCE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["BASECORRESPONDENCE"].AllPropertyDefs["REFERENCE"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string NumberLiteral
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["NUMBERLITERAL"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["BASECORRESPONDENCE"].AllPropertyDefs["NUMBERLITERAL"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["BASECORRESPONDENCE"].AllPropertyDefs["NUMBER"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["BASECORRESPONDENCE"].AllPropertyDefs["RELATEDLIST"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public NonMilitaryCorrespondenceNQL_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public NonMilitaryCorrespondenceNQL_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected NonMilitaryCorrespondenceNQL_Class() : base() { }
        }

        public static class States
        {
            public static Guid Cancelled { get { return new Guid("5ffba9de-0379-4ab7-86b2-15f68a500156"); } }
            public static Guid New { get { return new Guid("b0ad9eb4-690b-407a-91ee-756a6335faae"); } }
        }

        public static BindingList<BaseCorrespondence.NonMilitaryCorrespondenceNQL_Class> NonMilitaryCorrespondenceNQL(string OBJECTID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["BASECORRESPONDENCE"].QueryDefs["NonMilitaryCorrespondenceNQL"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("OBJECTID", OBJECTID);

            return TTReportNqlObject.QueryObjects<BaseCorrespondence.NonMilitaryCorrespondenceNQL_Class>(queryDef, paramList, pi);
        }

        public static BindingList<BaseCorrespondence.NonMilitaryCorrespondenceNQL_Class> NonMilitaryCorrespondenceNQL(TTObjectContext objectContext, string OBJECTID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["BASECORRESPONDENCE"].QueryDefs["NonMilitaryCorrespondenceNQL"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("OBJECTID", OBJECTID);

            return TTReportNqlObject.QueryObjects<BaseCorrespondence.NonMilitaryCorrespondenceNQL_Class>(objectContext, queryDef, paramList, pi);
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
    /// Konu
    /// </summary>
        public string Subject
        {
            get { return (string)this["SUBJECT"]; }
            set { this["SUBJECT"] = value; }
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
    /// Rapor Metni
    /// </summary>
        public string ReportText
        {
            get { return (string)this["REPORTTEXT"]; }
            set { this["REPORTTEXT"] = value; }
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
    /// Gizlilik Derecesi
    /// </summary>
        public ClassificationDegreeForDocuments? ClassificationDegree
        {
            get { return (ClassificationDegreeForDocuments?)(int?)this["CLASSIFICATIONDEGREE"]; }
            set { this["CLASSIFICATIONDEGREE"] = value; }
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
    /// Sayı Adı
    /// </summary>
        public string NumberLiteral
        {
            get { return (string)this["NUMBERLITERAL"]; }
            set { this["NUMBERLITERAL"] = value; }
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
    /// Liste
    /// </summary>
        public string RelatedList
        {
            get { return (string)this["RELATEDLIST"]; }
            set { this["RELATEDLIST"] = value; }
        }

        public ResUser ReportSender
        {
            get { return (ResUser)((ITTObject)this).GetParent("REPORTSENDER"); }
            set { this["REPORTSENDER"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public PurchaseOrder PurchaseOrder
        {
            get { return (PurchaseOrder)((ITTObject)this).GetParent("PURCHASEORDER"); }
            set { this["PURCHASEORDER"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        virtual protected void CreateParaphsCollection()
        {
            _Paraphs = new Paraph.ChildParaphCollection(this, new Guid("9b02386e-820a-4147-b9bb-eb2e60d88d9e"));
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

        virtual protected void CreateInfosCollection()
        {
            _Infos = new Info.ChildInfoCollection(this, new Guid("457ea561-852e-40dd-ac16-d3205d0ab7fd"));
            ((ITTChildObjectCollection)_Infos).GetChildren();
        }

        protected Info.ChildInfoCollection _Infos = null;
        public Info.ChildInfoCollection Infos
        {
            get
            {
                if (_Infos == null)
                    CreateInfosCollection();
                return _Infos;
            }
        }

        virtual protected void CreateDistributionPlacesCollection()
        {
            _DistributionPlaces = new DistributionPlace.ChildDistributionPlaceCollection(this, new Guid("d005bd14-65a2-4de6-9ebe-ee540afbfe4a"));
            ((ITTChildObjectCollection)_DistributionPlaces).GetChildren();
        }

        protected DistributionPlace.ChildDistributionPlaceCollection _DistributionPlaces = null;
        public DistributionPlace.ChildDistributionPlaceCollection DistributionPlaces
        {
            get
            {
                if (_DistributionPlaces == null)
                    CreateDistributionPlacesCollection();
                return _DistributionPlaces;
            }
        }

        protected BaseCorrespondence(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected BaseCorrespondence(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected BaseCorrespondence(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected BaseCorrespondence(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected BaseCorrespondence(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "BASECORRESPONDENCE", dataRow) { }
        protected BaseCorrespondence(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "BASECORRESPONDENCE", dataRow, isImported) { }
        public BaseCorrespondence(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public BaseCorrespondence(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public BaseCorrespondence() : base() { }

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