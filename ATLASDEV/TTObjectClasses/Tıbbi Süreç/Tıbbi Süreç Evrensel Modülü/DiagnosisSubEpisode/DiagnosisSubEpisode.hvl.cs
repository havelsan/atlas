
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="DiagnosisSubEpisode")] 

    public  partial class DiagnosisSubEpisode : TTObject
    {
        public class DiagnosisSubEpisodeList : TTObjectCollection<DiagnosisSubEpisode> { }
                    
        public class ChildDiagnosisSubEpisodeCollection : TTObject.TTChildObjectCollection<DiagnosisSubEpisode>
        {
            public ChildDiagnosisSubEpisodeCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildDiagnosisSubEpisodeCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        public static BindingList<DiagnosisSubEpisode> GetDataForDiagnoseSMS(TTObjectContext objectContext, DateTime TODAYSTART, Guid DIAGNOSEID, DateTime TODAYEND)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["DIAGNOSISSUBEPISODE"].QueryDefs["GetDataForDiagnoseSMS"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("TODAYSTART", TODAYSTART);
            paramList.Add("DIAGNOSEID", DIAGNOSEID);
            paramList.Add("TODAYEND", TODAYEND);

            return ((ITTQuery)objectContext).QueryObjects<DiagnosisSubEpisode>(queryDef, paramList);
        }

        public DiagnosisGrid DiagnosisGrid
        {
            get { return (DiagnosisGrid)((ITTObject)this).GetParent("DIAGNOSISGRID"); }
            set { this["DIAGNOSISGRID"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public SubEpisode SubEpisode
        {
            get { return (SubEpisode)((ITTObject)this).GetParent("SUBEPISODE"); }
            set { this["SUBEPISODE"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        virtual protected void CreateSEPDiagnosisCollection()
        {
            _SEPDiagnosis = new SEPDiagnosis.ChildSEPDiagnosisCollection(this, new Guid("5c024f27-6d88-46c7-8ca9-28957ec89db7"));
            ((ITTChildObjectCollection)_SEPDiagnosis).GetChildren();
        }

        protected SEPDiagnosis.ChildSEPDiagnosisCollection _SEPDiagnosis = null;
        public SEPDiagnosis.ChildSEPDiagnosisCollection SEPDiagnosis
        {
            get
            {
                if (_SEPDiagnosis == null)
                    CreateSEPDiagnosisCollection();
                return _SEPDiagnosis;
            }
        }

        protected DiagnosisSubEpisode(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected DiagnosisSubEpisode(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected DiagnosisSubEpisode(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected DiagnosisSubEpisode(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected DiagnosisSubEpisode(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "DIAGNOSISSUBEPISODE", dataRow) { }
        protected DiagnosisSubEpisode(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "DIAGNOSISSUBEPISODE", dataRow, isImported) { }
        public DiagnosisSubEpisode(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public DiagnosisSubEpisode(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public DiagnosisSubEpisode() : base() { }

    }
}