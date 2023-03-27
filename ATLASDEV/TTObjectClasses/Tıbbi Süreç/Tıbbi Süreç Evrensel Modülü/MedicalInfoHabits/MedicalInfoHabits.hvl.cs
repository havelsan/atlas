
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="MedicalInfoHabits")] 

    public  partial class MedicalInfoHabits : TTObject
    {
        public class MedicalInfoHabitsList : TTObjectCollection<MedicalInfoHabits> { }
                    
        public class ChildMedicalInfoHabitsCollection : TTObject.TTChildObjectCollection<MedicalInfoHabits>
        {
            public ChildMedicalInfoHabitsCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildMedicalInfoHabitsCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        public bool? Cigarette
        {
            get { return (bool?)this["CIGARETTE"]; }
            set { this["CIGARETTE"] = value; }
        }

        public bool? Alcohol
        {
            get { return (bool?)this["ALCOHOL"]; }
            set { this["ALCOHOL"] = value; }
        }

        public bool? Tea
        {
            get { return (bool?)this["TEA"]; }
            set { this["TEA"] = value; }
        }

        public bool? Coffee
        {
            get { return (bool?)this["COFFEE"]; }
            set { this["COFFEE"] = value; }
        }

        public bool? Other
        {
            get { return (bool?)this["OTHER"]; }
            set { this["OTHER"] = value; }
        }

        public string Description
        {
            get { return (string)this["DESCRIPTION"]; }
            set { this["DESCRIPTION"] = value; }
        }

    /// <summary>
    /// Madde Kullanımı
    /// </summary>
        public bool? Drug
        {
            get { return (bool?)this["DRUG"]; }
            set { this["DRUG"] = value; }
        }

        public SKRSSigaraKullanimi CigaretteUsageFrequency
        {
            get { return (SKRSSigaraKullanimi)((ITTObject)this).GetParent("CIGARETTEUSAGEFREQUENCY"); }
            set { this["CIGARETTEUSAGEFREQUENCY"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public SKRSAlkolKullanimi AlcoholUsageFrequency
        {
            get { return (SKRSAlkolKullanimi)((ITTObject)this).GetParent("ALCOHOLUSAGEFREQUENCY"); }
            set { this["ALCOHOLUSAGEFREQUENCY"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public SKRSMaddeKullanimi DrugUsageFrequency
        {
            get { return (SKRSMaddeKullanimi)((ITTObject)this).GetParent("DRUGUSAGEFREQUENCY"); }
            set { this["DRUGUSAGEFREQUENCY"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        virtual protected void CreateMedicalInformationCollection()
        {
            _MedicalInformation = new MedicalInformation.ChildMedicalInformationCollection(this, new Guid("2f926297-06f3-4347-bf1e-511b755a4cce"));
            ((ITTChildObjectCollection)_MedicalInformation).GetChildren();
        }

        protected MedicalInformation.ChildMedicalInformationCollection _MedicalInformation = null;
        public MedicalInformation.ChildMedicalInformationCollection MedicalInformation
        {
            get
            {
                if (_MedicalInformation == null)
                    CreateMedicalInformationCollection();
                return _MedicalInformation;
            }
        }

        protected MedicalInfoHabits(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected MedicalInfoHabits(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected MedicalInfoHabits(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected MedicalInfoHabits(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected MedicalInfoHabits(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "MEDICALINFOHABITS", dataRow) { }
        protected MedicalInfoHabits(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "MEDICALINFOHABITS", dataRow, isImported) { }
        public MedicalInfoHabits(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public MedicalInfoHabits(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public MedicalInfoHabits() : base() { }

    }
}