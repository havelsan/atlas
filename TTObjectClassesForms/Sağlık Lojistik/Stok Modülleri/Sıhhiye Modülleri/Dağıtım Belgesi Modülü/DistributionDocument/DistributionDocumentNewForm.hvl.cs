
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
    /// Dağıtım Belgesi
    /// </summary>
    public partial class DistributionDocumentNewForm : BaseDistributionDocumentForm
    {
    /// <summary>
    /// Dağıtım Belgesi için kullanılan temel sınıftır
    /// </summary>
        protected TTObjectClasses.DistributionDocument _DistributionDocument
        {
            get { return (TTObjectClasses.DistributionDocument)_ttObject; }
        }

        protected ITTButton AutoDistributionButton;
        protected ITTButton ChooseProductsFromTheTree;
        override protected void InitializeControls()
        {
            AutoDistributionButton = (ITTButton)AddControl(new Guid("38a49e00-828a-49eb-998c-589b88b033c0"));
            ChooseProductsFromTheTree = (ITTButton)AddControl(new Guid("174a7aa5-51dc-459d-8fde-c45f27830fb2"));
            base.InitializeControls();
        }

        public DistributionDocumentNewForm() : base("DISTRIBUTIONDOCUMENT", "DistributionDocumentNewForm")
        {
        }

        protected DistributionDocumentNewForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}