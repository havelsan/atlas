
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="ResPoliclinic")] 

    /// <summary>
    /// Poliklinik
    /// </summary>
    public  partial class ResPoliclinic : ResSection
    {
        public class ResPoliclinicList : TTObjectCollection<ResPoliclinic> { }
                    
        public class ChildResPoliclinicCollection : TTObject.TTChildObjectCollection<ResPoliclinic>
        {
            public ChildResPoliclinicCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildResPoliclinicCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class OLAP_GetResPoliclinicCount_Class : TTReportNqlObject 
        {
            public Object Nqlcolumn
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["NQLCOLUMN"]);
                }
            }

            public OLAP_GetResPoliclinicCount_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public OLAP_GetResPoliclinicCount_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected OLAP_GetResPoliclinicCount_Class() : base() { }
        }

        [Serializable] 

        public partial class GetPoliclinicDefinition_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public string Qref
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["QREF"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESPOLICLINIC"].AllPropertyDefs["QREF"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Name
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["NAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESPOLICLINIC"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Departmentname
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DEPARTMENTNAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESDEPARTMENT"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public GetPoliclinicDefinition_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetPoliclinicDefinition_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetPoliclinicDefinition_Class() : base() { }
        }

        [Serializable] 

        public partial class GetPoliclinicListDefinition_Class : TTReportNqlObject 
        {
            public string Name
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["NAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESPOLICLINIC"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public Guid? Department
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["DEPARTMENT"]);
                }
            }

            public GetPoliclinicListDefinition_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetPoliclinicListDefinition_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetPoliclinicListDefinition_Class() : base() { }
        }

        [Serializable] 

        public partial class GetMHRSPoliclinicDefinition_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public string Qref
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["QREF"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESPOLICLINIC"].AllPropertyDefs["QREF"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Name
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["NAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESPOLICLINIC"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Departmentname
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DEPARTMENTNAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESDEPARTMENT"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public GetMHRSPoliclinicDefinition_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetMHRSPoliclinicDefinition_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetMHRSPoliclinicDefinition_Class() : base() { }
        }

        public static BindingList<ResPoliclinic.OLAP_GetResPoliclinicCount_Class> OLAP_GetResPoliclinicCount(PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["RESPOLICLINIC"].QueryDefs["OLAP_GetResPoliclinicCount"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<ResPoliclinic.OLAP_GetResPoliclinicCount_Class>(queryDef, paramList, pi);
        }

        public static BindingList<ResPoliclinic.OLAP_GetResPoliclinicCount_Class> OLAP_GetResPoliclinicCount(TTObjectContext objectContext, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["RESPOLICLINIC"].QueryDefs["OLAP_GetResPoliclinicCount"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<ResPoliclinic.OLAP_GetResPoliclinicCount_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<ResPoliclinic> GetByRelation(TTObjectContext objectContext, string RELATIONPARENTNAME, string PARENTOBJECTID)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["RESPOLICLINIC"].QueryDefs["GetByRelation"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("RELATIONPARENTNAME", RELATIONPARENTNAME);
            paramList.Add("PARENTOBJECTID", PARENTOBJECTID);

            return ((ITTQuery)objectContext).QueryObjects<ResPoliclinic>(queryDef, paramList);
        }

        public static BindingList<ResPoliclinic.GetPoliclinicDefinition_Class> GetPoliclinicDefinition(string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["RESPOLICLINIC"].QueryDefs["GetPoliclinicDefinition"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<ResPoliclinic.GetPoliclinicDefinition_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<ResPoliclinic.GetPoliclinicDefinition_Class> GetPoliclinicDefinition(TTObjectContext objectContext, string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["RESPOLICLINIC"].QueryDefs["GetPoliclinicDefinition"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<ResPoliclinic.GetPoliclinicDefinition_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<ResPoliclinic.GetPoliclinicListDefinition_Class> GetPoliclinicListDefinition(string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["RESPOLICLINIC"].QueryDefs["GetPoliclinicListDefinition"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<ResPoliclinic.GetPoliclinicListDefinition_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<ResPoliclinic.GetPoliclinicListDefinition_Class> GetPoliclinicListDefinition(TTObjectContext objectContext, string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["RESPOLICLINIC"].QueryDefs["GetPoliclinicListDefinition"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<ResPoliclinic.GetPoliclinicListDefinition_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<ResPoliclinic> GetPoliclinicByMHRSCode(TTObjectContext objectContext, int MHRSCODE)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["RESPOLICLINIC"].QueryDefs["GetPoliclinicByMHRSCode"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("MHRSCODE", MHRSCODE);

            return ((ITTQuery)objectContext).QueryObjects<ResPoliclinic>(queryDef, paramList);
        }

        public static BindingList<ResPoliclinic> GetPoliclinicByMedulaBrans(TTObjectContext objectContext, string BRANS)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["RESPOLICLINIC"].QueryDefs["GetPoliclinicByMedulaBrans"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("BRANS", BRANS);

            return ((ITTQuery)objectContext).QueryObjects<ResPoliclinic>(queryDef, paramList);
        }

        public static BindingList<ResPoliclinic> GetDentalPoliclinic(TTObjectContext objectContext)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["RESPOLICLINIC"].QueryDefs["GetDentalPoliclinic"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return ((ITTQuery)objectContext).QueryObjects<ResPoliclinic>(queryDef, paramList);
        }

        public static BindingList<ResPoliclinic> GetPoliclinicByAsalCode(TTObjectContext objectContext, int ASALCODE)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["RESPOLICLINIC"].QueryDefs["GetPoliclinicByAsalCode"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("ASALCODE", ASALCODE);

            return ((ITTQuery)objectContext).QueryObjects<ResPoliclinic>(queryDef, paramList);
        }

        public static BindingList<ResPoliclinic> GetByMHRSKlinikVeAltKlinikKodu(TTObjectContext objectContext, int MHRSKLINIKKODU, int MHRSALTKLINIKKODU)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["RESPOLICLINIC"].QueryDefs["GetByMHRSKlinikVeAltKlinikKodu"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("MHRSKLINIKKODU", MHRSKLINIKKODU);
            paramList.Add("MHRSALTKLINIKKODU", MHRSALTKLINIKKODU);

            return ((ITTQuery)objectContext).QueryObjects<ResPoliclinic>(queryDef, paramList);
        }

        public static BindingList<ResPoliclinic> GetMHRSPoliclinics(TTObjectContext objectContext)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["RESPOLICLINIC"].QueryDefs["GetMHRSPoliclinics"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return ((ITTQuery)objectContext).QueryObjects<ResPoliclinic>(queryDef, paramList);
        }

        public static BindingList<ResPoliclinic.GetMHRSPoliclinicDefinition_Class> GetMHRSPoliclinicDefinition(string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["RESPOLICLINIC"].QueryDefs["GetMHRSPoliclinicDefinition"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<ResPoliclinic.GetMHRSPoliclinicDefinition_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<ResPoliclinic.GetMHRSPoliclinicDefinition_Class> GetMHRSPoliclinicDefinition(TTObjectContext objectContext, string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["RESPOLICLINIC"].QueryDefs["GetMHRSPoliclinicDefinition"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<ResPoliclinic.GetMHRSPoliclinicDefinition_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<ResPoliclinic> GetHCPoliclinic(TTObjectContext objectContext)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["RESPOLICLINIC"].QueryDefs["GetHCPoliclinic"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return ((ITTQuery)objectContext).QueryObjects<ResPoliclinic>(queryDef, paramList);
        }

        public static BindingList<ResPoliclinic> GetAllPoliclinics(TTObjectContext objectContext)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["RESPOLICLINIC"].QueryDefs["GetAllPoliclinics"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return ((ITTQuery)objectContext).QueryObjects<ResPoliclinic>(queryDef, paramList);
        }

        public static BindingList<ResPoliclinic> GetAllActivePoliclinic(TTObjectContext objectContext)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["RESPOLICLINIC"].QueryDefs["GetAllActivePoliclinic"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return ((ITTQuery)objectContext).QueryObjects<ResPoliclinic>(queryDef, paramList);
        }

    /// <summary>
    /// ASAL Kodu
    /// </summary>
        public int? ASALCode
        {
            get { return (int?)this["ASALCODE"]; }
            set { this["ASALCODE"] = value; }
        }

    /// <summary>
    /// MHRS Kodu
    /// </summary>
        public int? MHRSCode
        {
            get { return (int?)this["MHRSCODE"]; }
            set { this["MHRSCODE"] = value; }
        }

    /// <summary>
    /// MHRS Alt Klinik Kodu
    /// </summary>
        public int? MHRSAltKlinikKodu
        {
            get { return (int?)this["MHRSALTKLINIKKODU"]; }
            set { this["MHRSALTKLINIKKODU"] = value; }
        }

    /// <summary>
    /// Boy Kilo Bilgisini Kopyala
    /// </summary>
        public bool? CopyHeightWeight
        {
            get { return (bool?)this["COPYHEIGHTWEIGHT"]; }
            set { this["COPYHEIGHTWEIGHT"] = value; }
        }

    /// <summary>
    /// Diş Polikliniği
    /// </summary>
        public bool? IsDentalPoliclinic
        {
            get { return (bool?)this["ISDENTALPOLICLINIC"]; }
            set { this["ISDENTALPOLICLINIC"] = value; }
        }

    /// <summary>
    /// Türü
    /// </summary>
        public PoliclinicTypeEnum? PoliclinicType
        {
            get { return (PoliclinicTypeEnum?)(int?)this["POLICLINICTYPE"]; }
            set { this["POLICLINICTYPE"] = value; }
        }

        public bool? PatientCallSystemInUse
        {
            get { return (bool?)this["PATIENTCALLSYSTEMINUSE"]; }
            set { this["PATIENTCALLSYSTEMINUSE"] = value; }
        }

    /// <summary>
    /// Sağlık Kurulu
    /// </summary>
        public bool? IsHealthCommittee
        {
            get { return (bool?)this["ISHEALTHCOMMITTEE"]; }
            set { this["ISHEALTHCOMMITTEE"] = value; }
        }

    /// <summary>
    /// Görüntülü Randevu Var mı
    /// </summary>
        public bool? IsGoruntuluRandevu
        {
            get { return (bool?)this["ISGORUNTULURANDEVU"]; }
            set { this["ISGORUNTULURANDEVU"] = value; }
        }

    /// <summary>
    /// Bölüm
    /// </summary>
        public ResDepartment Department
        {
            get { return (ResDepartment)((ITTObject)this).GetParent("DEPARTMENT"); }
            set { this["DEPARTMENT"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        virtual protected void CreatePoliclinicRoomsCollection()
        {
            _PoliclinicRooms = new ResPoliclinicRoom.ChildResPoliclinicRoomCollection(this, new Guid("647f48fd-9e56-4e0a-9e6d-d52addfcc67f"));
            ((ITTChildObjectCollection)_PoliclinicRooms).GetChildren();
        }

        protected ResPoliclinicRoom.ChildResPoliclinicRoomCollection _PoliclinicRooms = null;
        public ResPoliclinicRoom.ChildResPoliclinicRoomCollection PoliclinicRooms
        {
            get
            {
                if (_PoliclinicRooms == null)
                    CreatePoliclinicRoomsCollection();
                return _PoliclinicRooms;
            }
        }

        override protected void CreateResourceUsersCollectionViews()
        {
            base.CreateResourceUsersCollectionViews();
        }

        protected ResPoliclinic(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected ResPoliclinic(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected ResPoliclinic(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected ResPoliclinic(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected ResPoliclinic(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "RESPOLICLINIC", dataRow) { }
        protected ResPoliclinic(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "RESPOLICLINIC", dataRow, isImported) { }
        public ResPoliclinic(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public ResPoliclinic(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public ResPoliclinic() : base() { }

    }
}