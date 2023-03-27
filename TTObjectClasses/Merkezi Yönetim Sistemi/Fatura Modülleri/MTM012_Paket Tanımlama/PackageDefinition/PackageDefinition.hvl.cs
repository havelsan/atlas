
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="PackageDefinition")] 

    /// <summary>
    /// Paket Tanımlama
    /// </summary>
    public  partial class PackageDefinition : TerminologyManagerDef
    {
        public class PackageDefinitionList : TTObjectCollection<PackageDefinition> { }
                    
        public class ChildPackageDefinitionCollection : TTObject.TTChildObjectCollection<PackageDefinition>
        {
            public ChildPackageDefinitionCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildPackageDefinitionCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetPackageDefinitions_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public long? ID
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ID"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PACKAGEDEFINITION"].AllPropertyDefs["ID"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PACKAGEDEFINITION"].AllPropertyDefs["CODE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PACKAGEDEFINITION"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public int? DayLimit
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DAYLIMIT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PACKAGEDEFINITION"].AllPropertyDefs["DAYLIMIT"].DataType;
                    return (int?)dataType.ConvertValue(val);
                }
            }

            public GetPackageDefinitions_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetPackageDefinitions_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetPackageDefinitions_Class() : base() { }
        }

        public static BindingList<PackageDefinition> GetByObjectID(TTObjectContext objectContext, string PARAMOBJECTID)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PACKAGEDEFINITION"].QueryDefs["GetByObjectID"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("PARAMOBJECTID", PARAMOBJECTID);

            return ((ITTQuery)objectContext).QueryObjects<PackageDefinition>(queryDef, paramList);
        }

        public static BindingList<PackageDefinition.GetPackageDefinitions_Class> GetPackageDefinitions(string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PACKAGEDEFINITION"].QueryDefs["GetPackageDefinitions"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<PackageDefinition.GetPackageDefinitions_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<PackageDefinition.GetPackageDefinitions_Class> GetPackageDefinitions(TTObjectContext objectContext, string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PACKAGEDEFINITION"].QueryDefs["GetPackageDefinitions"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<PackageDefinition.GetPackageDefinitions_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<PackageDefinition> GetPackageDefinitionByLastUpdateDate(TTObjectContext objectContext, DateTime STARTDATE, DateTime ENDDATE)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PACKAGEDEFINITION"].QueryDefs["GetPackageDefinitionByLastUpdateDate"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);

            return ((ITTQuery)objectContext).QueryObjects<PackageDefinition>(queryDef, paramList);
        }

    /// <summary>
    /// Ad
    /// </summary>
        public string Name
        {
            get { return (string)this["NAME"]; }
            set { this["NAME"] = value; }
        }

    /// <summary>
    /// Kod
    /// </summary>
        public string Code
        {
            get { return (string)this["CODE"]; }
            set { this["CODE"] = value; }
        }

    /// <summary>
    /// Yatak Gün Limiti
    /// </summary>
        public int? DayLimit
        {
            get { return (int?)this["DAYLIMIT"]; }
            set { this["DAYLIMIT"] = value; }
        }

    /// <summary>
    /// ID
    /// </summary>
        public TTSequence ID
        {
            get { return GetSequence("ID"); }
        }

    /// <summary>
    /// Ücretlendirmede Paket Kuralları Kullanılır
    /// </summary>
        public bool? UsePackageRulesForPricing
        {
            get { return (bool?)this["USEPACKAGERULESFORPRICING"]; }
            set { this["USEPACKAGERULESFORPRICING"] = value; }
        }

    /// <summary>
    /// Eşleştirilmiş Hizmet Adı
    /// </summary>
        public PackageProcedureDefinition PackageProcedureDefinition
        {
            get { return (PackageProcedureDefinition)((ITTObject)this).GetParent("PACKAGEPROCEDUREDEFINITION"); }
            set { this["PACKAGEPROCEDUREDEFINITION"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Yatak Sınıfı
    /// </summary>
        public BedClassDefinition BedClassDefinition
        {
            get { return (BedClassDefinition)((ITTObject)this).GetParent("BEDCLASSDEFINITION"); }
            set { this["BEDCLASSDEFINITION"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        virtual protected void CreateSubActionProcedureCollection()
        {
            _SubActionProcedure = new SubActionProcedure.ChildSubActionProcedureCollection(this, new Guid("b2cdf98f-5f80-40c1-83a6-408d98462962"));
            ((ITTChildObjectCollection)_SubActionProcedure).GetChildren();
        }

        protected SubActionProcedure.ChildSubActionProcedureCollection _SubActionProcedure = null;
        public SubActionProcedure.ChildSubActionProcedureCollection SubActionProcedure
        {
            get
            {
                if (_SubActionProcedure == null)
                    CreateSubActionProcedureCollection();
                return _SubActionProcedure;
            }
        }

        virtual protected void CreatePackageDetailMaterialsCollection()
        {
            _PackageDetailMaterials = new PackageDetailMaterial.ChildPackageDetailMaterialCollection(this, new Guid("11a1c880-86ff-4b82-8e0b-92d6d3582b68"));
            ((ITTChildObjectCollection)_PackageDetailMaterials).GetChildren();
        }

        protected PackageDetailMaterial.ChildPackageDetailMaterialCollection _PackageDetailMaterials = null;
    /// <summary>
    /// Child collection for Paket Tanımlama ile ilişkisi
    /// </summary>
        public PackageDetailMaterial.ChildPackageDetailMaterialCollection PackageDetailMaterials
        {
            get
            {
                if (_PackageDetailMaterials == null)
                    CreatePackageDetailMaterialsCollection();
                return _PackageDetailMaterials;
            }
        }

        virtual protected void CreateAccountTransactionCollection()
        {
            _AccountTransaction = new AccountTransaction.ChildAccountTransactionCollection(this, new Guid("6f54d742-c6ea-4863-a0b7-d39531fffe3e"));
            ((ITTChildObjectCollection)_AccountTransaction).GetChildren();
        }

        protected AccountTransaction.ChildAccountTransactionCollection _AccountTransaction = null;
    /// <summary>
    /// Child collection for Paket tanımına ilişki
    /// </summary>
        public AccountTransaction.ChildAccountTransactionCollection AccountTransaction
        {
            get
            {
                if (_AccountTransaction == null)
                    CreateAccountTransactionCollection();
                return _AccountTransaction;
            }
        }

        virtual protected void CreatePackageDetailProceduresCollection()
        {
            _PackageDetailProcedures = new PackageDetailProcedure.ChildPackageDetailProcedureCollection(this, new Guid("ceeed92b-06dc-42f4-ac9f-cb05841a094b"));
            ((ITTChildObjectCollection)_PackageDetailProcedures).GetChildren();
        }

        protected PackageDetailProcedure.ChildPackageDetailProcedureCollection _PackageDetailProcedures = null;
    /// <summary>
    /// Child collection for Paket Tanımlama ile ilişkisi
    /// </summary>
        public PackageDetailProcedure.ChildPackageDetailProcedureCollection PackageDetailProcedures
        {
            get
            {
                if (_PackageDetailProcedures == null)
                    CreatePackageDetailProceduresCollection();
                return _PackageDetailProcedures;
            }
        }

        virtual protected void CreatePackageTransferCollection()
        {
            _PackageTransfer = new PackageTransfer.ChildPackageTransferCollection(this, new Guid("32da0ecd-3154-442d-a4f1-d88d3dfc85a2"));
            ((ITTChildObjectCollection)_PackageTransfer).GetChildren();
        }

        protected PackageTransfer.ChildPackageTransferCollection _PackageTransfer = null;
    /// <summary>
    /// Child collection for Paket Tanımına ilişki
    /// </summary>
        public PackageTransfer.ChildPackageTransferCollection PackageTransfer
        {
            get
            {
                if (_PackageTransfer == null)
                    CreatePackageTransferCollection();
                return _PackageTransfer;
            }
        }

        virtual protected void CreatePackageExceptionProceduresCollection()
        {
            _PackageExceptionProcedures = new PackageExceptionProcedure.ChildPackageExceptionProcedureCollection(this, new Guid("3f06e204-273c-45c4-80c6-d300cbcb3a14"));
            ((ITTChildObjectCollection)_PackageExceptionProcedures).GetChildren();
        }

        protected PackageExceptionProcedure.ChildPackageExceptionProcedureCollection _PackageExceptionProcedures = null;
    /// <summary>
    /// Child collection for Paket Tanımlama ile ilişkisi
    /// </summary>
        public PackageExceptionProcedure.ChildPackageExceptionProcedureCollection PackageExceptionProcedures
        {
            get
            {
                if (_PackageExceptionProcedures == null)
                    CreatePackageExceptionProceduresCollection();
                return _PackageExceptionProcedures;
            }
        }

        virtual protected void CreatePackageExceptionMaterialsCollection()
        {
            _PackageExceptionMaterials = new PackageExceptionMaterial.ChildPackageExceptionMaterialCollection(this, new Guid("a61d3536-f03b-46cd-8f8d-9f0bc6529415"));
            ((ITTChildObjectCollection)_PackageExceptionMaterials).GetChildren();
        }

        protected PackageExceptionMaterial.ChildPackageExceptionMaterialCollection _PackageExceptionMaterials = null;
    /// <summary>
    /// Child collection for Paket Tanımlama ile ilişkisi
    /// </summary>
        public PackageExceptionMaterial.ChildPackageExceptionMaterialCollection PackageExceptionMaterials
        {
            get
            {
                if (_PackageExceptionMaterials == null)
                    CreatePackageExceptionMaterialsCollection();
                return _PackageExceptionMaterials;
            }
        }

        virtual protected void CreateProtocolPriceCollection()
        {
            _ProtocolPrice = new ProtocolPriceCalculation.ChildProtocolPriceCalculationCollection(this, new Guid("8b34e707-b716-49a2-98b1-f0433b05d606"));
            ((ITTChildObjectCollection)_ProtocolPrice).GetChildren();
        }

        protected ProtocolPriceCalculation.ChildProtocolPriceCalculationCollection _ProtocolPrice = null;
        public ProtocolPriceCalculation.ChildProtocolPriceCalculationCollection ProtocolPrice
        {
            get
            {
                if (_ProtocolPrice == null)
                    CreateProtocolPriceCollection();
                return _ProtocolPrice;
            }
        }

        protected PackageDefinition(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected PackageDefinition(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected PackageDefinition(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected PackageDefinition(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected PackageDefinition(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "PACKAGEDEFINITION", dataRow) { }
        protected PackageDefinition(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "PACKAGEDEFINITION", dataRow, isImported) { }
        public PackageDefinition(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public PackageDefinition(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public PackageDefinition() : base() { }

    }
}