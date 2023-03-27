
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="MedicalWaste")] 

    /// <summary>
    /// Tıbbi/Tehlikeli Atık
    /// </summary>
    public  partial class MedicalWaste : TTObject
    {
        public class MedicalWasteList : TTObjectCollection<MedicalWaste> { }
                    
        public class ChildMedicalWasteCollection : TTObject.TTChildObjectCollection<MedicalWaste>
        {
            public ChildMedicalWasteCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildMedicalWasteCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetMedicalWasteWithParam_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public double? Amount
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["AMOUNT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MEDICALWASTE"].AllPropertyDefs["AMOUNT"].DataType;
                    return (double?)dataType.ConvertValue(val);
                }
            }

            public string Medicalwasteproduce
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MEDICALWASTEPRODUCE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MEDICALWASTEPRODUCEDEFINITION"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Medicalwastetype
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MEDICALWASTETYPE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MEDICALWASTETYPEDEFINITION"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Ressection
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["RESSECTION"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESSECTION"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public DateTime? TransactionDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["TRANSACTIONDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MEDICALWASTE"].AllPropertyDefs["TRANSACTIONDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public DateTime? DeliveryDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DELIVERYDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MEDICALWASTE"].AllPropertyDefs["DELIVERYDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public GetMedicalWasteWithParam_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetMedicalWasteWithParam_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetMedicalWasteWithParam_Class() : base() { }
        }

        [Serializable] 

        public partial class GetAllMedicalWaste_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public double? Amount
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["AMOUNT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MEDICALWASTE"].AllPropertyDefs["AMOUNT"].DataType;
                    return (double?)dataType.ConvertValue(val);
                }
            }

            public string Medicalwasteproduce
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MEDICALWASTEPRODUCE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MEDICALWASTEPRODUCEDEFINITION"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Medicalwastetype
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MEDICALWASTETYPE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MEDICALWASTETYPEDEFINITION"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Ressection
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["RESSECTION"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESSECTION"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Containername
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["CONTAINERNAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MEDICALWASTECONTAINERDEFINITION"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public DateTime? TransactionDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["TRANSACTIONDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MEDICALWASTE"].AllPropertyDefs["TRANSACTIONDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public DateTime? DeliveryDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DELIVERYDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MEDICALWASTE"].AllPropertyDefs["DELIVERYDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public GetAllMedicalWaste_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetAllMedicalWaste_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetAllMedicalWaste_Class() : base() { }
        }

        public static class States
        {
    /// <summary>
    /// Yeni
    /// </summary>
            public static Guid New { get { return new Guid("64c5e121-820b-4014-ba99-e2eb7bc174eb"); } }
    /// <summary>
    /// İptal
    /// </summary>
            public static Guid Cancelled { get { return new Guid("efbdc587-8a6b-44a4-978b-6f930fb8c341"); } }
        }

        public static BindingList<MedicalWaste.GetMedicalWasteWithParam_Class> GetMedicalWasteWithParam(DateTime StartDate, DateTime EndDate, Guid Resource, Guid MedicalWasteType, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["MEDICALWASTE"].QueryDefs["GetMedicalWasteWithParam"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STARTDATE", StartDate);
            paramList.Add("ENDDATE", EndDate);
            paramList.Add("RESOURCE", Resource);
            paramList.Add("MEDICALWASTETYPE", MedicalWasteType);

            return TTReportNqlObject.QueryObjects<MedicalWaste.GetMedicalWasteWithParam_Class>(queryDef, paramList, pi);
        }

        public static BindingList<MedicalWaste.GetMedicalWasteWithParam_Class> GetMedicalWasteWithParam(TTObjectContext objectContext, DateTime StartDate, DateTime EndDate, Guid Resource, Guid MedicalWasteType, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["MEDICALWASTE"].QueryDefs["GetMedicalWasteWithParam"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STARTDATE", StartDate);
            paramList.Add("ENDDATE", EndDate);
            paramList.Add("RESOURCE", Resource);
            paramList.Add("MEDICALWASTETYPE", MedicalWasteType);

            return TTReportNqlObject.QueryObjects<MedicalWaste.GetMedicalWasteWithParam_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<MedicalWaste.GetAllMedicalWaste_Class> GetAllMedicalWaste(PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["MEDICALWASTE"].QueryDefs["GetAllMedicalWaste"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<MedicalWaste.GetAllMedicalWaste_Class>(queryDef, paramList, pi);
        }

        public static BindingList<MedicalWaste.GetAllMedicalWaste_Class> GetAllMedicalWaste(TTObjectContext objectContext, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["MEDICALWASTE"].QueryDefs["GetAllMedicalWaste"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<MedicalWaste.GetAllMedicalWaste_Class>(objectContext, queryDef, paramList, pi);
        }

    /// <summary>
    /// İşlem Tarihi
    /// </summary>
        public DateTime? TransactionDate
        {
            get { return (DateTime?)this["TRANSACTIONDATE"]; }
            set { this["TRANSACTIONDATE"] = value; }
        }

    /// <summary>
    /// Miktar
    /// </summary>
        public double? Amount
        {
            get { return (double?)this["AMOUNT"]; }
            set { this["AMOUNT"] = value; }
        }

        public DateTime? DeliveryDate
        {
            get { return (DateTime?)this["DELIVERYDATE"]; }
            set { this["DELIVERYDATE"] = value; }
        }

    /// <summary>
    /// İşlem Türü
    /// </summary>
        public MedicalWasteTypeDefinition MedicalWasteType
        {
            get { return (MedicalWasteTypeDefinition)((ITTObject)this).GetParent("MEDICALWASTETYPE"); }
            set { this["MEDICALWASTETYPE"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Ürün Adı
    /// </summary>
        public MedicalWasteProduceDefinition MedicalWasteProduce
        {
            get { return (MedicalWasteProduceDefinition)((ITTObject)this).GetParent("MEDICALWASTEPRODUCE"); }
            set { this["MEDICALWASTEPRODUCE"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Birim
    /// </summary>
        public ResSection ResSection
        {
            get { return (ResSection)((ITTObject)this).GetParent("RESSECTION"); }
            set { this["RESSECTION"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Konteynır
    /// </summary>
        public MedicalWasteContainerDefinition MedicalWasteContainer
        {
            get { return (MedicalWasteContainerDefinition)((ITTObject)this).GetParent("MEDICALWASTECONTAINER"); }
            set { this["MEDICALWASTECONTAINER"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected MedicalWaste(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected MedicalWaste(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected MedicalWaste(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected MedicalWaste(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected MedicalWaste(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "MEDICALWASTE", dataRow) { }
        protected MedicalWaste(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "MEDICALWASTE", dataRow, isImported) { }
        public MedicalWaste(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public MedicalWaste(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public MedicalWaste() : base() { }

        override protected void RunPreTransition(TTObjectStateTransitionDef transDef)
        {
            if (MustCallBasePreScript(transDef))
                base.RunPreTransition(transDef.BaseTransDef);
            this.PreTransition(transDef);
        }
        override protected void RunPostTransition(TTObjectStateTransitionDef transDef)
        {
            if (MustCallBasePostScript(transDef))
                base.RunPostTransition(transDef.BaseTransDef);
            this.PostTransition(transDef);
        }
        override protected void RunUndoTransition(TTObjectStateTransitionDef transDef)
        {
            if (MustCallBaseUndoScript(transDef))
                base.RunUndoTransition(transDef.BaseTransDef);
            this.UndoTransition(transDef);
        }
    }
}