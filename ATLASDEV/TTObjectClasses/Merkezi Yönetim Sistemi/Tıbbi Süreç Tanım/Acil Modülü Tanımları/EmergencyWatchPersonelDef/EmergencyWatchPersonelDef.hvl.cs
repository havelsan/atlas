
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="EmergencyWatchPersonelDef")] 

    /// <summary>
    /// Nöbet Çizelgesi Tanımı
    /// </summary>
    public  partial class EmergencyWatchPersonelDef : TTDefinitionSet
    {
        public class EmergencyWatchPersonelDefList : TTObjectCollection<EmergencyWatchPersonelDef> { }
                    
        public class ChildEmergencyWatchPersonelDefCollection : TTObject.TTChildObjectCollection<EmergencyWatchPersonelDef>
        {
            public ChildEmergencyWatchPersonelDefCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildEmergencyWatchPersonelDefCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
    /// <summary>
    /// Nöbetçi Personel
    /// </summary>
        public string NobetPersonel
        {
            get { return (string)this["NOBETPERSONEL"]; }
            set { this["NOBETPERSONEL"] = value; }
        }

    /// <summary>
    /// Başlangıç Tarihi
    /// </summary>
        public DateTime? BaslangicTarihi
        {
            get { return (DateTime?)this["BASLANGICTARIHI"]; }
            set { this["BASLANGICTARIHI"] = value; }
        }

    /// <summary>
    /// Bitiş Tarihi
    /// </summary>
        public DateTime? BitisTarih
        {
            get { return (DateTime?)this["BITISTARIH"]; }
            set { this["BITISTARIH"] = value; }
        }

    /// <summary>
    /// Bildirildi
    /// </summary>
        public bool? Bildirildi
        {
            get { return (bool?)this["BILDIRILDI"]; }
            set { this["BILDIRILDI"] = value; }
        }

    /// <summary>
    /// İcap
    /// </summary>
        public bool? Icapci
        {
            get { return (bool?)this["ICAPCI"]; }
            set { this["ICAPCI"] = value; }
        }

        public ResUser ResUser
        {
            get { return (ResUser)((ITTObject)this).GetParent("RESUSER"); }
            set { this["RESUSER"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public EmergencyWatchDef EmergencyWatchDef
        {
            get { return (EmergencyWatchDef)((ITTObject)this).GetParent("EMERGENCYWATCHDEF"); }
            set { this["EMERGENCYWATCHDEF"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected EmergencyWatchPersonelDef(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected EmergencyWatchPersonelDef(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected EmergencyWatchPersonelDef(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected EmergencyWatchPersonelDef(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected EmergencyWatchPersonelDef(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "EMERGENCYWATCHPERSONELDEF", dataRow) { }
        protected EmergencyWatchPersonelDef(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "EMERGENCYWATCHPERSONELDEF", dataRow, isImported) { }
        public EmergencyWatchPersonelDef(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public EmergencyWatchPersonelDef(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public EmergencyWatchPersonelDef() : base() { }

    }
}