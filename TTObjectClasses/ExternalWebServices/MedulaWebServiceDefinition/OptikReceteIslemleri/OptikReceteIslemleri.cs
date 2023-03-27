
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
    public  partial class OptikReceteIslemleri : TTObject
    {
        public static partial class WebMethods
        {
                    
        }

        #region Methods
        /// <remarks/>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.7.2102.0")]
        [System.SerializableAttribute()]
        [System.Diagnostics.DebuggerStepThroughAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xxxxxx.com")]
        public partial class receteTesisDVO
        {

            private string tcKimlikNoField;

            private string takipNoField;

            private string receteTarihiField;

            private string protokolNoField;

            private string receteTeshisField;

            private string tesisKoduField;

            private string drTescilNoField;

            private string doktorTcKimlikNoField;

            private string eReceteNoField;

            private string sagCam1Field;

            private string solCam1Field;

            private string gozlukTuru1Field;

            private string camTipi1Field;

            private string camRengi1Field;

            private string sagSferik1Field;

            private string sagSilendirik1Field;

            private string sagAks1Field;

            private string solSferik1Field;

            private string solSilendirik1Field;

            private string solAks1Field;

            private string sagCam2Field;

            private string solCam2Field;

            private string gozlukTuru2Field;

            private string camRengi2Field;

            private string camTipi2Field;

            private string sagSferik2Field;

            private string sagSilendirik2Field;

            private string sagAks2Field;

            private string solSferik2Field;

            private string solSilendirik2Field;

            private string solAks2Field;

            private string lensSagCamField;

            private string lensSagCamSferikField;

            private string lensSagCamSilendirikField;

            private string lensSagCamEgimField;

            private string lensSagCamAksField;

            private string lensSagCamCapField;

            private string lensSolCamField;

            private string lensSolCamSferikField;

            private string lensSolCamSilendirikField;

            private string lensSolCamEgimField;

            private string lensSolCamAksField;

            private string lensSolCamCapField;

            private string lensGeciciMaddeField;

            private string keratakonusSagCamSilendirikField;

            private string keratakonusSagCamEgimField;

            private string keratakonusSagCamAksField;

            private string keratakonusSolCamSilendirikField;

            private string keratakonusSolCamEgimField;

            private string keratakonusSolCamAksField;

            private string keratakonusSagCamField;

            private string keratakonusSagCamSferikField;

            private string keratakonusSagCamCapField;

            private string keratakonusSolCamField;

            private string keratakonusSolCamSferikField;

            private string keratakonusSolCamCapField;

            private string teleskobikSagCam1Field;

            private string teleskobikSolCam1Field;

            private string teleskobikGozlukTuru1Field;

            private string teleskopikGozlukTipi1Field;

            private string teleskopikSagSol1Field;

            private string teleskobikSagCam2Field;

            private string teleskobikSolCam2Field;

            private string teleskobikGozlukTuru2Field;

            private string teleskopikGozlukTipi2Field;

            private string teleskopikSagSol2Field;

            private string provizyonTipiField;

            private string receteTipiField;

            private ereceteTaniDVO[] ereceteTaniListesiField;

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public string tcKimlikNo
            {
                get
                {
                    return tcKimlikNoField;
                }
                set
                {
                    tcKimlikNoField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public string takipNo
            {
                get
                {
                    return takipNoField;
                }
                set
                {
                    takipNoField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public string receteTarihi
            {
                get
                {
                    return receteTarihiField;
                }
                set
                {
                    receteTarihiField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public string protokolNo
            {
                get
                {
                    return protokolNoField;
                }
                set
                {
                    protokolNoField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public string receteTeshis
            {
                get
                {
                    return receteTeshisField;
                }
                set
                {
                    receteTeshisField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public string tesisKodu
            {
                get
                {
                    return tesisKoduField;
                }
                set
                {
                    tesisKoduField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public string drTescilNo
            {
                get
                {
                    return drTescilNoField;
                }
                set
                {
                    drTescilNoField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public string doktorTcKimlikNo
            {
                get
                {
                    return doktorTcKimlikNoField;
                }
                set
                {
                    doktorTcKimlikNoField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable = true)]
            public string eReceteNo
            {
                get
                {
                    return eReceteNoField;
                }
                set
                {
                    eReceteNoField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable = true)]
            public string sagCam1
            {
                get
                {
                    return sagCam1Field;
                }
                set
                {
                    sagCam1Field = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable = true)]
            public string solCam1
            {
                get
                {
                    return solCam1Field;
                }
                set
                {
                    solCam1Field = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable = true)]
            public string gozlukTuru1
            {
                get
                {
                    return gozlukTuru1Field;
                }
                set
                {
                    gozlukTuru1Field = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable = true)]
            public string camTipi1
            {
                get
                {
                    return camTipi1Field;
                }
                set
                {
                    camTipi1Field = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable = true)]
            public string camRengi1
            {
                get
                {
                    return camRengi1Field;
                }
                set
                {
                    camRengi1Field = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable = true)]
            public string sagSferik1
            {
                get
                {
                    return sagSferik1Field;
                }
                set
                {
                    sagSferik1Field = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable = true)]
            public string sagSilendirik1
            {
                get
                {
                    return sagSilendirik1Field;
                }
                set
                {
                    sagSilendirik1Field = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable = true)]
            public string sagAks1
            {
                get
                {
                    return sagAks1Field;
                }
                set
                {
                    sagAks1Field = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable = true)]
            public string solSferik1
            {
                get
                {
                    return solSferik1Field;
                }
                set
                {
                    solSferik1Field = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable = true)]
            public string solSilendirik1
            {
                get
                {
                    return solSilendirik1Field;
                }
                set
                {
                    solSilendirik1Field = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable = true)]
            public string solAks1
            {
                get
                {
                    return solAks1Field;
                }
                set
                {
                    solAks1Field = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable = true)]
            public string sagCam2
            {
                get
                {
                    return sagCam2Field;
                }
                set
                {
                    sagCam2Field = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable = true)]
            public string solCam2
            {
                get
                {
                    return solCam2Field;
                }
                set
                {
                    solCam2Field = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable = true)]
            public string gozlukTuru2
            {
                get
                {
                    return gozlukTuru2Field;
                }
                set
                {
                    gozlukTuru2Field = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable = true)]
            public string camRengi2
            {
                get
                {
                    return camRengi2Field;
                }
                set
                {
                    camRengi2Field = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable = true)]
            public string camTipi2
            {
                get
                {
                    return camTipi2Field;
                }
                set
                {
                    camTipi2Field = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable = true)]
            public string sagSferik2
            {
                get
                {
                    return sagSferik2Field;
                }
                set
                {
                    sagSferik2Field = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable = true)]
            public string sagSilendirik2
            {
                get
                {
                    return sagSilendirik2Field;
                }
                set
                {
                    sagSilendirik2Field = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable = true)]
            public string sagAks2
            {
                get
                {
                    return sagAks2Field;
                }
                set
                {
                    sagAks2Field = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable = true)]
            public string solSferik2
            {
                get
                {
                    return solSferik2Field;
                }
                set
                {
                    solSferik2Field = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable = true)]
            public string solSilendirik2
            {
                get
                {
                    return solSilendirik2Field;
                }
                set
                {
                    solSilendirik2Field = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable = true)]
            public string solAks2
            {
                get
                {
                    return solAks2Field;
                }
                set
                {
                    solAks2Field = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable = true)]
            public string lensSagCam
            {
                get
                {
                    return lensSagCamField;
                }
                set
                {
                    lensSagCamField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable = true)]
            public string lensSagCamSferik
            {
                get
                {
                    return lensSagCamSferikField;
                }
                set
                {
                    lensSagCamSferikField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable = true)]
            public string lensSagCamSilendirik
            {
                get
                {
                    return lensSagCamSilendirikField;
                }
                set
                {
                    lensSagCamSilendirikField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable = true)]
            public string lensSagCamEgim
            {
                get
                {
                    return lensSagCamEgimField;
                }
                set
                {
                    lensSagCamEgimField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable = true)]
            public string lensSagCamAks
            {
                get
                {
                    return lensSagCamAksField;
                }
                set
                {
                    lensSagCamAksField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable = true)]
            public string lensSagCamCap
            {
                get
                {
                    return lensSagCamCapField;
                }
                set
                {
                    lensSagCamCapField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable = true)]
            public string lensSolCam
            {
                get
                {
                    return lensSolCamField;
                }
                set
                {
                    lensSolCamField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable = true)]
            public string lensSolCamSferik
            {
                get
                {
                    return lensSolCamSferikField;
                }
                set
                {
                    lensSolCamSferikField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable = true)]
            public string lensSolCamSilendirik
            {
                get
                {
                    return lensSolCamSilendirikField;
                }
                set
                {
                    lensSolCamSilendirikField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable = true)]
            public string lensSolCamEgim
            {
                get
                {
                    return lensSolCamEgimField;
                }
                set
                {
                    lensSolCamEgimField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable = true)]
            public string lensSolCamAks
            {
                get
                {
                    return lensSolCamAksField;
                }
                set
                {
                    lensSolCamAksField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable = true)]
            public string lensSolCamCap
            {
                get
                {
                    return lensSolCamCapField;
                }
                set
                {
                    lensSolCamCapField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable = true)]
            public string lensGeciciMadde
            {
                get
                {
                    return lensGeciciMaddeField;
                }
                set
                {
                    lensGeciciMaddeField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable = true)]
            public string keratakonusSagCamSilendirik
            {
                get
                {
                    return keratakonusSagCamSilendirikField;
                }
                set
                {
                    keratakonusSagCamSilendirikField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable = true)]
            public string keratakonusSagCamEgim
            {
                get
                {
                    return keratakonusSagCamEgimField;
                }
                set
                {
                    keratakonusSagCamEgimField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable = true)]
            public string keratakonusSagCamAks
            {
                get
                {
                    return keratakonusSagCamAksField;
                }
                set
                {
                    keratakonusSagCamAksField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable = true)]
            public string keratakonusSolCamSilendirik
            {
                get
                {
                    return keratakonusSolCamSilendirikField;
                }
                set
                {
                    keratakonusSolCamSilendirikField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable = true)]
            public string keratakonusSolCamEgim
            {
                get
                {
                    return keratakonusSolCamEgimField;
                }
                set
                {
                    keratakonusSolCamEgimField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable = true)]
            public string keratakonusSolCamAks
            {
                get
                {
                    return keratakonusSolCamAksField;
                }
                set
                {
                    keratakonusSolCamAksField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable = true)]
            public string keratakonusSagCam
            {
                get
                {
                    return keratakonusSagCamField;
                }
                set
                {
                    keratakonusSagCamField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable = true)]
            public string keratakonusSagCamSferik
            {
                get
                {
                    return keratakonusSagCamSferikField;
                }
                set
                {
                    keratakonusSagCamSferikField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable = true)]
            public string keratakonusSagCamCap
            {
                get
                {
                    return keratakonusSagCamCapField;
                }
                set
                {
                    keratakonusSagCamCapField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable = true)]
            public string keratakonusSolCam
            {
                get
                {
                    return keratakonusSolCamField;
                }
                set
                {
                    keratakonusSolCamField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable = true)]
            public string keratakonusSolCamSferik
            {
                get
                {
                    return keratakonusSolCamSferikField;
                }
                set
                {
                    keratakonusSolCamSferikField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable = true)]
            public string keratakonusSolCamCap
            {
                get
                {
                    return keratakonusSolCamCapField;
                }
                set
                {
                    keratakonusSolCamCapField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable = true)]
            public string teleskobikSagCam1
            {
                get
                {
                    return teleskobikSagCam1Field;
                }
                set
                {
                    teleskobikSagCam1Field = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable = true)]
            public string teleskobikSolCam1
            {
                get
                {
                    return teleskobikSolCam1Field;
                }
                set
                {
                    teleskobikSolCam1Field = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable = true)]
            public string teleskobikGozlukTuru1
            {
                get
                {
                    return teleskobikGozlukTuru1Field;
                }
                set
                {
                    teleskobikGozlukTuru1Field = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable = true)]
            public string teleskopikGozlukTipi1
            {
                get
                {
                    return teleskopikGozlukTipi1Field;
                }
                set
                {
                    teleskopikGozlukTipi1Field = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable = true)]
            public string teleskopikSagSol1
            {
                get
                {
                    return teleskopikSagSol1Field;
                }
                set
                {
                    teleskopikSagSol1Field = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable = true)]
            public string teleskobikSagCam2
            {
                get
                {
                    return teleskobikSagCam2Field;
                }
                set
                {
                    teleskobikSagCam2Field = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable = true)]
            public string teleskobikSolCam2
            {
                get
                {
                    return teleskobikSolCam2Field;
                }
                set
                {
                    teleskobikSolCam2Field = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable = true)]
            public string teleskobikGozlukTuru2
            {
                get
                {
                    return teleskobikGozlukTuru2Field;
                }
                set
                {
                    teleskobikGozlukTuru2Field = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable = true)]
            public string teleskopikGozlukTipi2
            {
                get
                {
                    return teleskopikGozlukTipi2Field;
                }
                set
                {
                    teleskopikGozlukTipi2Field = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable = true)]
            public string teleskopikSagSol2
            {
                get
                {
                    return teleskopikSagSol2Field;
                }
                set
                {
                    teleskopikSagSol2Field = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable = true)]
            public string provizyonTipi
            {
                get
                {
                    return provizyonTipiField;
                }
                set
                {
                    provizyonTipiField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public string receteTipi
            {
                get
                {
                    return receteTipiField;
                }
                set
                {
                    receteTipiField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute("ereceteTaniListesi", Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public ereceteTaniDVO[] ereceteTaniListesi
            {
                get
                {
                    return ereceteTaniListesiField;
                }
                set
                {
                    ereceteTaniListesiField = value;
                }
            }
        }

        /// <remarks/>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.7.2102.0")]
        [System.SerializableAttribute()]
        [System.Diagnostics.DebuggerStepThroughAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xxxxxx.com")]
        public partial class ereceteTaniDVO
        {

            private string taniAdiField;

            private string taniKoduField;

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable = true)]
            public string taniAdi
            {
                get
                {
                    return taniAdiField;
                }
                set
                {
                    taniAdiField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public string taniKodu
            {
                get
                {
                    return taniKoduField;
                }
                set
                {
                    taniKoduField = value;
                }
            }
        }

        /// <remarks/>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.7.2102.0")]
        [System.SerializableAttribute()]
        [System.Diagnostics.DebuggerStepThroughAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xxxxxx.com")]
        public partial class ereceteListeSorguCevapDVO
        {

            private receteTesisDVO[] ereceteListesiField;

            private string sonucKoduField;

            private string sonucMesajiField;

            private string uyariMesajiField;

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute("ereceteListesi", Form = System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable = true)]
            public receteTesisDVO[] ereceteListesi
            {
                get
                {
                    return ereceteListesiField;
                }
                set
                {
                    ereceteListesiField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public string sonucKodu
            {
                get
                {
                    return sonucKoduField;
                }
                set
                {
                    sonucKoduField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public string sonucMesaji
            {
                get
                {
                    return sonucMesajiField;
                }
                set
                {
                    sonucMesajiField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public string uyariMesaji
            {
                get
                {
                    return uyariMesajiField;
                }
                set
                {
                    uyariMesajiField = value;
                }
            }
        }

        /// <remarks/>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.7.2102.0")]
        [System.SerializableAttribute()]
        [System.Diagnostics.DebuggerStepThroughAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xxxxxx.com")]
        public partial class ereceteListeSorguIstekDVO
        {

            private int tesisKoduField;

            private long doktorTcKimlikNoField;

            private long hastaTcKimlikNoField;

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public int tesisKodu
            {
                get
                {
                    return tesisKoduField;
                }
                set
                {
                    tesisKoduField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public long doktorTcKimlikNo
            {
                get
                {
                    return doktorTcKimlikNoField;
                }
                set
                {
                    doktorTcKimlikNoField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public long hastaTcKimlikNo
            {
                get
                {
                    return hastaTcKimlikNoField;
                }
                set
                {
                    hastaTcKimlikNoField = value;
                }
            }
        }

        /// <remarks/>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.7.2102.0")]
        [System.SerializableAttribute()]
        [System.Diagnostics.DebuggerStepThroughAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xxxxxx.com")]
        public partial class ereceteSorguCevapDVO
        {

            private receteTesisDVO receteTesisDVOField;

            private string sonucKoduField;

            private string sonucMesajiField;

            private string uyariMesajiField;

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public receteTesisDVO receteTesisDVO
            {
                get
                {
                    return receteTesisDVOField;
                }
                set
                {
                    receteTesisDVOField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public string sonucKodu
            {
                get
                {
                    return sonucKoduField;
                }
                set
                {
                    sonucKoduField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public string sonucMesaji
            {
                get
                {
                    return sonucMesajiField;
                }
                set
                {
                    sonucMesajiField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public string uyariMesaji
            {
                get
                {
                    return uyariMesajiField;
                }
                set
                {
                    uyariMesajiField = value;
                }
            }
        }

        /// <remarks/>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.7.2102.0")]
        [System.SerializableAttribute()]
        [System.Diagnostics.DebuggerStepThroughAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xxxxxx.com")]
        public partial class ereceteSorguIstekDVO
        {

            private int tesisKoduField;

            private string ereceteNoField;

            private long doktorTcKimlikNoField;

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public int tesisKodu
            {
                get
                {
                    return tesisKoduField;
                }
                set
                {
                    tesisKoduField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public string ereceteNo
            {
                get
                {
                    return ereceteNoField;
                }
                set
                {
                    ereceteNoField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public long doktorTcKimlikNo
            {
                get
                {
                    return doktorTcKimlikNoField;
                }
                set
                {
                    doktorTcKimlikNoField = value;
                }
            }
        }

        /// <remarks/>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.7.2102.0")]
        [System.SerializableAttribute()]
        [System.Diagnostics.DebuggerStepThroughAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xxxxxx.com")]
        public partial class imzaliEreceteGirisCevapDVO
        {

            private receteTesisDVO ereceteDVOField;

            private string sonucKoduField;

            private string sonucMesajiField;

            private string uyariMesajiField;

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public receteTesisDVO ereceteDVO
            {
                get
                {
                    return ereceteDVOField;
                }
                set
                {
                    ereceteDVOField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public string sonucKodu
            {
                get
                {
                    return sonucKoduField;
                }
                set
                {
                    sonucKoduField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public string sonucMesaji
            {
                get
                {
                    return sonucMesajiField;
                }
                set
                {
                    sonucMesajiField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public string uyariMesaji
            {
                get
                {
                    return uyariMesajiField;
                }
                set
                {
                    uyariMesajiField = value;
                }
            }
        }

        /// <remarks/>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.7.2102.0")]
        [System.SerializableAttribute()]
        [System.Diagnostics.DebuggerStepThroughAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xxxxxx.com")]
        public partial class imzaliEreceteGirisIstekDVO
        {

            private byte[] imzaliEreceteField;

            private int tesisKoduField;

            private int surumNumarasiField;

            private long doktorTcKimlikNoField;

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified, DataType = "base64Binary")]
            public byte[] imzaliErecete
            {
                get
                {
                    return imzaliEreceteField;
                }
                set
                {
                    imzaliEreceteField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public int tesisKodu
            {
                get
                {
                    return tesisKoduField;
                }
                set
                {
                    tesisKoduField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public int surumNumarasi
            {
                get
                {
                    return surumNumarasiField;
                }
                set
                {
                    surumNumarasiField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public long doktorTcKimlikNo
            {
                get
                {
                    return doktorTcKimlikNoField;
                }
                set
                {
                    doktorTcKimlikNoField = value;
                }
            }
        }

        /// <remarks/>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.7.2102.0")]
        [System.SerializableAttribute()]
        [System.Diagnostics.DebuggerStepThroughAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xxxxxx.com")]
        public partial class ereceteSilDVO
        {

            private string eReceteNoField;

            private string tesisKoduField;

            private string doktorTcKimlikNoField;

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public string eReceteNo
            {
                get
                {
                    return eReceteNoField;
                }
                set
                {
                    eReceteNoField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public string tesisKodu
            {
                get
                {
                    return tesisKoduField;
                }
                set
                {
                    tesisKoduField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public string doktorTcKimlikNo
            {
                get
                {
                    return doktorTcKimlikNoField;
                }
                set
                {
                    doktorTcKimlikNoField = value;
                }
            }
        }

        /// <remarks/>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.7.2102.0")]
        [System.SerializableAttribute()]
        [System.Diagnostics.DebuggerStepThroughAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xxxxxx.com")]
        public partial class sonucDVO
        {

            private receteTesisDVO ereceteDVOField;

            private string sonucKoduField;

            private string sonucMesajiField;

            private string uyariMesajiField;

            private string eReceteNoField;

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public receteTesisDVO ereceteDVO
            {
                get
                {
                    return ereceteDVOField;
                }
                set
                {
                    ereceteDVOField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public string sonucKodu
            {
                get
                {
                    return sonucKoduField;
                }
                set
                {
                    sonucKoduField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public string sonucMesaji
            {
                get
                {
                    return sonucMesajiField;
                }
                set
                {
                    sonucMesajiField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public string uyariMesaji
            {
                get
                {
                    return uyariMesajiField;
                }
                set
                {
                    uyariMesajiField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public string eReceteNo
            {
                get
                {
                    return eReceteNoField;
                }
                set
                {
                    eReceteNoField = value;
                }
            }
        }

        #endregion Methods

    }
}