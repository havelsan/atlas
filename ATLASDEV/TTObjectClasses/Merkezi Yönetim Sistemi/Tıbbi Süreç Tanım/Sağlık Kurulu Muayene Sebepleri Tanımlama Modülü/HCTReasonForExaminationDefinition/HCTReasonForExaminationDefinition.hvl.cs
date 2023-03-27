
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="HCTReasonForExaminationDefinition")] 

    /// <summary>
    /// Sağlık Kurulu Üç İmza Muayene Sebepleri
    /// </summary>
    public  partial class HCTReasonForExaminationDefinition : TerminologyManagerDef
    {
        public class HCTReasonForExaminationDefinitionList : TTObjectCollection<HCTReasonForExaminationDefinition> { }
                    
        public class ChildHCTReasonForExaminationDefinitionCollection : TTObject.TTChildObjectCollection<HCTReasonForExaminationDefinition>
        {
            public ChildHCTReasonForExaminationDefinitionCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildHCTReasonForExaminationDefinitionCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetHCTRFExaminationDefinition_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public string ExaminationReason
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["EXAMINATIONREASON"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["HCTREASONFOREXAMINATIONDEFINITION"].AllPropertyDefs["EXAMINATIONREASON"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public HCThreeSpecialistReportTypeEnum? ReportType
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["REPORTTYPE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["HCTREASONFOREXAMINATIONDEFINITION"].AllPropertyDefs["REPORTTYPE"].DataType;
                    return (HCThreeSpecialistReportTypeEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public HCTSpecialistCountEnum? SpecialistCount
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["SPECIALISTCOUNT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["HCTREASONFOREXAMINATIONDEFINITION"].AllPropertyDefs["SPECIALISTCOUNT"].DataType;
                    return (HCTSpecialistCountEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public GetHCTRFExaminationDefinition_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetHCTRFExaminationDefinition_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetHCTRFExaminationDefinition_Class() : base() { }
        }

        public static BindingList<HCTReasonForExaminationDefinition.GetHCTRFExaminationDefinition_Class> GetHCTRFExaminationDefinition(string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["HCTREASONFOREXAMINATIONDEFINITION"].QueryDefs["GetHCTRFExaminationDefinition"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<HCTReasonForExaminationDefinition.GetHCTRFExaminationDefinition_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<HCTReasonForExaminationDefinition.GetHCTRFExaminationDefinition_Class> GetHCTRFExaminationDefinition(TTObjectContext objectContext, string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["HCTREASONFOREXAMINATIONDEFINITION"].QueryDefs["GetHCTRFExaminationDefinition"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<HCTReasonForExaminationDefinition.GetHCTRFExaminationDefinition_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<HCTReasonForExaminationDefinition> GetHCTReasnForExamDefByLastUpdateDate(TTObjectContext objectContext, DateTime STARTDATE, DateTime ENDDATE)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["HCTREASONFOREXAMINATIONDEFINITION"].QueryDefs["GetHCTReasnForExamDefByLastUpdateDate"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);

            return ((ITTQuery)objectContext).QueryObjects<HCTReasonForExaminationDefinition>(queryDef, paramList);
        }

    /// <summary>
    /// Muayene Sebebi
    /// </summary>
        public string ExaminationReason
        {
            get { return (string)this["EXAMINATIONREASON"]; }
            set { this["EXAMINATIONREASON"] = value; }
        }

    /// <summary>
    /// Uzman Sayısı
    /// </summary>
        public HCTSpecialistCountEnum? SpecialistCount
        {
            get { return (HCTSpecialistCountEnum?)(int?)this["SPECIALISTCOUNT"]; }
            set { this["SPECIALISTCOUNT"] = value; }
        }

    /// <summary>
    /// Rapor Türü
    /// </summary>
        public HCThreeSpecialistReportTypeEnum? ReportType
        {
            get { return (HCThreeSpecialistReportTypeEnum?)(int?)this["REPORTTYPE"]; }
            set { this["REPORTTYPE"] = value; }
        }

        protected HCTReasonForExaminationDefinition(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected HCTReasonForExaminationDefinition(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected HCTReasonForExaminationDefinition(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected HCTReasonForExaminationDefinition(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected HCTReasonForExaminationDefinition(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "HCTREASONFOREXAMINATIONDEFINITION", dataRow) { }
        protected HCTReasonForExaminationDefinition(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "HCTREASONFOREXAMINATIONDEFINITION", dataRow, isImported) { }
        public HCTReasonForExaminationDefinition(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public HCTReasonForExaminationDefinition(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public HCTReasonForExaminationDefinition() : base() { }

    }
}