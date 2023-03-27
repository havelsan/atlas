
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="Infertility")] 

    public  partial class Infertility : TTObject
    {
        public class InfertilityList : TTObjectCollection<Infertility> { }
                    
        public class ChildInfertilityCollection : TTObject.TTChildObjectCollection<Infertility>
        {
            public ChildInfertilityCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildInfertilityCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
    /// <summary>
    /// Hirsutismus
    /// </summary>
        public string Hirsutism
        {
            get { return (string)this["HIRSUTISM"]; }
            set { this["HIRSUTISM"] = value; }
        }

    /// <summary>
    /// Tiroid
    /// </summary>
        public string Thyroid
        {
            get { return (string)this["THYROID"]; }
            set { this["THYROID"] = value; }
        }

    /// <summary>
    /// Vulva
    /// </summary>
        public string Vulva
        {
            get { return (string)this["VULVA"]; }
            set { this["VULVA"] = value; }
        }

    /// <summary>
    /// Vajina
    /// </summary>
        public string Vagina
        {
            get { return (string)this["VAGINA"]; }
            set { this["VAGINA"] = value; }
        }

    /// <summary>
    /// Uterus
    /// </summary>
        public string Uterus
        {
            get { return (string)this["UTERUS"]; }
            set { this["UTERUS"] = value; }
        }

    /// <summary>
    /// Serviks
    /// </summary>
        public string Cervix
        {
            get { return (string)this["CERVIX"]; }
            set { this["CERVIX"] = value; }
        }

    /// <summary>
    /// Candida
    /// </summary>
        public string Candida
        {
            get { return (string)this["CANDIDA"]; }
            set { this["CANDIDA"] = value; }
        }

    /// <summary>
    /// Chlamdydia
    /// </summary>
        public string Chlamdydia
        {
            get { return (string)this["CHLAMDYDIA"]; }
            set { this["CHLAMDYDIA"] = value; }
        }

    /// <summary>
    /// Bazal Ultrason Tarihi
    /// </summary>
        public DateTime? BasalUltrasoundDate
        {
            get { return (DateTime?)this["BASALULTRASOUNDDATE"]; }
            set { this["BASALULTRASOUNDDATE"] = value; }
        }

    /// <summary>
    /// Endometrium
    /// </summary>
        public string Endometrium
        {
            get { return (string)this["ENDOMETRIUM"]; }
            set { this["ENDOMETRIUM"] = value; }
        }

    /// <summary>
    /// Sol Over Hacmi
    /// </summary>
        public string LeftOvaryVolume
        {
            get { return (string)this["LEFTOVARYVOLUME"]; }
            set { this["LEFTOVARYVOLUME"] = value; }
        }

    /// <summary>
    /// Sağ Over Hacmi
    /// </summary>
        public string RightOvaryVolume
        {
            get { return (string)this["RIGHTOVARYVOLUME"]; }
            set { this["RIGHTOVARYVOLUME"] = value; }
        }

    /// <summary>
    /// Karar
    /// </summary>
        public string Decision
        {
            get { return (string)this["DECISION"]; }
            set { this["DECISION"] = value; }
        }

    /// <summary>
    /// Sekonder Sex Karakteri
    /// </summary>
        public string SecondarySexCharacter
        {
            get { return (string)this["SECONDARYSEXCHARACTER"]; }
            set { this["SECONDARYSEXCHARACTER"] = value; }
        }

        public Patient Patient
        {
            get { return (Patient)((ITTObject)this).GetParent("PATIENT"); }
            set { this["PATIENT"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        virtual protected void CreateWomanSpecialityObjectCollection()
        {
            _WomanSpecialityObject = new WomanSpecialityObject.ChildWomanSpecialityObjectCollection(this, new Guid("06483141-efa9-4771-881f-c3bfce447444"));
            ((ITTChildObjectCollection)_WomanSpecialityObject).GetChildren();
        }

        protected WomanSpecialityObject.ChildWomanSpecialityObjectCollection _WomanSpecialityObject = null;
        public WomanSpecialityObject.ChildWomanSpecialityObjectCollection WomanSpecialityObject
        {
            get
            {
                if (_WomanSpecialityObject == null)
                    CreateWomanSpecialityObjectCollection();
                return _WomanSpecialityObject;
            }
        }

        protected Infertility(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected Infertility(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected Infertility(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected Infertility(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected Infertility(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "INFERTILITY", dataRow) { }
        protected Infertility(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "INFERTILITY", dataRow, isImported) { }
        public Infertility(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public Infertility(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public Infertility() : base() { }

    }
}