
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="BloodBankTestDefinition")] 

    /// <summary>
    /// Kan Bankası Hizmet Tanımı
    /// </summary>
    public  partial class BloodBankTestDefinition : ProcedureDefinition, IProcedureRequestDefinition
    {
        public class BloodBankTestDefinitionList : TTObjectCollection<BloodBankTestDefinition> { }
                    
        public class ChildBloodBankTestDefinitionCollection : TTObject.TTChildObjectCollection<BloodBankTestDefinition>
        {
            public ChildBloodBankTestDefinitionCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildBloodBankTestDefinitionCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetBloodBankTestDefinitions_Class : TTReportNqlObject 
        {
            public string Code
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["CODE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["BLOODBANKTESTDEFINITION"].AllPropertyDefs["CODE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["BLOODBANKTESTDEFINITION"].AllPropertyDefs["NAME"].DataType;
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

            public GetBloodBankTestDefinitions_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetBloodBankTestDefinitions_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetBloodBankTestDefinitions_Class() : base() { }
        }

        public static BindingList<BloodBankTestDefinition.GetBloodBankTestDefinitions_Class> GetBloodBankTestDefinitions(string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["BLOODBANKTESTDEFINITION"].QueryDefs["GetBloodBankTestDefinitions"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<BloodBankTestDefinition.GetBloodBankTestDefinitions_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<BloodBankTestDefinition.GetBloodBankTestDefinitions_Class> GetBloodBankTestDefinitions(TTObjectContext objectContext, string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["BLOODBANKTESTDEFINITION"].QueryDefs["GetBloodBankTestDefinitions"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<BloodBankTestDefinition.GetBloodBankTestDefinitions_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

    /// <summary>
    /// Kan Dağıtım Şekli
    /// </summary>
        public BloodDeliveryType? BloodDeliveryType
        {
            get { return (BloodDeliveryType?)(int?)this["BLOODDELIVERYTYPE"]; }
            set { this["BLOODDELIVERYTYPE"] = value; }
        }

    /// <summary>
    /// Kan Ürün Türü
    /// </summary>
        public BloodProductType? BloodProductType
        {
            get { return (BloodProductType?)(int?)this["BLOODPRODUCTTYPE"]; }
            set { this["BLOODPRODUCTTYPE"] = value; }
        }

    /// <summary>
    /// Kan Grup Türü
    /// </summary>
        public BloodGroupEnum? BloodGroupType
        {
            get { return (BloodGroupEnum?)(int?)this["BLOODGROUPTYPE"]; }
            set { this["BLOODGROUPTYPE"] = value; }
        }

    /// <summary>
    /// Barkod Numarası
    /// </summary>
        public long? BarcodeNo
        {
            get { return (long?)this["BARCODENO"]; }
            set { this["BARCODENO"] = value; }
        }

    /// <summary>
    /// Ürün Bazında Ücretlenir
    /// </summary>
        public bool? OnlyChargeWithProduct
        {
            get { return (bool?)this["ONLYCHARGEWITHPRODUCT"]; }
            set { this["ONLYCHARGEWITHPRODUCT"] = value; }
        }

        virtual protected void CreateMaterialsCollection()
        {
            _Materials = new BloodBankGridMaterialDefinition.ChildBloodBankGridMaterialDefinitionCollection(this, new Guid("3fdbf080-8dca-48e2-a470-05d8099e9985"));
            ((ITTChildObjectCollection)_Materials).GetChildren();
        }

        protected BloodBankGridMaterialDefinition.ChildBloodBankGridMaterialDefinitionCollection _Materials = null;
    /// <summary>
    /// Child collection for Kan Bnakası Test Tanım İlişkisi
    /// </summary>
        public BloodBankGridMaterialDefinition.ChildBloodBankGridMaterialDefinitionCollection Materials
        {
            get
            {
                if (_Materials == null)
                    CreateMaterialsCollection();
                return _Materials;
            }
        }

        virtual protected void CreateSubProceduresCollection()
        {
            _SubProcedures = new BloodBankGridProcedureDefinition.ChildBloodBankGridProcedureDefinitionCollection(this, new Guid("f07f3453-d4c0-4299-a152-d69d46ae3ba5"));
            ((ITTChildObjectCollection)_SubProcedures).GetChildren();
        }

        protected BloodBankGridProcedureDefinition.ChildBloodBankGridProcedureDefinitionCollection _SubProcedures = null;
        public BloodBankGridProcedureDefinition.ChildBloodBankGridProcedureDefinitionCollection SubProcedures
        {
            get
            {
                if (_SubProcedures == null)
                    CreateSubProceduresCollection();
                return _SubProcedures;
            }
        }

        protected BloodBankTestDefinition(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected BloodBankTestDefinition(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected BloodBankTestDefinition(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected BloodBankTestDefinition(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected BloodBankTestDefinition(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "BLOODBANKTESTDEFINITION", dataRow) { }
        protected BloodBankTestDefinition(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "BLOODBANKTESTDEFINITION", dataRow, isImported) { }
        public BloodBankTestDefinition(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public BloodBankTestDefinition(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public BloodBankTestDefinition() : base() { }

    }
}