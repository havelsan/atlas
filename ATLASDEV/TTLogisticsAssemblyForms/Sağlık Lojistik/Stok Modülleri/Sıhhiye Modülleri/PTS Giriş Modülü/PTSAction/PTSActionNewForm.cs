
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

using SmartCardWrapper;

using TTStorageManager;
using System.Runtime.Versioning;
using System.Windows.Forms;
using TTVisual;
namespace TTFormClasses
{
    public partial class PTSActionNewForm : BasePTSActionForm
    {
        override protected void BindControlEvents()
        {
            btnGetFromFile.Click += new TTControlEventDelegate(btnGetFromFile_Click);
            btnGetFromPTSID.Click += new TTControlEventDelegate(btnGetFromPTSID_Click);
            base.BindControlEvents();
        }

        override protected void UnBindControlEvents()
        {
            btnGetFromFile.Click -= new TTControlEventDelegate(btnGetFromFile_Click);
            btnGetFromPTSID.Click -= new TTControlEventDelegate(btnGetFromPTSID_Click);
            base.UnBindControlEvents();
        }

        private void btnGetFromFile_Click()
        {
            #region PTSActionNewForm_btnGetFromFile_Click
            //System.Windows.Forms.OpenFileDialog openFileDialog = new OpenFileDialog();
            //         openFileDialog.ShowDialog();
            //         string fileName = @openFileDialog.FileName;
            //         XmlDocument document = new XmlDocument();
            //         document.Load(fileName);
            //         _PTSAction.AddPTSActionDetails(document, _PTSAction);
            var a = 1;
#endregion PTSActionNewForm_btnGetFromFile_Click
        }

        private void btnGetFromPTSID_Click()
        {
#region PTSActionNewForm_btnGetFromPTSID_Click
   if(PTSID.Text.Equals(""))
            {
                InfoBox.Show("Lütfen Bir PTSID Giriniz.!");
            }
            else
            {
                
                PTSPackageReceiverServis.receiveFileParametersType request = new PTSPackageReceiverServis.receiveFileParametersType();
                request.sourceGLN = TTObjectClasses.SystemParameter.GetParameterValue("ITSGLN", "");
                request.transferId = Convert.ToInt32(PTSID.Text);
                
                byte[] fileArray = null;
                byte[] decompresedBuffer = null;
                
                try
                {
                    fileArray = PTSPackageReceiverServis.WebMethods.receiveFileStream(Sites.SiteLocalHost, request);
                    decompresedBuffer =TTUtils.Helpers.SharpZipHelper.DecompressZipAndReturnFirstFileEntry(fileArray);
                    System.IO.MemoryStream memoryStream = new System.IO.MemoryStream(decompresedBuffer);

                    XmlDocument document = new XmlDocument();
                    document.Load(memoryStream);
                    _PTSAction.AddPTSActionDetails(document, _PTSAction);
                }
                catch (Exception ex)
                {
                    if(ex.InnerException != null)
                    {
                        InfoBox.Show(ex.InnerException.InnerException.Message.ToString());
                    }
                    else
                    {
                        InfoBox.Show("Hata mesajı alınamadı. Sistem Yöneticisine başvurun.");
                    }
                }
            }
#endregion PTSActionNewForm_btnGetFromPTSID_Click
        }

        protected override void PreScript()
        {
#region PTSActionNewForm_PreScript
    base.PreScript();
#endregion PTSActionNewForm_PreScript

            }
                }
}