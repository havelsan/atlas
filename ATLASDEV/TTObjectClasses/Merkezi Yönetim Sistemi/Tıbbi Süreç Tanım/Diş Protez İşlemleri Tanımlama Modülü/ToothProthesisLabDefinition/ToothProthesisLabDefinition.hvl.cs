
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="ToothProthesisLabDefinition")] 

    /// <summary>
    /// Diş Protez Labaratuvar Tanım Ekranı
    /// </summary>
    public  partial class ToothProthesisLabDefinition : TTDefinitionSet
    {
        public class ToothProthesisLabDefinitionList : TTObjectCollection<ToothProthesisLabDefinition> { }
                    
        public class ChildToothProthesisLabDefinitionCollection : TTObject.TTChildObjectCollection<ToothProthesisLabDefinition>
        {
            public ChildToothProthesisLabDefinitionCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildToothProthesisLabDefinitionCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetToothProthesisLabDefinitionNQL_Class : TTReportNqlObject 
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["TOOTHPROTHESISLABDEFINITION"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public GetToothProthesisLabDefinitionNQL_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetToothProthesisLabDefinitionNQL_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetToothProthesisLabDefinitionNQL_Class() : base() { }
        }

        public static BindingList<ToothProthesisLabDefinition> GetToothProthesisLabDefinitionFormByLastUpdateDate(TTObjectContext objectContext, DateTime ENDDATE, DateTime STARTDATE)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["TOOTHPROTHESISLABDEFINITION"].QueryDefs["GetToothProthesisLabDefinitionFormByLastUpdateDate"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("ENDDATE", ENDDATE);
            paramList.Add("STARTDATE", STARTDATE);

            return ((ITTQuery)objectContext).QueryObjects<ToothProthesisLabDefinition>(queryDef, paramList);
        }

        public static BindingList<ToothProthesisLabDefinition.GetToothProthesisLabDefinitionNQL_Class> GetToothProthesisLabDefinitionNQL(string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["TOOTHPROTHESISLABDEFINITION"].QueryDefs["GetToothProthesisLabDefinitionNQL"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<ToothProthesisLabDefinition.GetToothProthesisLabDefinitionNQL_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<ToothProthesisLabDefinition.GetToothProthesisLabDefinitionNQL_Class> GetToothProthesisLabDefinitionNQL(TTObjectContext objectContext, string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["TOOTHPROTHESISLABDEFINITION"].QueryDefs["GetToothProthesisLabDefinitionNQL"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<ToothProthesisLabDefinition.GetToothProthesisLabDefinitionNQL_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

    /// <summary>
    /// Adı
    /// </summary>
        public string Name
        {
            get { return (string)this["NAME"]; }
            set { this["NAME"] = value; }
        }

        protected ToothProthesisLabDefinition(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected ToothProthesisLabDefinition(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected ToothProthesisLabDefinition(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected ToothProthesisLabDefinition(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected ToothProthesisLabDefinition(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "TOOTHPROTHESISLABDEFINITION", dataRow) { }
        protected ToothProthesisLabDefinition(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "TOOTHPROTHESISLABDEFINITION", dataRow, isImported) { }
        public ToothProthesisLabDefinition(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public ToothProthesisLabDefinition(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public ToothProthesisLabDefinition() : base() { }

    }
}