
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
    /// Periyot
    /// </summary>
    public partial class DateForm : TTForm
    {
    /// <summary>
    /// Günlük İlaç Çizelgesi
    /// </summary>
        protected TTObjectClasses.KSchedule _KSchedule
        {
            get { return (TTObjectClasses.KSchedule)_ttObject; }
        }

        protected ITTLabel ttlabel1;
        protected ITTDateTimePicker ttdatetimepicker2;
        protected ITTDateTimePicker ttdatetimepicker1;
        protected ITTLabel ttlabel2;
        override protected void InitializeControls()
        {
            ttlabel1 = (ITTLabel)AddControl(new Guid("612642c7-6dae-4d20-81ec-144faa43b564"));
            ttdatetimepicker2 = (ITTDateTimePicker)AddControl(new Guid("6052099c-2a22-467a-b62b-522b705008ee"));
            ttdatetimepicker1 = (ITTDateTimePicker)AddControl(new Guid("f44971f8-f3bf-46ae-89a0-8f9442504991"));
            ttlabel2 = (ITTLabel)AddControl(new Guid("1f642c3f-1236-4469-8de3-e2bbd6aa4de7"));
            base.InitializeControls();
        }

        public DateForm() : base("KSCHEDULE", "DateForm")
        {
        }

        protected DateForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}