
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="ForcesCommand")] 

    /// <summary>
    /// Kuvvet
    /// </summary>
    public  partial class ForcesCommand : TerminologyManagerDef
    {
        public class ForcesCommandList : TTObjectCollection<ForcesCommand> { }
                    
        public class ChildForcesCommandCollection : TTObject.TTChildObjectCollection<ForcesCommand>
        {
            public ChildForcesCommandCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildForcesCommandCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class OLAP_ForcesCommand_Class : TTReportNqlObject 
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["FORCESCOMMAND"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public OLAP_ForcesCommand_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public OLAP_ForcesCommand_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected OLAP_ForcesCommand_Class() : base() { }
        }

        [Serializable] 

        public partial class GetForcesCommandNQL_Class : TTReportNqlObject 
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["FORCESCOMMAND"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public long? Code
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["CODE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["FORCESCOMMAND"].AllPropertyDefs["CODE"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public string ExternalCode
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["EXTERNALCODE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["FORCESCOMMAND"].AllPropertyDefs["EXTERNALCODE"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public long? Code1
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["CODE1"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["FORCESCOMMAND"].AllPropertyDefs["CODE"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public bool? Active
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ACTIVE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["FORCESCOMMAND"].AllPropertyDefs["ACTIVE"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public GetForcesCommandNQL_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetForcesCommandNQL_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetForcesCommandNQL_Class() : base() { }
        }

        public static BindingList<ForcesCommand> GetForcesCommandByLastUpdateDate(TTObjectContext objectContext, DateTime STARTDATE, DateTime ENDDATE)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["FORCESCOMMAND"].QueryDefs["GetForcesCommandByLastUpdateDate"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);

            return ((ITTQuery)objectContext).QueryObjects<ForcesCommand>(queryDef, paramList);
        }

        public static BindingList<ForcesCommand.OLAP_ForcesCommand_Class> OLAP_ForcesCommand(PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["FORCESCOMMAND"].QueryDefs["OLAP_ForcesCommand"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<ForcesCommand.OLAP_ForcesCommand_Class>(queryDef, paramList, pi);
        }

        public static BindingList<ForcesCommand.OLAP_ForcesCommand_Class> OLAP_ForcesCommand(TTObjectContext objectContext, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["FORCESCOMMAND"].QueryDefs["OLAP_ForcesCommand"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<ForcesCommand.OLAP_ForcesCommand_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<ForcesCommand> GetForcesCommandByExternalCode(TTObjectContext objectContext, string EXTERNALCODE)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["FORCESCOMMAND"].QueryDefs["GetForcesCommandByExternalCode"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("EXTERNALCODE", EXTERNALCODE);

            return ((ITTQuery)objectContext).QueryObjects<ForcesCommand>(queryDef, paramList);
        }

        public static BindingList<ForcesCommand.GetForcesCommandNQL_Class> GetForcesCommandNQL(string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["FORCESCOMMAND"].QueryDefs["GetForcesCommandNQL"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<ForcesCommand.GetForcesCommandNQL_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<ForcesCommand.GetForcesCommandNQL_Class> GetForcesCommandNQL(TTObjectContext objectContext, string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["FORCESCOMMAND"].QueryDefs["GetForcesCommandNQL"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<ForcesCommand.GetForcesCommandNQL_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

    /// <summary>
    /// Akıllı Kart Kuvvet Kodu
    /// </summary>
        public long? Code
        {
            get { return (long?)this["CODE"]; }
            set { this["CODE"] = value; }
        }

    /// <summary>
    /// Aktif
    /// </summary>
        public bool? Active
        {
            get { return (bool?)this["ACTIVE"]; }
            set { this["ACTIVE"] = value; }
        }

    /// <summary>
    /// Akıllı Kart Kılavuz Kodu
    /// </summary>
        public string ExternalCode
        {
            get { return (string)this["EXTERNALCODE"]; }
            set { this["EXTERNALCODE"] = value; }
        }

    /// <summary>
    /// KısaAdı
    /// </summary>
        public string Qref
        {
            get { return (string)this["QREF"]; }
            set { this["QREF"] = value; }
        }

    /// <summary>
    /// Adı
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

        protected ForcesCommand(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected ForcesCommand(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected ForcesCommand(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected ForcesCommand(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected ForcesCommand(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "FORCESCOMMAND", dataRow) { }
        protected ForcesCommand(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "FORCESCOMMAND", dataRow, isImported) { }
        public ForcesCommand(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public ForcesCommand(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public ForcesCommand() : base() { }

    }
}