
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="FinancialReturnReasonDefinition")] 

    /// <summary>
    /// Döner Sermaye Hasta İade Nedeni Tanım Ekranı
    /// </summary>
    public  partial class FinancialReturnReasonDefinition : TerminologyManagerDef
    {
        public class FinancialReturnReasonDefinitionList : TTObjectCollection<FinancialReturnReasonDefinition> { }
                    
        public class ChildFinancialReturnReasonDefinitionCollection : TTObject.TTChildObjectCollection<FinancialReturnReasonDefinition>
        {
            public ChildFinancialReturnReasonDefinitionCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildFinancialReturnReasonDefinitionCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetFinancialReturnReasonDefinitions_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public long? Code
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["CODE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["FINANCIALRETURNREASONDEFINITION"].AllPropertyDefs["CODE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["FINANCIALRETURNREASONDEFINITION"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public GetFinancialReturnReasonDefinitions_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetFinancialReturnReasonDefinitions_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetFinancialReturnReasonDefinitions_Class() : base() { }
        }

        public static BindingList<FinancialReturnReasonDefinition.GetFinancialReturnReasonDefinitions_Class> GetFinancialReturnReasonDefinitions(string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["FINANCIALRETURNREASONDEFINITION"].QueryDefs["GetFinancialReturnReasonDefinitions"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<FinancialReturnReasonDefinition.GetFinancialReturnReasonDefinitions_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<FinancialReturnReasonDefinition.GetFinancialReturnReasonDefinitions_Class> GetFinancialReturnReasonDefinitions(TTObjectContext objectContext, string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["FINANCIALRETURNREASONDEFINITION"].QueryDefs["GetFinancialReturnReasonDefinitions"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<FinancialReturnReasonDefinition.GetFinancialReturnReasonDefinitions_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<FinancialReturnReasonDefinition> GetFinancialReturnReasonDefByLastUpdateDate(TTObjectContext objectContext, DateTime STARTDATE, DateTime ENDDATE)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["FINANCIALRETURNREASONDEFINITION"].QueryDefs["GetFinancialReturnReasonDefByLastUpdateDate"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);

            return ((ITTQuery)objectContext).QueryObjects<FinancialReturnReasonDefinition>(queryDef, paramList);
        }

    /// <summary>
    /// Kod
    /// </summary>
        public long? Code
        {
            get { return (long?)this["CODE"]; }
            set { this["CODE"] = value; }
        }

    /// <summary>
    /// Ad
    /// </summary>
        public string Name
        {
            get { return (string)this["NAME"]; }
            set { this["NAME"] = value; }
        }

        public string Name_Shadow
        {
            get { return (string)this["NAME_SHADOW"]; }
        }

        virtual protected void CreateFinancialPatientReturnCollection()
        {
            _FinancialPatientReturn = new FinancialPatientReturn.ChildFinancialPatientReturnCollection(this, new Guid("caad94ae-a44e-4df6-ad72-942c5f9bd42a"));
            ((ITTChildObjectCollection)_FinancialPatientReturn).GetChildren();
        }

        protected FinancialPatientReturn.ChildFinancialPatientReturnCollection _FinancialPatientReturn = null;
    /// <summary>
    /// Child collection for İade Nedeni
    /// </summary>
        public FinancialPatientReturn.ChildFinancialPatientReturnCollection FinancialPatientReturn
        {
            get
            {
                if (_FinancialPatientReturn == null)
                    CreateFinancialPatientReturnCollection();
                return _FinancialPatientReturn;
            }
        }

        protected FinancialReturnReasonDefinition(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected FinancialReturnReasonDefinition(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected FinancialReturnReasonDefinition(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected FinancialReturnReasonDefinition(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected FinancialReturnReasonDefinition(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "FINANCIALRETURNREASONDEFINITION", dataRow) { }
        protected FinancialReturnReasonDefinition(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "FINANCIALRETURNREASONDEFINITION", dataRow, isImported) { }
        protected FinancialReturnReasonDefinition(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public FinancialReturnReasonDefinition(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public FinancialReturnReasonDefinition() : base() { }

    }
}