
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="ehrAutopsyReport")] 

    /// <summary>
    /// Otopsi Raporu
    /// </summary>
    public  partial class ehrAutopsyReport : ehrEpisodeAction
    {
        public class ehrAutopsyReportList : TTObjectCollection<ehrAutopsyReport> { }
                    
        public class ChildehrAutopsyReportCollection : TTObject.TTChildObjectCollection<ehrAutopsyReport>
        {
            public ChildehrAutopsyReportCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildehrAutopsyReportCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        new public static class States
        {
            public static Guid Active { get { return new Guid("d82caca1-a08a-43fa-b009-be70b816c5ec"); } }
            public static Guid UnActive { get { return new Guid("8abe0000-7e19-46e0-a07f-e69109e6aa4c"); } }
        }

    /// <summary>
    /// Evrak Tarihi
    /// </summary>
        public DateTime? DocumentDate
        {
            get { return (DateTime?)this["DOCUMENTDATE"]; }
            set { this["DOCUMENTDATE"] = value; }
        }

    /// <summary>
    /// Evrak Sayısı
    /// </summary>
        public string DocumentNumber
        {
            get { return (string)this["DOCUMENTNUMBER"]; }
            set { this["DOCUMENTNUMBER"] = value; }
        }

    /// <summary>
    /// Adli Makam
    /// </summary>
        public MilitaryUnit SenderChair
        {
            get { return (MilitaryUnit)((ITTObject)this).GetParent("SENDERCHAIR"); }
            set { this["SENDERCHAIR"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected ehrAutopsyReport(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected ehrAutopsyReport(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected ehrAutopsyReport(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected ehrAutopsyReport(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected ehrAutopsyReport(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "EHRAUTOPSYREPORT", dataRow) { }
        protected ehrAutopsyReport(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "EHRAUTOPSYREPORT", dataRow, isImported) { }
        public ehrAutopsyReport(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public ehrAutopsyReport(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public ehrAutopsyReport() : base() { }

    }
}