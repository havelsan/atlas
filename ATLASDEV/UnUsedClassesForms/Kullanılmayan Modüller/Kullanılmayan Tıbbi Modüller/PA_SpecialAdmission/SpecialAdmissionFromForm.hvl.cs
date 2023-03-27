
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
using System.Windows.Forms;
using TTVisual;
namespace TTFormClasses
{
    public partial class SpecialAdmissionFrom : PatientAdmissionForm
    {
    /// <summary>
    /// Özel Statülü Hak Sahibi  
    /// </summary>
        protected TTObjectClasses.PA_SpecialAdmission _PA_SpecialAdmission
        {
            get { return (TTObjectClasses.PA_SpecialAdmission)_ttObject; }
        }

        protected ITTGroupBox FamilyInfo;
        protected ITTLabel labelHeadOfFamilyName;
        protected ITTTextBox HeadOfFamilyName;
        protected ITTLabel ttlabel5;
        protected ITTMaskedTextBox HeadOfFamtxt;
        protected ITTObjectListBox Relationship;
        protected ITTLabel labelRelationship;
        override protected void InitializeControls()
        {
            FamilyInfo = (ITTGroupBox)AddControl(new Guid("3471a3ec-7c50-4731-a8ba-9528e50e094a"));
            labelHeadOfFamilyName = (ITTLabel)AddControl(new Guid("f142f08e-fa98-4720-8abd-1b1970226f99"));
            HeadOfFamilyName = (ITTTextBox)AddControl(new Guid("aec7f140-64a0-443d-9daa-408223b62cc8"));
            ttlabel5 = (ITTLabel)AddControl(new Guid("10a026b3-ac89-4859-9d0d-46a03f502049"));
            HeadOfFamtxt = (ITTMaskedTextBox)AddControl(new Guid("0581ac9a-6536-4af8-af10-30a171e1fccd"));
            Relationship = (ITTObjectListBox)AddControl(new Guid("fe04e790-2bed-44bc-8edf-c5d4cb9bc378"));
            labelRelationship = (ITTLabel)AddControl(new Guid("6c9b5290-7330-4f11-83a9-b3c085b54a07"));
            base.InitializeControls();
        }

        public SpecialAdmissionFrom() : base("PA_SPECIALADMISSION", "SpecialAdmissionFrom")
        {
        }

        protected SpecialAdmissionFrom(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}