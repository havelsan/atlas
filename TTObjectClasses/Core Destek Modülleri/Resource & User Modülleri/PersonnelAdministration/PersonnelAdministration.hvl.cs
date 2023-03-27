
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="PersonnelAdministration")] 

    public  partial class PersonnelAdministration : TTObject
    {
        public class PersonnelAdministrationList : TTObjectCollection<PersonnelAdministration> { }
                    
        public class ChildPersonnelAdministrationCollection : TTObject.TTChildObjectCollection<PersonnelAdministration>
        {
            public ChildPersonnelAdministrationCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildPersonnelAdministrationCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetByIntegrationID_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public Guid? ObjectDefID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTDEFID"]);
                }
            }

            public Guid? CurrentStateDefID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["CURRENTSTATEDEFID"]);
                }
            }

            public DateTime? LastUpdate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["LASTUPDATE"]);
                    if (val == null)
                        return null;
                    return (DateTime)Convert.ChangeType(val, typeof(DateTime)); 
                }
            }

            public string Definition
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DEFINITION"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PERSONNELADMINISTRATION"].AllPropertyDefs["DEFINITION"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string IntegrationVersion
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["INTEGRATIONVERSION"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PERSONNELADMINISTRATION"].AllPropertyDefs["INTEGRATIONVERSION"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string IntegrationId
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["INTEGRATIONID"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PERSONNELADMINISTRATION"].AllPropertyDefs["INTEGRATIONID"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public bool? IsActive
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ISACTIVE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PERSONNELADMINISTRATION"].AllPropertyDefs["ISACTIVE"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public bool? ResUserAdministrationWorkType
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["RESUSERADMINISTRATIONWORKTYPE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PERSONNELADMINISTRATION"].AllPropertyDefs["RESUSERADMINISTRATIONWORKTYPE"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public string UniqueRefNo
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["UNIQUEREFNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PERSONNELADMINISTRATION"].AllPropertyDefs["UNIQUEREFNO"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public GetByIntegrationID_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetByIntegrationID_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetByIntegrationID_Class() : base() { }
        }

        public static BindingList<PersonnelAdministration.GetByIntegrationID_Class> GetByIntegrationID(string INTEGRATIONIDPARAM, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PERSONNELADMINISTRATION"].QueryDefs["GetByIntegrationID"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("INTEGRATIONIDPARAM", INTEGRATIONIDPARAM);

            return TTReportNqlObject.QueryObjects<PersonnelAdministration.GetByIntegrationID_Class>(queryDef, paramList, pi);
        }

        public static BindingList<PersonnelAdministration.GetByIntegrationID_Class> GetByIntegrationID(TTObjectContext objectContext, string INTEGRATIONIDPARAM, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PERSONNELADMINISTRATION"].QueryDefs["GetByIntegrationID"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("INTEGRATIONIDPARAM", INTEGRATIONIDPARAM);

            return TTReportNqlObject.QueryObjects<PersonnelAdministration.GetByIntegrationID_Class>(objectContext, queryDef, paramList, pi);
        }

        public string Definition
        {
            get { return (string)this["DEFINITION"]; }
            set { this["DEFINITION"] = value; }
        }

        public string IntegrationVersion
        {
            get { return (string)this["INTEGRATIONVERSION"]; }
            set { this["INTEGRATIONVERSION"] = value; }
        }

        public string IntegrationId
        {
            get { return (string)this["INTEGRATIONID"]; }
            set { this["INTEGRATIONID"] = value; }
        }

        public bool? IsActive
        {
            get { return (bool?)this["ISACTIVE"]; }
            set { this["ISACTIVE"] = value; }
        }

        public bool? ResUserAdministrationWorkType
        {
            get { return (bool?)this["RESUSERADMINISTRATIONWORKTYPE"]; }
            set { this["RESUSERADMINISTRATIONWORKTYPE"] = value; }
        }

        public string UniqueRefNo
        {
            get { return (string)this["UNIQUEREFNO"]; }
            set { this["UNIQUEREFNO"] = value; }
        }

        public TakeOffDatetime EndDate
        {
            get { return (TakeOffDatetime)((ITTObject)this).GetParent("ENDDATE"); }
            set { this["ENDDATE"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public MHRSActionTypeDefinition MHRSActionType
        {
            get { return (MHRSActionTypeDefinition)((ITTObject)this).GetParent("MHRSACTIONTYPE"); }
            set { this["MHRSACTIONTYPE"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public ResUser ResUser
        {
            get { return (ResUser)((ITTObject)this).GetParent("RESUSER"); }
            set { this["RESUSER"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public TakeOffDatetime StartDate
        {
            get { return (TakeOffDatetime)((ITTObject)this).GetParent("STARTDATE"); }
            set { this["STARTDATE"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected PersonnelAdministration(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected PersonnelAdministration(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected PersonnelAdministration(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected PersonnelAdministration(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected PersonnelAdministration(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "PERSONNELADMINISTRATION", dataRow) { }
        protected PersonnelAdministration(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "PERSONNELADMINISTRATION", dataRow, isImported) { }
        public PersonnelAdministration(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public PersonnelAdministration(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public PersonnelAdministration() : base() { }

    }
}