
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="MedicalComiteeDiagnosisGrid")] 

    /// <summary>
    /// Tanı
    /// </summary>
    public  partial class MedicalComiteeDiagnosisGrid : DiagnosisGrid
    {
        public class MedicalComiteeDiagnosisGridList : TTObjectCollection<MedicalComiteeDiagnosisGrid> { }
                    
        public class ChildMedicalComiteeDiagnosisGridCollection : TTObject.TTChildObjectCollection<MedicalComiteeDiagnosisGrid>
        {
            public ChildMedicalComiteeDiagnosisGridCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildMedicalComiteeDiagnosisGridCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetMCDiagnosisGridByEpisodeAction_Class : TTReportNqlObject 
        {
            public string Tanikodu
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["TANIKODU"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DIAGNOSISDEFINITION"].AllPropertyDefs["CODE"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Taniadi
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["TANIADI"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DIAGNOSISDEFINITION"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public GetMCDiagnosisGridByEpisodeAction_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetMCDiagnosisGridByEpisodeAction_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetMCDiagnosisGridByEpisodeAction_Class() : base() { }
        }

    /// <summary>
    /// MedicalComiteeDiagnosisGrid i EpisodeAction a göre get eder
    /// </summary>
        public static BindingList<MedicalComiteeDiagnosisGrid.GetMCDiagnosisGridByEpisodeAction_Class> GetMCDiagnosisGridByEpisodeAction(string EPISODEACTION, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["MEDICALCOMITEEDIAGNOSISGRID"].QueryDefs["GetMCDiagnosisGridByEpisodeAction"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("EPISODEACTION", EPISODEACTION);

            return TTReportNqlObject.QueryObjects<MedicalComiteeDiagnosisGrid.GetMCDiagnosisGridByEpisodeAction_Class>(queryDef, paramList, pi);
        }

    /// <summary>
    /// MedicalComiteeDiagnosisGrid i EpisodeAction a göre get eder
    /// </summary>
        public static BindingList<MedicalComiteeDiagnosisGrid.GetMCDiagnosisGridByEpisodeAction_Class> GetMCDiagnosisGridByEpisodeAction(TTObjectContext objectContext, string EPISODEACTION, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["MEDICALCOMITEEDIAGNOSISGRID"].QueryDefs["GetMCDiagnosisGridByEpisodeAction"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("EPISODEACTION", EPISODEACTION);

            return TTReportNqlObject.QueryObjects<MedicalComiteeDiagnosisGrid.GetMCDiagnosisGridByEpisodeAction_Class>(objectContext, queryDef, paramList, pi);
        }

        protected MedicalComiteeDiagnosisGrid(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected MedicalComiteeDiagnosisGrid(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected MedicalComiteeDiagnosisGrid(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected MedicalComiteeDiagnosisGrid(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected MedicalComiteeDiagnosisGrid(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "MEDICALCOMITEEDIAGNOSISGRID", dataRow) { }
        protected MedicalComiteeDiagnosisGrid(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "MEDICALCOMITEEDIAGNOSISGRID", dataRow, isImported) { }
        public MedicalComiteeDiagnosisGrid(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public MedicalComiteeDiagnosisGrid(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public MedicalComiteeDiagnosisGrid() : base() { }

    }
}