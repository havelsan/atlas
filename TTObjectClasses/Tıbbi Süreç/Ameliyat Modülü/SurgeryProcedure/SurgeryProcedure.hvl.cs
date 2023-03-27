
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="SurgeryProcedure")] 

    /// <summary>
    /// Ameliyat Kategorisi
    /// </summary>
    public  partial class SurgeryProcedure : BaseSurgeryProcedure
    {
        public class SurgeryProcedureList : TTObjectCollection<SurgeryProcedure> { }
                    
        public class ChildSurgeryProcedureCollection : TTObject.TTChildObjectCollection<SurgeryProcedure>
        {
            public ChildSurgeryProcedureCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildSurgeryProcedureCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetSurgeryProceduresByEpisode_Class : TTReportNqlObject 
        {
            public DateTime? ActionDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ACTIONDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SURGERYPROCEDURE"].AllPropertyDefs["ACTIONDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public string Name
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["NAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PROCEDUREDEFINITION"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Code
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["CODE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PROCEDUREDEFINITION"].AllPropertyDefs["CODE"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public DateTime? Surgerydate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["SURGERYDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SURGERY"].AllPropertyDefs["SURGERYSTARTTIME"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public GetSurgeryProceduresByEpisode_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetSurgeryProceduresByEpisode_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetSurgeryProceduresByEpisode_Class() : base() { }
        }

        [Serializable] 

        public partial class GetSurgeryProceduresBySubEpisode_Class : TTReportNqlObject 
        {
            public DateTime? ActionDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ACTIONDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SURGERYPROCEDURE"].AllPropertyDefs["ACTIONDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public string Name
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["NAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PROCEDUREDEFINITION"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Code
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["CODE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PROCEDUREDEFINITION"].AllPropertyDefs["CODE"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public DateTime? Surgerydate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["SURGERYDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SURGERY"].AllPropertyDefs["SURGERYSTARTTIME"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public GetSurgeryProceduresBySubEpisode_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetSurgeryProceduresBySubEpisode_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetSurgeryProceduresBySubEpisode_Class() : base() { }
        }

        [Serializable] 

        public partial class OLAP_GetCancelledSurgeryProcedure_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public DateTime? SurgeryStartTime
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["SURGERYSTARTTIME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SURGERY"].AllPropertyDefs["SURGERYSTARTTIME"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public DateTime? RequestDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["REQUESTDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SURGERY"].AllPropertyDefs["REQUESTDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public Object Statestatus
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["STATESTATUS"]);
                }
            }

            public OLAP_GetCancelledSurgeryProcedure_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public OLAP_GetCancelledSurgeryProcedure_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected OLAP_GetCancelledSurgeryProcedure_Class() : base() { }
        }

        [Serializable] 

        public partial class OLAP_GetSurgeryProcedures_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public AnesthesiaTechniqueEnum? AnesthesiaTechnique
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ANESTHESIATECHNIQUE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["ANESTHESIAANDREANIMATION"].AllPropertyDefs["ANESTHESIATECHNIQUE"].DataType;
                    return (AnesthesiaTechniqueEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public DateTime? RequestDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["REQUESTDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SURGERY"].AllPropertyDefs["REQUESTDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public DateTime? SurgeryStartTime
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["SURGERYSTARTTIME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SURGERY"].AllPropertyDefs["SURGERYSTARTTIME"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public Guid? ProcedureObject
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["PROCEDUREOBJECT"]);
                }
            }

            public Guid? Department
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["DEPARTMENT"]);
                }
            }

            public Guid? ProcedureSpeciality
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["PROCEDURESPECIALITY"]);
                }
            }

            public Guid? Sex
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["SEX"]);
                }
            }

            public DateTime? BirthDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["BIRTHDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENT"].AllPropertyDefs["BIRTHDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public PatientStatusEnum? PatientStatus
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PATIENTSTATUS"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["EPISODE"].AllPropertyDefs["PATIENTSTATUS"].DataType;
                    return (PatientStatusEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public bool? Emergency
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["EMERGENCY"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SURGERY"].AllPropertyDefs["EMERGENCY"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public Object Status
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["STATUS"]);
                }
            }

            public Guid? ProcedureDoctor
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["PROCEDUREDOCTOR"]);
                }
            }

            public OLAP_GetSurgeryProcedures_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public OLAP_GetSurgeryProcedures_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected OLAP_GetSurgeryProcedures_Class() : base() { }
        }

        [Serializable] 

        public partial class OLAP_GetSurgeryCountByPatient_Class : TTReportNqlObject 
        {
            public Object Patient
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["PATIENT"]);
                }
            }

            public OLAP_GetSurgeryCountByPatient_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public OLAP_GetSurgeryCountByPatient_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected OLAP_GetSurgeryCountByPatient_Class() : base() { }
        }

        [Serializable] 

        public partial class OLAP_GetSurgeryCountBySUTCode_Class : TTReportNqlObject 
        {
            public string Code
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["CODE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PROCEDUREDEFINITION"].AllPropertyDefs["CODE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PROCEDUREDEFINITION"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public Object Nqlcolumn
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["NQLCOLUMN"]);
                }
            }

            public OLAP_GetSurgeryCountBySUTCode_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public OLAP_GetSurgeryCountBySUTCode_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected OLAP_GetSurgeryCountBySUTCode_Class() : base() { }
        }

        [Serializable] 

        public partial class OLAP_Ameliyat_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public AnesthesiaTechniqueEnum? AnesthesiaTechnique
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ANESTHESIATECHNIQUE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["ANESTHESIAANDREANIMATION"].AllPropertyDefs["ANESTHESIATECHNIQUE"].DataType;
                    return (AnesthesiaTechniqueEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public DateTime? ActionDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ACTIONDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SURGERYPROCEDURE"].AllPropertyDefs["ACTIONDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public Guid? ProcedureObject
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["PROCEDUREOBJECT"]);
                }
            }

            public Guid? Department
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["DEPARTMENT"]);
                }
            }

            public Guid? ProcedureSpeciality
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["PROCEDURESPECIALITY"]);
                }
            }

            public Guid? Sex
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["SEX"]);
                }
            }

            public DateTime? BirthDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["BIRTHDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENT"].AllPropertyDefs["BIRTHDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public PatientStatusEnum? PatientStatus
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PATIENTSTATUS"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["EPISODE"].AllPropertyDefs["PATIENTSTATUS"].DataType;
                    return (PatientStatusEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public bool? Emergency
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["EMERGENCY"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SURGERY"].AllPropertyDefs["EMERGENCY"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public DateTime? RequestDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["REQUESTDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SURGERY"].AllPropertyDefs["REQUESTDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public Guid? CurrentStateDefID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["CURRENTSTATEDEFID"]);
                }
            }

            public OLAP_Ameliyat_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public OLAP_Ameliyat_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected OLAP_Ameliyat_Class() : base() { }
        }

        [Serializable] 

        public partial class GetSurgeryPersonnelBySurgery_Class : TTReportNqlObject 
        {
            public Guid? Surgeryprocedureobjectid
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["SURGERYPROCEDUREOBJECTID"]);
                }
            }

            public string Procedurename
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PROCEDURENAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PROCEDUREDEFINITION"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public UserTitleEnum? Title
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["TITLE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESUSER"].AllPropertyDefs["TITLE"].DataType;
                    return (UserTitleEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public string Personnelname
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PERSONNELNAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESUSER"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public SurgeryRoleEnum? Role
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ROLE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SURGERYPERSONNEL"].AllPropertyDefs["ROLE"].DataType;
                    return (SurgeryRoleEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public GetSurgeryPersonnelBySurgery_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetSurgeryPersonnelBySurgery_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetSurgeryPersonnelBySurgery_Class() : base() { }
        }

        [Serializable] 

        public partial class GetSurgeriesByEpisode_Class : TTReportNqlObject 
        {
            public string Name
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["NAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PROCEDUREDEFINITION"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public GetSurgeriesByEpisode_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetSurgeriesByEpisode_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetSurgeriesByEpisode_Class() : base() { }
        }

        [Serializable] 

        public partial class GetSurgeryProceduresBySurgery_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public string Code
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["CODE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PROCEDUREDEFINITION"].AllPropertyDefs["CODE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PROCEDUREDEFINITION"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string ComplicationDescription
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["COMPLICATIONDESCRIPTION"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SURGERYPROCEDURE"].AllPropertyDefs["COMPLICATIONDESCRIPTION"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public bool? IsComplicationSurgery
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ISCOMPLICATIONSURGERY"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SURGERYPROCEDURE"].AllPropertyDefs["ISCOMPLICATIONSURGERY"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public GetSurgeryProceduresBySurgery_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetSurgeryProceduresBySurgery_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetSurgeryProceduresBySurgery_Class() : base() { }
        }

        new public static class States
        {
            public static Guid New { get { return new Guid("1c28a828-4470-46a5-af69-701b5322df1f"); } }
            public static Guid Completed { get { return new Guid("35536bbc-e567-46c8-be88-3bc9d65bfd5f"); } }
            public static Guid Cancelled { get { return new Guid("d16bf872-a7d1-476c-806d-92fd1852dccc"); } }
        }

        public static BindingList<SurgeryProcedure.GetSurgeryProceduresByEpisode_Class> GetSurgeryProceduresByEpisode(string EPISODE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["SURGERYPROCEDURE"].QueryDefs["GetSurgeryProceduresByEpisode"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("EPISODE", EPISODE);

            return TTReportNqlObject.QueryObjects<SurgeryProcedure.GetSurgeryProceduresByEpisode_Class>(queryDef, paramList, pi);
        }

        public static BindingList<SurgeryProcedure.GetSurgeryProceduresByEpisode_Class> GetSurgeryProceduresByEpisode(TTObjectContext objectContext, string EPISODE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["SURGERYPROCEDURE"].QueryDefs["GetSurgeryProceduresByEpisode"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("EPISODE", EPISODE);

            return TTReportNqlObject.QueryObjects<SurgeryProcedure.GetSurgeryProceduresByEpisode_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<SurgeryProcedure.GetSurgeryProceduresBySubEpisode_Class> GetSurgeryProceduresBySubEpisode(string SUBEPISODE, string EPISODE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["SURGERYPROCEDURE"].QueryDefs["GetSurgeryProceduresBySubEpisode"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("SUBEPISODE", SUBEPISODE);
            paramList.Add("EPISODE", EPISODE);

            return TTReportNqlObject.QueryObjects<SurgeryProcedure.GetSurgeryProceduresBySubEpisode_Class>(queryDef, paramList, pi);
        }

        public static BindingList<SurgeryProcedure.GetSurgeryProceduresBySubEpisode_Class> GetSurgeryProceduresBySubEpisode(TTObjectContext objectContext, string SUBEPISODE, string EPISODE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["SURGERYPROCEDURE"].QueryDefs["GetSurgeryProceduresBySubEpisode"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("SUBEPISODE", SUBEPISODE);
            paramList.Add("EPISODE", EPISODE);

            return TTReportNqlObject.QueryObjects<SurgeryProcedure.GetSurgeryProceduresBySubEpisode_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<SurgeryProcedure.OLAP_GetCancelledSurgeryProcedure_Class> OLAP_GetCancelledSurgeryProcedure(DateTime FIRSTDATE, DateTime LASTDATE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["SURGERYPROCEDURE"].QueryDefs["OLAP_GetCancelledSurgeryProcedure"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("FIRSTDATE", FIRSTDATE);
            paramList.Add("LASTDATE", LASTDATE);

            return TTReportNqlObject.QueryObjects<SurgeryProcedure.OLAP_GetCancelledSurgeryProcedure_Class>(queryDef, paramList, pi);
        }

        public static BindingList<SurgeryProcedure.OLAP_GetCancelledSurgeryProcedure_Class> OLAP_GetCancelledSurgeryProcedure(TTObjectContext objectContext, DateTime FIRSTDATE, DateTime LASTDATE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["SURGERYPROCEDURE"].QueryDefs["OLAP_GetCancelledSurgeryProcedure"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("FIRSTDATE", FIRSTDATE);
            paramList.Add("LASTDATE", LASTDATE);

            return TTReportNqlObject.QueryObjects<SurgeryProcedure.OLAP_GetCancelledSurgeryProcedure_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<SurgeryProcedure.OLAP_GetSurgeryProcedures_Class> OLAP_GetSurgeryProcedures(DateTime FIRSTDATE, DateTime LASTDATE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["SURGERYPROCEDURE"].QueryDefs["OLAP_GetSurgeryProcedures"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("FIRSTDATE", FIRSTDATE);
            paramList.Add("LASTDATE", LASTDATE);

            return TTReportNqlObject.QueryObjects<SurgeryProcedure.OLAP_GetSurgeryProcedures_Class>(queryDef, paramList, pi);
        }

        public static BindingList<SurgeryProcedure.OLAP_GetSurgeryProcedures_Class> OLAP_GetSurgeryProcedures(TTObjectContext objectContext, DateTime FIRSTDATE, DateTime LASTDATE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["SURGERYPROCEDURE"].QueryDefs["OLAP_GetSurgeryProcedures"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("FIRSTDATE", FIRSTDATE);
            paramList.Add("LASTDATE", LASTDATE);

            return TTReportNqlObject.QueryObjects<SurgeryProcedure.OLAP_GetSurgeryProcedures_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<SurgeryProcedure.OLAP_GetSurgeryCountByPatient_Class> OLAP_GetSurgeryCountByPatient(string SURGERYPROID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["SURGERYPROCEDURE"].QueryDefs["OLAP_GetSurgeryCountByPatient"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("SURGERYPROID", SURGERYPROID);

            return TTReportNqlObject.QueryObjects<SurgeryProcedure.OLAP_GetSurgeryCountByPatient_Class>(queryDef, paramList, pi);
        }

        public static BindingList<SurgeryProcedure.OLAP_GetSurgeryCountByPatient_Class> OLAP_GetSurgeryCountByPatient(TTObjectContext objectContext, string SURGERYPROID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["SURGERYPROCEDURE"].QueryDefs["OLAP_GetSurgeryCountByPatient"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("SURGERYPROID", SURGERYPROID);

            return TTReportNqlObject.QueryObjects<SurgeryProcedure.OLAP_GetSurgeryCountByPatient_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<SurgeryProcedure.OLAP_GetSurgeryCountBySUTCode_Class> OLAP_GetSurgeryCountBySUTCode(DateTime ENDDATE, DateTime STARTDATE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["SURGERYPROCEDURE"].QueryDefs["OLAP_GetSurgeryCountBySUTCode"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("ENDDATE", ENDDATE);
            paramList.Add("STARTDATE", STARTDATE);

            return TTReportNqlObject.QueryObjects<SurgeryProcedure.OLAP_GetSurgeryCountBySUTCode_Class>(queryDef, paramList, pi);
        }

        public static BindingList<SurgeryProcedure.OLAP_GetSurgeryCountBySUTCode_Class> OLAP_GetSurgeryCountBySUTCode(TTObjectContext objectContext, DateTime ENDDATE, DateTime STARTDATE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["SURGERYPROCEDURE"].QueryDefs["OLAP_GetSurgeryCountBySUTCode"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("ENDDATE", ENDDATE);
            paramList.Add("STARTDATE", STARTDATE);

            return TTReportNqlObject.QueryObjects<SurgeryProcedure.OLAP_GetSurgeryCountBySUTCode_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<SurgeryProcedure.OLAP_Ameliyat_Class> OLAP_Ameliyat(DateTime DATE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["SURGERYPROCEDURE"].QueryDefs["OLAP_Ameliyat"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("DATE", DATE);

            return TTReportNqlObject.QueryObjects<SurgeryProcedure.OLAP_Ameliyat_Class>(queryDef, paramList, pi);
        }

        public static BindingList<SurgeryProcedure.OLAP_Ameliyat_Class> OLAP_Ameliyat(TTObjectContext objectContext, DateTime DATE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["SURGERYPROCEDURE"].QueryDefs["OLAP_Ameliyat"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("DATE", DATE);

            return TTReportNqlObject.QueryObjects<SurgeryProcedure.OLAP_Ameliyat_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<SurgeryProcedure.GetSurgeryPersonnelBySurgery_Class> GetSurgeryPersonnelBySurgery(string SURGERY, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["SURGERYPROCEDURE"].QueryDefs["GetSurgeryPersonnelBySurgery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("SURGERY", SURGERY);

            return TTReportNqlObject.QueryObjects<SurgeryProcedure.GetSurgeryPersonnelBySurgery_Class>(queryDef, paramList, pi);
        }

        public static BindingList<SurgeryProcedure.GetSurgeryPersonnelBySurgery_Class> GetSurgeryPersonnelBySurgery(TTObjectContext objectContext, string SURGERY, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["SURGERYPROCEDURE"].QueryDefs["GetSurgeryPersonnelBySurgery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("SURGERY", SURGERY);

            return TTReportNqlObject.QueryObjects<SurgeryProcedure.GetSurgeryPersonnelBySurgery_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<SurgeryProcedure.GetSurgeriesByEpisode_Class> GetSurgeriesByEpisode(string EPISODE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["SURGERYPROCEDURE"].QueryDefs["GetSurgeriesByEpisode"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("EPISODE", EPISODE);

            return TTReportNqlObject.QueryObjects<SurgeryProcedure.GetSurgeriesByEpisode_Class>(queryDef, paramList, pi);
        }

        public static BindingList<SurgeryProcedure.GetSurgeriesByEpisode_Class> GetSurgeriesByEpisode(TTObjectContext objectContext, string EPISODE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["SURGERYPROCEDURE"].QueryDefs["GetSurgeriesByEpisode"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("EPISODE", EPISODE);

            return TTReportNqlObject.QueryObjects<SurgeryProcedure.GetSurgeriesByEpisode_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<SurgeryProcedure> GetSurgeryProcedureByPatient(TTObjectContext objectContext, Guid PATIENT)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["SURGERYPROCEDURE"].QueryDefs["GetSurgeryProcedureByPatient"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("PATIENT", PATIENT);

            return ((ITTQuery)objectContext).QueryObjects<SurgeryProcedure>(queryDef, paramList);
        }

        public static BindingList<SurgeryProcedure.GetSurgeryProceduresBySurgery_Class> GetSurgeryProceduresBySurgery(string SURGERY, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["SURGERYPROCEDURE"].QueryDefs["GetSurgeryProceduresBySurgery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("SURGERY", SURGERY);

            return TTReportNqlObject.QueryObjects<SurgeryProcedure.GetSurgeryProceduresBySurgery_Class>(queryDef, paramList, pi);
        }

        public static BindingList<SurgeryProcedure.GetSurgeryProceduresBySurgery_Class> GetSurgeryProceduresBySurgery(TTObjectContext objectContext, string SURGERY, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["SURGERYPROCEDURE"].QueryDefs["GetSurgeryProceduresBySurgery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("SURGERY", SURGERY);

            return TTReportNqlObject.QueryObjects<SurgeryProcedure.GetSurgeryProceduresBySurgery_Class>(objectContext, queryDef, paramList, pi);
        }

    /// <summary>
    /// Child Relationlardaki (Ekip) değişimlerde değişen  böylece Doktor Performansa veri oluşturan bool
    /// </summary>
        public bool? HasChangedAtChildObjects
        {
            get { return (bool?)this["HASCHANGEDATCHILDOBJECTS"]; }
            set { this["HASCHANGEDATCHILDOBJECTS"] = value; }
        }

        public RabsonEnum? RabsonGroup
        {
            get { return (RabsonEnum?)(int?)this["RABSONGROUP"]; }
            set { this["RABSONGROUP"] = value; }
        }

        public string ComplicationDescription
        {
            get { return (string)this["COMPLICATIONDESCRIPTION"]; }
            set { this["COMPLICATIONDESCRIPTION"] = value; }
        }

        public bool? IsComplicationSurgery
        {
            get { return (bool?)this["ISCOMPLICATIONSURGERY"]; }
            set { this["ISCOMPLICATIONSURGERY"] = value; }
        }

    /// <summary>
    /// Skolyoz Ameliyatı
    /// </summary>
        public bool? IsScoliosisSurgery
        {
            get { return (bool?)this["ISSCOLIOSISSURGERY"]; }
            set { this["ISSCOLIOSISSURGERY"] = value; }
        }

        public ResSection Department
        {
            get { return (ResSection)((ITTObject)this).GetParent("DEPARTMENT"); }
            set { this["DEPARTMENT"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public Surgery Surgery
        {
            get 
            {   
                if (EpisodeAction is Surgery)
                    return (Surgery)EpisodeAction; 
                return null;
            }            
            set { EpisodeAction = value; }
        }

    /// <summary>
    /// İşlem
    /// </summary>
        public SurgeryDefinition SurgeryDefinition
        {
            get 
            {   
                if (ProcedureObject is SurgeryDefinition)
                    return (SurgeryDefinition)ProcedureObject; 
                return null;
            }            
            set { ProcedureObject = value; }
        }

        virtual protected void CreateSurgeryResponsibleDoctorsCollection()
        {
            _SurgeryResponsibleDoctors = new SurgeryResponsibleDoctor.ChildSurgeryResponsibleDoctorCollection(this, new Guid("78308e45-4e2e-460a-ae2a-2779996c6b9a"));
            ((ITTChildObjectCollection)_SurgeryResponsibleDoctors).GetChildren();
        }

        protected SurgeryResponsibleDoctor.ChildSurgeryResponsibleDoctorCollection _SurgeryResponsibleDoctors = null;
        public SurgeryResponsibleDoctor.ChildSurgeryResponsibleDoctorCollection SurgeryResponsibleDoctors
        {
            get
            {
                if (_SurgeryResponsibleDoctors == null)
                    CreateSurgeryResponsibleDoctorsCollection();
                return _SurgeryResponsibleDoctors;
            }
        }

        virtual protected void CreateSurgeryPackageProcedureCollection()
        {
            _SurgeryPackageProcedure = new SurgeryPackageProcedure.ChildSurgeryPackageProcedureCollection(this, new Guid("929563ba-5811-4b8f-98dc-e066f605463f"));
            ((ITTChildObjectCollection)_SurgeryPackageProcedure).GetChildren();
        }

        protected SurgeryPackageProcedure.ChildSurgeryPackageProcedureCollection _SurgeryPackageProcedure = null;
        public SurgeryPackageProcedure.ChildSurgeryPackageProcedureCollection SurgeryPackageProcedure
        {
            get
            {
                if (_SurgeryPackageProcedure == null)
                    CreateSurgeryPackageProcedureCollection();
                return _SurgeryPackageProcedure;
            }
        }

        virtual protected void CreateSurgeryNewBornProcedureCollection()
        {
            _SurgeryNewBornProcedure = new SurgeryNewBornProcedure.ChildSurgeryNewBornProcedureCollection(this, new Guid("0cb1c02b-6107-49d0-8810-57c1348e25d9"));
            ((ITTChildObjectCollection)_SurgeryNewBornProcedure).GetChildren();
        }

        protected SurgeryNewBornProcedure.ChildSurgeryNewBornProcedureCollection _SurgeryNewBornProcedure = null;
        public SurgeryNewBornProcedure.ChildSurgeryNewBornProcedureCollection SurgeryNewBornProcedure
        {
            get
            {
                if (_SurgeryNewBornProcedure == null)
                    CreateSurgeryNewBornProcedureCollection();
                return _SurgeryNewBornProcedure;
            }
        }

        protected SurgeryProcedure(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected SurgeryProcedure(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected SurgeryProcedure(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected SurgeryProcedure(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected SurgeryProcedure(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "SURGERYPROCEDURE", dataRow) { }
        protected SurgeryProcedure(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "SURGERYPROCEDURE", dataRow, isImported) { }
        public SurgeryProcedure(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public SurgeryProcedure(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public SurgeryProcedure() : base() { }

    }
}