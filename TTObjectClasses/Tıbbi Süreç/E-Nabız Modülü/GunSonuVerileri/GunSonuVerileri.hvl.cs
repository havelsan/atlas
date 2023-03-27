
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="GunSonuVerileri")] 

    public  partial class GunSonuVerileri : TTObject
    {
        public class GunSonuVerileriList : TTObjectCollection<GunSonuVerileri> { }
                    
        public class ChildGunSonuVerileriCollection : TTObject.TTChildObjectCollection<GunSonuVerileri>
        {
            public ChildGunSonuVerileriCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildGunSonuVerileriCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        public static BindingList<GunSonuVerileri> GetGunSonuByDate(TTObjectContext objectContext, DateTime CURRENTDATE)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["GUNSONUVERILERI"].QueryDefs["GetGunSonuByDate"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("CURRENTDATE", CURRENTDATE);

            return ((ITTQuery)objectContext).QueryObjects<GunSonuVerileri>(queryDef, paramList);
        }

        public DateTime? GunSonuTarih
        {
            get { return (DateTime?)this["GUNSONUTARIH"]; }
            set { this["GUNSONUTARIH"] = value; }
        }

    /// <summary>
    /// Gün sonu parametresinin kodu
    /// </summary>
        public int? GunSonuKodu
        {
            get { return (int?)this["GUNSONUKODU"]; }
            set { this["GUNSONUKODU"] = value; }
        }

    /// <summary>
    /// Gün sonu parametresinin değeri
    /// </summary>
        public int? GunSonuSayi
        {
            get { return (int?)this["GUNSONUSAYI"]; }
            set { this["GUNSONUSAYI"] = value; }
        }

        protected GunSonuVerileri(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected GunSonuVerileri(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected GunSonuVerileri(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected GunSonuVerileri(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected GunSonuVerileri(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "GUNSONUVERILERI", dataRow) { }
        protected GunSonuVerileri(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "GUNSONUVERILERI", dataRow, isImported) { }
        public GunSonuVerileri(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public GunSonuVerileri(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public GunSonuVerileri() : base() { }

    }
}