
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="VitalSignAndNursingDefinition")] 

    /// <summary>
    /// Vital Bulgu ve Hemşirelik İşlemleri Tanımlama
    /// </summary>
    public  partial class VitalSignAndNursingDefinition : ProcedureDefinition
    {
        public class VitalSignAndNursingDefinitionList : TTObjectCollection<VitalSignAndNursingDefinition> { }
                    
        public class ChildVitalSignAndNursingDefinitionCollection : TTObject.TTChildObjectCollection<VitalSignAndNursingDefinition>
        {
            public ChildVitalSignAndNursingDefinitionCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildVitalSignAndNursingDefinitionCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetVitalSignAndNursingDefinition_Class : TTReportNqlObject 
        {
            public long? ID
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ID"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["VITALSIGNANDNURSINGDEFINITION"].AllPropertyDefs["ID"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public string Code
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["CODE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["VITALSIGNANDNURSINGDEFINITION"].AllPropertyDefs["CODE"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Name
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["NAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["VITALSIGNANDNURSINGDEFINITION"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string EnglishName
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ENGLISHNAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["VITALSIGNANDNURSINGDEFINITION"].AllPropertyDefs["ENGLISHNAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Proceduretree
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PROCEDURETREE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PROCEDURETREEDEFINITION"].AllPropertyDefs["DESCRIPTION"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Qref
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["QREF"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["VITALSIGNANDNURSINGDEFINITION"].AllPropertyDefs["QREF"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public bool? Chargable
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["CHARGABLE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["VITALSIGNANDNURSINGDEFINITION"].AllPropertyDefs["CHARGABLE"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public Boolean? IsActive
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ISACTIVE"]);
                    if (val == null)
                        return null;
                    return (Boolean)Convert.ChangeType(val, typeof(Boolean)); 
                }
            }

            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public GetVitalSignAndNursingDefinition_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetVitalSignAndNursingDefinition_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetVitalSignAndNursingDefinition_Class() : base() { }
        }

        public static BindingList<VitalSignAndNursingDefinition> GetVitalSignAndNursDefByLastUpdateDate(TTObjectContext objectContext, DateTime STARTDATE, DateTime ENDDATE)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["VITALSIGNANDNURSINGDEFINITION"].QueryDefs["GetVitalSignAndNursDefByLastUpdateDate"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);

            return ((ITTQuery)objectContext).QueryObjects<VitalSignAndNursingDefinition>(queryDef, paramList);
        }

        public static BindingList<VitalSignAndNursingDefinition.GetVitalSignAndNursingDefinition_Class> GetVitalSignAndNursingDefinition(string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["VITALSIGNANDNURSINGDEFINITION"].QueryDefs["GetVitalSignAndNursingDefinition"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<VitalSignAndNursingDefinition.GetVitalSignAndNursingDefinition_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<VitalSignAndNursingDefinition.GetVitalSignAndNursingDefinition_Class> GetVitalSignAndNursingDefinition(TTObjectContext objectContext, string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["VITALSIGNANDNURSINGDEFINITION"].QueryDefs["GetVitalSignAndNursingDefinition"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<VitalSignAndNursingDefinition.GetVitalSignAndNursingDefinition_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<VitalSignAndNursingDefinition> GetAllVitalSignAndNursingDefinitions(TTObjectContext objectContext)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["VITALSIGNANDNURSINGDEFINITION"].QueryDefs["GetAllVitalSignAndNursingDefinitions"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return ((ITTQuery)objectContext).QueryObjects<VitalSignAndNursingDefinition>(queryDef, paramList);
        }

        public bool? DontNeedDataDuringApplication
        {
            get { return (bool?)this["DONTNEEDDATADURINGAPPLICATION"]; }
            set { this["DONTNEEDDATADURINGAPPLICATION"] = value; }
        }

        public VitalSignType? VitalSignType
        {
            get { return (VitalSignType?)(int?)this["VITALSIGNTYPE"]; }
            set { this["VITALSIGNTYPE"] = value; }
        }

        virtual protected void CreateValuesCollection()
        {
            _Values = new VitalSignAndNursingValueDefinition.ChildVitalSignAndNursingValueDefinitionCollection(this, new Guid("fe8a88c3-e360-4fcb-9a1c-348cd12505a9"));
            ((ITTChildObjectCollection)_Values).GetChildren();
        }

        protected VitalSignAndNursingValueDefinition.ChildVitalSignAndNursingValueDefinitionCollection _Values = null;
        public VitalSignAndNursingValueDefinition.ChildVitalSignAndNursingValueDefinitionCollection Values
        {
            get
            {
                if (_Values == null)
                    CreateValuesCollection();
                return _Values;
            }
        }

        protected VitalSignAndNursingDefinition(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected VitalSignAndNursingDefinition(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected VitalSignAndNursingDefinition(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected VitalSignAndNursingDefinition(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected VitalSignAndNursingDefinition(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "VITALSIGNANDNURSINGDEFINITION", dataRow) { }
        protected VitalSignAndNursingDefinition(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "VITALSIGNANDNURSINGDEFINITION", dataRow, isImported) { }
        protected VitalSignAndNursingDefinition(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public VitalSignAndNursingDefinition(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public VitalSignAndNursingDefinition() : base() { }

    }
}