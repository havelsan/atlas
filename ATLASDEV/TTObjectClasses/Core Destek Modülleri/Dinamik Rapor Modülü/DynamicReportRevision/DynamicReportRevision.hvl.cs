
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="DynamicReportRevision")] 

    /// <summary>
    /// Raporun Revizyonlarinin Tutuldugu Tablo
    /// </summary>
    public  partial class DynamicReportRevision : TTObject
    {
        public class DynamicReportRevisionList : TTObjectCollection<DynamicReportRevision> { }
                    
        public class ChildDynamicReportRevisionCollection : TTObject.TTChildObjectCollection<DynamicReportRevision>
        {
            public ChildDynamicReportRevisionCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildDynamicReportRevisionCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
    /// <summary>
    /// IsMain
    /// </summary>
        public bool? IsMain
        {
            get { return (bool?)this["ISMAIN"]; }
            set { this["ISMAIN"] = value; }
        }

    /// <summary>
    /// Raporun Revizyon Numarasi
    /// </summary>
        public int? RevisionNumber
        {
            get { return (int?)this["REVISIONNUMBER"]; }
            set { this["REVISIONNUMBER"] = value; }
        }

    /// <summary>
    /// Revizyonun Olusturulma Tarihi
    /// </summary>
        public DateTime? CreatedDate
        {
            get { return (DateTime?)this["CREATEDDATE"]; }
            set { this["CREATEDDATE"] = value; }
        }

    /// <summary>
    /// Raporun Olusturulma Sebebi
    /// </summary>
        public string ReportComment
        {
            get { return (string)this["REPORTCOMMENT"]; }
            set { this["REPORTCOMMENT"] = value; }
        }

    /// <summary>
    /// Raporun icerigi
    /// </summary>
        public object ReportJSONContent
        {
            get { return (object)this["REPORTJSONCONTENT"]; }
            set { this["REPORTJSONCONTENT"] = value; }
        }

    /// <summary>
    /// Revizyonun Aktifligi
    /// </summary>
        public bool? Enabled
        {
            get { return (bool?)this["ENABLED"]; }
            set { this["ENABLED"] = value; }
        }

        public ResUser CreatedBy
        {
            get { return (ResUser)((ITTObject)this).GetParent("CREATEDBY"); }
            set { this["CREATEDBY"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public DynamicReport DynamicReport
        {
            get { return (DynamicReport)((ITTObject)this).GetParent("DYNAMICREPORT"); }
            set { this["DYNAMICREPORT"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected DynamicReportRevision(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected DynamicReportRevision(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected DynamicReportRevision(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected DynamicReportRevision(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected DynamicReportRevision(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "DYNAMICREPORTREVISION", dataRow) { }
        protected DynamicReportRevision(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "DYNAMICREPORTREVISION", dataRow, isImported) { }
        public DynamicReportRevision(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public DynamicReportRevision(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public DynamicReportRevision() : base() { }

    }
}