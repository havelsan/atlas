
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="KuduzRiskliTemasAdres")] 

    public  partial class KuduzRiskliTemasAdres : TTObject
    {
        public class KuduzRiskliTemasAdresList : TTObjectCollection<KuduzRiskliTemasAdres> { }
                    
        public class ChildKuduzRiskliTemasAdresCollection : TTObject.TTChildObjectCollection<KuduzRiskliTemasAdres>
        {
            public ChildKuduzRiskliTemasAdresCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildKuduzRiskliTemasAdresCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        public string DisKapi
        {
            get { return (string)this["DISKAPI"]; }
            set { this["DISKAPI"] = value; }
        }

        public string IcKapi
        {
            get { return (string)this["ICKAPI"]; }
            set { this["ICKAPI"] = value; }
        }

        public SKRSAdresTipi SKRSAdresTipi
        {
            get { return (SKRSAdresTipi)((ITTObject)this).GetParent("SKRSADRESTIPI"); }
            set { this["SKRSADRESTIPI"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public SKRSBucakKodlari SKRSBucakKodlari
        {
            get { return (SKRSBucakKodlari)((ITTObject)this).GetParent("SKRSBUCAKKODLARI"); }
            set { this["SKRSBUCAKKODLARI"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public SKRSCSBMTipi SKRSCSBMTipi
        {
            get { return (SKRSCSBMTipi)((ITTObject)this).GetParent("SKRSCSBMTIPI"); }
            set { this["SKRSCSBMTIPI"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public SKRSIlceKodlari SKRSIlceKodlari
        {
            get { return (SKRSIlceKodlari)((ITTObject)this).GetParent("SKRSILCEKODLARI"); }
            set { this["SKRSILCEKODLARI"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public SKRSILKodlari SKRSILKodlari
        {
            get { return (SKRSILKodlari)((ITTObject)this).GetParent("SKRSILKODLARI"); }
            set { this["SKRSILKODLARI"] = (value==null ? null : (Guid?)value.ObjectID); }
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

        public KuduzRiskliTemasVeriSeti KuduzRiskliTemasVeriSeti
        {
            get { return (KuduzRiskliTemasVeriSeti)((ITTObject)this).GetParent("KUDUZRISKLITEMASVERISETI"); }
            set { this["KUDUZRISKLITEMASVERISETI"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected KuduzRiskliTemasAdres(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected KuduzRiskliTemasAdres(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected KuduzRiskliTemasAdres(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected KuduzRiskliTemasAdres(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected KuduzRiskliTemasAdres(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "KUDUZRISKLITEMASADRES", dataRow) { }
        protected KuduzRiskliTemasAdres(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "KUDUZRISKLITEMASADRES", dataRow, isImported) { }
        public KuduzRiskliTemasAdres(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public KuduzRiskliTemasAdres(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public KuduzRiskliTemasAdres() : base() { }

    }
}