
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
    /// Nöbet Günü Tanımlama
    /// </summary>
    public partial class NewWatchDayForm : TTForm
    {
    /// <summary>
    /// Nöbet Günü Tanımlama
    /// </summary>
        protected TTObjectClasses.MPBSWatchDayDefinition _MPBSWatchDayDefinition
        {
            get { return (TTObjectClasses.MPBSWatchDayDefinition)_ttObject; }
        }

        protected ITTEnumComboBox Type;
        protected ITTTextBox MinimumOffset;
        protected ITTLabel labelType;
        protected ITTLabel labelMinimumOffset;
        protected ITTTextBox DaysToBeChecked;
        protected ITTLabel labelDaysToBeChecked;
        override protected void InitializeControls()
        {
            Type = (ITTEnumComboBox)AddControl(new Guid("a9337319-0dbc-4ee2-932d-406f0a67c7a5"));
            MinimumOffset = (ITTTextBox)AddControl(new Guid("5a056004-734a-49ca-bbd3-6f98fc9f4df0"));
            labelType = (ITTLabel)AddControl(new Guid("0f77710b-638b-4588-b228-5d80ccae25cf"));
            labelMinimumOffset = (ITTLabel)AddControl(new Guid("d151fb54-f038-4303-95f6-89167e96abb4"));
            DaysToBeChecked = (ITTTextBox)AddControl(new Guid("5cea80a3-3878-4650-89b1-ecb27fedb886"));
            labelDaysToBeChecked = (ITTLabel)AddControl(new Guid("0f81170b-059b-4768-b8c5-fe7c5e3e3ade"));
            base.InitializeControls();
        }

        public NewWatchDayForm() : base("MPBSWATCHDAYDEFINITION", "NewWatchDayForm")
        {
        }

        protected NewWatchDayForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}