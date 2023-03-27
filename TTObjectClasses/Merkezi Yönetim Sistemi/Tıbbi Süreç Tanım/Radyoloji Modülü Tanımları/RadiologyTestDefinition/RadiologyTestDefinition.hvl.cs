
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="RadiologyTestDefinition")] 

    /// <summary>
    /// Radyoloji Tetkik Tanımları
    /// </summary>
    public  partial class RadiologyTestDefinition : ProcedureDefinition, IProcedureRequestDefinition
    {
        public class RadiologyTestDefinitionList : TTObjectCollection<RadiologyTestDefinition> { }
                    
        public class ChildRadiologyTestDefinitionCollection : TTObject.TTChildObjectCollection<RadiologyTestDefinition>
        {
            public ChildRadiologyTestDefinitionCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildRadiologyTestDefinitionCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetRadiologyTestDefinitionNQL_Class : TTReportNqlObject 
        {
            public string Code
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["CODE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RADIOLOGYTESTDEFINITION"].AllPropertyDefs["CODE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RADIOLOGYTESTDEFINITION"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
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

            public string SUTCode
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["SUTCODE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RADIOLOGYTESTDEFINITION"].AllPropertyDefs["SUTCODE"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public GetRadiologyTestDefinitionNQL_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetRadiologyTestDefinitionNQL_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetRadiologyTestDefinitionNQL_Class() : base() { }
        }

        [Serializable] 

        public partial class GetRadiologyTestDescriptionReportNQL_Class : TTReportNqlObject 
        {
            public string Name
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["NAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RADIOLOGYTESTDEFINITION"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Testdescription
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["TESTDESCRIPTION"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RADIOLOGYTESTDESCRIPTIONDEFINITION"].AllPropertyDefs["DESCRIPTION"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public GetRadiologyTestDescriptionReportNQL_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetRadiologyTestDescriptionReportNQL_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetRadiologyTestDescriptionReportNQL_Class() : base() { }
        }

        [Serializable] 

        public partial class OLAP_GetRadiologyTestDef_Class : TTReportNqlObject 
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RADIOLOGYTESTDEFINITION"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public Guid? ProcedureTree
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["PROCEDURETREE"]);
                }
            }

            public string Testtype
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["TESTTYPE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RADIOLOGYTESTTYPEDEFINITION"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public OLAP_GetRadiologyTestDef_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public OLAP_GetRadiologyTestDef_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected OLAP_GetRadiologyTestDef_Class() : base() { }
        }

        [Serializable] 

        public partial class OLAP_GetradiologyTestDef_WithDate_Class : TTReportNqlObject 
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RADIOLOGYTESTDEFINITION"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public Guid? ProcedureTree
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["PROCEDURETREE"]);
                }
            }

            public string Testtype
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["TESTTYPE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RADIOLOGYTESTTYPEDEFINITION"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public OLAP_GetradiologyTestDef_WithDate_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public OLAP_GetradiologyTestDef_WithDate_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected OLAP_GetradiologyTestDef_WithDate_Class() : base() { }
        }

        public static BindingList<RadiologyTestDefinition.GetRadiologyTestDefinitionNQL_Class> GetRadiologyTestDefinitionNQL(string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["RADIOLOGYTESTDEFINITION"].QueryDefs["GetRadiologyTestDefinitionNQL"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<RadiologyTestDefinition.GetRadiologyTestDefinitionNQL_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<RadiologyTestDefinition.GetRadiologyTestDefinitionNQL_Class> GetRadiologyTestDefinitionNQL(TTObjectContext objectContext, string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["RADIOLOGYTESTDEFINITION"].QueryDefs["GetRadiologyTestDefinitionNQL"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<RadiologyTestDefinition.GetRadiologyTestDefinitionNQL_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<RadiologyTestDefinition.GetRadiologyTestDescriptionReportNQL_Class> GetRadiologyTestDescriptionReportNQL(string PARAMOBJDEFID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["RADIOLOGYTESTDEFINITION"].QueryDefs["GetRadiologyTestDescriptionReportNQL"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("PARAMOBJDEFID", PARAMOBJDEFID);

            return TTReportNqlObject.QueryObjects<RadiologyTestDefinition.GetRadiologyTestDescriptionReportNQL_Class>(queryDef, paramList, pi);
        }

        public static BindingList<RadiologyTestDefinition.GetRadiologyTestDescriptionReportNQL_Class> GetRadiologyTestDescriptionReportNQL(TTObjectContext objectContext, string PARAMOBJDEFID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["RADIOLOGYTESTDEFINITION"].QueryDefs["GetRadiologyTestDescriptionReportNQL"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("PARAMOBJDEFID", PARAMOBJDEFID);

            return TTReportNqlObject.QueryObjects<RadiologyTestDefinition.GetRadiologyTestDescriptionReportNQL_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<RadiologyTestDefinition.OLAP_GetRadiologyTestDef_Class> OLAP_GetRadiologyTestDef(PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["RADIOLOGYTESTDEFINITION"].QueryDefs["OLAP_GetRadiologyTestDef"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<RadiologyTestDefinition.OLAP_GetRadiologyTestDef_Class>(queryDef, paramList, pi);
        }

        public static BindingList<RadiologyTestDefinition.OLAP_GetRadiologyTestDef_Class> OLAP_GetRadiologyTestDef(TTObjectContext objectContext, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["RADIOLOGYTESTDEFINITION"].QueryDefs["OLAP_GetRadiologyTestDef"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<RadiologyTestDefinition.OLAP_GetRadiologyTestDef_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<RadiologyTestDefinition.OLAP_GetradiologyTestDef_WithDate_Class> OLAP_GetradiologyTestDef_WithDate(DateTime LASTDATE, DateTime FIRSTDATE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["RADIOLOGYTESTDEFINITION"].QueryDefs["OLAP_GetradiologyTestDef_WithDate"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("LASTDATE", LASTDATE);
            paramList.Add("FIRSTDATE", FIRSTDATE);

            return TTReportNqlObject.QueryObjects<RadiologyTestDefinition.OLAP_GetradiologyTestDef_WithDate_Class>(queryDef, paramList, pi);
        }

        public static BindingList<RadiologyTestDefinition.OLAP_GetradiologyTestDef_WithDate_Class> OLAP_GetradiologyTestDef_WithDate(TTObjectContext objectContext, DateTime LASTDATE, DateTime FIRSTDATE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["RADIOLOGYTESTDEFINITION"].QueryDefs["OLAP_GetradiologyTestDef_WithDate"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("LASTDATE", LASTDATE);
            paramList.Add("FIRSTDATE", FIRSTDATE);

            return TTReportNqlObject.QueryObjects<RadiologyTestDefinition.OLAP_GetradiologyTestDef_WithDate_Class>(objectContext, queryDef, paramList, pi);
        }

        public bool? OnMonday
        {
            get { return (bool?)this["ONMONDAY"]; }
            set { this["ONMONDAY"] = value; }
        }

    /// <summary>
    /// Tab Açıklaması
    /// </summary>
        public string TabDescription
        {
            get { return (string)this["TABDESCRIPTION"]; }
            set { this["TABDESCRIPTION"] = value; }
        }

        public bool? OnTuesday
        {
            get { return (bool?)this["ONTUESDAY"]; }
            set { this["ONTUESDAY"] = value; }
        }

        public bool? OnWednesday
        {
            get { return (bool?)this["ONWEDNESDAY"]; }
            set { this["ONWEDNESDAY"] = value; }
        }

    /// <summary>
    /// Tetkik Çekim Süresi
    /// </summary>
        public int? ProcedureTime
        {
            get { return (int?)this["PROCEDURETIME"]; }
            set { this["PROCEDURETIME"] = value; }
        }

    /// <summary>
    /// Kısıtlamalı Tetkik
    /// </summary>
        public bool? IsRestrictedTest
        {
            get { return (bool?)this["ISRESTRICTEDTEST"]; }
            set { this["ISRESTRICTEDTEST"] = value; }
        }

    /// <summary>
    /// Süre Kontrolü
    /// </summary>
        public int? TimeLimit
        {
            get { return (int?)this["TIMELIMIT"]; }
            set { this["TIMELIMIT"] = value; }
        }

        public bool? OnThursday
        {
            get { return (bool?)this["ONTHURSDAY"]; }
            set { this["ONTHURSDAY"] = value; }
        }

        public bool? OnSaturday
        {
            get { return (bool?)this["ONSATURDAY"]; }
            set { this["ONSATURDAY"] = value; }
        }

    /// <summary>
    /// Başlık
    /// </summary>
        public bool? IsHeader
        {
            get { return (bool?)this["ISHEADER"]; }
            set { this["ISHEADER"] = value; }
        }

    /// <summary>
    /// Tab Sırası
    /// </summary>
        public int? TabRow
        {
            get { return (int?)this["TABROW"]; }
            set { this["TABROW"] = value; }
        }

        public bool? OnSunday
        {
            get { return (bool?)this["ONSUNDAY"]; }
            set { this["ONSUNDAY"] = value; }
        }

    /// <summary>
    /// Tab Adı
    /// </summary>
        public string TabName
        {
            get { return (string)this["TABNAME"]; }
            set { this["TABNAME"] = value; }
        }

    /// <summary>
    /// Vücut Bölgesi
    /// </summary>
        public RadiologyBodyPartEnum? BodyPart
        {
            get { return (RadiologyBodyPartEnum?)(int?)this["BODYPART"]; }
            set { this["BODYPART"] = value; }
        }

        public bool? OnFriday
        {
            get { return (bool?)this["ONFRIDAY"]; }
            set { this["ONFRIDAY"] = value; }
        }

    /// <summary>
    /// Cinsiyet Kontrolü
    /// </summary>
        public SexEnum? SexControl
        {
            get { return (SexEnum?)(int?)this["SEXCONTROL"]; }
            set { this["SEXCONTROL"] = value; }
        }

    /// <summary>
    /// Medulaya Accession No ve Modality bilgisi gönderilmeli
    /// </summary>
        public bool? AccessionModalityRequires
        {
            get { return (bool?)this["ACCESSIONMODALITYREQUIRES"]; }
            set { this["ACCESSIONMODALITYREQUIRES"] = value; }
        }

    /// <summary>
    /// Çalışılmayan
    /// </summary>
        public bool? IsPassiveNow
        {
            get { return (bool?)this["ISPASSIVENOW"]; }
            set { this["ISPASSIVENOW"] = value; }
        }

    /// <summary>
    /// Tetkik ID
    /// </summary>
        public TTSequence TestID
        {
            get { return GetSequence("TESTID"); }
        }

    /// <summary>
    /// Çalışmama Notu
    /// </summary>
        public string ReasonForPassive
        {
            get { return (string)this["REASONFORPASSIVE"]; }
            set { this["REASONFORPASSIVE"] = value; }
        }

    /// <summary>
    /// Tetkigin  RIS ile entegre calisip calisilmayacagi bilgisi.
    /// </summary>
        public bool? IsRISEntegratedTest
        {
            get { return (bool?)this["ISRISENTEGRATEDTEST"]; }
            set { this["ISRISENTEGRATEDTEST"] = value; }
        }

    /// <summary>
    /// Ön Bilgi
    /// </summary>
        public string PreInformation
        {
            get { return (string)this["PREINFORMATION"]; }
            set { this["PREINFORMATION"] = value; }
        }

    /// <summary>
    /// Tahmini Sonuçlanma Süresi (Gün)
    /// </summary>
        public int? EstimatedCompletionTime
        {
            get { return (int?)this["ESTIMATEDCOMPLETIONTIME"]; }
            set { this["ESTIMATEDCOMPLETIONTIME"] = value; }
        }

        public RadiologyTestTMDefinition TMRadTest
        {
            get { return (RadiologyTestTMDefinition)((ITTObject)this).GetParent("TMRADTEST"); }
            set { this["TMRADTEST"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public RadiologyTestTypeDefinition TestSubType
        {
            get { return (RadiologyTestTypeDefinition)((ITTObject)this).GetParent("TESTSUBTYPE"); }
            set { this["TESTSUBTYPE"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public RadiologyTabDefinition TestTab
        {
            get { return (RadiologyTabDefinition)((ITTObject)this).GetParent("TESTTAB"); }
            set { this["TESTTAB"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public RadiologyTestTypeDefinition TestType
        {
            get { return (RadiologyTestTypeDefinition)((ITTObject)this).GetParent("TESTTYPE"); }
            set { this["TESTTYPE"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        virtual protected void CreateTabNamesCollection()
        {
            _TabNames = new RadiologyTabNamesGrid.ChildRadiologyTabNamesGridCollection(this, new Guid("7a6eb685-fd5f-4aa4-9129-22e6c6d78610"));
            ((ITTChildObjectCollection)_TabNames).GetChildren();
        }

        protected RadiologyTabNamesGrid.ChildRadiologyTabNamesGridCollection _TabNames = null;
    /// <summary>
    /// Child collection for Test Tanımı İlişkisi
    /// </summary>
        public RadiologyTabNamesGrid.ChildRadiologyTabNamesGridCollection TabNames
        {
            get
            {
                if (_TabNames == null)
                    CreateTabNamesCollection();
                return _TabNames;
            }
        }

        virtual protected void CreateMaterialsCollection()
        {
            _Materials = new RadiologyGridMaterialDefinition.ChildRadiologyGridMaterialDefinitionCollection(this, new Guid("183722f9-94ac-4c45-ab38-51e9a8f562d0"));
            ((ITTChildObjectCollection)_Materials).GetChildren();
        }

        protected RadiologyGridMaterialDefinition.ChildRadiologyGridMaterialDefinitionCollection _Materials = null;
    /// <summary>
    /// Child collection for Radyoloji Test Tanımı İlişkisi
    /// </summary>
        public RadiologyGridMaterialDefinition.ChildRadiologyGridMaterialDefinitionCollection Materials
        {
            get
            {
                if (_Materials == null)
                    CreateMaterialsCollection();
                return _Materials;
            }
        }

        virtual protected void CreateEquipmentsCollection()
        {
            _Equipments = new RadiologyGridEquipmentDefinition.ChildRadiologyGridEquipmentDefinitionCollection(this, new Guid("78fea571-5b72-411c-ba70-6c58c224800d"));
            ((ITTChildObjectCollection)_Equipments).GetChildren();
        }

        protected RadiologyGridEquipmentDefinition.ChildRadiologyGridEquipmentDefinitionCollection _Equipments = null;
        public RadiologyGridEquipmentDefinition.ChildRadiologyGridEquipmentDefinitionCollection Equipments
        {
            get
            {
                if (_Equipments == null)
                    CreateEquipmentsCollection();
                return _Equipments;
            }
        }

        virtual protected void CreateRestrictedsCollection()
        {
            _Restricteds = new RadiologyGridRestrictedTestDefinition.ChildRadiologyGridRestrictedTestDefinitionCollection(this, new Guid("a6399f34-ea47-4652-bdd4-e9e798cc6dc6"));
            ((ITTChildObjectCollection)_Restricteds).GetChildren();
        }

        protected RadiologyGridRestrictedTestDefinition.ChildRadiologyGridRestrictedTestDefinitionCollection _Restricteds = null;
        public RadiologyGridRestrictedTestDefinition.ChildRadiologyGridRestrictedTestDefinitionCollection Restricteds
        {
            get
            {
                if (_Restricteds == null)
                    CreateRestrictedsCollection();
                return _Restricteds;
            }
        }

        virtual protected void CreateWorkDaysCollection()
        {
            _WorkDays = new RadiologyGridDays.ChildRadiologyGridDaysCollection(this, new Guid("38e03898-e19d-406b-bbe6-0c81a996be05"));
            ((ITTChildObjectCollection)_WorkDays).GetChildren();
        }

        protected RadiologyGridDays.ChildRadiologyGridDaysCollection _WorkDays = null;
    /// <summary>
    /// Child collection for Test Tanımı İlişkisi
    /// </summary>
        public RadiologyGridDays.ChildRadiologyGridDaysCollection WorkDays
        {
            get
            {
                if (_WorkDays == null)
                    CreateWorkDaysCollection();
                return _WorkDays;
            }
        }

        virtual protected void CreateTemplatesCollection()
        {
            _Templates = new RadiologyGridTemplateDefinition.ChildRadiologyGridTemplateDefinitionCollection(this, new Guid("9e1fcc87-164d-46ee-ab39-ba7d7c36a734"));
            ((ITTChildObjectCollection)_Templates).GetChildren();
        }

        protected RadiologyGridTemplateDefinition.ChildRadiologyGridTemplateDefinitionCollection _Templates = null;
        public RadiologyGridTemplateDefinition.ChildRadiologyGridTemplateDefinitionCollection Templates
        {
            get
            {
                if (_Templates == null)
                    CreateTemplatesCollection();
                return _Templates;
            }
        }

        virtual protected void CreateDepartmentsCollection()
        {
            _Departments = new RadiologyGridDepartmentDefinition.ChildRadiologyGridDepartmentDefinitionCollection(this, new Guid("930d99d7-381a-471b-850e-f6ca50f366c4"));
            ((ITTChildObjectCollection)_Departments).GetChildren();
        }

        protected RadiologyGridDepartmentDefinition.ChildRadiologyGridDepartmentDefinitionCollection _Departments = null;
        public RadiologyGridDepartmentDefinition.ChildRadiologyGridDepartmentDefinitionCollection Departments
        {
            get
            {
                if (_Departments == null)
                    CreateDepartmentsCollection();
                return _Departments;
            }
        }

        virtual protected void CreateRadiologyTestDescriptionsCollection()
        {
            _RadiologyTestDescriptions = new RadiologyGridTestDescriptionDefinition.ChildRadiologyGridTestDescriptionDefinitionCollection(this, new Guid("86828ce8-0f23-453a-b544-efbe71af4df0"));
            ((ITTChildObjectCollection)_RadiologyTestDescriptions).GetChildren();
        }

        protected RadiologyGridTestDescriptionDefinition.ChildRadiologyGridTestDescriptionDefinitionCollection _RadiologyTestDescriptions = null;
        public RadiologyGridTestDescriptionDefinition.ChildRadiologyGridTestDescriptionDefinitionCollection RadiologyTestDescriptions
        {
            get
            {
                if (_RadiologyTestDescriptions == null)
                    CreateRadiologyTestDescriptionsCollection();
                return _RadiologyTestDescriptions;
            }
        }

        protected RadiologyTestDefinition(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected RadiologyTestDefinition(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected RadiologyTestDefinition(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected RadiologyTestDefinition(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected RadiologyTestDefinition(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "RADIOLOGYTESTDEFINITION", dataRow) { }
        protected RadiologyTestDefinition(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "RADIOLOGYTESTDEFINITION", dataRow, isImported) { }
        public RadiologyTestDefinition(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public RadiologyTestDefinition(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public RadiologyTestDefinition() : base() { }

    }
}