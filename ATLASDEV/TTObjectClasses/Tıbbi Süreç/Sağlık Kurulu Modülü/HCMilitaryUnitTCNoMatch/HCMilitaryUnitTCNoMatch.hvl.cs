
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="HCMilitaryUnitTCNoMatch")] 

    /// <summary>
    /// Sağlık Kurulu XXXXXX Okul Tc No Eşleştirm
    /// </summary>
    public  partial class HCMilitaryUnitTCNoMatch : TTObject
    {
        public class HCMilitaryUnitTCNoMatchList : TTObjectCollection<HCMilitaryUnitTCNoMatch> { }
                    
        public class ChildHCMilitaryUnitTCNoMatchCollection : TTObject.TTChildObjectCollection<HCMilitaryUnitTCNoMatch>
        {
            public ChildHCMilitaryUnitTCNoMatchCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildHCMilitaryUnitTCNoMatchCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetReadHCMilitaryUnitTCNoMatch_Class : TTReportNqlObject 
        {
            public string TCNo
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["TCNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["HCMILITARYUNITTCNOMATCH"].AllPropertyDefs["TCNO"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public bool? IsRead
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ISREAD"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["HCMILITARYUNITTCNOMATCH"].AllPropertyDefs["ISREAD"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public GetReadHCMilitaryUnitTCNoMatch_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetReadHCMilitaryUnitTCNoMatch_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetReadHCMilitaryUnitTCNoMatch_Class() : base() { }
        }

        public static BindingList<HCMilitaryUnitTCNoMatch.GetReadHCMilitaryUnitTCNoMatch_Class> GetReadHCMilitaryUnitTCNoMatch(int YEAR, string MILITARYUNIT, int ISREADFLAG, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["HCMILITARYUNITTCNOMATCH"].QueryDefs["GetReadHCMilitaryUnitTCNoMatch"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("YEAR", YEAR);
            paramList.Add("MILITARYUNIT", MILITARYUNIT);
            paramList.Add("ISREADFLAG", ISREADFLAG);

            return TTReportNqlObject.QueryObjects<HCMilitaryUnitTCNoMatch.GetReadHCMilitaryUnitTCNoMatch_Class>(queryDef, paramList, pi);
        }

        public static BindingList<HCMilitaryUnitTCNoMatch.GetReadHCMilitaryUnitTCNoMatch_Class> GetReadHCMilitaryUnitTCNoMatch(TTObjectContext objectContext, int YEAR, string MILITARYUNIT, int ISREADFLAG, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["HCMILITARYUNITTCNOMATCH"].QueryDefs["GetReadHCMilitaryUnitTCNoMatch"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("YEAR", YEAR);
            paramList.Add("MILITARYUNIT", MILITARYUNIT);
            paramList.Add("ISREADFLAG", ISREADFLAG);

            return TTReportNqlObject.QueryObjects<HCMilitaryUnitTCNoMatch.GetReadHCMilitaryUnitTCNoMatch_Class>(objectContext, queryDef, paramList, pi);
        }

    /// <summary>
    /// Okundu mu
    /// </summary>
        public bool? IsRead
        {
            get { return (bool?)this["ISREAD"]; }
            set { this["ISREAD"] = value; }
        }

    /// <summary>
    /// Tc Kimlik No
    /// </summary>
        public string TCNo
        {
            get { return (string)this["TCNO"]; }
            set { this["TCNO"] = value; }
        }

    /// <summary>
    /// Yıl
    /// </summary>
        public int? Year
        {
            get { return (int?)this["YEAR"]; }
            set { this["YEAR"] = value; }
        }

        public MilitaryUnit MilitaryUnit
        {
            get { return (MilitaryUnit)((ITTObject)this).GetParent("MILITARYUNIT"); }
            set { this["MILITARYUNIT"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected HCMilitaryUnitTCNoMatch(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected HCMilitaryUnitTCNoMatch(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected HCMilitaryUnitTCNoMatch(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected HCMilitaryUnitTCNoMatch(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected HCMilitaryUnitTCNoMatch(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "HCMILITARYUNITTCNOMATCH", dataRow) { }
        protected HCMilitaryUnitTCNoMatch(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "HCMILITARYUNITTCNOMATCH", dataRow, isImported) { }
        public HCMilitaryUnitTCNoMatch(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public HCMilitaryUnitTCNoMatch(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public HCMilitaryUnitTCNoMatch() : base() { }

    }
}