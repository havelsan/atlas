
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="RaporEtkinMaddeDVO")] 

    public  partial class RaporEtkinMaddeDVO : BaseMedulaObject
    {
        public class RaporEtkinMaddeDVOList : TTObjectCollection<RaporEtkinMaddeDVO> { }
                    
        public class ChildRaporEtkinMaddeDVOCollection : TTObject.TTChildObjectCollection<RaporEtkinMaddeDVO>
        {
            public ChildRaporEtkinMaddeDVOCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildRaporEtkinMaddeDVOCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        public int? kullanimDoz1
        {
            get { return (int?)this["KULLANIMDOZ1"]; }
            set { this["KULLANIMDOZ1"] = value; }
        }

        public string etkinMaddeKodu
        {
            get { return (string)this["ETKINMADDEKODU"]; }
            set { this["ETKINMADDEKODU"] = value; }
        }

        public int? kullanimDoz2
        {
            get { return (int?)this["KULLANIMDOZ2"]; }
            set { this["KULLANIMDOZ2"] = value; }
        }

        public string kullanimDozBirim
        {
            get { return (string)this["KULLANIMDOZBIRIM"]; }
            set { this["KULLANIMDOZBIRIM"] = value; }
        }

        public int? kullanimPeriyot
        {
            get { return (int?)this["KULLANIMPERIYOT"]; }
            set { this["KULLANIMPERIYOT"] = value; }
        }

        public string kullanimPeriyotBirim
        {
            get { return (string)this["KULLANIMPERIYOTBIRIM"]; }
            set { this["KULLANIMPERIYOTBIRIM"] = value; }
        }

        public IlacRaporDVO IlacRaporDVO
        {
            get { return (IlacRaporDVO)((ITTObject)this).GetParent("ILACRAPORDVO"); }
            set { this["ILACRAPORDVO"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public IlacRaporDuzeltDVO IlacRaporDuzeltDVO
        {
            get { return (IlacRaporDuzeltDVO)((ITTObject)this).GetParent("ILACRAPORDUZELTDVO"); }
            set { this["ILACRAPORDUZELTDVO"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected RaporEtkinMaddeDVO(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected RaporEtkinMaddeDVO(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected RaporEtkinMaddeDVO(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected RaporEtkinMaddeDVO(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected RaporEtkinMaddeDVO(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "RAPORETKINMADDEDVO", dataRow) { }
        protected RaporEtkinMaddeDVO(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "RAPORETKINMADDEDVO", dataRow, isImported) { }
        public RaporEtkinMaddeDVO(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public RaporEtkinMaddeDVO(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public RaporEtkinMaddeDVO() : base() { }

    }
}