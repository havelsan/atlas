
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="SubSurgeryProcedure")] 

    public  partial class SubSurgeryProcedure : SurgeryProcedure
    {
        public class SubSurgeryProcedureList : TTObjectCollection<SubSurgeryProcedure> { }
                    
        public class ChildSubSurgeryProcedureCollection : TTObject.TTChildObjectCollection<SubSurgeryProcedure>
        {
            public ChildSubSurgeryProcedureCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildSubSurgeryProcedureCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetPersonnelBySubSurgery_Class : TTReportNqlObject 
        {
            public Guid? Subsurgeryprocedureobjectid
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["SUBSURGERYPROCEDUREOBJECTID"]);
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

            public GetPersonnelBySubSurgery_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetPersonnelBySubSurgery_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetPersonnelBySubSurgery_Class() : base() { }
        }

        [Serializable] 

        public partial class GetBySubSurgery_Class : TTReportNqlObject 
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

            public GetBySubSurgery_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetBySubSurgery_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetBySubSurgery_Class() : base() { }
        }

        new public static class States
        {
            public static Guid New { get { return new Guid("1c28a828-4470-46a5-af69-701b5322df1f"); } }
            public static Guid Completed { get { return new Guid("35536bbc-e567-46c8-be88-3bc9d65bfd5f"); } }
            public static Guid Cancelled { get { return new Guid("d16bf872-a7d1-476c-806d-92fd1852dccc"); } }
        }

        public static BindingList<SubSurgeryProcedure.GetPersonnelBySubSurgery_Class> GetPersonnelBySubSurgery(Guid SUBSURGERY, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["SUBSURGERYPROCEDURE"].QueryDefs["GetPersonnelBySubSurgery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("SUBSURGERY", SUBSURGERY);

            return TTReportNqlObject.QueryObjects<SubSurgeryProcedure.GetPersonnelBySubSurgery_Class>(queryDef, paramList, pi);
        }

        public static BindingList<SubSurgeryProcedure.GetPersonnelBySubSurgery_Class> GetPersonnelBySubSurgery(TTObjectContext objectContext, Guid SUBSURGERY, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["SUBSURGERYPROCEDURE"].QueryDefs["GetPersonnelBySubSurgery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("SUBSURGERY", SUBSURGERY);

            return TTReportNqlObject.QueryObjects<SubSurgeryProcedure.GetPersonnelBySubSurgery_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<SubSurgeryProcedure.GetBySubSurgery_Class> GetBySubSurgery(Guid SUBSURGERY, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["SUBSURGERYPROCEDURE"].QueryDefs["GetBySubSurgery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("SUBSURGERY", SUBSURGERY);

            return TTReportNqlObject.QueryObjects<SubSurgeryProcedure.GetBySubSurgery_Class>(queryDef, paramList, pi);
        }

        public static BindingList<SubSurgeryProcedure.GetBySubSurgery_Class> GetBySubSurgery(TTObjectContext objectContext, Guid SUBSURGERY, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["SUBSURGERYPROCEDURE"].QueryDefs["GetBySubSurgery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("SUBSURGERY", SUBSURGERY);

            return TTReportNqlObject.QueryObjects<SubSurgeryProcedure.GetBySubSurgery_Class>(objectContext, queryDef, paramList, pi);
        }

        public SubSurgery SubSurgery
        {
            get { return (SubSurgery)((ITTObject)this).GetParent("SUBSURGERY"); }
            set { this["SUBSURGERY"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected SubSurgeryProcedure(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected SubSurgeryProcedure(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected SubSurgeryProcedure(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected SubSurgeryProcedure(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected SubSurgeryProcedure(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "SUBSURGERYPROCEDURE", dataRow) { }
        protected SubSurgeryProcedure(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "SUBSURGERYPROCEDURE", dataRow, isImported) { }
        public SubSurgeryProcedure(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public SubSurgeryProcedure(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public SubSurgeryProcedure() : base() { }

    }
}