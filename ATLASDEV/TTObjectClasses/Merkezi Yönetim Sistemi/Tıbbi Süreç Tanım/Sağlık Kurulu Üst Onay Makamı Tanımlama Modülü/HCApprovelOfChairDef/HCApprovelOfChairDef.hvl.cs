
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="HCApprovelOfChairDef")] 

    /// <summary>
    /// Sağlık Kurulu Üst Onay Makamı Tanımlama
    /// </summary>
    public  partial class HCApprovelOfChairDef : TerminologyManagerDef
    {
        public class HCApprovelOfChairDefList : TTObjectCollection<HCApprovelOfChairDef> { }
                    
        public class ChildHCApprovelOfChairDefCollection : TTObject.TTChildObjectCollection<HCApprovelOfChairDef>
        {
            public ChildHCApprovelOfChairDefCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildHCApprovelOfChairDefCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetHCApprovelOfChairDefs_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public string Code
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["CODE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["HCAPPROVELOFCHAIRDEF"].AllPropertyDefs["CODE"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Name
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["NAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["HCAPPROVELOFCHAIRDEF"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Sitename
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["SITENAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SITES"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Resourcename
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["RESOURCENAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESSECTION"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public GetHCApprovelOfChairDefs_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetHCApprovelOfChairDefs_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetHCApprovelOfChairDefs_Class() : base() { }
        }

        public static BindingList<HCApprovelOfChairDef> GetHCApprovelOfChairDefByLastUpdateDate(TTObjectContext objectContext, DateTime STARTDATE, DateTime ENDDATE)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["HCAPPROVELOFCHAIRDEF"].QueryDefs["GetHCApprovelOfChairDefByLastUpdateDate"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);

            return ((ITTQuery)objectContext).QueryObjects<HCApprovelOfChairDef>(queryDef, paramList);
        }

        public static BindingList<HCApprovelOfChairDef.GetHCApprovelOfChairDefs_Class> GetHCApprovelOfChairDefs(string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["HCAPPROVELOFCHAIRDEF"].QueryDefs["GetHCApprovelOfChairDefs"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<HCApprovelOfChairDef.GetHCApprovelOfChairDefs_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<HCApprovelOfChairDef.GetHCApprovelOfChairDefs_Class> GetHCApprovelOfChairDefs(TTObjectContext objectContext, string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["HCAPPROVELOFCHAIRDEF"].QueryDefs["GetHCApprovelOfChairDefs"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<HCApprovelOfChairDef.GetHCApprovelOfChairDefs_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

    /// <summary>
    /// Kod
    /// </summary>
        public string Code
        {
            get { return (string)this["CODE"]; }
            set { this["CODE"] = value; }
        }

    /// <summary>
    /// Ad
    /// </summary>
        public string Name
        {
            get { return (string)this["NAME"]; }
            set { this["NAME"] = value; }
        }

    /// <summary>
    /// Saha Bilgisi
    /// </summary>
        public Sites Site
        {
            get { return (Sites)((ITTObject)this).GetParent("SITE"); }
            set { this["SITE"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Bölümlerle İlişki
    /// </summary>
        public ResSection ResSection
        {
            get { return (ResSection)((ITTObject)this).GetParent("RESSECTION"); }
            set { this["RESSECTION"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected HCApprovelOfChairDef(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected HCApprovelOfChairDef(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected HCApprovelOfChairDef(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected HCApprovelOfChairDef(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected HCApprovelOfChairDef(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "HCAPPROVELOFCHAIRDEF", dataRow) { }
        protected HCApprovelOfChairDef(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "HCAPPROVELOFCHAIRDEF", dataRow, isImported) { }
        protected HCApprovelOfChairDef(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public HCApprovelOfChairDef(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public HCApprovelOfChairDef() : base() { }

    }
}