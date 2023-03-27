
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="FavoriteDrug")] 

    public  partial class FavoriteDrug : TTObject
    {
        public class FavoriteDrugList : TTObjectCollection<FavoriteDrug> { }
                    
        public class ChildFavoriteDrugCollection : TTObject.TTChildObjectCollection<FavoriteDrug>
        {
            public ChildFavoriteDrugCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildFavoriteDrugCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetFavoriteDrugWithDrugID_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public GetFavoriteDrugWithDrugID_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetFavoriteDrugWithDrugID_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetFavoriteDrugWithDrugID_Class() : base() { }
        }

        [Serializable] 

        public partial class GetFavoriteDrugsWithObjectID_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public Guid? DrugDefinition
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["DRUGDEFINITION"]);
                }
            }

            public string Name
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["NAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DRUGDEFINITION"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public Object Miktar
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["MIKTAR"]);
                }
            }

            public GetFavoriteDrugsWithObjectID_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetFavoriteDrugsWithObjectID_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetFavoriteDrugsWithObjectID_Class() : base() { }
        }

        [Serializable] 

        public partial class GetFavoriteDrugs_Class : TTReportNqlObject 
        {
            public Guid? DrugDefinition
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["DRUGDEFINITION"]);
                }
            }

            public string Name
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["NAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DRUGDEFINITION"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public Object Miktar
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["MIKTAR"]);
                }
            }

            public GetFavoriteDrugs_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetFavoriteDrugs_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetFavoriteDrugs_Class() : base() { }
        }

        [Serializable] 

        public partial class GetFavoriteDrugDefsWithResUser_Class : TTReportNqlObject 
        {
            public Guid? DrugDefinition
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["DRUGDEFINITION"]);
                }
            }

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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DRUGDEFINITION"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public bool? SgkReturnPay
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["SGKRETURNPAY"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DRUGDEFINITION"].AllPropertyDefs["SGKRETURNPAY"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public bool? ShowZeroOnDrugOrder
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["SHOWZEROONDRUGORDER"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DRUGDEFINITION"].AllPropertyDefs["SHOWZEROONDRUGORDER"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DRUGDEFINITION"].AllPropertyDefs["BARCODE"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public DrugUsageTypeEnum? DrugUsageType
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DRUGUSAGETYPE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["ROUTEOFADMIN"].AllPropertyDefs["DRUGUSAGETYPE"].DataType;
                    return (DrugUsageTypeEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public PrescriptionTypeEnum? PrescriptionType
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PRESCRIPTIONTYPE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DRUGDEFINITION"].AllPropertyDefs["PRESCRIPTIONTYPE"].DataType;
                    return (PrescriptionTypeEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public DrugShapeTypeEnum? DrugShapeType
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DRUGSHAPETYPE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DRUGDEFINITION"].AllPropertyDefs["DRUGSHAPETYPE"].DataType;
                    return (DrugShapeTypeEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public bool? PatientSafetyFrom
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PATIENTSAFETYFROM"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DRUGDEFINITION"].AllPropertyDefs["PATIENTSAFETYFROM"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public ColorEnum? Color
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["COLOR"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DRUGDEFINITION"].AllPropertyDefs["COLOR"].DataType;
                    return (ColorEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public Object Inheld
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["INHELD"]);
                }
            }

            public string Drugingredientname
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DRUGINGREDIENTNAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["ACTIVEINGREDIENTDEFINITION"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public Guid? Drugingredientobjectid
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["DRUGINGREDIENTOBJECTID"]);
                }
            }

            public string Drugdescription
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DRUGDESCRIPTION"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DRUGDEFINITION"].AllPropertyDefs["DESCRIPTION"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public bool? DivisibleDrug
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DIVISIBLEDRUG"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DRUGDEFINITION"].AllPropertyDefs["DIVISIBLEDRUG"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public int? Miktar
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MIKTAR"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["FAVORITEDRUG"].AllPropertyDefs["COUNT"].DataType;
                    return (int?)dataType.ConvertValue(val);
                }
            }

            public GetFavoriteDrugDefsWithResUser_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetFavoriteDrugDefsWithResUser_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetFavoriteDrugDefsWithResUser_Class() : base() { }
        }

        [Serializable] 

        public partial class GetFavoriteDrugListRQ_Class : TTReportNqlObject 
        {
            public string Doctorname
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DOCTORNAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESUSER"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Drugname
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DRUGNAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DRUGDEFINITION"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public int? Sayi
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["SAYI"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["FAVORITEDRUG"].AllPropertyDefs["COUNT"].DataType;
                    return (int?)dataType.ConvertValue(val);
                }
            }

            public GetFavoriteDrugListRQ_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetFavoriteDrugListRQ_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetFavoriteDrugListRQ_Class() : base() { }
        }

        public static BindingList<FavoriteDrug.GetFavoriteDrugWithDrugID_Class> GetFavoriteDrugWithDrugID(Guid RESUSER, Guid DRUGID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["FAVORITEDRUG"].QueryDefs["GetFavoriteDrugWithDrugID"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("RESUSER", RESUSER);
            paramList.Add("DRUGID", DRUGID);

            return TTReportNqlObject.QueryObjects<FavoriteDrug.GetFavoriteDrugWithDrugID_Class>(queryDef, paramList, pi);
        }

        public static BindingList<FavoriteDrug.GetFavoriteDrugWithDrugID_Class> GetFavoriteDrugWithDrugID(TTObjectContext objectContext, Guid RESUSER, Guid DRUGID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["FAVORITEDRUG"].QueryDefs["GetFavoriteDrugWithDrugID"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("RESUSER", RESUSER);
            paramList.Add("DRUGID", DRUGID);

            return TTReportNqlObject.QueryObjects<FavoriteDrug.GetFavoriteDrugWithDrugID_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<FavoriteDrug.GetFavoriteDrugsWithObjectID_Class> GetFavoriteDrugsWithObjectID(Guid RESUSER, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["FAVORITEDRUG"].QueryDefs["GetFavoriteDrugsWithObjectID"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("RESUSER", RESUSER);

            return TTReportNqlObject.QueryObjects<FavoriteDrug.GetFavoriteDrugsWithObjectID_Class>(queryDef, paramList, pi);
        }

        public static BindingList<FavoriteDrug.GetFavoriteDrugsWithObjectID_Class> GetFavoriteDrugsWithObjectID(TTObjectContext objectContext, Guid RESUSER, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["FAVORITEDRUG"].QueryDefs["GetFavoriteDrugsWithObjectID"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("RESUSER", RESUSER);

            return TTReportNqlObject.QueryObjects<FavoriteDrug.GetFavoriteDrugsWithObjectID_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<FavoriteDrug.GetFavoriteDrugs_Class> GetFavoriteDrugs(Guid RESUSER, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["FAVORITEDRUG"].QueryDefs["GetFavoriteDrugs"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("RESUSER", RESUSER);

            return TTReportNqlObject.QueryObjects<FavoriteDrug.GetFavoriteDrugs_Class>(queryDef, paramList, pi);
        }

        public static BindingList<FavoriteDrug.GetFavoriteDrugs_Class> GetFavoriteDrugs(TTObjectContext objectContext, Guid RESUSER, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["FAVORITEDRUG"].QueryDefs["GetFavoriteDrugs"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("RESUSER", RESUSER);

            return TTReportNqlObject.QueryObjects<FavoriteDrug.GetFavoriteDrugs_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<FavoriteDrug.GetFavoriteDrugDefsWithResUser_Class> GetFavoriteDrugDefsWithResUser(Guid RESUSER, Guid STORE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["FAVORITEDRUG"].QueryDefs["GetFavoriteDrugDefsWithResUser"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("RESUSER", RESUSER);
            paramList.Add("STORE", STORE);

            return TTReportNqlObject.QueryObjects<FavoriteDrug.GetFavoriteDrugDefsWithResUser_Class>(queryDef, paramList, pi);
        }

        public static BindingList<FavoriteDrug.GetFavoriteDrugDefsWithResUser_Class> GetFavoriteDrugDefsWithResUser(TTObjectContext objectContext, Guid RESUSER, Guid STORE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["FAVORITEDRUG"].QueryDefs["GetFavoriteDrugDefsWithResUser"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("RESUSER", RESUSER);
            paramList.Add("STORE", STORE);

            return TTReportNqlObject.QueryObjects<FavoriteDrug.GetFavoriteDrugDefsWithResUser_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<FavoriteDrug.GetFavoriteDrugListRQ_Class> GetFavoriteDrugListRQ(IList<Guid> RESUSERS, Guid DRUG, bool ALLUSER, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["FAVORITEDRUG"].QueryDefs["GetFavoriteDrugListRQ"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("RESUSERS", RESUSERS);
            paramList.Add("DRUG", DRUG);
            paramList.Add("ALLUSER", ALLUSER);

            return TTReportNqlObject.QueryObjects<FavoriteDrug.GetFavoriteDrugListRQ_Class>(queryDef, paramList, pi);
        }

        public static BindingList<FavoriteDrug.GetFavoriteDrugListRQ_Class> GetFavoriteDrugListRQ(TTObjectContext objectContext, IList<Guid> RESUSERS, Guid DRUG, bool ALLUSER, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["FAVORITEDRUG"].QueryDefs["GetFavoriteDrugListRQ"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("RESUSERS", RESUSERS);
            paramList.Add("DRUG", DRUG);
            paramList.Add("ALLUSER", ALLUSER);

            return TTReportNqlObject.QueryObjects<FavoriteDrug.GetFavoriteDrugListRQ_Class>(objectContext, queryDef, paramList, pi);
        }

    /// <summary>
    /// Yazılma Sayısı
    /// </summary>
        public int? Count
        {
            get { return (int?)this["COUNT"]; }
            set { this["COUNT"] = value; }
        }

        public DrugDefinition DrugDefinition
        {
            get { return (DrugDefinition)((ITTObject)this).GetParent("DRUGDEFINITION"); }
            set { this["DRUGDEFINITION"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public ResUser ResUser
        {
            get { return (ResUser)((ITTObject)this).GetParent("RESUSER"); }
            set { this["RESUSER"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected FavoriteDrug(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected FavoriteDrug(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected FavoriteDrug(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected FavoriteDrug(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected FavoriteDrug(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "FAVORITEDRUG", dataRow) { }
        protected FavoriteDrug(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "FAVORITEDRUG", dataRow, isImported) { }
        public FavoriteDrug(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public FavoriteDrug(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public FavoriteDrug() : base() { }

    }
}