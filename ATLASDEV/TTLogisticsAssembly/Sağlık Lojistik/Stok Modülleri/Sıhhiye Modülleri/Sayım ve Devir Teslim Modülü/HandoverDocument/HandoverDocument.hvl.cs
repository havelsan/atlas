
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="HandoverDocument")] 

    /// <summary>
    /// Devir Teslim Belgesi
    /// </summary>
    public  partial class HandoverDocument : StockAction
    {
        public class HandoverDocumentList : TTObjectCollection<HandoverDocument> { }
                    
        public class ChildHandoverDocumentCollection : TTObject.TTChildObjectCollection<HandoverDocument>
        {
            public ChildHandoverDocumentCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildHandoverDocumentCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetHandoverDocumentReportQuery_Class : TTReportNqlObject 
        {
            public Guid? Orderdetailobjectid
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["ORDERDETAILOBJECTID"]);
                }
            }

            public string RegistrationNumber
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["REGISTRATIONNUMBER"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["HANDOVERDOCUMENT"].AllPropertyDefs["REGISTRATIONNUMBER"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string NATOStockNO
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["NATOSTOCKNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["STOCKCARD"].AllPropertyDefs["NATOSTOCKNO"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Cardname
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["CARDNAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["STOCKCARD"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public DateTime? TransactionDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["TRANSACTIONDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["HANDOVERDOCUMENT"].AllPropertyDefs["TRANSACTIONDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public Guid? StockCardClass
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["STOCKCARDCLASS"]);
                }
            }

            public string DistributionType
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DISTRIBUTIONTYPE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DISTRIBUTIONTYPEDEFINITION"].AllPropertyDefs["DISTRIBUTIONTYPE"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public Currency? Inheld
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["INHELD"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["HANDOVERDOCUMENTDETAIL"].AllPropertyDefs["INHELD"].DataType;
                    return (Currency?)dataType.ConvertValue(val);
                }
            }

            public Currency? CensusInheld
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["CENSUSINHELD"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["HANDOVERDOCUMENTDETAIL"].AllPropertyDefs["CENSUSINHELD"].DataType;
                    return (Currency?)dataType.ConvertValue(val);
                }
            }

            public Currency? Remnant
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["REMNANT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["HANDOVERDOCUMENTDETAIL"].AllPropertyDefs["REMNANT"].DataType;
                    return (Currency?)dataType.ConvertValue(val);
                }
            }

            public Currency? Absent
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ABSENT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["HANDOVERDOCUMENTDETAIL"].AllPropertyDefs["ABSENT"].DataType;
                    return (Currency?)dataType.ConvertValue(val);
                }
            }

            public GetHandoverDocumentReportQuery_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetHandoverDocumentReportQuery_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetHandoverDocumentReportQuery_Class() : base() { }
        }

        new public static class States
        {
    /// <summary>
    /// Onay
    /// </summary>
            public static Guid Approval { get { return new Guid("dd34d2fa-6c65-4bdd-8383-670ddaa987cd"); } }
    /// <summary>
    /// İptal Edildi
    /// </summary>
            public static Guid Cancelled { get { return new Guid("977532a8-d277-4738-a67a-45a4ebe01993"); } }
    /// <summary>
    /// Tamamlandı
    /// </summary>
            public static Guid Completed { get { return new Guid("94eac40f-89fb-419d-9018-0127eae67c1f"); } }
    /// <summary>
    /// Kayıt
    /// </summary>
            public static Guid New { get { return new Guid("e4108faa-3f02-4acb-8eb8-770901d6e97c"); } }
        }

        public static BindingList<HandoverDocument.GetHandoverDocumentReportQuery_Class> GetHandoverDocumentReportQuery(Guid TTOBJECTID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["HANDOVERDOCUMENT"].QueryDefs["GetHandoverDocumentReportQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("TTOBJECTID", TTOBJECTID);

            return TTReportNqlObject.QueryObjects<HandoverDocument.GetHandoverDocumentReportQuery_Class>(queryDef, paramList, pi);
        }

        public static BindingList<HandoverDocument.GetHandoverDocumentReportQuery_Class> GetHandoverDocumentReportQuery(TTObjectContext objectContext, Guid TTOBJECTID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["HANDOVERDOCUMENT"].QueryDefs["GetHandoverDocumentReportQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("TTOBJECTID", TTOBJECTID);

            return TTReportNqlObject.QueryObjects<HandoverDocument.GetHandoverDocumentReportQuery_Class>(objectContext, queryDef, paramList, pi);
        }

    /// <summary>
    /// Sayım Emri Tipi
    /// </summary>
        public CensusOrderTypeEnum? CensusOrderType
        {
            get { return (CensusOrderTypeEnum?)(int?)this["CENSUSORDERTYPE"]; }
            set { this["CENSUSORDERTYPE"] = value; }
        }

    /// <summary>
    /// Sayımın Yapıldığı Masa
    /// </summary>
        public ResCardDrawer CardDrawer
        {
            get { return (ResCardDrawer)((ITTObject)this).GetParent("CARDDRAWER"); }
            set { this["CARDDRAWER"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        virtual protected void CreateHandoverDocumentDetailsCollection()
        {
            _HandoverDocumentDetails = new HandoverDocumentDetail.ChildHandoverDocumentDetailCollection(this, new Guid("5088cdb6-b5a3-469f-92b6-fc484262bb54"));
            ((ITTChildObjectCollection)_HandoverDocumentDetails).GetChildren();
        }

        protected HandoverDocumentDetail.ChildHandoverDocumentDetailCollection _HandoverDocumentDetails = null;
        public HandoverDocumentDetail.ChildHandoverDocumentDetailCollection HandoverDocumentDetails
        {
            get
            {
                if (_HandoverDocumentDetails == null)
                    CreateHandoverDocumentDetailsCollection();
                return _HandoverDocumentDetails;
            }
        }

        protected HandoverDocument(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected HandoverDocument(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected HandoverDocument(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected HandoverDocument(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected HandoverDocument(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "HANDOVERDOCUMENT", dataRow) { }
        protected HandoverDocument(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "HANDOVERDOCUMENT", dataRow, isImported) { }
        public HandoverDocument(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public HandoverDocument(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public HandoverDocument() : base() { }

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