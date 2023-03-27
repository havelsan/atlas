
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="NucMedRadPharmMatGrid")] 

    public  partial class NucMedRadPharmMatGrid : BaseTreatmentMaterial
    {
        public class NucMedRadPharmMatGridList : TTObjectCollection<NucMedRadPharmMatGrid> { }
                    
        public class ChildNucMedRadPharmMatGridCollection : TTObject.TTChildObjectCollection<NucMedRadPharmMatGrid>
        {
            public ChildNucMedRadPharmMatGridCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildNucMedRadPharmMatGridCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class NucMedRadPharmMatRepNQL_Class : TTReportNqlObject 
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

            public bool? Eligible
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ELIGIBLE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["NUCMEDRADPHARMMATGRID"].AllPropertyDefs["ELIGIBLE"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public double? Amount
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["AMOUNT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["NUCMEDRADPHARMMATGRID"].AllPropertyDefs["AMOUNT"].DataType;
                    return (double?)dataType.ConvertValue(val);
                }
            }

            public DateTime? ActionDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ACTIONDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["NUCMEDRADPHARMMATGRID"].AllPropertyDefs["ACTIONDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public DateTime? PricingDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PRICINGDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["NUCMEDRADPHARMMATGRID"].AllPropertyDefs["PRICINGDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public bool? Active
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ACTIVE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["NUCMEDRADPHARMMATGRID"].AllPropertyDefs["ACTIVE"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public long? ID
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ID"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["NUCMEDRADPHARMMATGRID"].AllPropertyDefs["ID"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public bool? AccTrxsMultipliedByAmount
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ACCTRXSMULTIPLIEDBYAMOUNT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["NUCMEDRADPHARMMATGRID"].AllPropertyDefs["ACCTRXSMULTIPLIEDBYAMOUNT"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public bool? AccountOperationDone
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ACCOUNTOPERATIONDONE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["NUCMEDRADPHARMMATGRID"].AllPropertyDefs["ACCOUNTOPERATIONDONE"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public bool? PatientPay
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PATIENTPAY"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["NUCMEDRADPHARMMATGRID"].AllPropertyDefs["PATIENTPAY"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public string DonorID
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DONORID"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["NUCMEDRADPHARMMATGRID"].AllPropertyDefs["DONORID"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public int? UseAmount
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["USEAMOUNT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["NUCMEDRADPHARMMATGRID"].AllPropertyDefs["USEAMOUNT"].DataType;
                    return (int?)dataType.ConvertValue(val);
                }
            }

            public string UBBCode
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["UBBCODE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["NUCMEDRADPHARMMATGRID"].AllPropertyDefs["UBBCODE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["NUCMEDRADPHARMMATGRID"].AllPropertyDefs["CREATIONDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public bool? IsOldAction
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ISOLDACTION"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["NUCMEDRADPHARMMATGRID"].AllPropertyDefs["ISOLDACTION"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public string MedulaReportNo
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MEDULAREPORTNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["NUCMEDRADPHARMMATGRID"].AllPropertyDefs["MEDULAREPORTNO"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Note
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["NOTE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["NUCMEDRADPHARMMATGRID"].AllPropertyDefs["NOTE"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public int? Kdv
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["KDV"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["NUCMEDRADPHARMMATGRID"].AllPropertyDefs["KDV"].DataType;
                    return (int?)dataType.ConvertValue(val);
                }
            }

            public string MalzemeBrans
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MALZEMEBRANS"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["NUCMEDRADPHARMMATGRID"].AllPropertyDefs["MALZEMEBRANS"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public DateTime? MalzemeSatinAlisTarihi
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MALZEMESATINALISTARIHI"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["NUCMEDRADPHARMMATGRID"].AllPropertyDefs["MALZEMESATINALISTARIHI"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public double? KodsuzMalzemeFiyati
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["KODSUZMALZEMEFIYATI"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["NUCMEDRADPHARMMATGRID"].AllPropertyDefs["KODSUZMALZEMEFIYATI"].DataType;
                    return (double?)dataType.ConvertValue(val);
                }
            }

            public double? UnitPrice
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["UNITPRICE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["NUCMEDRADPHARMMATGRID"].AllPropertyDefs["UNITPRICE"].DataType;
                    return (double?)dataType.ConvertValue(val);
                }
            }

            public string DealerNo
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DEALERNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["NUCMEDRADPHARMMATGRID"].AllPropertyDefs["DEALERNO"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public bool? IsInjection
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ISINJECTION"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["NUCMEDRADPHARMMATGRID"].AllPropertyDefs["ISINJECTION"].DataType;
                    return (bool?)dataType.ConvertValue(val);
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

            public NucMedRadPharmMatRepNQL_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public NucMedRadPharmMatRepNQL_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected NucMedRadPharmMatRepNQL_Class() : base() { }
        }

        new public static class States
        {
    /// <summary>
    /// İptal
    /// </summary>
            public static Guid Cancelled { get { return new Guid("992adf01-83e6-4cfd-8b2d-b4e5ec7c6ce9"); } }
    /// <summary>
    /// Tamam
    /// </summary>
            public static Guid Completed { get { return new Guid("5b5b0e4f-bc4f-46dc-b5c8-6b64c3add14c"); } }
    /// <summary>
    /// Yeni
    /// </summary>
            public static Guid New { get { return new Guid("ca1c1c02-0674-47ad-ae79-e1bb1503065d"); } }
        }

        public static BindingList<NucMedRadPharmMatGrid.NucMedRadPharmMatRepNQL_Class> NucMedRadPharmMatRepNQL(string NUCLEARMEDICINE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["NUCMEDRADPHARMMATGRID"].QueryDefs["NucMedRadPharmMatRepNQL"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("NUCLEARMEDICINE", NUCLEARMEDICINE);

            return TTReportNqlObject.QueryObjects<NucMedRadPharmMatGrid.NucMedRadPharmMatRepNQL_Class>(queryDef, paramList, pi);
        }

        public static BindingList<NucMedRadPharmMatGrid.NucMedRadPharmMatRepNQL_Class> NucMedRadPharmMatRepNQL(TTObjectContext objectContext, string NUCLEARMEDICINE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["NUCMEDRADPHARMMATGRID"].QueryDefs["NucMedRadPharmMatRepNQL"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("NUCLEARMEDICINE", NUCLEARMEDICINE);

            return TTReportNqlObject.QueryObjects<NucMedRadPharmMatGrid.NucMedRadPharmMatRepNQL_Class>(objectContext, queryDef, paramList, pi);
        }

    /// <summary>
    /// Enjeksiyon
    /// </summary>
        public bool? IsInjection
        {
            get { return (bool?)this["ISINJECTION"]; }
            set { this["ISINJECTION"] = value; }
        }

    /// <summary>
    /// Radyofarmasötik Birimi Tanım İlişkisi
    /// </summary>
        public RadioPharmaceuticalUnitDefinition Unit
        {
            get { return (RadioPharmaceuticalUnitDefinition)((ITTObject)this).GetParent("UNIT"); }
            set { this["UNIT"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public NuclearMedicine NuclearMedicine
        {
            get 
            {   
                if (EpisodeAction is NuclearMedicine)
                    return (NuclearMedicine)EpisodeAction; 
                return null;
            }            
            set { EpisodeAction = value; }
        }

        protected NucMedRadPharmMatGrid(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected NucMedRadPharmMatGrid(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected NucMedRadPharmMatGrid(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected NucMedRadPharmMatGrid(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected NucMedRadPharmMatGrid(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "NUCMEDRADPHARMMATGRID", dataRow) { }
        protected NucMedRadPharmMatGrid(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "NUCMEDRADPHARMMATGRID", dataRow, isImported) { }
        public NucMedRadPharmMatGrid(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public NucMedRadPharmMatGrid(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public NucMedRadPharmMatGrid() : base() { }

    }
}