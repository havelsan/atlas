
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="AnalikIsgoremezlikRaporDVO")] 

    public  partial class AnalikIsgoremezlikRaporDVO : BaseMedulaObject
    {
        public class AnalikIsgoremezlikRaporDVOList : TTObjectCollection<AnalikIsgoremezlikRaporDVO> { }
                    
        public class ChildAnalikIsgoremezlikRaporDVOCollection : TTObject.TTChildObjectCollection<AnalikIsgoremezlikRaporDVO>
        {
            public ChildAnalikIsgoremezlikRaporDVOCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildAnalikIsgoremezlikRaporDVOCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
    /// <summary>
    /// Bebeğin tahmini doğum tarihi (dd.mm.yyyy)
    /// </summary>
        public string bebekDogumTarihi
        {
            get { return (string)this["BEBEKDOGUMTARIHI"]; }
            set { this["BEBEKDOGUMTARIHI"] = value; }
        }

    /// <summary>
    /// Doğacak tahmini çocuk sayısı
    /// </summary>
        public int? cocukSayisi
        {
            get { return (int?)this["COCUKSAYISI"]; }
            set { this["COCUKSAYISI"] = value; }
        }

        public RaporDVO raporDVO
        {
            get { return (RaporDVO)((ITTObject)this).GetParent("RAPORDVO"); }
            set { this["RAPORDVO"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected AnalikIsgoremezlikRaporDVO(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected AnalikIsgoremezlikRaporDVO(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected AnalikIsgoremezlikRaporDVO(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected AnalikIsgoremezlikRaporDVO(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected AnalikIsgoremezlikRaporDVO(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "ANALIKISGOREMEZLIKRAPORDVO", dataRow) { }
        protected AnalikIsgoremezlikRaporDVO(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "ANALIKISGOREMEZLIKRAPORDVO", dataRow, isImported) { }
        public AnalikIsgoremezlikRaporDVO(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public AnalikIsgoremezlikRaporDVO(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public AnalikIsgoremezlikRaporDVO() : base() { }

    }
}