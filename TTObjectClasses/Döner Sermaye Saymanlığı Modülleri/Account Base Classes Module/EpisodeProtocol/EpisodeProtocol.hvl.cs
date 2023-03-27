
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="EpisodeProtocol")] 

    /// <summary>
    /// Hasta epizotu ile anlaşmaların eşleşme bilgisini tutan sınıf
    /// </summary>
    public  partial class EpisodeProtocol : TTObject
    {
        public class EpisodeProtocolList : TTObjectCollection<EpisodeProtocol> { }
                    
        public class ChildEpisodeProtocolCollection : TTObject.TTChildObjectCollection<EpisodeProtocol>
        {
            public ChildEpisodeProtocolCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildEpisodeProtocolCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetEpisodeProtocols_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public long? Payercode
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PAYERCODE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PAYERDEFINITION"].AllPropertyDefs["CODE"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public string Payername
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PAYERNAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PAYERDEFINITION"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Payercity
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PAYERCITY"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["CITY"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Protocolname
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PROTOCOLNAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PROTOCOLDEFINITION"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public GetEpisodeProtocols_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetEpisodeProtocols_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetEpisodeProtocols_Class() : base() { }
        }

        public static class States
        {
    /// <summary>
    /// AÇIK
    /// </summary>
            public static Guid OPEN { get { return new Guid("b07159ee-f349-4b0b-8e7e-7571db6ce05e"); } }
    /// <summary>
    /// Toplu faturaya hazir
    /// </summary>
            public static Guid READY { get { return new Guid("fe55de8d-8fe0-4932-920d-4ee8946c1c12"); } }
    /// <summary>
    /// KAPALI
    /// </summary>
            public static Guid CLOSED { get { return new Guid("7c5d362d-aaf5-46f9-b0f4-92eeacff412f"); } }
        }

        public static BindingList<EpisodeProtocol.GetEpisodeProtocols_Class> GetEpisodeProtocols(string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["EPISODEPROTOCOL"].QueryDefs["GetEpisodeProtocols"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<EpisodeProtocol.GetEpisodeProtocols_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<EpisodeProtocol.GetEpisodeProtocols_Class> GetEpisodeProtocols(TTObjectContext objectContext, string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["EPISODEPROTOCOL"].QueryDefs["GetEpisodeProtocols"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<EpisodeProtocol.GetEpisodeProtocols_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

    /// <summary>
    /// Numara
    /// </summary>
        public TTSequence ID
        {
            get { return GetSequence("ID"); }
        }

    /// <summary>
    /// Toplu faturalama grubu (Muayene, muayene+tetkik)
    /// </summary>
        public CollectedInvoiceProcedureGroupEnum? InvoiceGroup
        {
            get { return (CollectedInvoiceProcedureGroupEnum?)(int?)this["INVOICEGROUP"]; }
            set { this["INVOICEGROUP"] = value; }
        }

    /// <summary>
    /// Ödeme kontrolüne takılıp takılmayacağı
    /// </summary>
        public bool? CheckPaid
        {
            get { return (bool?)this["CHECKPAID"]; }
            set { this["CHECKPAID"] = value; }
        }

    /// <summary>
    /// Sevk süresi
    /// </summary>
        public int? DayLimit
        {
            get { return (int?)this["DAYLIMIT"]; }
            set { this["DAYLIMIT"] = value; }
        }

    /// <summary>
    /// Açılış Tarihi
    /// </summary>
        public DateTime? OpeningDate
        {
            get { return (DateTime?)this["OPENINGDATE"]; }
            set { this["OPENINGDATE"] = value; }
        }

    /// <summary>
    /// Anlaşma tanımı ile ilişki
    /// </summary>
        public ProtocolDefinition Protocol
        {
            get { return (ProtocolDefinition)((ITTObject)this).GetParent("PROTOCOL"); }
            set { this["PROTOCOL"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Kurum Faturası işlemine ilişki
    /// </summary>
        public PayerInvoice PayerInvoice
        {
            get { return (PayerInvoice)((ITTObject)this).GetParent("PAYERINVOICE"); }
            set { this["PAYERINVOICE"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Kurum ile ilişki
    /// </summary>
        public PayerDefinition Payer
        {
            get { return (PayerDefinition)((ITTObject)this).GetParent("PAYER"); }
            set { this["PAYER"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        virtual protected void CreateTransferFromPackSubActPacsCollection()
        {
            _TransferFromPackSubActPacs = new TransferFromPackSubActPacs.ChildTransferFromPackSubActPacsCollection(this, new Guid("d7221073-f97f-4883-b666-ef69b19471a8"));
            ((ITTChildObjectCollection)_TransferFromPackSubActPacs).GetChildren();
        }

        protected TransferFromPackSubActPacs.ChildTransferFromPackSubActPacsCollection _TransferFromPackSubActPacs = null;
    /// <summary>
    /// Child collection for Anlaşma ile ilişki
    /// </summary>
        public TransferFromPackSubActPacs.ChildTransferFromPackSubActPacsCollection TransferFromPackSubActPacs
        {
            get
            {
                if (_TransferFromPackSubActPacs == null)
                    CreateTransferFromPackSubActPacsCollection();
                return _TransferFromPackSubActPacs;
            }
        }

        virtual protected void CreatePackageTransferProtocolDetailCollection()
        {
            _PackageTransferProtocolDetail = new PackageTransferProtocolDetail.ChildPackageTransferProtocolDetailCollection(this, new Guid("b4edb787-fa52-4000-8d8e-8f73ab5714e5"));
            ((ITTChildObjectCollection)_PackageTransferProtocolDetail).GetChildren();
        }

        protected PackageTransferProtocolDetail.ChildPackageTransferProtocolDetailCollection _PackageTransferProtocolDetail = null;
    /// <summary>
    /// Child collection for Anlaşma ile ilişki
    /// </summary>
        public PackageTransferProtocolDetail.ChildPackageTransferProtocolDetailCollection PackageTransferProtocolDetail
        {
            get
            {
                if (_PackageTransferProtocolDetail == null)
                    CreatePackageTransferProtocolDetailCollection();
                return _PackageTransferProtocolDetail;
            }
        }

        virtual protected void CreateAccountingProcessCollection()
        {
            _AccountingProcess = new AccountingProcess.ChildAccountingProcessCollection(this, new Guid("e31465e8-f344-4d83-8c4e-e8b7ddedd452"));
            ((ITTChildObjectCollection)_AccountingProcess).GetChildren();
        }

        protected AccountingProcess.ChildAccountingProcessCollection _AccountingProcess = null;
        public AccountingProcess.ChildAccountingProcessCollection AccountingProcess
        {
            get
            {
                if (_AccountingProcess == null)
                    CreateAccountingProcessCollection();
                return _AccountingProcess;
            }
        }

        protected EpisodeProtocol(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected EpisodeProtocol(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected EpisodeProtocol(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected EpisodeProtocol(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected EpisodeProtocol(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "EPISODEPROTOCOL", dataRow) { }
        protected EpisodeProtocol(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "EPISODEPROTOCOL", dataRow, isImported) { }
        public EpisodeProtocol(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public EpisodeProtocol(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public EpisodeProtocol() : base() { }

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