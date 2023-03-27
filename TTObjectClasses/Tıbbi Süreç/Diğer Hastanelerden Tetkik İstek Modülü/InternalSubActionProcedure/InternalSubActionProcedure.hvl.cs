
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="InternalSubActionProcedure")] 

    /// <summary>
    /// Diğer XXXXXXlerden Tetkik
    /// </summary>
    public  partial class InternalSubActionProcedure : SubActionProcedure
    {
        public class InternalSubActionProcedureList : TTObjectCollection<InternalSubActionProcedure> { }
                    
        public class ChildInternalSubActionProcedureCollection : TTObject.TTChildObjectCollection<InternalSubActionProcedure>
        {
            public ChildInternalSubActionProcedureCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildInternalSubActionProcedureCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetInternalSubActionProcedures_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public string Testname
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["TESTNAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PROCEDUREDEFINITION"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public GetInternalSubActionProcedures_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetInternalSubActionProcedures_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetInternalSubActionProcedures_Class() : base() { }
        }

        new public static class States
        {
            public static Guid New { get { return new Guid("1c28a828-4470-46a5-af69-701b5322df1f"); } }
            public static Guid Completed { get { return new Guid("35536bbc-e567-46c8-be88-3bc9d65bfd5f"); } }
            public static Guid Cancelled { get { return new Guid("d16bf872-a7d1-476c-806d-92fd1852dccc"); } }
        }

        public static BindingList<InternalSubActionProcedure.GetInternalSubActionProcedures_Class> GetInternalSubActionProcedures(string INTERNALPROCEDURE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["INTERNALSUBACTIONPROCEDURE"].QueryDefs["GetInternalSubActionProcedures"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("INTERNALPROCEDURE", INTERNALPROCEDURE);

            return TTReportNqlObject.QueryObjects<InternalSubActionProcedure.GetInternalSubActionProcedures_Class>(queryDef, paramList, pi);
        }

        public static BindingList<InternalSubActionProcedure.GetInternalSubActionProcedures_Class> GetInternalSubActionProcedures(TTObjectContext objectContext, string INTERNALPROCEDURE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["INTERNALSUBACTIONPROCEDURE"].QueryDefs["GetInternalSubActionProcedures"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("INTERNALPROCEDURE", INTERNALPROCEDURE);

            return TTReportNqlObject.QueryObjects<InternalSubActionProcedure.GetInternalSubActionProcedures_Class>(objectContext, queryDef, paramList, pi);
        }

        public ResOtherHospital OtherHospital
        {
            get { return (ResOtherHospital)((ITTObject)this).GetParent("OTHERHOSPITAL"); }
            set { this["OTHERHOSPITAL"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public InternalProcedureRequest InternalProcedureRequest
        {
            get 
            {   
                if (EpisodeAction is InternalProcedureRequest)
                    return (InternalProcedureRequest)EpisodeAction; 
                return null;
            }            
            set { EpisodeAction = value; }
        }

        protected InternalSubActionProcedure(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected InternalSubActionProcedure(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected InternalSubActionProcedure(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected InternalSubActionProcedure(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected InternalSubActionProcedure(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "INTERNALSUBACTIONPROCEDURE", dataRow) { }
        protected InternalSubActionProcedure(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "INTERNALSUBACTIONPROCEDURE", dataRow, isImported) { }
        public InternalSubActionProcedure(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public InternalSubActionProcedure(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public InternalSubActionProcedure() : base() { }

    }
}