
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
    public partial class WoundStageDefForm : TerminologyManagerDefForm
    {
        protected TTObjectClasses.WoundStageDef _WoundStageDef
        {
            get { return (TTObjectClasses.WoundStageDef)_ttObject; }
        }

        protected ITTCheckBox IsDepthNeeded;
        protected ITTLabel labelName;
        protected ITTTextBox Name;
        override protected void InitializeControls()
        {
            IsDepthNeeded = (ITTCheckBox)AddControl(new Guid("cbeac3ec-5d40-4496-adb3-d0fa15650cdc"));
            labelName = (ITTLabel)AddControl(new Guid("e4ab6e33-2660-43cb-bdad-bfa01588bd96"));
            Name = (ITTTextBox)AddControl(new Guid("7928f345-de19-4598-b065-099be652ae56"));
            base.InitializeControls();
        }

        public WoundStageDefForm() : base("WOUNDSTAGEDEF", "WoundStageDefForm")
        {
        }

        protected WoundStageDefForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}