
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="E2")] 

    /// <summary>
    /// E2 Belgesi
    /// </summary>
    public  partial class E2 : StockAction, IStockConsumptionTransaction, IAutoDocumentNumber
    {
        public class E2List : TTObjectCollection<E2> { }
                    
        public class ChildE2Collection : TTObject.TTChildObjectCollection<E2>
        {
            public ChildE2Collection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildE2Collection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetE2ReportQuery_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public DateTime? StartDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["STARTDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["E2"].AllPropertyDefs["STARTDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public DateTime? EndDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ENDDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["E2"].AllPropertyDefs["ENDDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public string RegistrationNumber
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["REGISTRATIONNUMBER"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["E2"].AllPropertyDefs["REGISTRATIONNUMBER"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string SequenceNumber
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["SEQUENCENUMBER"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["E2"].AllPropertyDefs["SEQUENCENUMBER"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public DateTime? FillingDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["FILLINGDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["E2"].AllPropertyDefs["FILLINGDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
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

            public string Material
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MATERIAL"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MATERIAL"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
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

            public Currency? Amount
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["AMOUNT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["E2MATERIAL"].AllPropertyDefs["AMOUNT"].DataType;
                    return (Currency?)dataType.ConvertValue(val);
                }
            }

            public GetE2ReportQuery_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetE2ReportQuery_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetE2ReportQuery_Class() : base() { }
        }

        new public static class States
        {
    /// <summary>
    /// Kayıt
    /// </summary>
            public static Guid Record { get { return new Guid("80c8bc64-be92-4f22-aff3-2f96f1fc64d9"); } }
    /// <summary>
    /// Baş Eczacı Onay
    /// </summary>
            public static Guid PharmacyApproval { get { return new Guid("137f97bd-ff86-4bc6-8ef2-ea56922428b2"); } }
    /// <summary>
    /// İptal Edildi
    /// </summary>
            public static Guid Cancelled { get { return new Guid("313b01c1-8190-4c15-9461-827fc5c7cb06"); } }
    /// <summary>
    /// Baş Hekim Onay
    /// </summary>
            public static Guid MedicalSuperintendentApproval { get { return new Guid("9d509e04-f62b-4ab8-bfa1-c6cf8854cb5c"); } }
    /// <summary>
    /// Saymanlık Onay
    /// </summary>
            public static Guid AccountancyApproval { get { return new Guid("12dbf31f-ad2d-471b-b216-4a57a3c59e46"); } }
    /// <summary>
    /// Tamamlandı
    /// </summary>
            public static Guid Completed { get { return new Guid("2280e7aa-b55f-4ea6-ba8b-dd7b2bb63614"); } }
        }

        public static BindingList<E2.GetE2ReportQuery_Class> GetE2ReportQuery(Guid TTOBJECTID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["E2"].QueryDefs["GetE2ReportQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("TTOBJECTID", TTOBJECTID);

            return TTReportNqlObject.QueryObjects<E2.GetE2ReportQuery_Class>(queryDef, paramList, pi);
        }

        public static BindingList<E2.GetE2ReportQuery_Class> GetE2ReportQuery(TTObjectContext objectContext, Guid TTOBJECTID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["E2"].QueryDefs["GetE2ReportQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("TTOBJECTID", TTOBJECTID);

            return TTReportNqlObject.QueryObjects<E2.GetE2ReportQuery_Class>(objectContext, queryDef, paramList, pi);
        }

    /// <summary>
    /// Doldurma Tarihi
    /// </summary>
        public DateTime? FillingDate
        {
            get { return (DateTime?)this["FILLINGDATE"]; }
            set { this["FILLINGDATE"] = value; }
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

        protected E2(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected E2(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected E2(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected E2(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected E2(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "E2", dataRow) { }
        protected E2(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "E2", dataRow, isImported) { }
        public E2(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public E2(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public E2() : base() { }

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