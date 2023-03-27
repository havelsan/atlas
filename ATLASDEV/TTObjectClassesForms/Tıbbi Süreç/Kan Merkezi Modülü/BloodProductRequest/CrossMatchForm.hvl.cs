
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
    /// Kan Bankası CrossMatch
    /// </summary>
    public partial class CrossMatch : EpisodeActionForm
    {
    /// <summary>
    /// Kan Ürünü İstek
    /// </summary>
        protected TTObjectClasses.BloodProductRequest _BloodProductRequest
        {
            get { return (TTObjectClasses.BloodProductRequest)_ttObject; }
        }

        protected ITTTabControl tttabcontrol1;
        protected ITTButton ttbutton1;
        protected ITTGroupBox ttgroupbox1;
        protected ITTCheckBox ttcheckbox5;
        protected ITTCheckBox ttcheckbox4;
        protected ITTCheckBox ttcheckbox3;
        protected ITTCheckBox ttcheckbox2;
        protected ITTCheckBox ttcheckbox1;
        protected ITTLabel ttlabel2;
        protected ITTLabel ttlabel1;
        protected ITTTextBox tttextbox1;
        protected ITTDateTimePicker ttdatetimepicker1;
        override protected void InitializeControls()
        {
            tttabcontrol1 = (ITTTabControl)AddControl(new Guid("d0933e4f-2844-41e2-80e0-6116331b8a09"));
            ttbutton1 = (ITTButton)AddControl(new Guid("b7fbdeb7-3b91-46e8-bfe3-893822fcea91"));
            ttgroupbox1 = (ITTGroupBox)AddControl(new Guid("650f9b28-6131-4506-ae90-f86c710723c8"));
            ttcheckbox5 = (ITTCheckBox)AddControl(new Guid("40fb17eb-adcd-42c4-a008-1e3cf3da4349"));
            ttcheckbox4 = (ITTCheckBox)AddControl(new Guid("a9dfb1ce-1cb9-4037-b340-5581a574b124"));
            ttcheckbox3 = (ITTCheckBox)AddControl(new Guid("41985c06-731a-4953-a9a7-7bfd8b722b36"));
            ttcheckbox2 = (ITTCheckBox)AddControl(new Guid("1f6410ff-2e6b-4882-8217-17fd584af846"));
            ttcheckbox1 = (ITTCheckBox)AddControl(new Guid("ea28ea98-e11a-44e3-9269-4f0beae64ba7"));
            ttlabel2 = (ITTLabel)AddControl(new Guid("6d3cda24-0c79-483c-9028-57f30bf99fba"));
            ttlabel1 = (ITTLabel)AddControl(new Guid("8e257262-9568-425e-b3eb-0141ba032d46"));
            tttextbox1 = (ITTTextBox)AddControl(new Guid("2e3cc712-fbdb-4974-a4e4-0339121feacc"));
            ttdatetimepicker1 = (ITTDateTimePicker)AddControl(new Guid("c34bb457-f3a4-4827-af56-3153fa215112"));
            base.InitializeControls();
        }

        public CrossMatch() : base("BLOODPRODUCTREQUEST", "CrossMatch")
        {
        }

        protected CrossMatch(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}