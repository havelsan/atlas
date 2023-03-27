
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="ReferableResourceDefinition")] 

    public  partial class ReferableResourceDefinition : TerminologyManagerDef
    {
        public class ReferableResourceDefinitionList : TTObjectCollection<ReferableResourceDefinition> { }
                    
        public class ChildReferableResourceDefinitionCollection : TTObject.TTChildObjectCollection<ReferableResourceDefinition>
        {
            public ChildReferableResourceDefinitionCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildReferableResourceDefinitionCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetReferableResourceDefinition_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public ReferableActionEnum? ReferableAction
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["REFERABLEACTION"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["REFERABLERESOURCEDEFINITION"].AllPropertyDefs["REFERABLEACTION"].DataType;
                    return (ReferableActionEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public GetReferableResourceDefinition_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetReferableResourceDefinition_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetReferableResourceDefinition_Class() : base() { }
        }

        public static BindingList<ReferableResourceDefinition.GetReferableResourceDefinition_Class> GetReferableResourceDefinition(string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["REFERABLERESOURCEDEFINITION"].QueryDefs["GetReferableResourceDefinition"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<ReferableResourceDefinition.GetReferableResourceDefinition_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<ReferableResourceDefinition.GetReferableResourceDefinition_Class> GetReferableResourceDefinition(TTObjectContext objectContext, string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["REFERABLERESOURCEDEFINITION"].QueryDefs["GetReferableResourceDefinition"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<ReferableResourceDefinition.GetReferableResourceDefinition_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<ReferableResourceDefinition> GetReferableResourceDefByLastUpdateDate(TTObjectContext objectContext, DateTime STARTDATE, DateTime ENDDATE)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["REFERABLERESOURCEDEFINITION"].QueryDefs["GetReferableResourceDefByLastUpdateDate"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);

            return ((ITTQuery)objectContext).QueryObjects<ReferableResourceDefinition>(queryDef, paramList);
        }

        public ReferableActionEnum? ReferableAction
        {
            get { return (ReferableActionEnum?)(int?)this["REFERABLEACTION"]; }
            set { this["REFERABLEACTION"] = value; }
        }

        virtual protected void CreateReferableHospitalsCollection()
        {
            _ReferableHospitals = new ReferableHospital.ChildReferableHospitalCollection(this, new Guid("5c78b59b-b9ac-417d-9833-0e92786b2fba"));
            ((ITTChildObjectCollection)_ReferableHospitals).GetChildren();
        }

        protected ReferableHospital.ChildReferableHospitalCollection _ReferableHospitals = null;
    /// <summary>
    /// Child collection for Havale Edilebilen XXXXXXler
    /// </summary>
        public ReferableHospital.ChildReferableHospitalCollection ReferableHospitals
        {
            get
            {
                if (_ReferableHospitals == null)
                    CreateReferableHospitalsCollection();
                return _ReferableHospitals;
            }
        }

        protected ReferableResourceDefinition(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected ReferableResourceDefinition(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected ReferableResourceDefinition(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected ReferableResourceDefinition(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected ReferableResourceDefinition(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "REFERABLERESOURCEDEFINITION", dataRow) { }
        protected ReferableResourceDefinition(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "REFERABLERESOURCEDEFINITION", dataRow, isImported) { }
        public ReferableResourceDefinition(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public ReferableResourceDefinition(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public ReferableResourceDefinition() : base() { }

    }
}