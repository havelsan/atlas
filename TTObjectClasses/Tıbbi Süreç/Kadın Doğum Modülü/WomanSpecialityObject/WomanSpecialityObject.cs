
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
    public partial class WomanSpecialityObject : SpecialityBasedObject
    {
        #region Methods
        public WomanSpecialityObject(PhysicianApplication physicianApplication) :this(physicianApplication.ObjectContext)
        {
            var context = physicianApplication.ObjectContext;
            Gynecology = new Gynecology(context);
            //this.Infertility = new Infertility(context);
            PhysicianApplication  = physicianApplication;

          var womanSpecialityObjectList = WomanSpecialityObject.GetWomanSpecialityObjectByPatient(context, physicianApplication.Episode.Patient.ObjectID);
            if (womanSpecialityObjectList.Count > 1) //GetWomanSpecialityObjectByPatient order by desc şeklinde çeklidiği için ilki alınıyor
            {
                var oldWomanSpecialityObject = womanSpecialityObjectList[1];
                Abortion = oldWomanSpecialityObject.Abortion;
                DC = oldWomanSpecialityObject.DC;
                DegreeOfRelationship = oldWomanSpecialityObject.DegreeOfRelationship;
                HusbandBloodGroup = oldWomanSpecialityObject.HusbandBloodGroup;
                HusbandFullName = oldWomanSpecialityObject.HusbandFullName;
                LivingBabies = oldWomanSpecialityObject.LivingBabies;
                MarriageDate = oldWomanSpecialityObject.MarriageDate;
                NumberOfPregnancy  = oldWomanSpecialityObject.NumberOfPregnancy;
                Parity = oldWomanSpecialityObject.Parity;
                RhIncompatibility = oldWomanSpecialityObject.RhIncompatibility;
                WomanBloodGroup = oldWomanSpecialityObject.WomanBloodGroup;
            }
        }

        #endregion Methods
    }
}