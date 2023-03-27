
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
    public  partial class XXXXXX112Services : TTObject
    {
#region Methods
        [Serializable]
        public class AsyncBase
        {
            [NonSerialized]
            protected TTObjectContext objectcontext;

            private string _medulaProvisionObjectID;

            private string _messageObjectID;

            public string MessageObjectID
            {
                get { return _messageObjectID; }
                set { _messageObjectID = value; }
            }

            public string MedulaProvisionObjectID
            {
                get { return _medulaProvisionObjectID; }
                set { _medulaProvisionObjectID = value; }
            }

            public AsyncBase()
            {
                MessageObjectID = Guid.NewGuid().ToString();
            }
        }

        [Serializable]
        public class EUYSTaniGonderParam : AsyncBase, IWebMethodCallback
        {
            public EUYSTaniGonderParam() { }

            //public EUYSTaniGonderParam(TTObjectClasses.HastaKabulIslemleri.provizyonGirisDVO provizyonGirisDVO, string medulaProvisionObjectID)
            //{
            //    _provizyonGirisDVO = provizyonGirisDVO;
            //    MedulaProvisionObjectID = medulaProvisionObjectID;
            //}
            //public TTObjectClasses.HastaKabulIslemleri.provizyonGirisDVO _provizyonGirisDVO;

            #region IWebMethodCallback Members

            public bool WebMethodCallback(object returnValue, object[] calledParameters, Exception messageException)
            {
                if (returnValue != null)
                {
                   int? result = (int?)returnValue;
                    if (result != 1)
                    {
                        //string medulaProvisionObjectID = MedulaProvisionObjectID;
                        HastaKabulCompletedInternal(result, ObjectContext);
                        //MedulaHelper.SaveAndDisposeContext(ObjectContext);
                        return false;
                    }
                    else
                        return true;
                }
                else
                    return true;

            }

            #endregion

            #region IAttributeInterface Members

            public TTObjectContext ObjectContext
            {
                get
                {
                    if (objectcontext == null)
                        objectcontext = new TTObjectContext(false);
                    return objectcontext;
                }
            }

            public void HastaKabulCompletedInternal(int? result, TTObjectContext _context)
            {
                //if (result)
                //{
                //}
            }



            #endregion
        }
        
        
        [Serializable]
        public class VakaSonlandirParam : AsyncBase, IWebMethodCallback
        {
            public VakaSonlandirParam() { }

            //public EUYSTaniGonderParam(TTObjectClasses.HastaKabulIslemleri.provizyonGirisDVO provizyonGirisDVO, string medulaProvisionObjectID)
            //{
            //    _provizyonGirisDVO = provizyonGirisDVO;
            //    MedulaProvisionObjectID = medulaProvisionObjectID;
            //}
            //public TTObjectClasses.HastaKabulIslemleri.provizyonGirisDVO _provizyonGirisDVO;

            #region IWebMethodCallback Members

            public bool WebMethodCallback(object returnValue, object[] calledParameters, Exception messageException)
            {
//                if (returnValue != null)
//                {
//                   int? result = (int?)returnValue;
//                    if (result != 1)
//                    {
//                        //string medulaProvisionObjectID = MedulaProvisionObjectID;
//                        HastaKabulCompletedInternal(result, ObjectContext);
//                        //MedulaHelper.SaveAndDisposeContext(ObjectContext);
//                        return false;
//                    }
//                    else
                        return true;
//                }
//                else
//                    return true;

            }

            #endregion

            #region IAttributeInterface Members

            public TTObjectContext ObjectContext
            {
                get
                {
                    if (objectcontext == null)
                        objectcontext = new TTObjectContext(false);
                    return objectcontext;
                }
            }

//            public void HastaKabulCompletedInternal(int? result, TTObjectContext _context)
//            {
//                //if (result)
//                //{
//                //}
//            }



            #endregion
        }
        
#endregion Methods

    }
}