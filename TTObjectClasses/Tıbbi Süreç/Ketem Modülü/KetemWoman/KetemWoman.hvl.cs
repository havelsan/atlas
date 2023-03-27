
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="KetemWoman")] 

    public  partial class KetemWoman : Ketem
    {
        public class KetemWomanList : TTObjectCollection<KetemWoman> { }
                    
        public class ChildKetemWomanCollection : TTObject.TTChildObjectCollection<KetemWoman>
        {
            public ChildKetemWomanCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildKetemWomanCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
    /// <summary>
    /// Menstrüel Siklus
    /// </summary>
        public string MenstrualCycle
        {
            get { return (string)this["MENSTRUALCYCLE"]; }
            set { this["MENSTRUALCYCLE"] = value; }
        }

    /// <summary>
    /// Menarş Yaşı
    /// </summary>
        public int? MenarcheAge
        {
            get { return (int?)this["MENARCHEAGE"]; }
            set { this["MENARCHEAGE"] = value; }
        }

    /// <summary>
    /// Menopoz Yaşı
    /// </summary>
        public int? MenopauseAge
        {
            get { return (int?)this["MENOPAUSEAGE"]; }
            set { this["MENOPAUSEAGE"] = value; }
        }

    /// <summary>
    /// Son Adet Tarihi
    /// </summary>
        public DateTime? LastMenstruationDate
        {
            get { return (DateTime?)this["LASTMENSTRUATIONDATE"]; }
            set { this["LASTMENSTRUATIONDATE"] = value; }
        }

    /// <summary>
    /// İlk Evlilik Yaşı
    /// </summary>
        public int? FirstMarriageAge
        {
            get { return (int?)this["FIRSTMARRIAGEAGE"]; }
            set { this["FIRSTMARRIAGEAGE"] = value; }
        }

    /// <summary>
    /// İlk Gebelik Yaşı
    /// </summary>
        public int? FirstGestationalAge
        {
            get { return (int?)this["FIRSTGESTATIONALAGE"]; }
            set { this["FIRSTGESTATIONALAGE"] = value; }
        }

    /// <summary>
    /// Gebelik Sayısı
    /// </summary>
        public int? GestationalNumber
        {
            get { return (int?)this["GESTATIONALNUMBER"]; }
            set { this["GESTATIONALNUMBER"] = value; }
        }

    /// <summary>
    /// Canlı Doğum Sayısı
    /// </summary>
        public int? LiveBirthNumber
        {
            get { return (int?)this["LIVEBIRTHNUMBER"]; }
            set { this["LIVEBIRTHNUMBER"] = value; }
        }

        public SKRSKullanilanAilePlanlamasiAPYontemi AilePlanlamasiAPYontemi
        {
            get { return (SKRSKullanilanAilePlanlamasiAPYontemi)((ITTObject)this).GetParent("AILEPLANLAMASIAPYONTEMI"); }
            set { this["AILEPLANLAMASIAPYONTEMI"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected KetemWoman(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected KetemWoman(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected KetemWoman(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected KetemWoman(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected KetemWoman(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "KETEMWOMAN", dataRow) { }
        protected KetemWoman(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "KETEMWOMAN", dataRow, isImported) { }
        public KetemWoman(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public KetemWoman(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public KetemWoman() : base() { }

    }
}