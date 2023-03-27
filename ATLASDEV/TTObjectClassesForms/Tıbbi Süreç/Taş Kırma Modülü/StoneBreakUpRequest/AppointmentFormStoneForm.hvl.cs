
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
    /// Randevu Formu
    /// </summary>
    public partial class AppointmentFormStone : EpisodeActionForm
    {
    /// <summary>
    /// Taş Kırma
    /// </summary>
        protected TTObjectClasses.StoneBreakUpRequest _StoneBreakUpRequest
        {
            get { return (TTObjectClasses.StoneBreakUpRequest)_ttObject; }
        }

        protected ITTTextBox tttextboxDescription;
        protected ITTTextBox tttextboxProtokolNo;
        protected ITTLabel ttlabel1;
        override protected void InitializeControls()
        {
            tttextboxDescription = (ITTTextBox)AddControl(new Guid("39a10b06-4cda-47cf-9e17-5be83497834b"));
            tttextboxProtokolNo = (ITTTextBox)AddControl(new Guid("5fe7e7de-7f33-4e27-94c2-5ce1a25941f3"));
            ttlabel1 = (ITTLabel)AddControl(new Guid("151f35af-15aa-4bf8-810e-80d6c397d6d7"));
            base.InitializeControls();
        }

        public AppointmentFormStone() : base("STONEBREAKUPREQUEST", "AppointmentFormStone")
        {
        }

        protected AppointmentFormStone(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}