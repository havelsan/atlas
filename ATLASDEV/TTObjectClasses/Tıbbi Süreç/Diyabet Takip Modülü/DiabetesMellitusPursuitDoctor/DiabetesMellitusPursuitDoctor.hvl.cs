
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="DiabetesMellitusPursuitDoctor")] 

    /// <summary>
    /// Diabet Doktor Bilgileri
    /// </summary>
    public  partial class DiabetesMellitusPursuitDoctor : TTObject
    {
        public class DiabetesMellitusPursuitDoctorList : TTObjectCollection<DiabetesMellitusPursuitDoctor> { }
                    
        public class ChildDiabetesMellitusPursuitDoctorCollection : TTObject.TTChildObjectCollection<DiabetesMellitusPursuitDoctor>
        {
            public ChildDiabetesMellitusPursuitDoctorCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildDiabetesMellitusPursuitDoctorCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
    /// <summary>
    /// Doktor tescil numarası
    /// </summary>
        public string drTescilNo
        {
            get { return (string)this["DRTESCILNO"]; }
            set { this["DRTESCILNO"] = value; }
        }

    /// <summary>
    /// Doktor branş
    /// </summary>
        public string drBransKodu
        {
            get { return (string)this["DRBRANSKODU"]; }
            set { this["DRBRANSKODU"] = value; }
        }

    /// <summary>
    /// DM Eğitim almış Mı
    /// </summary>
        public EvetHayirDurumEnum? dmEgitimiAlmisMi
        {
            get { return (EvetHayirDurumEnum?)(int?)this["DMEGITIMIALMISMI"]; }
            set { this["DMEGITIMIALMISMI"] = value; }
        }

        public DiabetesMellitusPursuit DiabetesMellitusPursuit
        {
            get { return (DiabetesMellitusPursuit)((ITTObject)this).GetParent("DIABETESMELLITUSPURSUIT"); }
            set { this["DIABETESMELLITUSPURSUIT"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public SpecialityDefinition BransKodu
        {
            get { return (SpecialityDefinition)((ITTObject)this).GetParent("BRANSKODU"); }
            set { this["BRANSKODU"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public ResUser Doktor
        {
            get { return (ResUser)((ITTObject)this).GetParent("DOKTOR"); }
            set { this["DOKTOR"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected DiabetesMellitusPursuitDoctor(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected DiabetesMellitusPursuitDoctor(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected DiabetesMellitusPursuitDoctor(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected DiabetesMellitusPursuitDoctor(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected DiabetesMellitusPursuitDoctor(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "DIABETESMELLITUSPURSUITDOCTOR", dataRow) { }
        protected DiabetesMellitusPursuitDoctor(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "DIABETESMELLITUSPURSUITDOCTOR", dataRow, isImported) { }
        public DiabetesMellitusPursuitDoctor(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public DiabetesMellitusPursuitDoctor(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public DiabetesMellitusPursuitDoctor() : base() { }

    }
}