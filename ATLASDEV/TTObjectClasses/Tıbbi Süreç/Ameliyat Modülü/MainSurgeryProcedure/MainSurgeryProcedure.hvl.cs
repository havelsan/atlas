
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="MainSurgeryProcedure")] 

    /// <summary>
    /// Ameliyat
    /// </summary>
    public  partial class MainSurgeryProcedure : SurgeryProcedure
    {
        public class MainSurgeryProcedureList : TTObjectCollection<MainSurgeryProcedure> { }
                    
        public class ChildMainSurgeryProcedureCollection : TTObject.TTChildObjectCollection<MainSurgeryProcedure>
        {
            public ChildMainSurgeryProcedureCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildMainSurgeryProcedureCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetMainSurgeryPersonnelBySurgery_Class : TTReportNqlObject 
        {
            public Guid? Mainsurgeryprocedureobjectid
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["MAINSURGERYPROCEDUREOBJECTID"]);
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

            public GetMainSurgeryPersonnelBySurgery_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetMainSurgeryPersonnelBySurgery_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetMainSurgeryPersonnelBySurgery_Class() : base() { }
        }

        [Serializable] 

        public partial class GetByMainSurgery_Class : TTReportNqlObject 
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

            public GetByMainSurgery_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetByMainSurgery_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetByMainSurgery_Class() : base() { }
        }

        [Serializable] 

        public partial class GetSurgeryProcedureCountByPatientGroupByDate_Class : TTReportNqlObject 
        {
            public DateTime? Sayi
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["SAYI"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SURGERY"].AllPropertyDefs["SURGERYSTARTTIME"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public GetSurgeryProcedureCountByPatientGroupByDate_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetSurgeryProcedureCountByPatientGroupByDate_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetSurgeryProcedureCountByPatientGroupByDate_Class() : base() { }
        }

        new public static class States
        {
            public static Guid New { get { return new Guid("1c28a828-4470-46a5-af69-701b5322df1f"); } }
            public static Guid Completed { get { return new Guid("35536bbc-e567-46c8-be88-3bc9d65bfd5f"); } }
            public static Guid Cancelled { get { return new Guid("d16bf872-a7d1-476c-806d-92fd1852dccc"); } }
        }

        public static BindingList<MainSurgeryProcedure.GetMainSurgeryPersonnelBySurgery_Class> GetMainSurgeryPersonnelBySurgery(Guid SURGERY, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["MAINSURGERYPROCEDURE"].QueryDefs["GetMainSurgeryPersonnelBySurgery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("SURGERY", SURGERY);

            return TTReportNqlObject.QueryObjects<MainSurgeryProcedure.GetMainSurgeryPersonnelBySurgery_Class>(queryDef, paramList, pi);
        }

        public static BindingList<MainSurgeryProcedure.GetMainSurgeryPersonnelBySurgery_Class> GetMainSurgeryPersonnelBySurgery(TTObjectContext objectContext, Guid SURGERY, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["MAINSURGERYPROCEDURE"].QueryDefs["GetMainSurgeryPersonnelBySurgery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("SURGERY", SURGERY);

            return TTReportNqlObject.QueryObjects<MainSurgeryProcedure.GetMainSurgeryPersonnelBySurgery_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<MainSurgeryProcedure.GetByMainSurgery_Class> GetByMainSurgery(Guid MAINSURGERY, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["MAINSURGERYPROCEDURE"].QueryDefs["GetByMainSurgery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("MAINSURGERY", MAINSURGERY);

            return TTReportNqlObject.QueryObjects<MainSurgeryProcedure.GetByMainSurgery_Class>(queryDef, paramList, pi);
        }

        public static BindingList<MainSurgeryProcedure.GetByMainSurgery_Class> GetByMainSurgery(TTObjectContext objectContext, Guid MAINSURGERY, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["MAINSURGERYPROCEDURE"].QueryDefs["GetByMainSurgery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("MAINSURGERY", MAINSURGERY);

            return TTReportNqlObject.QueryObjects<MainSurgeryProcedure.GetByMainSurgery_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<MainSurgeryProcedure.GetSurgeryProcedureCountByPatientGroupByDate_Class> GetSurgeryProcedureCountByPatientGroupByDate(DateTime STARTDATE, DateTime ENDDATE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["MAINSURGERYPROCEDURE"].QueryDefs["GetSurgeryProcedureCountByPatientGroupByDate"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);

            return TTReportNqlObject.QueryObjects<MainSurgeryProcedure.GetSurgeryProcedureCountByPatientGroupByDate_Class>(queryDef, paramList, pi);
        }

        public static BindingList<MainSurgeryProcedure.GetSurgeryProcedureCountByPatientGroupByDate_Class> GetSurgeryProcedureCountByPatientGroupByDate(TTObjectContext objectContext, DateTime STARTDATE, DateTime ENDDATE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["MAINSURGERYPROCEDURE"].QueryDefs["GetSurgeryProcedureCountByPatientGroupByDate"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);

            return TTReportNqlObject.QueryObjects<MainSurgeryProcedure.GetSurgeryProcedureCountByPatientGroupByDate_Class>(objectContext, queryDef, paramList, pi);
        }

        public Surgery MainSurgery
        {
            get { return (Surgery)((ITTObject)this).GetParent("MAINSURGERY"); }
            set { this["MAINSURGERY"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected MainSurgeryProcedure(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected MainSurgeryProcedure(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected MainSurgeryProcedure(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected MainSurgeryProcedure(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected MainSurgeryProcedure(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "MAINSURGERYPROCEDURE", dataRow) { }
        protected MainSurgeryProcedure(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "MAINSURGERYPROCEDURE", dataRow, isImported) { }
        public MainSurgeryProcedure(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public MainSurgeryProcedure(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public MainSurgeryProcedure() : base() { }

    }
}