
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="RaporGirisDVO")] 

    public  partial class RaporGirisDVO : BaseMedulaRaporObject
    {
        public class RaporGirisDVOList : TTObjectCollection<RaporGirisDVO> { }
                    
        public class ChildRaporGirisDVOCollection : TTObject.TTChildObjectCollection<RaporGirisDVO>
        {
            public ChildRaporGirisDVOCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildRaporGirisDVOCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
    /// <summary>
    /// Rapor Cevap
    /// </summary>
        public RaporCevapDVO raporCevapDVO
        {
            get { return (RaporCevapDVO)((ITTObject)this).GetParent("RAPORCEVAPDVO"); }
            set { this["RAPORCEVAPDVO"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public ProtezRaporDVO protezRapor
        {
            get { return (ProtezRaporDVO)((ITTObject)this).GetParent("PROTEZRAPOR"); }
            set { this["PROTEZRAPOR"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public TedaviRaporDVO tedaviRapor
        {
            get { return (TedaviRaporDVO)((ITTObject)this).GetParent("TEDAVIRAPOR"); }
            set { this["TEDAVIRAPOR"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public IsgoremezlikRaporDVO isgoremezlikRapor
        {
            get { return (IsgoremezlikRaporDVO)((ITTObject)this).GetParent("ISGOREMEZLIKRAPOR"); }
            set { this["ISGOREMEZLIKRAPOR"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public AnalikIsgoremezlikRaporDVO analikRapor
        {
            get { return (AnalikIsgoremezlikRaporDVO)((ITTObject)this).GetParent("ANALIKRAPOR"); }
            set { this["ANALIKRAPOR"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public DogumOncesiCalisabilirRaporDVO dogumOncesiCalisabilirRapor
        {
            get { return (DogumOncesiCalisabilirRaporDVO)((ITTObject)this).GetParent("DOGUMONCESICALISABILIRRAPOR"); }
            set { this["DOGUMONCESICALISABILIRRAPOR"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public DogumRaporDVO dogumRapor
        {
            get { return (DogumRaporDVO)((ITTObject)this).GetParent("DOGUMRAPOR"); }
            set { this["DOGUMRAPOR"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public IlacRaporDVO ilacRapor
        {
            get { return (IlacRaporDVO)((ITTObject)this).GetParent("ILACRAPOR"); }
            set { this["ILACRAPOR"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public MaluliyetRaporDVO maluliyetRapor
        {
            get { return (MaluliyetRaporDVO)((ITTObject)this).GetParent("MALULIYETRAPOR"); }
            set { this["MALULIYETRAPOR"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected RaporGirisDVO(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected RaporGirisDVO(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected RaporGirisDVO(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected RaporGirisDVO(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected RaporGirisDVO(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "RAPORGIRISDVO", dataRow) { }
        protected RaporGirisDVO(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "RAPORGIRISDVO", dataRow, isImported) { }
        public RaporGirisDVO(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public RaporGirisDVO(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public RaporGirisDVO() : base() { }

    }
}