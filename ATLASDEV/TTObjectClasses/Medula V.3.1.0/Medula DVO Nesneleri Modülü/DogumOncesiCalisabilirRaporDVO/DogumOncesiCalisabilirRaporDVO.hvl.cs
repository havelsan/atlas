
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="DogumOncesiCalisabilirRaporDVO")] 

    public  partial class DogumOncesiCalisabilirRaporDVO : BaseMedulaObject
    {
        public class DogumOncesiCalisabilirRaporDVOList : TTObjectCollection<DogumOncesiCalisabilirRaporDVO> { }
                    
        public class ChildDogumOncesiCalisabilirRaporDVOCollection : TTObject.TTChildObjectCollection<DogumOncesiCalisabilirRaporDVO>
        {
            public ChildDogumOncesiCalisabilirRaporDVOCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildDogumOncesiCalisabilirRaporDVOCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
    /// <summary>
    /// Doğum izninin başladığı tarih (dd.mm.yyyy)
    /// </summary>
        public string dogumIzniBaslangicTarihi
        {
            get { return (string)this["DOGUMIZNIBASLANGICTARIHI"]; }
            set { this["DOGUMIZNIBASLANGICTARIHI"] = value; }
        }

    /// <summary>
    /// Bebeğin tahmini doğum tarihi (dd.mm.yyyy)
    /// </summary>
        public string bebekDogumTarihi
        {
            get { return (string)this["BEBEKDOGUMTARIHI"]; }
            set { this["BEBEKDOGUMTARIHI"] = value; }
        }

        public RaporDVO raporDVO
        {
            get { return (RaporDVO)((ITTObject)this).GetParent("RAPORDVO"); }
            set { this["RAPORDVO"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected DogumOncesiCalisabilirRaporDVO(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected DogumOncesiCalisabilirRaporDVO(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected DogumOncesiCalisabilirRaporDVO(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected DogumOncesiCalisabilirRaporDVO(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected DogumOncesiCalisabilirRaporDVO(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "DOGUMONCESICALISABILIRRAPORDVO", dataRow) { }
        protected DogumOncesiCalisabilirRaporDVO(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "DOGUMONCESICALISABILIRRAPORDVO", dataRow, isImported) { }
        public DogumOncesiCalisabilirRaporDVO(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public DogumOncesiCalisabilirRaporDVO(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public DogumOncesiCalisabilirRaporDVO() : base() { }

    }
}