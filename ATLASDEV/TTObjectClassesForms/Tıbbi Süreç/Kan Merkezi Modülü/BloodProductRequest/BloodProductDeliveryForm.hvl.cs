
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
    /// Kan Bankası Kan Ürün Teslim
    /// </summary>
    public partial class BloodProductDeliveryForm : EpisodeActionForm
    {
    /// <summary>
    /// Kan Ürünü İstek
    /// </summary>
        protected TTObjectClasses.BloodProductRequest _BloodProductRequest
        {
            get { return (TTObjectClasses.BloodProductRequest)_ttObject; }
        }

        public BloodProductDeliveryForm() : base("BLOODPRODUCTREQUEST", "BloodProductDeliveryForm")
        {
        }

        protected BloodProductDeliveryForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}