
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="HCMatterSliceAnectodeDefinition")] 

    public  partial class HCMatterSliceAnectodeDefinition : TerminologyManagerDef
    {
        public class HCMatterSliceAnectodeDefinitionList : TTObjectCollection<HCMatterSliceAnectodeDefinition> { }
                    
        public class ChildHCMatterSliceAnectodeDefinitionCollection : TTObject.TTChildObjectCollection<HCMatterSliceAnectodeDefinition>
        {
            public ChildHCMatterSliceAnectodeDefinitionCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildHCMatterSliceAnectodeDefinitionCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetHCMatterSliceAnectodeDefinition_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public int? Matter
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MATTER"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["HCMATTERSLICEANECTODEDEFINITION"].AllPropertyDefs["MATTER"].DataType;
                    return (int?)dataType.ConvertValue(val);
                }
            }

            public SliceEnum? Slice
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["SLICE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["HCMATTERSLICEANECTODEDEFINITION"].AllPropertyDefs["SLICE"].DataType;
                    return (SliceEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public int? Anectode
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ANECTODE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["HCMATTERSLICEANECTODEDEFINITION"].AllPropertyDefs["ANECTODE"].DataType;
                    return (int?)dataType.ConvertValue(val);
                }
            }

            public GetHCMatterSliceAnectodeDefinition_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetHCMatterSliceAnectodeDefinition_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetHCMatterSliceAnectodeDefinition_Class() : base() { }
        }

        [Serializable] 

        public partial class OLAP_GetHCMatterSliceAnectodeDefinition_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public int? Matter
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MATTER"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["HCMATTERSLICEANECTODEDEFINITION"].AllPropertyDefs["MATTER"].DataType;
                    return (int?)dataType.ConvertValue(val);
                }
            }

            public SliceEnum? Slice
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["SLICE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["HCMATTERSLICEANECTODEDEFINITION"].AllPropertyDefs["SLICE"].DataType;
                    return (SliceEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public int? Anectode
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ANECTODE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["HCMATTERSLICEANECTODEDEFINITION"].AllPropertyDefs["ANECTODE"].DataType;
                    return (int?)dataType.ConvertValue(val);
                }
            }

            public string OfferOfDecision
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["OFFEROFDECISION"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["HCMATTERSLICEANECTODEDEFINITION"].AllPropertyDefs["OFFEROFDECISION"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public OLAP_GetHCMatterSliceAnectodeDefinition_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public OLAP_GetHCMatterSliceAnectodeDefinition_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected OLAP_GetHCMatterSliceAnectodeDefinition_Class() : base() { }
        }

        public static BindingList<HCMatterSliceAnectodeDefinition.GetHCMatterSliceAnectodeDefinition_Class> GetHCMatterSliceAnectodeDefinition(string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["HCMATTERSLICEANECTODEDEFINITION"].QueryDefs["GetHCMatterSliceAnectodeDefinition"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<HCMatterSliceAnectodeDefinition.GetHCMatterSliceAnectodeDefinition_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<HCMatterSliceAnectodeDefinition.GetHCMatterSliceAnectodeDefinition_Class> GetHCMatterSliceAnectodeDefinition(TTObjectContext objectContext, string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["HCMATTERSLICEANECTODEDEFINITION"].QueryDefs["GetHCMatterSliceAnectodeDefinition"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<HCMatterSliceAnectodeDefinition.GetHCMatterSliceAnectodeDefinition_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<HCMatterSliceAnectodeDefinition> GetHCMatterSliceAnectefByLastUpdateDate(TTObjectContext objectContext, DateTime STARTDATE, DateTime ENDDATE)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["HCMATTERSLICEANECTODEDEFINITION"].QueryDefs["GetHCMatterSliceAnectefByLastUpdateDate"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);

            return ((ITTQuery)objectContext).QueryObjects<HCMatterSliceAnectodeDefinition>(queryDef, paramList);
        }

        public static BindingList<HCMatterSliceAnectodeDefinition.OLAP_GetHCMatterSliceAnectodeDefinition_Class> OLAP_GetHCMatterSliceAnectodeDefinition(PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["HCMATTERSLICEANECTODEDEFINITION"].QueryDefs["OLAP_GetHCMatterSliceAnectodeDefinition"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<HCMatterSliceAnectodeDefinition.OLAP_GetHCMatterSliceAnectodeDefinition_Class>(queryDef, paramList, pi);
        }

        public static BindingList<HCMatterSliceAnectodeDefinition.OLAP_GetHCMatterSliceAnectodeDefinition_Class> OLAP_GetHCMatterSliceAnectodeDefinition(TTObjectContext objectContext, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["HCMATTERSLICEANECTODEDEFINITION"].QueryDefs["OLAP_GetHCMatterSliceAnectodeDefinition"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<HCMatterSliceAnectodeDefinition.OLAP_GetHCMatterSliceAnectodeDefinition_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<HCMatterSliceAnectodeDefinition> GetHCDecisionByMatterSliceAnectode(TTObjectContext objectContext, int PARAMMATTER, SliceEnum PARAMSLICE, int PARAMANECTODE)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["HCMATTERSLICEANECTODEDEFINITION"].QueryDefs["GetHCDecisionByMatterSliceAnectode"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("PARAMMATTER", PARAMMATTER);
            paramList.Add("PARAMSLICE", (int)PARAMSLICE);
            paramList.Add("PARAMANECTODE", PARAMANECTODE);

            return ((ITTQuery)objectContext).QueryObjects<HCMatterSliceAnectodeDefinition>(queryDef, paramList);
        }

    /// <summary>
    /// Dilim
    /// </summary>
        public SliceEnum? Slice
        {
            get { return (SliceEnum?)(int?)this["SLICE"]; }
            set { this["SLICE"] = value; }
        }

    /// <summary>
    /// Madde
    /// </summary>
        public int? Matter
        {
            get { return (int?)this["MATTER"]; }
            set { this["MATTER"] = value; }
        }

    /// <summary>
    /// Karar Teklifi
    /// </summary>
        public string OfferOfDecision
        {
            get { return (string)this["OFFEROFDECISION"]; }
            set { this["OFFEROFDECISION"] = value; }
        }

    /// <summary>
    /// Fıkra
    /// </summary>
        public int? Anectode
        {
            get { return (int?)this["ANECTODE"]; }
            set { this["ANECTODE"] = value; }
        }

    /// <summary>
    /// Fikir Ağırlıklı Çalışan
    /// </summary>
        public bool? MindWeightedEmployee
        {
            get { return (bool?)this["MINDWEIGHTEDEMPLOYEE"]; }
            set { this["MINDWEIGHTEDEMPLOYEE"] = value; }
        }

    /// <summary>
    /// Beden Ağırlıklı Çalışan
    /// </summary>
        public bool? BodyWeightedEmployee
        {
            get { return (bool?)this["BODYWEIGHTEDEMPLOYEE"]; }
            set { this["BODYWEIGHTEDEMPLOYEE"] = value; }
        }

    /// <summary>
    /// Kuvvet
    /// </summary>
        public ForcesCommand Force
        {
            get { return (ForcesCommand)((ITTObject)this).GetParent("FORCE"); }
            set { this["FORCE"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Rütbe
    /// </summary>
        public RankDefinitions Rank
        {
            get { return (RankDefinitions)((ITTObject)this).GetParent("RANK"); }
            set { this["RANK"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Sınıf
    /// </summary>
        public MilitaryClassDefinitions Class
        {
            get { return (MilitaryClassDefinitions)((ITTObject)this).GetParent("CLASS"); }
            set { this["CLASS"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected HCMatterSliceAnectodeDefinition(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected HCMatterSliceAnectodeDefinition(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected HCMatterSliceAnectodeDefinition(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected HCMatterSliceAnectodeDefinition(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected HCMatterSliceAnectodeDefinition(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "HCMATTERSLICEANECTODEDEFINITION", dataRow) { }
        protected HCMatterSliceAnectodeDefinition(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "HCMATTERSLICEANECTODEDEFINITION", dataRow, isImported) { }
        public HCMatterSliceAnectodeDefinition(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public HCMatterSliceAnectodeDefinition(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public HCMatterSliceAnectodeDefinition() : base() { }

    }
}