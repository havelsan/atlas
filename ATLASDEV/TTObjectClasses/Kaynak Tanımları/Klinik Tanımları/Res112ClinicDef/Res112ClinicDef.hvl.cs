
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="Res112ClinicDef")] 

    /// <summary>
    /// 112 Klinik Tanımları
    /// </summary>
    public  partial class Res112ClinicDef : TerminologyManagerDef
    {
        public class Res112ClinicDefList : TTObjectCollection<Res112ClinicDef> { }
                    
        public class ChildRes112ClinicDefCollection : TTObject.TTChildObjectCollection<Res112ClinicDef>
        {
            public ChildRes112ClinicDefCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildRes112ClinicDefCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class Get112ClinikDef_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public string Code
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["CODE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RES112CLINICDEF"].AllPropertyDefs["CODE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RES112CLINICDEF"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public Get112ClinikDef_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public Get112ClinikDef_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected Get112ClinikDef_Class() : base() { }
        }

        public static BindingList<Res112ClinicDef.Get112ClinikDef_Class> Get112ClinikDef(string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["RES112CLINICDEF"].QueryDefs["Get112ClinikDef"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<Res112ClinicDef.Get112ClinikDef_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<Res112ClinicDef.Get112ClinikDef_Class> Get112ClinikDef(TTObjectContext objectContext, string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["RES112CLINICDEF"].QueryDefs["Get112ClinikDef"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<Res112ClinicDef.Get112ClinikDef_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

    /// <summary>
    /// Kod
    /// </summary>
        public string Code
        {
            get { return (string)this["CODE"]; }
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

        protected Res112ClinicDef(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected Res112ClinicDef(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected Res112ClinicDef(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected Res112ClinicDef(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected Res112ClinicDef(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "RES112CLINICDEF", dataRow) { }
        protected Res112ClinicDef(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "RES112CLINICDEF", dataRow, isImported) { }
        protected Res112ClinicDef(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public Res112ClinicDef(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public Res112ClinicDef() : base() { }

    }
}