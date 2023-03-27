
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="NuclearMedicineTestDefinition")] 

    /// <summary>
    /// Nükleer Tıp Tetkik Tanımları
    /// </summary>
    public  partial class NuclearMedicineTestDefinition : ProcedureDefinition, IProcedureRequestDefinition
    {
        public class NuclearMedicineTestDefinitionList : TTObjectCollection<NuclearMedicineTestDefinition> { }
                    
        public class ChildNuclearMedicineTestDefinitionCollection : TTObject.TTChildObjectCollection<NuclearMedicineTestDefinition>
        {
            public ChildNuclearMedicineTestDefinitionCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildNuclearMedicineTestDefinitionCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class NuclearMedicineTestDefFormNQL_Class : TTReportNqlObject 
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["NUCLEARMEDICINETESTDEFINITION"].AllPropertyDefs["CODE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["NUCLEARMEDICINETESTDEFINITION"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public NuclearMedicineTestDefFormNQL_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public NuclearMedicineTestDefFormNQL_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected NuclearMedicineTestDefFormNQL_Class() : base() { }
        }

        public static BindingList<NuclearMedicineTestDefinition.NuclearMedicineTestDefFormNQL_Class> NuclearMedicineTestDefFormNQL(string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["NUCLEARMEDICINETESTDEFINITION"].QueryDefs["NuclearMedicineTestDefFormNQL"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<NuclearMedicineTestDefinition.NuclearMedicineTestDefFormNQL_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<NuclearMedicineTestDefinition.NuclearMedicineTestDefFormNQL_Class> NuclearMedicineTestDefFormNQL(TTObjectContext objectContext, string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["NUCLEARMEDICINETESTDEFINITION"].QueryDefs["NuclearMedicineTestDefFormNQL"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<NuclearMedicineTestDefinition.NuclearMedicineTestDefFormNQL_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<NuclearMedicineTestDefinition> GetNuclearMedicineTestDefByLastUpdateDate(TTObjectContext objectContext, DateTime STARTDATE, DateTime ENDDATE)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["NUCLEARMEDICINETESTDEFINITION"].QueryDefs["GetNuclearMedicineTestDefByLastUpdateDate"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);

            return ((ITTQuery)objectContext).QueryObjects<NuclearMedicineTestDefinition>(queryDef, paramList);
        }

    /// <summary>
    /// Tetkik Sıra Numarasıdır
    /// </summary>
        public TTSequence TestID
        {
            get { return GetSequence("TESTID"); }
        }

    /// <summary>
    /// Nükleer Tıp  Bölümü İlişkisi
    /// </summary>
        public ResNuclearMedicineDepartment NuclearMedicineDepartment
        {
            get { return (ResNuclearMedicineDepartment)((ITTObject)this).GetParent("NUCLEARMEDICINEDEPARTMENT"); }
            set { this["NUCLEARMEDICINEDEPARTMENT"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Test Grubu İlişkisi
    /// </summary>
        public NucMedTestGroupDef TestGroup
        {
            get { return (NucMedTestGroupDef)((ITTObject)this).GetParent("TESTGROUP"); }
            set { this["TESTGROUP"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        virtual protected void CreateMaterialsCollection()
        {
            _Materials = new NuclearMedicineGridMaterialDefinition.ChildNuclearMedicineGridMaterialDefinitionCollection(this, new Guid("fca743f8-d666-4783-8175-c4ccb5696516"));
            ((ITTChildObjectCollection)_Materials).GetChildren();
        }

        protected NuclearMedicineGridMaterialDefinition.ChildNuclearMedicineGridMaterialDefinitionCollection _Materials = null;
    /// <summary>
    /// Child collection for Nükleer Tıp Test Tanımı İlişkisi
    /// </summary>
        public NuclearMedicineGridMaterialDefinition.ChildNuclearMedicineGridMaterialDefinitionCollection Materials
        {
            get
            {
                if (_Materials == null)
                    CreateMaterialsCollection();
                return _Materials;
            }
        }

        virtual protected void CreatePharmMaterialsCollection()
        {
            _PharmMaterials = new NuclearMedicineGridPharmDefinition.ChildNuclearMedicineGridPharmDefinitionCollection(this, new Guid("95f6bacb-345e-4360-8bc1-5a8ff616b548"));
            ((ITTChildObjectCollection)_PharmMaterials).GetChildren();
        }

        protected NuclearMedicineGridPharmDefinition.ChildNuclearMedicineGridPharmDefinitionCollection _PharmMaterials = null;
    /// <summary>
    /// Child collection for Nükleer Tıp Test Tanımı İlişkisi
    /// </summary>
        public NuclearMedicineGridPharmDefinition.ChildNuclearMedicineGridPharmDefinitionCollection PharmMaterials
        {
            get
            {
                if (_PharmMaterials == null)
                    CreatePharmMaterialsCollection();
                return _PharmMaterials;
            }
        }

        virtual protected void CreateTabsBelongToCollection()
        {
            _TabsBelongTo = new NucMedTabNamesGrid.ChildNucMedTabNamesGridCollection(this, new Guid("04a030c2-5d03-46d1-b5c1-e37248e9a23d"));
            ((ITTChildObjectCollection)_TabsBelongTo).GetChildren();
        }

        protected NucMedTabNamesGrid.ChildNucMedTabNamesGridCollection _TabsBelongTo = null;
        public NucMedTabNamesGrid.ChildNucMedTabNamesGridCollection TabsBelongTo
        {
            get
            {
                if (_TabsBelongTo == null)
                    CreateTabsBelongToCollection();
                return _TabsBelongTo;
            }
        }

        virtual protected void CreateEquipmentsCollection()
        {
            _Equipments = new NuclearMedicineGridEquipmentDefinition.ChildNuclearMedicineGridEquipmentDefinitionCollection(this, new Guid("4e4dbe44-d692-4250-8f81-e83611d37a44"));
            ((ITTChildObjectCollection)_Equipments).GetChildren();
        }

        protected NuclearMedicineGridEquipmentDefinition.ChildNuclearMedicineGridEquipmentDefinitionCollection _Equipments = null;
    /// <summary>
    /// Child collection for Nükleer Tıp Test Tanım İlişkisi
    /// </summary>
        public NuclearMedicineGridEquipmentDefinition.ChildNuclearMedicineGridEquipmentDefinitionCollection Equipments
        {
            get
            {
                if (_Equipments == null)
                    CreateEquipmentsCollection();
                return _Equipments;
            }
        }

        protected NuclearMedicineTestDefinition(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected NuclearMedicineTestDefinition(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected NuclearMedicineTestDefinition(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected NuclearMedicineTestDefinition(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected NuclearMedicineTestDefinition(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "NUCLEARMEDICINETESTDEFINITION", dataRow) { }
        protected NuclearMedicineTestDefinition(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "NUCLEARMEDICINETESTDEFINITION", dataRow, isImported) { }
        public NuclearMedicineTestDefinition(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public NuclearMedicineTestDefinition(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public NuclearMedicineTestDefinition() : base() { }

    }
}