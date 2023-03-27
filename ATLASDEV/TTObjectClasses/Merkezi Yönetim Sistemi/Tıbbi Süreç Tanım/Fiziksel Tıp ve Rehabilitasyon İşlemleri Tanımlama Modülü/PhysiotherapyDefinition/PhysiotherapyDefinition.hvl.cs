
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="PhysiotherapyDefinition")] 

    /// <summary>
    /// Fiziksel Tıp ve Rehabilitasyon İşlemleri Tanımlama
    /// </summary>
    public  partial class PhysiotherapyDefinition : ProcedureDefinition
    {
        public class PhysiotherapyDefinitionList : TTObjectCollection<PhysiotherapyDefinition> { }
                    
        public class ChildPhysiotherapyDefinitionCollection : TTObject.TTChildObjectCollection<PhysiotherapyDefinition>
        {
            public ChildPhysiotherapyDefinitionCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildPhysiotherapyDefinitionCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetPhysiotherapyDefinition_Class : TTReportNqlObject 
        {
            public long? ID
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ID"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PHYSIOTHERAPYDEFINITION"].AllPropertyDefs["ID"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PHYSIOTHERAPYDEFINITION"].AllPropertyDefs["CODE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PHYSIOTHERAPYDEFINITION"].AllPropertyDefs["NAME"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PHYSIOTHERAPYDEFINITION"].AllPropertyDefs["ENGLISHNAME"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PHYSIOTHERAPYDEFINITION"].AllPropertyDefs["TREATMENTDURATION"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PHYSIOTHERAPYDEFINITION"].AllPropertyDefs["QREF"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PHYSIOTHERAPYDEFINITION"].AllPropertyDefs["CHARGABLE"].DataType;
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

            public GetPhysiotherapyDefinition_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetPhysiotherapyDefinition_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetPhysiotherapyDefinition_Class() : base() { }
        }

        public static BindingList<PhysiotherapyDefinition> GetPhysiothDefByLastUpdateDate(TTObjectContext objectContext, DateTime STARTDATE, DateTime ENDDATE)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PHYSIOTHERAPYDEFINITION"].QueryDefs["GetPhysiothDefByLastUpdateDate"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);

            return ((ITTQuery)objectContext).QueryObjects<PhysiotherapyDefinition>(queryDef, paramList);
        }

        public static BindingList<PhysiotherapyDefinition.GetPhysiotherapyDefinition_Class> GetPhysiotherapyDefinition(string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PHYSIOTHERAPYDEFINITION"].QueryDefs["GetPhysiotherapyDefinition"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<PhysiotherapyDefinition.GetPhysiotherapyDefinition_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<PhysiotherapyDefinition.GetPhysiotherapyDefinition_Class> GetPhysiotherapyDefinition(TTObjectContext objectContext, string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PHYSIOTHERAPYDEFINITION"].QueryDefs["GetPhysiotherapyDefinition"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<PhysiotherapyDefinition.GetPhysiotherapyDefinition_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<PhysiotherapyDefinition> GetAllPhysiotherapyDefinitions(TTObjectContext objectContext)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PHYSIOTHERAPYDEFINITION"].QueryDefs["GetAllPhysiotherapyDefinitions"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return ((ITTQuery)objectContext).QueryObjects<PhysiotherapyDefinition>(queryDef, paramList);
        }

        public static BindingList<PhysiotherapyDefinition> GetPhysiotherapyDefinitionList(TTObjectContext objectContext, string injectionSQL)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PHYSIOTHERAPYDEFINITION"].QueryDefs["GetPhysiotherapyDefinitionList"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return ((ITTQuery)objectContext).QueryObjects<PhysiotherapyDefinition>(queryDef, paramList, injectionSQL);
        }

    /// <summary>
    /// Tedavi Süresi
    /// </summary>
        public int? TreatmentDuration
        {
            get { return (int?)this["TREATMENTDURATION"]; }
            set { this["TREATMENTDURATION"] = value; }
        }

    /// <summary>
    /// Tetkik Alt Sınıfı
    /// </summary>
        public ExaminationSubClassEnum? ExaminationSubClass
        {
            get { return (ExaminationSubClassEnum?)(int?)this["EXAMINATIONSUBCLASS"]; }
            set { this["EXAMINATIONSUBCLASS"] = value; }
        }

    /// <summary>
    /// Sıra Numarası
    /// </summary>
        public int? OrderNo
        {
            get { return (int?)this["ORDERNO"]; }
            set { this["ORDERNO"] = value; }
        }

    /// <summary>
    /// ESWT İşlemi
    /// </summary>
        public bool? ESWTTransaction
        {
            get { return (bool?)this["ESWTTRANSACTION"]; }
            set { this["ESWTTRANSACTION"] = value; }
        }

        virtual protected void CreateTreatmentRoomsCollection()
        {
            _TreatmentRooms = new PhysiotherapyTreatmentRoomGrid.ChildPhysiotherapyTreatmentRoomGridCollection(this, new Guid("7507ed2f-cd8d-4e62-9e08-8266f8ffb150"));
            ((ITTChildObjectCollection)_TreatmentRooms).GetChildren();
        }

        protected PhysiotherapyTreatmentRoomGrid.ChildPhysiotherapyTreatmentRoomGridCollection _TreatmentRooms = null;
    /// <summary>
    /// Child collection for Tedavi Odaları
    /// </summary>
        public PhysiotherapyTreatmentRoomGrid.ChildPhysiotherapyTreatmentRoomGridCollection TreatmentRooms
        {
            get
            {
                if (_TreatmentRooms == null)
                    CreateTreatmentRoomsCollection();
                return _TreatmentRooms;
            }
        }

        virtual protected void CreateTreatmentUnitsCollection()
        {
            _TreatmentUnits = new PhysiotherapyTreatmentUnitGrid.ChildPhysiotherapyTreatmentUnitGridCollection(this, new Guid("457a7778-930c-44b6-9f08-d70615f13971"));
            ((ITTChildObjectCollection)_TreatmentUnits).GetChildren();
        }

        protected PhysiotherapyTreatmentUnitGrid.ChildPhysiotherapyTreatmentUnitGridCollection _TreatmentUnits = null;
    /// <summary>
    /// Child collection for Tanı Tedavi Üniteleri
    /// </summary>
        public PhysiotherapyTreatmentUnitGrid.ChildPhysiotherapyTreatmentUnitGridCollection TreatmentUnits
        {
            get
            {
                if (_TreatmentUnits == null)
                    CreateTreatmentUnitsCollection();
                return _TreatmentUnits;
            }
        }

        protected PhysiotherapyDefinition(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected PhysiotherapyDefinition(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected PhysiotherapyDefinition(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected PhysiotherapyDefinition(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected PhysiotherapyDefinition(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "PHYSIOTHERAPYDEFINITION", dataRow) { }
        protected PhysiotherapyDefinition(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "PHYSIOTHERAPYDEFINITION", dataRow, isImported) { }
        public PhysiotherapyDefinition(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public PhysiotherapyDefinition(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public PhysiotherapyDefinition() : base() { }

    }
}