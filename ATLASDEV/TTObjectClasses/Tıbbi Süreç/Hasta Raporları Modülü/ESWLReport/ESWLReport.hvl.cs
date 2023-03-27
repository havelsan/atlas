
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="ESWLReport")] 

    /// <summary>
    /// ESWL Raporu
    /// </summary>
    public  partial class ESWLReport : TTObject
    {
        public class ESWLReportList : TTObjectCollection<ESWLReport> { }
                    
        public class ChildESWLReportCollection : TTObject.TTChildObjectCollection<ESWLReport>
        {
            public ChildESWLReportCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildESWLReportCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
    /// <summary>
    /// Taş Sayısı
    /// </summary>
        public int? NumberOfStone
        {
            get { return (int?)this["NUMBEROFSTONE"]; }
            set { this["NUMBEROFSTONE"] = value; }
        }

    /// <summary>
    /// Seans Sayısı
    /// </summary>
        public int? NumberOfSessions
        {
            get { return (int?)this["NUMBEROFSESSIONS"]; }
            set { this["NUMBEROFSESSIONS"] = value; }
        }

        public TedaviRaporiIslemKodlari TedaviRaporiIslemKodlari
        {
            get { return (TedaviRaporiIslemKodlari)((ITTObject)this).GetParent("TEDAVIRAPORIISLEMKODLARI"); }
            set { this["TEDAVIRAPORIISLEMKODLARI"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public Bobrek Bobrek
        {
            get { return (Bobrek)((ITTObject)this).GetParent("BOBREK"); }
            set { this["BOBREK"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        virtual protected void CreateESWLReportDetailGridCollection()
        {
            _ESWLReportDetailGrid = new ESWLReportDetailGrid.ChildESWLReportDetailGridCollection(this, new Guid("91a11e3f-b53d-4a0c-9f2d-8eb997a2aab5"));
            ((ITTChildObjectCollection)_ESWLReportDetailGrid).GetChildren();
        }

        protected ESWLReportDetailGrid.ChildESWLReportDetailGridCollection _ESWLReportDetailGrid = null;
        public ESWLReportDetailGrid.ChildESWLReportDetailGridCollection ESWLReportDetailGrid
        {
            get
            {
                if (_ESWLReportDetailGrid == null)
                    CreateESWLReportDetailGridCollection();
                return _ESWLReportDetailGrid;
            }
        }

        protected ESWLReport(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected ESWLReport(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected ESWLReport(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected ESWLReport(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected ESWLReport(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "ESWLREPORT", dataRow) { }
        protected ESWLReport(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "ESWLREPORT", dataRow, isImported) { }
        public ESWLReport(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public ESWLReport(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public ESWLReport() : base() { }

    }
}