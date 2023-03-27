
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="MedicalInfoAllergies")] 

    public  partial class MedicalInfoAllergies : TTObject
    {
        public class MedicalInfoAllergiesList : TTObjectCollection<MedicalInfoAllergies> { }
                    
        public class ChildMedicalInfoAllergiesCollection : TTObject.TTChildObjectCollection<MedicalInfoAllergies>
        {
            public ChildMedicalInfoAllergiesCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildMedicalInfoAllergiesCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        public string OtherAllergies
        {
            get { return (string)this["OTHERALLERGIES"]; }
            set { this["OTHERALLERGIES"] = value; }
        }

        virtual protected void CreateMedicalInfoFoodAllergiesCollection()
        {
            _MedicalInfoFoodAllergies = new MedicalInfoFoodAllergies.ChildMedicalInfoFoodAllergiesCollection(this, new Guid("8108ce02-c7da-4bd7-84fc-32441a79f582"));
            ((ITTChildObjectCollection)_MedicalInfoFoodAllergies).GetChildren();
        }

        protected MedicalInfoFoodAllergies.ChildMedicalInfoFoodAllergiesCollection _MedicalInfoFoodAllergies = null;
        public MedicalInfoFoodAllergies.ChildMedicalInfoFoodAllergiesCollection MedicalInfoFoodAllergies
        {
            get
            {
                if (_MedicalInfoFoodAllergies == null)
                    CreateMedicalInfoFoodAllergiesCollection();
                return _MedicalInfoFoodAllergies;
            }
        }

        virtual protected void CreateMedicalInfoDrugAllergiesCollection()
        {
            _MedicalInfoDrugAllergies = new MedicalInfoDrugAllergies.ChildMedicalInfoDrugAllergiesCollection(this, new Guid("20774fe7-eec3-4983-ab91-8cf8e905b97c"));
            ((ITTChildObjectCollection)_MedicalInfoDrugAllergies).GetChildren();
        }

        protected MedicalInfoDrugAllergies.ChildMedicalInfoDrugAllergiesCollection _MedicalInfoDrugAllergies = null;
        public MedicalInfoDrugAllergies.ChildMedicalInfoDrugAllergiesCollection MedicalInfoDrugAllergies
        {
            get
            {
                if (_MedicalInfoDrugAllergies == null)
                    CreateMedicalInfoDrugAllergiesCollection();
                return _MedicalInfoDrugAllergies;
            }
        }

        protected MedicalInfoAllergies(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected MedicalInfoAllergies(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected MedicalInfoAllergies(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected MedicalInfoAllergies(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected MedicalInfoAllergies(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "MEDICALINFOALLERGIES", dataRow) { }
        protected MedicalInfoAllergies(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "MEDICALINFOALLERGIES", dataRow, isImported) { }
        public MedicalInfoAllergies(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public MedicalInfoAllergies(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public MedicalInfoAllergies() : base() { }

    }
}