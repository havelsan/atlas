
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
    /// İhtiyaç Fazlası Düzenleme
    /// </summary>
    public partial class SurPlusDefinitionForm : TTDefinitionForm
    {
    /// <summary>
    /// İhtiyaç fazlası mevcut inceleme modülünün ana sınıfıdır
    /// </summary>
        protected TTObjectClasses.SurPlusNeedDefinition _SurPlusNeedDefinition
        {
            get { return (TTObjectClasses.SurPlusNeedDefinition)_ttObject; }
        }

        protected ITTLabel labelMaterial;
        protected ITTObjectListBox Material;
        protected ITTLabel labelAccountancy;
        protected ITTObjectListBox Accountancy;
        protected ITTLabel labelExpirationDate;
        protected ITTDateTimePicker ExpirationDate;
        protected ITTLabel labelStatus;
        protected ITTEnumComboBox Status;
        protected ITTLabel labelAmount;
        protected ITTTextBox Amount;
        override protected void InitializeControls()
        {
            labelMaterial = (ITTLabel)AddControl(new Guid("41208707-4350-441c-9dc9-501e2d3fcfbe"));
            Material = (ITTObjectListBox)AddControl(new Guid("668407ea-2b76-4d58-81d5-b47f6bb565f8"));
            labelAccountancy = (ITTLabel)AddControl(new Guid("e1e38592-e46e-4668-8987-16881ab3b880"));
            Accountancy = (ITTObjectListBox)AddControl(new Guid("25b65030-e4df-4c85-b38b-e65d14bc9def"));
            labelExpirationDate = (ITTLabel)AddControl(new Guid("aa69017f-7c40-4bcb-8488-ceee639e2874"));
            ExpirationDate = (ITTDateTimePicker)AddControl(new Guid("1aa7f160-faf3-4f59-a206-4c6a2ef83566"));
            labelStatus = (ITTLabel)AddControl(new Guid("b61d4806-b184-4d41-a5ec-26882f2d18b9"));
            Status = (ITTEnumComboBox)AddControl(new Guid("aaa6da74-b479-4db3-8ac2-0e7831e4face"));
            labelAmount = (ITTLabel)AddControl(new Guid("8e6be3f9-4190-4b2b-ac38-08c4fa112db9"));
            Amount = (ITTTextBox)AddControl(new Guid("7d449dd1-2f58-4ac7-b63b-f963843fac67"));
            base.InitializeControls();
        }

        public SurPlusDefinitionForm() : base("SURPLUSNEEDDEFINITION", "SurPlusDefinitionForm")
        {
        }

        protected SurPlusDefinitionForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}