
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
    /// Order Tatil Günü Tanımı
    /// </summary>
    public partial class OrderRestDayDefForm : TerminologyManagerDefForm
    {
        protected TTObjectClasses.OrderRestDayDef _OrderRestDayDef
        {
            get { return (TTObjectClasses.OrderRestDayDef)_ttObject; }
        }

        protected ITTLabel labelRestDayDescription;
        protected ITTTextBox RestDayDescription;
        protected ITTTextBox RestDayCount;
        protected ITTLabel labelRestDayCount;
        protected ITTLabel labelOrderDay;
        protected ITTDateTimePicker OrderDay;
        protected ITTCheckBox IsActive;
        override protected void InitializeControls()
        {
            labelRestDayDescription = (ITTLabel)AddControl(new Guid("efbb9e50-1401-4920-a4bd-36cf6e5e0b61"));
            RestDayDescription = (ITTTextBox)AddControl(new Guid("c7914296-6e4c-4518-b7e7-957c50111859"));
            RestDayCount = (ITTTextBox)AddControl(new Guid("e3acb044-6ad8-4b74-84cf-5ac71efc707a"));
            labelRestDayCount = (ITTLabel)AddControl(new Guid("97082743-8fdf-4c11-9100-c744dc510431"));
            labelOrderDay = (ITTLabel)AddControl(new Guid("8cfbff4b-7504-464b-8c89-16469376c87a"));
            OrderDay = (ITTDateTimePicker)AddControl(new Guid("aa330ef5-d8a8-43cd-b1a1-53c902dc60c3"));
            IsActive = (ITTCheckBox)AddControl(new Guid("0b2f4255-3231-45e9-9132-13d7fd7714d5"));
            base.InitializeControls();
        }

        public OrderRestDayDefForm() : base("ORDERRESTDAYDEF", "OrderRestDayDefForm")
        {
        }

        protected OrderRestDayDefForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}