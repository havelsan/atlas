
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="ConfirmationUnitDefinition")] 

    /// <summary>
    /// Onay Makamı Tanımları 
    /// </summary>
    public  partial class ConfirmationUnitDefinition : TerminologyManagerDef
    {
        public class ConfirmationUnitDefinitionList : TTObjectCollection<ConfirmationUnitDefinition> { }
                    
        public class ChildConfirmationUnitDefinitionCollection : TTObject.TTChildObjectCollection<ConfirmationUnitDefinition>
        {
            public ChildConfirmationUnitDefinitionCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildConfirmationUnitDefinitionCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetConfirmationUnitDefinition_Class : TTReportNqlObject 
        {
            public string Code
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["CODE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["CONFIRMATIONUNITDEFINITION"].AllPropertyDefs["CODE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["CONFIRMATIONUNITDEFINITION"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public GetConfirmationUnitDefinition_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetConfirmationUnitDefinition_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetConfirmationUnitDefinition_Class() : base() { }
        }

    /// <summary>
    /// Onay Makamı Tanımılarını get eder
    /// </summary>
        public static BindingList<ConfirmationUnitDefinition.GetConfirmationUnitDefinition_Class> GetConfirmationUnitDefinition(string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["CONFIRMATIONUNITDEFINITION"].QueryDefs["GetConfirmationUnitDefinition"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<ConfirmationUnitDefinition.GetConfirmationUnitDefinition_Class>(queryDef, paramList, injectionSQL, pi);
        }

    /// <summary>
    /// Onay Makamı Tanımılarını get eder
    /// </summary>
        public static BindingList<ConfirmationUnitDefinition.GetConfirmationUnitDefinition_Class> GetConfirmationUnitDefinition(TTObjectContext objectContext, string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["CONFIRMATIONUNITDEFINITION"].QueryDefs["GetConfirmationUnitDefinition"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<ConfirmationUnitDefinition.GetConfirmationUnitDefinition_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<ConfirmationUnitDefinition> GetConfirmationUnitDefByLastUpdateDate(TTObjectContext objectContext, DateTime STARTDATE, DateTime ENDDATE)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["CONFIRMATIONUNITDEFINITION"].QueryDefs["GetConfirmationUnitDefByLastUpdateDate"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);

            return ((ITTQuery)objectContext).QueryObjects<ConfirmationUnitDefinition>(queryDef, paramList);
        }

    /// <summary>
    /// Kodu
    /// </summary>
        public string Code
        {
            get { return (string)this["CODE"]; }
            set { this["CODE"] = value; }
        }

    /// <summary>
    /// Adı
    /// </summary>
        public string Name
        {
            get { return (string)this["NAME"]; }
            set { this["NAME"] = value; }
        }

    /// <summary>
    /// No
    /// </summary>
        public long? ID
        {
            get { return (long?)this["ID"]; }
            set { this["ID"] = value; }
        }

    /// <summary>
    /// Aktif
    /// </summary>
        public bool? Active
        {
            get { return (bool?)this["ACTIVE"]; }
            set { this["ACTIVE"] = value; }
        }

        virtual protected void CreateSendingCheckedHealthComiteeReportCHCRGridCollection()
        {
            _SendingCheckedHealthComiteeReportCHCRGrid = new SendingCheckedHealthCommiteeReportCHCRGrid.ChildSendingCheckedHealthCommiteeReportCHCRGridCollection(this, new Guid("da5cadae-53f4-4247-9802-8223d7ab9a56"));
            ((ITTChildObjectCollection)_SendingCheckedHealthComiteeReportCHCRGrid).GetChildren();
        }

        protected SendingCheckedHealthCommiteeReportCHCRGrid.ChildSendingCheckedHealthCommiteeReportCHCRGridCollection _SendingCheckedHealthComiteeReportCHCRGrid = null;
    /// <summary>
    /// Child collection for Gönderilecek Makam
    /// </summary>
        public SendingCheckedHealthCommiteeReportCHCRGrid.ChildSendingCheckedHealthCommiteeReportCHCRGridCollection SendingCheckedHealthComiteeReportCHCRGrid
        {
            get
            {
                if (_SendingCheckedHealthComiteeReportCHCRGrid == null)
                    CreateSendingCheckedHealthComiteeReportCHCRGridCollection();
                return _SendingCheckedHealthComiteeReportCHCRGrid;
            }
        }

        protected ConfirmationUnitDefinition(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected ConfirmationUnitDefinition(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected ConfirmationUnitDefinition(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected ConfirmationUnitDefinition(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected ConfirmationUnitDefinition(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "CONFIRMATIONUNITDEFINITION", dataRow) { }
        protected ConfirmationUnitDefinition(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "CONFIRMATIONUNITDEFINITION", dataRow, isImported) { }
        protected ConfirmationUnitDefinition(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public ConfirmationUnitDefinition(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public ConfirmationUnitDefinition() : base() { }

    }
}