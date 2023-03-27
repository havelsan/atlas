
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
    public partial class AppointmentFormOrthesis : EpisodeActionForm
    {
    /// <summary>
    /// Ortez Protez  İşlemlerinin Gerçekleştirildiği Temel Nesnedir
    /// </summary>
        protected TTObjectClasses.OrthesisProsthesisRequest _OrthesisProsthesisRequest
        {
            get { return (TTObjectClasses.OrthesisProsthesisRequest)_ttObject; }
        }

        protected ITTTextBox tttextboxProtokolNo;
        protected ITTTextBox tttextboxDescription;
        protected ITTLabel ttlabel1;
        override protected void InitializeControls()
        {
            tttextboxProtokolNo = (ITTTextBox)AddControl(new Guid("d5307a82-1a45-472c-8087-8796ee28357e"));
            tttextboxDescription = (ITTTextBox)AddControl(new Guid("d3800330-5018-4cb4-be8a-e244ca27d063"));
            ttlabel1 = (ITTLabel)AddControl(new Guid("dba4a033-d56d-4b6a-9178-dfbfbcf6f8c7"));
            base.InitializeControls();
        }

        public AppointmentFormOrthesis() : base("ORTHESISPROSTHESISREQUEST", "AppointmentFormOrthesis")
        {
        }

        protected AppointmentFormOrthesis(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}