
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="PatientAndFamilyInstructionDefinition")] 

    public  partial class PatientAndFamilyInstructionDefinition : TerminologyManagerDef
    {
        public class PatientAndFamilyInstructionDefinitionList : TTObjectCollection<PatientAndFamilyInstructionDefinition> { }
                    
        public class ChildPatientAndFamilyInstructionDefinitionCollection : TTObject.TTChildObjectCollection<PatientAndFamilyInstructionDefinition>
        {
            public ChildPatientAndFamilyInstructionDefinitionCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildPatientAndFamilyInstructionDefinitionCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetPatientAndFamilyInstruction_Class : TTReportNqlObject 
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENTANDFAMILYINSTRUCTIONDEFINITION"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public GetPatientAndFamilyInstruction_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetPatientAndFamilyInstruction_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetPatientAndFamilyInstruction_Class() : base() { }
        }

        public static BindingList<PatientAndFamilyInstructionDefinition.GetPatientAndFamilyInstruction_Class> GetPatientAndFamilyInstruction(string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PATIENTANDFAMILYINSTRUCTIONDEFINITION"].QueryDefs["GetPatientAndFamilyInstruction"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<PatientAndFamilyInstructionDefinition.GetPatientAndFamilyInstruction_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<PatientAndFamilyInstructionDefinition.GetPatientAndFamilyInstruction_Class> GetPatientAndFamilyInstruction(TTObjectContext objectContext, string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PATIENTANDFAMILYINSTRUCTIONDEFINITION"].QueryDefs["GetPatientAndFamilyInstruction"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<PatientAndFamilyInstructionDefinition.GetPatientAndFamilyInstruction_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<PatientAndFamilyInstructionDefinition> GetPatientFamilyInstDefByLastUpdateDate(TTObjectContext objectContext, DateTime STARTDATE, DateTime ENDDATE)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PATIENTANDFAMILYINSTRUCTIONDEFINITION"].QueryDefs["GetPatientFamilyInstDefByLastUpdateDate"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);

            return ((ITTQuery)objectContext).QueryObjects<PatientAndFamilyInstructionDefinition>(queryDef, paramList);
        }

        public static BindingList<PatientAndFamilyInstructionDefinition> GetAllPatientFamilyInstDefList(TTObjectContext objectContext)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PATIENTANDFAMILYINSTRUCTIONDEFINITION"].QueryDefs["GetAllPatientFamilyInstDefList"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return ((ITTQuery)objectContext).QueryObjects<PatientAndFamilyInstructionDefinition>(queryDef, paramList);
        }

    /// <summary>
    /// Hasta ve Aile Eğitimi
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

        protected PatientAndFamilyInstructionDefinition(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected PatientAndFamilyInstructionDefinition(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected PatientAndFamilyInstructionDefinition(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected PatientAndFamilyInstructionDefinition(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected PatientAndFamilyInstructionDefinition(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "PATIENTANDFAMILYINSTRUCTIONDEFINITION", dataRow) { }
        protected PatientAndFamilyInstructionDefinition(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "PATIENTANDFAMILYINSTRUCTIONDEFINITION", dataRow, isImported) { }
        public PatientAndFamilyInstructionDefinition(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public PatientAndFamilyInstructionDefinition(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public PatientAndFamilyInstructionDefinition() : base() { }

    }
}