
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


namespace TTObjectClasses
{
    /// <summary>
    /// EHR Base Class
    /// </summary>
    public  partial class BaseEhr : TTObject
    {
        public partial class GetEHRPricesByPatient_Class : TTReportNqlObject 
        {
        }

        protected override void PreInsert()
        {
#region PreInsert
            base.PreInsert();
            if(CurrentStateDefID == null)
            {
                if(!(this is ehrEpisodeAction))
                    CurrentStateDefID = BaseEhr.States.Active;
            }
#endregion PreInsert
        }

#region Methods
        protected override void OnConstruct()
        {
            base.OnConstruct();
            // if (((ITTObject)this).IsNew == true)// HAtalı Çalışıyor bazen IsNew gelmiyor
            if(CurrentStateDefID == null)
            {
                if(!(this is ehrEpisodeAction))
                    CurrentStateDefID = BaseEhr.States.Active;
            }
        }
        
        public virtual List<TTObject> getFullPackage()
        {
            List<TTObject> package = new List<TTObject>();
            if(!package.Contains(this))
                package.Add(this);//ehrobject
            foreach (TTObjectRelationDef relDef in ObjectDef.AllChildRelationDefs)
            {
                if (!string.IsNullOrEmpty(relDef.ChildrenName))
                {
                    System.Reflection.PropertyInfo propInfo = GetType().GetProperty(relDef.ChildrenName.ToString());
                    object childCollection = propInfo.GetValue(this, null);
                    ITTChildObjectCollection cc = childCollection as ITTChildObjectCollection;
                    //IsEmbedded false olan relationlar ancak Select methodu ile doldurulurlar için
                    BindingList<TTObject> childColEhr=  new BindingList<TTObject>();
                    if (relDef.IsEmbedded.Equals(false))
                    {
                        Type[] param = new Type[1];
                        param[0] = typeof(string);
                        System.Reflection.MethodInfo methodInfo = cc.GetType().GetMethod("Select", param);
                        object[] objparam = new object[1] { "" };
                        Type typeOfChild = methodInfo.ReturnType;
                        foreach (object nonEmbeddedCC in (IList)methodInfo.Invoke(cc, objparam))
                        {
                            if (nonEmbeddedCC is BaseEhr)
                                AddChildObjectToPackage(package, (TTObject)nonEmbeddedCC);
                        }
                    }
                    else
                    {
                        foreach (TTObject embeddedCC in cc)
                        {
                            if (embeddedCC is BaseEhr)
                                AddChildObjectToPackage(package, (TTObject)embeddedCC);
                        }
                    }
                }
            }
            // parentında BaseEhr varsa oda gelsin
            foreach (TTObjectRelationDef relDef in ObjectDef.AllParentRelationDefs)
            {
                if (!string.IsNullOrEmpty(relDef.CodeName))
                {
                    System.Reflection.PropertyInfo propInfo = GetType().GetProperty(relDef.CodeName.ToString());
                    if (propInfo != null)
                    {
                        object parentObj = propInfo.GetValue(this, null);
                        BaseEhr parentBaseEhr = parentObj as BaseEhr;
                        if (parentBaseEhr != null)
                        {
                            if (!package.Contains(parentBaseEhr))
                                package.Add(parentBaseEhr);
                        }
                    }
                }
            }
            return package;
        }

        private List<TTObject> AddChildObjectToPackage(List<TTObject> package, TTObject childobject)
        {
            if (childobject != null)
            {
                if (childobject is BaseEhr)
                {
                    List<TTObject> childPackage = ((BaseEhr)childobject).getFullPackage();
                    foreach (TTObject childOfchild in childPackage)
                    {
                        if (childOfchild != null && (!package.Contains(childOfchild)))
                            package.Add(childOfchild);
                    }
                }
            }
            return package;
        }
        
#endregion Methods

    }
}