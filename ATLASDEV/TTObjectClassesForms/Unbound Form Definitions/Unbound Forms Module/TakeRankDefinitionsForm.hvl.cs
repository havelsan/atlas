
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
    /// Rütbe Bilgileri Alma Formu
    /// </summary>
    public partial class TakeRankDefinitionsForm : TTUnboundForm
    {
        protected ITTCheckBox ACTIVE;
        protected ITTTextBox ID;
        protected ITTTextBox NAME;
        protected ITTTextBox EXTERNALCODE;
        protected ITTTextBox CODE;
        protected ITTLabel labelExternalCode;
        protected ITTLabel labelName;
        protected ITTLabel labelID;
        protected ITTLabel labelCode;
        protected ITTButton ttbutton1;
        protected ITTLabel ttlabel1;
        protected ITTEnumComboBox ttenumcombobox1;
        override protected void InitializeControls()
        {
            ACTIVE = (ITTCheckBox)AddControl(new Guid("2ad68cf0-f2cc-41e2-b67d-6d6b931d1421"));
            ID = (ITTTextBox)AddControl(new Guid("c008fc9e-48dd-4173-8615-e2e305cca9b3"));
            NAME = (ITTTextBox)AddControl(new Guid("bcb5fad0-36c5-4859-9cb0-8769469450e5"));
            EXTERNALCODE = (ITTTextBox)AddControl(new Guid("5dce980b-0ae8-46bc-9f5a-fe937e316e92"));
            CODE = (ITTTextBox)AddControl(new Guid("d154d9c4-ed18-4aa5-9043-eb123db5c3b9"));
            labelExternalCode = (ITTLabel)AddControl(new Guid("8e320876-63d5-43e2-a27c-90b2c585e168"));
            labelName = (ITTLabel)AddControl(new Guid("a2b27d1a-c39f-4d41-8cb3-10f10efbc739"));
            labelID = (ITTLabel)AddControl(new Guid("7c532b48-1e21-4f67-9590-c6d4b29499a1"));
            labelCode = (ITTLabel)AddControl(new Guid("983e246e-d952-4eb0-98d7-24d0574f2947"));
            ttbutton1 = (ITTButton)AddControl(new Guid("758b7e81-8960-4f6b-a559-a809b4c35220"));
            ttlabel1 = (ITTLabel)AddControl(new Guid("28a3e3b8-1021-420b-8825-27900426c17e"));
            ttenumcombobox1 = (ITTEnumComboBox)AddControl(new Guid("ceba8799-133b-4d15-b21a-1cdc899cd6cb"));
            base.InitializeControls();
        }

        public TakeRankDefinitionsForm() : base("TakeRankDefinitionsForm")
        {
        }

        protected TakeRankDefinitionsForm(string formDefName) : base(formDefName)
        {
        }
    }
}