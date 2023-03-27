
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="BaseEpisodeDataCorrection")] 

    public  abstract  partial class BaseEpisodeDataCorrection : BasePatientDataCorrection
    {
        public class BaseEpisodeDataCorrectionList : TTObjectCollection<BaseEpisodeDataCorrection> { }
                    
        public class ChildBaseEpisodeDataCorrectionCollection : TTObject.TTChildObjectCollection<BaseEpisodeDataCorrection>
        {
            public ChildBaseEpisodeDataCorrectionCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildBaseEpisodeDataCorrectionCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        new public static class States
        {
            public static Guid New { get { return new Guid("34897a19-9fa2-4dff-a783-83131c222bbc"); } }
            public static Guid Cancelled { get { return new Guid("d9a4cfca-0c12-4913-bf60-35e811619787"); } }
            public static Guid Completed { get { return new Guid("f00f14e0-e935-4391-b052-6218ca0e612e"); } }
        }

        public Episode Episode
        {
            get { return (Episode)((ITTObject)this).GetParent("EPISODE"); }
            set { this["EPISODE"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected BaseEpisodeDataCorrection(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected BaseEpisodeDataCorrection(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected BaseEpisodeDataCorrection(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected BaseEpisodeDataCorrection(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected BaseEpisodeDataCorrection(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "BASEEPISODEDATACORRECTION", dataRow) { }
        protected BaseEpisodeDataCorrection(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "BASEEPISODEDATACORRECTION", dataRow, isImported) { }
        public BaseEpisodeDataCorrection(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public BaseEpisodeDataCorrection(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public BaseEpisodeDataCorrection() : base() { }

    }
}