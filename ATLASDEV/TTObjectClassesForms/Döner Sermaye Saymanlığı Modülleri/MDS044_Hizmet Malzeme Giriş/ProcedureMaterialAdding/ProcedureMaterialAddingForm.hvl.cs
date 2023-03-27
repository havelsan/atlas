
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
    public partial class ProcedureMaterialAddingForm : EpisodeActionForm
    {
    /// <summary>
    /// Hizmet Malzeme Giriş
    /// </summary>
        protected TTObjectClasses.ProcedureMaterialAdding _ProcedureMaterialAdding
        {
            get { return (TTObjectClasses.ProcedureMaterialAdding)_ttObject; }
        }

        protected ITTLabel labelProcedureDoctor;
        protected ITTTabControl tttabcontrol1;
        protected ITTTabPage tttabpage2;
        protected ITTGrid GridProcedure;
        protected ITTDateTimePickerColumn ttdatetimepickercolumn1;
        protected ITTListBoxColumn ttlistboxcolumn1;
        protected ITTTextBoxColumn tttextboxcolumn1;
        protected ITTTextBoxColumn PPAYERPRICE;
        protected ITTTextBoxColumn PPATIENTPRICE;
        protected ITTListBoxColumn Performer;
        protected ITTTabPage tttabpage1;
        protected ITTLabel ttlabel2;
        protected ITTDateTimePicker PEndDate;
        protected ITTDateTimePicker PStartDate;
        protected ITTLabel labelProcedureDefinition;
        protected ITTLabel ttlabel3;
        protected ITTObjectListBox ProcedureDefinition;
        protected ITTTabPage tttabpage3;
        protected ITTGrid GridMaterials;
        protected ITTDateTimePickerColumn ttdatetimepickercolumn2;
        protected ITTListBoxColumn ttlistboxcolumn2;
        protected ITTTextBoxColumn tttextboxcolumn2;
        protected ITTTextBoxColumn MPAYERPRICE;
        protected ITTTextBoxColumn MPATIENTPRICE;
        protected ITTObjectListBox ProcedureDoctor;
        override protected void InitializeControls()
        {
            labelProcedureDoctor = (ITTLabel)AddControl(new Guid("0b0585fb-3983-41c8-821a-1071b070d9f6"));
            tttabcontrol1 = (ITTTabControl)AddControl(new Guid("78cc50ae-924d-4a14-af5d-3a635422fc54"));
            tttabpage2 = (ITTTabPage)AddControl(new Guid("63cd7d5d-a0c3-432d-bc31-ea1feddfd04e"));
            GridProcedure = (ITTGrid)AddControl(new Guid("2dbf3d8c-a698-4c1a-ad57-d1a8cdf3a28c"));
            ttdatetimepickercolumn1 = (ITTDateTimePickerColumn)AddControl(new Guid("0e079573-73ce-48cd-8888-4b78ec1ca9b8"));
            ttlistboxcolumn1 = (ITTListBoxColumn)AddControl(new Guid("eb534525-4e45-4764-9c3c-025bbf034846"));
            tttextboxcolumn1 = (ITTTextBoxColumn)AddControl(new Guid("360c7eba-bc22-4327-87a2-05d825f33ee8"));
            PPAYERPRICE = (ITTTextBoxColumn)AddControl(new Guid("b3299a24-b995-442e-a3b6-03eee9a60cc4"));
            PPATIENTPRICE = (ITTTextBoxColumn)AddControl(new Guid("7b532ac5-d429-4e5c-b052-9134032f959e"));
            Performer = (ITTListBoxColumn)AddControl(new Guid("b5519315-23a0-4f6b-9f51-c61b55cba8b6"));
            tttabpage1 = (ITTTabPage)AddControl(new Guid("92465ae9-90f9-4ec2-a4f5-70978395d83c"));
            ttlabel2 = (ITTLabel)AddControl(new Guid("4bd88bc6-3110-4ba2-8adb-d2f9fe12ac65"));
            PEndDate = (ITTDateTimePicker)AddControl(new Guid("2f606110-79b8-44a4-a5f3-bcc5c03f659e"));
            PStartDate = (ITTDateTimePicker)AddControl(new Guid("d8f1c3f7-0f05-4d3d-ad70-56b47e7da244"));
            labelProcedureDefinition = (ITTLabel)AddControl(new Guid("8dcee6e4-6fe4-4a70-955e-952011dcb0ac"));
            ttlabel3 = (ITTLabel)AddControl(new Guid("aa25a336-eae5-49da-936e-ecbb542fff51"));
            ProcedureDefinition = (ITTObjectListBox)AddControl(new Guid("6f1fd220-c1d6-4309-b62f-ad60c65ac143"));
            tttabpage3 = (ITTTabPage)AddControl(new Guid("d6c0f6a1-080e-4635-ae81-6010721f17e7"));
            GridMaterials = (ITTGrid)AddControl(new Guid("d2b86e77-aa93-438a-bc5e-c2794b85a3cf"));
            ttdatetimepickercolumn2 = (ITTDateTimePickerColumn)AddControl(new Guid("4646c822-bcfe-4532-8023-4281ba0984c4"));
            ttlistboxcolumn2 = (ITTListBoxColumn)AddControl(new Guid("f325664f-0b43-4fa1-9f03-03d8cd92867c"));
            tttextboxcolumn2 = (ITTTextBoxColumn)AddControl(new Guid("f556368b-a730-48c3-a8b9-79dae7268a41"));
            MPAYERPRICE = (ITTTextBoxColumn)AddControl(new Guid("7cbca37b-4935-46a8-bead-48e82f0a9f0a"));
            MPATIENTPRICE = (ITTTextBoxColumn)AddControl(new Guid("bbb37d1a-6545-434d-b1ae-d43eaa7d4e93"));
            ProcedureDoctor = (ITTObjectListBox)AddControl(new Guid("abedf2a7-fa73-4845-abb2-188bb8b21aca"));
            base.InitializeControls();
        }

        public ProcedureMaterialAddingForm() : base("PROCEDUREMATERIALADDING", "ProcedureMaterialAddingForm")
        {
        }

        protected ProcedureMaterialAddingForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}