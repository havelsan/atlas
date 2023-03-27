
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="BaseDentalEpisodeActionDiagnosisGrid")] 

    public  partial class BaseDentalEpisodeActionDiagnosisGrid : DiagnosisGrid
    {
        public class BaseDentalEpisodeActionDiagnosisGridList : TTObjectCollection<BaseDentalEpisodeActionDiagnosisGrid> { }
                    
        public class ChildBaseDentalEpisodeActionDiagnosisGridCollection : TTObject.TTChildObjectCollection<BaseDentalEpisodeActionDiagnosisGrid>
        {
            public ChildBaseDentalEpisodeActionDiagnosisGridCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildBaseDentalEpisodeActionDiagnosisGridCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        public static BindingList<BaseDentalEpisodeActionDiagnosisGrid> GetByExternalIDNQL(TTObjectContext objectContext, string EXTERNALID, string PATIENT)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["BASEDENTALEPISODEACTIONDIAGNOSISGRID"].QueryDefs["GetByExternalIDNQL"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("EXTERNALID", EXTERNALID);
            paramList.Add("PATIENT", PATIENT);

            return ((ITTQuery)objectContext).QueryObjects<BaseDentalEpisodeActionDiagnosisGrid>(queryDef, paramList);
        }

    /// <summary>
    /// Pozisyon
    /// </summary>
        public DentalPositionEnum? DentalPosition
        {
            get { return (DentalPositionEnum?)(int?)this["DENTALPOSITION"]; }
            set { this["DENTALPOSITION"] = value; }
        }

    /// <summary>
    /// Diş No
    /// </summary>
        public ToothNumberEnum? ToothNumber
        {
            get { return (ToothNumberEnum?)(int?)this["TOOTHNUMBER"]; }
            set { this["TOOTHNUMBER"] = value; }
        }

    /// <summary>
    /// DentalineID
    /// </summary>
        public string ExternalID
        {
            get { return (string)this["EXTERNALID"]; }
            set { this["EXTERNALID"] = value; }
        }

        protected BaseDentalEpisodeActionDiagnosisGrid(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected BaseDentalEpisodeActionDiagnosisGrid(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected BaseDentalEpisodeActionDiagnosisGrid(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected BaseDentalEpisodeActionDiagnosisGrid(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected BaseDentalEpisodeActionDiagnosisGrid(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "BASEDENTALEPISODEACTIONDIAGNOSISGRID", dataRow) { }
        protected BaseDentalEpisodeActionDiagnosisGrid(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "BASEDENTALEPISODEACTIONDIAGNOSISGRID", dataRow, isImported) { }
        public BaseDentalEpisodeActionDiagnosisGrid(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public BaseDentalEpisodeActionDiagnosisGrid(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public BaseDentalEpisodeActionDiagnosisGrid() : base() { }

    }
}