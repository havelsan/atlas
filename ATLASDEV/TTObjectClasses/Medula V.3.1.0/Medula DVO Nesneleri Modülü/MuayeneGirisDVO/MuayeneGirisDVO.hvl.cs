
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="MuayeneGirisDVO")] 

    public  partial class MuayeneGirisDVO : BaseMedulaObject
    {
        public class MuayeneGirisDVOList : TTObjectCollection<MuayeneGirisDVO> { }
                    
        public class ChildMuayeneGirisDVOCollection : TTObject.TTChildObjectCollection<MuayeneGirisDVO>
        {
            public ChildMuayeneGirisDVOCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildMuayeneGirisDVOCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        public long? referansNo
        {
            get { return (long?)this["REFERANSNO"]; }
            set { this["REFERANSNO"] = value; }
        }

    /// <summary>
    /// Hastanın TC Kimlik Numarası
    /// </summary>
        public string hastaTCKimlikNo
        {
            get { return (string)this["HASTATCKIMLIKNO"]; }
            set { this["HASTATCKIMLIKNO"] = value; }
        }

    /// <summary>
    /// Muayene Tarihi
    /// </summary>
        public string muayeneTarihi
        {
            get { return (string)this["MUAYENETARIHI"]; }
            set { this["MUAYENETARIHI"] = value; }
        }

    /// <summary>
    /// Tesis Kodu
    /// </summary>
        public int? saglikTesisKodu
        {
            get { return (int?)this["SAGLIKTESISKODU"]; }
            set { this["SAGLIKTESISKODU"] = value; }
        }

    /// <summary>
    /// SUT Kodu
    /// </summary>
        public string sutKodu
        {
            get { return (string)this["SUTKODU"]; }
            set { this["SUTKODU"] = value; }
        }

    /// <summary>
    /// Branş Kodu
    /// </summary>
        public string bransKodu
        {
            get { return (string)this["BRANSKODU"]; }
            set { this["BRANSKODU"] = value; }
        }

    /// <summary>
    /// Doktor Tescil No
    /// </summary>
        public string drTescilNo
        {
            get { return (string)this["DRTESCILNO"]; }
            set { this["DRTESCILNO"] = value; }
        }

        public bool? gizliTutulsunmu
        {
            get { return (bool?)this["GIZLITUTULSUNMU"]; }
            set { this["GIZLITUTULSUNMU"] = value; }
        }

        public MuayeneGirisCevapDVO muayeneGirisCevapDVO
        {
            get { return (MuayeneGirisCevapDVO)((ITTObject)this).GetParent("MUAYENEGIRISCEVAPDVO"); }
            set { this["MUAYENEGIRISCEVAPDVO"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected MuayeneGirisDVO(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected MuayeneGirisDVO(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected MuayeneGirisDVO(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected MuayeneGirisDVO(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected MuayeneGirisDVO(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "MUAYENEGIRISDVO", dataRow) { }
        protected MuayeneGirisDVO(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "MUAYENEGIRISDVO", dataRow, isImported) { }
        public MuayeneGirisDVO(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public MuayeneGirisDVO(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public MuayeneGirisDVO() : base() { }

    }
}