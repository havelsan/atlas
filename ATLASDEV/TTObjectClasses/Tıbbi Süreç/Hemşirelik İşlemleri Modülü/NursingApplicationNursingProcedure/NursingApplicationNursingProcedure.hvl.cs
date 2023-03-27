
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="NursingApplicationNursingProcedure")] 

    public  partial class NursingApplicationNursingProcedure : BaseNursingProcedure
    {
        public class NursingApplicationNursingProcedureList : TTObjectCollection<NursingApplicationNursingProcedure> { }
                    
        public class ChildNursingApplicationNursingProcedureCollection : TTObject.TTChildObjectCollection<NursingApplicationNursingProcedure>
        {
            public ChildNursingApplicationNursingProcedureCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildNursingApplicationNursingProcedureCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetByNursingApplicationNursingProcedure_Class : TTReportNqlObject 
        {
            public DateTime? ActionDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ACTIONDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["NURSINGAPPLICATIONNURSINGPROCEDURE"].AllPropertyDefs["ACTIONDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public Guid? ProcedureObject
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["PROCEDUREOBJECT"]);
                }
            }

            public string Result
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["RESULT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["NURSINGAPPLICATIONNURSINGPROCEDURE"].AllPropertyDefs["RESULT"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Note
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["NOTE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["NURSINGAPPLICATIONNURSINGPROCEDURE"].AllPropertyDefs["NOTE"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public GetByNursingApplicationNursingProcedure_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetByNursingApplicationNursingProcedure_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetByNursingApplicationNursingProcedure_Class() : base() { }
        }

        new public static class States
        {
            public static Guid New { get { return new Guid("1c28a828-4470-46a5-af69-701b5322df1f"); } }
            public static Guid Completed { get { return new Guid("35536bbc-e567-46c8-be88-3bc9d65bfd5f"); } }
            public static Guid Cancelled { get { return new Guid("d16bf872-a7d1-476c-806d-92fd1852dccc"); } }
        }

        public static BindingList<NursingApplicationNursingProcedure.GetByNursingApplicationNursingProcedure_Class> GetByNursingApplicationNursingProcedure(Guid TTOBJECTID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["NURSINGAPPLICATIONNURSINGPROCEDURE"].QueryDefs["GetByNursingApplicationNursingProcedure"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("TTOBJECTID", TTOBJECTID);

            return TTReportNqlObject.QueryObjects<NursingApplicationNursingProcedure.GetByNursingApplicationNursingProcedure_Class>(queryDef, paramList, pi);
        }

        public static BindingList<NursingApplicationNursingProcedure.GetByNursingApplicationNursingProcedure_Class> GetByNursingApplicationNursingProcedure(TTObjectContext objectContext, Guid TTOBJECTID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["NURSINGAPPLICATIONNURSINGPROCEDURE"].QueryDefs["GetByNursingApplicationNursingProcedure"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("TTOBJECTID", TTOBJECTID);

            return TTReportNqlObject.QueryObjects<NursingApplicationNursingProcedure.GetByNursingApplicationNursingProcedure_Class>(objectContext, queryDef, paramList, pi);
        }

        public NursingApplication Nursingapplication
        {
            get 
            {   
                if (EpisodeAction is NursingApplication)
                    return (NursingApplication)EpisodeAction; 
                return null;
            }            
            set { EpisodeAction = value; }
        }

        protected NursingApplicationNursingProcedure(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected NursingApplicationNursingProcedure(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected NursingApplicationNursingProcedure(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected NursingApplicationNursingProcedure(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected NursingApplicationNursingProcedure(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "NURSINGAPPLICATIONNURSINGPROCEDURE", dataRow) { }
        protected NursingApplicationNursingProcedure(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "NURSINGAPPLICATIONNURSINGPROCEDURE", dataRow, isImported) { }
        public NursingApplicationNursingProcedure(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public NursingApplicationNursingProcedure(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public NursingApplicationNursingProcedure() : base() { }

    }
}