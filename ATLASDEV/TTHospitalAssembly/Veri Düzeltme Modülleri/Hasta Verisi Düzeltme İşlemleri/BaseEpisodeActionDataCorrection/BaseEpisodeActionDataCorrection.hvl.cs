
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="BaseEpisodeActionDataCorrection")] 

    public  abstract  partial class BaseEpisodeActionDataCorrection : BaseEpisodeDataCorrection
    {
        public class BaseEpisodeActionDataCorrectionList : TTObjectCollection<BaseEpisodeActionDataCorrection> { }
                    
        public class ChildBaseEpisodeActionDataCorrectionCollection : TTObject.TTChildObjectCollection<BaseEpisodeActionDataCorrection>
        {
            public ChildBaseEpisodeActionDataCorrectionCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildBaseEpisodeActionDataCorrectionCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        new public static class States
        {
            public static Guid New { get { return new Guid("34897a19-9fa2-4dff-a783-83131c222bbc"); } }
            public static Guid Cancelled { get { return new Guid("d9a4cfca-0c12-4913-bf60-35e811619787"); } }
            public static Guid Completed { get { return new Guid("f00f14e0-e935-4391-b052-6218ca0e612e"); } }
        }

        public EpisodeAction EpisodeAction
        {
            get { return (EpisodeAction)((ITTObject)this).GetParent("EPISODEACTION"); }
            set { this["EPISODEACTION"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected BaseEpisodeActionDataCorrection(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected BaseEpisodeActionDataCorrection(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected BaseEpisodeActionDataCorrection(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected BaseEpisodeActionDataCorrection(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected BaseEpisodeActionDataCorrection(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "BASEEPISODEACTIONDATACORRECTION", dataRow) { }
        protected BaseEpisodeActionDataCorrection(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "BASEEPISODEACTIONDATACORRECTION", dataRow, isImported) { }
        public BaseEpisodeActionDataCorrection(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public BaseEpisodeActionDataCorrection(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public BaseEpisodeActionDataCorrection() : base() { }

    }
}