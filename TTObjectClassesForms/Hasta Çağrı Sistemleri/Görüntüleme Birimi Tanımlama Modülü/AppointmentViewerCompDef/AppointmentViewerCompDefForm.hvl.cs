
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
    public partial class AppointmentViewerCompDefForm : TTDefinitionForm
    {
    /// <summary>
    /// Randevu Sırası Bilgisayar Tanımı  
    /// </summary>
        protected TTObjectClasses.AppointmentViewerCompDef _AppointmentViewerCompDef
        {
            get { return (TTObjectClasses.AppointmentViewerCompDef)_ttObject; }
        }

        protected ITTGrid RelatedQueues;
        protected ITTListBoxColumn ExaminationQueueDefinitionRelatedQueues;
        protected ITTLabel labelRowCount;
        protected ITTTextBox RowCount;
        protected ITTTextBox ComputerName;
        protected ITTTextBox tttextbox1;
        protected ITTGrid RelatedResources;
        protected ITTListBoxColumn ResourceRelatedResource;
        protected ITTLabel labelComputerName;
        protected ITTLabel ttlabel1;
        override protected void InitializeControls()
        {
            RelatedQueues = (ITTGrid)AddControl(new Guid("98d84daf-14d6-41f8-bb69-6bbc25f396cd"));
            ExaminationQueueDefinitionRelatedQueues = (ITTListBoxColumn)AddControl(new Guid("b066a329-7dbe-4bce-8a01-0d4f59a8fa0f"));
            labelRowCount = (ITTLabel)AddControl(new Guid("6e8ec96c-a22a-445f-b8c9-5af5d878b289"));
            RowCount = (ITTTextBox)AddControl(new Guid("b9e44574-6858-48ba-8fc1-967f42801104"));
            ComputerName = (ITTTextBox)AddControl(new Guid("16f8e4e1-1fa3-45d2-b152-171c240e7353"));
            tttextbox1 = (ITTTextBox)AddControl(new Guid("853c439c-2414-4145-82b0-7868999cf4e4"));
            RelatedResources = (ITTGrid)AddControl(new Guid("78d265d2-afd4-4669-b587-ae30ce7380d2"));
            ResourceRelatedResource = (ITTListBoxColumn)AddControl(new Guid("18590bb0-1e11-4034-b7f2-6a82675d6263"));
            labelComputerName = (ITTLabel)AddControl(new Guid("82214178-ac80-4b6b-8035-5642a84ce804"));
            ttlabel1 = (ITTLabel)AddControl(new Guid("dc8da168-6477-44f5-b303-21e713278657"));
            base.InitializeControls();
        }

        public AppointmentViewerCompDefForm() : base("APPOINTMENTVIEWERCOMPDEF", "AppointmentViewerCompDefForm")
        {
        }

        protected AppointmentViewerCompDefForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}