
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="ProcurementUnitDef")] 

    public  partial class ProcurementUnitDef : TerminologyManagerDef
    {
        public class ProcurementUnitDefList : TTObjectCollection<ProcurementUnitDef> { }
                    
        public class ChildProcurementUnitDefCollection : TTObject.TTChildObjectCollection<ProcurementUnitDef>
        {
            public ChildProcurementUnitDefCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildProcurementUnitDefCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class ProcurementUnitDefFormNQL_Class : TTReportNqlObject 
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PROCUREMENTUNITDEF"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Militaryunitname
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MILITARYUNITNAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MILITARYUNIT"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public ProcurementUnitDefFormNQL_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public ProcurementUnitDefFormNQL_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected ProcurementUnitDefFormNQL_Class() : base() { }
        }

        public static BindingList<ProcurementUnitDef.ProcurementUnitDefFormNQL_Class> ProcurementUnitDefFormNQL(string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PROCUREMENTUNITDEF"].QueryDefs["ProcurementUnitDefFormNQL"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<ProcurementUnitDef.ProcurementUnitDefFormNQL_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<ProcurementUnitDef.ProcurementUnitDefFormNQL_Class> ProcurementUnitDefFormNQL(TTObjectContext objectContext, string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PROCUREMENTUNITDEF"].QueryDefs["ProcurementUnitDefFormNQL"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<ProcurementUnitDef.ProcurementUnitDefFormNQL_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<ProcurementUnitDef> GetProcurementUnitDefByLastUpdateDate(TTObjectContext objectContext, DateTime STARTDATE, DateTime ENDDATE)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PROCUREMENTUNITDEF"].QueryDefs["GetProcurementUnitDefByLastUpdateDate"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);

            return ((ITTQuery)objectContext).QueryObjects<ProcurementUnitDef>(queryDef, paramList);
        }

    /// <summary>
    /// Faks
    /// </summary>
        public string Fax
        {
            get { return (string)this["FAX"]; }
            set { this["FAX"] = value; }
        }

    /// <summary>
    /// Telefon
    /// </summary>
        public string Telephone
        {
            get { return (string)this["TELEPHONE"]; }
            set { this["TELEPHONE"] = value; }
        }

    /// <summary>
    /// Adres
    /// </summary>
        public string Address
        {
            get { return (string)this["ADDRESS"]; }
            set { this["ADDRESS"] = value; }
        }

    /// <summary>
    /// E Mail
    /// </summary>
        public string eMail
        {
            get { return (string)this["EMAIL"]; }
            set { this["EMAIL"] = value; }
        }

    /// <summary>
    /// Tedarik Birimi Adı
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

        public MilitaryUnit MilitaryUnit
        {
            get { return (MilitaryUnit)((ITTObject)this).GetParent("MILITARYUNIT"); }
            set { this["MILITARYUNIT"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected ProcurementUnitDef(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected ProcurementUnitDef(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected ProcurementUnitDef(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected ProcurementUnitDef(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected ProcurementUnitDef(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "PROCUREMENTUNITDEF", dataRow) { }
        protected ProcurementUnitDef(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "PROCUREMENTUNITDEF", dataRow, isImported) { }
        public ProcurementUnitDef(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public ProcurementUnitDef(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public ProcurementUnitDef() : base() { }

    }
}