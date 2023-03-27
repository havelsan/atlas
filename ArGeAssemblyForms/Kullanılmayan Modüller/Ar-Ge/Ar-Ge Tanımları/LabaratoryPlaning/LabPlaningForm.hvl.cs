
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
    public partial class LabPlaningForm : TTForm
    {
        protected TTObjectClasses.LabaratoryPlaning _LabaratoryPlaning
        {
            get { return (TTObjectClasses.LabaratoryPlaning)_ttObject; }
        }

        protected ITTGrid PlanLabaratoryPlaning;
        protected ITTDateTimePickerColumn ReserveDateLabaratoryPlaning;
        protected ITTTextBoxColumn PeriodLabaratoryPlaning;
        protected ITTCheckBoxColumn IsUsedLabaratoryPlaning;
        protected ITTCheckBoxColumn LabStatusLabaratoryPlaning;
        protected ITTTextBoxColumn StatusCommentLabaratoryPlaning;
        protected ITTLabel labelLabaratory;
        protected ITTObjectListBox Labaratory;
        override protected void InitializeControls()
        {
            PlanLabaratoryPlaning = (ITTGrid)AddControl(new Guid("d4f621ba-99e2-4efc-9804-c56d39cbaa47"));
            ReserveDateLabaratoryPlaning = (ITTDateTimePickerColumn)AddControl(new Guid("d578d2e6-4ac0-4e37-bf91-d9d779ce70e1"));
            PeriodLabaratoryPlaning = (ITTTextBoxColumn)AddControl(new Guid("312034df-70e6-4129-ac28-723ac8559293"));
            IsUsedLabaratoryPlaning = (ITTCheckBoxColumn)AddControl(new Guid("40329dd5-3798-4a6c-9129-e6af194f5dd0"));
            LabStatusLabaratoryPlaning = (ITTCheckBoxColumn)AddControl(new Guid("9e702e46-dd47-4200-a1fa-96c8ebb477e0"));
            StatusCommentLabaratoryPlaning = (ITTTextBoxColumn)AddControl(new Guid("1b60a96b-a1ff-4c9c-99d3-56a690df0571"));
            labelLabaratory = (ITTLabel)AddControl(new Guid("0dc0d406-d828-4ea7-985c-389221318b84"));
            Labaratory = (ITTObjectListBox)AddControl(new Guid("646db21c-0efc-4ca5-a7d3-0b251f389187"));
            base.InitializeControls();
        }

        public LabPlaningForm() : base("LABARATORYPLANING", "LabPlaningForm")
        {
        }

        protected LabPlaningForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}