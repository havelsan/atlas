
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
    /// New Unbound Form
    /// </summary>
    public partial class TestUnBoundForm : TTUnboundForm
    {
        protected ITTObjectListBox TTListBox;
        protected ITTButton CreateSubEpisode;
        protected ITTPanel ttpanel1;
        protected ITTButton ttbutton1;
        protected ITTLabel ttlabel1;
        protected ITTDateTimePicker dtStartDate;
        protected ITTDateTimePicker dtEndDate;
        protected ITTLabel ttlabel2;
        protected ITTButton ttbutton2;
        override protected void InitializeControls()
        {
            TTListBox = (ITTObjectListBox)AddControl(new Guid("ff40084f-c50c-4db6-ac71-a84bbe7eafcb"));
            CreateSubEpisode = (ITTButton)AddControl(new Guid("602ba0c9-b976-4aea-ae3f-2917c243641a"));
            ttpanel1 = (ITTPanel)AddControl(new Guid("61ad5eef-b76a-4bd7-b319-a857f6b33fb7"));
            ttbutton1 = (ITTButton)AddControl(new Guid("56abc6ce-8392-4f85-8c63-c9760da8f686"));
            ttlabel1 = (ITTLabel)AddControl(new Guid("b7b8153a-61ad-4a2c-b226-b9c8a59d8abd"));
            dtStartDate = (ITTDateTimePicker)AddControl(new Guid("ecbdf4a6-e503-4eef-ae82-e576b46c0f80"));
            dtEndDate = (ITTDateTimePicker)AddControl(new Guid("da11ba4a-dc36-44b7-b00d-a6ecc7561c8e"));
            ttlabel2 = (ITTLabel)AddControl(new Guid("2d176c51-a519-44ca-8193-1724298d9bf9"));
            ttbutton2 = (ITTButton)AddControl(new Guid("d8943d04-1d8e-4319-82f4-ef72da6271d6"));
            base.InitializeControls();
        }

        public TestUnBoundForm() : base("TestUnBoundForm")
        {
        }

        protected TestUnBoundForm(string formDefName) : base(formDefName)
        {
        }
    }
}