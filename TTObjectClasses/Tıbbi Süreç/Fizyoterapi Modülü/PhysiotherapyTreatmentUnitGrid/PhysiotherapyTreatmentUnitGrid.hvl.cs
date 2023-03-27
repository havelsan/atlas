
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="PhysiotherapyTreatmentUnitGrid")] 

    /// <summary>
    /// Fizyoterapi Tedavi Birimi
    /// </summary>
    public  partial class PhysiotherapyTreatmentUnitGrid : TTObject
    {
        public class PhysiotherapyTreatmentUnitGridList : TTObjectCollection<PhysiotherapyTreatmentUnitGrid> { }
                    
        public class ChildPhysiotherapyTreatmentUnitGridCollection : TTObject.TTChildObjectCollection<PhysiotherapyTreatmentUnitGrid>
        {
            public ChildPhysiotherapyTreatmentUnitGridCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildPhysiotherapyTreatmentUnitGridCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetTreatmentDiagnosisInfo_Class : TTReportNqlObject 
        {
            public Guid? Physiotherapydefinitionid
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["PHYSIOTHERAPYDEFINITIONID"]);
                }
            }

            public string Physiotherapydefinitionname
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PHYSIOTHERAPYDEFINITIONNAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PHYSIOTHERAPYDEFINITION"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public Guid? Treatmentdiagnosisunitid
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["TREATMENTDIAGNOSISUNITID"]);
                }
            }

            public string Treatmentdiagnosisunitname
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["TREATMENTDIAGNOSISUNITNAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESTREATMENTDIAGNOSISUNIT"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public GetTreatmentDiagnosisInfo_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetTreatmentDiagnosisInfo_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetTreatmentDiagnosisInfo_Class() : base() { }
        }

        public static BindingList<PhysiotherapyTreatmentUnitGrid.GetTreatmentDiagnosisInfo_Class> GetTreatmentDiagnosisInfo(PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PHYSIOTHERAPYTREATMENTUNITGRID"].QueryDefs["GetTreatmentDiagnosisInfo"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<PhysiotherapyTreatmentUnitGrid.GetTreatmentDiagnosisInfo_Class>(queryDef, paramList, pi);
        }

        public static BindingList<PhysiotherapyTreatmentUnitGrid.GetTreatmentDiagnosisInfo_Class> GetTreatmentDiagnosisInfo(TTObjectContext objectContext, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PHYSIOTHERAPYTREATMENTUNITGRID"].QueryDefs["GetTreatmentDiagnosisInfo"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<PhysiotherapyTreatmentUnitGrid.GetTreatmentDiagnosisInfo_Class>(objectContext, queryDef, paramList, pi);
        }

    /// <summary>
    /// Tanı Tedavi Üniteleri
    /// </summary>
        public PhysiotherapyDefinition PhysiotherapyDefinition
        {
            get { return (PhysiotherapyDefinition)((ITTObject)this).GetParent("PHYSIOTHERAPYDEFINITION"); }
            set { this["PHYSIOTHERAPYDEFINITION"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Tanı Tedavi Ünitesi
    /// </summary>
        public ResTreatmentDiagnosisUnit TreatmentDiagnosisUnit
        {
            get { return (ResTreatmentDiagnosisUnit)((ITTObject)this).GetParent("TREATMENTDIAGNOSISUNIT"); }
            set { this["TREATMENTDIAGNOSISUNIT"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected PhysiotherapyTreatmentUnitGrid(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected PhysiotherapyTreatmentUnitGrid(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected PhysiotherapyTreatmentUnitGrid(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected PhysiotherapyTreatmentUnitGrid(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected PhysiotherapyTreatmentUnitGrid(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "PHYSIOTHERAPYTREATMENTUNITGRID", dataRow) { }
        protected PhysiotherapyTreatmentUnitGrid(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "PHYSIOTHERAPYTREATMENTUNITGRID", dataRow, isImported) { }
        public PhysiotherapyTreatmentUnitGrid(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public PhysiotherapyTreatmentUnitGrid(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public PhysiotherapyTreatmentUnitGrid() : base() { }

    }
}