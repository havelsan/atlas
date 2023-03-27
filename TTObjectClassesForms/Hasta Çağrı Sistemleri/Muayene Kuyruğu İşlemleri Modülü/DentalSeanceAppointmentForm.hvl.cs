
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
    /// Diş Sıraya Alınan Hastalar
    /// </summary>
    public partial class DentalSeanceAppointment : TTUnboundForm
    {
        protected ITTObjectListBox TTListBoxProcedure;
        protected ITTButton ttbuttonExportExcel;
        protected ITTLabel ttlabel3;
        protected ITTTextBox txtPatientName;
        protected ITTButton cmdSearchPatient;
        protected ITTButton cmdListPatientItems;
        protected ITTTabControl tttabcontrolExaminationQueue;
        protected ITTTabPage tabpageWaitingItems;
        protected ITTGrid QueueItemsGrid;
        protected ITTTextBoxColumn CallTime;
        protected ITTTextBoxColumn QueueItemObjectID;
        protected ITTTextBoxColumn Desc;
        protected ITTTextBoxColumn OrderNo;
        protected ITTTextBoxColumn Procedure;
        protected ITTTextBoxColumn ToothNumbers;
        protected ITTButtonColumn DeleteProcedure;
        protected ITTLabel ttlabel1;
        override protected void InitializeControls()
        {
            TTListBoxProcedure = (ITTObjectListBox)AddControl(new Guid("d34589d5-cdca-4725-a614-b1936b40ecf5"));
            ttbuttonExportExcel = (ITTButton)AddControl(new Guid("7e0b7a2e-3407-4e93-b9f0-617fb99db77f"));
            ttlabel3 = (ITTLabel)AddControl(new Guid("1cc8cb76-3e1f-4ec3-97be-481122d193a8"));
            txtPatientName = (ITTTextBox)AddControl(new Guid("042d13dd-bde9-4260-b737-c2e506d88026"));
            cmdSearchPatient = (ITTButton)AddControl(new Guid("fdbb7d8e-8724-43c7-9560-8289871b560e"));
            cmdListPatientItems = (ITTButton)AddControl(new Guid("ea913a61-89c9-447d-8b27-fd4cca6b25a3"));
            tttabcontrolExaminationQueue = (ITTTabControl)AddControl(new Guid("49145087-c657-4ecb-80a7-082cb76fbca8"));
            tabpageWaitingItems = (ITTTabPage)AddControl(new Guid("0526b6e9-e199-45fa-8f38-ffacb4c38b3c"));
            QueueItemsGrid = (ITTGrid)AddControl(new Guid("9e20ec37-2854-4505-89b2-a5dec46f2198"));
            CallTime = (ITTTextBoxColumn)AddControl(new Guid("c5ea460a-1ebd-4f92-917f-77a87cc2b962"));
            QueueItemObjectID = (ITTTextBoxColumn)AddControl(new Guid("45f5d186-3e62-4801-8e14-28f3841fe768"));
            Desc = (ITTTextBoxColumn)AddControl(new Guid("ec9cbbad-5865-455d-9a58-4b8817d595bd"));
            OrderNo = (ITTTextBoxColumn)AddControl(new Guid("cf4382b6-fa10-4887-834c-0c941d359dce"));
            Procedure = (ITTTextBoxColumn)AddControl(new Guid("8c781f11-e972-4beb-ba09-c0fc13ca3232"));
            ToothNumbers = (ITTTextBoxColumn)AddControl(new Guid("63fbee5c-1bed-4616-bee0-6b977c26f9ad"));
            DeleteProcedure = (ITTButtonColumn)AddControl(new Guid("9b2b0d0b-47fc-42de-958b-26418de4183c"));
            ttlabel1 = (ITTLabel)AddControl(new Guid("1d33fca9-58e0-46a3-b5a5-bfd2129a08e2"));
            base.InitializeControls();
        }

        public DentalSeanceAppointment() : base("DentalSeanceAppointment")
        {
        }

        protected DentalSeanceAppointment(string formDefName) : base(formDefName)
        {
        }
    }
}