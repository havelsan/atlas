
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
    /// Günlük Kur Tanımı
    /// </summary>
    public partial class DailyRateDefinitionForm : TTDefinitionForm
    {
    /// <summary>
    /// Günlük Kur Tanımı
    /// </summary>
        protected TTObjectClasses.DailyRateDefinition _DailyRateDefinition
        {
            get { return (TTObjectClasses.DailyRateDefinition)_ttObject; }
        }

        protected ITTLabel labelRateDate;
        protected ITTObjectListBox RATETYPE;
        protected ITTTextBox DAILYRATE;
        protected ITTLabel labelDailyRate;
        protected ITTLabel ttlabel3;
        protected ITTLabel ttlabel4;
        protected ITTDateTimePicker RATEDATE;
        protected ITTObjectListBox CURRENCYTYPE;
        override protected void InitializeControls()
        {
            labelRateDate = (ITTLabel)AddControl(new Guid("f9de5b17-d316-4eb1-9977-217488dd01c0"));
            RATETYPE = (ITTObjectListBox)AddControl(new Guid("5d60e443-8418-41b8-b1c5-52fdc0fb8641"));
            DAILYRATE = (ITTTextBox)AddControl(new Guid("5f6f1d9a-47f1-4750-a4b4-5550cb844eb6"));
            labelDailyRate = (ITTLabel)AddControl(new Guid("268f9c6d-a091-4f0b-857e-7ae427fd050a"));
            ttlabel3 = (ITTLabel)AddControl(new Guid("0657b93b-90fa-4843-8184-86e7ad4714f2"));
            ttlabel4 = (ITTLabel)AddControl(new Guid("f48190ae-8043-4fbb-bf15-98aa33fe214a"));
            RATEDATE = (ITTDateTimePicker)AddControl(new Guid("051e286d-af29-4896-81ab-ab7882f6275e"));
            CURRENCYTYPE = (ITTObjectListBox)AddControl(new Guid("92a33084-73ee-42de-8270-c4a750f6e19c"));
            base.InitializeControls();
        }

        public DailyRateDefinitionForm() : base("DAILYRATEDEFINITION", "DailyRateDefinitionForm")
        {
        }

        protected DailyRateDefinitionForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}