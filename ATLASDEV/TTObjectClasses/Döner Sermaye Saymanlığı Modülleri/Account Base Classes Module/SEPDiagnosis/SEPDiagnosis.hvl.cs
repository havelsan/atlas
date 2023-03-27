
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="SEPDiagnosis")] 

    /// <summary>
    /// SEP Tanıları
    /// </summary>
    public  partial class SEPDiagnosis : TTObject
    {
        public class SEPDiagnosisList : TTObjectCollection<SEPDiagnosis> { }
                    
        public class ChildSEPDiagnosisCollection : TTObject.TTChildObjectCollection<SEPDiagnosis>
        {
            public ChildSEPDiagnosisCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildSEPDiagnosisCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetBySubEpisodeProtocolAndState_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public GetBySubEpisodeProtocolAndState_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetBySubEpisodeProtocolAndState_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetBySubEpisodeProtocolAndState_Class() : base() { }
        }

        [Serializable] 

        public partial class GetBySubEpisodeProtocol_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public long? Id
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ID"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SEPDIAGNOSIS"].AllPropertyDefs["ID"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public Guid? Diagnose
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["DIAGNOSE"]);
                }
            }

            public string Diagnosecode
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DIAGNOSECODE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DIAGNOSISDEFINITION"].AllPropertyDefs["CODE"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Diagnosename
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DIAGNOSENAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DIAGNOSISDEFINITION"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public Object Diagnosistype
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["DIAGNOSISTYPE"]);
                }
            }

            public bool? IsMainDiagnose
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ISMAINDIAGNOSE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SEPDIAGNOSIS"].AllPropertyDefs["ISMAINDIAGNOSE"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public string MedulaProcessNo
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MEDULAPROCESSNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SEPDIAGNOSIS"].AllPropertyDefs["MEDULAPROCESSNO"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public Guid? CurrentStateDefID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["CURRENTSTATEDEFID"]);
                }
            }

            public Object Statename
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["STATENAME"]);
                }
            }

            public Object Statetext
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["STATETEXT"]);
                }
            }

            public string MedulaResultCode
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MEDULARESULTCODE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SEPDIAGNOSIS"].AllPropertyDefs["MEDULARESULTCODE"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string MedulaResultMessage
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MEDULARESULTMESSAGE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SEPDIAGNOSIS"].AllPropertyDefs["MEDULARESULTMESSAGE"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public Guid? OzelDurum
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OZELDURUM"]);
                }
            }

            public GetBySubEpisodeProtocol_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetBySubEpisodeProtocol_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetBySubEpisodeProtocol_Class() : base() { }
        }

        public static class States
        {
    /// <summary>
    /// Sunucuya Gönderildi
    /// </summary>
            public static Guid MedulaSentServer { get { return new Guid("2519c160-5ae7-44ce-a827-c1b800120102"); } }
    /// <summary>
    /// Tanı Kaydı Başarılı
    /// </summary>
            public static Guid MedulaEntrySuccessful { get { return new Guid("649984ea-00a9-499b-bb47-df2035e09c48"); } }
    /// <summary>
    /// Tanı Kaydı Başarısız
    /// </summary>
            public static Guid MedulaEntryUnsuccessful { get { return new Guid("dfb81e9d-8ea8-42e5-afe4-be176e31f3cd"); } }
    /// <summary>
    /// Yeni
    /// </summary>
            public static Guid New { get { return new Guid("232d2033-4f71-485e-9296-3fd1d8c1864a"); } }
    /// <summary>
    /// Medulaya Gönderilmeyecek
    /// </summary>
            public static Guid MedulaDontSend { get { return new Guid("d63cab51-471d-4a91-8c43-cef7c79d1262"); } }
        }

        public static BindingList<SEPDiagnosis.GetBySubEpisodeProtocolAndState_Class> GetBySubEpisodeProtocolAndState(Guid SEP, IList<Guid> STATES, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["SEPDIAGNOSIS"].QueryDefs["GetBySubEpisodeProtocolAndState"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("SEP", SEP);
            paramList.Add("STATES", STATES);

            return TTReportNqlObject.QueryObjects<SEPDiagnosis.GetBySubEpisodeProtocolAndState_Class>(queryDef, paramList, pi);
        }

        public static BindingList<SEPDiagnosis.GetBySubEpisodeProtocolAndState_Class> GetBySubEpisodeProtocolAndState(TTObjectContext objectContext, Guid SEP, IList<Guid> STATES, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["SEPDIAGNOSIS"].QueryDefs["GetBySubEpisodeProtocolAndState"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("SEP", SEP);
            paramList.Add("STATES", STATES);

            return TTReportNqlObject.QueryObjects<SEPDiagnosis.GetBySubEpisodeProtocolAndState_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<SEPDiagnosis> GetBySEPAndState(TTObjectContext objectContext, Guid SEP, IList<Guid> STATES)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["SEPDIAGNOSIS"].QueryDefs["GetBySEPAndState"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("SEP", SEP);
            paramList.Add("STATES", STATES);

            return ((ITTQuery)objectContext).QueryObjects<SEPDiagnosis>(queryDef, paramList);
        }

        public static BindingList<SEPDiagnosis.GetBySubEpisodeProtocol_Class> GetBySubEpisodeProtocol(Guid SEP, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["SEPDIAGNOSIS"].QueryDefs["GetBySubEpisodeProtocol"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("SEP", SEP);

            return TTReportNqlObject.QueryObjects<SEPDiagnosis.GetBySubEpisodeProtocol_Class>(queryDef, paramList, pi);
        }

        public static BindingList<SEPDiagnosis.GetBySubEpisodeProtocol_Class> GetBySubEpisodeProtocol(TTObjectContext objectContext, Guid SEP, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["SEPDIAGNOSIS"].QueryDefs["GetBySubEpisodeProtocol"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("SEP", SEP);

            return TTReportNqlObject.QueryObjects<SEPDiagnosis.GetBySubEpisodeProtocol_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<SEPDiagnosis> GetByProvisionNoAndState(TTObjectContext objectContext, string PROVISIONNO, IList<Guid> STATES)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["SEPDIAGNOSIS"].QueryDefs["GetByProvisionNoAndState"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("PROVISIONNO", PROVISIONNO);
            paramList.Add("STATES", STATES);

            return ((ITTQuery)objectContext).QueryObjects<SEPDiagnosis>(queryDef, paramList);
        }

        public static BindingList<SEPDiagnosis> GetBySEP(TTObjectContext objectContext, Guid SEP)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["SEPDIAGNOSIS"].QueryDefs["GetBySEP"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("SEP", SEP);

            return ((ITTQuery)objectContext).QueryObjects<SEPDiagnosis>(queryDef, paramList);
        }

    /// <summary>
    /// Id
    /// </summary>
        public TTSequence Id
        {
            get { return GetSequence("ID"); }
        }

    /// <summary>
    /// Medula İşlem Sıra Numarası
    /// </summary>
        public string MedulaProcessNo
        {
            get { return (string)this["MEDULAPROCESSNO"]; }
            set { this["MEDULAPROCESSNO"] = value; }
        }

    /// <summary>
    /// Ana Tanı
    /// </summary>
        public bool? IsMainDiagnose
        {
            get { return (bool?)this["ISMAINDIAGNOSE"]; }
            set { this["ISMAINDIAGNOSE"] = value; }
        }

    /// <summary>
    /// Tanı Tipi
    /// </summary>
        public DiagnosisTypeEnum? DiagnosisType
        {
            get { return (DiagnosisTypeEnum?)(int?)this["DIAGNOSISTYPE"]; }
            set { this["DIAGNOSISTYPE"] = value; }
        }

    /// <summary>
    /// Medula Sonuç Kodu
    /// </summary>
        public string MedulaResultCode
        {
            get { return (string)this["MEDULARESULTCODE"]; }
            set { this["MEDULARESULTCODE"] = value; }
        }

    /// <summary>
    /// Medula Sonuç Mesajı
    /// </summary>
        public string MedulaResultMessage
        {
            get { return (string)this["MEDULARESULTMESSAGE"]; }
            set { this["MEDULARESULTMESSAGE"] = value; }
        }

    /// <summary>
    /// Tanı
    /// </summary>
        public DiagnosisDefinition Diagnose
        {
            get { return (DiagnosisDefinition)((ITTObject)this).GetParent("DIAGNOSE"); }
            set { this["DIAGNOSE"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Tanı Gridi
    /// </summary>
        public DiagnosisGrid DiagnosisGrid
        {
            get { return (DiagnosisGrid)((ITTObject)this).GetParent("DIAGNOSISGRID"); }
            set { this["DIAGNOSISGRID"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// SEP
    /// </summary>
        public SubEpisodeProtocol SubEpisodeProtocol
        {
            get { return (SubEpisodeProtocol)((ITTObject)this).GetParent("SUBEPISODEPROTOCOL"); }
            set { this["SUBEPISODEPROTOCOL"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// OzelDurum
    /// </summary>
        public OzelDurum OzelDurum
        {
            get { return (OzelDurum)((ITTObject)this).GetParent("OZELDURUM"); }
            set { this["OZELDURUM"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public DiagnosisSubEpisode DiagnosisSubEpisode
        {
            get { return (DiagnosisSubEpisode)((ITTObject)this).GetParent("DIAGNOSISSUBEPISODE"); }
            set { this["DIAGNOSISSUBEPISODE"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        virtual protected void CreateCokluOzelDurumCollection()
        {
            _CokluOzelDurum = new CokluOzelDurum.ChildCokluOzelDurumCollection(this, new Guid("f24e77b2-f657-4051-a6ad-bb317200d4bb"));
            ((ITTChildObjectCollection)_CokluOzelDurum).GetChildren();
        }

        protected CokluOzelDurum.ChildCokluOzelDurumCollection _CokluOzelDurum = null;
    /// <summary>
    /// Child collection for Çoklu Özel Durum
    /// </summary>
        public CokluOzelDurum.ChildCokluOzelDurumCollection CokluOzelDurum
        {
            get
            {
                if (_CokluOzelDurum == null)
                    CreateCokluOzelDurumCollection();
                return _CokluOzelDurum;
            }
        }

        virtual protected void CreateInvoiceLogsCollection()
        {
            _InvoiceLogs = new InvoiceLog.ChildInvoiceLogCollection(this, new Guid("f8b23903-e75e-4051-ba70-fc1e5986d6c7"));
            ((ITTChildObjectCollection)_InvoiceLogs).GetChildren();
        }

        protected InvoiceLog.ChildInvoiceLogCollection _InvoiceLogs = null;
        public InvoiceLog.ChildInvoiceLogCollection InvoiceLogs
        {
            get
            {
                if (_InvoiceLogs == null)
                    CreateInvoiceLogsCollection();
                return _InvoiceLogs;
            }
        }

        protected SEPDiagnosis(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected SEPDiagnosis(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected SEPDiagnosis(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected SEPDiagnosis(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected SEPDiagnosis(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "SEPDIAGNOSIS", dataRow) { }
        protected SEPDiagnosis(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "SEPDIAGNOSIS", dataRow, isImported) { }
        public SEPDiagnosis(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public SEPDiagnosis(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public SEPDiagnosis() : base() { }

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