
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
    public partial class NursingLegMeasurementForm : BaseNursingDataEntryForm
    {
    /// <summary>
    /// Bacak Ölçüm Takip Formu
    /// </summary>
        protected TTObjectClasses.NursingLegMeasurement _NursingLegMeasurement
        {
            get { return (TTObjectClasses.NursingLegMeasurement)_ttObject; }
        }

        protected ITTLabel labelActionDate;
        protected ITTDateTimePicker ActionDate;
        protected ITTLabel ttlabel1;
        protected ITTLabel ttlabel6;
        protected ITTLabel ttlabel5;
        protected ITTLabel labelUpperLeftLeg;
        protected ITTTextBox UpperLeftLeg;
        protected ITTTextBox LowerLeftLeg;
        protected ITTTextBox UpperRightLeg;
        protected ITTTextBox LowerRightLeg;
        protected ITTLabel labelLowerLeftLeg;
        protected ITTLabel labelUpperRightLeg;
        protected ITTLabel labelLowerRightLeg;
        protected ITTLabel ttlabel2;
        protected ITTLabel ttlabel3;
        protected ITTLabel ttlabel4;
        override protected void InitializeControls()
        {
            labelActionDate = (ITTLabel)AddControl(new Guid("161997cd-4af8-4aae-abef-27fb34a97bfd"));
            ActionDate = (ITTDateTimePicker)AddControl(new Guid("053bf236-1e7b-4aa0-a2a5-90a45fb6083b"));
            ttlabel1 = (ITTLabel)AddControl(new Guid("838fa6bd-4996-4d00-83fe-0e4280fab24e"));
            ttlabel6 = (ITTLabel)AddControl(new Guid("50954778-2079-4557-9b12-bd07d6d65739"));
            ttlabel5 = (ITTLabel)AddControl(new Guid("30725f6a-0165-4508-871b-b9aac63f6759"));
            labelUpperLeftLeg = (ITTLabel)AddControl(new Guid("f0953e75-f7d4-4fa4-80fb-c4d20ef248a5"));
            UpperLeftLeg = (ITTTextBox)AddControl(new Guid("37bd60f2-d882-40ff-8644-a12835b480a3"));
            LowerLeftLeg = (ITTTextBox)AddControl(new Guid("dc6af08a-7e58-4f93-a624-47adc80fb098"));
            UpperRightLeg = (ITTTextBox)AddControl(new Guid("761d95c2-8fdd-4a17-b8aa-45817d3a9f91"));
            LowerRightLeg = (ITTTextBox)AddControl(new Guid("6b4d0b19-f9c9-45e4-b02a-732c9afa6a66"));
            labelLowerLeftLeg = (ITTLabel)AddControl(new Guid("1953dd46-3072-4a92-aa62-255d043e04b5"));
            labelUpperRightLeg = (ITTLabel)AddControl(new Guid("98015107-b886-43d3-8ef7-d432338eae06"));
            labelLowerRightLeg = (ITTLabel)AddControl(new Guid("7a9abba5-b769-44ba-ad8f-29cdb44522af"));
            ttlabel2 = (ITTLabel)AddControl(new Guid("c4a7ef68-936a-44cb-b96b-26c7bb4a19ab"));
            ttlabel3 = (ITTLabel)AddControl(new Guid("487ccf96-aee6-46bf-8d31-de3f223032b8"));
            ttlabel4 = (ITTLabel)AddControl(new Guid("6172ebcb-b065-4172-b1c6-638c95251c03"));
            base.InitializeControls();
        }

        public NursingLegMeasurementForm() : base("NURSINGLEGMEASUREMENT", "NursingLegMeasurementForm")
        {
        }

        protected NursingLegMeasurementForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}