
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="MainPatientGroupDefinition")] 

    public  partial class MainPatientGroupDefinition : TerminologyManagerDef
    {
        public class MainPatientGroupDefinitionList : TTObjectCollection<MainPatientGroupDefinition> { }
                    
        public class ChildMainPatientGroupDefinitionCollection : TTObject.TTChildObjectCollection<MainPatientGroupDefinition>
        {
            public ChildMainPatientGroupDefinitionCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildMainPatientGroupDefinitionCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetMainPatientGroupDefinition_Class : TTReportNqlObject 
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MAINPATIENTGROUPDEFINITION"].AllPropertyDefs["NAME"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MAINPATIENTGROUPDEFINITION"].AllPropertyDefs["ORDERNO"].DataType;
                    return (int?)dataType.ConvertValue(val);
                }
            }

            public GetMainPatientGroupDefinition_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetMainPatientGroupDefinition_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetMainPatientGroupDefinition_Class() : base() { }
        }

        public static BindingList<MainPatientGroupDefinition> GetByMainPatientGroupEnum(TTObjectContext objectContext, MainPatientGroupEnum MAINPARAMPATIENTGROUP)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["MAINPATIENTGROUPDEFINITION"].QueryDefs["GetByMainPatientGroupEnum"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("MAINPARAMPATIENTGROUP", (int)MAINPARAMPATIENTGROUP);

            return ((ITTQuery)objectContext).QueryObjects<MainPatientGroupDefinition>(queryDef, paramList);
        }

        public static BindingList<MainPatientGroupDefinition> GetActiveMainPatientGroups(TTObjectContext objectContext, bool GETALL, bool ISEMERGENCYUSER, bool ISMEDULAINTEGRATION, int FOREIGNUSAGE)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["MAINPATIENTGROUPDEFINITION"].QueryDefs["GetActiveMainPatientGroups"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("GETALL", GETALL);
            paramList.Add("ISEMERGENCYUSER", ISEMERGENCYUSER);
            paramList.Add("ISMEDULAINTEGRATION", ISMEDULAINTEGRATION);
            paramList.Add("FOREIGNUSAGE", FOREIGNUSAGE);

            return ((ITTQuery)objectContext).QueryObjects<MainPatientGroupDefinition>(queryDef, paramList);
        }

        public static BindingList<MainPatientGroupDefinition.GetMainPatientGroupDefinition_Class> GetMainPatientGroupDefinition(string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["MAINPATIENTGROUPDEFINITION"].QueryDefs["GetMainPatientGroupDefinition"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<MainPatientGroupDefinition.GetMainPatientGroupDefinition_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<MainPatientGroupDefinition.GetMainPatientGroupDefinition_Class> GetMainPatientGroupDefinition(TTObjectContext objectContext, string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["MAINPATIENTGROUPDEFINITION"].QueryDefs["GetMainPatientGroupDefinition"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<MainPatientGroupDefinition.GetMainPatientGroupDefinition_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<MainPatientGroupDefinition> GetMainPatientGroups(TTObjectContext objectContext)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["MAINPATIENTGROUPDEFINITION"].QueryDefs["GetMainPatientGroups"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return ((ITTQuery)objectContext).QueryObjects<MainPatientGroupDefinition>(queryDef, paramList);
        }

        public static BindingList<MainPatientGroupDefinition> GetMainPatientGroupDefinitionByLastUpdateDate(TTObjectContext objectContext, DateTime STARTDATE, DateTime ENDDATE)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["MAINPATIENTGROUPDEFINITION"].QueryDefs["GetMainPatientGroupDefinitionByLastUpdateDate"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);

            return ((ITTQuery)objectContext).QueryObjects<MainPatientGroupDefinition>(queryDef, paramList);
        }

        public static BindingList<MainPatientGroupDefinition> GetActiveByMainPatientGroupEnum(TTObjectContext objectContext, MainPatientGroupEnum MAINPARAMPATIENTGROUP)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["MAINPATIENTGROUPDEFINITION"].QueryDefs["GetActiveByMainPatientGroupEnum"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("MAINPARAMPATIENTGROUP", (int)MAINPARAMPATIENTGROUP);

            return ((ITTQuery)objectContext).QueryObjects<MainPatientGroupDefinition>(queryDef, paramList);
        }

    /// <summary>
    /// XXXXXXden Kaydı Yapılabilir
    /// </summary>
        public bool? AllowAdmissionFromSite
        {
            get { return (bool?)this["ALLOWADMISSIONFROMSITE"]; }
            set { this["ALLOWADMISSIONFROMSITE"] = value; }
        }

    /// <summary>
    /// Ana Hasta Grubu
    /// </summary>
        public MainPatientGroupEnum? MainPatientGroupEnum
        {
            get { return (MainPatientGroupEnum?)(int?)this["MAINPATIENTGROUPENUM"]; }
            set { this["MAINPATIENTGROUPENUM"] = value; }
        }

    /// <summary>
    /// Ana Grup Adı
    /// </summary>
        public string Name
        {
            get { return (string)this["NAME"]; }
            set { this["NAME"] = value; }
        }

    /// <summary>
    /// Alt Grupları Tek Ekrandan Kabul Et
    /// </summary>
        public bool? UseMyClassForChildren
        {
            get { return (bool?)this["USEMYCLASSFORCHILDREN"]; }
            set { this["USEMYCLASSFORCHILDREN"] = value; }
        }

    /// <summary>
    /// Sıra No
    /// </summary>
        public int? OrderNo
        {
            get { return (int?)this["ORDERNO"]; }
            set { this["ORDERNO"] = value; }
        }

        public string Name_Shadow
        {
            get { return (string)this["NAME_SHADOW"]; }
        }

        virtual protected void CreatePatientGroupsCollection()
        {
            _PatientGroups = new PatientGroupDefinition.ChildPatientGroupDefinitionCollection(this, new Guid("ec3ece36-253e-4d76-8e07-f8f8dc7618ad"));
            ((ITTChildObjectCollection)_PatientGroups).GetChildren();
        }

        protected PatientGroupDefinition.ChildPatientGroupDefinitionCollection _PatientGroups = null;
    /// <summary>
    /// Child collection for Ana Hasta Grubu
    /// </summary>
        public PatientGroupDefinition.ChildPatientGroupDefinitionCollection PatientGroups
        {
            get
            {
                if (_PatientGroups == null)
                    CreatePatientGroupsCollection();
                return _PatientGroups;
            }
        }

        protected MainPatientGroupDefinition(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected MainPatientGroupDefinition(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected MainPatientGroupDefinition(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected MainPatientGroupDefinition(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected MainPatientGroupDefinition(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "MAINPATIENTGROUPDEFINITION", dataRow) { }
        protected MainPatientGroupDefinition(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "MAINPATIENTGROUPDEFINITION", dataRow, isImported) { }
        public MainPatientGroupDefinition(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public MainPatientGroupDefinition(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public MainPatientGroupDefinition() : base() { }

    }
}