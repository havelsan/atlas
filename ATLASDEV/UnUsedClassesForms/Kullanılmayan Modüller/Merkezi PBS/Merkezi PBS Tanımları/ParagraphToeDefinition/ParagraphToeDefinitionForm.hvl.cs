
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
    public partial class ParagraphToeDefinitionForm : TerminologyManagerDefForm
    {
        protected TTObjectClasses.ParagraphToeDefinition _ParagraphToeDefinition
        {
            get { return (TTObjectClasses.ParagraphToeDefinition)_ttObject; }
        }

        protected ITTCheckBox ttcheckboxActive;
        protected ITTLabel labelSectionId;
        protected ITTObjectListBox SectionId;
        protected ITTLabel labelMainToeId;
        protected ITTObjectListBox MainToeId;
        protected ITTLabel labelOfficeId;
        protected ITTObjectListBox OfficeId;
        protected ITTLabel labelPARAGRAPHTOECODE;
        protected ITTTextBox PARAGRAPHTOECODE;
        override protected void InitializeControls()
        {
            ttcheckboxActive = (ITTCheckBox)AddControl(new Guid("7f8ea3f0-f8e9-49e5-8fcb-63198e27eec5"));
            labelSectionId = (ITTLabel)AddControl(new Guid("69df0431-e683-446d-89d5-ccd90e5c5ffe"));
            SectionId = (ITTObjectListBox)AddControl(new Guid("165d7dc2-5845-4ee8-8118-c73c171cec2f"));
            labelMainToeId = (ITTLabel)AddControl(new Guid("f4547464-20ce-425d-9a59-272c0d09ac32"));
            MainToeId = (ITTObjectListBox)AddControl(new Guid("f8824fa6-f968-41b4-b62f-b9fe604d702e"));
            labelOfficeId = (ITTLabel)AddControl(new Guid("f62163d4-55c8-4451-a8ac-e71abf07c32b"));
            OfficeId = (ITTObjectListBox)AddControl(new Guid("ed5ba4bb-4886-46b6-a14a-be674a09ccff"));
            labelPARAGRAPHTOECODE = (ITTLabel)AddControl(new Guid("28a942ea-95f4-446a-9c3c-39d43af529e2"));
            PARAGRAPHTOECODE = (ITTTextBox)AddControl(new Guid("e44e3890-331b-4a88-a0e2-0594b7fe2299"));
            base.InitializeControls();
        }

        public ParagraphToeDefinitionForm() : base("PARAGRAPHTOEDEFINITION", "ParagraphToeDefinitionForm")
        {
        }

        protected ParagraphToeDefinitionForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}