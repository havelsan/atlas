
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="PatientOwnDrugTrx")] 

    public  partial class PatientOwnDrugTrx : TTObject
    {
        public class PatientOwnDrugTrxList : TTObjectCollection<PatientOwnDrugTrx> { }
                    
        public class ChildPatientOwnDrugTrxCollection : TTObject.TTChildObjectCollection<PatientOwnDrugTrx>
        {
            public ChildPatientOwnDrugTrxCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildPatientOwnDrugTrxCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetRestPatientOwnDrugByMaterialAndEpisode_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public DateTime? ExpirationDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["EXPIRATIONDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENTOWNDRUGTRX"].AllPropertyDefs["EXPIRATIONDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public Object Restamount
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["RESTAMOUNT"]);
                }
            }

            public GetRestPatientOwnDrugByMaterialAndEpisode_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetRestPatientOwnDrugByMaterialAndEpisode_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetRestPatientOwnDrugByMaterialAndEpisode_Class() : base() { }
        }

        [Serializable] 

        public partial class GetRestPatientOwnDrug_Class : TTReportNqlObject 
        {
            public Guid? Material
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["MATERIAL"]);
                }
            }

            public Object Restamount
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["RESTAMOUNT"]);
                }
            }

            public GetRestPatientOwnDrug_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetRestPatientOwnDrug_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetRestPatientOwnDrug_Class() : base() { }
        }

        [Serializable] 

        public partial class GetRestOwnDrugTrx_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public Guid? Material
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["MATERIAL"]);
                }
            }

            public Object Restamount
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["RESTAMOUNT"]);
                }
            }

            public GetRestOwnDrugTrx_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetRestOwnDrugTrx_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetRestOwnDrugTrx_Class() : base() { }
        }

        [Serializable] 

        public partial class GetPatientOwnDrugDetailBySubEpisode_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public string Name
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["NAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MATERIAL"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Barcode
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["BARCODE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MATERIAL"].AllPropertyDefs["BARCODE"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public Object Restamount
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["RESTAMOUNT"]);
                }
            }

            public DateTime? ExpirationDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["EXPIRATIONDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENTOWNDRUGTRX"].AllPropertyDefs["EXPIRATIONDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public double? Amount
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["AMOUNT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENTOWNDRUGTRX"].AllPropertyDefs["AMOUNT"].DataType;
                    return (double?)dataType.ConvertValue(val);
                }
            }

            public GetPatientOwnDrugDetailBySubEpisode_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetPatientOwnDrugDetailBySubEpisode_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetPatientOwnDrugDetailBySubEpisode_Class() : base() { }
        }

        public static BindingList<PatientOwnDrugTrx.GetRestPatientOwnDrugByMaterialAndEpisode_Class> GetRestPatientOwnDrugByMaterialAndEpisode(Guid EPISODEID, Guid MATERIALID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PATIENTOWNDRUGTRX"].QueryDefs["GetRestPatientOwnDrugByMaterialAndEpisode"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("EPISODEID", EPISODEID);
            paramList.Add("MATERIALID", MATERIALID);

            return TTReportNqlObject.QueryObjects<PatientOwnDrugTrx.GetRestPatientOwnDrugByMaterialAndEpisode_Class>(queryDef, paramList, pi);
        }

        public static BindingList<PatientOwnDrugTrx.GetRestPatientOwnDrugByMaterialAndEpisode_Class> GetRestPatientOwnDrugByMaterialAndEpisode(TTObjectContext objectContext, Guid EPISODEID, Guid MATERIALID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PATIENTOWNDRUGTRX"].QueryDefs["GetRestPatientOwnDrugByMaterialAndEpisode"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("EPISODEID", EPISODEID);
            paramList.Add("MATERIALID", MATERIALID);

            return TTReportNqlObject.QueryObjects<PatientOwnDrugTrx.GetRestPatientOwnDrugByMaterialAndEpisode_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<PatientOwnDrugTrx.GetRestPatientOwnDrug_Class> GetRestPatientOwnDrug(Guid EPISODEID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PATIENTOWNDRUGTRX"].QueryDefs["GetRestPatientOwnDrug"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("EPISODEID", EPISODEID);

            return TTReportNqlObject.QueryObjects<PatientOwnDrugTrx.GetRestPatientOwnDrug_Class>(queryDef, paramList, pi);
        }

        public static BindingList<PatientOwnDrugTrx.GetRestPatientOwnDrug_Class> GetRestPatientOwnDrug(TTObjectContext objectContext, Guid EPISODEID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PATIENTOWNDRUGTRX"].QueryDefs["GetRestPatientOwnDrug"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("EPISODEID", EPISODEID);

            return TTReportNqlObject.QueryObjects<PatientOwnDrugTrx.GetRestPatientOwnDrug_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<PatientOwnDrugTrx.GetRestOwnDrugTrx_Class> GetRestOwnDrugTrx(Guid EPISODEID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PATIENTOWNDRUGTRX"].QueryDefs["GetRestOwnDrugTrx"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("EPISODEID", EPISODEID);

            return TTReportNqlObject.QueryObjects<PatientOwnDrugTrx.GetRestOwnDrugTrx_Class>(queryDef, paramList, pi);
        }

        public static BindingList<PatientOwnDrugTrx.GetRestOwnDrugTrx_Class> GetRestOwnDrugTrx(TTObjectContext objectContext, Guid EPISODEID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PATIENTOWNDRUGTRX"].QueryDefs["GetRestOwnDrugTrx"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("EPISODEID", EPISODEID);

            return TTReportNqlObject.QueryObjects<PatientOwnDrugTrx.GetRestOwnDrugTrx_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<PatientOwnDrugTrx.GetPatientOwnDrugDetailBySubEpisode_Class> GetPatientOwnDrugDetailBySubEpisode(Guid SUBEPISODEID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PATIENTOWNDRUGTRX"].QueryDefs["GetPatientOwnDrugDetailBySubEpisode"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("SUBEPISODEID", SUBEPISODEID);

            return TTReportNqlObject.QueryObjects<PatientOwnDrugTrx.GetPatientOwnDrugDetailBySubEpisode_Class>(queryDef, paramList, pi);
        }

        public static BindingList<PatientOwnDrugTrx.GetPatientOwnDrugDetailBySubEpisode_Class> GetPatientOwnDrugDetailBySubEpisode(TTObjectContext objectContext, Guid SUBEPISODEID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PATIENTOWNDRUGTRX"].QueryDefs["GetPatientOwnDrugDetailBySubEpisode"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("SUBEPISODEID", SUBEPISODEID);

            return TTReportNqlObject.QueryObjects<PatientOwnDrugTrx.GetPatientOwnDrugDetailBySubEpisode_Class>(objectContext, queryDef, paramList, pi);
        }

    /// <summary>
    /// Son Kullanma Tarihi
    /// </summary>
        public DateTime? ExpirationDate
        {
            get { return (DateTime?)this["EXPIRATIONDATE"]; }
            set { this["EXPIRATIONDATE"] = value; }
        }

        public double? Amount
        {
            get { return (double?)this["AMOUNT"]; }
            set { this["AMOUNT"] = value; }
        }

        public PatientOwnDrugEntryDetail PatientOwnDrugEntryDetail
        {
            get { return (PatientOwnDrugEntryDetail)((ITTObject)this).GetParent("PATIENTOWNDRUGENTRYDETAIL"); }
            set { this["PATIENTOWNDRUGENTRYDETAIL"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        virtual protected void CreatePatientOwnDrugTrxDetailsCollection()
        {
            _PatientOwnDrugTrxDetails = new PatientOwnDrugTrxDetail.ChildPatientOwnDrugTrxDetailCollection(this, new Guid("d0ba235d-a2ee-4b57-8ba9-24c3e5ab0352"));
            ((ITTChildObjectCollection)_PatientOwnDrugTrxDetails).GetChildren();
        }

        protected PatientOwnDrugTrxDetail.ChildPatientOwnDrugTrxDetailCollection _PatientOwnDrugTrxDetails = null;
        public PatientOwnDrugTrxDetail.ChildPatientOwnDrugTrxDetailCollection PatientOwnDrugTrxDetails
        {
            get
            {
                if (_PatientOwnDrugTrxDetails == null)
                    CreatePatientOwnDrugTrxDetailsCollection();
                return _PatientOwnDrugTrxDetails;
            }
        }

        protected PatientOwnDrugTrx(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected PatientOwnDrugTrx(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected PatientOwnDrugTrx(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected PatientOwnDrugTrx(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected PatientOwnDrugTrx(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "PATIENTOWNDRUGTRX", dataRow) { }
        protected PatientOwnDrugTrx(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "PATIENTOWNDRUGTRX", dataRow, isImported) { }
        public PatientOwnDrugTrx(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public PatientOwnDrugTrx(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public PatientOwnDrugTrx() : base() { }

    }
}