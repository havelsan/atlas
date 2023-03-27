
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="NursingInitiativeDefinition")] 

    /// <summary>
    /// Hemşirelik Ağrı Değerlendirme Girişimi Tanımları
    /// </summary>
    public  partial class NursingInitiativeDefinition : TerminologyManagerDef
    {
        public class NursingInitiativeDefinitionList : TTObjectCollection<NursingInitiativeDefinition> { }
                    
        public class ChildNursingInitiativeDefinitionCollection : TTObject.TTChildObjectCollection<NursingInitiativeDefinition>
        {
            public ChildNursingInitiativeDefinitionCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildNursingInitiativeDefinitionCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetNursingInitiativeDef_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public string Initiative
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["INITIATIVE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["NURSINGINITIATIVEDEFINITION"].AllPropertyDefs["INITIATIVE"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public int? OrderNo
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ORDERNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["NURSINGINITIATIVEDEFINITION"].AllPropertyDefs["ORDERNO"].DataType;
                    return (int?)dataType.ConvertValue(val);
                }
            }

            public GetNursingInitiativeDef_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetNursingInitiativeDef_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetNursingInitiativeDef_Class() : base() { }
        }

        public static BindingList<NursingInitiativeDefinition.GetNursingInitiativeDef_Class> GetNursingInitiativeDef(string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["NURSINGINITIATIVEDEFINITION"].QueryDefs["GetNursingInitiativeDef"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<NursingInitiativeDefinition.GetNursingInitiativeDef_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<NursingInitiativeDefinition.GetNursingInitiativeDef_Class> GetNursingInitiativeDef(TTObjectContext objectContext, string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["NURSINGINITIATIVEDEFINITION"].QueryDefs["GetNursingInitiativeDef"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<NursingInitiativeDefinition.GetNursingInitiativeDef_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<NursingInitiativeDefinition> GetNursingInitiativeDefinition(TTObjectContext objectContext, string injectionSQL)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["NURSINGINITIATIVEDEFINITION"].QueryDefs["GetNursingInitiativeDefinition"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return ((ITTQuery)objectContext).QueryObjects<NursingInitiativeDefinition>(queryDef, paramList, injectionSQL);
        }

        public string Initiative
        {
            get { return (string)this["INITIATIVE"]; }
            set { this["INITIATIVE"] = value; }
        }

    /// <summary>
    /// Sıra
    /// </summary>
        public int? OrderNo
        {
            get { return (int?)this["ORDERNO"]; }
            set { this["ORDERNO"] = value; }
        }

        protected NursingInitiativeDefinition(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected NursingInitiativeDefinition(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected NursingInitiativeDefinition(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected NursingInitiativeDefinition(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected NursingInitiativeDefinition(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "NURSINGINITIATIVEDEFINITION", dataRow) { }
        protected NursingInitiativeDefinition(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "NURSINGINITIATIVEDEFINITION", dataRow, isImported) { }
        public NursingInitiativeDefinition(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public NursingInitiativeDefinition(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public NursingInitiativeDefinition() : base() { }

    }
}