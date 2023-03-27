
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
    /// Patoloji Resim Formu
    /// </summary>
    public partial class PathologyImageForm : TTForm
    {
    /// <summary>
    /// PathologyImage
    /// </summary>
        protected TTObjectClasses.PathologyImage _PathologyImage
        {
            get { return (TTObjectClasses.PathologyImage)_ttObject; }
        }

        protected ITTPictureBoxControl pictImage;
        protected ITTLabel lblDescription;
        protected ITTTextBox txtDescription;
        override protected void InitializeControls()
        {
            pictImage = (ITTPictureBoxControl)AddControl(new Guid("8637b104-a3e6-4348-ae63-04096b7adfd4"));
            lblDescription = (ITTLabel)AddControl(new Guid("00ce16da-6284-4856-afef-77b654291bf6"));
            txtDescription = (ITTTextBox)AddControl(new Guid("e070156d-b7c3-4b7d-a629-9a8f38075d2b"));
            base.InitializeControls();
        }

        public PathologyImageForm() : base("PATHOLOGYIMAGE", "PathologyImageForm")
        {
        }

        protected PathologyImageForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}