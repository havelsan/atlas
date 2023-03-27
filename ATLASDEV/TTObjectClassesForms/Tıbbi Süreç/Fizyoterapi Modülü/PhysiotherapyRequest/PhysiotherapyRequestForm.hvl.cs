
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
    /// Fizyoterapi İstek Formu
    /// </summary>
    public partial class PhysiotherapyRequestForm : TTForm
    {
    /// <summary>
    /// F.T.R. İstek İşlemlerinin Gerçekleştirildiği  Nesnedir
    /// </summary>
        protected TTObjectClasses.PhysiotherapyRequest _PhysiotherapyRequest
        {
            get { return (TTObjectClasses.PhysiotherapyRequest)_ttObject; }
        }

        protected ITTLabel labelProtocolNo;
        protected ITTTextBox ProtocolNo;
        override protected void InitializeControls()
        {
            labelProtocolNo = (ITTLabel)AddControl(new Guid("59dd2050-64ff-445c-8c42-ebb1f90df6e0"));
            ProtocolNo = (ITTTextBox)AddControl(new Guid("59069a04-d1e7-4e0d-b427-d96c4bc17932"));
            base.InitializeControls();
        }

        public PhysiotherapyRequestForm() : base("PHYSIOTHERAPYREQUEST", "PhysiotherapyRequestForm")
        {
        }

        protected PhysiotherapyRequestForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}