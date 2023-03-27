
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="DrugDrugInteraction")] 

    /// <summary>
    /// İlaç - İlaç Etkileşimi
    /// </summary>
    public  partial class DrugDrugInteraction : TTObject
    {
        public class DrugDrugInteractionList : TTObjectCollection<DrugDrugInteraction> { }
                    
        public class ChildDrugDrugInteractionCollection : TTObject.TTChildObjectCollection<DrugDrugInteraction>
        {
            public ChildDrugDrugInteractionCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildDrugDrugInteractionCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class DrugDrugIntegrationRQ_Class : TTReportNqlObject 
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

            public string Message
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MESSAGE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DRUGDRUGINTERACTION"].AllPropertyDefs["MESSAGE"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public InteractionLevelTypeEnum? InteractionLevelType
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["INTERACTIONLEVELTYPE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DRUGDRUGINTERACTION"].AllPropertyDefs["INTERACTIONLEVELTYPE"].DataType;
                    return (InteractionLevelTypeEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public DrugDrugIntegrationRQ_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public DrugDrugIntegrationRQ_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected DrugDrugIntegrationRQ_Class() : base() { }
        }

        public static BindingList<DrugDrugInteraction.DrugDrugIntegrationRQ_Class> DrugDrugIntegrationRQ(string INTERACTIONDRUG, string DRUGDEFINITON, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["DRUGDRUGINTERACTION"].QueryDefs["DrugDrugIntegrationRQ"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("INTERACTIONDRUG", INTERACTIONDRUG);
            paramList.Add("DRUGDEFINITON", DRUGDEFINITON);

            return TTReportNqlObject.QueryObjects<DrugDrugInteraction.DrugDrugIntegrationRQ_Class>(queryDef, paramList, pi);
        }

        public static BindingList<DrugDrugInteraction.DrugDrugIntegrationRQ_Class> DrugDrugIntegrationRQ(TTObjectContext objectContext, string INTERACTIONDRUG, string DRUGDEFINITON, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["DRUGDRUGINTERACTION"].QueryDefs["DrugDrugIntegrationRQ"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("INTERACTIONDRUG", INTERACTIONDRUG);
            paramList.Add("DRUGDEFINITON", DRUGDEFINITON);

            return TTReportNqlObject.QueryObjects<DrugDrugInteraction.DrugDrugIntegrationRQ_Class>(objectContext, queryDef, paramList, pi);
        }

    /// <summary>
    /// Uyarı Mesajı
    /// </summary>
        public string Message
        {
            get { return (string)this["MESSAGE"]; }
            set { this["MESSAGE"] = value; }
        }

    /// <summary>
    /// Etkileşim Seviyesi
    /// </summary>
        public InteractionLevelTypeEnum? InteractionLevelType
        {
            get { return (InteractionLevelTypeEnum?)(int?)this["INTERACTIONLEVELTYPE"]; }
            set { this["INTERACTIONLEVELTYPE"] = value; }
        }

        public DrugDefinition InteractionDrug
        {
            get { return (DrugDefinition)((ITTObject)this).GetParent("INTERACTIONDRUG"); }
            set { this["INTERACTIONDRUG"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public DrugDefinition DrugDefinition
        {
            get { return (DrugDefinition)((ITTObject)this).GetParent("DRUGDEFINITION"); }
            set { this["DRUGDEFINITION"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected DrugDrugInteraction(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected DrugDrugInteraction(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected DrugDrugInteraction(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected DrugDrugInteraction(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected DrugDrugInteraction(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "DRUGDRUGINTERACTION", dataRow) { }
        protected DrugDrugInteraction(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "DRUGDRUGINTERACTION", dataRow, isImported) { }
        public DrugDrugInteraction(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public DrugDrugInteraction(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public DrugDrugInteraction() : base() { }

    }
}