
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="ResSection")] 

    /// <summary>
    /// Birim
    /// </summary>
    public  partial class ResSection : Resource
    {
        public class ResSectionList : TTObjectCollection<ResSection> { }
                    
        public class ChildResSectionCollection : TTObject.TTChildObjectCollection<ResSection>
        {
            public ChildResSectionCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildResSectionCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class ConsultationRequestResourceListNql_Class : TTReportNqlObject 
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESPOLICLINIC"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
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

            public ConsultationRequestResourceListNql_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public ConsultationRequestResourceListNql_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected ConsultationRequestResourceListNql_Class() : base() { }
        }

        [Serializable] 

        public partial class EnableResSectionListNQL_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public long? ID
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ID"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESSECTION"].AllPropertyDefs["ID"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public string Qref
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["QREF"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESSECTION"].AllPropertyDefs["QREF"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESSECTION"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public String ObjectDefName
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["OBJECTDEFNAME"]);
                    if (val == null)
                        return null;
                    return (String)Convert.ChangeType(val, typeof(String)); 
                }
            }

            public EnableResSectionListNQL_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public EnableResSectionListNQL_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected EnableResSectionListNQL_Class() : base() { }
        }

        [Serializable] 

        public partial class PoliclinicClinicDepartmentListNQL_Class : TTReportNqlObject 
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESSECTION"].AllPropertyDefs["QREF"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESSECTION"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Name_Shadow
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["NAME_SHADOW"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESSECTION"].AllPropertyDefs["NAME_SHADOW"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public PoliclinicClinicDepartmentListNQL_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public PoliclinicClinicDepartmentListNQL_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected PoliclinicClinicDepartmentListNQL_Class() : base() { }
        }

        [Serializable] 

        public partial class SendToResourceListNQL_Class : TTReportNqlObject 
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

            public SendToResourceListNQL_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public SendToResourceListNQL_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected SendToResourceListNQL_Class() : base() { }
        }

        [Serializable] 

        public partial class PoliclinicClinicListNQL_Class : TTReportNqlObject 
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESSECTION"].AllPropertyDefs["QREF"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESSECTION"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Name_Shadow
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["NAME_SHADOW"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESSECTION"].AllPropertyDefs["NAME_SHADOW"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public PoliclinicClinicListNQL_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public PoliclinicClinicListNQL_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected PoliclinicClinicListNQL_Class() : base() { }
        }

        [Serializable] 

        public partial class GetAllSections_Class : TTReportNqlObject 
        {
            public Guid? Sectionid
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["SECTIONID"]);
                }
            }

            public string Sectionname
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["SECTIONNAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESSECTION"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public String Sectiontypeid
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["SECTIONTYPEID"]);
                    if (val == null)
                        return null;
                    return (String)Convert.ChangeType(val, typeof(String)); 
                }
            }

            public ResourceEnableType? Type
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["TYPE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESSECTION"].AllPropertyDefs["ENABLEDTYPE"].DataType;
                    return (ResourceEnableType?)(int)dataType.ConvertValue(val);
                }
            }

            public ResourceEnableType? Typename
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["TYPENAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESSECTION"].AllPropertyDefs["ENABLEDTYPE"].DataType;
                    return (ResourceEnableType?)(int)dataType.ConvertValue(val);
                }
            }

            public bool? Tobeconsulted
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["TOBECONSULTED"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESSECTION"].AllPropertyDefs["ISTOBECONSULTATION"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public Guid? Storeid
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["STOREID"]);
                }
            }

            public string Storename
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["STORENAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["STORE"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public Boolean? Isactiveforsection
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ISACTIVEFORSECTION"]);
                    if (val == null)
                        return null;
                    return (Boolean)Convert.ChangeType(val, typeof(Boolean)); 
                }
            }

            public Boolean? Isactiveforstore
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ISACTIVEFORSTORE"]);
                    if (val == null)
                        return null;
                    return (Boolean)Convert.ChangeType(val, typeof(Boolean)); 
                }
            }

            public GetAllSections_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetAllSections_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetAllSections_Class() : base() { }
        }

        [Serializable] 

        public partial class PoliclinicClinicTreatmentUnitListNQL_Class : TTReportNqlObject 
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESSECTION"].AllPropertyDefs["QREF"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESSECTION"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Name_Shadow
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["NAME_SHADOW"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESSECTION"].AllPropertyDefs["NAME_SHADOW"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public PoliclinicClinicTreatmentUnitListNQL_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public PoliclinicClinicTreatmentUnitListNQL_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected PoliclinicClinicTreatmentUnitListNQL_Class() : base() { }
        }

        [Serializable] 

        public partial class PolClinTreatLabUnitListNql_Class : TTReportNqlObject 
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESSECTION"].AllPropertyDefs["QREF"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESSECTION"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Name_Shadow
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["NAME_SHADOW"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESSECTION"].AllPropertyDefs["NAME_SHADOW"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public PolClinTreatLabUnitListNql_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public PolClinTreatLabUnitListNql_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected PolClinTreatLabUnitListNql_Class() : base() { }
        }

        [Serializable] 

        public partial class GetAllSectionsMobile_Class : TTReportNqlObject 
        {
            public Guid? Sectionid
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["SECTIONID"]);
                }
            }

            public string Sectionname
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["SECTIONNAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESSECTION"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public String Sectiontypeid
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["SECTIONTYPEID"]);
                    if (val == null)
                        return null;
                    return (String)Convert.ChangeType(val, typeof(String)); 
                }
            }

            public ResourceEnableType? Type
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["TYPE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESSECTION"].AllPropertyDefs["ENABLEDTYPE"].DataType;
                    return (ResourceEnableType?)(int)dataType.ConvertValue(val);
                }
            }

            public ResourceEnableType? Typename
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["TYPENAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESSECTION"].AllPropertyDefs["ENABLEDTYPE"].DataType;
                    return (ResourceEnableType?)(int)dataType.ConvertValue(val);
                }
            }

            public bool? Tobeconsulted
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["TOBECONSULTED"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESSECTION"].AllPropertyDefs["ISTOBECONSULTATION"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public Guid? Storeid
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["STOREID"]);
                }
            }

            public string Storename
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["STORENAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["STORE"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public Boolean? Isactiveforsection
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ISACTIVEFORSECTION"]);
                    if (val == null)
                        return null;
                    return (Boolean)Convert.ChangeType(val, typeof(Boolean)); 
                }
            }

            public Boolean? Isactiveforstore
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ISACTIVEFORSTORE"]);
                    if (val == null)
                        return null;
                    return (Boolean)Convert.ChangeType(val, typeof(Boolean)); 
                }
            }

            public GetAllSectionsMobile_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetAllSectionsMobile_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetAllSectionsMobile_Class() : base() { }
        }

        [Serializable] 

        public partial class GetAllRessectionForSubepisodeNQL_Class : TTReportNqlObject 
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESSECTION"].AllPropertyDefs["QREF"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESSECTION"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Name_Shadow
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["NAME_SHADOW"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESSECTION"].AllPropertyDefs["NAME_SHADOW"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public GetAllRessectionForSubepisodeNQL_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetAllRessectionForSubepisodeNQL_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetAllRessectionForSubepisodeNQL_Class() : base() { }
        }

        [Serializable] 

        public partial class GetAllResWardListWithEmtyBedCount_Class : TTReportNqlObject 
        {
            public Guid? Wardobjectid
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["WARDOBJECTID"]);
                }
            }

            public Object Name
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["NAME"]);
                }
            }

            public Object Emptybed
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["EMPTYBED"]);
                }
            }

            public GetAllResWardListWithEmtyBedCount_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetAllResWardListWithEmtyBedCount_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetAllResWardListWithEmtyBedCount_Class() : base() { }
        }

        public static BindingList<ResSection.ConsultationRequestResourceListNql_Class> ConsultationRequestResourceListNql(string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["RESSECTION"].QueryDefs["ConsultationRequestResourceListNql"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<ResSection.ConsultationRequestResourceListNql_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<ResSection.ConsultationRequestResourceListNql_Class> ConsultationRequestResourceListNql(TTObjectContext objectContext, string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["RESSECTION"].QueryDefs["ConsultationRequestResourceListNql"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<ResSection.ConsultationRequestResourceListNql_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<ResSection.EnableResSectionListNQL_Class> EnableResSectionListNQL(string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["RESSECTION"].QueryDefs["EnableResSectionListNQL"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<ResSection.EnableResSectionListNQL_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<ResSection.EnableResSectionListNQL_Class> EnableResSectionListNQL(TTObjectContext objectContext, string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["RESSECTION"].QueryDefs["EnableResSectionListNQL"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<ResSection.EnableResSectionListNQL_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<ResSection> GetResSections(TTObjectContext objectContext, string injectionSQL)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["RESSECTION"].QueryDefs["GetResSections"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return ((ITTQuery)objectContext).QueryObjects<ResSection>(queryDef, paramList, injectionSQL);
        }

        public static BindingList<ResSection> GetIfHasActionCancelledTime(TTObjectContext objectContext)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["RESSECTION"].QueryDefs["GetIfHasActionCancelledTime"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return ((ITTQuery)objectContext).QueryObjects<ResSection>(queryDef, paramList);
        }

        public static BindingList<ResSection.PoliclinicClinicDepartmentListNQL_Class> PoliclinicClinicDepartmentListNQL(string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["RESSECTION"].QueryDefs["PoliclinicClinicDepartmentListNQL"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<ResSection.PoliclinicClinicDepartmentListNQL_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<ResSection.PoliclinicClinicDepartmentListNQL_Class> PoliclinicClinicDepartmentListNQL(TTObjectContext objectContext, string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["RESSECTION"].QueryDefs["PoliclinicClinicDepartmentListNQL"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<ResSection.PoliclinicClinicDepartmentListNQL_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<ResSection.SendToResourceListNQL_Class> SendToResourceListNQL(string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["RESSECTION"].QueryDefs["SendToResourceListNQL"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<ResSection.SendToResourceListNQL_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<ResSection.SendToResourceListNQL_Class> SendToResourceListNQL(TTObjectContext objectContext, string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["RESSECTION"].QueryDefs["SendToResourceListNQL"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<ResSection.SendToResourceListNQL_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<ResSection> GetResourceOfUserBySpeciality(TTObjectContext objectContext, Guid CURRENTUSER, int INOUTPATIENT, IList<string> SPECIALITIES)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["RESSECTION"].QueryDefs["GetResourceOfUserBySpeciality"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("CURRENTUSER", CURRENTUSER);
            paramList.Add("INOUTPATIENT", INOUTPATIENT);
            paramList.Add("SPECIALITIES", SPECIALITIES);

            return ((ITTQuery)objectContext).QueryObjects<ResSection>(queryDef, paramList);
        }

        public static BindingList<ResSection> ConsultationRequestResourceList(TTObjectContext objectContext, string injectionSQL)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["RESSECTION"].QueryDefs["ConsultationRequestResourceList"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return ((ITTQuery)objectContext).QueryObjects<ResSection>(queryDef, paramList, injectionSQL);
        }

        public static BindingList<ResSection.PoliclinicClinicListNQL_Class> PoliclinicClinicListNQL(string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["RESSECTION"].QueryDefs["PoliclinicClinicListNQL"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<ResSection.PoliclinicClinicListNQL_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<ResSection.PoliclinicClinicListNQL_Class> PoliclinicClinicListNQL(TTObjectContext objectContext, string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["RESSECTION"].QueryDefs["PoliclinicClinicListNQL"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<ResSection.PoliclinicClinicListNQL_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<ResSection> GetBySpeciality(TTObjectContext objectContext, Guid SPECIALITY)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["RESSECTION"].QueryDefs["GetBySpeciality"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("SPECIALITY", SPECIALITY);

            return ((ITTQuery)objectContext).QueryObjects<ResSection>(queryDef, paramList);
        }

        public static BindingList<ResSection.GetAllSections_Class> GetAllSections(PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["RESSECTION"].QueryDefs["GetAllSections"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<ResSection.GetAllSections_Class>(queryDef, paramList, pi);
        }

        public static BindingList<ResSection.GetAllSections_Class> GetAllSections(TTObjectContext objectContext, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["RESSECTION"].QueryDefs["GetAllSections"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<ResSection.GetAllSections_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<ResSection> PoliclinicAndEmergencyListNQL(TTObjectContext objectContext, string injectionSQL)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["RESSECTION"].QueryDefs["PoliclinicAndEmergencyListNQL"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return ((ITTQuery)objectContext).QueryObjects<ResSection>(queryDef, paramList, injectionSQL);
        }

        public static BindingList<ResSection> GetPoliclinicClinicDepartment(TTObjectContext objectContext)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["RESSECTION"].QueryDefs["GetPoliclinicClinicDepartment"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return ((ITTQuery)objectContext).QueryObjects<ResSection>(queryDef, paramList);
        }

        public static BindingList<ResSection.PoliclinicClinicTreatmentUnitListNQL_Class> PoliclinicClinicTreatmentUnitListNQL(string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["RESSECTION"].QueryDefs["PoliclinicClinicTreatmentUnitListNQL"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<ResSection.PoliclinicClinicTreatmentUnitListNQL_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<ResSection.PoliclinicClinicTreatmentUnitListNQL_Class> PoliclinicClinicTreatmentUnitListNQL(TTObjectContext objectContext, string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["RESSECTION"].QueryDefs["PoliclinicClinicTreatmentUnitListNQL"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<ResSection.PoliclinicClinicTreatmentUnitListNQL_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<ResSection> GetDentalResources(TTObjectContext objectContext, string injectionSQL)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["RESSECTION"].QueryDefs["GetDentalResources"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return ((ITTQuery)objectContext).QueryObjects<ResSection>(queryDef, paramList, injectionSQL);
        }

        public static BindingList<ResSection> GetResourcesExceptDentalResources(TTObjectContext objectContext, string injectionSQL)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["RESSECTION"].QueryDefs["GetResourcesExceptDentalResources"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return ((ITTQuery)objectContext).QueryObjects<ResSection>(queryDef, paramList, injectionSQL);
        }

        public static BindingList<ResSection.PolClinTreatLabUnitListNql_Class> PolClinTreatLabUnitListNql(string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["RESSECTION"].QueryDefs["PolClinTreatLabUnitListNql"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<ResSection.PolClinTreatLabUnitListNql_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<ResSection.PolClinTreatLabUnitListNql_Class> PolClinTreatLabUnitListNql(TTObjectContext objectContext, string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["RESSECTION"].QueryDefs["PolClinTreatLabUnitListNql"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<ResSection.PolClinTreatLabUnitListNql_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<ResSection> GetMorgueDepartment(TTObjectContext objectContext, Guid OBJECTID)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["RESSECTION"].QueryDefs["GetMorgueDepartment"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("OBJECTID", OBJECTID);

            return ((ITTQuery)objectContext).QueryObjects<ResSection>(queryDef, paramList);
        }

        public static BindingList<ResSection> GetResourceByUserAndObjDef(TTObjectContext objectContext, Guid USERID, Guid OBJDEFID, string injectionSQL = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["RESSECTION"].QueryDefs["GetResourceByUserAndObjDef"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("USERID", USERID);
            paramList.Add("OBJDEFID", OBJDEFID);

            return ((ITTQuery)objectContext).QueryObjects<ResSection>(queryDef, paramList, injectionSQL);
        }

        public static BindingList<ResSection> GetByObjectId(TTObjectContext objectContext, Guid OBJECTID)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["RESSECTION"].QueryDefs["GetByObjectId"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("OBJECTID", OBJECTID);

            return ((ITTQuery)objectContext).QueryObjects<ResSection>(queryDef, paramList);
        }

        public static BindingList<ResSection> GetPoliclinicAndClinics(TTObjectContext objectContext)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["RESSECTION"].QueryDefs["GetPoliclinicAndClinics"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return ((ITTQuery)objectContext).QueryObjects<ResSection>(queryDef, paramList);
        }

        public static BindingList<ResSection.GetAllSectionsMobile_Class> GetAllSectionsMobile(string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["RESSECTION"].QueryDefs["GetAllSectionsMobile"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<ResSection.GetAllSectionsMobile_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<ResSection.GetAllSectionsMobile_Class> GetAllSectionsMobile(TTObjectContext objectContext, string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["RESSECTION"].QueryDefs["GetAllSectionsMobile"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<ResSection.GetAllSectionsMobile_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<ResSection> GetOnlyPoliclinics(TTObjectContext objectContext, string injectionSQL)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["RESSECTION"].QueryDefs["GetOnlyPoliclinics"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return ((ITTQuery)objectContext).QueryObjects<ResSection>(queryDef, paramList, injectionSQL);
        }

        public static BindingList<ResSection.GetAllRessectionForSubepisodeNQL_Class> GetAllRessectionForSubepisodeNQL(string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["RESSECTION"].QueryDefs["GetAllRessectionForSubepisodeNQL"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<ResSection.GetAllRessectionForSubepisodeNQL_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<ResSection.GetAllRessectionForSubepisodeNQL_Class> GetAllRessectionForSubepisodeNQL(TTObjectContext objectContext, string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["RESSECTION"].QueryDefs["GetAllRessectionForSubepisodeNQL"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<ResSection.GetAllRessectionForSubepisodeNQL_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<ResSection.GetAllResWardListWithEmtyBedCount_Class> GetAllResWardListWithEmtyBedCount(PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["RESSECTION"].QueryDefs["GetAllResWardListWithEmtyBedCount"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<ResSection.GetAllResWardListWithEmtyBedCount_Class>(queryDef, paramList, pi);
        }

        public static BindingList<ResSection.GetAllResWardListWithEmtyBedCount_Class> GetAllResWardListWithEmtyBedCount(TTObjectContext objectContext, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["RESSECTION"].QueryDefs["GetAllResWardListWithEmtyBedCount"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<ResSection.GetAllResWardListWithEmtyBedCount_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<ResSection> GetSectionForDailyOperations(TTObjectContext objectContext)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["RESSECTION"].QueryDefs["GetSectionForDailyOperations"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return ((ITTQuery)objectContext).QueryObjects<ResSection>(queryDef, paramList);
        }

    /// <summary>
    /// Randevu Limiti
    /// </summary>
        public int? AppointmentLimit
        {
            get { return (int?)this["APPOINTMENTLIMIT"]; }
            set { this["APPOINTMENTLIMIT"] = value; }
        }

    /// <summary>
    /// İşlem İptal Süresi(Gün)
    /// </summary>
        public int? ActionCancelledTime
        {
            get { return (int?)this["ACTIONCANCELLEDTIME"]; }
            set { this["ACTIONCANCELLEDTIME"] = value; }
        }

    /// <summary>
    /// Kullanım Tipi
    /// </summary>
        public ResourceEnableType? EnabledType
        {
            get { return (ResourceEnableType?)(int?)this["ENABLEDTYPE"]; }
            set { this["ENABLEDTYPE"] = value; }
        }

    /// <summary>
    /// 4.Ay Kontenjanı
    /// </summary>
        public int? AprilQuota
        {
            get { return (int?)this["APRILQUOTA"]; }
            set { this["APRILQUOTA"] = value; }
        }

    /// <summary>
    /// 8. Ay Kontenjanı
    /// </summary>
        public int? AugustQuota
        {
            get { return (int?)this["AUGUSTQUOTA"]; }
            set { this["AUGUSTQUOTA"] = value; }
        }

    /// <summary>
    /// 6. Ay Kontenjanı
    /// </summary>
        public int? JuneQuata
        {
            get { return (int?)this["JUNEQUATA"]; }
            set { this["JUNEQUATA"] = value; }
        }

    /// <summary>
    /// Son Kontenjanlı Kabul Tarihi
    /// </summary>
        public DateTime? LastQuotaDate
        {
            get { return (DateTime?)this["LASTQUOTADATE"]; }
            set { this["LASTQUOTADATE"] = value; }
        }

    /// <summary>
    /// 11. Ay Kontenjanı
    /// </summary>
        public int? NovemberQuota
        {
            get { return (int?)this["NOVEMBERQUOTA"]; }
            set { this["NOVEMBERQUOTA"] = value; }
        }

    /// <summary>
    /// 10. Ay Kontenjanı
    /// </summary>
        public int? OctoberQuota
        {
            get { return (int?)this["OCTOBERQUOTA"]; }
            set { this["OCTOBERQUOTA"] = value; }
        }

    /// <summary>
    /// 9. Ay Kontenjanı
    /// </summary>
        public int? SeptemberQuota
        {
            get { return (int?)this["SEPTEMBERQUOTA"]; }
            set { this["SEPTEMBERQUOTA"] = value; }
        }

    /// <summary>
    /// Haftalık Kontenjan
    /// </summary>
        public int? WeeklyQuota
        {
            get { return (int?)this["WEEKLYQUOTA"]; }
            set { this["WEEKLYQUOTA"] = value; }
        }

    /// <summary>
    /// SK Bölüm Raporunu Gösterme
    /// </summary>
        public bool? DontShowHCDepartmentReport
        {
            get { return (bool?)this["DONTSHOWHCDEPARTMENTREPORT"]; }
            set { this["DONTSHOWHCDEPARTMENTREPORT"] = value; }
        }

    /// <summary>
    /// İrtibat Telefonu
    /// </summary>
        public string ContactPhone
        {
            get { return (string)this["CONTACTPHONE"]; }
            set { this["CONTACTPHONE"] = value; }
        }

    /// <summary>
    /// Konsültasyon Yapılabilir
    /// </summary>
        public bool? IsToBeConsultation
        {
            get { return (bool?)this["ISTOBECONSULTATION"]; }
            set { this["ISTOBECONSULTATION"] = value; }
        }

    /// <summary>
    /// Etiket Basılsın
    /// </summary>
        public bool? IsEtiquettePrinted
        {
            get { return (bool?)this["ISETIQUETTEPRINTED"]; }
            set { this["ISETIQUETTEPRINTED"] = value; }
        }

    /// <summary>
    /// Etiket Sayısı
    /// </summary>
        public int? EtiquetteCount
        {
            get { return (int?)this["ETIQUETTECOUNT"]; }
            set { this["ETIQUETTECOUNT"] = value; }
        }

    /// <summary>
    /// Hasta Çağrı Sistemi Kullanımda
    /// </summary>
        public bool? PCSInUse
        {
            get { return (bool?)this["PCSINUSE"]; }
            set { this["PCSINUSE"] = value; }
        }

    /// <summary>
    /// 3. Ay Kontenjanı
    /// </summary>
        public int? MarchQuota
        {
            get { return (int?)this["MARCHQUOTA"]; }
            set { this["MARCHQUOTA"] = value; }
        }

    /// <summary>
    /// Günlük Kontenjan
    /// </summary>
        public int? DailyQuota
        {
            get { return (int?)this["DAILYQUOTA"]; }
            set { this["DAILYQUOTA"] = value; }
        }

    /// <summary>
    /// 12. Ay Kontenjanı
    /// </summary>
        public int? DecemberQuota
        {
            get { return (int?)this["DECEMBERQUOTA"]; }
            set { this["DECEMBERQUOTA"] = value; }
        }

    /// <summary>
    /// 2.Ay Kontenjanı
    /// </summary>
        public int? FebruaryQuota
        {
            get { return (int?)this["FEBRUARYQUOTA"]; }
            set { this["FEBRUARYQUOTA"] = value; }
        }

    /// <summary>
    /// 1.Ay Kontenjanı
    /// </summary>
        public int? JanuaryQuota
        {
            get { return (int?)this["JANUARYQUOTA"]; }
            set { this["JANUARYQUOTA"] = value; }
        }

    /// <summary>
    /// 7. Ay Kontenjanı
    /// </summary>
        public int? JulyQuota
        {
            get { return (int?)this["JULYQUOTA"]; }
            set { this["JULYQUOTA"] = value; }
        }

    /// <summary>
    /// 5. Ay Kontenjanı
    /// </summary>
        public int? MayQuota
        {
            get { return (int?)this["MAYQUOTA"]; }
            set { this["MAYQUOTA"] = value; }
        }

    /// <summary>
    /// Aylık Kontenjan
    /// </summary>
        public int? MonthlyQuota
        {
            get { return (int?)this["MONTHLYQUOTA"]; }
            set { this["MONTHLYQUOTA"] = value; }
        }

    /// <summary>
    /// Sağlık Kurulu Muayene Ücreti Oluşturma
    /// </summary>
        public bool? NotChargeHCExaminationPrice
        {
            get { return (bool?)this["NOTCHARGEHCEXAMINATIONPRICE"]; }
            set { this["NOTCHARGEHCEXAMINATIONPRICE"] = value; }
        }

    /// <summary>
    /// İrtibat Adresi
    /// </summary>
        public string ContactAddress
        {
            get { return (string)this["CONTACTADDRESS"]; }
            set { this["CONTACTADDRESS"] = value; }
        }

        public bool? IgnoreQuotaControl
        {
            get { return (bool?)this["IGNOREQUOTACONTROL"]; }
            set { this["IGNOREQUOTACONTROL"] = value; }
        }

        public int? InpatientQuota
        {
            get { return (int?)this["INPATIENTQUOTA"]; }
            set { this["INPATIENTQUOTA"] = value; }
        }

    /// <summary>
    /// Himss Kontrollerine Girer
    /// </summary>
        public bool? HimssRequired
        {
            get { return (bool?)this["HIMSSREQUIRED"]; }
            set { this["HIMSSREQUIRED"] = value; }
        }

    /// <summary>
    /// Tehlikeli/Tıbbi Atık
    /// </summary>
        public bool? IsmedicalWaste
        {
            get { return (bool?)this["ISMEDICALWASTE"]; }
            set { this["ISMEDICALWASTE"] = value; }
        }

        public ResSectionTypeEnum? ResSectionType
        {
            get { return (ResSectionTypeEnum?)(int?)this["RESSECTIONTYPE"]; }
            set { this["RESSECTIONTYPE"] = value; }
        }

        public DateTime? ResourceStartTime
        {
            get { return (DateTime?)this["RESOURCESTARTTIME"]; }
            set { this["RESOURCESTARTTIME"] = value; }
        }

    /// <summary>
    /// Kaynak Bitiş Zamanı
    /// </summary>
        public DateTime? ResourceEndTime
        {
            get { return (DateTime?)this["RESOURCEENDTIME"]; }
            set { this["RESOURCEENDTIME"] = value; }
        }

    /// <summary>
    /// Kiosk Kabulü Yapılır
    /// </summary>
        public bool? ShownInKiosk
        {
            get { return (bool?)this["SHOWNINKIOSK"]; }
            set { this["SHOWNINKIOSK"] = value; }
        }

        public int? OptionalDelayMinute
        {
            get { return (int?)this["OPTIONALDELAYMINUTE"]; }
            set { this["OPTIONALDELAYMINUTE"] = value; }
        }

    /// <summary>
    /// cinsiyet Kontrolü Yaplır
    /// </summary>
        public SexEnum? SexException
        {
            get { return (SexEnum?)(int?)this["SEXEXCEPTION"]; }
            set { this["SEXEXCEPTION"] = value; }
        }

    /// <summary>
    /// Kabul Alınabilecek Max yaş
    /// </summary>
        public int? MaxAge
        {
            get { return (int?)this["MAXAGE"]; }
            set { this["MAXAGE"] = value; }
        }

    /// <summary>
    /// Medula Provizyonu ALınmayacak Birim
    /// </summary>
        public bool? DontTakeGSSProvision
        {
            get { return (bool?)this["DONTTAKEGSSPROVISION"]; }
            set { this["DONTTAKEGSSPROVISION"] = value; }
        }

    /// <summary>
    /// Kabul Alınabilecek Minimum yaş
    /// </summary>
        public int? MinAge
        {
            get { return (int?)this["MINAGE"]; }
            set { this["MINAGE"] = value; }
        }

        public SKRSCodeDefinition SaglikNetKlinikleri
        {
            get { return (SKRSCodeDefinition)((ITTObject)this).GetParent("SAGLIKNETKLINIKLERI"); }
            set { this["SAGLIKNETKLINIKLERI"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Birim için default Tedavi Tipi
    /// </summary>
        public TedaviTipi TedaviTipi
        {
            get { return (TedaviTipi)((ITTObject)this).GetParent("TEDAVITIPI"); }
            set { this["TEDAVITIPI"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Birim için default Tedavi Türü
    /// </summary>
        public TedaviTuru TedaviTuru
        {
            get { return (TedaviTuru)((ITTObject)this).GetParent("TEDAVITURU"); }
            set { this["TEDAVITURU"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Birim için default Takip Tipi
    /// </summary>
        public TakipTipi TakipTipi
        {
            get { return (TakipTipi)((ITTObject)this).GetParent("TAKIPTIPI"); }
            set { this["TAKIPTIPI"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public ResFloor ResFloor
        {
            get { return (ResFloor)((ITTObject)this).GetParent("RESFLOOR"); }
            set { this["RESFLOOR"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        virtual protected void CreateHyperbaricOxygenTreatmentUnitGridsCollection()
        {
            _HyperbaricOxygenTreatmentUnitGrids = new HyperbaricOxygenTreatmentUnitGrid.ChildHyperbaricOxygenTreatmentUnitGridCollection(this, new Guid("58bfe6bf-59d2-4413-85ad-0e2ff578d66e"));
            ((ITTChildObjectCollection)_HyperbaricOxygenTreatmentUnitGrids).GetChildren();
        }

        protected HyperbaricOxygenTreatmentUnitGrid.ChildHyperbaricOxygenTreatmentUnitGridCollection _HyperbaricOxygenTreatmentUnitGrids = null;
    /// <summary>
    /// Child collection for Hiperbarik Oksijen Tedavi Ünitesi
    /// </summary>
        public HyperbaricOxygenTreatmentUnitGrid.ChildHyperbaricOxygenTreatmentUnitGridCollection HyperbaricOxygenTreatmentUnitGrids
        {
            get
            {
                if (_HyperbaricOxygenTreatmentUnitGrids == null)
                    CreateHyperbaricOxygenTreatmentUnitGridsCollection();
                return _HyperbaricOxygenTreatmentUnitGrids;
            }
        }

        virtual protected void CreateDPDepartmentGridsCollection()
        {
            _DPDepartmentGrids = new DentalProsthesisDepartmentGrid.ChildDentalProsthesisDepartmentGridCollection(this, new Guid("6ed49828-824e-4dd6-ba1b-70d91895a70c"));
            ((ITTChildObjectCollection)_DPDepartmentGrids).GetChildren();
        }

        protected DentalProsthesisDepartmentGrid.ChildDentalProsthesisDepartmentGridCollection _DPDepartmentGrids = null;
        public DentalProsthesisDepartmentGrid.ChildDentalProsthesisDepartmentGridCollection DPDepartmentGrids
        {
            get
            {
                if (_DPDepartmentGrids == null)
                    CreateDPDepartmentGridsCollection();
                return _DPDepartmentGrids;
            }
        }

        virtual protected void CreateDTDepartmentGridsCollection()
        {
            _DTDepartmentGrids = new DentalTreatmentDepartmentGrid.ChildDentalTreatmentDepartmentGridCollection(this, new Guid("94748dcd-cc62-4b7d-90f0-c4241a7c9c67"));
            ((ITTChildObjectCollection)_DTDepartmentGrids).GetChildren();
        }

        protected DentalTreatmentDepartmentGrid.ChildDentalTreatmentDepartmentGridCollection _DTDepartmentGrids = null;
    /// <summary>
    /// Child collection for Diş Tedavi Birimleri
    /// </summary>
        public DentalTreatmentDepartmentGrid.ChildDentalTreatmentDepartmentGridCollection DTDepartmentGrids
        {
            get
            {
                if (_DTDepartmentGrids == null)
                    CreateDTDepartmentGridsCollection();
                return _DTDepartmentGrids;
            }
        }

        virtual protected void CreateResourceUsersCollectionViews()
        {
        }

        virtual protected void CreateResourceUsersCollection()
        {
            _ResourceUsers = new UserResource.ChildUserResourceCollection(this, new Guid("aac5d62a-45e8-48d2-a7e0-df8a66c06036"));
            CreateResourceUsersCollectionViews();
            ((ITTChildObjectCollection)_ResourceUsers).GetChildren();
        }

        protected UserResource.ChildUserResourceCollection _ResourceUsers = null;
        public UserResource.ChildUserResourceCollection ResourceUsers
        {
            get
            {
                if (_ResourceUsers == null)
                    CreateResourceUsersCollection();
                return _ResourceUsers;
            }
        }

        virtual protected void CreatePatientAdmissionProcedureRequestFormDetailDefsCollection()
        {
            _PatientAdmissionProcedureRequestFormDetailDefs = new ProcedureRequestFormDetailDefinition.ChildProcedureRequestFormDetailDefinitionCollection(this, new Guid("63b06958-16c2-4eb4-b6ca-da5e45927e53"));
            ((ITTChildObjectCollection)_PatientAdmissionProcedureRequestFormDetailDefs).GetChildren();
        }

        protected ProcedureRequestFormDetailDefinition.ChildProcedureRequestFormDetailDefinitionCollection _PatientAdmissionProcedureRequestFormDetailDefs = null;
        public ProcedureRequestFormDetailDefinition.ChildProcedureRequestFormDetailDefinitionCollection PatientAdmissionProcedureRequestFormDetailDefs
        {
            get
            {
                if (_PatientAdmissionProcedureRequestFormDetailDefs == null)
                    CreatePatientAdmissionProcedureRequestFormDetailDefsCollection();
                return _PatientAdmissionProcedureRequestFormDetailDefs;
            }
        }

        virtual protected void CreatePatientExamParticipUnitCollection()
        {
            _PatientExamParticipUnit = new PatientExamParticipUnit.ChildPatientExamParticipUnitCollection(this, new Guid("8393018c-d561-43d3-a529-ffc471252497"));
            ((ITTChildObjectCollection)_PatientExamParticipUnit).GetChildren();
        }

        protected PatientExamParticipUnit.ChildPatientExamParticipUnitCollection _PatientExamParticipUnit = null;
    /// <summary>
    /// Child collection for Muayene Katkı Payından Muaf olan Yakınlık Dereceleri ilişkisi
    /// </summary>
        public PatientExamParticipUnit.ChildPatientExamParticipUnitCollection PatientExamParticipUnit
        {
            get
            {
                if (_PatientExamParticipUnit == null)
                    CreatePatientExamParticipUnitCollection();
                return _PatientExamParticipUnit;
            }
        }

        virtual protected void CreateExaminationQueueDefinitionsCollection()
        {
            _ExaminationQueueDefinitions = new ExaminationQueueDefinition.ChildExaminationQueueDefinitionCollection(this, new Guid("eea3fb27-f999-4160-b489-e38aa485a7b7"));
            ((ITTChildObjectCollection)_ExaminationQueueDefinitions).GetChildren();
        }

        protected ExaminationQueueDefinition.ChildExaminationQueueDefinitionCollection _ExaminationQueueDefinitions = null;
        public ExaminationQueueDefinition.ChildExaminationQueueDefinitionCollection ExaminationQueueDefinitions
        {
            get
            {
                if (_ExaminationQueueDefinitions == null)
                    CreateExaminationQueueDefinitionsCollection();
                return _ExaminationQueueDefinitions;
            }
        }

        virtual protected void CreateResponsibleUsersCollection()
        {
            _ResponsibleUsers = new ResponsibleUsersGrid.ChildResponsibleUsersGridCollection(this, new Guid("4acf084c-80f4-45a2-aac4-0339619b053d"));
            ((ITTChildObjectCollection)_ResponsibleUsers).GetChildren();
        }

        protected ResponsibleUsersGrid.ChildResponsibleUsersGridCollection _ResponsibleUsers = null;
        public ResponsibleUsersGrid.ChildResponsibleUsersGridCollection ResponsibleUsers
        {
            get
            {
                if (_ResponsibleUsers == null)
                    CreateResponsibleUsersCollection();
                return _ResponsibleUsers;
            }
        }

        virtual protected void CreateReusableMaterialsCollection()
        {
            _ReusableMaterials = new ResReusableMaterial.ChildResReusableMaterialCollection(this, new Guid("6f3e63d6-ac67-434d-af58-ea111d00f95b"));
            ((ITTChildObjectCollection)_ReusableMaterials).GetChildren();
        }

        protected ResReusableMaterial.ChildResReusableMaterialCollection _ReusableMaterials = null;
        public ResReusableMaterial.ChildResReusableMaterialCollection ReusableMaterials
        {
            get
            {
                if (_ReusableMaterials == null)
                    CreateReusableMaterialsCollection();
                return _ReusableMaterials;
            }
        }

        protected ResSection(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected ResSection(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected ResSection(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected ResSection(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected ResSection(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "RESSECTION", dataRow) { }
        protected ResSection(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "RESSECTION", dataRow, isImported) { }
        protected ResSection(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public ResSection(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public ResSection() : base() { }

    }
}