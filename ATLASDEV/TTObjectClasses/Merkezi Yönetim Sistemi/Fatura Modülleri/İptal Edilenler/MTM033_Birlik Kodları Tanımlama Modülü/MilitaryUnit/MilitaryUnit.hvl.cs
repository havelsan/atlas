
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="MilitaryUnit")] 

    /// <summary>
    /// Birlik Kodları Tanımları
    /// </summary>
    public  partial class MilitaryUnit : TerminologyManagerDef, IMilitaryUnit
    {
        public class MilitaryUnitList : TTObjectCollection<MilitaryUnit> { }
                    
        public class ChildMilitaryUnitCollection : TTObject.TTChildObjectCollection<MilitaryUnit>
        {
            public ChildMilitaryUnitCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildMilitaryUnitCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetMilitaryUnit_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public string Code
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["CODE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MILITARYUNIT"].AllPropertyDefs["CODE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MILITARYUNIT"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Forcescommandname
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["FORCESCOMMANDNAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["FORCESCOMMAND"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public GetMilitaryUnit_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetMilitaryUnit_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetMilitaryUnit_Class() : base() { }
        }

        [Serializable] 

        public partial class OLAP_GetMilitaryUnit_WithDate_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public string Code
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["CODE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MILITARYUNIT"].AllPropertyDefs["CODE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MILITARYUNIT"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public Guid? ForcesCommand
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["FORCESCOMMAND"]);
                }
            }

            public OLAP_GetMilitaryUnit_WithDate_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public OLAP_GetMilitaryUnit_WithDate_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected OLAP_GetMilitaryUnit_WithDate_Class() : base() { }
        }

        [Serializable] 

        public partial class OLAP_GetMilitaryUnit_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public string Code
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["CODE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MILITARYUNIT"].AllPropertyDefs["CODE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MILITARYUNIT"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public Guid? ForcesCommand
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["FORCESCOMMAND"]);
                }
            }

            public OLAP_GetMilitaryUnit_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public OLAP_GetMilitaryUnit_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected OLAP_GetMilitaryUnit_Class() : base() { }
        }

        [Serializable] 

        public partial class GetHCSenderChairMilitaryUnits_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public string Code
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["CODE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MILITARYUNIT"].AllPropertyDefs["CODE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MILITARYUNIT"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public GetHCSenderChairMilitaryUnits_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetHCSenderChairMilitaryUnits_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetHCSenderChairMilitaryUnits_Class() : base() { }
        }

        public static BindingList<MilitaryUnit.GetMilitaryUnit_Class> GetMilitaryUnit(string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["MILITARYUNIT"].QueryDefs["GetMilitaryUnit"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<MilitaryUnit.GetMilitaryUnit_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<MilitaryUnit.GetMilitaryUnit_Class> GetMilitaryUnit(TTObjectContext objectContext, string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["MILITARYUNIT"].QueryDefs["GetMilitaryUnit"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<MilitaryUnit.GetMilitaryUnit_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<MilitaryUnit> GetMilitaryUnitByLastUpdateDate(TTObjectContext objectContext, DateTime STARTDATE, DateTime ENDDATE)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["MILITARYUNIT"].QueryDefs["GetMilitaryUnitByLastUpdateDate"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);

            return ((ITTQuery)objectContext).QueryObjects<MilitaryUnit>(queryDef, paramList);
        }

        public static BindingList<MilitaryUnit.OLAP_GetMilitaryUnit_WithDate_Class> OLAP_GetMilitaryUnit_WithDate(DateTime FIRSTDATE, DateTime LASTDATE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["MILITARYUNIT"].QueryDefs["OLAP_GetMilitaryUnit_WithDate"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("FIRSTDATE", FIRSTDATE);
            paramList.Add("LASTDATE", LASTDATE);

            return TTReportNqlObject.QueryObjects<MilitaryUnit.OLAP_GetMilitaryUnit_WithDate_Class>(queryDef, paramList, pi);
        }

        public static BindingList<MilitaryUnit.OLAP_GetMilitaryUnit_WithDate_Class> OLAP_GetMilitaryUnit_WithDate(TTObjectContext objectContext, DateTime FIRSTDATE, DateTime LASTDATE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["MILITARYUNIT"].QueryDefs["OLAP_GetMilitaryUnit_WithDate"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("FIRSTDATE", FIRSTDATE);
            paramList.Add("LASTDATE", LASTDATE);

            return TTReportNqlObject.QueryObjects<MilitaryUnit.OLAP_GetMilitaryUnit_WithDate_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<MilitaryUnit.OLAP_GetMilitaryUnit_Class> OLAP_GetMilitaryUnit(PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["MILITARYUNIT"].QueryDefs["OLAP_GetMilitaryUnit"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<MilitaryUnit.OLAP_GetMilitaryUnit_Class>(queryDef, paramList, pi);
        }

        public static BindingList<MilitaryUnit.OLAP_GetMilitaryUnit_Class> OLAP_GetMilitaryUnit(TTObjectContext objectContext, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["MILITARYUNIT"].QueryDefs["OLAP_GetMilitaryUnit"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<MilitaryUnit.OLAP_GetMilitaryUnit_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<MilitaryUnit.GetHCSenderChairMilitaryUnits_Class> GetHCSenderChairMilitaryUnits(PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["MILITARYUNIT"].QueryDefs["GetHCSenderChairMilitaryUnits"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<MilitaryUnit.GetHCSenderChairMilitaryUnits_Class>(queryDef, paramList, pi);
        }

        public static BindingList<MilitaryUnit.GetHCSenderChairMilitaryUnits_Class> GetHCSenderChairMilitaryUnits(TTObjectContext objectContext, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["MILITARYUNIT"].QueryDefs["GetHCSenderChairMilitaryUnits"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<MilitaryUnit.GetHCSenderChairMilitaryUnits_Class>(objectContext, queryDef, paramList, pi);
        }

    /// <summary>
    /// ID
    /// </summary>
        public long? ID
        {
            get { return (long?)this["ID"]; }
            set { this["ID"] = value; }
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
    /// Bağlı Adı
    /// </summary>
        public string LinkedName
        {
            get { return (string)this["LINKEDNAME"]; }
            set { this["LINKEDNAME"] = value; }
        }

    /// <summary>
    /// Kodu
    /// </summary>
        public string Code
        {
            get { return (string)this["CODE"]; }
            set { this["CODE"] = value; }
        }

    /// <summary>
    /// Sağlık Kuruluna Gönderen Makamdır
    /// </summary>
        public bool? IsHCSenderChair
        {
            get { return (bool?)this["ISHCSENDERCHAIR"]; }
            set { this["ISHCSENDERCHAIR"] = value; }
        }

    /// <summary>
    /// Birlik Değildir
    /// </summary>
        public bool? OnlySenderChair
        {
            get { return (bool?)this["ONLYSENDERCHAIR"]; }
            set { this["ONLYSENDERCHAIR"] = value; }
        }

        public string Name_Shadow
        {
            get { return (string)this["NAME_SHADOW"]; }
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
    /// Sistemi destekler/desteklemez
    /// </summary>
        public bool? IsSupported
        {
            get { return (bool?)this["ISSUPPORTED"]; }
            set { this["ISSUPPORTED"] = value; }
        }

        public ForcesCommand ForcesCommand
        {
            get { return (ForcesCommand)((ITTObject)this).GetParent("FORCESCOMMAND"); }
            set { this["FORCESCOMMAND"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public Sites Site
        {
            get { return (Sites)((ITTObject)this).GetParent("SITE"); }
            set { this["SITE"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        virtual protected void CreateStageCollection()
        {
            _Stage = new StageDefinition.ChildStageDefinitionCollection(this, new Guid("7f14874e-9152-4913-92ee-0faca5528bd9"));
            ((ITTChildObjectCollection)_Stage).GetChildren();
        }

        protected StageDefinition.ChildStageDefinitionCollection _Stage = null;
        public StageDefinition.ChildStageDefinitionCollection Stage
        {
            get
            {
                if (_Stage == null)
                    CreateStageCollection();
                return _Stage;
            }
        }

        virtual protected void CreateHospitalCollection()
        {
            _Hospital = new ResHospital.ChildResHospitalCollection(this, new Guid("abab957f-50a8-44aa-a55f-4d9fc9d7d32a"));
            ((ITTChildObjectCollection)_Hospital).GetChildren();
        }

        protected ResHospital.ChildResHospitalCollection _Hospital = null;
        public ResHospital.ChildResHospitalCollection Hospital
        {
            get
            {
                if (_Hospital == null)
                    CreateHospitalCollection();
                return _Hospital;
            }
        }

        virtual protected void CreateCMRRelationsDefinitionCollection()
        {
            _CMRRelationsDefinition = new CMRRelationsDefinition.ChildCMRRelationsDefinitionCollection(this, new Guid("6ebf77ca-3aac-4d9b-a4f2-9a92047b4e28"));
            ((ITTChildObjectCollection)_CMRRelationsDefinition).GetChildren();
        }

        protected CMRRelationsDefinition.ChildCMRRelationsDefinitionCollection _CMRRelationsDefinition = null;
        public CMRRelationsDefinition.ChildCMRRelationsDefinitionCollection CMRRelationsDefinition
        {
            get
            {
                if (_CMRRelationsDefinition == null)
                    CreateCMRRelationsDefinitionCollection();
                return _CMRRelationsDefinition;
            }
        }

        virtual protected void CreateAccountanciesCollection()
        {
            _Accountancies = new Accountancy.ChildAccountancyCollection(this, new Guid("6f8a3934-4200-40a9-8ce5-de2904943cdf"));
            ((ITTChildObjectCollection)_Accountancies).GetChildren();
        }

        protected Accountancy.ChildAccountancyCollection _Accountancies = null;
        public Accountancy.ChildAccountancyCollection Accountancies
        {
            get
            {
                if (_Accountancies == null)
                    CreateAccountanciesCollection();
                return _Accountancies;
            }
        }

        protected MilitaryUnit(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected MilitaryUnit(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected MilitaryUnit(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected MilitaryUnit(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected MilitaryUnit(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "MILITARYUNIT", dataRow) { }
        protected MilitaryUnit(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "MILITARYUNIT", dataRow, isImported) { }
        protected MilitaryUnit(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public MilitaryUnit(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public MilitaryUnit() : base() { }

    }
}