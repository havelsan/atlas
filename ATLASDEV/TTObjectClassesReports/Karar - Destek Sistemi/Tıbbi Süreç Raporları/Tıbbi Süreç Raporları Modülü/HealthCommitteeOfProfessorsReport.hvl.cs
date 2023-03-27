
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

using TTReportTool;
using TTVisual;
namespace TTReportClasses
{
    /// <summary>
    /// Profesörler Sağlık Kurulu Raporu
    /// </summary>
    public partial class HealthCommitteeOfProfessorsReport : TTReport
    {
        public class ReportRuntimeParameters 
        {
            public string TTOBJECTID = (string)TTObjectDefManager.Instance.DataTypes["String50"].ConvertValue("28EB27BF-E3E8-449C-B0DF-037338707DAD");
        }

        public partial class ARKASAYFAGroup : TTReportGroup
        {
            public HealthCommitteeOfProfessorsReport MyParentReport
            {
                get { return (HealthCommitteeOfProfessorsReport)ParentReport; }
            }

            new public ARKASAYFAGroupHeader Header()
            {
                return (ARKASAYFAGroupHeader)_header;
            }

            new public ARKASAYFAGroupFooter Footer()
            {
                return (ARKASAYFAGroupFooter)_footer;
            }

            public TTReportField TANI { get {return Header().TANI;} }
            public TTReportField NewField1 { get {return Header().NewField1;} }
            public TTReportField KARAR { get {return Header().KARAR;} }
            public TTReportField NewField3 { get {return Header().NewField3;} }
            public TTReportField NewField4 { get {return Header().NewField4;} }
            public TTReportShape shape1 { get {return Header().shape1;} }
            public TTReportField NewField18 { get {return Header().NewField18;} }
            public TTReportShape shape2 { get {return Header().shape2;} }
            public TTReportField MEMBERS { get {return Header().MEMBERS;} }
            public TTReportField MADDE { get {return Header().MADDE;} }
            public TTReportField USTMAKAMONAYI { get {return Header().USTMAKAMONAYI;} }
            public TTReportField HEAD1 { get {return Header().HEAD1;} }
            public TTReportField KARAR1 { get {return Header().KARAR1;} }
            public ARKASAYFAGroup(TTReport parentReport, string name) : base(parentReport, name)
            {
                onConstruct();
            }
            public ARKASAYFAGroup(TTReportGroup parentGroup, string name) : base(parentGroup, name)
            {
                onConstruct();
            }

             
            protected override TTReportNqlDataSet GetReportNqlDataSet()
            {
                TTBaseReportNqlData[] list = new TTBaseReportNqlData[1];
                list[0] = new TTReportNqlData<HealthCommitteeOfProfessors.GetHealthCommitteeOfProfessors_Class>("GetHealthCommitteeOfProfessors", HealthCommitteeOfProfessors.GetHealthCommitteeOfProfessors((string)TTObjectDefManager.Instance.DataTypes["String50"].ConvertValue(MyParentReport.RuntimeParameters.TTOBJECTID)));
                return new TTReportNqlDataSet(ParentGroup, list);
            }

            private void onConstruct()
            {
                _body = null;
                _header = new ARKASAYFAGroupHeader(this);
                _footer = new ARKASAYFAGroupFooter(this);

                DataSourceType = DataSourceTypeEnum.dstSelfRS;
            }

            public partial class ARKASAYFAGroupHeader : TTReportSection
            {
                public HealthCommitteeOfProfessorsReport MyParentReport
                {
                    get { return (HealthCommitteeOfProfessorsReport)ParentReport; }
                }
                
                public TTReportField TANI;
                public TTReportField NewField1;
                public TTReportField KARAR;
                public TTReportField NewField3;
                public TTReportField NewField4;
                public TTReportShape shape1;
                public TTReportField NewField18;
                public TTReportShape shape2;
                public TTReportField MEMBERS;
                public TTReportField MADDE;
                public TTReportField USTMAKAMONAYI;
                public TTReportField HEAD1;
                public TTReportField KARAR1; 
                public ARKASAYFAGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 120;
                    ForceNewPage = EvetHayirEnum.ehEvet;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    IsAutoSize = EvetHayirEnum.ehHayir;
                    RepeatCount = 0;
                    
                    TANI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 40, 5, 195, 21, false);
                    TANI.Name = "TANI";
                    TANI.DrawStyle = DrawStyleConstants.vbSolid;
                    TANI.FillStyle = FillStyleConstants.vbFSTransparent;
                    TANI.FieldType = ReportFieldTypeEnum.ftVariable;
                    TANI.MultiLine = EvetHayirEnum.ehEvet;
                    TANI.WordBreak = EvetHayirEnum.ehEvet;
                    TANI.TextFont.Name = "Arial Narrow";
                    TANI.Value = @"";

                    NewField1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 5, 40, 21, false);
                    NewField1.Name = "NewField1";
                    NewField1.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1.FillStyle = FillStyleConstants.vbFSTransparent;
                    NewField1.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1.TextFont.Name = "Arial Narrow";
                    NewField1.Value = @"TEŞHİS";

                    KARAR = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 40, 21, 195, 43, false);
                    KARAR.Name = "KARAR";
                    KARAR.DrawStyle = DrawStyleConstants.vbSolid;
                    KARAR.FillStyle = FillStyleConstants.vbFSTransparent;
                    KARAR.FieldType = ReportFieldTypeEnum.ftVariable;
                    KARAR.MultiLine = EvetHayirEnum.ehEvet;
                    KARAR.WordBreak = EvetHayirEnum.ehEvet;
                    KARAR.TextFont.Name = "Arial Narrow";
                    KARAR.TextFont.Size = 8;
                    KARAR.Value = @"";

                    NewField3 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 21, 40, 43, false);
                    NewField3.Name = "NewField3";
                    NewField3.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField3.FillStyle = FillStyleConstants.vbFSTransparent;
                    NewField3.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField3.TextFont.Name = "Arial Narrow";
                    NewField3.Value = @"KARAR";

                    NewField4 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 11, 43, 191, 48, false);
                    NewField4.Name = "NewField4";
                    NewField4.FillStyle = FillStyleConstants.vbFSTransparent;
                    NewField4.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField4.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField4.MultiLine = EvetHayirEnum.ehEvet;
                    NewField4.WordBreak = EvetHayirEnum.ehEvet;
                    NewField4.TextFont.Name = "Arial Narrow";
                    NewField4.TextFont.Size = 9;
                    NewField4.TextFont.Bold = true;
                    NewField4.Value = @"SAĞLIK KURULU ÜYELERİ";

                    shape1 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 10, 42, 10, 225, false);
                    shape1.Name = "shape1";
                    shape1.DrawStyle = DrawStyleConstants.vbSolid;

                    NewField18 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 251, 195, 268, false);
                    NewField18.Name = "NewField18";
                    NewField18.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField18.FillStyle = FillStyleConstants.vbFSTransparent;
                    NewField18.MultiLine = EvetHayirEnum.ehEvet;
                    NewField18.TextFont.Name = "Arial Narrow";
                    NewField18.Value = @"Milli Savunma Bakanlığı Sağlık Başkanı Onayı:";

                    shape2 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 195, 42, 195, 226, false);
                    shape2.Name = "shape2";
                    shape2.DrawStyle = DrawStyleConstants.vbSolid;

                    MEMBERS = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 12, 47, 194, 222, false);
                    MEMBERS.Name = "MEMBERS";
                    MEMBERS.FieldType = ReportFieldTypeEnum.ftVariable;
                    MEMBERS.MultiLine = EvetHayirEnum.ehEvet;
                    MEMBERS.WordBreak = EvetHayirEnum.ehEvet;
                    MEMBERS.ExpandTabs = EvetHayirEnum.ehEvet;
                    MEMBERS.TextFont.Size = 6;
                    MEMBERS.TextFont.Bold = true;
                    MEMBERS.Value = @"";

                    MADDE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 211, 23, 236, 28, false);
                    MADDE.Name = "MADDE";
                    MADDE.Visible = EvetHayirEnum.ehHayir;
                    MADDE.FieldType = ReportFieldTypeEnum.ftVariable;
                    MADDE.TextFormat = @"NOCR/";
                    MADDE.Value = @"";

                    USTMAKAMONAYI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 223, 195, 251, false);
                    USTMAKAMONAYI.Name = "USTMAKAMONAYI";
                    USTMAKAMONAYI.DrawStyle = DrawStyleConstants.vbSolid;
                    USTMAKAMONAYI.FillStyle = FillStyleConstants.vbFSTransparent;
                    USTMAKAMONAYI.FieldType = ReportFieldTypeEnum.ftVariable;
                    USTMAKAMONAYI.MultiLine = EvetHayirEnum.ehEvet;
                    USTMAKAMONAYI.TextFont.Name = "Arial Narrow";
                    USTMAKAMONAYI.Value = @"Sağlık Kurulu tarafından verilen karar S.Y. Yönetmeliği {%MADDE%} maddelerine/fıkralarına uygundur.

                                                                             Rütbesi, Sicil No.
                                                                             Adı Soyadı
                                                                             İmza, mühür";

                    HEAD1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 12, 47, 37, 52, false);
                    HEAD1.Name = "HEAD1";
                    HEAD1.TextFont.Size = 9;
                    HEAD1.TextFont.Bold = true;
                    HEAD1.Value = @"BAŞKAN";

                    KARAR1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 214, 40, 237, 62, false);
                    KARAR1.Name = "KARAR1";
                    KARAR1.Visible = EvetHayirEnum.ehHayir;
                    KARAR1.DrawStyle = DrawStyleConstants.vbSolid;
                    KARAR1.FillStyle = FillStyleConstants.vbFSTransparent;
                    KARAR1.FieldType = ReportFieldTypeEnum.ftVariable;
                    KARAR1.MultiLine = EvetHayirEnum.ehEvet;
                    KARAR1.WordBreak = EvetHayirEnum.ehEvet;
                    KARAR1.TextFont.Name = "Arial Narrow";
                    KARAR1.TextFont.Size = 8;
                    KARAR1.Value = @"{#KARAR#}";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    HealthCommitteeOfProfessors.GetHealthCommitteeOfProfessors_Class dataset_GetHealthCommitteeOfProfessors = ParentGroup.rsGroup.GetCurrentRecord<HealthCommitteeOfProfessors.GetHealthCommitteeOfProfessors_Class>(0);
                    TANI.CalcValue = @"";
                    NewField1.CalcValue = NewField1.Value;
                    KARAR.CalcValue = @"";
                    NewField3.CalcValue = NewField3.Value;
                    NewField4.CalcValue = NewField4.Value;
                    NewField18.CalcValue = NewField18.Value;
                    MEMBERS.CalcValue = @"";
                    MADDE.CalcValue = @"";
                    USTMAKAMONAYI.CalcValue = @"Sağlık Kurulu tarafından verilen karar S.Y. Yönetmeliği " + MyParentReport.ARKASAYFA.MADDE.FormattedValue + @" maddelerine/fıkralarına uygundur.

                                                                             Rütbesi, Sicil No.
                                                                             Adı Soyadı
                                                                             İmza, mühür";
                    HEAD1.CalcValue = HEAD1.Value;
                    KARAR1.CalcValue = (dataset_GetHealthCommitteeOfProfessors != null ? Globals.ToStringCore(dataset_GetHealthCommitteeOfProfessors.Karar) : "");
                    return new TTReportObject[] { TANI,NewField1,KARAR,NewField3,NewField4,NewField18,MEMBERS,MADDE,USTMAKAMONAYI,HEAD1,KARAR1};
                }

                public override void RunScript()
                {
#region ARKASAYFA HEADER_Script
                    string sNewLine = System.Environment.NewLine;
            TTObjectContext context = new TTObjectContext(true);
            string sObjectID = ((HealthCommitteeOfProfessorsReport)ParentReport).RuntimeParameters.TTOBJECTID.ToString();
            HealthCommitteeOfProfessors hcp = (HealthCommitteeOfProfessors)context.GetObject(new Guid(sObjectID),"HealthCommitteeOfProfessors");
            
            if(hcp == null)
                throw new Exception("Rapor Profesörler Sağlık Kurulu işlemi üzerinden alınmalıdır.\r\nReason: HealthCommitteeOfProfessors is null");
            
            this.KARAR.CalcValue = TTObjectClasses.Common.GetTextOfRTFString(this.KARAR1.CalcValue);            
            //Tanı
            int nCount = 1;
            this.TANI.CalcValue = "";
            
            BindingList<HealthCommittee_DiagnosisGrid.GetDiagnosisByParentObjectID_Class> pDiagnosis = null;
            pDiagnosis = HealthCommittee_DiagnosisGrid.GetDiagnosisByParentObjectID(sObjectID);
            foreach(HealthCommittee_DiagnosisGrid.GetDiagnosisByParentObjectID_Class pGrid in pDiagnosis)
            {
                this.TANI.CalcValue += nCount.ToString() + "- " + pGrid.Tanikodu + " " + pGrid.Taniadi;
                this.TANI.CalcValue += "\r\n";
                nCount++;
            }
            //Members
            if(hcp.MemberOfHealthCommitteeOfProf != null)
            {
                string sMembersText = sNewLine;
                string sMemberName = "", sMemberMilClass = "", sMemberRank = "", sMemberTitle = "";
                
                const int COLUMN_COUNT = 4;
                const int SPACE_COUNT = 60;
                int nCounter = 0;
                int nRow = 0;

                string sNameRow = new string(' ', SPACE_COUNT * COLUMN_COUNT);
                string sRankRow = new string(' ', SPACE_COUNT * COLUMN_COUNT);
                string sTitleRow = new string(' ', SPACE_COUNT * COLUMN_COUNT);
                
                foreach(HealthCommitteMemberGrid pMember in hcp.MemberOfHealthCommitteeOfProf.Members)
                {
                    sMemberName = pMember.Doctor.Name;
                    sMemberMilClass = pMember.Doctor.MilitaryClass == null ? "" : pMember.Doctor.MilitaryClass.Name;
                    sMemberRank = pMember.Doctor.Rank == null ? "" : pMember.Doctor.Rank.Name;
                    sMemberTitle = !pMember.Doctor.Title.HasValue ? "" : TTObjectClasses.Common.GetDisplayTextOfDataTypeEnum(pMember.Doctor.Title.Value);
                    
                    sNameRow = sNameRow.Insert(nCounter, sMemberName);
                    sRankRow = sRankRow.Insert(nCounter, sMemberMilClass + " " + sMemberRank);
                    sTitleRow = sTitleRow.Insert(nCounter, sMemberTitle);

                    nCounter += SPACE_COUNT;

                    nRow = nCounter / SPACE_COUNT;
                    int nRate = nRow % COLUMN_COUNT;
                    if (nRate == 0)
                    {
                        sNameRow = sNameRow.TrimEnd(new char[] { ' ' });
                        sMembersText += sNameRow + "\r\n";
                        sRankRow = sRankRow.TrimEnd(new char[] { ' ' });
                        sMembersText += sRankRow + "\r\n";
                        sTitleRow = sTitleRow.TrimEnd(new char[] { ' ' });
                        sMembersText += sTitleRow + "\r\n";

                        sNameRow = new string(' ', SPACE_COUNT * COLUMN_COUNT);
                        sRankRow = new string(' ', SPACE_COUNT * COLUMN_COUNT);
                        sTitleRow = new string(' ', SPACE_COUNT * COLUMN_COUNT);

                        sMembersText += "\r\n\r\n";
                        nCounter = 0;
                    }
                }
                
                sNameRow = sNameRow.TrimEnd(new char[] { ' ' });
                sMembersText += sNameRow + "\r\n";
                sRankRow = sRankRow.TrimEnd(new char[] { ' ' });
                sMembersText += sRankRow + "\r\n";
                sTitleRow = sTitleRow.TrimEnd(new char[] { ' ' });
                sMembersText += sTitleRow + "\r\n";
                
                this.MEMBERS.CalcValue = sMembersText;
                
            }
            //YETKİLİ ÜST MAKAM ONAYLARI
            string sAnectode = "[";
            string sUpperApproval = "YETKİLİ ÜST MAKAM ONAYLARI" + sNewLine;

            sUpperApproval += "Sağlık Kurulu tarafından verilen karar B.K. Yönetmeliği ";
            BindingList<HealthCommittee_MatterSliceAnectodeGrid.GetMatterSliceAnectodeByParentObjectID_Class> theAnectodes = null;
            theAnectodes = HealthCommittee_MatterSliceAnectodeGrid.GetMatterSliceAnectodeByParentObjectID(sObjectID);
            foreach(HealthCommittee_MatterSliceAnectodeGrid.GetMatterSliceAnectodeByParentObjectID_Class theAnectode in theAnectodes)
            {
                sAnectode += theAnectode.Madde+"/"+theAnectode.Dilim+"/"+theAnectode.Fikra;
                sAnectode += "\t";
            }
            sAnectode += "]";
            
            sUpperApproval += sAnectode + " Maddelerine/Fıkralarına uygundur." + sNewLine + sNewLine;
            
            if(hcp.MemberOfHealthCommitteeOfProf != null && hcp.MemberOfHealthCommitteeOfProf.MasterOfHealthCommittee != null)
            {
                string sEmpID = hcp.MemberOfHealthCommitteeOfProf.MasterOfHealthCommittee.EmploymentRecordID;
                string sMilClass = (hcp.MemberOfHealthCommitteeOfProf.MasterOfHealthCommittee.MilitaryClass == null ? "" : hcp.MemberOfHealthCommitteeOfProf.MasterOfHealthCommittee.MilitaryClass.Name);
                string sRank = (hcp.MemberOfHealthCommitteeOfProf.MasterOfHealthCommittee.Rank == null ? "" : hcp.MemberOfHealthCommitteeOfProf.MasterOfHealthCommittee.Rank.Name);
                
                sUpperApproval += "Rütbesi, Sicil no: "+ sRank + "" + " As.Hst.Bştbp.                               :"+ TTObjectClasses.Common.RecTime().Date.ToShortDateString() + sNewLine;
                sUpperApproval += "Adı Soyadı" + sNewLine;
                sUpperApproval += "İmza, Mühür" + sNewLine + sNewLine;
                //Name
                for(int i = 0;i<100;i++)
                    sUpperApproval += " ";
                sUpperApproval += hcp.MemberOfHealthCommitteeOfProf.MasterOfHealthCommittee.Name + sNewLine;
                
                //Rank
                for(int i = 0;i<100;i++)
                    sUpperApproval += " ";
                sUpperApproval += sRank + sNewLine;
                
                //title1
                for(int i = 0;i<100;i++)
                    sUpperApproval += " ";
                sUpperApproval += "XXXXXX Dekanı," + sNewLine;
                
                //title2
                for(int i = 0;i<100;i++)
                    sUpperApproval += " ";
                sUpperApproval += "Eğitim XXXXXX Baştabibi" + sNewLine;
            }
            this.USTMAKAMONAYI.CalcValue = sUpperApproval;
#endregion ARKASAYFA HEADER_Script
                }
            }
            public partial class ARKASAYFAGroupFooter : TTReportSection
            {
                public HealthCommitteeOfProfessorsReport MyParentReport
                {
                    get { return (HealthCommitteeOfProfessorsReport)ParentReport; }
                }
                 
                public ARKASAYFAGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 1;
                    IsVisible = EvetHayirEnum.ehHayir;
                    IsAutoSize = EvetHayirEnum.ehHayir;
                    RepeatCount = 0;
                    
                }
                
            }

        }

        public ARKASAYFAGroup ARKASAYFA;

        public partial class ANAGroup : TTReportGroup
        {
            public HealthCommitteeOfProfessorsReport MyParentReport
            {
                get { return (HealthCommitteeOfProfessorsReport)ParentReport; }
            }

            new public ANAGroupHeader Header()
            {
                return (ANAGroupHeader)_header;
            }

            new public ANAGroupFooter Footer()
            {
                return (ANAGroupFooter)_footer;
            }

            public TTReportField FRESOURCE { get {return Header().FRESOURCE;} }
            public TTReportField NewField3 { get {return Header().NewField3;} }
            public TTReportField NewField53 { get {return Header().NewField53;} }
            public TTReportField NewField21 { get {return Header().NewField21;} }
            public TTReportField NewField0 { get {return Header().NewField0;} }
            public TTReportField NewField1 { get {return Header().NewField1;} }
            public TTReportField NewField4 { get {return Header().NewField4;} }
            public TTReportField NewField5 { get {return Header().NewField5;} }
            public TTReportField NewField6 { get {return Header().NewField6;} }
            public TTReportField NewField7 { get {return Header().NewField7;} }
            public TTReportField NewField8 { get {return Header().NewField8;} }
            public TTReportField NewField10 { get {return Header().NewField10;} }
            public TTReportField MAKSAD { get {return Header().MAKSAD;} }
            public TTReportField MAKAM { get {return Header().MAKAM;} }
            public TTReportField RAPORTARIHI { get {return Header().RAPORTARIHI;} }
            public TTReportField KARANTINANO { get {return Header().KARANTINANO;} }
            public TTReportField YATISTARIHI { get {return Header().YATISTARIHI;} }
            public TTReportField TABURCUTARIHI { get {return Header().TABURCUTARIHI;} }
            public TTReportField NewField20 { get {return Header().NewField20;} }
            public TTReportField NewField22 { get {return Header().NewField22;} }
            public TTReportField NewField23 { get {return Header().NewField23;} }
            public TTReportField NewField25 { get {return Header().NewField25;} }
            public TTReportField LBLSICIL { get {return Header().LBLSICIL;} }
            public TTReportField NAME { get {return Header().NAME;} }
            public TTReportField FATHERNAME { get {return Header().FATHERNAME;} }
            public TTReportField BIRLIK { get {return Header().BIRLIK;} }
            public TTReportField SINIFRUTBE { get {return Header().SINIFRUTBE;} }
            public TTReportField SICILNO { get {return Header().SICILNO;} }
            public TTReportField NewField33 { get {return Header().NewField33;} }
            public TTReportField ADRES { get {return Header().ADRES;} }
            public TTReportField DTYER { get {return Header().DTYER;} }
            public TTReportField SKBASLIK { get {return Header().SKBASLIK;} }
            public TTReportField EMIRTARIHI { get {return Header().EMIRTARIHI;} }
            public TTReportField NewField40 { get {return Header().NewField40;} }
            public TTReportField EMIRNO { get {return Header().EMIRNO;} }
            public TTReportField RAPORNO { get {return Header().RAPORNO;} }
            public TTReportField NewField2 { get {return Header().NewField2;} }
            public TTReportField NewField42 { get {return Header().NewField42;} }
            public TTReportField NewField44 { get {return Header().NewField44;} }
            public TTReportField NewField45 { get {return Header().NewField45;} }
            public TTReportField BOY { get {return Header().BOY;} }
            public TTReportField NewField48 { get {return Header().NewField48;} }
            public TTReportField AGIRLIK { get {return Header().AGIRLIK;} }
            public TTReportField SKNEFESVERME { get {return Header().SKNEFESVERME;} }
            public TTReportField SKNEFESALMA { get {return Header().SKNEFESALMA;} }
            public TTReportField NewField49 { get {return Header().NewField49;} }
            public TTReportField NewField24 { get {return Header().NewField24;} }
            public TTReportField MUAMELESAYISI { get {return Header().MUAMELESAYISI;} }
            public TTReportField NewField51 { get {return Header().NewField51;} }
            public TTReportField NewField520 { get {return Header().NewField520;} }
            public TTReportField NewField52 { get {return Header().NewField52;} }
            public TTReportField NewField73 { get {return Header().NewField73;} }
            public TTReportField ACTID { get {return Header().ACTID;} }
            public TTReportField NewField75 { get {return Header().NewField75;} }
            public TTReportField PID { get {return Header().PID;} }
            public TTReportField KIMLIKNO { get {return Header().KIMLIKNO;} }
            public TTReportField TCNO { get {return Header().TCNO;} }
            public TTReportField NewField { get {return Header().NewField;} }
            public TTReportField VERGINO { get {return Header().VERGINO;} }
            public TTReportField NewField9 { get {return Header().NewField9;} }
            public TTReportField KADEME { get {return Header().KADEME;} }
            public TTReportShape shape13 { get {return Footer().shape13;} }
            public ANAGroup(TTReport parentReport, string name) : base(parentReport, name)
            {
                onConstruct();
            }
            public ANAGroup(TTReportGroup parentGroup, string name) : base(parentGroup, name)
            {
                onConstruct();
            }

            private void onConstruct()
            {
                _body = null;
                _header = new ANAGroupHeader(this);
                _footer = new ANAGroupFooter(this);

            }

            public partial class ANAGroupHeader : TTReportSection
            {
                public HealthCommitteeOfProfessorsReport MyParentReport
                {
                    get { return (HealthCommitteeOfProfessorsReport)ParentReport; }
                }
                
                public TTReportField FRESOURCE;
                public TTReportField NewField3;
                public TTReportField NewField53;
                public TTReportField NewField21;
                public TTReportField NewField0;
                public TTReportField NewField1;
                public TTReportField NewField4;
                public TTReportField NewField5;
                public TTReportField NewField6;
                public TTReportField NewField7;
                public TTReportField NewField8;
                public TTReportField NewField10;
                public TTReportField MAKSAD;
                public TTReportField MAKAM;
                public TTReportField RAPORTARIHI;
                public TTReportField KARANTINANO;
                public TTReportField YATISTARIHI;
                public TTReportField TABURCUTARIHI;
                public TTReportField NewField20;
                public TTReportField NewField22;
                public TTReportField NewField23;
                public TTReportField NewField25;
                public TTReportField LBLSICIL;
                public TTReportField NAME;
                public TTReportField FATHERNAME;
                public TTReportField BIRLIK;
                public TTReportField SINIFRUTBE;
                public TTReportField SICILNO;
                public TTReportField NewField33;
                public TTReportField ADRES;
                public TTReportField DTYER;
                public TTReportField SKBASLIK;
                public TTReportField EMIRTARIHI;
                public TTReportField NewField40;
                public TTReportField EMIRNO;
                public TTReportField RAPORNO;
                public TTReportField NewField2;
                public TTReportField NewField42;
                public TTReportField NewField44;
                public TTReportField NewField45;
                public TTReportField BOY;
                public TTReportField NewField48;
                public TTReportField AGIRLIK;
                public TTReportField SKNEFESVERME;
                public TTReportField SKNEFESALMA;
                public TTReportField NewField49;
                public TTReportField NewField24;
                public TTReportField MUAMELESAYISI;
                public TTReportField NewField51;
                public TTReportField NewField520;
                public TTReportField NewField52;
                public TTReportField NewField73;
                public TTReportField ACTID;
                public TTReportField NewField75;
                public TTReportField PID;
                public TTReportField KIMLIKNO;
                public TTReportField TCNO;
                public TTReportField NewField;
                public TTReportField VERGINO;
                public TTReportField NewField9;
                public TTReportField KADEME; 
                public ANAGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 105;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    IsAutoSize = EvetHayirEnum.ehHayir;
                    RepeatCount = 0;
                    
                    FRESOURCE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 36, 53, 73, 66, false);
                    FRESOURCE.Name = "FRESOURCE";
                    FRESOURCE.DrawStyle = DrawStyleConstants.vbSolid;
                    FRESOURCE.FillStyle = FillStyleConstants.vbFSTransparent;
                    FRESOURCE.DrawWidth = 2;
                    FRESOURCE.FieldType = ReportFieldTypeEnum.ftVariable;
                    FRESOURCE.MultiLine = EvetHayirEnum.ehEvet;
                    FRESOURCE.WordBreak = EvetHayirEnum.ehEvet;
                    FRESOURCE.TextFont.Name = "Arial Narrow";
                    FRESOURCE.TextFont.Size = 8;
                    FRESOURCE.Value = @"{#ARKASAYFA.FRESOURCE#}";

                    NewField3 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 71, 164, 76, false);
                    NewField3.Name = "NewField3";
                    NewField3.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField3.FillStyle = FillStyleConstants.vbFSTransparent;
                    NewField3.DrawWidth = 2;
                    NewField3.MultiLine = EvetHayirEnum.ehEvet;
                    NewField3.WordBreak = EvetHayirEnum.ehEvet;
                    NewField3.TextFont.Name = "Arial Narrow";
                    NewField3.Value = @"Muayeneye gönderen makam :";

                    NewField53 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 164, 16, 196, 66, false);
                    NewField53.Name = "NewField53";
                    NewField53.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField53.FillStyle = FillStyleConstants.vbFSTransparent;
                    NewField53.DrawWidth = 2;
                    NewField53.TextFont.Name = "Arial Narrow";
                    NewField53.Value = @"";

                    NewField21 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 73, 53, 93, 58, false);
                    NewField21.Name = "NewField21";
                    NewField21.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField21.FillStyle = FillStyleConstants.vbFSTransparent;
                    NewField21.DrawWidth = 2;
                    NewField21.MultiLine = EvetHayirEnum.ehEvet;
                    NewField21.WordBreak = EvetHayirEnum.ehEvet;
                    NewField21.TextFont.Name = "Arial Narrow";
                    NewField21.Value = @"D. Tarihi";

                    NewField0 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 16, 36, 25, false);
                    NewField0.Name = "NewField0";
                    NewField0.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField0.FillStyle = FillStyleConstants.vbFSTransparent;
                    NewField0.DrawWidth = 2;
                    NewField0.MultiLine = EvetHayirEnum.ehEvet;
                    NewField0.WordBreak = EvetHayirEnum.ehEvet;
                    NewField0.TextFont.Name = "Arial Narrow";
                    NewField0.Value = @"Muayene Yapan Sağlık Kurulu































































































";

                    NewField1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 53, 36, 66, false);
                    NewField1.Name = "NewField1";
                    NewField1.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1.FillStyle = FillStyleConstants.vbFSTransparent;
                    NewField1.DrawWidth = 2;
                    NewField1.MultiLine = EvetHayirEnum.ehEvet;
                    NewField1.WordBreak = EvetHayirEnum.ehEvet;
                    NewField1.TextFont.Name = "Arial Narrow";
                    NewField1.Value = @"XXXXXXde tedavide iken sağlık kuruluna sevk eden servis";

                    NewField4 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 38, 36, 43, false);
                    NewField4.Name = "NewField4";
                    NewField4.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField4.FillStyle = FillStyleConstants.vbFSTransparent;
                    NewField4.DrawWidth = 2;
                    NewField4.MultiLine = EvetHayirEnum.ehEvet;
                    NewField4.WordBreak = EvetHayirEnum.ehEvet;
                    NewField4.TextFont.Name = "Arial Narrow";
                    NewField4.Value = @"Karantina Nu";

                    NewField5 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 76, 84, 81, false);
                    NewField5.Name = "NewField5";
                    NewField5.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField5.FillStyle = FillStyleConstants.vbFSTransparent;
                    NewField5.DrawWidth = 2;
                    NewField5.MultiLine = EvetHayirEnum.ehEvet;
                    NewField5.WordBreak = EvetHayirEnum.ehEvet;
                    NewField5.TextFont.Name = "Arial Narrow";
                    NewField5.Value = @"Emir Tarihi           :";

                    NewField6 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 25, 36, 33, false);
                    NewField6.Name = "NewField6";
                    NewField6.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField6.FillStyle = FillStyleConstants.vbFSTransparent;
                    NewField6.DrawWidth = 2;
                    NewField6.MultiLine = EvetHayirEnum.ehEvet;
                    NewField6.WordBreak = EvetHayirEnum.ehEvet;
                    NewField6.TextFont.Name = "Arial Narrow";
                    NewField6.Value = @"Rapor Numarası";

                    NewField7 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 84, 76, 164, 96, false);
                    NewField7.Name = "NewField7";
                    NewField7.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField7.FillStyle = FillStyleConstants.vbFSTransparent;
                    NewField7.DrawWidth = 2;
                    NewField7.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField7.MultiLine = EvetHayirEnum.ehEvet;
                    NewField7.WordBreak = EvetHayirEnum.ehEvet;
                    NewField7.TextFont.Name = "Arial Narrow";
                    NewField7.Value = @"Ne maksatla muayene edildiği";

                    NewField8 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 43, 36, 48, false);
                    NewField8.Name = "NewField8";
                    NewField8.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField8.FillStyle = FillStyleConstants.vbFSTransparent;
                    NewField8.DrawWidth = 2;
                    NewField8.MultiLine = EvetHayirEnum.ehEvet;
                    NewField8.WordBreak = EvetHayirEnum.ehEvet;
                    NewField8.TextFont.Name = "Arial Narrow";
                    NewField8.Value = @"XXXXXXye Giriş";

                    NewField10 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 48, 36, 53, false);
                    NewField10.Name = "NewField10";
                    NewField10.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField10.FillStyle = FillStyleConstants.vbFSTransparent;
                    NewField10.DrawWidth = 2;
                    NewField10.MultiLine = EvetHayirEnum.ehEvet;
                    NewField10.WordBreak = EvetHayirEnum.ehEvet;
                    NewField10.TextFont.Name = "Arial Narrow";
                    NewField10.Value = @"XXXXXXden Çıkış";

                    MAKSAD = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 85, 82, 163, 95, false);
                    MAKSAD.Name = "MAKSAD";
                    MAKSAD.FillStyle = FillStyleConstants.vbFSTransparent;
                    MAKSAD.DrawWidth = 2;
                    MAKSAD.FieldType = ReportFieldTypeEnum.ftVariable;
                    MAKSAD.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    MAKSAD.MultiLine = EvetHayirEnum.ehEvet;
                    MAKSAD.WordBreak = EvetHayirEnum.ehEvet;
                    MAKSAD.TextFont.Name = "Arial Narrow";
                    MAKSAD.TextFont.Size = 8;
                    MAKSAD.Value = @"";

                    MAKAM = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 50, 71, 164, 76, false);
                    MAKAM.Name = "MAKAM";
                    MAKAM.FillStyle = FillStyleConstants.vbFSTransparent;
                    MAKAM.DrawWidth = 2;
                    MAKAM.FieldType = ReportFieldTypeEnum.ftVariable;
                    MAKAM.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    MAKAM.MultiLine = EvetHayirEnum.ehEvet;
                    MAKAM.WordBreak = EvetHayirEnum.ehEvet;
                    MAKAM.TextFont.Name = "Arial Narrow";
                    MAKAM.TextFont.Size = 7;
                    MAKAM.Value = @"{#ARKASAYFA.MAKAM#}";

                    RAPORTARIHI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 36, 33, 73, 38, false);
                    RAPORTARIHI.Name = "RAPORTARIHI";
                    RAPORTARIHI.DrawStyle = DrawStyleConstants.vbSolid;
                    RAPORTARIHI.FillStyle = FillStyleConstants.vbFSTransparent;
                    RAPORTARIHI.DrawWidth = 2;
                    RAPORTARIHI.FieldType = ReportFieldTypeEnum.ftVariable;
                    RAPORTARIHI.TextFormat = @"Short Date";
                    RAPORTARIHI.MultiLine = EvetHayirEnum.ehEvet;
                    RAPORTARIHI.WordBreak = EvetHayirEnum.ehEvet;
                    RAPORTARIHI.TextFont.Name = "Arial Narrow";
                    RAPORTARIHI.TextFont.Size = 8;
                    RAPORTARIHI.Value = @"{#ARKASAYFA.RAPORTARIHI#}";

                    KARANTINANO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 36, 38, 73, 43, false);
                    KARANTINANO.Name = "KARANTINANO";
                    KARANTINANO.DrawStyle = DrawStyleConstants.vbSolid;
                    KARANTINANO.FillStyle = FillStyleConstants.vbFSTransparent;
                    KARANTINANO.DrawWidth = 2;
                    KARANTINANO.FieldType = ReportFieldTypeEnum.ftVariable;
                    KARANTINANO.MultiLine = EvetHayirEnum.ehEvet;
                    KARANTINANO.WordBreak = EvetHayirEnum.ehEvet;
                    KARANTINANO.TextFont.Name = "Arial Narrow";
                    KARANTINANO.TextFont.Size = 8;
                    KARANTINANO.Value = @"{#ARKASAYFA.KPROKOLNO#}";

                    YATISTARIHI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 36, 43, 73, 48, false);
                    YATISTARIHI.Name = "YATISTARIHI";
                    YATISTARIHI.DrawStyle = DrawStyleConstants.vbSolid;
                    YATISTARIHI.FillStyle = FillStyleConstants.vbFSTransparent;
                    YATISTARIHI.DrawWidth = 2;
                    YATISTARIHI.FieldType = ReportFieldTypeEnum.ftVariable;
                    YATISTARIHI.TextFormat = @"Short Date";
                    YATISTARIHI.MultiLine = EvetHayirEnum.ehEvet;
                    YATISTARIHI.WordBreak = EvetHayirEnum.ehEvet;
                    YATISTARIHI.TextFont.Name = "Arial Narrow";
                    YATISTARIHI.TextFont.Size = 8;
                    YATISTARIHI.Value = @"{#ARKASAYFA.HGTARIHI#}";

                    TABURCUTARIHI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 36, 48, 73, 53, false);
                    TABURCUTARIHI.Name = "TABURCUTARIHI";
                    TABURCUTARIHI.DrawStyle = DrawStyleConstants.vbSolid;
                    TABURCUTARIHI.FillStyle = FillStyleConstants.vbFSTransparent;
                    TABURCUTARIHI.DrawWidth = 2;
                    TABURCUTARIHI.FieldType = ReportFieldTypeEnum.ftVariable;
                    TABURCUTARIHI.TextFormat = @"Short Date";
                    TABURCUTARIHI.MultiLine = EvetHayirEnum.ehEvet;
                    TABURCUTARIHI.WordBreak = EvetHayirEnum.ehEvet;
                    TABURCUTARIHI.TextFont.Name = "Arial Narrow";
                    TABURCUTARIHI.TextFont.Size = 8;
                    TABURCUTARIHI.Value = @"{#ARKASAYFA.TABURCUTARIHI#}";

                    NewField20 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 104, 16, 164, 25, false);
                    NewField20.Name = "NewField20";
                    NewField20.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField20.FillStyle = FillStyleConstants.vbFSTransparent;
                    NewField20.DrawWidth = 2;
                    NewField20.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField20.VertAlign = VerticalAlignmentEnum.vaBottom;
                    NewField20.TextFont.Name = "Arial Narrow";
                    NewField20.TextFont.Size = 9;
                    NewField20.Value = @"Künye";

                    NewField22 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 73, 33, 93, 38, false);
                    NewField22.Name = "NewField22";
                    NewField22.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField22.FillStyle = FillStyleConstants.vbFSTransparent;
                    NewField22.DrawWidth = 2;
                    NewField22.MultiLine = EvetHayirEnum.ehEvet;
                    NewField22.WordBreak = EvetHayirEnum.ehEvet;
                    NewField22.TextFont.Name = "Arial Narrow";
                    NewField22.Value = @"Adı Soyadı";

                    NewField23 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 73, 38, 93, 43, false);
                    NewField23.Name = "NewField23";
                    NewField23.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField23.FillStyle = FillStyleConstants.vbFSTransparent;
                    NewField23.DrawWidth = 2;
                    NewField23.MultiLine = EvetHayirEnum.ehEvet;
                    NewField23.WordBreak = EvetHayirEnum.ehEvet;
                    NewField23.TextFont.Name = "Arial Narrow";
                    NewField23.Value = @"Baba Adı";

                    NewField25 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 73, 43, 93, 48, false);
                    NewField25.Name = "NewField25";
                    NewField25.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField25.FillStyle = FillStyleConstants.vbFSTransparent;
                    NewField25.DrawWidth = 2;
                    NewField25.MultiLine = EvetHayirEnum.ehEvet;
                    NewField25.WordBreak = EvetHayirEnum.ehEvet;
                    NewField25.TextFont.Name = "Arial Narrow";
                    NewField25.Value = @"Sınıf Rütbe";

                    LBLSICIL = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 73, 48, 93, 53, false);
                    LBLSICIL.Name = "LBLSICIL";
                    LBLSICIL.DrawStyle = DrawStyleConstants.vbSolid;
                    LBLSICIL.FillStyle = FillStyleConstants.vbFSTransparent;
                    LBLSICIL.DrawWidth = 2;
                    LBLSICIL.MultiLine = EvetHayirEnum.ehEvet;
                    LBLSICIL.WordBreak = EvetHayirEnum.ehEvet;
                    LBLSICIL.TextFont.Name = "Arial Narrow";
                    LBLSICIL.Value = @"Sicil Nu";

                    NAME = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 93, 33, 164, 38, false);
                    NAME.Name = "NAME";
                    NAME.DrawStyle = DrawStyleConstants.vbSolid;
                    NAME.FillStyle = FillStyleConstants.vbFSTransparent;
                    NAME.DrawWidth = 2;
                    NAME.FieldType = ReportFieldTypeEnum.ftVariable;
                    NAME.MultiLine = EvetHayirEnum.ehEvet;
                    NAME.WordBreak = EvetHayirEnum.ehEvet;
                    NAME.TextFont.Name = "Arial Narrow";
                    NAME.TextFont.Size = 8;
                    NAME.Value = @"{#ARKASAYFA.PNAME#} {#ARKASAYFA.PSURNAME#}";

                    FATHERNAME = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 93, 38, 164, 43, false);
                    FATHERNAME.Name = "FATHERNAME";
                    FATHERNAME.DrawStyle = DrawStyleConstants.vbSolid;
                    FATHERNAME.FillStyle = FillStyleConstants.vbFSTransparent;
                    FATHERNAME.DrawWidth = 2;
                    FATHERNAME.FieldType = ReportFieldTypeEnum.ftVariable;
                    FATHERNAME.MultiLine = EvetHayirEnum.ehEvet;
                    FATHERNAME.WordBreak = EvetHayirEnum.ehEvet;
                    FATHERNAME.TextFont.Name = "Arial Narrow";
                    FATHERNAME.TextFont.Size = 8;
                    FATHERNAME.Value = @"{#ARKASAYFA.FATHERNAME#}";

                    BIRLIK = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 93, 25, 164, 33, false);
                    BIRLIK.Name = "BIRLIK";
                    BIRLIK.DrawStyle = DrawStyleConstants.vbSolid;
                    BIRLIK.FillStyle = FillStyleConstants.vbFSTransparent;
                    BIRLIK.DrawWidth = 2;
                    BIRLIK.FieldType = ReportFieldTypeEnum.ftVariable;
                    BIRLIK.MultiLine = EvetHayirEnum.ehEvet;
                    BIRLIK.WordBreak = EvetHayirEnum.ehEvet;
                    BIRLIK.TextFont.Name = "Arial Narrow";
                    BIRLIK.TextFont.Size = 8;
                    BIRLIK.Value = @"";

                    SINIFRUTBE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 93, 43, 164, 48, false);
                    SINIFRUTBE.Name = "SINIFRUTBE";
                    SINIFRUTBE.DrawStyle = DrawStyleConstants.vbSolid;
                    SINIFRUTBE.FillStyle = FillStyleConstants.vbFSTransparent;
                    SINIFRUTBE.DrawWidth = 2;
                    SINIFRUTBE.FieldType = ReportFieldTypeEnum.ftVariable;
                    SINIFRUTBE.MultiLine = EvetHayirEnum.ehEvet;
                    SINIFRUTBE.WordBreak = EvetHayirEnum.ehEvet;
                    SINIFRUTBE.TextFont.Name = "Arial Narrow";
                    SINIFRUTBE.TextFont.Size = 8;
                    SINIFRUTBE.Value = @"";

                    SICILNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 93, 48, 164, 53, false);
                    SICILNO.Name = "SICILNO";
                    SICILNO.DrawStyle = DrawStyleConstants.vbSolid;
                    SICILNO.FillStyle = FillStyleConstants.vbFSTransparent;
                    SICILNO.DrawWidth = 2;
                    SICILNO.FieldType = ReportFieldTypeEnum.ftVariable;
                    SICILNO.MultiLine = EvetHayirEnum.ehEvet;
                    SICILNO.WordBreak = EvetHayirEnum.ehEvet;
                    SICILNO.TextFont.Name = "Arial Narrow";
                    SICILNO.TextFont.Size = 8;
                    SICILNO.Value = @"";

                    NewField33 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 73, 58, 93, 66, false);
                    NewField33.Name = "NewField33";
                    NewField33.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField33.FillStyle = FillStyleConstants.vbFSTransparent;
                    NewField33.DrawWidth = 2;
                    NewField33.MultiLine = EvetHayirEnum.ehEvet;
                    NewField33.WordBreak = EvetHayirEnum.ehEvet;
                    NewField33.TextFont.Name = "Arial Narrow";
                    NewField33.Value = @"Devamlı Adresi";

                    ADRES = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 93, 58, 164, 66, false);
                    ADRES.Name = "ADRES";
                    ADRES.DrawStyle = DrawStyleConstants.vbSolid;
                    ADRES.FillStyle = FillStyleConstants.vbFSTransparent;
                    ADRES.DrawWidth = 2;
                    ADRES.FieldType = ReportFieldTypeEnum.ftVariable;
                    ADRES.MultiLine = EvetHayirEnum.ehEvet;
                    ADRES.WordBreak = EvetHayirEnum.ehEvet;
                    ADRES.TextFont.Name = "Arial Narrow";
                    ADRES.TextFont.Size = 8;
                    ADRES.Value = @"{#ARKASAYFA.ADRES#}";

                    DTYER = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 93, 53, 164, 58, false);
                    DTYER.Name = "DTYER";
                    DTYER.DrawStyle = DrawStyleConstants.vbSolid;
                    DTYER.FillStyle = FillStyleConstants.vbFSTransparent;
                    DTYER.DrawWidth = 2;
                    DTYER.FieldType = ReportFieldTypeEnum.ftVariable;
                    DTYER.TextFormat = @"Short Date";
                    DTYER.MultiLine = EvetHayirEnum.ehEvet;
                    DTYER.WordBreak = EvetHayirEnum.ehEvet;
                    DTYER.TextFont.Name = "Arial Narrow";
                    DTYER.TextFont.Size = 8;
                    DTYER.Value = @"{#ARKASAYFA.DTARIHI#}";

                    SKBASLIK = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 36, 16, 104, 25, false);
                    SKBASLIK.Name = "SKBASLIK";
                    SKBASLIK.DrawStyle = DrawStyleConstants.vbSolid;
                    SKBASLIK.FillStyle = FillStyleConstants.vbFSTransparent;
                    SKBASLIK.DrawWidth = 2;
                    SKBASLIK.FieldType = ReportFieldTypeEnum.ftExpression;
                    SKBASLIK.MultiLine = EvetHayirEnum.ehEvet;
                    SKBASLIK.WordBreak = EvetHayirEnum.ehEvet;
                    SKBASLIK.TextFont.Name = "Arial Narrow";
                    SKBASLIK.TextFont.Size = 9;
                    SKBASLIK.Value = @"TTObjectClasses.SystemParameter.GetParameterValue(""SKRAPORHEADER"",""XXXXXX PROF.SAĞ.KRL"")";

                    EMIRTARIHI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 36, 76, 83, 80, false);
                    EMIRTARIHI.Name = "EMIRTARIHI";
                    EMIRTARIHI.FillStyle = FillStyleConstants.vbFSTransparent;
                    EMIRTARIHI.DrawWidth = 2;
                    EMIRTARIHI.FieldType = ReportFieldTypeEnum.ftVariable;
                    EMIRTARIHI.TextFormat = @"Short Date";
                    EMIRTARIHI.TextFont.Name = "Arial Narrow";
                    EMIRTARIHI.TextFont.Size = 8;
                    EMIRTARIHI.Value = @"{#ARKASAYFA.EVRAKTARIHI#}";

                    NewField40 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 81, 84, 86, false);
                    NewField40.Name = "NewField40";
                    NewField40.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField40.FillStyle = FillStyleConstants.vbFSTransparent;
                    NewField40.DrawWidth = 2;
                    NewField40.MultiLine = EvetHayirEnum.ehEvet;
                    NewField40.WordBreak = EvetHayirEnum.ehEvet;
                    NewField40.TextFont.Name = "Arial Narrow";
                    NewField40.Value = @"Emir Şube ve Nu :";

                    EMIRNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 36, 81, 84, 85, false);
                    EMIRNO.Name = "EMIRNO";
                    EMIRNO.FillStyle = FillStyleConstants.vbFSTransparent;
                    EMIRNO.DrawWidth = 2;
                    EMIRNO.FieldType = ReportFieldTypeEnum.ftVariable;
                    EMIRNO.TextFont.Name = "Arial Narrow";
                    EMIRNO.TextFont.Size = 8;
                    EMIRNO.Value = @"{#ARKASAYFA.EVRAKSAYISI#}";

                    RAPORNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 36, 25, 73, 33, false);
                    RAPORNO.Name = "RAPORNO";
                    RAPORNO.DrawStyle = DrawStyleConstants.vbSolid;
                    RAPORNO.FillStyle = FillStyleConstants.vbFSTransparent;
                    RAPORNO.DrawWidth = 2;
                    RAPORNO.FieldType = ReportFieldTypeEnum.ftVariable;
                    RAPORNO.MultiLine = EvetHayirEnum.ehEvet;
                    RAPORNO.WordBreak = EvetHayirEnum.ehEvet;
                    RAPORNO.TextFont.Name = "Arial Narrow";
                    RAPORNO.TextFont.Size = 8;
                    RAPORNO.Value = @"{#ARKASAYFA.RAPORNO#}";

                    NewField2 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 33, 36, 38, false);
                    NewField2.Name = "NewField2";
                    NewField2.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField2.FillStyle = FillStyleConstants.vbFSTransparent;
                    NewField2.DrawWidth = 2;
                    NewField2.MultiLine = EvetHayirEnum.ehEvet;
                    NewField2.WordBreak = EvetHayirEnum.ehEvet;
                    NewField2.TextFont.Name = "Arial Narrow";
                    NewField2.Value = @"Rapor Tarihi";

                    NewField42 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 91, 22, 96, false);
                    NewField42.Name = "NewField42";
                    NewField42.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField42.FillStyle = FillStyleConstants.vbFSTransparent;
                    NewField42.DrawWidth = 2;
                    NewField42.MultiLine = EvetHayirEnum.ehEvet;
                    NewField42.WordBreak = EvetHayirEnum.ehEvet;
                    NewField42.TextFont.Name = "Arial Narrow";
                    NewField42.Value = @"Ağırlık";

                    NewField44 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 48, 91, 66, 96, false);
                    NewField44.Name = "NewField44";
                    NewField44.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField44.FillStyle = FillStyleConstants.vbFSTransparent;
                    NewField44.DrawWidth = 2;
                    NewField44.MultiLine = EvetHayirEnum.ehEvet;
                    NewField44.WordBreak = EvetHayirEnum.ehEvet;
                    NewField44.TextFont.Name = "Arial Narrow";
                    NewField44.Value = @"Soluk Verme";

                    NewField45 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 86, 22, 91, false);
                    NewField45.Name = "NewField45";
                    NewField45.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField45.FillStyle = FillStyleConstants.vbFSTransparent;
                    NewField45.DrawWidth = 2;
                    NewField45.MultiLine = EvetHayirEnum.ehEvet;
                    NewField45.WordBreak = EvetHayirEnum.ehEvet;
                    NewField45.TextFont.Name = "Arial Narrow";
                    NewField45.Value = @"Boy";

                    BOY = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 22, 86, 48, 91, false);
                    BOY.Name = "BOY";
                    BOY.DrawStyle = DrawStyleConstants.vbSolid;
                    BOY.FillStyle = FillStyleConstants.vbFSTransparent;
                    BOY.DrawWidth = 2;
                    BOY.FieldType = ReportFieldTypeEnum.ftVariable;
                    BOY.MultiLine = EvetHayirEnum.ehEvet;
                    BOY.WordBreak = EvetHayirEnum.ehEvet;
                    BOY.TextFont.Name = "Arial Narrow";
                    BOY.TextFont.Size = 8;
                    BOY.Value = @"{#ARKASAYFA.BOY#}";

                    NewField48 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 48, 86, 66, 91, false);
                    NewField48.Name = "NewField48";
                    NewField48.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField48.FillStyle = FillStyleConstants.vbFSTransparent;
                    NewField48.DrawWidth = 2;
                    NewField48.MultiLine = EvetHayirEnum.ehEvet;
                    NewField48.WordBreak = EvetHayirEnum.ehEvet;
                    NewField48.TextFont.Name = "Arial Narrow";
                    NewField48.Value = @"Soluk Alma";

                    AGIRLIK = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 22, 91, 48, 96, false);
                    AGIRLIK.Name = "AGIRLIK";
                    AGIRLIK.DrawStyle = DrawStyleConstants.vbSolid;
                    AGIRLIK.FillStyle = FillStyleConstants.vbFSTransparent;
                    AGIRLIK.DrawWidth = 2;
                    AGIRLIK.FieldType = ReportFieldTypeEnum.ftVariable;
                    AGIRLIK.MultiLine = EvetHayirEnum.ehEvet;
                    AGIRLIK.WordBreak = EvetHayirEnum.ehEvet;
                    AGIRLIK.TextFont.Name = "Arial Narrow";
                    AGIRLIK.TextFont.Size = 8;
                    AGIRLIK.Value = @"{#ARKASAYFA.KILO#}";

                    SKNEFESVERME = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 66, 91, 84, 96, false);
                    SKNEFESVERME.Name = "SKNEFESVERME";
                    SKNEFESVERME.DrawStyle = DrawStyleConstants.vbSolid;
                    SKNEFESVERME.FillStyle = FillStyleConstants.vbFSTransparent;
                    SKNEFESVERME.DrawWidth = 2;
                    SKNEFESVERME.FieldType = ReportFieldTypeEnum.ftVariable;
                    SKNEFESVERME.MultiLine = EvetHayirEnum.ehEvet;
                    SKNEFESVERME.WordBreak = EvetHayirEnum.ehEvet;
                    SKNEFESVERME.TextFont.Name = "Arial Narrow";
                    SKNEFESVERME.TextFont.Size = 8;
                    SKNEFESVERME.Value = @"";

                    SKNEFESALMA = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 66, 86, 84, 91, false);
                    SKNEFESALMA.Name = "SKNEFESALMA";
                    SKNEFESALMA.DrawStyle = DrawStyleConstants.vbSolid;
                    SKNEFESALMA.FillStyle = FillStyleConstants.vbFSTransparent;
                    SKNEFESALMA.DrawWidth = 2;
                    SKNEFESALMA.FieldType = ReportFieldTypeEnum.ftVariable;
                    SKNEFESALMA.MultiLine = EvetHayirEnum.ehEvet;
                    SKNEFESALMA.WordBreak = EvetHayirEnum.ehEvet;
                    SKNEFESALMA.TextFont.Name = "Arial Narrow";
                    SKNEFESALMA.TextFont.Size = 8;
                    SKNEFESALMA.Value = @"";

                    NewField49 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 164, 71, 196, 96, false);
                    NewField49.Name = "NewField49";
                    NewField49.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField49.FillStyle = FillStyleConstants.vbFSTransparent;
                    NewField49.DrawWidth = 2;
                    NewField49.MultiLine = EvetHayirEnum.ehEvet;
                    NewField49.WordBreak = EvetHayirEnum.ehEvet;
                    NewField49.TextFont.Name = "Arial Narrow";
                    NewField49.Value = @"Kaçıncı Muayenesi (Sağlık Fişine Göre)































































































































































































































































































































































































(Sağlık fişine göre)";

                    NewField24 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 73, 25, 93, 33, false);
                    NewField24.Name = "NewField24";
                    NewField24.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField24.FillStyle = FillStyleConstants.vbFSTransparent;
                    NewField24.DrawWidth = 2;
                    NewField24.MultiLine = EvetHayirEnum.ehEvet;
                    NewField24.WordBreak = EvetHayirEnum.ehEvet;
                    NewField24.TextFont.Name = "Arial Narrow";
                    NewField24.Value = @"Birlik";

                    MUAMELESAYISI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 165, 84, 194, 95, false);
                    MUAMELESAYISI.Name = "MUAMELESAYISI";
                    MUAMELESAYISI.FillStyle = FillStyleConstants.vbFSTransparent;
                    MUAMELESAYISI.DrawWidth = 2;
                    MUAMELESAYISI.FieldType = ReportFieldTypeEnum.ftVariable;
                    MUAMELESAYISI.MultiLine = EvetHayirEnum.ehEvet;
                    MUAMELESAYISI.WordBreak = EvetHayirEnum.ehEvet;
                    MUAMELESAYISI.TextFont.Name = "Arial Narrow";
                    MUAMELESAYISI.TextFont.Size = 8;
                    MUAMELESAYISI.Value = @"{#ARKASAYFA.MUAMELESAYISI#}. İŞLEM";

                    NewField51 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 96, 48, 105, false);
                    NewField51.Name = "NewField51";
                    NewField51.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField51.FillStyle = FillStyleConstants.vbFSTransparent;
                    NewField51.DrawWidth = 2;
                    NewField51.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField51.MultiLine = EvetHayirEnum.ehEvet;
                    NewField51.WordBreak = EvetHayirEnum.ehEvet;
                    NewField51.TextFont.Name = "Arial Narrow";
                    NewField51.Value = @"Muayene ve tetkik yapan servis ve  laboratuvarlar";

                    NewField520 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 48, 96, 196, 105, false);
                    NewField520.Name = "NewField520";
                    NewField520.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField520.FillStyle = FillStyleConstants.vbFSTransparent;
                    NewField520.DrawWidth = 2;
                    NewField520.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField520.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField520.TextFont.Name = "Arial Narrow";
                    NewField520.Value = @"BULGULAR";

                    NewField52 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 8, 196, 15, false);
                    NewField52.Name = "NewField52";
                    NewField52.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField52.TextFont.Name = "Arial";
                    NewField52.TextFont.Size = 14;
                    NewField52.TextFont.Bold = true;
                    NewField52.Value = @"TÜRK SİLAHLI KUVVETLERİ SAĞLIK RAPORU";

                    NewField73 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 165, 17, 176, 22, false);
                    NewField73.Name = "NewField73";
                    NewField73.FillStyle = FillStyleConstants.vbFSTransparent;
                    NewField73.TextFont.Name = "Arial Narrow";
                    NewField73.TextFont.Size = 8;
                    NewField73.Value = @"İşlem Nu";

                    ACTID = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 177, 17, 195, 22, false);
                    ACTID.Name = "ACTID";
                    ACTID.FillStyle = FillStyleConstants.vbFSTransparent;
                    ACTID.FieldType = ReportFieldTypeEnum.ftVariable;
                    ACTID.HorzAlign = HorizontalAlignmentEnum.haRight;
                    ACTID.TextFont.Name = "Arial Narrow";
                    ACTID.TextFont.Size = 8;
                    ACTID.Value = @"{#ARKASAYFA.ISLEMNO#}";

                    NewField75 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 165, 62, 176, 67, false);
                    NewField75.Name = "NewField75";
                    NewField75.FillStyle = FillStyleConstants.vbFSTransparent;
                    NewField75.TextFont.Name = "Arial Narrow";
                    NewField75.TextFont.Size = 8;
                    NewField75.Value = @"Hasta Nu";

                    PID = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 176, 62, 195, 67, false);
                    PID.Name = "PID";
                    PID.FillStyle = FillStyleConstants.vbFSTransparent;
                    PID.FieldType = ReportFieldTypeEnum.ftVariable;
                    PID.HorzAlign = HorizontalAlignmentEnum.haRight;
                    PID.TextFont.Name = "Arial Narrow";
                    PID.TextFont.Size = 8;
                    PID.Value = @"{#ARKASAYFA.PID#}";

                    KIMLIKNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 66, 36, 71, false);
                    KIMLIKNO.Name = "KIMLIKNO";
                    KIMLIKNO.DrawStyle = DrawStyleConstants.vbSolid;
                    KIMLIKNO.FillStyle = FillStyleConstants.vbFSTransparent;
                    KIMLIKNO.DrawWidth = 2;
                    KIMLIKNO.CaseFormat = CaseFormatEnum.fcTitleCase;
                    KIMLIKNO.TextFont.Name = "Arial Narrow";
                    KIMLIKNO.Value = @"TC Kimlik Nu";

                    TCNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 36, 66, 73, 71, false);
                    TCNO.Name = "TCNO";
                    TCNO.DrawStyle = DrawStyleConstants.vbSolid;
                    TCNO.FillStyle = FillStyleConstants.vbFSTransparent;
                    TCNO.DrawWidth = 2;
                    TCNO.FieldType = ReportFieldTypeEnum.ftVariable;
                    TCNO.TextFont.Name = "Arial Narrow";
                    TCNO.TextFont.Size = 9;
                    TCNO.Value = @"{#ARKASAYFA.TCNO#}";

                    NewField = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 73, 66, 91, 71, false);
                    NewField.Name = "NewField";
                    NewField.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField.FillStyle = FillStyleConstants.vbFSTransparent;
                    NewField.DrawWidth = 2;
                    NewField.TextFont.Name = "Arial Narrow";
                    NewField.Value = @"Vergi Nu";

                    VERGINO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 91, 66, 135, 71, false);
                    VERGINO.Name = "VERGINO";
                    VERGINO.DrawStyle = DrawStyleConstants.vbSolid;
                    VERGINO.FillStyle = FillStyleConstants.vbFSTransparent;
                    VERGINO.DrawWidth = 2;
                    VERGINO.FieldType = ReportFieldTypeEnum.ftVariable;
                    VERGINO.TextFont.Name = "Arial Narrow";
                    VERGINO.TextFont.Size = 9;
                    VERGINO.Value = @"";

                    NewField9 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 135, 66, 164, 71, false);
                    NewField9.Name = "NewField9";
                    NewField9.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField9.DrawWidth = 2;
                    NewField9.TextFont.Name = "Arial Narrow";
                    NewField9.Value = @"Derece/Kademe";

                    KADEME = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 164, 66, 196, 71, false);
                    KADEME.Name = "KADEME";
                    KADEME.DrawStyle = DrawStyleConstants.vbSolid;
                    KADEME.FillStyle = FillStyleConstants.vbFSTransparent;
                    KADEME.DrawWidth = 2;
                    KADEME.FieldType = ReportFieldTypeEnum.ftVariable;
                    KADEME.TextFont.Name = "Arial Narrow";
                    KADEME.TextFont.Size = 9;
                    KADEME.Value = @"";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    HealthCommitteeOfProfessors.GetHealthCommitteeOfProfessors_Class dataset_GetHealthCommitteeOfProfessors = MyParentReport.ARKASAYFA.rsGroup.GetCurrentRecord<HealthCommitteeOfProfessors.GetHealthCommitteeOfProfessors_Class>(0);
                    FRESOURCE.CalcValue = (dataset_GetHealthCommitteeOfProfessors != null ? Globals.ToStringCore(dataset_GetHealthCommitteeOfProfessors.Fresource) : "");
                    NewField3.CalcValue = NewField3.Value;
                    NewField53.CalcValue = NewField53.Value;
                    NewField21.CalcValue = NewField21.Value;
                    NewField0.CalcValue = NewField0.Value;
                    NewField1.CalcValue = NewField1.Value;
                    NewField4.CalcValue = NewField4.Value;
                    NewField5.CalcValue = NewField5.Value;
                    NewField6.CalcValue = NewField6.Value;
                    NewField7.CalcValue = NewField7.Value;
                    NewField8.CalcValue = NewField8.Value;
                    NewField10.CalcValue = NewField10.Value;
                    MAKSAD.CalcValue = @"";
                    MAKAM.CalcValue = (dataset_GetHealthCommitteeOfProfessors != null ? Globals.ToStringCore(dataset_GetHealthCommitteeOfProfessors.Makam) : "");
                    RAPORTARIHI.CalcValue = (dataset_GetHealthCommitteeOfProfessors != null ? Globals.ToStringCore(dataset_GetHealthCommitteeOfProfessors.Raportarihi) : "");
                    KARANTINANO.CalcValue = (dataset_GetHealthCommitteeOfProfessors != null ? Globals.ToStringCore(dataset_GetHealthCommitteeOfProfessors.Kprokolno) : "");
                    YATISTARIHI.CalcValue = (dataset_GetHealthCommitteeOfProfessors != null ? Globals.ToStringCore(dataset_GetHealthCommitteeOfProfessors.Hgtarihi) : "");
                    TABURCUTARIHI.CalcValue = (dataset_GetHealthCommitteeOfProfessors != null ? Globals.ToStringCore(dataset_GetHealthCommitteeOfProfessors.Taburcutarihi) : "");
                    NewField20.CalcValue = NewField20.Value;
                    NewField22.CalcValue = NewField22.Value;
                    NewField23.CalcValue = NewField23.Value;
                    NewField25.CalcValue = NewField25.Value;
                    LBLSICIL.CalcValue = LBLSICIL.Value;
                    NAME.CalcValue = (dataset_GetHealthCommitteeOfProfessors != null ? Globals.ToStringCore(dataset_GetHealthCommitteeOfProfessors.Pname) : "") + @" " + (dataset_GetHealthCommitteeOfProfessors != null ? Globals.ToStringCore(dataset_GetHealthCommitteeOfProfessors.Psurname) : "");
                    FATHERNAME.CalcValue = (dataset_GetHealthCommitteeOfProfessors != null ? Globals.ToStringCore(dataset_GetHealthCommitteeOfProfessors.FatherName) : "");
                    BIRLIK.CalcValue = @"";
                    SINIFRUTBE.CalcValue = @"";
                    SICILNO.CalcValue = @"";
                    NewField33.CalcValue = NewField33.Value;
                    ADRES.CalcValue = (dataset_GetHealthCommitteeOfProfessors != null ? Globals.ToStringCore(dataset_GetHealthCommitteeOfProfessors.Adres) : "");
                    DTYER.CalcValue = (dataset_GetHealthCommitteeOfProfessors != null ? Globals.ToStringCore(dataset_GetHealthCommitteeOfProfessors.Dtarihi) : "");
                    EMIRTARIHI.CalcValue = (dataset_GetHealthCommitteeOfProfessors != null ? Globals.ToStringCore(dataset_GetHealthCommitteeOfProfessors.Evraktarihi) : "");
                    NewField40.CalcValue = NewField40.Value;
                    EMIRNO.CalcValue = (dataset_GetHealthCommitteeOfProfessors != null ? Globals.ToStringCore(dataset_GetHealthCommitteeOfProfessors.Evraksayisi) : "");
                    RAPORNO.CalcValue = (dataset_GetHealthCommitteeOfProfessors != null ? Globals.ToStringCore(dataset_GetHealthCommitteeOfProfessors.Raporno) : "");
                    NewField2.CalcValue = NewField2.Value;
                    NewField42.CalcValue = NewField42.Value;
                    NewField44.CalcValue = NewField44.Value;
                    NewField45.CalcValue = NewField45.Value;
                    BOY.CalcValue = (dataset_GetHealthCommitteeOfProfessors != null ? Globals.ToStringCore(dataset_GetHealthCommitteeOfProfessors.Boy) : "");
                    NewField48.CalcValue = NewField48.Value;
                    AGIRLIK.CalcValue = (dataset_GetHealthCommitteeOfProfessors != null ? Globals.ToStringCore(dataset_GetHealthCommitteeOfProfessors.Kilo) : "");
                    SKNEFESVERME.CalcValue = @"";
                    SKNEFESALMA.CalcValue = @"";
                    NewField49.CalcValue = NewField49.Value;
                    NewField24.CalcValue = NewField24.Value;
                    MUAMELESAYISI.CalcValue = (dataset_GetHealthCommitteeOfProfessors != null ? Globals.ToStringCore(dataset_GetHealthCommitteeOfProfessors.Muamelesayisi) : "") + @". İŞLEM";
                    NewField51.CalcValue = NewField51.Value;
                    NewField520.CalcValue = NewField520.Value;
                    NewField52.CalcValue = NewField52.Value;
                    NewField73.CalcValue = NewField73.Value;
                    ACTID.CalcValue = (dataset_GetHealthCommitteeOfProfessors != null ? Globals.ToStringCore(dataset_GetHealthCommitteeOfProfessors.Islemno) : "");
                    NewField75.CalcValue = NewField75.Value;
                    PID.CalcValue = (dataset_GetHealthCommitteeOfProfessors != null ? Globals.ToStringCore(dataset_GetHealthCommitteeOfProfessors.Pid) : "");
                    KIMLIKNO.CalcValue = KIMLIKNO.Value;
                    TCNO.CalcValue = (dataset_GetHealthCommitteeOfProfessors != null ? Globals.ToStringCore(dataset_GetHealthCommitteeOfProfessors.Tcno) : "");
                    NewField.CalcValue = NewField.Value;
                    VERGINO.CalcValue = @"";
                    NewField9.CalcValue = NewField9.Value;
                    KADEME.CalcValue = @"";
                    SKBASLIK.CalcValue = TTObjectClasses.SystemParameter.GetParameterValue("SKRAPORHEADER","XXXXXX PROF.SAĞ.KRL");
                    return new TTReportObject[] { FRESOURCE,NewField3,NewField53,NewField21,NewField0,NewField1,NewField4,NewField5,NewField6,NewField7,NewField8,NewField10,MAKSAD,MAKAM,RAPORTARIHI,KARANTINANO,YATISTARIHI,TABURCUTARIHI,NewField20,NewField22,NewField23,NewField25,LBLSICIL,NAME,FATHERNAME,BIRLIK,SINIFRUTBE,SICILNO,NewField33,ADRES,DTYER,EMIRTARIHI,NewField40,EMIRNO,RAPORNO,NewField2,NewField42,NewField44,NewField45,BOY,NewField48,AGIRLIK,SKNEFESVERME,SKNEFESALMA,NewField49,NewField24,MUAMELESAYISI,NewField51,NewField520,NewField52,NewField73,ACTID,NewField75,PID,KIMLIKNO,TCNO,NewField,VERGINO,NewField9,KADEME,SKBASLIK};
                }

                public override void RunScript()
                {
#region ANA HEADER_Script
                    TTObjectContext context = new TTObjectContext(true);
            string sObjectID = ((HealthCommitteeOfProfessorsReport)ParentReport).RuntimeParameters.TTOBJECTID.ToString();
            HealthCommitteeOfProfessors hcp = (HealthCommitteeOfProfessors)context.GetObject(new Guid(sObjectID),"HealthCommitteeOfProfessors");
            
            if(hcp == null)
                throw new Exception("Rapor Profesörler Sağlık Kurulu işlemi üzerinden alınmalıdır.\r\nReason: HealthCommitteeOfProfessors is null");
#endregion ANA HEADER_Script
                }
            }
            public partial class ANAGroupFooter : TTReportSection
            {
                public HealthCommitteeOfProfessorsReport MyParentReport
                {
                    get { return (HealthCommitteeOfProfessorsReport)ParentReport; }
                }
                
                public TTReportShape shape13; 
                public ANAGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 5;
                    IsAligned = EvetHayirEnum.ehEvet;
                    IsAutoSize = EvetHayirEnum.ehHayir;
                    RepeatCount = 0;
                    
                    shape13 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 10, 0, 196, 0, false);
                    shape13.Name = "shape13";
                    shape13.DrawStyle = DrawStyleConstants.vbSolid;
                    shape13.DrawWidth = 2;

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    return new TTReportObject[] { };
                }
            }

        }

        public ANAGroup ANA;

        public partial class MAINGroup : TTReportGroup
        {
            public HealthCommitteeOfProfessorsReport MyParentReport
            {
                get { return (HealthCommitteeOfProfessorsReport)ParentReport; }
            }

            new public MAINGroupBody Body()
            {
                return (MAINGroupBody)_body;
            }
            public TTReportField YENIBOLUM { get {return Body().YENIBOLUM;} }
            public TTReportShape shape6 { get {return Body().shape6;} }
            public TTReportField BOLUMRAPOR { get {return Body().BOLUMRAPOR;} }
            public TTReportField BOLUMRAPOR1 { get {return Body().BOLUMRAPOR1;} }
            public TTReportShape shape8 { get {return Body().shape8;} }
            public TTReportShape shape9 { get {return Body().shape9;} }
            public TTReportField RAPORTARIHI { get {return Body().RAPORTARIHI;} }
            public TTReportField RAPOR1 { get {return Body().RAPOR1;} }
            public TTReportField OBJECTID { get {return Body().OBJECTID;} }
            public MAINGroup(TTReport parentReport, string name) : base(parentReport, name)
            {
                onConstruct();
            }
            public MAINGroup(TTReportGroup parentGroup, string name) : base(parentGroup, name)
            {
                onConstruct();
            }

             
            protected override TTReportNqlDataSet GetReportNqlDataSet()
            {
                TTBaseReportNqlData[] list = new TTBaseReportNqlData[1];
                list[0] = new TTReportNqlData<HealthCommitteeExamination.GetHCExaminationByMasterAction_Class>("GetHCExaminationByMasterAction", HealthCommitteeExamination.GetHCExaminationByMasterAction((string)TTObjectDefManager.Instance.DataTypes["String50"].ConvertValue(MyParentReport.RuntimeParameters.TTOBJECTID)));
                return new TTReportNqlDataSet(ParentGroup, list);
            }

            private void onConstruct()
            {
                _header = null;
                _footer = null;
                _body = new MAINGroupBody(this);
                DataSourceType = DataSourceTypeEnum.dstSelfRS;
            }

            public partial class MAINGroupBody : TTReportSection
            {
                public HealthCommitteeOfProfessorsReport MyParentReport
                {
                    get { return (HealthCommitteeOfProfessorsReport)ParentReport; }
                }
                
                public TTReportField YENIBOLUM;
                public TTReportShape shape6;
                public TTReportField BOLUMRAPOR;
                public TTReportField BOLUMRAPOR1;
                public TTReportShape shape8;
                public TTReportShape shape9;
                public TTReportField RAPORTARIHI;
                public TTReportField RAPOR1;
                public TTReportField OBJECTID; 
                public MAINGroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 11;
                    RepeatCount = 0;
                    
                    YENIBOLUM = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 11, 1, 47, 13, false);
                    YENIBOLUM.Name = "YENIBOLUM";
                    YENIBOLUM.FillStyle = FillStyleConstants.vbFSTransparent;
                    YENIBOLUM.FieldType = ReportFieldTypeEnum.ftVariable;
                    YENIBOLUM.CaseFormat = CaseFormatEnum.fcTitleCase;
                    YENIBOLUM.MultiLine = EvetHayirEnum.ehEvet;
                    YENIBOLUM.WordBreak = EvetHayirEnum.ehEvet;
                    YENIBOLUM.ExpandTabs = EvetHayirEnum.ehEvet;
                    YENIBOLUM.TextFont.Name = "Arial Narrow";
                    YENIBOLUM.TextFont.Size = 7;
                    YENIBOLUM.Value = @"{#BOLUM#} ({%RAPORTARIHI%} / {#RAPORNO#})";

                    shape6 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 10, 1, 10, 8, false);
                    shape6.Name = "shape6";
                    shape6.DrawStyle = DrawStyleConstants.vbSolid;
                    shape6.DrawWidth = 2;
                    shape6.ExtendTo = ExtendToEnum.extPageHeight;

                    BOLUMRAPOR = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 49, 0, 190, 3, false);
                    BOLUMRAPOR.Name = "BOLUMRAPOR";
                    BOLUMRAPOR.FillStyle = FillStyleConstants.vbFSTransparent;
                    BOLUMRAPOR.FieldType = ReportFieldTypeEnum.ftVariable;
                    BOLUMRAPOR.MultiLine = EvetHayirEnum.ehEvet;
                    BOLUMRAPOR.NoClip = EvetHayirEnum.ehEvet;
                    BOLUMRAPOR.WordBreak = EvetHayirEnum.ehEvet;
                    BOLUMRAPOR.ExpandTabs = EvetHayirEnum.ehEvet;
                    BOLUMRAPOR.TextFont.Name = "Arial Narrow";
                    BOLUMRAPOR.TextFont.Size = 7;
                    BOLUMRAPOR.Value = @"";

                    BOLUMRAPOR1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 49, 7, 97, 9, false);
                    BOLUMRAPOR1.Name = "BOLUMRAPOR1";
                    BOLUMRAPOR1.Visible = EvetHayirEnum.ehHayir;
                    BOLUMRAPOR1.FillStyle = FillStyleConstants.vbFSTransparent;
                    BOLUMRAPOR1.FieldType = ReportFieldTypeEnum.ftVariable;
                    BOLUMRAPOR1.MultiLine = EvetHayirEnum.ehEvet;
                    BOLUMRAPOR1.NoClip = EvetHayirEnum.ehEvet;
                    BOLUMRAPOR1.WordBreak = EvetHayirEnum.ehEvet;
                    BOLUMRAPOR1.ExpandTabs = EvetHayirEnum.ehEvet;
                    BOLUMRAPOR1.TextFont.Name = "Arial Narrow";
                    BOLUMRAPOR1.TextFont.Size = 7;
                    BOLUMRAPOR1.Value = @"{#DOKTORADI#}
{#DOKTORSINIFI#} {#DOKTORRUTBE#}
{#DOKTORUNVAN#}";

                    shape8 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 48, 1, 48, 8, false);
                    shape8.Name = "shape8";
                    shape8.DrawStyle = DrawStyleConstants.vbSolid;
                    shape8.DrawWidth = 2;
                    shape8.ExtendTo = ExtendToEnum.extPageHeight;

                    shape9 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 196, 1, 196, 8, false);
                    shape9.Name = "shape9";
                    shape9.DrawStyle = DrawStyleConstants.vbSolid;
                    shape9.DrawWidth = 2;
                    shape9.ExtendTo = ExtendToEnum.extPageHeight;

                    RAPORTARIHI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 212, 0, 237, 5, false);
                    RAPORTARIHI.Name = "RAPORTARIHI";
                    RAPORTARIHI.Visible = EvetHayirEnum.ehHayir;
                    RAPORTARIHI.FieldType = ReportFieldTypeEnum.ftVariable;
                    RAPORTARIHI.TextFormat = @"Short Date";
                    RAPORTARIHI.Value = @"{#RAPORTARIHI#}";

                    RAPOR1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 212, 6, 237, 11, false);
                    RAPOR1.Name = "RAPOR1";
                    RAPOR1.Visible = EvetHayirEnum.ehHayir;
                    RAPOR1.FieldType = ReportFieldTypeEnum.ftVariable;
                    RAPOR1.Value = @"{#RAPOR#}";

                    OBJECTID = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 239, 0, 264, 5, false);
                    OBJECTID.Name = "OBJECTID";
                    OBJECTID.Visible = EvetHayirEnum.ehHayir;
                    OBJECTID.FieldType = ReportFieldTypeEnum.ftVariable;
                    OBJECTID.Value = @"{#OBJECTID#}";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    HealthCommitteeExamination.GetHCExaminationByMasterAction_Class dataset_GetHCExaminationByMasterAction = ParentGroup.rsGroup.GetCurrentRecord<HealthCommitteeExamination.GetHCExaminationByMasterAction_Class>(0);
                    RAPORTARIHI.CalcValue = (dataset_GetHCExaminationByMasterAction != null ? Globals.ToStringCore(dataset_GetHCExaminationByMasterAction.Raportarihi) : "");
                    YENIBOLUM.CalcValue = (dataset_GetHCExaminationByMasterAction != null ? Globals.ToStringCore(dataset_GetHCExaminationByMasterAction.Bolum) : "") + @" (" + MyParentReport.MAIN.RAPORTARIHI.FormattedValue + @" / " + (dataset_GetHCExaminationByMasterAction != null ? Globals.ToStringCore(dataset_GetHCExaminationByMasterAction.Raporno) : "") + @")";
                    BOLUMRAPOR.CalcValue = @"";
                    BOLUMRAPOR1.CalcValue = (dataset_GetHCExaminationByMasterAction != null ? Globals.ToStringCore(dataset_GetHCExaminationByMasterAction.Doktoradi) : "") + @"
" + (dataset_GetHCExaminationByMasterAction != null ? Globals.ToStringCore(dataset_GetHCExaminationByMasterAction.Doktorsinifi) : "") + @" " + (dataset_GetHCExaminationByMasterAction != null ? Globals.ToStringCore(dataset_GetHCExaminationByMasterAction.Doktorrutbe) : "") + @"
" + (dataset_GetHCExaminationByMasterAction != null ? Globals.ToStringCore(dataset_GetHCExaminationByMasterAction.Doktorunvan) : "");
                    RAPOR1.CalcValue = (dataset_GetHCExaminationByMasterAction != null ? Globals.ToStringCore(dataset_GetHCExaminationByMasterAction.Rapor) : "");
                    OBJECTID.CalcValue = (dataset_GetHCExaminationByMasterAction != null ? Globals.ToStringCore(dataset_GetHCExaminationByMasterAction.ObjectID) : "");
                    return new TTReportObject[] { RAPORTARIHI,YENIBOLUM,BOLUMRAPOR,BOLUMRAPOR1,RAPOR1,OBJECTID};
                }

                public override void RunScript()
                {
#region MAIN BODY_Script
                    TTObjectContext context = new TTObjectContext(true);
            string sObjectID = this.OBJECTID.CalcValue;
            HealthCommitteeExamination hcp = (HealthCommitteeExamination)context.GetObject(new Guid(sObjectID),"HealthCommitteeExamination");
            
            string sKarar = TTObjectClasses.Common.GetTextOfRTFString(this.RAPOR1.CalcValue);
            
            this.BOLUMRAPOR.CalcValue = sKarar + "\r\n\r\n" + this.BOLUMRAPOR1.CalcValue;
#endregion MAIN BODY_Script
                }
            }

        }

        public MAINGroup MAIN;

        private ReportRuntimeParameters _runtimeParameters;
        public ReportRuntimeParameters RuntimeParameters
        {
            get { return _runtimeParameters; }
        }

        public HealthCommitteeOfProfessorsReport()
        {
            ARKASAYFA = new ARKASAYFAGroup(this,"ARKASAYFA");
            ANA = new ANAGroup(ARKASAYFA,"ANA");
            MAIN = new MAINGroup(ANA,"MAIN");
            _runtimeParameters = new ReportRuntimeParameters();
            
            ReportParameter reportParameter;
            reportParameter = Parameters.Add("TTOBJECTID", "28EB27BF-E3E8-449C-B0DF-037338707DAD", "ID", @"", true, false, false, new Guid("53c9e989-dad5-4f3f-b973-d0bda68f0942"));
        }

        public override void PrepareTTReport(Dictionary<string, object> parameters)
        {
            if (parameters.ContainsKey("TTOBJECTID"))
                _runtimeParameters.TTOBJECTID = (string)TTObjectDefManager.Instance.DataTypes["String50"].ConvertValue(parameters["TTOBJECTID"]);
            Name = "HEALTHCOMMITTEEOFPROFESSORSREPORT";
            Caption = "Profesörler Sağlık Kurulu Raporu";
            FieldDefaults = SetFieldDefaultProperties();
            RTFDefaults = SetRTFDefaultProperties();
            HTMLDefaults = SetHTMLDefaultProperties();
            ShapeDefaults = SetShapeDefaultProperties();
        }

        protected TTReportField SetFieldDefaultProperties()
        {
            TTReportField fd = new TTReportField();

            fd.Visible = EvetHayirEnum.ehEvet;
            fd.ForeColor = System.Drawing.Color.Black;
            fd.FillColor = System.Drawing.Color.White;
            fd.DrawStyle = DrawStyleConstants.vbInvisible;
            fd.FillStyle = FillStyleConstants.vbFSSolid;
            fd.DrawWidth = 1;

            fd.FieldType = ReportFieldTypeEnum.ftConstant;
            fd.CaseFormat = CaseFormatEnum.fcNoChange;
            fd.TextFormat = "";
            fd.TextColor = System.Drawing.Color.Black;
            fd.FontAngle = 0;
            fd.HorzAlign = HorizontalAlignmentEnum.haleft;
            fd.VertAlign = VerticalAlignmentEnum.vaTop;
            fd.MultiLine = EvetHayirEnum.ehHayir;
            fd.NoClip = EvetHayirEnum.ehHayir;
            fd.WordBreak = EvetHayirEnum.ehHayir;
            fd.ExpandTabs = EvetHayirEnum.ehHayir;
            fd.CrossTabRole = CrosstabRoleEnum.ctrNone;
            fd.CrossTabValues = "";
            fd.ExcelCol = 0;
            fd.ObjectDefName = "";
            fd.DataMember = "";
            fd.TextFont.Name = "Courier New";
            fd.TextFont.Size = 10;
            fd.TextFont.Bold = false;
            fd.TextFont.Italic = false;
            fd.TextFont.Underline = false;
            fd.TextFont.Strikethrough = false;
            fd.TextFont.CharSet = 162;
            return fd;
        }

        protected TTReportRTF SetRTFDefaultProperties()
        {
            TTReportRTF fd = new TTReportRTF();

            fd.Visible = EvetHayirEnum.ehEvet;
            fd.ForeColor = System.Drawing.Color.Black;
            fd.FillColor = System.Drawing.Color.White;
            fd.DrawStyle = DrawStyleConstants.vbInvisible;
            fd.FillStyle = FillStyleConstants.vbFSSolid;
            fd.DrawWidth = 1;

            fd.CanExpand = EvetHayirEnum.ehEvet;
            fd.CanShrink = EvetHayirEnum.ehEvet;
            fd.CanSplit = EvetHayirEnum.ehEvet;
            fd.EvaluateValue = EvetHayirEnum.ehHayir;
            return fd;
        }

        protected TTReportHTML SetHTMLDefaultProperties()
        {
            TTReportHTML fd = new TTReportHTML();

            fd.Visible = EvetHayirEnum.ehEvet;
            fd.ForeColor = System.Drawing.Color.Black;
            fd.FillColor = System.Drawing.Color.White;
            fd.DrawStyle = DrawStyleConstants.vbInvisible;
            fd.FillStyle = FillStyleConstants.vbFSSolid;
            fd.DrawWidth = 1;

            fd.CanExpand = EvetHayirEnum.ehEvet;
            fd.CanShrink = EvetHayirEnum.ehEvet;
            fd.CanSplit = EvetHayirEnum.ehEvet;
            fd.EvaluateValue = EvetHayirEnum.ehHayir;
            return fd;
        }

        protected TTReportShape SetShapeDefaultProperties()
        {
            TTReportShape fd = new TTReportShape();

            fd.Visible = EvetHayirEnum.ehEvet;
            fd.ForeColor = System.Drawing.Color.Black;
            fd.FillColor = System.Drawing.Color.White;
            fd.DrawStyle = DrawStyleConstants.vbSolid;
            fd.FillStyle = FillStyleConstants.vbFSSolid;
            fd.DrawWidth = 1;
            return fd;
        }

    }
}