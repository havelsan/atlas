
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
    /// Kan Grubu Testi Prosedür
    /// </summary>
    public partial class BloodGroupTestProcedure : EpisodeActionForm
    {
    /// <summary>
    /// Kan Grubu
    /// </summary>
        protected TTObjectClasses.BloodBnkBloodGroup _BloodBnkBloodGroup
        {
            get { return (TTObjectClasses.BloodBnkBloodGroup)_ttObject; }
        }

        protected ITTTabControl tttabcontrol1;
        protected ITTTabPage tttabpage1;
        protected ITTGrid ttgrid1;
        protected ITTListBoxColumn Test;
        protected ITTGroupBox ttgroupbox1;
        protected ITTDateTimePicker ttdatetimepicker1;
        protected ITTTextBox tttextbox2;
        protected ITTLabel ttlabel1;
        protected ITTLabel ttlabel3;
        protected ITTButton ttbutton1;
        protected ITTTextBox tttextbox1;
        protected ITTLabel ttlabel2;
        override protected void InitializeControls()
        {
            tttabcontrol1 = (ITTTabControl)AddControl(new Guid("5fba04f3-f561-4dfb-8d85-22db1f66998b"));
            tttabpage1 = (ITTTabPage)AddControl(new Guid("dbc84787-e806-45d6-92a3-c12319723bde"));
            ttgrid1 = (ITTGrid)AddControl(new Guid("1e92ccf7-98c8-4847-8226-e51f0a76b429"));
            Test = (ITTListBoxColumn)AddControl(new Guid("02dabd4e-4940-405f-9550-c0c7f6b26a38"));
            ttgroupbox1 = (ITTGroupBox)AddControl(new Guid("f5fb9af3-5cf5-45ca-983b-dba50ab85b9c"));
            ttdatetimepicker1 = (ITTDateTimePicker)AddControl(new Guid("512c821c-8864-415f-9c78-382207929073"));
            tttextbox2 = (ITTTextBox)AddControl(new Guid("4b573e3a-0a1b-4299-acd4-386e591488ab"));
            ttlabel1 = (ITTLabel)AddControl(new Guid("f904a234-1493-4f76-bd1b-4326dd0c553e"));
            ttlabel3 = (ITTLabel)AddControl(new Guid("1eb4fe00-3260-494b-8a1f-47230802d18f"));
            ttbutton1 = (ITTButton)AddControl(new Guid("c4a004c4-8fd9-4354-82ab-4e445687e713"));
            tttextbox1 = (ITTTextBox)AddControl(new Guid("6e675c73-a47c-4ec0-a1fb-66db9696b077"));
            ttlabel2 = (ITTLabel)AddControl(new Guid("7ff6a623-89aa-49aa-8ed6-d165716000ed"));
            base.InitializeControls();
        }

        public BloodGroupTestProcedure() : base("BLOODBNKBLOODGROUP", "BloodGroupTestProcedure")
        {
        }

        protected BloodGroupTestProcedure(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}