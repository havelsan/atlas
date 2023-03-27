
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="EkokardiografiFormObject")] 

    /// <summary>
    /// Ekokardiografi Türünde Manipulasyonların Ortak Objesi
    /// </summary>
    public  partial class EkokardiografiFormObject : ManipulationFormBaseObject
    {
        public class EkokardiografiFormObjectList : TTObjectCollection<EkokardiografiFormObject> { }
                    
        public class ChildEkokardiografiFormObjectCollection : TTObject.TTChildObjectCollection<EkokardiografiFormObject>
        {
            public ChildEkokardiografiFormObjectCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildEkokardiografiFormObjectCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
    /// <summary>
    /// Kalp Hızı
    /// </summary>
        public string KalpHizi
        {
            get { return (string)this["KALPHIZI"]; }
            set { this["KALPHIZI"] = value; }
        }

    /// <summary>
    /// Ritim
    /// </summary>
        public string Ritim
        {
            get { return (string)this["RITIM"]; }
            set { this["RITIM"] = value; }
        }

    /// <summary>
    /// LV Segment Hareketleri
    /// </summary>
        public object LVSegmentHareket
        {
            get { return (object)this["LVSEGMENTHAREKET"]; }
            set { this["LVSEGMENTHAREKET"] = value; }
        }

        public object PerikartOzellik
        {
            get { return (object)this["PERIKARTOZELLIK"]; }
            set { this["PERIKARTOZELLIK"] = value; }
        }

        public object EkoSonuc
        {
            get { return (object)this["EKOSONUC"]; }
            set { this["EKOSONUC"] = value; }
        }

    /// <summary>
    /// Boy
    /// </summary>
        public string Boy
        {
            get { return (string)this["BOY"]; }
            set { this["BOY"] = value; }
        }

    /// <summary>
    /// Kilo
    /// </summary>
        public string Kilo
        {
            get { return (string)this["KILO"]; }
            set { this["KILO"] = value; }
        }

        virtual protected void CreateMitralKapakBulgularCollection()
        {
            _MitralKapakBulgular = new MitralKapakBulgu.ChildMitralKapakBulguCollection(this, new Guid("597c9ea9-2a84-4a94-b85d-b3cb80800710"));
            ((ITTChildObjectCollection)_MitralKapakBulgular).GetChildren();
        }

        protected MitralKapakBulgu.ChildMitralKapakBulguCollection _MitralKapakBulgular = null;
        public MitralKapakBulgu.ChildMitralKapakBulguCollection MitralKapakBulgular
        {
            get
            {
                if (_MitralKapakBulgular == null)
                    CreateMitralKapakBulgularCollection();
                return _MitralKapakBulgular;
            }
        }

        virtual protected void CreateAortKapakBulgularCollection()
        {
            _AortKapakBulgular = new AortKapakBulgu.ChildAortKapakBulguCollection(this, new Guid("add34c91-c6ab-47ea-ba0a-f9e365553a9c"));
            ((ITTChildObjectCollection)_AortKapakBulgular).GetChildren();
        }

        protected AortKapakBulgu.ChildAortKapakBulguCollection _AortKapakBulgular = null;
        public AortKapakBulgu.ChildAortKapakBulguCollection AortKapakBulgular
        {
            get
            {
                if (_AortKapakBulgular == null)
                    CreateAortKapakBulgularCollection();
                return _AortKapakBulgular;
            }
        }

        virtual protected void CreateTrikuspitKapakBulgularCollection()
        {
            _TrikuspitKapakBulgular = new TrikuspitKapakBulgu.ChildTrikuspitKapakBulguCollection(this, new Guid("cca399e2-ece8-41bf-b437-c2a1660acef7"));
            ((ITTChildObjectCollection)_TrikuspitKapakBulgular).GetChildren();
        }

        protected TrikuspitKapakBulgu.ChildTrikuspitKapakBulguCollection _TrikuspitKapakBulgular = null;
        public TrikuspitKapakBulgu.ChildTrikuspitKapakBulguCollection TrikuspitKapakBulgular
        {
            get
            {
                if (_TrikuspitKapakBulgular == null)
                    CreateTrikuspitKapakBulgularCollection();
                return _TrikuspitKapakBulgular;
            }
        }

        virtual protected void CreatePulmonerKapakBulgularCollection()
        {
            _PulmonerKapakBulgular = new PulmonerKapakBulgu.ChildPulmonerKapakBulguCollection(this, new Guid("7f11566a-735e-469e-be6a-37a376a56d63"));
            ((ITTChildObjectCollection)_PulmonerKapakBulgular).GetChildren();
        }

        protected PulmonerKapakBulgu.ChildPulmonerKapakBulguCollection _PulmonerKapakBulgular = null;
        public PulmonerKapakBulgu.ChildPulmonerKapakBulguCollection PulmonerKapakBulgular
        {
            get
            {
                if (_PulmonerKapakBulgular == null)
                    CreatePulmonerKapakBulgularCollection();
                return _PulmonerKapakBulgular;
            }
        }

        virtual protected void CreateEkokardiografiBulgularCollection()
        {
            _EkokardiografiBulgular = new EkokardiografiBulgu.ChildEkokardiografiBulguCollection(this, new Guid("d4c5c431-caeb-448f-b038-c2ec7bc45db2"));
            ((ITTChildObjectCollection)_EkokardiografiBulgular).GetChildren();
        }

        protected EkokardiografiBulgu.ChildEkokardiografiBulguCollection _EkokardiografiBulgular = null;
        public EkokardiografiBulgu.ChildEkokardiografiBulguCollection EkokardiografiBulgular
        {
            get
            {
                if (_EkokardiografiBulgular == null)
                    CreateEkokardiografiBulgularCollection();
                return _EkokardiografiBulgular;
            }
        }

        protected EkokardiografiFormObject(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected EkokardiografiFormObject(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected EkokardiografiFormObject(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected EkokardiografiFormObject(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected EkokardiografiFormObject(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "EKOKARDIOGRAFIFORMOBJECT", dataRow) { }
        protected EkokardiografiFormObject(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "EKOKARDIOGRAFIFORMOBJECT", dataRow, isImported) { }
        public EkokardiografiFormObject(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public EkokardiografiFormObject(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public EkokardiografiFormObject() : base() { }

    }
}