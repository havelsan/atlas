
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="LaboratoryGridPanelTestDefinition")] 

    /// <summary>
    /// Panel Tetkikler Grid Tanımı
    /// </summary>
    public  partial class LaboratoryGridPanelTestDefinition : TTDefinitionSet
    {
        public class LaboratoryGridPanelTestDefinitionList : TTObjectCollection<LaboratoryGridPanelTestDefinition> { }
                    
        public class ChildLaboratoryGridPanelTestDefinitionCollection : TTObject.TTChildObjectCollection<LaboratoryGridPanelTestDefinition>
        {
            public ChildLaboratoryGridPanelTestDefinitionCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildLaboratoryGridPanelTestDefinitionCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetLabGridPanelsNQL_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public int? SequenceNo
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["SEQUENCENO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["LABORATORYGRIDPANELTESTDEFINITION"].AllPropertyDefs["SEQUENCENO"].DataType;
                    return (int?)dataType.ConvertValue(val);
                }
            }

            public Guid? LaboratoryTest
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["LABORATORYTEST"]);
                }
            }

            public GetLabGridPanelsNQL_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetLabGridPanelsNQL_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetLabGridPanelsNQL_Class() : base() { }
        }

        [Serializable] 

        public partial class VEM_TETKIK_PARAMETRE_Class : TTReportNqlObject 
        {
            public Guid? Tetkik_parametre_kodu
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["TETKIK_PARAMETRE_KODU"]);
                }
            }

            public Object Referans_tablo_adi
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["REFERANS_TABLO_ADI"]);
                }
            }

            public string Tetkik_parametre_adi
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["TETKIK_PARAMETRE_ADI"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["LABORATORYTESTDEFINITION"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public Guid? Tetkik_kodu
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["TETKIK_KODU"]);
                }
            }

            public Object Medula_parametre_kodu
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["MEDULA_PARAMETRE_KODU"]);
                }
            }

            public Object Loinc_kodu
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["LOINC_KODU"]);
                }
            }

            public int? Rapor_sonuc_sirasi
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["RAPOR_SONUC_SIRASI"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["LABORATORYGRIDPANELTESTDEFINITION"].AllPropertyDefs["SEQUENCENO"].DataType;
                    return (int?)dataType.ConvertValue(val);
                }
            }

            public Boolean? Iptal_durumu
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["IPTAL_DURUMU"]);
                    if (val == null)
                        return null;
                    return (Boolean)Convert.ChangeType(val, typeof(Boolean)); 
                }
            }

            public Object Ekleyen_kullanici_kodu
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["EKLEYEN_KULLANICI_KODU"]);
                }
            }

            public DateTime? Guncelleme_tarihi
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["GUNCELLEME_TARIHI"]);
                    if (val == null)
                        return null;
                    return (DateTime)Convert.ChangeType(val, typeof(DateTime)); 
                }
            }

            public Object Guncelleyen_kullanici_kodu
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["GUNCELLEYEN_KULLANICI_KODU"]);
                }
            }

            public VEM_TETKIK_PARAMETRE_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public VEM_TETKIK_PARAMETRE_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected VEM_TETKIK_PARAMETRE_Class() : base() { }
        }

        public static BindingList<LaboratoryGridPanelTestDefinition.GetLabGridPanelsNQL_Class> GetLabGridPanelsNQL(Guid PARAMTEST, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["LABORATORYGRIDPANELTESTDEFINITION"].QueryDefs["GetLabGridPanelsNQL"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("PARAMTEST", PARAMTEST);

            return TTReportNqlObject.QueryObjects<LaboratoryGridPanelTestDefinition.GetLabGridPanelsNQL_Class>(queryDef, paramList, pi);
        }

        public static BindingList<LaboratoryGridPanelTestDefinition.GetLabGridPanelsNQL_Class> GetLabGridPanelsNQL(TTObjectContext objectContext, Guid PARAMTEST, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["LABORATORYGRIDPANELTESTDEFINITION"].QueryDefs["GetLabGridPanelsNQL"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("PARAMTEST", PARAMTEST);

            return TTReportNqlObject.QueryObjects<LaboratoryGridPanelTestDefinition.GetLabGridPanelsNQL_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<LaboratoryGridPanelTestDefinition> GetLabGridPanels(TTObjectContext objectContext, Guid PARAMTEST)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["LABORATORYGRIDPANELTESTDEFINITION"].QueryDefs["GetLabGridPanels"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("PARAMTEST", PARAMTEST);

            return ((ITTQuery)objectContext).QueryObjects<LaboratoryGridPanelTestDefinition>(queryDef, paramList);
        }

        public static BindingList<LaboratoryGridPanelTestDefinition.VEM_TETKIK_PARAMETRE_Class> VEM_TETKIK_PARAMETRE(PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["LABORATORYGRIDPANELTESTDEFINITION"].QueryDefs["VEM_TETKIK_PARAMETRE"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<LaboratoryGridPanelTestDefinition.VEM_TETKIK_PARAMETRE_Class>(queryDef, paramList, pi);
        }

        public static BindingList<LaboratoryGridPanelTestDefinition.VEM_TETKIK_PARAMETRE_Class> VEM_TETKIK_PARAMETRE(TTObjectContext objectContext, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["LABORATORYGRIDPANELTESTDEFINITION"].QueryDefs["VEM_TETKIK_PARAMETRE"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<LaboratoryGridPanelTestDefinition.VEM_TETKIK_PARAMETRE_Class>(objectContext, queryDef, paramList, pi);
        }

    /// <summary>
    /// Sıra No
    /// </summary>
        public int? SequenceNo
        {
            get { return (int?)this["SEQUENCENO"]; }
            set { this["SEQUENCENO"] = value; }
        }

    /// <summary>
    /// Laboratuvar Test Tanımı İlişkisi
    /// </summary>
        public LaboratoryTestDefinition LaboratoryTest
        {
            get { return (LaboratoryTestDefinition)((ITTObject)this).GetParent("LABORATORYTEST"); }
            set { this["LABORATORYTEST"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Laboratuvar Test Tanım İlişkisi
    /// </summary>
        public LaboratoryTestDefinition LaboratoryTestDefinition
        {
            get { return (LaboratoryTestDefinition)((ITTObject)this).GetParent("LABORATORYTESTDEFINITION"); }
            set { this["LABORATORYTESTDEFINITION"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected LaboratoryGridPanelTestDefinition(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected LaboratoryGridPanelTestDefinition(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected LaboratoryGridPanelTestDefinition(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected LaboratoryGridPanelTestDefinition(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected LaboratoryGridPanelTestDefinition(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "LABORATORYGRIDPANELTESTDEFINITION", dataRow) { }
        protected LaboratoryGridPanelTestDefinition(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "LABORATORYGRIDPANELTESTDEFINITION", dataRow, isImported) { }
        public LaboratoryGridPanelTestDefinition(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public LaboratoryGridPanelTestDefinition(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public LaboratoryGridPanelTestDefinition() : base() { }

    }
}