
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
    public partial class KvcRiskScoreForm : TTForm
    {
    /// <summary>
    /// KVC Risk Skorlama
    /// </summary>
        protected TTObjectClasses.KvcRiskScore _KvcRiskScore
        {
            get { return (TTObjectClasses.KvcRiskScore)_ttObject; }
        }

        protected ITTCheckBox PulmonaryHypertension;
        protected ITTCheckBox IsWoman;
        protected ITTLabel labelEntryDate;
        protected ITTDateTimePicker EntryDate;
        protected ITTLabel labelTotalScore;
        protected ITTTextBox TotalScore;
        protected ITTTextBox AgePoint;
        protected ITTCheckBox ThoracicAorta;
        protected ITTCheckBox PostMIVSD;
        protected ITTCheckBox LVLess30;
        protected ITTCheckBox LV30to50;
        protected ITTCheckBox KidneyFunction;
        protected ITTCheckBox KidneyFailure;
        protected ITTCheckBox KahRaspiration;
        protected ITTCheckBox KahLung;
        protected ITTCheckBox EkstrakardiyakArteriopati;
        protected ITTCheckBox DiabetesMellitus;
        protected ITTCheckBox CriticalPreop;
        protected ITTCheckBox CardiacOperation;
        protected ITTLabel labelAgePoint;
        protected ITTCheckBox ActiveEndocarditis;
        override protected void InitializeControls()
        {
            PulmonaryHypertension = (ITTCheckBox)AddControl(new Guid("93a9cbf5-cb95-490a-a302-f4da17b36c8c"));
            IsWoman = (ITTCheckBox)AddControl(new Guid("5a9d74ea-4d89-42e2-b71e-90312d26e5cb"));
            labelEntryDate = (ITTLabel)AddControl(new Guid("c97ac41b-5637-44fd-80cf-d9b5d344506d"));
            EntryDate = (ITTDateTimePicker)AddControl(new Guid("c88d5a46-10ce-4664-874d-da132672c866"));
            labelTotalScore = (ITTLabel)AddControl(new Guid("aa66e7ac-91ed-4e86-9792-93b749f2b995"));
            TotalScore = (ITTTextBox)AddControl(new Guid("f83cb823-21aa-4f87-85ff-941fc76b0c8e"));
            AgePoint = (ITTTextBox)AddControl(new Guid("e4c36274-9c52-47c6-9f9c-751e51ca86c7"));
            ThoracicAorta = (ITTCheckBox)AddControl(new Guid("b20581cb-39cd-4e3a-b043-ae17cdc6ff8a"));
            PostMIVSD = (ITTCheckBox)AddControl(new Guid("74918b54-8310-4ebc-b627-68bb6e6eed5d"));
            LVLess30 = (ITTCheckBox)AddControl(new Guid("3f0618a0-8303-4421-8ca2-140168ae71f7"));
            LV30to50 = (ITTCheckBox)AddControl(new Guid("5ea345ec-2b66-473f-b355-25f0c73bc685"));
            KidneyFunction = (ITTCheckBox)AddControl(new Guid("24cc0939-5aa2-4e74-8c4d-ea60b7db088c"));
            KidneyFailure = (ITTCheckBox)AddControl(new Guid("1af4842c-523d-464c-b748-51c8d40f2a22"));
            KahRaspiration = (ITTCheckBox)AddControl(new Guid("b6e00fb6-98e9-40bc-9856-a70828016e3b"));
            KahLung = (ITTCheckBox)AddControl(new Guid("0444782e-2f1d-45be-85cd-b4933c67df67"));
            EkstrakardiyakArteriopati = (ITTCheckBox)AddControl(new Guid("06b06a20-3249-4ec6-bd5d-3a0b88a9eb89"));
            DiabetesMellitus = (ITTCheckBox)AddControl(new Guid("c07f32e0-1d9b-4961-9842-8ebf5fafe84b"));
            CriticalPreop = (ITTCheckBox)AddControl(new Guid("81defc64-0cd5-4b7f-bd69-2897b65f38ee"));
            CardiacOperation = (ITTCheckBox)AddControl(new Guid("ed9c8e1f-675e-48aa-a3de-d553441d2bb1"));
            labelAgePoint = (ITTLabel)AddControl(new Guid("ab3cafa1-0187-4f1d-9223-620387c36a87"));
            ActiveEndocarditis = (ITTCheckBox)AddControl(new Guid("64420b6a-85c0-461f-bb3a-a6954c166546"));
            base.InitializeControls();
        }

        public KvcRiskScoreForm() : base("KVCRISKSCORE", "KvcRiskScoreForm")
        {
        }

        protected KvcRiskScoreForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}