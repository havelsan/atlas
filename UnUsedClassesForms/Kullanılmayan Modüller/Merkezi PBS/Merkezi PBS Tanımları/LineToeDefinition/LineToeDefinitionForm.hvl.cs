
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
    public partial class LineToeDefinitionForm : TerminologyManagerDefForm
    {
        protected TTObjectClasses.LineToeDefinition _LineToeDefinition
        {
            get { return (TTObjectClasses.LineToeDefinition)_ttObject; }
        }

        protected ITTLabel mainToeDescr;
        protected ITTTextBox LINETOECODE;
        protected ITTTextBox DESCRIPTION;
        protected ITTCheckBox ttcheckbox1;
        protected ITTCheckBox ttcheckboxActive;
        protected ITTLabel labelArmedForceId;
        protected ITTObjectListBox ArmedForceId;
        protected ITTLabel labelRankId;
        protected ITTObjectListBox RankId;
        protected ITTLabel labelClassId;
        protected ITTObjectListBox ClassId;
        protected ITTLabel labelMobilizationId;
        protected ITTObjectListBox MobilizationId;
        protected ITTLabel labelPeaceId;
        protected ITTObjectListBox PeaceId;
        protected ITTLabel labelToeTypeId;
        protected ITTObjectListBox ToeTypeId;
        protected ITTLabel labelSamId;
        protected ITTObjectListBox SamId;
        protected ITTLabel labelHonorificId;
        protected ITTObjectListBox HonorificId;
        protected ITTLabel labelBranchId;
        protected ITTObjectListBox BranchId;
        protected ITTLabel labelMissionId;
        protected ITTObjectListBox MissionId;
        protected ITTLabel labelSectionId;
        protected ITTObjectListBox SectionId;
        protected ITTLabel labelLINETOECODE;
        protected ITTLabel labelDESCRIPTION;
        protected ITTLabel ttlabel3;
        protected ITTLabel ttlabel4;
        protected ITTLabel paragraphToeDescr;
        override protected void InitializeControls()
        {
            mainToeDescr = (ITTLabel)AddControl(new Guid("0ed1290c-29b1-42e1-a8c3-ad19466024f5"));
            LINETOECODE = (ITTTextBox)AddControl(new Guid("adb3bd76-3a13-4b4d-bc5b-04c7b355aa80"));
            DESCRIPTION = (ITTTextBox)AddControl(new Guid("3b36a004-58e6-433a-95e8-7d58d1c8002d"));
            ttcheckbox1 = (ITTCheckBox)AddControl(new Guid("23507847-9bf4-49b3-b88a-d6be844f2da3"));
            ttcheckboxActive = (ITTCheckBox)AddControl(new Guid("63b38411-ec02-4ea9-996d-f6d658a85afa"));
            labelArmedForceId = (ITTLabel)AddControl(new Guid("d8de4392-2eea-498d-8dac-bbe07f1fa433"));
            ArmedForceId = (ITTObjectListBox)AddControl(new Guid("0df5cba2-0dea-4a7b-8c31-640fc2240fdf"));
            labelRankId = (ITTLabel)AddControl(new Guid("e6c8cbf2-fa03-454d-a9e9-ddc09421c885"));
            RankId = (ITTObjectListBox)AddControl(new Guid("11235f1d-faec-46f4-a9fc-e6e29471a252"));
            labelClassId = (ITTLabel)AddControl(new Guid("27fe3d2d-12c0-4138-9b75-ebfc61eff316"));
            ClassId = (ITTObjectListBox)AddControl(new Guid("d8afe5da-9066-42f5-8bc3-c74a50b92552"));
            labelMobilizationId = (ITTLabel)AddControl(new Guid("f0a6f760-f7aa-459c-9d63-d86b64aa8a8a"));
            MobilizationId = (ITTObjectListBox)AddControl(new Guid("046ff9be-81d2-4f78-880e-78a104090643"));
            labelPeaceId = (ITTLabel)AddControl(new Guid("5404e63d-ce57-424e-b999-015df62339b4"));
            PeaceId = (ITTObjectListBox)AddControl(new Guid("c76c3465-778e-4a59-8a6b-86e03558231d"));
            labelToeTypeId = (ITTLabel)AddControl(new Guid("103b9987-19a7-46c8-ad3b-f0e14ca39943"));
            ToeTypeId = (ITTObjectListBox)AddControl(new Guid("92204f74-f9e0-46a0-afd5-3f86daf332b1"));
            labelSamId = (ITTLabel)AddControl(new Guid("3bf25d42-a2b9-4b22-b25c-600c4f3e566b"));
            SamId = (ITTObjectListBox)AddControl(new Guid("87d63941-ab98-4425-8311-9e2fd9fdfc35"));
            labelHonorificId = (ITTLabel)AddControl(new Guid("86498715-ab00-4a77-aa42-bdd63898e6fe"));
            HonorificId = (ITTObjectListBox)AddControl(new Guid("efd8ae6d-053c-4875-9226-9fa640358fc6"));
            labelBranchId = (ITTLabel)AddControl(new Guid("4f8c3af1-12b0-4ca5-a53d-6585decf72f9"));
            BranchId = (ITTObjectListBox)AddControl(new Guid("ed2af639-0743-4947-bc3f-befa49c30555"));
            labelMissionId = (ITTLabel)AddControl(new Guid("edf5ae57-596f-439d-85e0-98e2e2d8947f"));
            MissionId = (ITTObjectListBox)AddControl(new Guid("f4aee330-76d7-4d92-8aa5-8749f9b2f84a"));
            labelSectionId = (ITTLabel)AddControl(new Guid("cf117438-d25f-4cb3-9d95-46fcada40c5c"));
            SectionId = (ITTObjectListBox)AddControl(new Guid("694bdbaf-ba59-40da-8ced-a118dc978aee"));
            labelLINETOECODE = (ITTLabel)AddControl(new Guid("4baa5811-bab1-4b09-8bdc-6946787edeea"));
            labelDESCRIPTION = (ITTLabel)AddControl(new Guid("36d1984e-7075-4cf3-b3d3-b847e97735ad"));
            ttlabel3 = (ITTLabel)AddControl(new Guid("f5e69350-0e9f-4bdb-9c34-35171d6d5c2d"));
            ttlabel4 = (ITTLabel)AddControl(new Guid("bebd39fc-084d-47c0-babb-ef7c466ac4e4"));
            paragraphToeDescr = (ITTLabel)AddControl(new Guid("faa2eda0-47f9-4b62-850a-1051d2bc4e34"));
            base.InitializeControls();
        }

        public LineToeDefinitionForm() : base("LINETOEDEFINITION", "LineToeDefinitionForm")
        {
        }

        protected LineToeDefinitionForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}