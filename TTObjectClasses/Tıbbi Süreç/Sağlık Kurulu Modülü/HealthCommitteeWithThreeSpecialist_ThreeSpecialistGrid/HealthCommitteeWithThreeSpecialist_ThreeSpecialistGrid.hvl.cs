
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="HealthCommitteeWithThreeSpecialist_ThreeSpecialistGrid")] 

    /// <summary>
    /// Sağlık Kurulu Üç İmza Üç uzman
    /// </summary>
    public  partial class HealthCommitteeWithThreeSpecialist_ThreeSpecialistGrid : TTObject
    {
        public class HealthCommitteeWithThreeSpecialist_ThreeSpecialistGridList : TTObjectCollection<HealthCommitteeWithThreeSpecialist_ThreeSpecialistGrid> { }
                    
        public class ChildHealthCommitteeWithThreeSpecialist_ThreeSpecialistGridCollection : TTObject.TTChildObjectCollection<HealthCommitteeWithThreeSpecialist_ThreeSpecialistGrid>
        {
            public ChildHealthCommitteeWithThreeSpecialist_ThreeSpecialistGridCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildHealthCommitteeWithThreeSpecialist_ThreeSpecialistGridCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetHCWTS_ThreeSpecialistGridByParent_Class : TTReportNqlObject 
        {
            public Guid? Gridid
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["GRIDID"]);
                }
            }

            public string Uzmanadi1
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["UZMANADI1"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESUSER"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Sinif1
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["SINIF1"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MILITARYCLASSDEFINITIONS"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Rutbe1
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["RUTBE1"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RANKDEFINITIONS"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public UserTitleEnum? Unvan1
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["UNVAN1"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESUSER"].AllPropertyDefs["TITLE"].DataType;
                    return (UserTitleEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public string Sicil1
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["SICIL1"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESUSER"].AllPropertyDefs["EMPLOYMENTRECORDID"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public GetHCWTS_ThreeSpecialistGridByParent_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetHCWTS_ThreeSpecialistGridByParent_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetHCWTS_ThreeSpecialistGridByParent_Class() : base() { }
        }

    /// <summary>
    /// HEALTHCOMMITTEEWITHTHREESPECIALIST_THREESPECIALISTGRID i parent HCWTS ile get eder
    /// </summary>
        public static BindingList<HealthCommitteeWithThreeSpecialist_ThreeSpecialistGrid.GetHCWTS_ThreeSpecialistGridByParent_Class> GetHCWTS_ThreeSpecialistGridByParent(string PARENTID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["HEALTHCOMMITTEEWITHTHREESPECIALIST_THREESPECIALISTGRID"].QueryDefs["GetHCWTS_ThreeSpecialistGridByParent"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("PARENTID", PARENTID);

            return TTReportNqlObject.QueryObjects<HealthCommitteeWithThreeSpecialist_ThreeSpecialistGrid.GetHCWTS_ThreeSpecialistGridByParent_Class>(queryDef, paramList, pi);
        }

    /// <summary>
    /// HEALTHCOMMITTEEWITHTHREESPECIALIST_THREESPECIALISTGRID i parent HCWTS ile get eder
    /// </summary>
        public static BindingList<HealthCommitteeWithThreeSpecialist_ThreeSpecialistGrid.GetHCWTS_ThreeSpecialistGridByParent_Class> GetHCWTS_ThreeSpecialistGridByParent(TTObjectContext objectContext, string PARENTID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["HEALTHCOMMITTEEWITHTHREESPECIALIST_THREESPECIALISTGRID"].QueryDefs["GetHCWTS_ThreeSpecialistGridByParent"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("PARENTID", PARENTID);

            return TTReportNqlObject.QueryObjects<HealthCommitteeWithThreeSpecialist_ThreeSpecialistGrid.GetHCWTS_ThreeSpecialistGridByParent_Class>(objectContext, queryDef, paramList, pi);
        }

    /// <summary>
    /// Uzman 2
    /// </summary>
        public ResUser Specialist2
        {
            get { return (ResUser)((ITTObject)this).GetParent("SPECIALIST2"); }
            set { this["SPECIALIST2"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public HealthCommitteeWithThreeSpecialist HCommitteeWithThreeSpecialist
        {
            get { return (HealthCommitteeWithThreeSpecialist)((ITTObject)this).GetParent("HCOMMITTEEWITHTHREESPECIALIST"); }
            set { this["HCOMMITTEEWITHTHREESPECIALIST"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Uzman 3
    /// </summary>
        public ResUser Specialist3
        {
            get { return (ResUser)((ITTObject)this).GetParent("SPECIALIST3"); }
            set { this["SPECIALIST3"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Uzman 1
    /// </summary>
        public ResUser Specialist1
        {
            get { return (ResUser)((ITTObject)this).GetParent("SPECIALIST1"); }
            set { this["SPECIALIST1"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// 2. Birim
    /// </summary>
        public ResSection ResSectionOfSpecialist2
        {
            get { return (ResSection)((ITTObject)this).GetParent("RESSECTIONOFSPECIALIST2"); }
            set { this["RESSECTIONOFSPECIALIST2"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// 3. Birim
    /// </summary>
        public ResSection ResSectionOfSpecialist3
        {
            get { return (ResSection)((ITTObject)this).GetParent("RESSECTIONOFSPECIALIST3"); }
            set { this["RESSECTIONOFSPECIALIST3"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected HealthCommitteeWithThreeSpecialist_ThreeSpecialistGrid(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected HealthCommitteeWithThreeSpecialist_ThreeSpecialistGrid(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected HealthCommitteeWithThreeSpecialist_ThreeSpecialistGrid(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected HealthCommitteeWithThreeSpecialist_ThreeSpecialistGrid(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected HealthCommitteeWithThreeSpecialist_ThreeSpecialistGrid(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "HEALTHCOMMITTEEWITHTHREESPECIALIST_THREESPECIALISTGRID", dataRow) { }
        protected HealthCommitteeWithThreeSpecialist_ThreeSpecialistGrid(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "HEALTHCOMMITTEEWITHTHREESPECIALIST_THREESPECIALISTGRID", dataRow, isImported) { }
        public HealthCommitteeWithThreeSpecialist_ThreeSpecialistGrid(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public HealthCommitteeWithThreeSpecialist_ThreeSpecialistGrid(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public HealthCommitteeWithThreeSpecialist_ThreeSpecialistGrid() : base() { }

    }
}