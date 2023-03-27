
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="ActiveIngredientDefinition")] 

    public  partial class ActiveIngredientDefinition : TerminologyManagerDef
    {
        public class ActiveIngredientDefinitionList : TTObjectCollection<ActiveIngredientDefinition> { }
                    
        public class ChildActiveIngredientDefinitionCollection : TTObject.TTChildObjectCollection<ActiveIngredientDefinition>
        {
            public ChildActiveIngredientDefinitionCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildActiveIngredientDefinitionCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetActiveIngredientDefinitions_Class : TTReportNqlObject 
        {
            public string Code
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["CODE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["ACTIVEINGREDIENTDEFINITION"].AllPropertyDefs["CODE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["ACTIVEINGREDIENTDEFINITION"].AllPropertyDefs["NATOSTOCKNO"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["ACTIVEINGREDIENTDEFINITION"].AllPropertyDefs["NAME"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["ACTIVEINGREDIENTDEFINITION"].AllPropertyDefs["DESCRIPTION"].DataType;
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

            public GetActiveIngredientDefinitions_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetActiveIngredientDefinitions_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetActiveIngredientDefinitions_Class() : base() { }
        }

        [Serializable] 

        public partial class GetActiveIngredientListReportQuery_Class : TTReportNqlObject 
        {
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

            public GetActiveIngredientListReportQuery_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetActiveIngredientListReportQuery_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetActiveIngredientListReportQuery_Class() : base() { }
        }

        public static BindingList<ActiveIngredientDefinition.GetActiveIngredientDefinitions_Class> GetActiveIngredientDefinitions(string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["ACTIVEINGREDIENTDEFINITION"].QueryDefs["GetActiveIngredientDefinitions"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<ActiveIngredientDefinition.GetActiveIngredientDefinitions_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<ActiveIngredientDefinition.GetActiveIngredientDefinitions_Class> GetActiveIngredientDefinitions(TTObjectContext objectContext, string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["ACTIVEINGREDIENTDEFINITION"].QueryDefs["GetActiveIngredientDefinitions"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<ActiveIngredientDefinition.GetActiveIngredientDefinitions_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<ActiveIngredientDefinition.GetActiveIngredientListReportQuery_Class> GetActiveIngredientListReportQuery(PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["ACTIVEINGREDIENTDEFINITION"].QueryDefs["GetActiveIngredientListReportQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<ActiveIngredientDefinition.GetActiveIngredientListReportQuery_Class>(queryDef, paramList, pi);
        }

        public static BindingList<ActiveIngredientDefinition.GetActiveIngredientListReportQuery_Class> GetActiveIngredientListReportQuery(TTObjectContext objectContext, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["ACTIVEINGREDIENTDEFINITION"].QueryDefs["GetActiveIngredientListReportQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<ActiveIngredientDefinition.GetActiveIngredientListReportQuery_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<ActiveIngredientDefinition> GetActiveIngredientbySPTSActiveIngredientID(TTObjectContext objectContext, long SPTSACTIVEINGREDIENTID)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["ACTIVEINGREDIENTDEFINITION"].QueryDefs["GetActiveIngredientbySPTSActiveIngredientID"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("SPTSACTIVEINGREDIENTID", SPTSACTIVEINGREDIENTID);

            return ((ITTQuery)objectContext).QueryObjects<ActiveIngredientDefinition>(queryDef, paramList);
        }

        public static BindingList<ActiveIngredientDefinition> GetActiveIngredientDefinitionByLastUpdateDate(TTObjectContext objectContext, DateTime STARTDATE, DateTime ENDDATE)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["ACTIVEINGREDIENTDEFINITION"].QueryDefs["GetActiveIngredientDefinitionByLastUpdateDate"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);

            return ((ITTQuery)objectContext).QueryObjects<ActiveIngredientDefinition>(queryDef, paramList);
        }

        public static BindingList<ActiveIngredientDefinition> GetAllActiveIngredientDefinitions(TTObjectContext objectContext, string injectionSQL)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["ACTIVEINGREDIENTDEFINITION"].QueryDefs["GetAllActiveIngredientDefinitions"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return ((ITTQuery)objectContext).QueryObjects<ActiveIngredientDefinition>(queryDef, paramList, injectionSQL);
        }

    /// <summary>
    /// Hızlı Referans
    /// </summary>
        public string QREF
        {
            get { return (string)this["QREF"]; }
            set { this["QREF"] = value; }
        }

    /// <summary>
    /// NATO Stok No
    /// </summary>
        public string NATOStockNO
        {
            get { return (string)this["NATOSTOCKNO"]; }
            set { this["NATOSTOCKNO"] = value; }
        }

    /// <summary>
    /// Etken Madde Kodu
    /// </summary>
        public string Code
        {
            get { return (string)this["CODE"]; }
            set { this["CODE"] = value; }
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
    /// Etken Madde Adı
    /// </summary>
        public string Name
        {
            get { return (string)this["NAME"]; }
            set { this["NAME"] = value; }
        }

        public long? SPTSActiveIngredientID
        {
            get { return (long?)this["SPTSACTIVEINGREDIENTID"]; }
            set { this["SPTSACTIVEINGREDIENTID"] = value; }
        }

        public string Name_Shadow
        {
            get { return (string)this["NAME_SHADOW"]; }
        }

    /// <summary>
    /// Maximum Doz
    /// </summary>
        public double? MaxDose
        {
            get { return (double?)this["MAXDOSE"]; }
            set { this["MAXDOSE"] = value; }
        }

        public UnitDefinition MaxDoseUnit
        {
            get { return (UnitDefinition)((ITTObject)this).GetParent("MAXDOSEUNIT"); }
            set { this["MAXDOSEUNIT"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        virtual protected void CreateActiveIngredientInteractionsCollection()
        {
            _ActiveIngredientInteractions = new ActiveIngredientInteraction.ChildActiveIngredientInteractionCollection(this, new Guid("d08b9cb4-e1f1-4d3d-8c07-9d02e5398179"));
            ((ITTChildObjectCollection)_ActiveIngredientInteractions).GetChildren();
        }

        protected ActiveIngredientInteraction.ChildActiveIngredientInteractionCollection _ActiveIngredientInteractions = null;
        public ActiveIngredientInteraction.ChildActiveIngredientInteractionCollection ActiveIngredientInteractions
        {
            get
            {
                if (_ActiveIngredientInteractions == null)
                    CreateActiveIngredientInteractionsCollection();
                return _ActiveIngredientInteractions;
            }
        }

        virtual protected void CreateActiveIngredientDetailsCollection()
        {
            _ActiveIngredientDetails = new ActiveIngredientDetail.ChildActiveIngredientDetailCollection(this, new Guid("ffd52e06-2e0a-4124-9cab-2edf08fe323d"));
            ((ITTChildObjectCollection)_ActiveIngredientDetails).GetChildren();
        }

        protected ActiveIngredientDetail.ChildActiveIngredientDetailCollection _ActiveIngredientDetails = null;
        public ActiveIngredientDetail.ChildActiveIngredientDetailCollection ActiveIngredientDetails
        {
            get
            {
                if (_ActiveIngredientDetails == null)
                    CreateActiveIngredientDetailsCollection();
                return _ActiveIngredientDetails;
            }
        }

        protected ActiveIngredientDefinition(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected ActiveIngredientDefinition(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected ActiveIngredientDefinition(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected ActiveIngredientDefinition(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected ActiveIngredientDefinition(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "ACTIVEINGREDIENTDEFINITION", dataRow) { }
        protected ActiveIngredientDefinition(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "ACTIVEINGREDIENTDEFINITION", dataRow, isImported) { }
        public ActiveIngredientDefinition(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public ActiveIngredientDefinition(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public ActiveIngredientDefinition() : base() { }

    }
}