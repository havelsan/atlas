
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
    public partial class RangeOfMotionMeasurementForm : BaseAdditionalInfoForm
    {
    /// <summary>
    /// Eklem Hareket Açıklığı Ölçümü
    /// </summary>
        protected TTObjectClasses.RangeOfMotionMeasurementForm _RangeOfMotionMeasurementForm
        {
            get { return (TTObjectClasses.RangeOfMotionMeasurementForm)_ttObject; }
        }

        protected ITTLabel labelRotationHASK;
        protected ITTTextBox RotationHASK;
        protected ITTTextBox RotationHAOK;
        protected ITTTextBox RotationHABK;
        protected ITTTextBox RotationEHA;
        protected ITTTextBox AbductionHASK;
        protected ITTTextBox AbductionHAOK;
        protected ITTTextBox AbductionHABK;
        protected ITTTextBox AbductionEHA;
        protected ITTTextBox FlexionHASK;
        protected ITTTextBox FlexionHAOK;
        protected ITTTextBox FlexionHABK;
        protected ITTTextBox FlexionEHA;
        protected ITTTextBox ExtensionHAOK;
        protected ITTTextBox ExtensionHASK;
        protected ITTTextBox ExtensionHABK;
        protected ITTTextBox ExtensionEHA;
        protected ITTTextBox Code;
        protected ITTLabel labelRotationHAOK;
        protected ITTLabel labelRotationHABK;
        protected ITTLabel labelRotationEHA;
        protected ITTLabel labelAbductionHASK;
        protected ITTLabel labelAbductionHAOK;
        protected ITTLabel labelAbductionHABK;
        protected ITTLabel labelAbductionEHA;
        protected ITTLabel labelFlexionHASK;
        protected ITTLabel labelFlexionHAOK;
        protected ITTLabel labelFlexionHABK;
        protected ITTLabel labelFlexionEHA;
        protected ITTLabel labelExtensionHAOK;
        protected ITTLabel labelExtensionHASK;
        protected ITTLabel labelExtensionHABK;
        protected ITTLabel labelExtensionEHA;
        protected ITTLabel labelCreationDate;
        protected ITTDateTimePicker CreationDate;
        protected ITTLabel labelCode;
        override protected void InitializeControls()
        {
            labelRotationHASK = (ITTLabel)AddControl(new Guid("c814a955-bb02-4057-a3d1-09c14e7eb484"));
            RotationHASK = (ITTTextBox)AddControl(new Guid("40ab2676-c75d-47b8-a7a9-ce3a65514758"));
            RotationHAOK = (ITTTextBox)AddControl(new Guid("0a4cf428-3ed6-4a00-bce9-c152885132e6"));
            RotationHABK = (ITTTextBox)AddControl(new Guid("87b1a1ad-56d2-4bb5-a404-8797b0f83a45"));
            RotationEHA = (ITTTextBox)AddControl(new Guid("e931a294-5304-42db-a673-07bb41b2e522"));
            AbductionHASK = (ITTTextBox)AddControl(new Guid("5f3083c5-6138-4963-9f39-14735b63bab2"));
            AbductionHAOK = (ITTTextBox)AddControl(new Guid("c9d7aa42-696e-44aa-873e-51f778d12f62"));
            AbductionHABK = (ITTTextBox)AddControl(new Guid("4fd03613-c16f-4ccf-b65c-6befb5f0b2f2"));
            AbductionEHA = (ITTTextBox)AddControl(new Guid("a75311a2-23b9-4569-8ce6-43c5570255ee"));
            FlexionHASK = (ITTTextBox)AddControl(new Guid("ea6f56b3-8c90-47d8-8818-520a3282b27e"));
            FlexionHAOK = (ITTTextBox)AddControl(new Guid("05f52d51-344d-4806-a78b-43faf5538289"));
            FlexionHABK = (ITTTextBox)AddControl(new Guid("38fe0bc3-bed6-4866-accb-d3c8a705b637"));
            FlexionEHA = (ITTTextBox)AddControl(new Guid("6ede39fd-b836-4431-a053-068c76f92958"));
            ExtensionHAOK = (ITTTextBox)AddControl(new Guid("e0308d79-c995-4716-a908-862f03f150f3"));
            ExtensionHASK = (ITTTextBox)AddControl(new Guid("38123d65-2e70-4a84-b1cc-3ead716aa946"));
            ExtensionHABK = (ITTTextBox)AddControl(new Guid("f4985d25-354a-4fba-95c8-a644e1ae07d3"));
            ExtensionEHA = (ITTTextBox)AddControl(new Guid("a16a0f93-74f7-4b8c-b41f-734d903f9052"));
            Code = (ITTTextBox)AddControl(new Guid("af8f59d6-9290-405f-bb48-1b0c2f8f0ebc"));
            labelRotationHAOK = (ITTLabel)AddControl(new Guid("c68001c8-39c9-45e9-a1f6-9493e1caac21"));
            labelRotationHABK = (ITTLabel)AddControl(new Guid("86d26c72-b128-4428-89d0-1a3024187dd1"));
            labelRotationEHA = (ITTLabel)AddControl(new Guid("454a58cd-27b2-4ccf-94e2-0b2473dac313"));
            labelAbductionHASK = (ITTLabel)AddControl(new Guid("10447e7a-d215-4f44-81b9-43a571aea36b"));
            labelAbductionHAOK = (ITTLabel)AddControl(new Guid("e30bb5e4-87a5-435b-b0b5-8f239afa7f95"));
            labelAbductionHABK = (ITTLabel)AddControl(new Guid("331cfe2a-fa12-4641-b3bd-4f9134ccace1"));
            labelAbductionEHA = (ITTLabel)AddControl(new Guid("2b7c2d62-8493-41d4-bf32-2adcab884dcf"));
            labelFlexionHASK = (ITTLabel)AddControl(new Guid("08567847-0f50-4a95-bf31-8eceb7f176ee"));
            labelFlexionHAOK = (ITTLabel)AddControl(new Guid("8e986253-e74c-4c6d-a3d2-fa39393c765c"));
            labelFlexionHABK = (ITTLabel)AddControl(new Guid("6b80f223-d705-4e0b-b40c-babf6504085d"));
            labelFlexionEHA = (ITTLabel)AddControl(new Guid("42456bc9-641e-457b-aa0b-33ab1ee77691"));
            labelExtensionHAOK = (ITTLabel)AddControl(new Guid("5a212e11-9a89-4c74-a1e0-ac7f3f7f2df9"));
            labelExtensionHASK = (ITTLabel)AddControl(new Guid("719dd62b-8d18-490e-b22b-346a29c50706"));
            labelExtensionHABK = (ITTLabel)AddControl(new Guid("b995992b-0c44-4e2e-9378-6f0b0a31e81b"));
            labelExtensionEHA = (ITTLabel)AddControl(new Guid("4e94bb94-11ad-491c-ab7e-8aaa2924d6b2"));
            labelCreationDate = (ITTLabel)AddControl(new Guid("a31229d7-dcb7-4724-afd9-bacb4b597240"));
            CreationDate = (ITTDateTimePicker)AddControl(new Guid("4aac7e55-8acc-474f-a984-4517ed18b63f"));
            labelCode = (ITTLabel)AddControl(new Guid("68b13109-6600-4c3e-ad67-6ee23a6b413d"));
            base.InitializeControls();
        }

        public RangeOfMotionMeasurementForm() : base("RANGEOFMOTIONMEASUREMENTFORM", "RangeOfMotionMeasurementForm")
        {
        }

        protected RangeOfMotionMeasurementForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}