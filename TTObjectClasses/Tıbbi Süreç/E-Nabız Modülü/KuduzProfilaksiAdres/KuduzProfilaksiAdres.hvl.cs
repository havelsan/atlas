
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="KuduzProfilaksiAdres")] 

    /// <summary>
    /// Kuduz Profilaksi Bildirim Adres Bilgisi
    /// </summary>
    public  partial class KuduzProfilaksiAdres : TTObject
    {
        public class KuduzProfilaksiAdresList : TTObjectCollection<KuduzProfilaksiAdres> { }
                    
        public class ChildKuduzProfilaksiAdresCollection : TTObject.TTChildObjectCollection<KuduzProfilaksiAdres>
        {
            public ChildKuduzProfilaksiAdresCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildKuduzProfilaksiAdresCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        public string IcKapi
        {
            get { return (string)this["ICKAPI"]; }
            set { this["ICKAPI"] = value; }
        }

        public string DisKapi
        {
            get { return (string)this["DISKAPI"]; }
            set { this["DISKAPI"] = value; }
        }

        public KuduzProfilaksiVeriSeti KuduzProfilaksiVeriSeti
        {
            get { return (KuduzProfilaksiVeriSeti)((ITTObject)this).GetParent("KUDUZPROFILAKSIVERISETI"); }
            set { this["KUDUZPROFILAKSIVERISETI"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public SKRSAdresTipi SKRSAdresTipi
        {
            get { return (SKRSAdresTipi)((ITTObject)this).GetParent("SKRSADRESTIPI"); }
            set { this["SKRSADRESTIPI"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public SKRSILKodlari SKRSILKodlari
        {
            get { return (SKRSILKodlari)((ITTObject)this).GetParent("SKRSILKODLARI"); }
            set { this["SKRSILKODLARI"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public SKRSIlceKodlari SKRSIlceKodlari
        {
            get { return (SKRSIlceKodlari)((ITTObject)this).GetParent("SKRSILCEKODLARI"); }
            set { this["SKRSILCEKODLARI"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public SKRSCSBMTipi SKRSCSBMTipi
        {
            get { return (SKRSCSBMTipi)((ITTObject)this).GetParent("SKRSCSBMTIPI"); }
            set { this["SKRSCSBMTIPI"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public SKRSBucakKodlari SKRSBucakKodlari
        {
            get { return (SKRSBucakKodlari)((ITTObject)this).GetParent("SKRSBUCAKKODLARI"); }
            set { this["SKRSBUCAKKODLARI"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public SKRSKoyKodlari SKRSKoyKodlari
        {
            get { return (SKRSKoyKodlari)((ITTObject)this).GetParent("SKRSKOYKODLARI"); }
            set { this["SKRSKOYKODLARI"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public SKRSMahalleKodlari SKRSMahalleKodlari
        {
            get { return (SKRSMahalleKodlari)((ITTObject)this).GetParent("SKRSMAHALLEKODLARI"); }
            set { this["SKRSMAHALLEKODLARI"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected KuduzProfilaksiAdres(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected KuduzProfilaksiAdres(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected KuduzProfilaksiAdres(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected KuduzProfilaksiAdres(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected KuduzProfilaksiAdres(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "KUDUZPROFILAKSIADRES", dataRow) { }
        protected KuduzProfilaksiAdres(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "KUDUZPROFILAKSIADRES", dataRow, isImported) { }
        public KuduzProfilaksiAdres(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public KuduzProfilaksiAdres(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public KuduzProfilaksiAdres() : base() { }

    }
}