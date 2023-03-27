
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="UnitEnclosureDefinition")] 

    public  partial class UnitEnclosureDefinition : TerminologyManagerDef, ITMK
    {
        public class UnitEnclosureDefinitionList : TTObjectCollection<UnitEnclosureDefinition> { }
                    
        public class ChildUnitEnclosureDefinitionCollection : TTObject.TTChildObjectCollection<UnitEnclosureDefinition>
        {
            public ChildUnitEnclosureDefinitionCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildUnitEnclosureDefinitionCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetUnitEnclosureDefinitionList_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public string NAME
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["NAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["UNITENCLOSUREDEFINITION"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public GetUnitEnclosureDefinitionList_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetUnitEnclosureDefinitionList_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetUnitEnclosureDefinitionList_Class() : base() { }
        }

        [Serializable] 

        public partial class OLAP_GetUnitEnclosureDefinition_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public string NAME
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["NAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["UNITENCLOSUREDEFINITION"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public Guid? MilitaryUnit
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["MILITARYUNIT"]);
                }
            }

            public string YKDSXXXXXXID
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["YKDSXXXXXXID"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["UNITENCLOSUREDEFINITION"].AllPropertyDefs["YKDSXXXXXXID"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public OLAP_GetUnitEnclosureDefinition_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public OLAP_GetUnitEnclosureDefinition_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected OLAP_GetUnitEnclosureDefinition_Class() : base() { }
        }

        public static BindingList<UnitEnclosureDefinition.GetUnitEnclosureDefinitionList_Class> GetUnitEnclosureDefinitionList(string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["UNITENCLOSUREDEFINITION"].QueryDefs["GetUnitEnclosureDefinitionList"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<UnitEnclosureDefinition.GetUnitEnclosureDefinitionList_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<UnitEnclosureDefinition.GetUnitEnclosureDefinitionList_Class> GetUnitEnclosureDefinitionList(TTObjectContext objectContext, string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["UNITENCLOSUREDEFINITION"].QueryDefs["GetUnitEnclosureDefinitionList"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<UnitEnclosureDefinition.GetUnitEnclosureDefinitionList_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<UnitEnclosureDefinition.OLAP_GetUnitEnclosureDefinition_Class> OLAP_GetUnitEnclosureDefinition(PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["UNITENCLOSUREDEFINITION"].QueryDefs["OLAP_GetUnitEnclosureDefinition"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<UnitEnclosureDefinition.OLAP_GetUnitEnclosureDefinition_Class>(queryDef, paramList, pi);
        }

        public static BindingList<UnitEnclosureDefinition.OLAP_GetUnitEnclosureDefinition_Class> OLAP_GetUnitEnclosureDefinition(TTObjectContext objectContext, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["UNITENCLOSUREDEFINITION"].QueryDefs["OLAP_GetUnitEnclosureDefinition"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<UnitEnclosureDefinition.OLAP_GetUnitEnclosureDefinition_Class>(objectContext, queryDef, paramList, pi);
        }

        public string NAME
        {
            get { return (string)this["NAME"]; }
            set { this["NAME"] = value; }
        }

        public int? SEQUENCE
        {
            get { return (int?)this["SEQUENCE"]; }
            set { this["SEQUENCE"] = value; }
        }

        public string DESCRIPTION
        {
            get { return (string)this["DESCRIPTION"]; }
            set { this["DESCRIPTION"] = value; }
        }

    /// <summary>
    /// Site İp
    /// </summary>
        public string SITEIP
        {
            get { return (string)this["SITEIP"]; }
            set { this["SITEIP"] = value; }
        }

        public int? USETHISORG
        {
            get { return (int?)this["USETHISORG"]; }
            set { this["USETHISORG"] = value; }
        }

    /// <summary>
    /// Ykds XXXXXX Id
    /// </summary>
        public string YKDSXXXXXXID
        {
            get { return (string)this["YKDSXXXXXXID"]; }
            set { this["YKDSXXXXXXID"] = value; }
        }

        public MilitaryUnit MilitaryUnit
        {
            get { return (MilitaryUnit)((ITTObject)this).GetParent("MILITARYUNIT"); }
            set { this["MILITARYUNIT"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public UnitEnclosureDefinition ParentId
        {
            get { return (UnitEnclosureDefinition)((ITTObject)this).GetParent("PARENTID"); }
            set { this["PARENTID"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected UnitEnclosureDefinition(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected UnitEnclosureDefinition(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected UnitEnclosureDefinition(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected UnitEnclosureDefinition(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected UnitEnclosureDefinition(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "UNITENCLOSUREDEFINITION", dataRow) { }
        protected UnitEnclosureDefinition(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "UNITENCLOSUREDEFINITION", dataRow, isImported) { }
        public UnitEnclosureDefinition(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public UnitEnclosureDefinition(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public UnitEnclosureDefinition() : base() { }

    }
}