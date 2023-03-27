
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="ProtocolDefinition")] 

    /// <summary>
    /// Kurum Anlaşma Tanımlama
    /// </summary>
    public  partial class ProtocolDefinition : TerminologyManagerDef
    {
        public class ProtocolDefinitionList : TTObjectCollection<ProtocolDefinition> { }
                    
        public class ChildProtocolDefinitionCollection : TTObject.TTChildObjectCollection<ProtocolDefinition>
        {
            public ChildProtocolDefinitionCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildProtocolDefinitionCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetProtocolDefinitions_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public long? Id
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ID"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PROTOCOLDEFINITION"].AllPropertyDefs["ID"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PROTOCOLDEFINITION"].AllPropertyDefs["CODE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PROTOCOLDEFINITION"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public ProtocolTypeEnum? Type
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["TYPE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PROTOCOLDEFINITION"].AllPropertyDefs["TYPE"].DataType;
                    return (ProtocolTypeEnum?)(int)dataType.ConvertValue(val);
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

            public GetProtocolDefinitions_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetProtocolDefinitions_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetProtocolDefinitions_Class() : base() { }
        }

        public static BindingList<ProtocolDefinition.GetProtocolDefinitions_Class> GetProtocolDefinitions(string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PROTOCOLDEFINITION"].QueryDefs["GetProtocolDefinitions"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<ProtocolDefinition.GetProtocolDefinitions_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<ProtocolDefinition.GetProtocolDefinitions_Class> GetProtocolDefinitions(TTObjectContext objectContext, string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PROTOCOLDEFINITION"].QueryDefs["GetProtocolDefinitions"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<ProtocolDefinition.GetProtocolDefinitions_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<ProtocolDefinition> GetProtocolDefinitionByLastUpdateDate(TTObjectContext objectContext, DateTime STARTDATE, DateTime ENDDATE)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PROTOCOLDEFINITION"].QueryDefs["GetProtocolDefinitionByLastUpdateDate"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);

            return ((ITTQuery)objectContext).QueryObjects<ProtocolDefinition>(queryDef, paramList);
        }

        public static BindingList<ProtocolDefinition> GetByObjectID(TTObjectContext objectContext, string PARAMOBJECTID)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PROTOCOLDEFINITION"].QueryDefs["GetByObjectID"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("PARAMOBJECTID", PARAMOBJECTID);

            return ((ITTQuery)objectContext).QueryObjects<ProtocolDefinition>(queryDef, paramList);
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

        public long? Id
        {
            get { return (long?)this["ID"]; }
            set { this["ID"] = value; }
        }

    /// <summary>
    /// Tür
    /// </summary>
        public ProtocolTypeEnum? Type
        {
            get { return (ProtocolTypeEnum?)(int?)this["TYPE"]; }
            set { this["TYPE"] = value; }
        }

        public string Name_Shadow
        {
            get { return (string)this["NAME_SHADOW"]; }
        }

    /// <summary>
    /// Döner Sermaye Kontrolü Gerektirir
    /// </summary>
        public bool? RequiresFinancialControl
        {
            get { return (bool?)this["REQUIRESFINANCIALCONTROL"]; }
            set { this["REQUIRESFINANCIALCONTROL"] = value; }
        }

    /// <summary>
    /// Özel Muayene Farkı Alınır
    /// </summary>
        public bool? SpecialExamination
        {
            get { return (bool?)this["SPECIALEXAMINATION"]; }
            set { this["SPECIALEXAMINATION"] = value; }
        }

    /// <summary>
    /// Avans Alınması Zorunlu
    /// </summary>
        public bool? RequiresAdvance
        {
            get { return (bool?)this["REQUIRESADVANCE"]; }
            set { this["REQUIRESADVANCE"] = value; }
        }

    /// <summary>
    /// Ayaktan Hasta Ödeme Türü
    /// </summary>
        public AccountOperationTimeEnum? OutPatientPaymentType
        {
            get { return (AccountOperationTimeEnum?)(int?)this["OUTPATIENTPAYMENTTYPE"]; }
            set { this["OUTPATIENTPAYMENTTYPE"] = value; }
        }

    /// <summary>
    /// Yatan Hasta Ödeme Türü
    /// </summary>
        public AccountOperationTimeEnum? InPatientPaymentType
        {
            get { return (AccountOperationTimeEnum?)(int?)this["INPATIENTPAYMENTTYPE"]; }
            set { this["INPATIENTPAYMENTTYPE"] = value; }
        }

        virtual protected void CreateTransferFromPackageCollection()
        {
            _TransferFromPackage = new TransferFromPackage.ChildTransferFromPackageCollection(this, new Guid("9a56835c-fbcc-430d-bbfc-1343f5803e17"));
            ((ITTChildObjectCollection)_TransferFromPackage).GetChildren();
        }

        protected TransferFromPackage.ChildTransferFromPackageCollection _TransferFromPackage = null;
    /// <summary>
    /// Child collection for Anlaşma ile ilişki
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

        virtual protected void CreateProtocolPriceCollection()
        {
            _ProtocolPrice = new ProtocolPriceCalculation.ChildProtocolPriceCalculationCollection(this, new Guid("e9625d7f-c405-4267-8a01-6d6961752dfe"));
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

        virtual protected void CreateProtocolDetailMaterialsCollection()
        {
            _ProtocolDetailMaterials = new ProtocolDetailMaterialDefinition.ChildProtocolDetailMaterialDefinitionCollection(this, new Guid("063cc3d4-9766-4f90-b8e4-5ee4048e4f10"));
            ((ITTChildObjectCollection)_ProtocolDetailMaterials).GetChildren();
        }

        protected ProtocolDetailMaterialDefinition.ChildProtocolDetailMaterialDefinitionCollection _ProtocolDetailMaterials = null;
    /// <summary>
    /// Child collection for Anlaşma Tanımı ile ilişki
    /// </summary>
        public ProtocolDetailMaterialDefinition.ChildProtocolDetailMaterialDefinitionCollection ProtocolDetailMaterials
        {
            get
            {
                if (_ProtocolDetailMaterials == null)
                    CreateProtocolDetailMaterialsCollection();
                return _ProtocolDetailMaterials;
            }
        }

        virtual protected void CreateExceptionMaterialsCollection()
        {
            _ExceptionMaterials = new ProtocolExceptionMaterialDefinition.ChildProtocolExceptionMaterialDefinitionCollection(this, new Guid("5911d1ce-adf6-41a8-8a2c-7ae8dc6b9770"));
            ((ITTChildObjectCollection)_ExceptionMaterials).GetChildren();
        }

        protected ProtocolExceptionMaterialDefinition.ChildProtocolExceptionMaterialDefinitionCollection _ExceptionMaterials = null;
    /// <summary>
    /// Child collection for Anlaşma Tanımı ile ilişki
    /// </summary>
        public ProtocolExceptionMaterialDefinition.ChildProtocolExceptionMaterialDefinitionCollection ExceptionMaterials
        {
            get
            {
                if (_ExceptionMaterials == null)
                    CreateExceptionMaterialsCollection();
                return _ExceptionMaterials;
            }
        }

        virtual protected void CreateProtocolDetailProceduresCollection()
        {
            _ProtocolDetailProcedures = new ProtocolDetailProcedureDefinition.ChildProtocolDetailProcedureDefinitionCollection(this, new Guid("e60bec35-95ed-45f9-9be8-ae16fe640db3"));
            ((ITTChildObjectCollection)_ProtocolDetailProcedures).GetChildren();
        }

        protected ProtocolDetailProcedureDefinition.ChildProtocolDetailProcedureDefinitionCollection _ProtocolDetailProcedures = null;
    /// <summary>
    /// Child collection for Anlaşma Tanımı ile ilişki
    /// </summary>
        public ProtocolDetailProcedureDefinition.ChildProtocolDetailProcedureDefinitionCollection ProtocolDetailProcedures
        {
            get
            {
                if (_ProtocolDetailProcedures == null)
                    CreateProtocolDetailProceduresCollection();
                return _ProtocolDetailProcedures;
            }
        }

        virtual protected void CreateEpisodeProtocolCollection()
        {
            _EpisodeProtocol = new EpisodeProtocol.ChildEpisodeProtocolCollection(this, new Guid("4e2d5f2f-b05f-4fb3-875b-977c1b2fe659"));
            ((ITTChildObjectCollection)_EpisodeProtocol).GetChildren();
        }

        protected EpisodeProtocol.ChildEpisodeProtocolCollection _EpisodeProtocol = null;
    /// <summary>
    /// Child collection for Anlaşma tanımı ile ilişki
    /// </summary>
        public EpisodeProtocol.ChildEpisodeProtocolCollection EpisodeProtocol
        {
            get
            {
                if (_EpisodeProtocol == null)
                    CreateEpisodeProtocolCollection();
                return _EpisodeProtocol;
            }
        }

        virtual protected void CreatePayerInvoiceCollection()
        {
            _PayerInvoice = new PayerInvoice.ChildPayerInvoiceCollection(this, new Guid("f169dca8-c08b-4c79-92fd-761bc129fa87"));
            ((ITTChildObjectCollection)_PayerInvoice).GetChildren();
        }

        protected PayerInvoice.ChildPayerInvoiceCollection _PayerInvoice = null;
    /// <summary>
    /// Child collection for Anlaşmalarla İlişki
    /// </summary>
        public PayerInvoice.ChildPayerInvoiceCollection PayerInvoice
        {
            get
            {
                if (_PayerInvoice == null)
                    CreatePayerInvoiceCollection();
                return _PayerInvoice;
            }
        }

        virtual protected void CreateExceptionProceduresCollection()
        {
            _ExceptionProcedures = new ProtocolExceptionProcedureDefinition.ChildProtocolExceptionProcedureDefinitionCollection(this, new Guid("b6f49796-93aa-41a0-bc54-cb8b046c149f"));
            ((ITTChildObjectCollection)_ExceptionProcedures).GetChildren();
        }

        protected ProtocolExceptionProcedureDefinition.ChildProtocolExceptionProcedureDefinitionCollection _ExceptionProcedures = null;
    /// <summary>
    /// Child collection for Anlaşma Tanımı ile ilişki
    /// </summary>
        public ProtocolExceptionProcedureDefinition.ChildProtocolExceptionProcedureDefinitionCollection ExceptionProcedures
        {
            get
            {
                if (_ExceptionProcedures == null)
                    CreateExceptionProceduresCollection();
                return _ExceptionProcedures;
            }
        }

        virtual protected void CreatePayerProtocolDefinitionsCollection()
        {
            _PayerProtocolDefinitions = new PayerProtocolDefinition.ChildPayerProtocolDefinitionCollection(this, new Guid("3114cba2-2953-4a97-88d0-f7249849daf7"));
            ((ITTChildObjectCollection)_PayerProtocolDefinitions).GetChildren();
        }

        protected PayerProtocolDefinition.ChildPayerProtocolDefinitionCollection _PayerProtocolDefinitions = null;
    /// <summary>
    /// Child collection for Protocol ile PayerProtocol iliskisi
    /// </summary>
        public PayerProtocolDefinition.ChildPayerProtocolDefinitionCollection PayerProtocolDefinitions
        {
            get
            {
                if (_PayerProtocolDefinitions == null)
                    CreatePayerProtocolDefinitionsCollection();
                return _PayerProtocolDefinitions;
            }
        }

        virtual protected void CreateIIMProtocolsCollection()
        {
            _IIMProtocols = new IIMProtocol.ChildIIMProtocolCollection(this, new Guid("d7b2b613-37ad-454a-8c96-0cec671b1329"));
            ((ITTChildObjectCollection)_IIMProtocols).GetChildren();
        }

        protected IIMProtocol.ChildIIMProtocolCollection _IIMProtocols = null;
    /// <summary>
    /// Child collection for Kural Protokol bilgisi
    /// </summary>
        public IIMProtocol.ChildIIMProtocolCollection IIMProtocols
        {
            get
            {
                if (_IIMProtocols == null)
                    CreateIIMProtocolsCollection();
                return _IIMProtocols;
            }
        }

        virtual protected void CreateSubEpisodeProtocolsCollection()
        {
            _SubEpisodeProtocols = new SubEpisodeProtocol.ChildSubEpisodeProtocolCollection(this, new Guid("d8b58904-1317-482a-b9d0-4d2952914781"));
            ((ITTChildObjectCollection)_SubEpisodeProtocols).GetChildren();
        }

        protected SubEpisodeProtocol.ChildSubEpisodeProtocolCollection _SubEpisodeProtocols = null;
        public SubEpisodeProtocol.ChildSubEpisodeProtocolCollection SubEpisodeProtocols
        {
            get
            {
                if (_SubEpisodeProtocols == null)
                    CreateSubEpisodeProtocolsCollection();
                return _SubEpisodeProtocols;
            }
        }

        protected ProtocolDefinition(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected ProtocolDefinition(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected ProtocolDefinition(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected ProtocolDefinition(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected ProtocolDefinition(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "PROTOCOLDEFINITION", dataRow) { }
        protected ProtocolDefinition(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "PROTOCOLDEFINITION", dataRow, isImported) { }
        protected ProtocolDefinition(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public ProtocolDefinition(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public ProtocolDefinition() : base() { }

    }
}