
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
    /// <summary>
    /// Waterlow Bası Riski
    /// </summary>
    public partial class NursingWaterlowRiskForm : TTForm
    {
        protected TTObjectClasses.NursingWaterlowRisk _NursingWaterlowRisk
        {
            get { return (TTObjectClasses.NursingWaterlowRisk)_ttObject; }
        }

        protected ITTLabel labelSkinType;
        protected ITTObjectListBox SkinType;
        protected ITTLabel labelHeightSizeRate;
        protected ITTObjectListBox HeightSizeRate;
        protected ITTLabel labelDrugs;
        protected ITTObjectListBox Drugs;
        protected ITTLabel labelSex;
        protected ITTObjectListBox Sex;
        protected ITTLabel labelKontinans;
        protected ITTObjectListBox Kontinans;
        protected ITTLabel labelSurgerAndTrauma;
        protected ITTObjectListBox SurgerAndTrauma;
        protected ITTLabel labelAge;
        protected ITTObjectListBox Age;
        protected ITTLabel labelNeurologicalProblem;
        protected ITTObjectListBox NeurologicalProblem;
        protected ITTLabel labelAppetite;
        protected ITTObjectListBox Appetite;
        protected ITTLabel labelTextureMalnutrusyon;
        protected ITTObjectListBox TextureMalnutrusyon;
        protected ITTLabel labelMobilite;
        protected ITTObjectListBox Mobilite;
        protected ITTLabel labelRiskScore;
        protected ITTEnumComboBox RiskScore;
        protected ITTLabel labelActionDate;
        protected ITTDateTimePicker ActionDate;
        override protected void InitializeControls()
        {
            labelSkinType = (ITTLabel)AddControl(new Guid("312a7564-7952-4eef-8b66-f5a42e01f62d"));
            SkinType = (ITTObjectListBox)AddControl(new Guid("4183c373-ffe9-4e22-a3da-ed9435d5fb0d"));
            labelHeightSizeRate = (ITTLabel)AddControl(new Guid("8d274fe8-accb-4ea4-a1bc-72298fed5355"));
            HeightSizeRate = (ITTObjectListBox)AddControl(new Guid("a6fc1e11-6dd0-40b0-8db6-0d21862218a2"));
            labelDrugs = (ITTLabel)AddControl(new Guid("293cd97c-ebd9-4086-a70c-e02a4691db52"));
            Drugs = (ITTObjectListBox)AddControl(new Guid("d6d1c0c5-54ba-4aa8-b7f3-8241b0d53d24"));
            labelSex = (ITTLabel)AddControl(new Guid("17775170-d7c9-4c0d-a759-7251ce67a20f"));
            Sex = (ITTObjectListBox)AddControl(new Guid("97260947-2c73-40d1-866f-f4a8eee6f6be"));
            labelKontinans = (ITTLabel)AddControl(new Guid("f411c915-4c81-4d34-84ad-95230138415f"));
            Kontinans = (ITTObjectListBox)AddControl(new Guid("be46417d-5122-4346-8109-9b00e65b02fe"));
            labelSurgerAndTrauma = (ITTLabel)AddControl(new Guid("30616aaf-1522-45ac-80cc-5a34edcd98ce"));
            SurgerAndTrauma = (ITTObjectListBox)AddControl(new Guid("bc9baf63-f228-49e0-96f1-2a2ca52dca10"));
            labelAge = (ITTLabel)AddControl(new Guid("4b8a5ad7-7863-45bd-90cf-bbab7f20008e"));
            Age = (ITTObjectListBox)AddControl(new Guid("25e0c014-1d28-46c7-ab25-f6954c61f54f"));
            labelNeurologicalProblem = (ITTLabel)AddControl(new Guid("573fb9da-2501-498f-8e3a-c39e1f732715"));
            NeurologicalProblem = (ITTObjectListBox)AddControl(new Guid("8d41fe26-7fb5-4947-8e6c-66c162364f39"));
            labelAppetite = (ITTLabel)AddControl(new Guid("3c407d24-da8b-43e3-a124-4ef055b109d8"));
            Appetite = (ITTObjectListBox)AddControl(new Guid("4929f73d-57fc-4e90-9809-a4f70ef6f66c"));
            labelTextureMalnutrusyon = (ITTLabel)AddControl(new Guid("0d3a6d62-3074-4488-ba5a-661971330e4a"));
            TextureMalnutrusyon = (ITTObjectListBox)AddControl(new Guid("03630f24-833d-4628-b46f-38829e0a3338"));
            labelMobilite = (ITTLabel)AddControl(new Guid("6167b7c1-1120-4adf-b7d3-ade20a8585f3"));
            Mobilite = (ITTObjectListBox)AddControl(new Guid("1eda238b-dea9-444a-8ccd-9055a4956578"));
            labelRiskScore = (ITTLabel)AddControl(new Guid("e78a7c4c-06fd-4495-b0d5-a27bedeff4fb"));
            RiskScore = (ITTEnumComboBox)AddControl(new Guid("9541acf4-95dd-47b3-ad8c-fbb885e65e41"));
            labelActionDate = (ITTLabel)AddControl(new Guid("a2d6d229-522f-4811-aeb5-79135014c514"));
            ActionDate = (ITTDateTimePicker)AddControl(new Guid("9b4c3915-0edf-4551-a050-a2047dff9213"));
            base.InitializeControls();
        }

        public NursingWaterlowRiskForm() : base("NURSINGWATERLOWRISK", "NursingWaterlowRiskForm")
        {
        }

        protected NursingWaterlowRiskForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}