
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
    public partial class PMAddingPatientShareForm : EpisodeActionForm
    {
    /// <summary>
    /// Hizmet Malzeme Giriş (Hasta Payı)
    /// </summary>
        protected TTObjectClasses.PMAddingPatientShare _PMAddingPatientShare
        {
            get { return (TTObjectClasses.PMAddingPatientShare)_ttObject; }
        }

        protected ITTTabControl tttabcontrol1;
        protected ITTTabPage tttabpage2;
        protected ITTGrid GridProcedure;
        protected ITTDateTimePickerColumn ttdatetimepickercolumn1;
        protected ITTListBoxColumn ttlistboxcolumn1;
        protected ITTTextBoxColumn tttextboxcolumn1;
        protected ITTCheckBoxColumn RROBOTICSURGERYPACKAGE;
        protected ITTTextBoxColumn PPATIENTPRICE;
        protected ITTListBoxColumn Performer;
        protected ITTTabPage tttabpage3;
        protected ITTGrid GridMaterials;
        protected ITTDateTimePickerColumn ttdatetimepickercolumn2;
        protected ITTListBoxColumn ttlistboxcolumn2;
        protected ITTTextBoxColumn tttextboxcolumn2;
        protected ITTTextBoxColumn MPATIENTPRICE;
        override protected void InitializeControls()
        {
            tttabcontrol1 = (ITTTabControl)AddControl(new Guid("94ed82c5-dd51-4f38-a7f9-71d508d22582"));
            tttabpage2 = (ITTTabPage)AddControl(new Guid("7be7257e-0790-4fb7-b459-14ee97107c4f"));
            GridProcedure = (ITTGrid)AddControl(new Guid("df688236-81f6-420b-b734-05048d675956"));
            ttdatetimepickercolumn1 = (ITTDateTimePickerColumn)AddControl(new Guid("d4b57b0e-8a70-437b-b57d-62a5af7061a6"));
            ttlistboxcolumn1 = (ITTListBoxColumn)AddControl(new Guid("ed13a2c4-3982-487c-9012-ad3dd1abf54e"));
            tttextboxcolumn1 = (ITTTextBoxColumn)AddControl(new Guid("0f03cffe-d0b9-4656-841d-02b7f1b0824b"));
            RROBOTICSURGERYPACKAGE = (ITTCheckBoxColumn)AddControl(new Guid("0ca14f53-4778-48d0-9a35-481c7dea3049"));
            PPATIENTPRICE = (ITTTextBoxColumn)AddControl(new Guid("9e1c7efb-7725-4020-a53c-7dd93b21ec54"));
            Performer = (ITTListBoxColumn)AddControl(new Guid("6a411a26-df39-432c-b5e7-596fbb71e166"));
            tttabpage3 = (ITTTabPage)AddControl(new Guid("85349a0b-aa3a-42be-a89e-88dc731bc329"));
            GridMaterials = (ITTGrid)AddControl(new Guid("919bf3f5-7ca3-4e8d-807e-7ac11babb091"));
            ttdatetimepickercolumn2 = (ITTDateTimePickerColumn)AddControl(new Guid("fe052cd8-e3ab-471b-ac22-280dddad61f0"));
            ttlistboxcolumn2 = (ITTListBoxColumn)AddControl(new Guid("61724437-b3ba-4c59-8b8e-7a8817c9bfb0"));
            tttextboxcolumn2 = (ITTTextBoxColumn)AddControl(new Guid("a960b67c-759b-41ab-b9f5-df5054136f65"));
            MPATIENTPRICE = (ITTTextBoxColumn)AddControl(new Guid("16798cdc-3a3c-49a8-8498-910ae03c6a4d"));
            base.InitializeControls();
        }

        public PMAddingPatientShareForm() : base("PMADDINGPATIENTSHARE", "PMAddingPatientShareForm")
        {
        }

        protected PMAddingPatientShareForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}