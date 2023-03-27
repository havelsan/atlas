
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="ResSurgeryDesk")] 

    /// <summary>
    /// Ameliyat Masası
    /// </summary>
    public  partial class ResSurgeryDesk : ResSection
    {
        public class ResSurgeryDeskList : TTObjectCollection<ResSurgeryDesk> { }
                    
        public class ChildResSurgeryDeskCollection : TTObject.TTChildObjectCollection<ResSurgeryDesk>
        {
            public ChildResSurgeryDeskCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildResSurgeryDeskCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetSurgeryDeskDefinition_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public string Qref
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["QREF"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESSURGERYDESK"].AllPropertyDefs["QREF"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESSURGERYDESK"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Surgeryroomname
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["SURGERYROOMNAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESSURGERYROOM"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public GetSurgeryDeskDefinition_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetSurgeryDeskDefinition_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetSurgeryDeskDefinition_Class() : base() { }
        }

        public static BindingList<ResSurgeryDesk.GetSurgeryDeskDefinition_Class> GetSurgeryDeskDefinition(string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["RESSURGERYDESK"].QueryDefs["GetSurgeryDeskDefinition"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<ResSurgeryDesk.GetSurgeryDeskDefinition_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<ResSurgeryDesk.GetSurgeryDeskDefinition_Class> GetSurgeryDeskDefinition(TTObjectContext objectContext, string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["RESSURGERYDESK"].QueryDefs["GetSurgeryDeskDefinition"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<ResSurgeryDesk.GetSurgeryDeskDefinition_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<ResSurgeryDesk> GetActiveSurgeryDesks(TTObjectContext objectContext)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["RESSURGERYDESK"].QueryDefs["GetActiveSurgeryDesks"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return ((ITTQuery)objectContext).QueryObjects<ResSurgeryDesk>(queryDef, paramList);
        }

    /// <summary>
    /// Ameliyat Odası
    /// </summary>
        public ResSurgeryRoom SurgeryRoom
        {
            get { return (ResSurgeryRoom)((ITTObject)this).GetParent("SURGERYROOM"); }
            set { this["SURGERYROOM"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected ResSurgeryDesk(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected ResSurgeryDesk(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected ResSurgeryDesk(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected ResSurgeryDesk(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected ResSurgeryDesk(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "RESSURGERYDESK", dataRow) { }
        protected ResSurgeryDesk(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "RESSURGERYDESK", dataRow, isImported) { }
        protected ResSurgeryDesk(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public ResSurgeryDesk(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public ResSurgeryDesk() : base() { }

    }
}