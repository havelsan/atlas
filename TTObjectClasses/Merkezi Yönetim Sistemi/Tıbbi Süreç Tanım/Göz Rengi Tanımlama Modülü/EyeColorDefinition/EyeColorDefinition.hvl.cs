
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="EyeColorDefinition")] 

    /// <summary>
    /// Göz Rengi Tanımlama
    /// </summary>
    public  partial class EyeColorDefinition : TerminologyManagerDef
    {
        public class EyeColorDefinitionList : TTObjectCollection<EyeColorDefinition> { }
                    
        public class ChildEyeColorDefinitionCollection : TTObject.TTChildObjectCollection<EyeColorDefinition>
        {
            public ChildEyeColorDefinitionCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildEyeColorDefinitionCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetEyeColorDefinitionNQL_Class : TTReportNqlObject 
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["EYECOLORDEFINITION"].AllPropertyDefs["NAME"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["EYECOLORDEFINITION"].AllPropertyDefs["EXTERNALCODE"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public GetEyeColorDefinitionNQL_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetEyeColorDefinitionNQL_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetEyeColorDefinitionNQL_Class() : base() { }
        }

        public static BindingList<EyeColorDefinition> GetEyeColorByLastUpdateDate(TTObjectContext objectContext, DateTime STARTDATE, DateTime ENDDATE)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["EYECOLORDEFINITION"].QueryDefs["GetEyeColorByLastUpdateDate"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);

            return ((ITTQuery)objectContext).QueryObjects<EyeColorDefinition>(queryDef, paramList);
        }

        public static BindingList<EyeColorDefinition> GetEyeColorByExternalCode(TTObjectContext objectContext, string EXTERNALCODE)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["EYECOLORDEFINITION"].QueryDefs["GetEyeColorByExternalCode"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("EXTERNALCODE", EXTERNALCODE);

            return ((ITTQuery)objectContext).QueryObjects<EyeColorDefinition>(queryDef, paramList);
        }

        public static BindingList<EyeColorDefinition.GetEyeColorDefinitionNQL_Class> GetEyeColorDefinitionNQL(string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["EYECOLORDEFINITION"].QueryDefs["GetEyeColorDefinitionNQL"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<EyeColorDefinition.GetEyeColorDefinitionNQL_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<EyeColorDefinition.GetEyeColorDefinitionNQL_Class> GetEyeColorDefinitionNQL(TTObjectContext objectContext, string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["EYECOLORDEFINITION"].QueryDefs["GetEyeColorDefinitionNQL"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<EyeColorDefinition.GetEyeColorDefinitionNQL_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

    /// <summary>
    /// Harici Kodu
    /// </summary>
        public string ExternalCode
        {
            get { return (string)this["EXTERNALCODE"]; }
            set { this["EXTERNALCODE"] = value; }
        }

    /// <summary>
    /// Adı
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

        protected EyeColorDefinition(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected EyeColorDefinition(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected EyeColorDefinition(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected EyeColorDefinition(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected EyeColorDefinition(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "EYECOLORDEFINITION", dataRow) { }
        protected EyeColorDefinition(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "EYECOLORDEFINITION", dataRow, isImported) { }
        public EyeColorDefinition(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public EyeColorDefinition(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public EyeColorDefinition() : base() { }

    }
}