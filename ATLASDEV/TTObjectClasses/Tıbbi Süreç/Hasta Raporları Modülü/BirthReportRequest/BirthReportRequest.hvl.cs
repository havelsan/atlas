
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="BirthReportRequest")] 

    /// <summary>
    /// Birden Fazla Doğum Raporunun Yazılması İçin Kullanılan NEsnedir
    /// </summary>
    public  partial class BirthReportRequest : EpisodeAction
    {
        public class BirthReportRequestList : TTObjectCollection<BirthReportRequest> { }
                    
        public class ChildBirthReportRequestCollection : TTObject.TTChildObjectCollection<BirthReportRequest>
        {
            public ChildBirthReportRequestCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildBirthReportRequestCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        public static class States
        {
    /// <summary>
    /// Yeni
    /// </summary>
            public static Guid New { get { return new Guid("12e47a17-feb8-465b-9d75-8926306ce2e8"); } }
            public static Guid Complete { get { return new Guid("5321fe29-4649-4ea6-930e-42e818e8c7fd"); } }
        }

        public static BindingList<BirthReportRequest> GetBirthReportRequestByEpisode(TTObjectContext objectContext, Guid EPISODE)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["BIRTHREPORTREQUEST"].QueryDefs["GetBirthReportRequestByEpisode"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("EPISODE", EPISODE);

            return ((ITTQuery)objectContext).QueryObjects<BirthReportRequest>(queryDef, paramList);
        }

        virtual protected void CreateBirthReportsCollection()
        {
            _BirthReports = new BirthReport.ChildBirthReportCollection(this, new Guid("eed0353a-6da4-426c-bb7c-5efa2ced7cf7"));
            ((ITTChildObjectCollection)_BirthReports).GetChildren();
        }

        protected BirthReport.ChildBirthReportCollection _BirthReports = null;
    /// <summary>
    /// Child collection for İstek-Doğum Raporları
    /// </summary>
        public BirthReport.ChildBirthReportCollection BirthReports
        {
            get
            {
                if (_BirthReports == null)
                    CreateBirthReportsCollection();
                return _BirthReports;
            }
        }

        protected BirthReportRequest(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected BirthReportRequest(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected BirthReportRequest(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected BirthReportRequest(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected BirthReportRequest(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "BIRTHREPORTREQUEST", dataRow) { }
        protected BirthReportRequest(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "BIRTHREPORTREQUEST", dataRow, isImported) { }
        public BirthReportRequest(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public BirthReportRequest(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public BirthReportRequest() : base() { }

        override protected void RunPreTransition(TTObjectStateTransitionDef transDef)
        {
            if (MustCallBasePreScript(transDef))
                base.RunPreTransition(transDef.BaseTransDef);
            this.PreTransition(transDef);
        }
        override protected void RunPostTransition(TTObjectStateTransitionDef transDef)
        {
            if (MustCallBasePostScript(transDef))
                base.RunPostTransition(transDef.BaseTransDef);
            this.PostTransition(transDef);
        }
        override protected void RunUndoTransition(TTObjectStateTransitionDef transDef)
        {
            if (MustCallBaseUndoScript(transDef))
                base.RunUndoTransition(transDef.BaseTransDef);
            this.UndoTransition(transDef);
        }
    }
}