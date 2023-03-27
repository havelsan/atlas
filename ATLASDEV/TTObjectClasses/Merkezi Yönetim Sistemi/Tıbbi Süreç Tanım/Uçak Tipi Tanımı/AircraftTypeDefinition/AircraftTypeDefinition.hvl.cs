
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="AircraftTypeDefinition")] 

    /// <summary>
    /// Uçak Tipi Tanımı
    /// </summary>
    public  partial class AircraftTypeDefinition : TerminologyManagerDef
    {
        public class AircraftTypeDefinitionList : TTObjectCollection<AircraftTypeDefinition> { }
                    
        public class ChildAircraftTypeDefinitionCollection : TTObject.TTChildObjectCollection<AircraftTypeDefinition>
        {
            public ChildAircraftTypeDefinitionCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildAircraftTypeDefinitionCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetAircraftTypeDefinitions_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public long? Code
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["CODE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["AIRCRAFTTYPEDEFINITION"].AllPropertyDefs["CODE"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public string Name
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["NAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["AIRCRAFTTYPEDEFINITION"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public GetAircraftTypeDefinitions_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetAircraftTypeDefinitions_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetAircraftTypeDefinitions_Class() : base() { }
        }

        public static BindingList<AircraftTypeDefinition> GetAircraftTypeDefByLastUpdateDate(TTObjectContext objectContext, DateTime STARTDATE, DateTime ENDDATE)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["AIRCRAFTTYPEDEFINITION"].QueryDefs["GetAircraftTypeDefByLastUpdateDate"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);

            return ((ITTQuery)objectContext).QueryObjects<AircraftTypeDefinition>(queryDef, paramList);
        }

        public static BindingList<AircraftTypeDefinition.GetAircraftTypeDefinitions_Class> GetAircraftTypeDefinitions(string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["AIRCRAFTTYPEDEFINITION"].QueryDefs["GetAircraftTypeDefinitions"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<AircraftTypeDefinition.GetAircraftTypeDefinitions_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<AircraftTypeDefinition.GetAircraftTypeDefinitions_Class> GetAircraftTypeDefinitions(TTObjectContext objectContext, string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["AIRCRAFTTYPEDEFINITION"].QueryDefs["GetAircraftTypeDefinitions"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<AircraftTypeDefinition.GetAircraftTypeDefinitions_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

    /// <summary>
    /// Kod
    /// </summary>
        public long? Code
        {
            get { return (long?)this["CODE"]; }
            set { this["CODE"] = value; }
        }

    /// <summary>
    /// Ad
    /// </summary>
        public string Name
        {
            get { return (string)this["NAME"]; }
            set { this["NAME"] = value; }
        }

        public string Name_Shadow
        {
            get { return (string)this["NAME_SHADOW"]; }
        }

        protected AircraftTypeDefinition(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected AircraftTypeDefinition(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected AircraftTypeDefinition(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected AircraftTypeDefinition(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected AircraftTypeDefinition(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "AIRCRAFTTYPEDEFINITION", dataRow) { }
        protected AircraftTypeDefinition(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "AIRCRAFTTYPEDEFINITION", dataRow, isImported) { }
        protected AircraftTypeDefinition(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public AircraftTypeDefinition(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public AircraftTypeDefinition() : base() { }

    }
}