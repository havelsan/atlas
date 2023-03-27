
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="HealtUnitDefinition")] 

    /// <summary>
    /// Sağlık Teşkili Tanımı
    /// </summary>
    public  partial class HealtUnitDefinition : TTDefinitionSet
    {
        public class HealtUnitDefinitionList : TTObjectCollection<HealtUnitDefinition> { }
                    
        public class ChildHealtUnitDefinitionCollection : TTObject.TTChildObjectCollection<HealtUnitDefinition>
        {
            public ChildHealtUnitDefinitionCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildHealtUnitDefinitionCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetHealtUnitDefinition_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public string HealtUnitName
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["HEALTUNITNAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["HEALTUNITDEFINITION"].AllPropertyDefs["HEALTUNITNAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Type
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["TYPE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["HEALTUNITDEFINITION"].AllPropertyDefs["TYPE"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string MilitaryUnit
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MILITARYUNIT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["HEALTUNITDEFINITION"].AllPropertyDefs["MILITARYUNIT"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public GetHealtUnitDefinition_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetHealtUnitDefinition_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetHealtUnitDefinition_Class() : base() { }
        }

        public static BindingList<HealtUnitDefinition.GetHealtUnitDefinition_Class> GetHealtUnitDefinition(string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["HEALTUNITDEFINITION"].QueryDefs["GetHealtUnitDefinition"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<HealtUnitDefinition.GetHealtUnitDefinition_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<HealtUnitDefinition.GetHealtUnitDefinition_Class> GetHealtUnitDefinition(TTObjectContext objectContext, string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["HEALTUNITDEFINITION"].QueryDefs["GetHealtUnitDefinition"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<HealtUnitDefinition.GetHealtUnitDefinition_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

    /// <summary>
    /// Konuş Yerleri
    /// </summary>
        public string Location
        {
            get { return (string)this["LOCATION"]; }
            set { this["LOCATION"] = value; }
        }

    /// <summary>
    /// Hareketliliği
    /// </summary>
        public string Briskness
        {
            get { return (string)this["BRISKNESS"]; }
            set { this["BRISKNESS"] = value; }
        }

    /// <summary>
    /// Korunaklı Alan Kapsamına Göre Durumları
    /// </summary>
        public string SuntrapArea
        {
            get { return (string)this["SUNTRAPAREA"]; }
            set { this["SUNTRAPAREA"] = value; }
        }

    /// <summary>
    /// En Yakın Tafics Santralinin Bulunduğu Birlik ve Mesafesi
    /// </summary>
        public string NearestTafics
        {
            get { return (string)this["NEARESTTAFICS"]; }
            set { this["NEARESTTAFICS"] = value; }
        }

    /// <summary>
    /// Tafics Santraline Mesafede Korunaklı Alan Durumu
    /// </summary>
        public string TaficsStatus
        {
            get { return (string)this["TAFICSSTATUS"]; }
            set { this["TAFICSSTATUS"] = value; }
        }

    /// <summary>
    /// Nakil Araçları
    /// </summary>
        public string DeliveryEquipment
        {
            get { return (string)this["DELIVERYEQUIPMENT"]; }
            set { this["DELIVERYEQUIPMENT"] = value; }
        }

    /// <summary>
    /// Teknik Destek Alabilecek Personel Durumu
    /// </summary>
        public string TechAssistancePersonalStatus
        {
            get { return (string)this["TECHASSISTANCEPERSONALSTATUS"]; }
            set { this["TECHASSISTANCEPERSONALSTATUS"] = value; }
        }

    /// <summary>
    /// Sağlık Birimlerinin Hizmet Verdiği Personel Sayısı
    /// </summary>
        public string HealtUnitPersonelCount
        {
            get { return (string)this["HEALTUNITPERSONELCOUNT"]; }
            set { this["HEALTUNITPERSONELCOUNT"] = value; }
        }

    /// <summary>
    /// Sağlık Birimleri Yıllık İstatislikleri
    /// </summary>
        public string YearlyStatistics
        {
            get { return (string)this["YEARLYSTATISTICS"]; }
            set { this["YEARLYSTATISTICS"] = value; }
        }

    /// <summary>
    /// Sağlık Birimlerinin Tetkik ve Tedavi İmkanları
    /// </summary>
        public string TreatmentAxe
        {
            get { return (string)this["TREATMENTAXE"]; }
            set { this["TREATMENTAXE"] = value; }
        }

    /// <summary>
    /// Küçük Cerrahi ve Ameliyat Sayıları
    /// </summary>
        public string OperationCount
        {
            get { return (string)this["OPERATIONCOUNT"]; }
            set { this["OPERATIONCOUNT"] = value; }
        }

    /// <summary>
    /// Teşkili Destekleyen Sağlık Birimi
    /// </summary>
        public string HealthDepartment
        {
            get { return (string)this["HEALTHDEPARTMENT"]; }
            set { this["HEALTHDEPARTMENT"] = value; }
        }

    /// <summary>
    /// Teknik Destek Alınabilecek En Yakın Bilgi İşlem Teşkilatı
    /// </summary>
        public string ITSystems
        {
            get { return (string)this["ITSYSTEMS"]; }
            set { this["ITSYSTEMS"] = value; }
        }

    /// <summary>
    /// Saülık Teşkil Adı
    /// </summary>
        public string HealtUnitName
        {
            get { return (string)this["HEALTUNITNAME"]; }
            set { this["HEALTUNITNAME"] = value; }
        }

    /// <summary>
    /// Tipi
    /// </summary>
        public string Type
        {
            get { return (string)this["TYPE"]; }
            set { this["TYPE"] = value; }
        }

    /// <summary>
    /// Bağlı Olduğu XXXXXXlık
    /// </summary>
        public string MilitaryUnit
        {
            get { return (string)this["MILITARYUNIT"]; }
            set { this["MILITARYUNIT"] = value; }
        }

    /// <summary>
    /// Sağlık Birimlerinde Görevli Personel Durumu
    /// </summary>
        public string PersonalStatus
        {
            get { return (string)this["PERSONALSTATUS"]; }
            set { this["PERSONALSTATUS"] = value; }
        }

    /// <summary>
    /// Yatak Sayısı
    /// </summary>
        public string BedCount
        {
            get { return (string)this["BEDCOUNT"]; }
            set { this["BEDCOUNT"] = value; }
        }

        protected HealtUnitDefinition(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected HealtUnitDefinition(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected HealtUnitDefinition(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected HealtUnitDefinition(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected HealtUnitDefinition(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "HEALTUNITDEFINITION", dataRow) { }
        protected HealtUnitDefinition(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "HEALTUNITDEFINITION", dataRow, isImported) { }
        public HealtUnitDefinition(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public HealtUnitDefinition(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public HealtUnitDefinition() : base() { }

    }
}