
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="Material")] 

    /// <summary>
    /// Stok kartına bağlı olan malzeme tanımları için kullanılan sınıftır
    /// </summary>
    public  partial class Material : TerminologyManagerDef, ITTListObject, ISUTRulableMaterial
    {
        public class MaterialList : TTObjectCollection<Material> { }
                    
        public class ChildMaterialCollection : TTObject.TTChildObjectCollection<Material>
        {
            public ChildMaterialCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildMaterialCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetStockCardListReportQuery_Class : TTReportNqlObject 
        {
            public string Mainclass
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MAINCLASS"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["STOCKCARDCLASS"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Classname
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["CLASSNAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["STOCKCARDCLASS"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Mainmaterialname
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MAINMATERIALNAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MATERIALTREEDEFINITION"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public long? CardOrderNO
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["CARDORDERNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["STOCKCARD"].AllPropertyDefs["CARDORDERNO"].DataType;
                    return (long?)dataType.ConvertValue(val);
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

            public string Materialname
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MATERIALNAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MATERIAL"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public StockCardStatusEnum? Status
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["STATUS"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["STOCKCARD"].AllPropertyDefs["STATUS"].DataType;
                    return (StockCardStatusEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public string Storename
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["STORENAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["STORE"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public GetStockCardListReportQuery_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetStockCardListReportQuery_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetStockCardListReportQuery_Class() : base() { }
        }

        [Serializable] 

        public partial class GetMaterialDependStockCardReportQuery_Class : TTReportNqlObject 
        {
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

            public string Cardname
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["CARDNAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["STOCKCARD"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public long? CardOrderNO
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["CARDORDERNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["STOCKCARD"].AllPropertyDefs["CARDORDERNO"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MATERIAL"].AllPropertyDefs["CODE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MATERIAL"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public GetMaterialDependStockCardReportQuery_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetMaterialDependStockCardReportQuery_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetMaterialDependStockCardReportQuery_Class() : base() { }
        }

        [Serializable] 

        public partial class GetMaterialListQuery_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public bool? AllowToGivePatient
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ALLOWTOGIVEPATIENT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MATERIAL"].AllPropertyDefs["ALLOWTOGIVEPATIENT"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public bool? Chargable
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["CHARGABLE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MATERIAL"].AllPropertyDefs["CHARGABLE"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public long? MaterialCodeSequence
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MATERIALCODESEQUENCE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MATERIAL"].AllPropertyDefs["MATERIALCODESEQUENCE"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public string Description
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DESCRIPTION"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MATERIAL"].AllPropertyDefs["DESCRIPTION"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MATERIAL"].AllPropertyDefs["NAME"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MATERIAL"].AllPropertyDefs["ORIGINALNAME"].DataType;
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

            public string Distributiontypename
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DISTRIBUTIONTYPENAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DISTRIBUTIONTYPEDEFINITION"].AllPropertyDefs["DISTRIBUTIONTYPE"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Barcode
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["BARCODE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MATERIAL"].AllPropertyDefs["BARCODE"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public bool? IsIndividualTrackingRequired
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ISINDIVIDUALTRACKINGREQUIRED"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MATERIAL"].AllPropertyDefs["ISINDIVIDUALTRACKINGREQUIRED"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public GetMaterialListQuery_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetMaterialListQuery_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetMaterialListQuery_Class() : base() { }
        }

        [Serializable] 

        public partial class GetDrugAndMagistrals_Class : TTReportNqlObject 
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MATERIAL"].AllPropertyDefs["NAME"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MATERIAL"].AllPropertyDefs["ORIGINALNAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Code
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["CODE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MATERIAL"].AllPropertyDefs["CODE"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public GetDrugAndMagistrals_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetDrugAndMagistrals_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetDrugAndMagistrals_Class() : base() { }
        }

        [Serializable] 

        public partial class GetMaterialDetail_Class : TTReportNqlObject 
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MATERIAL"].AllPropertyDefs["CODE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MATERIAL"].AllPropertyDefs["NAME"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MATERIAL"].AllPropertyDefs["ORIGINALNAME"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MATERIAL"].AllPropertyDefs["CHARGABLE"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public bool? AllowToGivePatient
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ALLOWTOGIVEPATIENT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MATERIAL"].AllPropertyDefs["ALLOWTOGIVEPATIENT"].DataType;
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

            public string Stockcardnsn
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["STOCKCARDNSN"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["STOCKCARD"].AllPropertyDefs["NATOSTOCKNO"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public long? Stockcardorderno
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["STOCKCARDORDERNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["STOCKCARD"].AllPropertyDefs["CARDORDERNO"].DataType;
                    return (long?)dataType.ConvertValue(val);
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

            public string Stockcardclasscode
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["STOCKCARDCLASSCODE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["STOCKCARDCLASS"].AllPropertyDefs["CODE"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Stockcardclassname
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["STOCKCARDCLASSNAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["STOCKCARDCLASS"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public object MaterialPicture
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MATERIALPICTURE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MATERIAL"].AllPropertyDefs["MATERIALPICTURE"].DataType;
                    return (object)dataType.ConvertValue(val);
                }
            }

            public GetMaterialDetail_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetMaterialDetail_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetMaterialDetail_Class() : base() { }
        }

        [Serializable] 

        public partial class GetMaterialPricingDetail_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public string Pricinglistname
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PRICINGLISTNAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PRICINGLISTDEFINITION"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Pricinglistgroupname
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PRICINGLISTGROUPNAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PRICINGLISTGROUPDEFINITION"].AllPropertyDefs["DESCRIPTION"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Currencytypename
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["CURRENCYTYPENAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["CURRENCYTYPEDEFINITION"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public Currency? Price
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PRICE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PRICINGDETAILDEFINITION"].AllPropertyDefs["PRICE"].DataType;
                    return (Currency?)dataType.ConvertValue(val);
                }
            }

            public DateTime? DateStart
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DATESTART"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PRICINGDETAILDEFINITION"].AllPropertyDefs["DATESTART"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public DateTime? DateEnd
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DATEEND"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PRICINGDETAILDEFINITION"].AllPropertyDefs["DATEEND"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public GetMaterialPricingDetail_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetMaterialPricingDetail_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetMaterialPricingDetail_Class() : base() { }
        }

        [Serializable] 

        public partial class GetStockCardListByGroupReportQuery_Class : TTReportNqlObject 
        {
            public string Name
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["NAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["STOCKCARDCLASS"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public StockCardStatusEnum? Status
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["STATUS"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["STOCKCARD"].AllPropertyDefs["STATUS"].DataType;
                    return (StockCardStatusEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public Object Countstatus
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["COUNTSTATUS"]);
                }
            }

            public GetStockCardListByGroupReportQuery_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetStockCardListByGroupReportQuery_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetStockCardListByGroupReportQuery_Class() : base() { }
        }

        [Serializable] 

        public partial class OLAP_Material_Class : TTReportNqlObject 
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MATERIAL"].AllPropertyDefs["CODE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MATERIAL"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public Guid? MaterialTree
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["MATERIALTREE"]);
                }
            }

            public Guid? StockCard
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["STOCKCARD"]);
                }
            }

            public OLAP_Material_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public OLAP_Material_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected OLAP_Material_Class() : base() { }
        }

        [Serializable] 

        public partial class GetMaterialInheldReportQuery_Class : TTReportNqlObject 
        {
            public string Storename
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["STORENAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["STORE"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public Object Inheld
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["INHELD"]);
                }
            }

            public GetMaterialInheldReportQuery_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetMaterialInheldReportQuery_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetMaterialInheldReportQuery_Class() : base() { }
        }

        [Serializable] 

        public partial class GetMaterials_Class : TTReportNqlObject 
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MATERIAL"].AllPropertyDefs["NAME"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MATERIAL"].AllPropertyDefs["ORIGINALNAME"].DataType;
                    return (string)dataType.ConvertValue(val);
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

            public string Code
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["CODE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MATERIAL"].AllPropertyDefs["CODE"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public Currency? Inheld
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["INHELD"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["STOCK"].AllPropertyDefs["INHELD"].DataType;
                    return (Currency?)dataType.ConvertValue(val);
                }
            }

            public Guid? Store
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["STORE"]);
                }
            }

            public string Distributiontypename
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DISTRIBUTIONTYPENAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DISTRIBUTIONTYPEDEFINITION"].AllPropertyDefs["DISTRIBUTIONTYPE"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public GetMaterials_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetMaterials_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetMaterials_Class() : base() { }
        }

        [Serializable] 

        public partial class GetMaterialWithNoEffectivePrice_Class : TTReportNqlObject 
        {
            public string Code
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["CODE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MATERIAL"].AllPropertyDefs["CODE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MATERIAL"].AllPropertyDefs["NAME"].DataType;
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

            public string Mattreedesc
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MATTREEDESC"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MATERIALTREEDEFINITION"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public GetMaterialWithNoEffectivePrice_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetMaterialWithNoEffectivePrice_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetMaterialWithNoEffectivePrice_Class() : base() { }
        }

        [Serializable] 

        public partial class GetMaterialBarcodeLevelDetail_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public string Producername
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PRODUCERNAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PRODUCER"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Barcode
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["BARCODE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MATERIALBARCODELEVEL"].AllPropertyDefs["BARCODE"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public double? PackageAmount
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PACKAGEAMOUNT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MATERIALBARCODELEVEL"].AllPropertyDefs["PACKAGEAMOUNT"].DataType;
                    return (double?)dataType.ConvertValue(val);
                }
            }

            public string LicenceNO
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["LICENCENO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MATERIALBARCODELEVEL"].AllPropertyDefs["LICENCENO"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public LicencingOrganizationEnum? LicencingOrganization
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["LICENCINGORGANIZATION"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MATERIALBARCODELEVEL"].AllPropertyDefs["LICENCINGORGANIZATION"].DataType;
                    return (LicencingOrganizationEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public DateTime? LicenceDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["LICENCEDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MATERIALBARCODELEVEL"].AllPropertyDefs["LICENCEDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public GetMaterialBarcodeLevelDetail_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetMaterialBarcodeLevelDetail_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetMaterialBarcodeLevelDetail_Class() : base() { }
        }

        [Serializable] 

        public partial class GetMaterialNonDependStockCard_Class : TTReportNqlObject 
        {
            public string Code
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["CODE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MATERIAL"].AllPropertyDefs["CODE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MATERIAL"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public GetMaterialNonDependStockCard_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetMaterialNonDependStockCard_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetMaterialNonDependStockCard_Class() : base() { }
        }

        [Serializable] 

        public partial class GetStockCardsToActReportQuery_Class : TTReportNqlObject 
        {
            public string Mainclassname
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MAINCLASSNAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["STOCKCARDCLASS"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public long? CardOrderNO
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["CARDORDERNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["STOCKCARD"].AllPropertyDefs["CARDORDERNO"].DataType;
                    return (long?)dataType.ConvertValue(val);
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

            public string Materialname
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MATERIALNAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MATERIAL"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Classname
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["CLASSNAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["STOCKCARDCLASS"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public Object Transactioncount
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["TRANSACTIONCOUNT"]);
                }
            }

            public GetStockCardsToActReportQuery_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetStockCardsToActReportQuery_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetStockCardsToActReportQuery_Class() : base() { }
        }

        [Serializable] 

        public partial class GetMaterialsWithPrice_Class : TTReportNqlObject 
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MATERIAL"].AllPropertyDefs["NAME"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MATERIAL"].AllPropertyDefs["ORIGINALNAME"].DataType;
                    return (string)dataType.ConvertValue(val);
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

            public string Code
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["CODE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MATERIAL"].AllPropertyDefs["CODE"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public Object Pricecode
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["PRICECODE"]);
                }
            }

            public Object Price
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["PRICE"]);
                }
            }

            public GetMaterialsWithPrice_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetMaterialsWithPrice_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetMaterialsWithPrice_Class() : base() { }
        }

        [Serializable] 

        public partial class OLAP_Material_WithDate_Class : TTReportNqlObject 
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MATERIAL"].AllPropertyDefs["CODE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MATERIAL"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public Guid? MaterialTree
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["MATERIALTREE"]);
                }
            }

            public Guid? StockCard
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["STOCKCARD"]);
                }
            }

            public OLAP_Material_WithDate_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public OLAP_Material_WithDate_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected OLAP_Material_WithDate_Class() : base() { }
        }

        [Serializable] 

        public partial class GetMaterialWithMultiEffectivePriceByPriceList_Class : TTReportNqlObject 
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MATERIAL"].AllPropertyDefs["CODE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MATERIAL"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public Object Pricecount
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["PRICECOUNT"]);
                }
            }

            public GetMaterialWithMultiEffectivePriceByPriceList_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetMaterialWithMultiEffectivePriceByPriceList_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetMaterialWithMultiEffectivePriceByPriceList_Class() : base() { }
        }

        [Serializable] 

        public partial class GetOldMaterialListQuery_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public bool? AllowToGivePatient
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ALLOWTOGIVEPATIENT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MATERIAL"].AllPropertyDefs["ALLOWTOGIVEPATIENT"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public bool? Chargable
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["CHARGABLE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MATERIAL"].AllPropertyDefs["CHARGABLE"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public string Code
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["CODE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MATERIAL"].AllPropertyDefs["CODE"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Description
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DESCRIPTION"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MATERIAL"].AllPropertyDefs["DESCRIPTION"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MATERIAL"].AllPropertyDefs["NAME"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MATERIAL"].AllPropertyDefs["ORIGINALNAME"].DataType;
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

            public string Distributiontypename
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DISTRIBUTIONTYPENAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DISTRIBUTIONTYPEDEFINITION"].AllPropertyDefs["DISTRIBUTIONTYPE"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Barcode
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["BARCODE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MATERIAL"].AllPropertyDefs["BARCODE"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public GetOldMaterialListQuery_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetOldMaterialListQuery_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetOldMaterialListQuery_Class() : base() { }
        }

        [Serializable] 

        public partial class ProductMatchMaterialQuery_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
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

            public string ProductNumber
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PRODUCTNUMBER"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PRODUCTDEFINITION"].AllPropertyDefs["PRODUCTNUMBER"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PRODUCTDEFINITION"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public ProductMatchMaterialQuery_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public ProductMatchMaterialQuery_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected ProductMatchMaterialQuery_Class() : base() { }
        }

        [Serializable] 

        public partial class ProductNotMatchMaterialQuery_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
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

            public string Barcode
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["BARCODE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MATERIALPRODUCTLEVEL"].AllPropertyDefs["BARCODE"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public ProductNotMatchMaterialQuery_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public ProductNotMatchMaterialQuery_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected ProductNotMatchMaterialQuery_Class() : base() { }
        }

        [Serializable] 

        public partial class GetDrugAndMaterialListQuery_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public bool? AllowToGivePatient
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ALLOWTOGIVEPATIENT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MATERIAL"].AllPropertyDefs["ALLOWTOGIVEPATIENT"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public bool? Chargable
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["CHARGABLE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MATERIAL"].AllPropertyDefs["CHARGABLE"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public string Code
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["CODE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MATERIAL"].AllPropertyDefs["CODE"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Description
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DESCRIPTION"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MATERIAL"].AllPropertyDefs["DESCRIPTION"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MATERIAL"].AllPropertyDefs["NAME"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MATERIAL"].AllPropertyDefs["ORIGINALNAME"].DataType;
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

            public string Distributiontypename
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DISTRIBUTIONTYPENAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DISTRIBUTIONTYPEDEFINITION"].AllPropertyDefs["DISTRIBUTIONTYPE"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Barcode
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["BARCODE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MATERIAL"].AllPropertyDefs["BARCODE"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public Currency? Inheld
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["INHELD"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["STOCK"].AllPropertyDefs["INHELD"].DataType;
                    return (Currency?)dataType.ConvertValue(val);
                }
            }

            public GetDrugAndMaterialListQuery_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetDrugAndMaterialListQuery_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetDrugAndMaterialListQuery_Class() : base() { }
        }

        [Serializable] 

        public partial class GetPrescriptionMaterialListQuery_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public bool? AllowToGivePatient
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ALLOWTOGIVEPATIENT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MATERIAL"].AllPropertyDefs["ALLOWTOGIVEPATIENT"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public bool? Chargable
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["CHARGABLE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MATERIAL"].AllPropertyDefs["CHARGABLE"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public string Code
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["CODE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MATERIAL"].AllPropertyDefs["CODE"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Description
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DESCRIPTION"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MATERIAL"].AllPropertyDefs["DESCRIPTION"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MATERIAL"].AllPropertyDefs["NAME"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MATERIAL"].AllPropertyDefs["ORIGINALNAME"].DataType;
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

            public string Distributiontypename
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DISTRIBUTIONTYPENAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DISTRIBUTIONTYPEDEFINITION"].AllPropertyDefs["DISTRIBUTIONTYPE"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Barcode
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["BARCODE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MATERIAL"].AllPropertyDefs["BARCODE"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public GetPrescriptionMaterialListQuery_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetPrescriptionMaterialListQuery_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetPrescriptionMaterialListQuery_Class() : base() { }
        }

        [Serializable] 

        public partial class VEM_STOK_KART_Class : TTReportNqlObject 
        {
            public Guid? Stok_kart_kodu
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["STOK_KART_KODU"]);
                }
            }

            public Object Referans_tablo_adi
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["REFERANS_TABLO_ADI"]);
                }
            }

            public string Malzeme_adi
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MALZEME_ADI"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MATERIAL"].AllPropertyDefs["ORIGINALNAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public int? Mkys_malzeme_kodu
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MKYS_MALZEME_KODU"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MATERIAL"].AllPropertyDefs["MKYSMALZEMEKODU"].DataType;
                    return (int?)dataType.ConvertValue(val);
                }
            }

            public string Tasinir_kodu
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["TASINIR_KODU"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MATERIAL"].AllPropertyDefs["CODE"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public Guid? Malzeme_tipi
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["MALZEME_TIPI"]);
                }
            }

            public string Ilac_barkodu
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ILAC_BARKODU"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MATERIAL"].AllPropertyDefs["BARCODE"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public Object Malzeme_sut_kodu
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["MALZEME_SUT_KODU"]);
                }
            }

            public Object Recete_turu
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["RECETE_TURU"]);
                }
            }

            public double? Medula_carpani
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MEDULA_CARPANI"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MATERIAL"].AllPropertyDefs["MEDULAMULTIPLIER"].DataType;
                    return (double?)dataType.ConvertValue(val);
                }
            }

            public Object Ekleyen_kullanici_kodu
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["EKLEYEN_KULLANICI_KODU"]);
                }
            }

            public Object Guncelleme_tarihi
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["GUNCELLEME_TARIHI"]);
                }
            }

            public Object Guncelleyen_kullanici_kodu
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["GUNCELLEYEN_KULLANICI_KODU"]);
                }
            }

            public VEM_STOK_KART_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public VEM_STOK_KART_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected VEM_STOK_KART_Class() : base() { }
        }

        [Serializable] 

        public partial class GetAllowedDrugAndMaterialListQuery_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public bool? AllowToGivePatient
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ALLOWTOGIVEPATIENT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MATERIAL"].AllPropertyDefs["ALLOWTOGIVEPATIENT"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public bool? Chargable
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["CHARGABLE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MATERIAL"].AllPropertyDefs["CHARGABLE"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public long? MaterialCodeSequence
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MATERIALCODESEQUENCE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MATERIAL"].AllPropertyDefs["MATERIALCODESEQUENCE"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public string Description
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DESCRIPTION"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MATERIAL"].AllPropertyDefs["DESCRIPTION"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public MaterialDescriptionShowTypeEnum? MaterialDescriptionShowType
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MATERIALDESCRIPTIONSHOWTYPE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MATERIAL"].AllPropertyDefs["MATERIALDESCRIPTIONSHOWTYPE"].DataType;
                    return (MaterialDescriptionShowTypeEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public string Name
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["NAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MATERIAL"].AllPropertyDefs["NAME"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MATERIAL"].AllPropertyDefs["ORIGINALNAME"].DataType;
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

            public string Distributiontypename
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DISTRIBUTIONTYPENAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DISTRIBUTIONTYPEDEFINITION"].AllPropertyDefs["DISTRIBUTIONTYPE"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Barcode
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["BARCODE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MATERIAL"].AllPropertyDefs["BARCODE"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public MaterialPatientTypeEnum? MaterialPatientType
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MATERIALPATIENTTYPE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MATERIAL"].AllPropertyDefs["MATERIALPATIENTTYPE"].DataType;
                    return (MaterialPatientTypeEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public bool? DivideAmountToPatient
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DIVIDEAMOUNTTOPATIENT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MATERIAL"].AllPropertyDefs["DIVIDEAMOUNTTOPATIENT"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public double? DivideTotalAmount
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DIVIDETOTALAMOUNT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MATERIAL"].AllPropertyDefs["DIVIDETOTALAMOUNT"].DataType;
                    return (double?)dataType.ConvertValue(val);
                }
            }

            public double? DivideUnitAmount
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DIVIDEUNITAMOUNT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MATERIAL"].AllPropertyDefs["DIVIDEUNITAMOUNT"].DataType;
                    return (double?)dataType.ConvertValue(val);
                }
            }

            public Currency? Inheld
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["INHELD"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["STOCK"].AllPropertyDefs["INHELD"].DataType;
                    return (Currency?)dataType.ConvertValue(val);
                }
            }

            public GetAllowedDrugAndMaterialListQuery_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetAllowedDrugAndMaterialListQuery_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetAllowedDrugAndMaterialListQuery_Class() : base() { }
        }

        [Serializable] 

        public partial class GetMaterialsForOutReport_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public Guid? ObjectDefID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTDEFID"]);
                }
            }

            public Guid? CurrentStateDefID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["CURRENTSTATEDEFID"]);
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

            public DateTime? LastUpdate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["LASTUPDATE"]);
                    if (val == null)
                        return null;
                    return (DateTime)Convert.ChangeType(val, typeof(DateTime)); 
                }
            }

            public object MaterialPicture
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MATERIALPICTURE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MATERIAL"].AllPropertyDefs["MATERIALPICTURE"].DataType;
                    return (object)dataType.ConvertValue(val);
                }
            }

            public string Description
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DESCRIPTION"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MATERIAL"].AllPropertyDefs["DESCRIPTION"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MATERIAL"].AllPropertyDefs["NAME"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MATERIAL"].AllPropertyDefs["ALLOWTOGIVEPATIENT"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public string Code
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["CODE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MATERIAL"].AllPropertyDefs["CODE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MATERIAL"].AllPropertyDefs["ORIGINALNAME"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MATERIAL"].AllPropertyDefs["CHARGABLE"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public bool? DividePriceToVolume
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DIVIDEPRICETOVOLUME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MATERIAL"].AllPropertyDefs["DIVIDEPRICETOVOLUME"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public DateTime? AuctionDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["AUCTIONDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MATERIAL"].AllPropertyDefs["AUCTIONDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public string RegistrationAuctionNo
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["REGISTRATIONAUCTIONNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MATERIAL"].AllPropertyDefs["REGISTRATIONAUCTIONNO"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public bool? SetMedulaInfoByMultiplier
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["SETMEDULAINFOBYMULTIPLIER"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MATERIAL"].AllPropertyDefs["SETMEDULAINFOBYMULTIPLIER"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public string ETKMDescription
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ETKMDESCRIPTION"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MATERIAL"].AllPropertyDefs["ETKMDESCRIPTION"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public DateTime? CreationDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["CREATIONDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MATERIAL"].AllPropertyDefs["CREATIONDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public double? MedulaMultiplier
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MEDULAMULTIPLIER"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MATERIAL"].AllPropertyDefs["MEDULAMULTIPLIER"].DataType;
                    return (double?)dataType.ConvertValue(val);
                }
            }

            public bool? IsArmyDrug
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ISARMYDRUG"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MATERIAL"].AllPropertyDefs["ISARMYDRUG"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public bool? CreateInMedulaDontSendState
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["CREATEINMEDULADONTSENDSTATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MATERIAL"].AllPropertyDefs["CREATEINMEDULADONTSENDSTATE"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public bool? IsRestrictedMaterial
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ISRESTRICTEDMATERIAL"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MATERIAL"].AllPropertyDefs["ISRESTRICTEDMATERIAL"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public double? AccTrxAmountMultiplier
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ACCTRXAMOUNTMULTIPLIER"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MATERIAL"].AllPropertyDefs["ACCTRXAMOUNTMULTIPLIER"].DataType;
                    return (double?)dataType.ConvertValue(val);
                }
            }

            public double? AccTrxUnitPriceDivider
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ACCTRXUNITPRICEDIVIDER"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MATERIAL"].AllPropertyDefs["ACCTRXUNITPRICEDIVIDER"].DataType;
                    return (double?)dataType.ConvertValue(val);
                }
            }

            public bool? IsExpendableMaterial
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ISEXPENDABLEMATERIAL"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MATERIAL"].AllPropertyDefs["ISEXPENDABLEMATERIAL"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public string Barcode
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["BARCODE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MATERIAL"].AllPropertyDefs["BARCODE"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public DateTime? LicenceDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["LICENCEDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MATERIAL"].AllPropertyDefs["LICENCEDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public double? CurrentPrice
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["CURRENTPRICE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MATERIAL"].AllPropertyDefs["CURRENTPRICE"].DataType;
                    return (double?)dataType.ConvertValue(val);
                }
            }

            public double? Discount
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DISCOUNT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MATERIAL"].AllPropertyDefs["DISCOUNT"].DataType;
                    return (double?)dataType.ConvertValue(val);
                }
            }

            public string LicenceNO
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["LICENCENO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MATERIAL"].AllPropertyDefs["LICENCENO"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public LicencingOrganizationEnum? LicencingOrganization
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["LICENCINGORGANIZATION"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MATERIAL"].AllPropertyDefs["LICENCINGORGANIZATION"].DataType;
                    return (LicencingOrganizationEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public string BarcodeName
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["BARCODENAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MATERIAL"].AllPropertyDefs["BARCODENAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public double? PackageAmount
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PACKAGEAMOUNT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MATERIAL"].AllPropertyDefs["PACKAGEAMOUNT"].DataType;
                    return (double?)dataType.ConvertValue(val);
                }
            }

            public long? ProductNumber
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PRODUCTNUMBER"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MATERIAL"].AllPropertyDefs["PRODUCTNUMBER"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public long? SPTSDrugID
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["SPTSDRUGID"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MATERIAL"].AllPropertyDefs["SPTSDRUGID"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public int? SPTSLicencingOrganizationID
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["SPTSLICENCINGORGANIZATIONID"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MATERIAL"].AllPropertyDefs["SPTSLICENCINGORGANIZATIONID"].DataType;
                    return (int?)dataType.ConvertValue(val);
                }
            }

            public string Name_Shadow
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["NAME_SHADOW"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MATERIAL"].AllPropertyDefs["NAME_SHADOW"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public MaterialPricingTypeEnum? MaterialPricingType
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MATERIALPRICINGTYPE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MATERIAL"].AllPropertyDefs["MATERIALPRICINGTYPE"].DataType;
                    return (MaterialPricingTypeEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public DateTime? PurchaseDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PURCHASEDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MATERIAL"].AllPropertyDefs["PURCHASEDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public bool? IsOldMaterial
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ISOLDMATERIAL"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MATERIAL"].AllPropertyDefs["ISOLDMATERIAL"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public int? MkysMalzemeKodu
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MKYSMALZEMEKODU"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MATERIAL"].AllPropertyDefs["MKYSMALZEMEKODU"].DataType;
                    return (int?)dataType.ConvertValue(val);
                }
            }

            public MaterialTypeForInvoiceEnum? MaterialTypeForInvoice
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MATERIALTYPEFORINVOICE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MATERIAL"].AllPropertyDefs["MATERIALTYPEFORINVOICE"].DataType;
                    return (MaterialTypeForInvoiceEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public SUTMalzemeEKEnum? SUTAppendix
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["SUTAPPENDIX"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MATERIAL"].AllPropertyDefs["SUTAPPENDIX"].DataType;
                    return (SUTMalzemeEKEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public bool? ShowZeroOnDistributionInfo
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["SHOWZEROONDISTRIBUTIONINFO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MATERIAL"].AllPropertyDefs["SHOWZEROONDISTRIBUTIONINFO"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public bool? IsIndividualTrackingRequired
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ISINDIVIDUALTRACKINGREQUIRED"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MATERIAL"].AllPropertyDefs["ISINDIVIDUALTRACKINGREQUIRED"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public bool? IsPackageExclusive
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ISPACKAGEEXCLUSIVE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MATERIAL"].AllPropertyDefs["ISPACKAGEEXCLUSIVE"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public string StorageConditions
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["STORAGECONDITIONS"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MATERIAL"].AllPropertyDefs["STORAGECONDITIONS"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public int? EstimatedTimeOfCheck
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ESTIMATEDTIMEOFCHECK"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MATERIAL"].AllPropertyDefs["ESTIMATEDTIMEOFCHECK"].DataType;
                    return (int?)dataType.ConvertValue(val);
                }
            }

            public bool? IsTagNoRequired
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ISTAGNOREQUIRED"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MATERIAL"].AllPropertyDefs["ISTAGNOREQUIRED"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public MaterialDescriptionShowTypeEnum? MaterialDescriptionShowType
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MATERIALDESCRIPTIONSHOWTYPE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MATERIAL"].AllPropertyDefs["MATERIALDESCRIPTIONSHOWTYPE"].DataType;
                    return (MaterialDescriptionShowTypeEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public bool? DivideAmountToPatient
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DIVIDEAMOUNTTOPATIENT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MATERIAL"].AllPropertyDefs["DIVIDEAMOUNTTOPATIENT"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public double? DivideUnitAmount
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DIVIDEUNITAMOUNT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MATERIAL"].AllPropertyDefs["DIVIDEUNITAMOUNT"].DataType;
                    return (double?)dataType.ConvertValue(val);
                }
            }

            public double? DivideTotalAmount
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DIVIDETOTALAMOUNT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MATERIAL"].AllPropertyDefs["DIVIDETOTALAMOUNT"].DataType;
                    return (double?)dataType.ConvertValue(val);
                }
            }

            public int? PatientMaxDayOut
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PATIENTMAXDAYOUT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MATERIAL"].AllPropertyDefs["PATIENTMAXDAYOUT"].DataType;
                    return (int?)dataType.ConvertValue(val);
                }
            }

            public Currency? OperatingShare
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["OPERATINGSHARE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MATERIAL"].AllPropertyDefs["OPERATINGSHARE"].DataType;
                    return (Currency?)dataType.ConvertValue(val);
                }
            }

            public Currency? TresuryShare
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["TRESURYSHARE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MATERIAL"].AllPropertyDefs["TRESURYSHARE"].DataType;
                    return (Currency?)dataType.ConvertValue(val);
                }
            }

            public Currency? ShcekShare
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["SHCEKSHARE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MATERIAL"].AllPropertyDefs["SHCEKSHARE"].DataType;
                    return (Currency?)dataType.ConvertValue(val);
                }
            }

            public string IsmId
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ISMID"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MATERIAL"].AllPropertyDefs["ISMID"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public MaterialPatientTypeEnum? MaterialPatientType
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MATERIALPATIENTTYPE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MATERIAL"].AllPropertyDefs["MATERIALPATIENTTYPE"].DataType;
                    return (MaterialPatientTypeEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public bool? NotShownOnEpicrisisForm
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["NOTSHOWNONEPICRISISFORM"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MATERIAL"].AllPropertyDefs["NOTSHOWNONEPICRISISFORM"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public bool? DailyStay
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DAILYSTAY"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MATERIAL"].AllPropertyDefs["DAILYSTAY"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public long? MaterialCodeSequence
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MATERIALCODESEQUENCE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MATERIAL"].AllPropertyDefs["MATERIALCODESEQUENCE"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public bool? SendSMS
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["SENDSMS"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MATERIAL"].AllPropertyDefs["SENDSMS"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public int? MaximumEstimatedTimeOfCheck
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MAXIMUMESTIMATEDTIMEOFCHECK"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MATERIAL"].AllPropertyDefs["MAXIMUMESTIMATEDTIMEOFCHECK"].DataType;
                    return (int?)dataType.ConvertValue(val);
                }
            }

            public int? WarningDayDuration
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["WARNINGDAYDURATION"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MATERIAL"].AllPropertyDefs["WARNINGDAYDURATION"].DataType;
                    return (int?)dataType.ConvertValue(val);
                }
            }

            public GetMaterialsForOutReport_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetMaterialsForOutReport_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetMaterialsForOutReport_Class() : base() { }
        }

        [Serializable] 

        public partial class GetMaterialForStockQuery_Class : TTReportNqlObject 
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MATERIAL"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public GetMaterialForStockQuery_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetMaterialForStockQuery_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetMaterialForStockQuery_Class() : base() { }
        }

        [Serializable] 

        public partial class GetUTSMaterials_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public string Barcode
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["BARCODE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MATERIAL"].AllPropertyDefs["BARCODE"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public GetUTSMaterials_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetUTSMaterials_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetUTSMaterials_Class() : base() { }
        }

        [Serializable] 

        public partial class GetUTSMaterialsByBarcode_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public string Barcode
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["BARCODE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MATERIAL"].AllPropertyDefs["BARCODE"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public GetUTSMaterialsByBarcode_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetUTSMaterialsByBarcode_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetUTSMaterialsByBarcode_Class() : base() { }
        }

        [Serializable] 

        public partial class GetUTSMaterialDetails_Class : TTReportNqlObject 
        {
            public string Barcode
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["BARCODE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MATERIAL"].AllPropertyDefs["BARCODE"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Materialname
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MATERIALNAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MATERIAL"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Producername
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PRODUCERNAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PRODUCER"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public GetUTSMaterialDetails_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetUTSMaterialDetails_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetUTSMaterialDetails_Class() : base() { }
        }

        [Serializable] 

        public partial class GetRestAmounInStock_Class : TTReportNqlObject 
        {
            public Currency? Inheld
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["INHELD"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["STOCK"].AllPropertyDefs["INHELD"].DataType;
                    return (Currency?)dataType.ConvertValue(val);
                }
            }

            public GetRestAmounInStock_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetRestAmounInStock_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetRestAmounInStock_Class() : base() { }
        }

        [Serializable] 

        public partial class GetHospitalInventory_Class : TTReportNqlObject 
        {
            public Currency? Inheld
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["INHELD"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["STOCK"].AllPropertyDefs["INHELD"].DataType;
                    return (Currency?)dataType.ConvertValue(val);
                }
            }

            public string Name
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["NAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["STORE"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public GetHospitalInventory_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetHospitalInventory_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetHospitalInventory_Class() : base() { }
        }

        [Serializable] 

        public partial class GetNewMaterialInListQuery_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public bool? AllowToGivePatient
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ALLOWTOGIVEPATIENT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MATERIAL"].AllPropertyDefs["ALLOWTOGIVEPATIENT"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public bool? Chargable
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["CHARGABLE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MATERIAL"].AllPropertyDefs["CHARGABLE"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public long? MaterialCodeSequence
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MATERIALCODESEQUENCE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MATERIAL"].AllPropertyDefs["MATERIALCODESEQUENCE"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public string Description
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DESCRIPTION"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MATERIAL"].AllPropertyDefs["DESCRIPTION"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MATERIAL"].AllPropertyDefs["NAME"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MATERIAL"].AllPropertyDefs["ORIGINALNAME"].DataType;
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

            public string Stockcardengname
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["STOCKCARDENGNAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["STOCKCARD"].AllPropertyDefs["ENGLISHNAME"].DataType;
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

            public string Distributiontypename
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DISTRIBUTIONTYPENAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DISTRIBUTIONTYPEDEFINITION"].AllPropertyDefs["DISTRIBUTIONTYPE"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Barcode
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["BARCODE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MATERIAL"].AllPropertyDefs["BARCODE"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public bool? IsIndividualTrackingRequired
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ISINDIVIDUALTRACKINGREQUIRED"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MATERIAL"].AllPropertyDefs["ISINDIVIDUALTRACKINGREQUIRED"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public GetNewMaterialInListQuery_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetNewMaterialInListQuery_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetNewMaterialInListQuery_Class() : base() { }
        }

        [Serializable] 

        public partial class GetNewMaterialOutListQuery_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public bool? AllowToGivePatient
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ALLOWTOGIVEPATIENT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MATERIAL"].AllPropertyDefs["ALLOWTOGIVEPATIENT"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public bool? Chargable
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["CHARGABLE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MATERIAL"].AllPropertyDefs["CHARGABLE"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public long? MaterialCodeSequence
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MATERIALCODESEQUENCE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MATERIAL"].AllPropertyDefs["MATERIALCODESEQUENCE"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public string Description
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DESCRIPTION"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MATERIAL"].AllPropertyDefs["DESCRIPTION"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MATERIAL"].AllPropertyDefs["NAME"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MATERIAL"].AllPropertyDefs["ORIGINALNAME"].DataType;
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

            public string Stockcardengname
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["STOCKCARDENGNAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["STOCKCARD"].AllPropertyDefs["ENGLISHNAME"].DataType;
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

            public string Distributiontypename
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DISTRIBUTIONTYPENAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DISTRIBUTIONTYPEDEFINITION"].AllPropertyDefs["DISTRIBUTIONTYPE"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Barcode
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["BARCODE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MATERIAL"].AllPropertyDefs["BARCODE"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public bool? IsIndividualTrackingRequired
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ISINDIVIDUALTRACKINGREQUIRED"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MATERIAL"].AllPropertyDefs["ISINDIVIDUALTRACKINGREQUIRED"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public Currency? Inheld
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["INHELD"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["STOCK"].AllPropertyDefs["INHELD"].DataType;
                    return (Currency?)dataType.ConvertValue(val);
                }
            }

            public GetNewMaterialOutListQuery_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetNewMaterialOutListQuery_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetNewMaterialOutListQuery_Class() : base() { }
        }

        [Serializable] 

        public partial class GetMaterialByDistributionDoc_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public bool? AllowToGivePatient
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ALLOWTOGIVEPATIENT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MATERIAL"].AllPropertyDefs["ALLOWTOGIVEPATIENT"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public bool? Chargable
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["CHARGABLE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MATERIAL"].AllPropertyDefs["CHARGABLE"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public long? MaterialCodeSequence
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MATERIALCODESEQUENCE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MATERIAL"].AllPropertyDefs["MATERIALCODESEQUENCE"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public string Description
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DESCRIPTION"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MATERIAL"].AllPropertyDefs["DESCRIPTION"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MATERIAL"].AllPropertyDefs["NAME"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MATERIAL"].AllPropertyDefs["ORIGINALNAME"].DataType;
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

            public string Distributiontypename
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DISTRIBUTIONTYPENAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DISTRIBUTIONTYPEDEFINITION"].AllPropertyDefs["DISTRIBUTIONTYPE"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Barcode
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["BARCODE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MATERIAL"].AllPropertyDefs["BARCODE"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public bool? IsIndividualTrackingRequired
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ISINDIVIDUALTRACKINGREQUIRED"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MATERIAL"].AllPropertyDefs["ISINDIVIDUALTRACKINGREQUIRED"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public Currency? Inheld
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["INHELD"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["STOCK"].AllPropertyDefs["INHELD"].DataType;
                    return (Currency?)dataType.ConvertValue(val);
                }
            }

            public GetMaterialByDistributionDoc_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetMaterialByDistributionDoc_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetMaterialByDistributionDoc_Class() : base() { }
        }

        [Serializable] 

        public partial class GetMaterialsForMultiSelectForm_Class : TTReportNqlObject 
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MATERIAL"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Barcode
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["BARCODE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MATERIAL"].AllPropertyDefs["BARCODE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MATERIAL"].AllPropertyDefs["ORIGINALNAME"].DataType;
                    return (string)dataType.ConvertValue(val);
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

            public string Code
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["CODE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MATERIAL"].AllPropertyDefs["CODE"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public Currency? Inheld
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["INHELD"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["STOCK"].AllPropertyDefs["INHELD"].DataType;
                    return (Currency?)dataType.ConvertValue(val);
                }
            }

            public Guid? Store
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["STORE"]);
                }
            }

            public string Distributiontypename
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DISTRIBUTIONTYPENAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DISTRIBUTIONTYPEDEFINITION"].AllPropertyDefs["DISTRIBUTIONTYPE"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public bool? ShowZeroOnDistributionInfo
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["SHOWZEROONDISTRIBUTIONINFO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MATERIAL"].AllPropertyDefs["SHOWZEROONDISTRIBUTIONINFO"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public bool? IsTagNoRequired
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ISTAGNOREQUIRED"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MATERIAL"].AllPropertyDefs["ISTAGNOREQUIRED"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public Currency? MinimumLevel
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MINIMUMLEVEL"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["STOCK"].AllPropertyDefs["MINIMUMLEVEL"].DataType;
                    return (Currency?)dataType.ConvertValue(val);
                }
            }

            public Currency? MaximumLevel
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MAXIMUMLEVEL"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["STOCK"].AllPropertyDefs["MAXIMUMLEVEL"].DataType;
                    return (Currency?)dataType.ConvertValue(val);
                }
            }

            public Currency? CriticalLevel
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["CRITICALLEVEL"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["STOCK"].AllPropertyDefs["CRITICALLEVEL"].DataType;
                    return (Currency?)dataType.ConvertValue(val);
                }
            }

            public GetMaterialsForMultiSelectForm_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetMaterialsForMultiSelectForm_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetMaterialsForMultiSelectForm_Class() : base() { }
        }

        public static BindingList<Material.GetStockCardListReportQuery_Class> GetStockCardListReportQuery(Guid OBJECTID, int STATUS, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["MATERIAL"].QueryDefs["GetStockCardListReportQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("OBJECTID", OBJECTID);
            paramList.Add("STATUS", STATUS);

            return TTReportNqlObject.QueryObjects<Material.GetStockCardListReportQuery_Class>(queryDef, paramList, pi);
        }

        public static BindingList<Material.GetStockCardListReportQuery_Class> GetStockCardListReportQuery(TTObjectContext objectContext, Guid OBJECTID, int STATUS, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["MATERIAL"].QueryDefs["GetStockCardListReportQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("OBJECTID", OBJECTID);
            paramList.Add("STATUS", STATUS);

            return TTReportNqlObject.QueryObjects<Material.GetStockCardListReportQuery_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<Material.GetMaterialDependStockCardReportQuery_Class> GetMaterialDependStockCardReportQuery(PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["MATERIAL"].QueryDefs["GetMaterialDependStockCardReportQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<Material.GetMaterialDependStockCardReportQuery_Class>(queryDef, paramList, pi);
        }

        public static BindingList<Material.GetMaterialDependStockCardReportQuery_Class> GetMaterialDependStockCardReportQuery(TTObjectContext objectContext, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["MATERIAL"].QueryDefs["GetMaterialDependStockCardReportQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<Material.GetMaterialDependStockCardReportQuery_Class>(objectContext, queryDef, paramList, pi);
        }

    /// <summary>
    /// GetTreatmentMaterial
    /// </summary>
        public static BindingList<Material> GetTreatmentMaterial(TTObjectContext objectContext, string injectionSQL)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["MATERIAL"].QueryDefs["GetTreatmentMaterial"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return ((ITTQuery)objectContext).QueryObjects<Material>(queryDef, paramList, injectionSQL);
        }

        public static BindingList<Material.GetMaterialListQuery_Class> GetMaterialListQuery(string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["MATERIAL"].QueryDefs["GetMaterialListQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<Material.GetMaterialListQuery_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<Material.GetMaterialListQuery_Class> GetMaterialListQuery(TTObjectContext objectContext, string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["MATERIAL"].QueryDefs["GetMaterialListQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<Material.GetMaterialListQuery_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<Material.GetDrugAndMagistrals_Class> GetDrugAndMagistrals(string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["MATERIAL"].QueryDefs["GetDrugAndMagistrals"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<Material.GetDrugAndMagistrals_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<Material.GetDrugAndMagistrals_Class> GetDrugAndMagistrals(TTObjectContext objectContext, string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["MATERIAL"].QueryDefs["GetDrugAndMagistrals"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<Material.GetDrugAndMagistrals_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<Material.GetMaterialDetail_Class> GetMaterialDetail(string MATERIALOBJECTID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["MATERIAL"].QueryDefs["GetMaterialDetail"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("MATERIALOBJECTID", MATERIALOBJECTID);

            return TTReportNqlObject.QueryObjects<Material.GetMaterialDetail_Class>(queryDef, paramList, pi);
        }

        public static BindingList<Material.GetMaterialDetail_Class> GetMaterialDetail(TTObjectContext objectContext, string MATERIALOBJECTID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["MATERIAL"].QueryDefs["GetMaterialDetail"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("MATERIALOBJECTID", MATERIALOBJECTID);

            return TTReportNqlObject.QueryObjects<Material.GetMaterialDetail_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<Material.GetMaterialPricingDetail_Class> GetMaterialPricingDetail(string MATERIALOBJECTID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["MATERIAL"].QueryDefs["GetMaterialPricingDetail"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("MATERIALOBJECTID", MATERIALOBJECTID);

            return TTReportNqlObject.QueryObjects<Material.GetMaterialPricingDetail_Class>(queryDef, paramList, pi);
        }

        public static BindingList<Material.GetMaterialPricingDetail_Class> GetMaterialPricingDetail(TTObjectContext objectContext, string MATERIALOBJECTID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["MATERIAL"].QueryDefs["GetMaterialPricingDetail"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("MATERIALOBJECTID", MATERIALOBJECTID);

            return TTReportNqlObject.QueryObjects<Material.GetMaterialPricingDetail_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<Material.GetStockCardListByGroupReportQuery_Class> GetStockCardListByGroupReportQuery(PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["MATERIAL"].QueryDefs["GetStockCardListByGroupReportQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<Material.GetStockCardListByGroupReportQuery_Class>(queryDef, paramList, pi);
        }

        public static BindingList<Material.GetStockCardListByGroupReportQuery_Class> GetStockCardListByGroupReportQuery(TTObjectContext objectContext, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["MATERIAL"].QueryDefs["GetStockCardListByGroupReportQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<Material.GetStockCardListByGroupReportQuery_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<Material.OLAP_Material_Class> OLAP_Material(PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["MATERIAL"].QueryDefs["OLAP_Material"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<Material.OLAP_Material_Class>(queryDef, paramList, pi);
        }

        public static BindingList<Material.OLAP_Material_Class> OLAP_Material(TTObjectContext objectContext, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["MATERIAL"].QueryDefs["OLAP_Material"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<Material.OLAP_Material_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<Material.GetMaterialInheldReportQuery_Class> GetMaterialInheldReportQuery(string STOCKCARDID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["MATERIAL"].QueryDefs["GetMaterialInheldReportQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STOCKCARDID", STOCKCARDID);

            return TTReportNqlObject.QueryObjects<Material.GetMaterialInheldReportQuery_Class>(queryDef, paramList, pi);
        }

        public static BindingList<Material.GetMaterialInheldReportQuery_Class> GetMaterialInheldReportQuery(TTObjectContext objectContext, string STOCKCARDID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["MATERIAL"].QueryDefs["GetMaterialInheldReportQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STOCKCARDID", STOCKCARDID);

            return TTReportNqlObject.QueryObjects<Material.GetMaterialInheldReportQuery_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<Material> GetMaterial(TTObjectContext objectContext, string injectionSQL)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["MATERIAL"].QueryDefs["GetMaterial"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return ((ITTQuery)objectContext).QueryObjects<Material>(queryDef, paramList, injectionSQL);
        }

    /// <summary>
    /// Where kısmına ekleme yapılmamalı
    /// </summary>
        public static BindingList<Material.GetMaterials_Class> GetMaterials(string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["MATERIAL"].QueryDefs["GetMaterials"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<Material.GetMaterials_Class>(queryDef, paramList, injectionSQL, pi);
        }

    /// <summary>
    /// Where kısmına ekleme yapılmamalı
    /// </summary>
        public static BindingList<Material.GetMaterials_Class> GetMaterials(TTObjectContext objectContext, string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["MATERIAL"].QueryDefs["GetMaterials"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<Material.GetMaterials_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<Material.GetMaterialWithNoEffectivePrice_Class> GetMaterialWithNoEffectivePrice(PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["MATERIAL"].QueryDefs["GetMaterialWithNoEffectivePrice"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<Material.GetMaterialWithNoEffectivePrice_Class>(queryDef, paramList, pi);
        }

        public static BindingList<Material.GetMaterialWithNoEffectivePrice_Class> GetMaterialWithNoEffectivePrice(TTObjectContext objectContext, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["MATERIAL"].QueryDefs["GetMaterialWithNoEffectivePrice"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<Material.GetMaterialWithNoEffectivePrice_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<Material.GetMaterialBarcodeLevelDetail_Class> GetMaterialBarcodeLevelDetail(string MATERIALOBJECTID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["MATERIAL"].QueryDefs["GetMaterialBarcodeLevelDetail"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("MATERIALOBJECTID", MATERIALOBJECTID);

            return TTReportNqlObject.QueryObjects<Material.GetMaterialBarcodeLevelDetail_Class>(queryDef, paramList, pi);
        }

        public static BindingList<Material.GetMaterialBarcodeLevelDetail_Class> GetMaterialBarcodeLevelDetail(TTObjectContext objectContext, string MATERIALOBJECTID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["MATERIAL"].QueryDefs["GetMaterialBarcodeLevelDetail"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("MATERIALOBJECTID", MATERIALOBJECTID);

            return TTReportNqlObject.QueryObjects<Material.GetMaterialBarcodeLevelDetail_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<Material.GetMaterialNonDependStockCard_Class> GetMaterialNonDependStockCard(PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["MATERIAL"].QueryDefs["GetMaterialNonDependStockCard"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<Material.GetMaterialNonDependStockCard_Class>(queryDef, paramList, pi);
        }

        public static BindingList<Material.GetMaterialNonDependStockCard_Class> GetMaterialNonDependStockCard(TTObjectContext objectContext, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["MATERIAL"].QueryDefs["GetMaterialNonDependStockCard"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<Material.GetMaterialNonDependStockCard_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<Material.GetStockCardsToActReportQuery_Class> GetStockCardsToActReportQuery(Guid OBJECTID, DateTime STARTDATE, DateTime FINISHDATE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["MATERIAL"].QueryDefs["GetStockCardsToActReportQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("OBJECTID", OBJECTID);
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("FINISHDATE", FINISHDATE);

            return TTReportNqlObject.QueryObjects<Material.GetStockCardsToActReportQuery_Class>(queryDef, paramList, pi);
        }

        public static BindingList<Material.GetStockCardsToActReportQuery_Class> GetStockCardsToActReportQuery(TTObjectContext objectContext, Guid OBJECTID, DateTime STARTDATE, DateTime FINISHDATE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["MATERIAL"].QueryDefs["GetStockCardsToActReportQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("OBJECTID", OBJECTID);
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("FINISHDATE", FINISHDATE);

            return TTReportNqlObject.QueryObjects<Material.GetStockCardsToActReportQuery_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<Material> GetMaterialWithoutStockCard(TTObjectContext objectContext)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["MATERIAL"].QueryDefs["GetMaterialWithoutStockCard"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return ((ITTQuery)objectContext).QueryObjects<Material>(queryDef, paramList);
        }

        public static BindingList<Material.GetMaterialsWithPrice_Class> GetMaterialsWithPrice(string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["MATERIAL"].QueryDefs["GetMaterialsWithPrice"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<Material.GetMaterialsWithPrice_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<Material.GetMaterialsWithPrice_Class> GetMaterialsWithPrice(TTObjectContext objectContext, string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["MATERIAL"].QueryDefs["GetMaterialsWithPrice"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<Material.GetMaterialsWithPrice_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<Material.OLAP_Material_WithDate_Class> OLAP_Material_WithDate(DateTime FIRSTDATE, DateTime LASTDATE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["MATERIAL"].QueryDefs["OLAP_Material_WithDate"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("FIRSTDATE", FIRSTDATE);
            paramList.Add("LASTDATE", LASTDATE);

            return TTReportNqlObject.QueryObjects<Material.OLAP_Material_WithDate_Class>(queryDef, paramList, pi);
        }

        public static BindingList<Material.OLAP_Material_WithDate_Class> OLAP_Material_WithDate(TTObjectContext objectContext, DateTime FIRSTDATE, DateTime LASTDATE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["MATERIAL"].QueryDefs["OLAP_Material_WithDate"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("FIRSTDATE", FIRSTDATE);
            paramList.Add("LASTDATE", LASTDATE);

            return TTReportNqlObject.QueryObjects<Material.OLAP_Material_WithDate_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<Material.GetMaterialWithMultiEffectivePriceByPriceList_Class> GetMaterialWithMultiEffectivePriceByPriceList(string PRICELIST, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["MATERIAL"].QueryDefs["GetMaterialWithMultiEffectivePriceByPriceList"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("PRICELIST", PRICELIST);

            return TTReportNqlObject.QueryObjects<Material.GetMaterialWithMultiEffectivePriceByPriceList_Class>(queryDef, paramList, pi);
        }

        public static BindingList<Material.GetMaterialWithMultiEffectivePriceByPriceList_Class> GetMaterialWithMultiEffectivePriceByPriceList(TTObjectContext objectContext, string PRICELIST, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["MATERIAL"].QueryDefs["GetMaterialWithMultiEffectivePriceByPriceList"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("PRICELIST", PRICELIST);

            return TTReportNqlObject.QueryObjects<Material.GetMaterialWithMultiEffectivePriceByPriceList_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<Material> GetMaterialByBarcode(TTObjectContext objectContext, string BARCODE)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["MATERIAL"].QueryDefs["GetMaterialByBarcode"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("BARCODE", BARCODE);

            return ((ITTQuery)objectContext).QueryObjects<Material>(queryDef, paramList);
        }

        public static BindingList<Material.GetOldMaterialListQuery_Class> GetOldMaterialListQuery(string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["MATERIAL"].QueryDefs["GetOldMaterialListQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<Material.GetOldMaterialListQuery_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<Material.GetOldMaterialListQuery_Class> GetOldMaterialListQuery(TTObjectContext objectContext, string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["MATERIAL"].QueryDefs["GetOldMaterialListQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<Material.GetOldMaterialListQuery_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<Material.ProductMatchMaterialQuery_Class> ProductMatchMaterialQuery(Guid STORE, int ALL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["MATERIAL"].QueryDefs["ProductMatchMaterialQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STORE", STORE);
            paramList.Add("ALL", ALL);

            return TTReportNqlObject.QueryObjects<Material.ProductMatchMaterialQuery_Class>(queryDef, paramList, pi);
        }

        public static BindingList<Material.ProductMatchMaterialQuery_Class> ProductMatchMaterialQuery(TTObjectContext objectContext, Guid STORE, int ALL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["MATERIAL"].QueryDefs["ProductMatchMaterialQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STORE", STORE);
            paramList.Add("ALL", ALL);

            return TTReportNqlObject.QueryObjects<Material.ProductMatchMaterialQuery_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<Material.ProductNotMatchMaterialQuery_Class> ProductNotMatchMaterialQuery(PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["MATERIAL"].QueryDefs["ProductNotMatchMaterialQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<Material.ProductNotMatchMaterialQuery_Class>(queryDef, paramList, pi);
        }

        public static BindingList<Material.ProductNotMatchMaterialQuery_Class> ProductNotMatchMaterialQuery(TTObjectContext objectContext, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["MATERIAL"].QueryDefs["ProductNotMatchMaterialQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<Material.ProductNotMatchMaterialQuery_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<Material.GetDrugAndMaterialListQuery_Class> GetDrugAndMaterialListQuery(string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["MATERIAL"].QueryDefs["GetDrugAndMaterialListQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<Material.GetDrugAndMaterialListQuery_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<Material.GetDrugAndMaterialListQuery_Class> GetDrugAndMaterialListQuery(TTObjectContext objectContext, string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["MATERIAL"].QueryDefs["GetDrugAndMaterialListQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<Material.GetDrugAndMaterialListQuery_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<Material.GetPrescriptionMaterialListQuery_Class> GetPrescriptionMaterialListQuery(string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["MATERIAL"].QueryDefs["GetPrescriptionMaterialListQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<Material.GetPrescriptionMaterialListQuery_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<Material.GetPrescriptionMaterialListQuery_Class> GetPrescriptionMaterialListQuery(TTObjectContext objectContext, string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["MATERIAL"].QueryDefs["GetPrescriptionMaterialListQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<Material.GetPrescriptionMaterialListQuery_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<Material.VEM_STOK_KART_Class> VEM_STOK_KART(string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["MATERIAL"].QueryDefs["VEM_STOK_KART"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<Material.VEM_STOK_KART_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<Material.VEM_STOK_KART_Class> VEM_STOK_KART(TTObjectContext objectContext, string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["MATERIAL"].QueryDefs["VEM_STOK_KART"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<Material.VEM_STOK_KART_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<Material.GetAllowedDrugAndMaterialListQuery_Class> GetAllowedDrugAndMaterialListQuery(string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["MATERIAL"].QueryDefs["GetAllowedDrugAndMaterialListQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<Material.GetAllowedDrugAndMaterialListQuery_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<Material.GetAllowedDrugAndMaterialListQuery_Class> GetAllowedDrugAndMaterialListQuery(TTObjectContext objectContext, string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["MATERIAL"].QueryDefs["GetAllowedDrugAndMaterialListQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<Material.GetAllowedDrugAndMaterialListQuery_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<Material> GetMaterialWithTreeDef(TTObjectContext objectContext)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["MATERIAL"].QueryDefs["GetMaterialWithTreeDef"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return ((ITTQuery)objectContext).QueryObjects<Material>(queryDef, paramList);
        }

        public static BindingList<Material.GetMaterialsForOutReport_Class> GetMaterialsForOutReport(string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["MATERIAL"].QueryDefs["GetMaterialsForOutReport"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<Material.GetMaterialsForOutReport_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<Material.GetMaterialsForOutReport_Class> GetMaterialsForOutReport(TTObjectContext objectContext, string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["MATERIAL"].QueryDefs["GetMaterialsForOutReport"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<Material.GetMaterialsForOutReport_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<Material> GetMaterialForOut(TTObjectContext objectContext, string injectionSQL)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["MATERIAL"].QueryDefs["GetMaterialForOut"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return ((ITTQuery)objectContext).QueryObjects<Material>(queryDef, paramList, injectionSQL);
        }

        public static BindingList<Material.GetMaterialForStockQuery_Class> GetMaterialForStockQuery(string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["MATERIAL"].QueryDefs["GetMaterialForStockQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<Material.GetMaterialForStockQuery_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<Material.GetMaterialForStockQuery_Class> GetMaterialForStockQuery(TTObjectContext objectContext, string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["MATERIAL"].QueryDefs["GetMaterialForStockQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<Material.GetMaterialForStockQuery_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<Material.GetUTSMaterials_Class> GetUTSMaterials(PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["MATERIAL"].QueryDefs["GetUTSMaterials"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<Material.GetUTSMaterials_Class>(queryDef, paramList, pi);
        }

        public static BindingList<Material.GetUTSMaterials_Class> GetUTSMaterials(TTObjectContext objectContext, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["MATERIAL"].QueryDefs["GetUTSMaterials"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<Material.GetUTSMaterials_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<Material.GetUTSMaterialsByBarcode_Class> GetUTSMaterialsByBarcode(IList<string> BARCODES, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["MATERIAL"].QueryDefs["GetUTSMaterialsByBarcode"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("BARCODES", BARCODES);

            return TTReportNqlObject.QueryObjects<Material.GetUTSMaterialsByBarcode_Class>(queryDef, paramList, pi);
        }

        public static BindingList<Material.GetUTSMaterialsByBarcode_Class> GetUTSMaterialsByBarcode(TTObjectContext objectContext, IList<string> BARCODES, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["MATERIAL"].QueryDefs["GetUTSMaterialsByBarcode"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("BARCODES", BARCODES);

            return TTReportNqlObject.QueryObjects<Material.GetUTSMaterialsByBarcode_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<Material.GetUTSMaterialDetails_Class> GetUTSMaterialDetails(PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["MATERIAL"].QueryDefs["GetUTSMaterialDetails"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<Material.GetUTSMaterialDetails_Class>(queryDef, paramList, pi);
        }

        public static BindingList<Material.GetUTSMaterialDetails_Class> GetUTSMaterialDetails(TTObjectContext objectContext, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["MATERIAL"].QueryDefs["GetUTSMaterialDetails"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<Material.GetUTSMaterialDetails_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<Material.GetRestAmounInStock_Class> GetRestAmounInStock(Guid STOREID, string injectionSQL = null, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["MATERIAL"].QueryDefs["GetRestAmounInStock"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STOREID", STOREID);

            return TTReportNqlObject.QueryObjects<Material.GetRestAmounInStock_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<Material.GetRestAmounInStock_Class> GetRestAmounInStock(TTObjectContext objectContext, Guid STOREID, string injectionSQL = null, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["MATERIAL"].QueryDefs["GetRestAmounInStock"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STOREID", STOREID);

            return TTReportNqlObject.QueryObjects<Material.GetRestAmounInStock_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<Material.GetHospitalInventory_Class> GetHospitalInventory(Guid STOREID, string injectionSQL = null, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["MATERIAL"].QueryDefs["GetHospitalInventory"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STOREID", STOREID);

            return TTReportNqlObject.QueryObjects<Material.GetHospitalInventory_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<Material.GetHospitalInventory_Class> GetHospitalInventory(TTObjectContext objectContext, Guid STOREID, string injectionSQL = null, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["MATERIAL"].QueryDefs["GetHospitalInventory"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STOREID", STOREID);

            return TTReportNqlObject.QueryObjects<Material.GetHospitalInventory_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<Material.GetNewMaterialInListQuery_Class> GetNewMaterialInListQuery(string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["MATERIAL"].QueryDefs["GetNewMaterialInListQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<Material.GetNewMaterialInListQuery_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<Material.GetNewMaterialInListQuery_Class> GetNewMaterialInListQuery(TTObjectContext objectContext, string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["MATERIAL"].QueryDefs["GetNewMaterialInListQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<Material.GetNewMaterialInListQuery_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<Material.GetNewMaterialOutListQuery_Class> GetNewMaterialOutListQuery(string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["MATERIAL"].QueryDefs["GetNewMaterialOutListQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<Material.GetNewMaterialOutListQuery_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<Material.GetNewMaterialOutListQuery_Class> GetNewMaterialOutListQuery(TTObjectContext objectContext, string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["MATERIAL"].QueryDefs["GetNewMaterialOutListQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<Material.GetNewMaterialOutListQuery_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<Material.GetMaterialByDistributionDoc_Class> GetMaterialByDistributionDoc(string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["MATERIAL"].QueryDefs["GetMaterialByDistributionDoc"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<Material.GetMaterialByDistributionDoc_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<Material.GetMaterialByDistributionDoc_Class> GetMaterialByDistributionDoc(TTObjectContext objectContext, string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["MATERIAL"].QueryDefs["GetMaterialByDistributionDoc"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<Material.GetMaterialByDistributionDoc_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<Material.GetMaterialsForMultiSelectForm_Class> GetMaterialsForMultiSelectForm(string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["MATERIAL"].QueryDefs["GetMaterialsForMultiSelectForm"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<Material.GetMaterialsForMultiSelectForm_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<Material.GetMaterialsForMultiSelectForm_Class> GetMaterialsForMultiSelectForm(TTObjectContext objectContext, string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["MATERIAL"].QueryDefs["GetMaterialsForMultiSelectForm"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<Material.GetMaterialsForMultiSelectForm_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

    /// <summary>
    /// Malzeme Fotoğraf
    /// </summary>
        public object MaterialPicture
        {
            get { return (object)this["MATERIALPICTURE"]; }
            set { this["MATERIALPICTURE"] = value; }
        }

    /// <summary>
    /// Açıklama
    /// </summary>
        public string Description
        {
            get { return (string)this["DESCRIPTION"]; }
            set { this["DESCRIPTION"] = value; }
        }

    /// <summary>
    /// Türkçe Adı
    /// </summary>
        public string Name
        {
            get { return (string)this["NAME"]; }
            set { this["NAME"] = value; }
        }

    /// <summary>
    /// Hastaya İlaç Verilir
    /// </summary>
        public bool? AllowToGivePatient
        {
            get { return (bool?)this["ALLOWTOGIVEPATIENT"]; }
            set { this["ALLOWTOGIVEPATIENT"] = value; }
        }

    /// <summary>
    /// Malzeme Kodu
    /// </summary>
        public string Code
        {
            get { return (string)this["CODE"]; }
            set { this["CODE"] = value; }
        }

    /// <summary>
    /// Orjinal Adı
    /// </summary>
        public string OriginalName
        {
            get { return (string)this["ORIGINALNAME"]; }
            set { this["ORIGINALNAME"] = value; }
        }

    /// <summary>
    /// Ücretlendirilir
    /// </summary>
        public bool? Chargable
        {
            get { return (bool?)this["CHARGABLE"]; }
            set { this["CHARGABLE"] = value; }
        }

    /// <summary>
    /// Fiyatı Hacime Bölünerek Hesaplanır
    /// </summary>
        public bool? DividePriceToVolume
        {
            get { return (bool?)this["DIVIDEPRICETOVOLUME"]; }
            set { this["DIVIDEPRICETOVOLUME"] = value; }
        }

    /// <summary>
    /// İhale Kesinleşme Tarihi
    /// </summary>
        public DateTime? AuctionDate
        {
            get { return (DateTime?)this["AUCTIONDATE"]; }
            set { this["AUCTIONDATE"] = value; }
        }

    /// <summary>
    /// İhale Kayıt No /Alım No
    /// </summary>
        public string RegistrationAuctionNo
        {
            get { return (string)this["REGISTRATIONAUCTIONNO"]; }
            set { this["REGISTRATIONAUCTIONNO"] = value; }
        }

    /// <summary>
    /// Medula Adet ve Fiyatı Çarpana Göre Ayarlanır
    /// </summary>
        public bool? SetMedulaInfoByMultiplier
        {
            get { return (bool?)this["SETMEDULAINFOBYMULTIPLIER"]; }
            set { this["SETMEDULAINFOBYMULTIPLIER"] = value; }
        }

    /// <summary>
    /// ETKM Açıklama
    /// </summary>
        public string ETKMDescription
        {
            get { return (string)this["ETKMDESCRIPTION"]; }
            set { this["ETKMDESCRIPTION"] = value; }
        }

    /// <summary>
    /// Açılış Tarihi
    /// </summary>
        public DateTime? CreationDate
        {
            get { return (DateTime?)this["CREATIONDATE"]; }
            set { this["CREATIONDATE"] = value; }
        }

    /// <summary>
    /// Medula Adet ve Fiyat Çarpanı
    /// </summary>
        public double? MedulaMultiplier
        {
            get { return (double?)this["MEDULAMULTIPLIER"]; }
            set { this["MEDULAMULTIPLIER"] = value; }
        }

        public bool? IsArmyDrug
        {
            get { return (bool?)this["ISARMYDRUG"]; }
            set { this["ISARMYDRUG"] = value; }
        }

    /// <summary>
    /// Medulaya Gönderilmeyecek Durumunda Oluştur
    /// </summary>
        public bool? CreateInMedulaDontSendState
        {
            get { return (bool?)this["CREATEINMEDULADONTSENDSTATE"]; }
            set { this["CREATEINMEDULADONTSENDSTATE"] = value; }
        }

    /// <summary>
    /// Kontrollü Sarf Malzeme
    /// </summary>
        public bool? IsRestrictedMaterial
        {
            get { return (bool?)this["ISRESTRICTEDMATERIAL"]; }
            set { this["ISRESTRICTEDMATERIAL"] = value; }
        }

    /// <summary>
    /// Ücretlendirmede Miktar Çarpanı
    /// </summary>
        public double? AccTrxAmountMultiplier
        {
            get { return (double?)this["ACCTRXAMOUNTMULTIPLIER"]; }
            set { this["ACCTRXAMOUNTMULTIPLIER"] = value; }
        }

    /// <summary>
    /// Ücretlendirmede Birim Fiyat Böleni
    /// </summary>
        public double? AccTrxUnitPriceDivider
        {
            get { return (double?)this["ACCTRXUNITPRICEDIVIDER"]; }
            set { this["ACCTRXUNITPRICEDIVIDER"] = value; }
        }

    /// <summary>
    /// Depodan Sarf Edilebilir
    /// </summary>
        public bool? IsExpendableMaterial
        {
            get { return (bool?)this["ISEXPENDABLEMATERIAL"]; }
            set { this["ISEXPENDABLEMATERIAL"] = value; }
        }

        public string Barcode
        {
            get { return (string)this["BARCODE"]; }
            set { this["BARCODE"] = value; }
        }

        public DateTime? LicenceDate
        {
            get { return (DateTime?)this["LICENCEDATE"]; }
            set { this["LICENCEDATE"] = value; }
        }

        public double? CurrentPrice
        {
            get { return (double?)this["CURRENTPRICE"]; }
            set { this["CURRENTPRICE"] = value; }
        }

        public double? Discount
        {
            get { return (double?)this["DISCOUNT"]; }
            set { this["DISCOUNT"] = value; }
        }

        public string LicenceNO
        {
            get { return (string)this["LICENCENO"]; }
            set { this["LICENCENO"] = value; }
        }

        public LicencingOrganizationEnum? LicencingOrganization
        {
            get { return (LicencingOrganizationEnum?)(int?)this["LICENCINGORGANIZATION"]; }
            set { this["LICENCINGORGANIZATION"] = value; }
        }

        public string BarcodeName
        {
            get { return (string)this["BARCODENAME"]; }
            set { this["BARCODENAME"] = value; }
        }

        public double? PackageAmount
        {
            get { return (double?)this["PACKAGEAMOUNT"]; }
            set { this["PACKAGEAMOUNT"] = value; }
        }

        public long? ProductNumber
        {
            get { return (long?)this["PRODUCTNUMBER"]; }
            set { this["PRODUCTNUMBER"] = value; }
        }

        public long? SPTSDrugID
        {
            get { return (long?)this["SPTSDRUGID"]; }
            set { this["SPTSDRUGID"] = value; }
        }

        public int? SPTSLicencingOrganizationID
        {
            get { return (int?)this["SPTSLICENCINGORGANIZATIONID"]; }
            set { this["SPTSLICENCINGORGANIZATIONID"] = value; }
        }

        public string Name_Shadow
        {
            get { return (string)this["NAME_SHADOW"]; }
        }

    /// <summary>
    /// Malzeme Fiyatlandırma Türü
    /// </summary>
        public MaterialPricingTypeEnum? MaterialPricingType
        {
            get { return (MaterialPricingTypeEnum?)(int?)this["MATERIALPRICINGTYPE"]; }
            set { this["MATERIALPRICINGTYPE"] = value; }
        }

    /// <summary>
    /// Satınalma Tarihi
    /// </summary>
        public DateTime? PurchaseDate
        {
            get { return (DateTime?)this["PURCHASEDATE"]; }
            set { this["PURCHASEDATE"] = value; }
        }

    /// <summary>
    /// Eski Malzeme
    /// </summary>
        public bool? IsOldMaterial
        {
            get { return (bool?)this["ISOLDMATERIAL"]; }
            set { this["ISOLDMATERIAL"] = value; }
        }

        public int? MkysMalzemeKodu
        {
            get { return (int?)this["MKYSMALZEMEKODU"]; }
            set { this["MKYSMALZEMEKODU"] = value; }
        }

    /// <summary>
    /// Fatura malzeme tipi
    /// </summary>
        public MaterialTypeForInvoiceEnum? MaterialTypeForInvoice
        {
            get { return (MaterialTypeForInvoiceEnum?)(int?)this["MATERIALTYPEFORINVOICE"]; }
            set { this["MATERIALTYPEFORINVOICE"] = value; }
        }

    /// <summary>
    /// SUT Eki
    /// </summary>
        public SUTMalzemeEKEnum? SUTAppendix
        {
            get { return (SUTMalzemeEKEnum?)(int?)this["SUTAPPENDIX"]; }
            set { this["SUTAPPENDIX"] = value; }
        }

        public bool? ShowZeroOnDistributionInfo
        {
            get { return (bool?)this["SHOWZEROONDISTRIBUTIONINFO"]; }
            set { this["SHOWZEROONDISTRIBUTIONINFO"] = value; }
        }

    /// <summary>
    /// Tekil Takip Gerektirir
    /// </summary>
        public bool? IsIndividualTrackingRequired
        {
            get { return (bool?)this["ISINDIVIDUALTRACKINGREQUIRED"]; }
            set { this["ISINDIVIDUALTRACKINGREQUIRED"] = value; }
        }

    /// <summary>
    /// Paket Harici Faturalanır
    /// </summary>
        public bool? IsPackageExclusive
        {
            get { return (bool?)this["ISPACKAGEEXCLUSIVE"]; }
            set { this["ISPACKAGEEXCLUSIVE"] = value; }
        }

    /// <summary>
    /// Depolama Koşulları
    /// </summary>
        public string StorageConditions
        {
            get { return (string)this["STORAGECONDITIONS"]; }
            set { this["STORAGECONDITIONS"] = value; }
        }

    /// <summary>
    /// Minimum Tahmini Teymin Süresi(Gün)
    /// </summary>
        public int? EstimatedTimeOfCheck
        {
            get { return (int?)this["ESTIMATEDTIMEOFCHECK"]; }
            set { this["ESTIMATEDTIMEOFCHECK"] = value; }
        }

    /// <summary>
    /// Künye No Zorunlu
    /// </summary>
        public bool? IsTagNoRequired
        {
            get { return (bool?)this["ISTAGNOREQUIRED"]; }
            set { this["ISTAGNOREQUIRED"] = value; }
        }

    /// <summary>
    /// Açıklama Uyarı Yeri
    /// </summary>
        public MaterialDescriptionShowTypeEnum? MaterialDescriptionShowType
        {
            get { return (MaterialDescriptionShowTypeEnum?)(int?)this["MATERIALDESCRIPTIONSHOWTYPE"]; }
            set { this["MATERIALDESCRIPTIONSHOWTYPE"] = value; }
        }

    /// <summary>
    /// Hastalara Bölünebilir
    /// </summary>
        public bool? DivideAmountToPatient
        {
            get { return (bool?)this["DIVIDEAMOUNTTOPATIENT"]; }
            set { this["DIVIDEAMOUNTTOPATIENT"] = value; }
        }

    /// <summary>
    /// Birim Doz
    /// </summary>
        public double? DivideUnitAmount
        {
            get { return (double?)this["DIVIDEUNITAMOUNT"]; }
            set { this["DIVIDEUNITAMOUNT"] = value; }
        }

    /// <summary>
    /// Tolam Doz
    /// </summary>
        public double? DivideTotalAmount
        {
            get { return (double?)this["DIVIDETOTALAMOUNT"]; }
            set { this["DIVIDETOTALAMOUNT"] = value; }
        }

    /// <summary>
    /// Hastaya Gün Max. Çıkış
    /// </summary>
        public int? PatientMaxDayOut
        {
            get { return (int?)this["PATIENTMAXDAYOUT"]; }
            set { this["PATIENTMAXDAYOUT"] = value; }
        }

    /// <summary>
    /// İşletme Payı
    /// </summary>
        public Currency? OperatingShare
        {
            get { return (Currency?)this["OPERATINGSHARE"]; }
            set { this["OPERATINGSHARE"] = value; }
        }

    /// <summary>
    /// Hazine Payı
    /// </summary>
        public Currency? TresuryShare
        {
            get { return (Currency?)this["TRESURYSHARE"]; }
            set { this["TRESURYSHARE"] = value; }
        }

    /// <summary>
    /// S.H.Ç.E.K Payı
    /// </summary>
        public Currency? ShcekShare
        {
            get { return (Currency?)this["SHCEKSHARE"]; }
            set { this["SHCEKSHARE"] = value; }
        }

    /// <summary>
    /// İ.S.M. Id
    /// </summary>
        public string IsmId
        {
            get { return (string)this["ISMID"]; }
            set { this["ISMID"] = value; }
        }

    /// <summary>
    /// Hasta Türü
    /// </summary>
        public MaterialPatientTypeEnum? MaterialPatientType
        {
            get { return (MaterialPatientTypeEnum?)(int?)this["MATERIALPATIENTTYPE"]; }
            set { this["MATERIALPATIENTTYPE"] = value; }
        }

        public bool? NotShownOnEpicrisisForm
        {
            get { return (bool?)this["NOTSHOWNONEPICRISISFORM"]; }
            set { this["NOTSHOWNONEPICRISISFORM"] = value; }
        }

    /// <summary>
    /// Günübirlik Yatış Gerektirir
    /// </summary>
        public bool? DailyStay
        {
            get { return (bool?)this["DAILYSTAY"]; }
            set { this["DAILYSTAY"] = value; }
        }

    /// <summary>
    /// Malzeme Kodu
    /// </summary>
        public TTSequence MaterialCodeSequence
        {
            get { return GetSequence("MATERIALCODESEQUENCE"); }
        }

    /// <summary>
    /// SMS Gönder
    /// </summary>
        public bool? SendSMS
        {
            get { return (bool?)this["SENDSMS"]; }
            set { this["SENDSMS"] = value; }
        }

    /// <summary>
    /// Maksimum Tahmini Temin Süresi
    /// </summary>
        public int? MaximumEstimatedTimeOfCheck
        {
            get { return (int?)this["MAXIMUMESTIMATEDTIMEOFCHECK"]; }
            set { this["MAXIMUMESTIMATEDTIMEOFCHECK"] = value; }
        }

    /// <summary>
    /// Uyarı Gün Süresi
    /// </summary>
        public int? WarningDayDuration
        {
            get { return (int?)this["WARNINGDAYDURATION"]; }
            set { this["WARNINGDAYDURATION"] = value; }
        }

        public MaterialTreeDefinition MaterialTree
        {
            get { return (MaterialTreeDefinition)((ITTObject)this).GetParent("MATERIALTREE"); }
            set { this["MATERIALTREE"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public StockCard StockCard
        {
            get { return (StockCard)((ITTObject)this).GetParent("STOCKCARD"); }
            set { this["STOCKCARD"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public SpecialityDefinition Brans
        {
            get { return (SpecialityDefinition)((ITTObject)this).GetParent("BRANS"); }
            set { this["BRANS"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public Material JoinedMaterial
        {
            get { return (Material)((ITTObject)this).GetParent("JOINEDMATERIAL"); }
            set { this["JOINEDMATERIAL"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public Sites CreatedSite
        {
            get { return (Sites)((ITTObject)this).GetParent("CREATEDSITE"); }
            set { this["CREATEDSITE"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public Producer Producer
        {
            get { return (Producer)((ITTObject)this).GetParent("PRODUCER"); }
            set { this["PRODUCER"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// GMDN Kodu
    /// </summary>
        public GMDNDefinition GMDNCode
        {
            get { return (GMDNDefinition)((ITTObject)this).GetParent("GMDNCODE"); }
            set { this["GMDNCODE"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public MaterialPlaceOfUseDef MaterialPlaceOfUseDef
        {
            get { return (MaterialPlaceOfUseDef)((ITTObject)this).GetParent("MATERIALPLACEOFUSEDEF"); }
            set { this["MATERIALPLACEOFUSEDEF"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public MaterialPurposeDefinition MaterialPurposeDefinition
        {
            get { return (MaterialPurposeDefinition)((ITTObject)this).GetParent("MATERIALPURPOSEDEFINITION"); }
            set { this["MATERIALPURPOSEDEFINITION"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public MalzemeGetData MKYSMalzeme
        {
            get { return (MalzemeGetData)((ITTObject)this).GetParent("MKYSMALZEME"); }
            set { this["MKYSMALZEME"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public UnitDefinition DivideUnitDefinition
        {
            get { return (UnitDefinition)((ITTObject)this).GetParent("DIVIDEUNITDEFINITION"); }
            set { this["DIVIDEUNITDEFINITION"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Muhasebe Gelir Hesap Kırınımı ile ilişki
    /// </summary>
        public RevenueSubAccountCodeDefinition RevenueSubAccountCode
        {
            get { return (RevenueSubAccountCodeDefinition)((ITTObject)this).GetParent("REVENUESUBACCOUNTCODE"); }
            set { this["REVENUESUBACCOUNTCODE"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        virtual protected void CreateMaterialBarcodeLevelsCollection()
        {
            _MaterialBarcodeLevels = new MaterialBarcodeLevel.ChildMaterialBarcodeLevelCollection(this, new Guid("dd8c0bcc-ecbc-44e2-8a50-31bca9c4e8b8"));
            ((ITTChildObjectCollection)_MaterialBarcodeLevels).GetChildren();
        }

        protected MaterialBarcodeLevel.ChildMaterialBarcodeLevelCollection _MaterialBarcodeLevels = null;
        public MaterialBarcodeLevel.ChildMaterialBarcodeLevelCollection MaterialBarcodeLevels
        {
            get
            {
                if (_MaterialBarcodeLevels == null)
                    CreateMaterialBarcodeLevelsCollection();
                return _MaterialBarcodeLevels;
            }
        }

        virtual protected void CreateMaterialPricesCollection()
        {
            _MaterialPrices = new MaterialPrice.ChildMaterialPriceCollection(this, new Guid("5f9df809-de0e-4ac3-93f7-4b49ceb3bacf"));
            ((ITTChildObjectCollection)_MaterialPrices).GetChildren();
        }

        protected MaterialPrice.ChildMaterialPriceCollection _MaterialPrices = null;
    /// <summary>
    /// Child collection for Malzeme
    /// </summary>
        public MaterialPrice.ChildMaterialPriceCollection MaterialPrices
        {
            get
            {
                if (_MaterialPrices == null)
                    CreateMaterialPricesCollection();
                return _MaterialPrices;
            }
        }

        virtual protected void CreateMaterialExceptionsCollection()
        {
            _MaterialExceptions = new DiscountTypeMaterialExceptionDefinition.ChildDiscountTypeMaterialExceptionDefinitionCollection(this, new Guid("4e17a4f3-e471-4b30-a44c-764c9dbd3d14"));
            ((ITTChildObjectCollection)_MaterialExceptions).GetChildren();
        }

        protected DiscountTypeMaterialExceptionDefinition.ChildDiscountTypeMaterialExceptionDefinitionCollection _MaterialExceptions = null;
    /// <summary>
    /// Child collection for Malzeme ile ilişki
    /// </summary>
        public DiscountTypeMaterialExceptionDefinition.ChildDiscountTypeMaterialExceptionDefinitionCollection MaterialExceptions
        {
            get
            {
                if (_MaterialExceptions == null)
                    CreateMaterialExceptionsCollection();
                return _MaterialExceptions;
            }
        }

        virtual protected void CreateProtocolPriceCollection()
        {
            _ProtocolPrice = new ProtocolPriceCalculation.ChildProtocolPriceCalculationCollection(this, new Guid("f9cf7791-2b8d-4042-a786-6cd8a5f0333d"));
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

        virtual protected void CreateStocksCollection()
        {
            _Stocks = new Stock.ChildStockCollection(this, new Guid("bf4c57d8-fc78-4ad3-a70a-8175ab70cf28"));
            ((ITTChildObjectCollection)_Stocks).GetChildren();
        }

        protected Stock.ChildStockCollection _Stocks = null;
        public Stock.ChildStockCollection Stocks
        {
            get
            {
                if (_Stocks == null)
                    CreateStocksCollection();
                return _Stocks;
            }
        }

        virtual protected void CreateUTSNotificationCollection()
        {
            _UTSNotification = new UTSNotification.ChildUTSNotificationCollection(this, new Guid("3a95cee2-052c-4c80-bf61-6e664fedca59"));
            ((ITTChildObjectCollection)_UTSNotification).GetChildren();
        }

        protected UTSNotification.ChildUTSNotificationCollection _UTSNotification = null;
        public UTSNotification.ChildUTSNotificationCollection UTSNotification
        {
            get
            {
                if (_UTSNotification == null)
                    CreateUTSNotificationCollection();
                return _UTSNotification;
            }
        }

        virtual protected void CreateMaterialRuleSetsCollection()
        {
            _MaterialRuleSets = new MaterialRuleSet.ChildMaterialRuleSetCollection(this, new Guid("c219bdde-bb53-42a9-bef1-a50ccfd19642"));
            ((ITTChildObjectCollection)_MaterialRuleSets).GetChildren();
        }

        protected MaterialRuleSet.ChildMaterialRuleSetCollection _MaterialRuleSets = null;
    /// <summary>
    /// Child collection for Malzeme-Malzeme Kural Setleri
    /// </summary>
        public MaterialRuleSet.ChildMaterialRuleSetCollection MaterialRuleSets
        {
            get
            {
                if (_MaterialRuleSets == null)
                    CreateMaterialRuleSetsCollection();
                return _MaterialRuleSets;
            }
        }

        virtual protected void CreateMaterialVatRatesCollection()
        {
            _MaterialVatRates = new MaterialVatRate.ChildMaterialVatRateCollection(this, new Guid("fc152f09-5a37-4444-a532-e935624b9b72"));
            ((ITTChildObjectCollection)_MaterialVatRates).GetChildren();
        }

        protected MaterialVatRate.ChildMaterialVatRateCollection _MaterialVatRates = null;
        public MaterialVatRate.ChildMaterialVatRateCollection MaterialVatRates
        {
            get
            {
                if (_MaterialVatRates == null)
                    CreateMaterialVatRatesCollection();
                return _MaterialVatRates;
            }
        }

        virtual protected void CreatePriceUpdatingCollection()
        {
            _PriceUpdating = new PriceUpdating.ChildPriceUpdatingCollection(this, new Guid("33caa223-5cc8-49d4-8293-0068b4ec8dd2"));
            ((ITTChildObjectCollection)_PriceUpdating).GetChildren();
        }

        protected PriceUpdating.ChildPriceUpdatingCollection _PriceUpdating = null;
    /// <summary>
    /// Child collection for Malzeme ile ilişki
    /// </summary>
        public PriceUpdating.ChildPriceUpdatingCollection PriceUpdating
        {
            get
            {
                if (_PriceUpdating == null)
                    CreatePriceUpdatingCollection();
                return _PriceUpdating;
            }
        }

        virtual protected void CreateDailyDrugSchOrdersCollection()
        {
            _DailyDrugSchOrders = new DailyDrugSchOrder.ChildDailyDrugSchOrderCollection(this, new Guid("cfca0604-7576-4f84-8af9-06cd8b57cef9"));
            ((ITTChildObjectCollection)_DailyDrugSchOrders).GetChildren();
        }

        protected DailyDrugSchOrder.ChildDailyDrugSchOrderCollection _DailyDrugSchOrders = null;
        public DailyDrugSchOrder.ChildDailyDrugSchOrderCollection DailyDrugSchOrders
        {
            get
            {
                if (_DailyDrugSchOrders == null)
                    CreateDailyDrugSchOrdersCollection();
                return _DailyDrugSchOrders;
            }
        }

        virtual protected void CreateDailyDrugUnDrugsCollection()
        {
            _DailyDrugUnDrugs = new DailyDrugUnDrug.ChildDailyDrugUnDrugCollection(this, new Guid("26295a10-99e5-4f14-9789-a08401ffc2db"));
            ((ITTChildObjectCollection)_DailyDrugUnDrugs).GetChildren();
        }

        protected DailyDrugUnDrug.ChildDailyDrugUnDrugCollection _DailyDrugUnDrugs = null;
        public DailyDrugUnDrug.ChildDailyDrugUnDrugCollection DailyDrugUnDrugs
        {
            get
            {
                if (_DailyDrugUnDrugs == null)
                    CreateDailyDrugUnDrugsCollection();
                return _DailyDrugUnDrugs;
            }
        }

        virtual protected void CreateAccountingProcessCollection()
        {
            _AccountingProcess = new AccountingProcess.ChildAccountingProcessCollection(this, new Guid("f45baf2f-ab97-4fb1-b7c6-b03d3cdc6f39"));
            ((ITTChildObjectCollection)_AccountingProcess).GetChildren();
        }

        protected AccountingProcess.ChildAccountingProcessCollection _AccountingProcess = null;
    /// <summary>
    /// Child collection for İlaç/Malzeme
    /// </summary>
        public AccountingProcess.ChildAccountingProcessCollection AccountingProcess
        {
            get
            {
                if (_AccountingProcess == null)
                    CreateAccountingProcessCollection();
                return _AccountingProcess;
            }
        }

        virtual protected void CreateMaterialProductLevelsCollection()
        {
            _MaterialProductLevels = new MaterialProductLevel.ChildMaterialProductLevelCollection(this, new Guid("2c7753ab-af38-47e6-9d7e-beb333fe0f1c"));
            ((ITTChildObjectCollection)_MaterialProductLevels).GetChildren();
        }

        protected MaterialProductLevel.ChildMaterialProductLevelCollection _MaterialProductLevels = null;
        public MaterialProductLevel.ChildMaterialProductLevelCollection MaterialProductLevels
        {
            get
            {
                if (_MaterialProductLevels == null)
                    CreateMaterialProductLevelsCollection();
                return _MaterialProductLevels;
            }
        }

        virtual protected void CreateTransferFromPackageCollection()
        {
            _TransferFromPackage = new TransferFromPackage.ChildTransferFromPackageCollection(this, new Guid("03e73d8b-0648-4ddd-a92f-9e1a323b41cf"));
            ((ITTChildObjectCollection)_TransferFromPackage).GetChildren();
        }

        protected TransferFromPackage.ChildTransferFromPackageCollection _TransferFromPackage = null;
    /// <summary>
    /// Child collection for İlaç/Malzeme
    /// </summary>
        public TransferFromPackage.ChildTransferFromPackageCollection TransferFromPackage
        {
            get
            {
                if (_TransferFromPackage == null)
                    CreateTransferFromPackageCollection();
                return _TransferFromPackage;
            }
        }

        virtual protected void CreatePackageTransferCollection()
        {
            _PackageTransfer = new PackageTransfer.ChildPackageTransferCollection(this, new Guid("7a937453-560d-4a9a-8cd2-bb026747f73d"));
            ((ITTChildObjectCollection)_PackageTransfer).GetChildren();
        }

        protected PackageTransfer.ChildPackageTransferCollection _PackageTransfer = null;
    /// <summary>
    /// Child collection for İlaç/Malzeme
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

        virtual protected void CreatePresTypeMaterialMatchDefCollection()
        {
            _PresTypeMaterialMatchDef = new PresTypeMaterialMatchDef.ChildPresTypeMaterialMatchDefCollection(this, new Guid("85ee0a3c-f6bb-4562-a415-14536857ce09"));
            ((ITTChildObjectCollection)_PresTypeMaterialMatchDef).GetChildren();
        }

        protected PresTypeMaterialMatchDef.ChildPresTypeMaterialMatchDefCollection _PresTypeMaterialMatchDef = null;
        public PresTypeMaterialMatchDef.ChildPresTypeMaterialMatchDefCollection PresTypeMaterialMatchDef
        {
            get
            {
                if (_PresTypeMaterialMatchDef == null)
                    CreatePresTypeMaterialMatchDefCollection();
                return _PresTypeMaterialMatchDef;
            }
        }

        virtual protected void CreateJoinMaterialRemovalCollection()
        {
            _JoinMaterialRemoval = new JoinMaterialRemoval.ChildJoinMaterialRemovalCollection(this, new Guid("c7f14fd9-2f92-4465-a7ae-27b429d87948"));
            ((ITTChildObjectCollection)_JoinMaterialRemoval).GetChildren();
        }

        protected JoinMaterialRemoval.ChildJoinMaterialRemovalCollection _JoinMaterialRemoval = null;
        public JoinMaterialRemoval.ChildJoinMaterialRemovalCollection JoinMaterialRemoval
        {
            get
            {
                if (_JoinMaterialRemoval == null)
                    CreateJoinMaterialRemovalCollection();
                return _JoinMaterialRemoval;
            }
        }

        virtual protected void CreateMaterialSpecialtysCollection()
        {
            _MaterialSpecialtys = new MaterialSpecialty.ChildMaterialSpecialtyCollection(this, new Guid("62c510d3-07fb-46cd-8048-764992e897b5"));
            ((ITTChildObjectCollection)_MaterialSpecialtys).GetChildren();
        }

        protected MaterialSpecialty.ChildMaterialSpecialtyCollection _MaterialSpecialtys = null;
        public MaterialSpecialty.ChildMaterialSpecialtyCollection MaterialSpecialtys
        {
            get
            {
                if (_MaterialSpecialtys == null)
                    CreateMaterialSpecialtysCollection();
                return _MaterialSpecialtys;
            }
        }

        virtual protected void CreateCentralMaterialProductsCollection()
        {
            _CentralMaterialProducts = new CentralMaterialProduct.ChildCentralMaterialProductCollection(this, new Guid("c9bd4f19-90ad-4429-ade9-0a36e18f4b07"));
            ((ITTChildObjectCollection)_CentralMaterialProducts).GetChildren();
        }

        protected CentralMaterialProduct.ChildCentralMaterialProductCollection _CentralMaterialProducts = null;
        public CentralMaterialProduct.ChildCentralMaterialProductCollection CentralMaterialProducts
        {
            get
            {
                if (_CentralMaterialProducts == null)
                    CreateCentralMaterialProductsCollection();
                return _CentralMaterialProducts;
            }
        }

        virtual protected void CreateKSchedulePatienOwnDrugsCollection()
        {
            _KSchedulePatienOwnDrugs = new KSchedulePatienOwnDrug.ChildKSchedulePatienOwnDrugCollection(this, new Guid("5defa182-103a-496b-b3c2-aead454e72f5"));
            ((ITTChildObjectCollection)_KSchedulePatienOwnDrugs).GetChildren();
        }

        protected KSchedulePatienOwnDrug.ChildKSchedulePatienOwnDrugCollection _KSchedulePatienOwnDrugs = null;
        public KSchedulePatienOwnDrug.ChildKSchedulePatienOwnDrugCollection KSchedulePatienOwnDrugs
        {
            get
            {
                if (_KSchedulePatienOwnDrugs == null)
                    CreateKSchedulePatienOwnDrugsCollection();
                return _KSchedulePatienOwnDrugs;
            }
        }

        virtual protected void CreateMaterialDocumentationsCollection()
        {
            _MaterialDocumentations = new MaterialDocumentation.ChildMaterialDocumentationCollection(this, new Guid("ee764c82-a4ce-41a6-8465-e194e1e0df2f"));
            ((ITTChildObjectCollection)_MaterialDocumentations).GetChildren();
        }

        protected MaterialDocumentation.ChildMaterialDocumentationCollection _MaterialDocumentations = null;
        public MaterialDocumentation.ChildMaterialDocumentationCollection MaterialDocumentations
        {
            get
            {
                if (_MaterialDocumentations == null)
                    CreateMaterialDocumentationsCollection();
                return _MaterialDocumentations;
            }
        }

        virtual protected void CreateUpdateMaterialPriceCollection()
        {
            _UpdateMaterialPrice = new UpdateMaterialPrice.ChildUpdateMaterialPriceCollection(this, new Guid("46ae1bb0-ce7f-494c-a27b-aefd7f1dedcb"));
            ((ITTChildObjectCollection)_UpdateMaterialPrice).GetChildren();
        }

        protected UpdateMaterialPrice.ChildUpdateMaterialPriceCollection _UpdateMaterialPrice = null;
        public UpdateMaterialPrice.ChildUpdateMaterialPriceCollection UpdateMaterialPrice
        {
            get
            {
                if (_UpdateMaterialPrice == null)
                    CreateUpdateMaterialPriceCollection();
                return _UpdateMaterialPrice;
            }
        }

        virtual protected void CreateMaterialProceduresCollection()
        {
            _MaterialProcedures = new MaterialProcedures.ChildMaterialProceduresCollection(this, new Guid("3302bba6-acc2-4c11-b225-3473a9de8636"));
            ((ITTChildObjectCollection)_MaterialProcedures).GetChildren();
        }

        protected MaterialProcedures.ChildMaterialProceduresCollection _MaterialProcedures = null;
        public MaterialProcedures.ChildMaterialProceduresCollection MaterialProcedures
        {
            get
            {
                if (_MaterialProcedures == null)
                    CreateMaterialProceduresCollection();
                return _MaterialProcedures;
            }
        }

        protected Material(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected Material(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected Material(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected Material(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected Material(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "MATERIAL", dataRow) { }
        protected Material(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "MATERIAL", dataRow, isImported) { }
        public Material(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public Material(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public Material() : base() { }

    }
}