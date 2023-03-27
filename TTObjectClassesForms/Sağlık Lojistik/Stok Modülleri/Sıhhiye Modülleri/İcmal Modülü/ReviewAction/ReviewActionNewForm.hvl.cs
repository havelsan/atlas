
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
    public partial class ReviewActionNewForm : BaseReviewActionForm
    {
    /// <summary>
    /// İcmal 
    /// </summary>
        protected TTObjectClasses.ReviewAction _ReviewAction
        {
            get { return (TTObjectClasses.ReviewAction)_ttObject; }
        }

        public ReviewActionNewForm() : base("REVIEWACTION", "ReviewActionNewForm")
        {
        }

        protected ReviewActionNewForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}