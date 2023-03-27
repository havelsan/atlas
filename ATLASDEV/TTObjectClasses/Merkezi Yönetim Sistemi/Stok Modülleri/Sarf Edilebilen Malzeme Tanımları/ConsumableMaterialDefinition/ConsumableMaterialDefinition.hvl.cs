
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="ConsumableMaterialDefinition")] 

    /// <summary>
    /// Sarf Edilebilen Malzeme Tanımları
    /// </summary>
    public  partial class ConsumableMaterialDefinition : Material
    {
        public class ConsumableMaterialDefinitionList : TTObjectCollection<ConsumableMaterialDefinition> { }
                    
        public class ChildConsumableMaterialDefinitionCollection : TTObject.TTChildObjectCollection<ConsumableMaterialDefinition>
        {
            public ChildConsumableMaterialDefinitionCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildConsumableMaterialDefinitionCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetConsumableMaterialDefinition_Class : TTReportNqlObject 
        {
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

            public string Barcode
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["BARCODE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["CONSUMABLEMATERIALDEFINITION"].AllPropertyDefs["BARCODE"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public long? MaterialCodeSequence
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MATERIALCODESEQUENCE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["CONSUMABLEMATERIALDEFINITION"].AllPropertyDefs["MATERIALCODESEQUENCE"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public string Name
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["NAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["CONSUMABLEMATERIALDEFINITION"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string OriginalName
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ORIGINALNAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["CONSUMABLEMATERIALDEFINITION"].AllPropertyDefs["ORIGINALNAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Materialtreename
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MATERIALTREENAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MATERIALTREEDEFINITION"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Stockcardname
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["STOCKCARDNAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["STOCKCARD"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public bool? AllowToGivePatient
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ALLOWTOGIVEPATIENT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["CONSUMABLEMATERIALDEFINITION"].AllPropertyDefs["ALLOWTOGIVEPATIENT"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public string NATOStockNO
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["NATOSTOCKNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["STOCKCARD"].AllPropertyDefs["NATOSTOCKNO"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public GetConsumableMaterialDefinition_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetConsumableMaterialDefinition_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetConsumableMaterialDefinition_Class() : base() { }
        }

        public static BindingList<ConsumableMaterialDefinition.GetConsumableMaterialDefinition_Class> GetConsumableMaterialDefinition(string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["CONSUMABLEMATERIALDEFINITION"].QueryDefs["GetConsumableMaterialDefinition"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<ConsumableMaterialDefinition.GetConsumableMaterialDefinition_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<ConsumableMaterialDefinition.GetConsumableMaterialDefinition_Class> GetConsumableMaterialDefinition(TTObjectContext objectContext, string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["CONSUMABLEMATERIALDEFINITION"].QueryDefs["GetConsumableMaterialDefinition"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<ConsumableMaterialDefinition.GetConsumableMaterialDefinition_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<ConsumableMaterialDefinition> GetConsumableMaterial(TTObjectContext objectContext)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["CONSUMABLEMATERIALDEFINITION"].QueryDefs["GetConsumableMaterial"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return ((ITTQuery)objectContext).QueryObjects<ConsumableMaterialDefinition>(queryDef, paramList);
        }

        public static BindingList<ConsumableMaterialDefinition> GetConsumableMatDefByLastUpdateDate(TTObjectContext objectContext, DateTime STARTDATE, DateTime ENDDATE)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["CONSUMABLEMATERIALDEFINITION"].QueryDefs["GetConsumableMatDefByLastUpdateDate"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);

            return ((ITTQuery)objectContext).QueryObjects<ConsumableMaterialDefinition>(queryDef, paramList);
        }

    /// <summary>
    /// Allogreft Malzeme
    /// </summary>
        public bool? IsAllogreft
        {
            get { return (bool?)this["ISALLOGREFT"]; }
            set { this["ISALLOGREFT"] = value; }
        }

    /// <summary>
    /// Cinsiyet
    /// </summary>
        public SexEnum? SEX
        {
            get { return (SexEnum?)(int?)this["SEX"]; }
            set { this["SEX"] = value; }
        }

    /// <summary>
    /// Uygulanabilir Maximum Hasta Yaşı
    /// </summary>
        public int? MaxPatientAge
        {
            get { return (int?)this["MAXPATIENTAGE"]; }
            set { this["MAXPATIENTAGE"] = value; }
        }

    /// <summary>
    /// Uygulanabilir en küçük yaş
    /// </summary>
        public int? MinPatientAge
        {
            get { return (int?)this["MINPATIENTAGE"]; }
            set { this["MINPATIENTAGE"] = value; }
        }

    /// <summary>
    /// Tekrar Gün
    /// </summary>
        public double? OrderRPTDay
        {
            get { return (double?)this["ORDERRPTDAY"]; }
            set { this["ORDERRPTDAY"] = value; }
        }

        public object SpecificationFile
        {
            get { return (object)this["SPECIFICATIONFILE"]; }
            set { this["SPECIFICATIONFILE"] = value; }
        }

        public string SpecificationFileName
        {
            get { return (string)this["SPECIFICATIONFILENAME"]; }
            set { this["SPECIFICATIONFILENAME"] = value; }
        }

        public DateTime? SpecificationUploadDate
        {
            get { return (DateTime?)this["SPECIFICATIONUPLOADDATE"]; }
            set { this["SPECIFICATIONUPLOADDATE"] = value; }
        }

    /// <summary>
    /// Epikriz Formunda Görünmesin
    /// </summary>
        public bool? NotAppearInEpicrisis
        {
            get { return (bool?)this["NOTAPPEARINEPICRISIS"]; }
            set { this["NOTAPPEARINEPICRISIS"] = value; }
        }

    /// <summary>
    /// S.K.T Zorunlu Olsun
    /// </summary>
        public bool? HasEstimatedTime
        {
            get { return (bool?)this["HASESTIMATEDTIME"]; }
            set { this["HASESTIMATEDTIME"] = value; }
        }

        public ConsumableMaterialDefinition ParentConsumableMaterial
        {
            get { return (ConsumableMaterialDefinition)((ITTObject)this).GetParent("PARENTCONSUMABLEMATERIAL"); }
            set { this["PARENTCONSUMABLEMATERIAL"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        virtual protected void CreateConsumableMaterialDefinitionsCollection()
        {
            _ConsumableMaterialDefinitions = new ConsumableMaterialDefinition.ChildConsumableMaterialDefinitionCollection(this, new Guid("cd11ac63-2cd6-4e99-8c71-329770af7ed6"));
            ((ITTChildObjectCollection)_ConsumableMaterialDefinitions).GetChildren();
        }

        protected ConsumableMaterialDefinition.ChildConsumableMaterialDefinitionCollection _ConsumableMaterialDefinitions = null;
        public ConsumableMaterialDefinition.ChildConsumableMaterialDefinitionCollection ConsumableMaterialDefinitions
        {
            get
            {
                if (_ConsumableMaterialDefinitions == null)
                    CreateConsumableMaterialDefinitionsCollection();
                return _ConsumableMaterialDefinitions;
            }
        }

        virtual protected void CreateManuelEquivalentConsMatCollection()
        {
            _ManuelEquivalentConsMat = new EquivalentConsMaterial.ChildEquivalentConsMaterialCollection(this, new Guid("f8912815-0aeb-4e7f-a4c9-9bf97ec2f435"));
            ((ITTChildObjectCollection)_ManuelEquivalentConsMat).GetChildren();
        }

        protected EquivalentConsMaterial.ChildEquivalentConsMaterialCollection _ManuelEquivalentConsMat = null;
        public EquivalentConsMaterial.ChildEquivalentConsMaterialCollection ManuelEquivalentConsMat
        {
            get
            {
                if (_ManuelEquivalentConsMat == null)
                    CreateManuelEquivalentConsMatCollection();
                return _ManuelEquivalentConsMat;
            }
        }

        protected ConsumableMaterialDefinition(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected ConsumableMaterialDefinition(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected ConsumableMaterialDefinition(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected ConsumableMaterialDefinition(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected ConsumableMaterialDefinition(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "CONSUMABLEMATERIALDEFINITION", dataRow) { }
        protected ConsumableMaterialDefinition(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "CONSUMABLEMATERIALDEFINITION", dataRow, isImported) { }
        public ConsumableMaterialDefinition(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public ConsumableMaterialDefinition(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public ConsumableMaterialDefinition() : base() { }

    }
}