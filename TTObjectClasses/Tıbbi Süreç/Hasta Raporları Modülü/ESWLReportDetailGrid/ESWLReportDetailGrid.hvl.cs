
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="ESWLReportDetailGrid")] 

    /// <summary>
    /// ESWL  Rapor Detayları
    /// </summary>
    public  partial class ESWLReportDetailGrid : TTObject
    {
        public class ESWLReportDetailGridList : TTObjectCollection<ESWLReportDetailGrid> { }
                    
        public class ChildESWLReportDetailGridCollection : TTObject.TTChildObjectCollection<ESWLReportDetailGrid>
        {
            public ChildESWLReportDetailGridCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildESWLReportDetailGridCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
    /// <summary>
    /// Taş Boyutu
    /// </summary>
        public int? StoneSize
        {
            get { return (int?)this["STONESIZE"]; }
            set { this["STONESIZE"] = value; }
        }

        public TasLokalizasyon TasLokalizasyon
        {
            get { return (TasLokalizasyon)((ITTObject)this).GetParent("TASLOKALIZASYON"); }
            set { this["TASLOKALIZASYON"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public ESWLReport ESWLReport
        {
            get { return (ESWLReport)((ITTObject)this).GetParent("ESWLREPORT"); }
            set { this["ESWLREPORT"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected ESWLReportDetailGrid(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected ESWLReportDetailGrid(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected ESWLReportDetailGrid(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected ESWLReportDetailGrid(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected ESWLReportDetailGrid(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "ESWLREPORTDETAILGRID", dataRow) { }
        protected ESWLReportDetailGrid(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "ESWLREPORTDETAILGRID", dataRow, isImported) { }
        public ESWLReportDetailGrid(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public ESWLReportDetailGrid(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public ESWLReportDetailGrid() : base() { }

    }
}