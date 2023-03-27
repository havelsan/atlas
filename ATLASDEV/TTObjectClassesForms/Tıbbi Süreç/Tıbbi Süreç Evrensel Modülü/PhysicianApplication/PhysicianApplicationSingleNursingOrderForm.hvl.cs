
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
    public partial class PhysicianApplicationSingleNursingOrderForm : TTForm
    {
    /// <summary>
    /// Muayene,Kontrol Muayenesi,Konsültasyon, Klinik Doktor İşlemleri gibi doktor işlemlerinin ana objesi
    /// </summary>
        protected TTObjectClasses.PhysicianApplication _PhysicianApplication
        {
            get { return (TTObjectClasses.PhysicianApplication)_ttObject; }
        }

        protected ITTGrid GridNursingOrders;
        protected ITTButtonColumn RPT;
        protected ITTDateTimePickerColumn OrderActionDate;
        protected ITTListBoxColumn OrderProcedureObject;
        protected ITTDateTimePickerColumn PeriodStartTime;
        protected ITTDateTimePickerColumn ExecutionDate;
        protected ITTTextBoxColumn NursingApplicationResult;
        protected ITTTextBoxColumn NursingApplicationNurseNote;
        override protected void InitializeControls()
        {
            GridNursingOrders = (ITTGrid)AddControl(new Guid("fca9631c-3114-489b-b918-bd4b3a9ac12a"));
            RPT = (ITTButtonColumn)AddControl(new Guid("28440bc6-4cc6-4748-92cf-f03f9de6a6c1"));
            OrderActionDate = (ITTDateTimePickerColumn)AddControl(new Guid("176fb9ba-f5d5-4dfe-85b2-c9f87685cd8d"));
            OrderProcedureObject = (ITTListBoxColumn)AddControl(new Guid("acde6c4e-3b67-42d7-8736-293cfe9e2559"));
            PeriodStartTime = (ITTDateTimePickerColumn)AddControl(new Guid("07ccf574-5cbc-45a1-9824-53bbef9e9dbf"));
            ExecutionDate = (ITTDateTimePickerColumn)AddControl(new Guid("b0edad13-4333-4717-9002-7e912d55d242"));
            NursingApplicationResult = (ITTTextBoxColumn)AddControl(new Guid("9a6b4b38-3ae5-43e8-9ca3-37f7250568d6"));
            NursingApplicationNurseNote = (ITTTextBoxColumn)AddControl(new Guid("c3805259-9a86-47a2-9ab2-624367a5dc49"));
            base.InitializeControls();
        }

        public PhysicianApplicationSingleNursingOrderForm() : base("PHYSICIANAPPLICATION", "PhysicianApplicationSingleNursingOrderForm")
        {
        }

        protected PhysicianApplicationSingleNursingOrderForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}