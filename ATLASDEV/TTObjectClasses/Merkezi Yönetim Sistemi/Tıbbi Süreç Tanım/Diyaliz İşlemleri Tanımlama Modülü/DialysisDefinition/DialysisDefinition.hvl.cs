
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="DialysisDefinition")] 

    /// <summary>
    /// Diyaliz İşlemleri Tanımlama
    /// </summary>
    public  partial class DialysisDefinition : ProcedureDefinition
    {
        public class DialysisDefinitionList : TTObjectCollection<DialysisDefinition> { }
                    
        public class ChildDialysisDefinitionCollection : TTObject.TTChildObjectCollection<DialysisDefinition>
        {
            public ChildDialysisDefinitionCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildDialysisDefinitionCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetDialysisDefinition_Class : TTReportNqlObject 
        {
            public long? ID
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ID"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DIALYSISDEFINITION"].AllPropertyDefs["ID"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DIALYSISDEFINITION"].AllPropertyDefs["CODE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DIALYSISDEFINITION"].AllPropertyDefs["NAME"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DIALYSISDEFINITION"].AllPropertyDefs["ENGLISHNAME"].DataType;
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

            public int? TreatmentDuration
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["TREATMENTDURATION"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DIALYSISDEFINITION"].AllPropertyDefs["TREATMENTDURATION"].DataType;
                    return (int?)dataType.ConvertValue(val);
                }
            }

            public string Qref
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["QREF"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DIALYSISDEFINITION"].AllPropertyDefs["QREF"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DIALYSISDEFINITION"].AllPropertyDefs["CHARGABLE"].DataType;
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

            public GetDialysisDefinition_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetDialysisDefinition_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetDialysisDefinition_Class() : base() { }
        }

        public static BindingList<DialysisDefinition.GetDialysisDefinition_Class> GetDialysisDefinition(string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["DIALYSISDEFINITION"].QueryDefs["GetDialysisDefinition"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<DialysisDefinition.GetDialysisDefinition_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<DialysisDefinition.GetDialysisDefinition_Class> GetDialysisDefinition(TTObjectContext objectContext, string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["DIALYSISDEFINITION"].QueryDefs["GetDialysisDefinition"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<DialysisDefinition.GetDialysisDefinition_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<DialysisDefinition> GetDialysisDefinitionByLastUpdateDate(TTObjectContext objectContext, DateTime STARTDATE, DateTime ENDDATE)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["DIALYSISDEFINITION"].QueryDefs["GetDialysisDefinitionByLastUpdateDate"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);

            return ((ITTQuery)objectContext).QueryObjects<DialysisDefinition>(queryDef, paramList);
        }

    /// <summary>
    /// Tedavi Süresi
    /// </summary>
        public int? TreatmentDuration
        {
            get { return (int?)this["TREATMENTDURATION"]; }
            set { this["TREATMENTDURATION"] = value; }
        }

        virtual protected void CreateTreatmentUnitsCollection()
        {
            _TreatmentUnits = new DialysisTreatmentUnitGrid.ChildDialysisTreatmentUnitGridCollection(this, new Guid("045312bd-3448-4d3a-b973-0a0bec493baf"));
            ((ITTChildObjectCollection)_TreatmentUnits).GetChildren();
        }

        protected DialysisTreatmentUnitGrid.ChildDialysisTreatmentUnitGridCollection _TreatmentUnits = null;
    /// <summary>
    /// Child collection for Tanı Tedavi Üniteleri
    /// </summary>
        public DialysisTreatmentUnitGrid.ChildDialysisTreatmentUnitGridCollection TreatmentUnits
        {
            get
            {
                if (_TreatmentUnits == null)
                    CreateTreatmentUnitsCollection();
                return _TreatmentUnits;
            }
        }

        virtual protected void CreateUsedMaterialsCollection()
        {
            _UsedMaterials = new DialysisUsedMaterialGrid.ChildDialysisUsedMaterialGridCollection(this, new Guid("96c8b257-6712-495a-94b1-4b124e2b0fff"));
            ((ITTChildObjectCollection)_UsedMaterials).GetChildren();
        }

        protected DialysisUsedMaterialGrid.ChildDialysisUsedMaterialGridCollection _UsedMaterials = null;
    /// <summary>
    /// Child collection for Diyalizde Kullanılan Malzemeler
    /// </summary>
        public DialysisUsedMaterialGrid.ChildDialysisUsedMaterialGridCollection UsedMaterials
        {
            get
            {
                if (_UsedMaterials == null)
                    CreateUsedMaterialsCollection();
                return _UsedMaterials;
            }
        }

        virtual protected void CreateDialysisTreatmentEquipmentsCollection()
        {
            _DialysisTreatmentEquipments = new DialysisTreatmentEquipmentGrid.ChildDialysisTreatmentEquipmentGridCollection(this, new Guid("92e59be5-f471-4ebf-821a-9407dd0f89bd"));
            ((ITTChildObjectCollection)_DialysisTreatmentEquipments).GetChildren();
        }

        protected DialysisTreatmentEquipmentGrid.ChildDialysisTreatmentEquipmentGridCollection _DialysisTreatmentEquipments = null;
    /// <summary>
    /// Child collection for Tedavi Cihazı
    /// </summary>
        public DialysisTreatmentEquipmentGrid.ChildDialysisTreatmentEquipmentGridCollection DialysisTreatmentEquipments
        {
            get
            {
                if (_DialysisTreatmentEquipments == null)
                    CreateDialysisTreatmentEquipmentsCollection();
                return _DialysisTreatmentEquipments;
            }
        }

        protected DialysisDefinition(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected DialysisDefinition(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected DialysisDefinition(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected DialysisDefinition(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected DialysisDefinition(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "DIALYSISDEFINITION", dataRow) { }
        protected DialysisDefinition(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "DIALYSISDEFINITION", dataRow, isImported) { }
        public DialysisDefinition(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public DialysisDefinition(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public DialysisDefinition() : base() { }

    }
}