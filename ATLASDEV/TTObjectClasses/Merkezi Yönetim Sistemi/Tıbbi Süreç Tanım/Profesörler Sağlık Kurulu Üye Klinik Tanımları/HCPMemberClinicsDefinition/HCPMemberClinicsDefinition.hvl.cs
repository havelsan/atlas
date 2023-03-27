
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="HCPMemberClinicsDefinition")] 

    /// <summary>
    /// PSK Üye Klinik Tanımları
    /// </summary>
    public  partial class HCPMemberClinicsDefinition : TTDefinitionSet
    {
        public class HCPMemberClinicsDefinitionList : TTObjectCollection<HCPMemberClinicsDefinition> { }
                    
        public class ChildHCPMemberClinicsDefinitionCollection : TTObject.TTChildObjectCollection<HCPMemberClinicsDefinition>
        {
            public ChildHCPMemberClinicsDefinitionCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildHCPMemberClinicsDefinitionCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetHCPMemberClinicsDefinition_Class : TTReportNqlObject 
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["HCPMEMBERCLINICSDEFINITION"].AllPropertyDefs["CODE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESSECTION"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public GetHCPMemberClinicsDefinition_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetHCPMemberClinicsDefinition_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetHCPMemberClinicsDefinition_Class() : base() { }
        }

        public static BindingList<HCPMemberClinicsDefinition.GetHCPMemberClinicsDefinition_Class> GetHCPMemberClinicsDefinition(string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["HCPMEMBERCLINICSDEFINITION"].QueryDefs["GetHCPMemberClinicsDefinition"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<HCPMemberClinicsDefinition.GetHCPMemberClinicsDefinition_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<HCPMemberClinicsDefinition.GetHCPMemberClinicsDefinition_Class> GetHCPMemberClinicsDefinition(TTObjectContext objectContext, string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["HCPMEMBERCLINICSDEFINITION"].QueryDefs["GetHCPMemberClinicsDefinition"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<HCPMemberClinicsDefinition.GetHCPMemberClinicsDefinition_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<HCPMemberClinicsDefinition> GetAllMemberClinics(TTObjectContext objectContext)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["HCPMEMBERCLINICSDEFINITION"].QueryDefs["GetAllMemberClinics"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return ((ITTQuery)objectContext).QueryObjects<HCPMemberClinicsDefinition>(queryDef, paramList);
        }

    /// <summary>
    /// Kodu
    /// </summary>
        public TTSequence Code
        {
            get { return GetSequence("CODE"); }
        }

        public HealthCommitteeOfProfessors HealthCommitteeOfProfessors
        {
            get { return (HealthCommitteeOfProfessors)((ITTObject)this).GetParent("HEALTHCOMMITTEEOFPROFESSORS"); }
            set { this["HEALTHCOMMITTEEOFPROFESSORS"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public ResSection MemberClinic
        {
            get { return (ResSection)((ITTObject)this).GetParent("MEMBERCLINIC"); }
            set { this["MEMBERCLINIC"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected HCPMemberClinicsDefinition(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected HCPMemberClinicsDefinition(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected HCPMemberClinicsDefinition(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected HCPMemberClinicsDefinition(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected HCPMemberClinicsDefinition(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "HCPMEMBERCLINICSDEFINITION", dataRow) { }
        protected HCPMemberClinicsDefinition(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "HCPMEMBERCLINICSDEFINITION", dataRow, isImported) { }
        public HCPMemberClinicsDefinition(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public HCPMemberClinicsDefinition(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public HCPMemberClinicsDefinition() : base() { }

    }
}