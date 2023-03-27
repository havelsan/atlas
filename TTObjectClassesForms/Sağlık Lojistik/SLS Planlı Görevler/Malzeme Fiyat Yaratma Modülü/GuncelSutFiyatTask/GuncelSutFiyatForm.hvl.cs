
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
    /// Sut Fiyat Güncelleme
    /// </summary>
    public partial class GuncelSutFiyatForm : ScheduledTaskBaseForm
    {
    /// <summary>
    /// SUT Fiyat Güncelleme
    /// </summary>
        protected TTObjectClasses.GuncelSutFiyatTask _GuncelSutFiyatTask
        {
            get { return (TTObjectClasses.GuncelSutFiyatTask)_ttObject; }
        }

        protected ITTGrid GuncelSutFiyatUsers;
        protected ITTListBoxColumn UserGuncelSutFiyatUser;
        protected ITTListBoxColumn GuncelSutFiyatTaskGuncelSutFiyatUser;
        override protected void InitializeControls()
        {
            GuncelSutFiyatUsers = (ITTGrid)AddControl(new Guid("a994b928-329c-49ad-9702-b6b59261f619"));
            UserGuncelSutFiyatUser = (ITTListBoxColumn)AddControl(new Guid("ba4c777d-c017-460e-90f8-68357b4238f6"));
            GuncelSutFiyatTaskGuncelSutFiyatUser = (ITTListBoxColumn)AddControl(new Guid("9f2f7ca3-6ed4-4a1d-b52f-8986a68cec58"));
            base.InitializeControls();
        }

        public GuncelSutFiyatForm() : base("GUNCELSUTFIYATTASK", "GuncelSutFiyatForm")
        {
        }

        protected GuncelSutFiyatForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}