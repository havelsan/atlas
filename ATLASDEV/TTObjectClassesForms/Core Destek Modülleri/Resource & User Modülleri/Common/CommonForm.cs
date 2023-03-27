
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
    public partial class CommonForm : TTForm
    {
#region CommonForm_ClientSideMethods
        public static byte[] SignContent(string content)
        {
            return SignContent(string.Empty, content);
        }

        public static byte[] SignContent(string header, string content)
        {
            //TODO 
            //TTFormClasses.ContentSignForm form = new TTFormClasses.ContentSignForm();
            //if (!string.IsNullOrEmpty(header))
            //{
            //    form.SetHeader(header);
            //}
            //form.SetContent(content);
            //DialogResult result = form.ShowDialog();
            //if (result != DialogResult.OK)
            //    return null;
            //return form.SignedContent;
            return null;
        }

        public static SortedList<object, object> GetSelectedMSItemList(SortedList<object, object> sortedList, Boolean multiSelect, string ListTitle)
        {
            TTFormClasses.MSItemForm frm = new TTFormClasses.MSItemForm();
            return frm.SelectedMSItemList(sortedList, multiSelect, ListTitle);
        }
        public static SortedList<object, object> GetSelectedMSItemList(SortedList<object, object> sortedList, Boolean multiSelect)
        {
            TTFormClasses.MSItemForm frm = new TTFormClasses.MSItemForm();
            return frm.SelectedMSItemList(sortedList, multiSelect, "");
        }
        
        
         public static MainStoreDefinition SelectAllMainStoreDefinition(System.Windows.Forms.IWin32Window parent)
        {
            MainStoreDefinition mainStoreDefinition = null;
            TTObjectContext readOnlyObjectContext = new TTObjectContext(true);
            BindingList<MainStoreDefinition> mainStores = MainStoreDefinition.GetAllMainStores(readOnlyObjectContext);

            if (mainStores.Count == 1)
            {
                mainStoreDefinition = mainStores[0];
            }
            else
            {
                MultiSelectForm mSelectForm = new MultiSelectForm();
                foreach (MainStoreDefinition mainStore in mainStores)
                    mSelectForm.AddMSItem(mainStore.Name, mainStore.ObjectID.ToString(), mainStore);

                string mkey = mSelectForm.GetMSItem(parent, "İlgili Ana Depoyu Seçiniz", true);
                if (string.IsNullOrEmpty(mkey))
                    throw new Exception(SystemMessage.GetMessage(371));
                mainStoreDefinition = mSelectForm.MSSelectedItemObject as MainStoreDefinition;
            }
            return mainStoreDefinition;
        }

        public static MainStoreDefinition SelectResourceDependentMainStoreDefinition(System.Windows.Forms.IWin32Window parent)
        {
            MainStoreDefinition mainStoreDefinition = null;
            List<MainStoreDefinition> selectableMainStores = new List<MainStoreDefinition>();
            foreach (UserResource userResource in Common.CurrentResource.UserResources)
            {
                if (userResource.Resource.EnabledType == ResourceEnableType.BothInpatientAndOutPatient || userResource.Resource.EnabledType == ResourceEnableType.InPatient || userResource.Resource.EnabledType == ResourceEnableType.OutPatient || userResource.Resource.EnabledType == ResourceEnableType.Secmaster)
                    if (userResource.Resource.Store != null && userResource.Resource.Store is MainStoreDefinition)
                    if (selectableMainStores.Contains((MainStoreDefinition)userResource.Resource.Store) == false)
                    selectableMainStores.Add((MainStoreDefinition)userResource.Resource.Store);
            }

            if (selectableMainStores.Count == 1)
            {
                mainStoreDefinition = selectableMainStores[0];
            }
            else
            {
                MultiSelectForm mSelectForm = new MultiSelectForm();
                foreach (MainStoreDefinition mainStore in selectableMainStores)
                    mSelectForm.AddMSItem(mainStore.Name, mainStore.ObjectID.ToString(), mainStore);

                string mkey = mSelectForm.GetMSItem(parent, "İlgili Ana Depoyu Seçiniz", true);
                if (string.IsNullOrEmpty(mkey))
                    throw new Exception(SystemMessage.GetMessage(371));
                mainStoreDefinition = mSelectForm.MSSelectedItemObject as MainStoreDefinition;
            }
            return mainStoreDefinition;
        }
        
        
        public static void ShowPacsViewer(string patientId, string accessionNo)
        {
            string pacsViewerAtlas = TTObjectClasses.SystemParameter.GetParameterValue("PacsViewerAtlas", "0");
            if (pacsViewerAtlas == "1")
                ShowAtlasPacsViewer(patientId, accessionNo);
            else
                ShowMediPlusPacsViewer(patientId, accessionNo);
        } 
        
        public static void ShowMediPlusPacsViewer(string patientId, string accessionNo)
        {
            string userName = TTObjectClasses.Common.CurrentUser.Name;
            string accessionNoStr = accessionNo;
            string patientIdStr = patientId;
            string viewerUrl = TTObjectClasses.SystemParameter.GetParameterValue("PacsViewerUrl", null);
            string token = "1";
            
            userName = EncodeTo64(userName);
            accessionNoStr = EncodeTo64(accessionNoStr);
            patientIdStr = EncodeTo64(patientIdStr);
            token = EncodeTo64(token);
            
            if (String.IsNullOrEmpty(viewerUrl))
                throw new TTException("PacsViewerUrl sistem parametresi bilgisi eksik. Bilgi İşlemi arayınız.");
            else
                TTVisual.TTForm.CallInternetExplorer(viewerUrl, userName, token, accessionNoStr, patientIdStr);
        }
         
          public static void ShowAtlasPacsViewer(string patientId, string accessionNo)
        {
            string viewerUrl = TTObjectClasses.SystemParameter.GetParameterValue("PacsViewerUrl", null);
            if (string.IsNullOrEmpty(viewerUrl))
                throw new TTException("PacsViewerUrl sistem parametresi bilgisi eksik. Bilgi İşlemi arayınız.");
            string viewerUrlEncrptionReq = TTObjectClasses.SystemParameter.GetParameterValue("PacsViewerUrlEncryptionRequired", "0");
            string viewerUrlEncrptionKey = TTObjectClasses.SystemParameter.GetParameterValue("PacsViewerUrlEncryptionKey", null);
            if (viewerUrlEncrptionReq == "1" && string.IsNullOrEmpty(viewerUrlEncrptionKey))
                throw new TTException("PacsViewerUrlEncryptionKey sistem parametresi bilgisi eksik. Bilgi İşlemi arayınız.");
            string urlParams = string.Format("patientid={0}&accession={1}",  patientId, accessionNo);
            if ( viewerUrlEncrptionReq == "1" )
                urlParams = TTUtils.SymetricEncryption.Encrypt(urlParams, viewerUrlEncrptionKey);
            
            string url = string.Format("{0}?p={1}", viewerUrl, urlParams);
            System.Diagnostics.Process.Start(url);
        }
          
          
        public static Guid? SelectRemoteMethodDef()
        {
            Guid? returnValue = null;
            if (Common.ClientAsyncRemoteMethodDefs != null)
            {
                MultiSelectForm multiSelectForm = new MultiSelectForm();
                foreach (TTRemoteMethodDef remoteMethodDef in Common.ClientAsyncRemoteMethodDefs.Values)
                    multiSelectForm.AddMSItem(remoteMethodDef.ApplicationName, remoteMethodDef.RemoteMethodDefID.ToString(), remoteMethodDef.RemoteMethodDefID);

                if (string.IsNullOrEmpty(multiSelectForm.GetMSItem(null,"Uzaktan Yöntemi Seçiniz...", false, true, false, false, true, false)) == false)
                    returnValue = (Guid)multiSelectForm.MSSelectedItemObject;
            }
            return returnValue;
        }
        
        public static string EncodeTo64(string toEncode)
        {
            byte[] toEncodeAsBytes = System.Text.Encoding.GetEncoding("iso-8859-9").GetBytes(toEncode);
            string returnValue = System.Convert.ToBase64String(toEncodeAsBytes);
            return returnValue;
        }
       
       
#endregion CommonForm_ClientSideMethods
    }
}