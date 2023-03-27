
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="Resource")] 

    /// <summary>
    /// BaseResourceClass
    /// </summary>
    public  abstract  partial class Resource : TTDefinitionSet
    {
        public class ResourceList : TTObjectCollection<Resource> { }
                    
        public class ChildResourceCollection : TTObject.TTChildObjectCollection<Resource>
        {
            public ChildResourceCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildResourceCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetResSectionResUserNQL_Class : TTReportNqlObject 
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESSECTION"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public GetResSectionResUserNQL_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetResSectionResUserNQL_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetResSectionResUserNQL_Class() : base() { }
        }

        [Serializable] 

        public partial class GetResSectionForHospitalInfo_Class : TTReportNqlObject 
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESSECTION"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public GetResSectionForHospitalInfo_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetResSectionForHospitalInfo_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetResSectionForHospitalInfo_Class() : base() { }
        }

        [Serializable] 

        public partial class GetResClinicForHospitalInfo_Class : TTReportNqlObject 
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESSECTION"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public GetResClinicForHospitalInfo_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetResClinicForHospitalInfo_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetResClinicForHospitalInfo_Class() : base() { }
        }

        public static BindingList<Resource> GetResource(TTObjectContext objectContext, string OBJECTID)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["RESOURCE"].QueryDefs["GetResource"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("OBJECTID", OBJECTID);

            return ((ITTQuery)objectContext).QueryObjects<Resource>(queryDef, paramList);
        }

        public static BindingList<Resource> GetResources(TTObjectContext objectContext, string injectionSQL)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["RESOURCE"].QueryDefs["GetResources"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return ((ITTQuery)objectContext).QueryObjects<Resource>(queryDef, paramList, injectionSQL);
        }

        public static BindingList<Resource> GetResourcesForQueueInDate(TTObjectContext objectContext, Guid QUEUE, DateTime WORKDATE)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["RESOURCE"].QueryDefs["GetResourcesForQueueInDate"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("QUEUE", QUEUE);
            paramList.Add("WORKDATE", WORKDATE);

            return ((ITTQuery)objectContext).QueryObjects<Resource>(queryDef, paramList);
        }

        public static BindingList<Resource> GetResourceByStore(TTObjectContext objectContext, Guid STOREID)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["RESOURCE"].QueryDefs["GetResourceByStore"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STOREID", STOREID);

            return ((ITTQuery)objectContext).QueryObjects<Resource>(queryDef, paramList);
        }

        public static BindingList<Resource.GetResSectionResUserNQL_Class> GetResSectionResUserNQL(string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["RESOURCE"].QueryDefs["GetResSectionResUserNQL"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<Resource.GetResSectionResUserNQL_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<Resource.GetResSectionResUserNQL_Class> GetResSectionResUserNQL(TTObjectContext objectContext, string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["RESOURCE"].QueryDefs["GetResSectionResUserNQL"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<Resource.GetResSectionResUserNQL_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<Resource.GetResSectionForHospitalInfo_Class> GetResSectionForHospitalInfo(string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["RESOURCE"].QueryDefs["GetResSectionForHospitalInfo"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<Resource.GetResSectionForHospitalInfo_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<Resource.GetResSectionForHospitalInfo_Class> GetResSectionForHospitalInfo(TTObjectContext objectContext, string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["RESOURCE"].QueryDefs["GetResSectionForHospitalInfo"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<Resource.GetResSectionForHospitalInfo_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<Resource.GetResClinicForHospitalInfo_Class> GetResClinicForHospitalInfo(string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["RESOURCE"].QueryDefs["GetResClinicForHospitalInfo"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<Resource.GetResClinicForHospitalInfo_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<Resource.GetResClinicForHospitalInfo_Class> GetResClinicForHospitalInfo(TTObjectContext objectContext, string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["RESOURCE"].QueryDefs["GetResClinicForHospitalInfo"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<Resource.GetResClinicForHospitalInfo_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

    /// <summary>
    /// Kısa Adı
    /// </summary>
        public string Qref
        {
            get { return (string)this["QREF"]; }
            set { this["QREF"] = value; }
        }

    /// <summary>
    /// Kaynak adı
    /// </summary>
        public string Name
        {
            get { return (string)this["NAME"]; }
            set { this["NAME"] = value; }
        }

        public TTSequence ID
        {
            get { return GetSequence("ID"); }
        }

    /// <summary>
    /// Kaynak adı
    /// </summary>
        public string Name_Shadow
        {
            get { return (string)this["NAME_SHADOW"]; }
        }

    /// <summary>
    /// Bulundugu Yerin Adres Tarifi
    /// </summary>
        public string Location
        {
            get { return (string)this["LOCATION"]; }
            set { this["LOCATION"] = value; }
        }

        public string DeskPhoneNumber
        {
            get { return (string)this["DESKPHONENUMBER"]; }
            set { this["DESKPHONENUMBER"] = value; }
        }

    /// <summary>
    /// Kaynak Tipi
    /// </summary>
        public ResType ResType
        {
            get { return (ResType)((ITTObject)this).GetParent("RESTYPE"); }
            set { this["RESTYPE"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Depo
    /// </summary>
        public Store Store
        {
            get { return (Store)((ITTObject)this).GetParent("STORE"); }
            set { this["STORE"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        virtual protected void CreateResourceSpecialitiesCollection()
        {
            _ResourceSpecialities = new ResourceSpecialityGrid.ChildResourceSpecialityGridCollection(this, new Guid("108acc10-8f55-4596-a0ab-7f15ead4d447"));
            ((ITTChildObjectCollection)_ResourceSpecialities).GetChildren();
        }

        protected ResourceSpecialityGrid.ChildResourceSpecialityGridCollection _ResourceSpecialities = null;
        public ResourceSpecialityGrid.ChildResourceSpecialityGridCollection ResourceSpecialities
        {
            get
            {
                if (_ResourceSpecialities == null)
                    CreateResourceSpecialitiesCollection();
                return _ResourceSpecialities;
            }
        }

        virtual protected void CreateAppointmentsCollection()
        {
            _Appointments = new Appointment.ChildAppointmentCollection(this, new Guid("896ff112-314e-4190-8a6c-f8dcf866154a"));
            ((ITTChildObjectCollection)_Appointments).GetChildren();
        }

        protected Appointment.ChildAppointmentCollection _Appointments = null;
        public Appointment.ChildAppointmentCollection Appointments
        {
            get
            {
                if (_Appointments == null)
                    CreateAppointmentsCollection();
                return _Appointments;
            }
        }

        virtual protected void CreatePatientAuthorizedResourcesCollection()
        {
            _PatientAuthorizedResources = new PatientAuthorizedResource.ChildPatientAuthorizedResourceCollection(this, new Guid("08906a86-3341-4ed2-925c-824d9b73736d"));
            ((ITTChildObjectCollection)_PatientAuthorizedResources).GetChildren();
        }

        protected PatientAuthorizedResource.ChildPatientAuthorizedResourceCollection _PatientAuthorizedResources = null;
        public PatientAuthorizedResource.ChildPatientAuthorizedResourceCollection PatientAuthorizedResources
        {
            get
            {
                if (_PatientAuthorizedResources == null)
                    CreatePatientAuthorizedResourcesCollection();
                return _PatientAuthorizedResources;
            }
        }

        virtual protected void CreateQueueResourceDefCollection()
        {
            _QueueResourceDef = new QueueResourceWorkPlanDefinition.ChildQueueResourceWorkPlanDefinitionCollection(this, new Guid("f12e2837-9d06-43f3-97e8-bac79812fdde"));
            ((ITTChildObjectCollection)_QueueResourceDef).GetChildren();
        }

        protected QueueResourceWorkPlanDefinition.ChildQueueResourceWorkPlanDefinitionCollection _QueueResourceDef = null;
        public QueueResourceWorkPlanDefinition.ChildQueueResourceWorkPlanDefinitionCollection QueueResourceDef
        {
            get
            {
                if (_QueueResourceDef == null)
                    CreateQueueResourceDefCollection();
                return _QueueResourceDef;
            }
        }

        protected Resource(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected Resource(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected Resource(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected Resource(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected Resource(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "RESOURCE", dataRow) { }
        protected Resource(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "RESOURCE", dataRow, isImported) { }
        public Resource(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public Resource(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public Resource() : base() { }

    }
}