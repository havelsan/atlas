
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="DrugActiveIngredient")] 

    public  partial class DrugActiveIngredient : TerminologyManagerDef
    {
        public class DrugActiveIngredientList : TTObjectCollection<DrugActiveIngredient> { }
                    
        public class ChildDrugActiveIngredientCollection : TTObject.TTChildObjectCollection<DrugActiveIngredient>
        {
            public ChildDrugActiveIngredientCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildDrugActiveIngredientCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetDrugActiveIngReportQuery_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public string Etkinmadde
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ETKINMADDE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["ACTIVEINGREDIENTDEFINITION"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public GetDrugActiveIngReportQuery_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetDrugActiveIngReportQuery_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetDrugActiveIngReportQuery_Class() : base() { }
        }

        [Serializable] 

        public partial class GetAllDrugActiveIngByActiveIngredient_Class : TTReportNqlObject 
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["ACTIVEINGREDIENTDEFINITION"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public Guid? Drugdefinition
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["DRUGDEFINITION"]);
                }
            }

            public GetAllDrugActiveIngByActiveIngredient_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetAllDrugActiveIngByActiveIngredient_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetAllDrugActiveIngByActiveIngredient_Class() : base() { }
        }

        [Serializable] 

        public partial class GetAllDrugByParentActiveIng_Class : TTReportNqlObject 
        {
            public Guid? Drugdefinition
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["DRUGDEFINITION"]);
                }
            }

            public double? Value
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["VALUE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DRUGACTIVEINGREDIENT"].AllPropertyDefs["VALUE"].DataType;
                    return (double?)dataType.ConvertValue(val);
                }
            }

            public GetAllDrugByParentActiveIng_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetAllDrugByParentActiveIng_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetAllDrugByParentActiveIng_Class() : base() { }
        }

        public static BindingList<DrugActiveIngredient.GetDrugActiveIngReportQuery_Class> GetDrugActiveIngReportQuery(string DRUGDEFINITION, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["DRUGACTIVEINGREDIENT"].QueryDefs["GetDrugActiveIngReportQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("DRUGDEFINITION", DRUGDEFINITION);

            return TTReportNqlObject.QueryObjects<DrugActiveIngredient.GetDrugActiveIngReportQuery_Class>(queryDef, paramList, pi);
        }

        public static BindingList<DrugActiveIngredient.GetDrugActiveIngReportQuery_Class> GetDrugActiveIngReportQuery(TTObjectContext objectContext, string DRUGDEFINITION, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["DRUGACTIVEINGREDIENT"].QueryDefs["GetDrugActiveIngReportQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("DRUGDEFINITION", DRUGDEFINITION);

            return TTReportNqlObject.QueryObjects<DrugActiveIngredient.GetDrugActiveIngReportQuery_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<DrugActiveIngredient> GetDrugActiveIngByLastUpdateDate(TTObjectContext objectContext, DateTime STARTDATE, DateTime ENDDATE)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["DRUGACTIVEINGREDIENT"].QueryDefs["GetDrugActiveIngByLastUpdateDate"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);

            return ((ITTQuery)objectContext).QueryObjects<DrugActiveIngredient>(queryDef, paramList);
        }

        public static BindingList<DrugActiveIngredient> GetAll(TTObjectContext objectContext, string injectionSQL)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["DRUGACTIVEINGREDIENT"].QueryDefs["GetAll"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return ((ITTQuery)objectContext).QueryObjects<DrugActiveIngredient>(queryDef, paramList, injectionSQL);
        }

        public static BindingList<DrugActiveIngredient.GetAllDrugActiveIngByActiveIngredient_Class> GetAllDrugActiveIngByActiveIngredient(Guid ActiveIngredientGuid, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["DRUGACTIVEINGREDIENT"].QueryDefs["GetAllDrugActiveIngByActiveIngredient"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("ACTIVEINGREDIENTGUID", ActiveIngredientGuid);

            return TTReportNqlObject.QueryObjects<DrugActiveIngredient.GetAllDrugActiveIngByActiveIngredient_Class>(queryDef, paramList, pi);
        }

        public static BindingList<DrugActiveIngredient.GetAllDrugActiveIngByActiveIngredient_Class> GetAllDrugActiveIngByActiveIngredient(TTObjectContext objectContext, Guid ActiveIngredientGuid, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["DRUGACTIVEINGREDIENT"].QueryDefs["GetAllDrugActiveIngByActiveIngredient"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("ACTIVEINGREDIENTGUID", ActiveIngredientGuid);

            return TTReportNqlObject.QueryObjects<DrugActiveIngredient.GetAllDrugActiveIngByActiveIngredient_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<DrugActiveIngredient.GetAllDrugByParentActiveIng_Class> GetAllDrugByParentActiveIng(Guid ActiveIngredientGuid, Guid ExistDrug, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["DRUGACTIVEINGREDIENT"].QueryDefs["GetAllDrugByParentActiveIng"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("ACTIVEINGREDIENTGUID", ActiveIngredientGuid);
            paramList.Add("EXISTDRUG", ExistDrug);

            return TTReportNqlObject.QueryObjects<DrugActiveIngredient.GetAllDrugByParentActiveIng_Class>(queryDef, paramList, pi);
        }

        public static BindingList<DrugActiveIngredient.GetAllDrugByParentActiveIng_Class> GetAllDrugByParentActiveIng(TTObjectContext objectContext, Guid ActiveIngredientGuid, Guid ExistDrug, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["DRUGACTIVEINGREDIENT"].QueryDefs["GetAllDrugByParentActiveIng"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("ACTIVEINGREDIENTGUID", ActiveIngredientGuid);
            paramList.Add("EXISTDRUG", ExistDrug);

            return TTReportNqlObject.QueryObjects<DrugActiveIngredient.GetAllDrugByParentActiveIng_Class>(objectContext, queryDef, paramList, pi);
        }

    /// <summary>
    /// Maximum Doz
    /// </summary>
        public double? MaxDose
        {
            get { return (double?)this["MAXDOSE"]; }
            set { this["MAXDOSE"] = value; }
        }

        public Guid? OldDrugDefinition
        {
            get { return (Guid?)this["OLDDRUGDEFINITION"]; }
            set { this["OLDDRUGDEFINITION"] = value; }
        }

    /// <summary>
    /// Değer
    /// </summary>
        public double? Value
        {
            get { return (double?)this["VALUE"]; }
            set { this["VALUE"] = value; }
        }

    /// <summary>
    /// Etkin
    /// </summary>
        public bool? IsParentIngredient
        {
            get { return (bool?)this["ISPARENTINGREDIENT"]; }
            set { this["ISPARENTINGREDIENT"] = value; }
        }

        public UnitDefinition Unit
        {
            get { return (UnitDefinition)((ITTObject)this).GetParent("UNIT"); }
            set { this["UNIT"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public DrugDefinition DrugDefinition
        {
            get { return (DrugDefinition)((ITTObject)this).GetParent("DRUGDEFINITION"); }
            set { this["DRUGDEFINITION"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public ActiveIngredientDefinition ActiveIngredient
        {
            get { return (ActiveIngredientDefinition)((ITTObject)this).GetParent("ACTIVEINGREDIENT"); }
            set { this["ACTIVEINGREDIENT"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public UnitDefinition MaxDoseUnit
        {
            get { return (UnitDefinition)((ITTObject)this).GetParent("MAXDOSEUNIT"); }
            set { this["MAXDOSEUNIT"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected DrugActiveIngredient(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected DrugActiveIngredient(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected DrugActiveIngredient(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected DrugActiveIngredient(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected DrugActiveIngredient(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "DRUGACTIVEINGREDIENT", dataRow) { }
        protected DrugActiveIngredient(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "DRUGACTIVEINGREDIENT", dataRow, isImported) { }
        public DrugActiveIngredient(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public DrugActiveIngredient(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public DrugActiveIngredient() : base() { }

    }
}