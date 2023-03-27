
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="SPTSDiagnosisInfo")] 

    public  partial class SPTSDiagnosisInfo : TerminologyManagerDef
    {
        public class SPTSDiagnosisInfoList : TTObjectCollection<SPTSDiagnosisInfo> { }
                    
        public class ChildSPTSDiagnosisInfoCollection : TTObject.TTChildObjectCollection<SPTSDiagnosisInfo>
        {
            public ChildSPTSDiagnosisInfoCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildSPTSDiagnosisInfoCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        public static BindingList<SPTSDiagnosisInfo> GetDiagnosisInfoBySPTSIDs(TTObjectContext objectContext, long ID)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["SPTSDIAGNOSISINFO"].QueryDefs["GetDiagnosisInfoBySPTSIDs"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("ID", ID);

            return ((ITTQuery)objectContext).QueryObjects<SPTSDiagnosisInfo>(queryDef, paramList);
        }

        public static BindingList<SPTSDiagnosisInfo> GetSPTSDiagbyLastupdateDate(TTObjectContext objectContext, DateTime STARTDATE, DateTime ENDDATE)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["SPTSDIAGNOSISINFO"].QueryDefs["GetSPTSDiagbyLastupdateDate"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);

            return ((ITTQuery)objectContext).QueryObjects<SPTSDiagnosisInfo>(queryDef, paramList);
        }

        public string SearchName
        {
            get { return (string)this["SEARCHNAME"]; }
            set { this["SEARCHNAME"] = value; }
        }

        public int? IsGroup
        {
            get { return (int?)this["ISGROUP"]; }
            set { this["ISGROUP"] = value; }
        }

        public DateTime? LastUpdateDate
        {
            get { return (DateTime?)this["LASTUPDATEDATE"]; }
            set { this["LASTUPDATEDATE"] = value; }
        }

        public long? ParentID
        {
            get { return (long?)this["PARENTID"]; }
            set { this["PARENTID"] = value; }
        }

        public long? ID
        {
            get { return (long?)this["ID"]; }
            set { this["ID"] = value; }
        }

        public string EnglishName
        {
            get { return (string)this["ENGLISHNAME"]; }
            set { this["ENGLISHNAME"] = value; }
        }

        public string Code
        {
            get { return (string)this["CODE"]; }
            set { this["CODE"] = value; }
        }

        public string Name
        {
            get { return (string)this["NAME"]; }
            set { this["NAME"] = value; }
        }

        public string Name_Shadow
        {
            get { return (string)this["NAME_SHADOW"]; }
        }

        protected SPTSDiagnosisInfo(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected SPTSDiagnosisInfo(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected SPTSDiagnosisInfo(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected SPTSDiagnosisInfo(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected SPTSDiagnosisInfo(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "SPTSDIAGNOSISINFO", dataRow) { }
        protected SPTSDiagnosisInfo(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "SPTSDIAGNOSISINFO", dataRow, isImported) { }
        public SPTSDiagnosisInfo(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public SPTSDiagnosisInfo(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public SPTSDiagnosisInfo() : base() { }

    }
}