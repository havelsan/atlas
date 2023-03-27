
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="PositionDefinition")] 

    /// <summary>
    /// Statü Tanımlama
    /// </summary>
    public  partial class PositionDefinition : TTDefinitionSet
    {
        public class PositionDefinitionList : TTObjectCollection<PositionDefinition> { }
                    
        public class ChildPositionDefinitionCollection : TTObject.TTChildObjectCollection<PositionDefinition>
        {
            public ChildPositionDefinitionCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildPositionDefinitionCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetPositionDefinitionNQL_Class : TTReportNqlObject 
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["POSITIONDEFINITION"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string ExternalCode
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["EXTERNALCODE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["POSITIONDEFINITION"].AllPropertyDefs["EXTERNALCODE"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string ShortName
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["SHORTNAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["POSITIONDEFINITION"].AllPropertyDefs["SHORTNAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public GetPositionDefinitionNQL_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetPositionDefinitionNQL_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetPositionDefinitionNQL_Class() : base() { }
        }

        public static BindingList<PositionDefinition> GetPositionDefinitionByExternalCode(TTObjectContext objectContext, string EXTERNALCODE)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["POSITIONDEFINITION"].QueryDefs["GetPositionDefinitionByExternalCode"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("EXTERNALCODE", EXTERNALCODE);

            return ((ITTQuery)objectContext).QueryObjects<PositionDefinition>(queryDef, paramList);
        }

        public static BindingList<PositionDefinition.GetPositionDefinitionNQL_Class> GetPositionDefinitionNQL(string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["POSITIONDEFINITION"].QueryDefs["GetPositionDefinitionNQL"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<PositionDefinition.GetPositionDefinitionNQL_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<PositionDefinition.GetPositionDefinitionNQL_Class> GetPositionDefinitionNQL(TTObjectContext objectContext, string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["POSITIONDEFINITION"].QueryDefs["GetPositionDefinitionNQL"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<PositionDefinition.GetPositionDefinitionNQL_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

    /// <summary>
    /// Kısa Adı
    /// </summary>
        public string ShortName
        {
            get { return (string)this["SHORTNAME"]; }
            set { this["SHORTNAME"] = value; }
        }

    /// <summary>
    /// Adı
    /// </summary>
        public string Name
        {
            get { return (string)this["NAME"]; }
            set { this["NAME"] = value; }
        }

    /// <summary>
    /// Harici Kodu
    /// </summary>
        public string ExternalCode
        {
            get { return (string)this["EXTERNALCODE"]; }
            set { this["EXTERNALCODE"] = value; }
        }

        public string Name_Shadow
        {
            get { return (string)this["NAME_SHADOW"]; }
        }

        public string ShortName_Shadow
        {
            get { return (string)this["SHORTNAME_SHADOW"]; }
        }

        protected PositionDefinition(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected PositionDefinition(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected PositionDefinition(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected PositionDefinition(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected PositionDefinition(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "POSITIONDEFINITION", dataRow) { }
        protected PositionDefinition(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "POSITIONDEFINITION", dataRow, isImported) { }
        public PositionDefinition(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public PositionDefinition(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public PositionDefinition() : base() { }

    }
}