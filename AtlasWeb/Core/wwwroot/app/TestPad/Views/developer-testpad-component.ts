import { Component } from '@angular/core';

@Component({
  selector: 'developer-testpad',
  template: `

<h1>Atlas Geliştirici Test Modülü</h1>
<div>
 <nav id="list-nav">
    <a routerLink="externalweb" routerLinkActive="active">External Web Servis Çağrısı Test Ekranı</a>
    <a routerLink="serialize" routerLinkActive="active">Model Nesneleri Serialize Test Ekranı</a>
    <a routerLink="activepatientservice" routerLinkActive="active">Aktif Hasta Servisi Test Ekranı</a>
    <a routerLink="activeuserservice" routerLinkActive="active">Aktif Kullanıcı Servisi Test Ekranı</a>
    <a routerLink="dynamiccomp" routerLinkActive="active">Dynamic Component Test</a>
    <a routerLink="templateeditor" routerLinkActive="active">Template Editor Test</a>
    <a routerLink="statepanel" routerLinkActive="active">State Panel Test</a>
    <a routerLink="showmessage" routerLinkActive="active">Show Message Test</a>
    <a routerLink="jsonresult" routerLinkActive="active">Json Result Test Test</a>
    <a routerLink="formeditor" routerLinkActive="active">Form Editor Test</a>
    <a routerLink="querylist" routerLinkActive="active">Query List Test</a>
    <a routerLink="querylistparam" routerLinkActive="active">Query List with Params Test</a>
    <a routerLink="treatmentmaterial" routerLinkActive="active">Treatment Material Test</a>
    <a routerLink="readonlyform" routerLinkActive="active">Readonly Form Test</a>
    <a routerLink="esign" routerLinkActive="active">E-Signature Test Form</a>
    <a routerLink="reporttest" routerLinkActive="active">Report Test Pad</a>
    <a routerLink="controltest" routerLinkActive="active">Control Test</a>
    <a routerLink="toolsmenutest" routerLinkActive="active">Tools Menu Test</a>
    <a routerLink="memleaktest" routerLinkActive="active">Memoy Leak Test</a>
    <a routerLink="dropdowntest" routerLinkActive="active">Drop Down Test</a>
    <a routerLink="messagetest" routerLinkActive="active">Message Test</a>
    <a routerLink="definitiontest" routerLinkActive="active">Definition Test</a>
    <a routerLink="definitionform/def" routerLinkActive="active">Definition Form</a>
    <a routerLink="hizmettest" routerLinkActive="active">Hizmet Giriş Test Form</a>
    <a routerLink="reportdesignertest" routerLinkActive="active">Report Test Designer</a>
    <a routerLink="pagingtest" routerLinkActive="active">Paging Test Form</a>
    <a routerLink="dynamicform" routerLinkActive="active">Dynamic Form Test</a>
    <a routerLink="dynamicreporting" routerLinkActive="active">Dynamic Report Test</a>
    <a routerLink="dynamicreportingedit" routerLinkActive="active">Dynamic Report DataSource Edit</a>
    <a routerLink="dashboardtest" routerLinkActive="active">Dashboard Test</a>
    <a routerLink="dashboardedit" routerLinkActive="active">Dashboard DataSource Edit</a>
    </nav>
</div>
<hr/>
<router-outlet></router-outlet>
<!-- Routed views go here -->
`,
  styles: [` nav#list-nav {
  padding:0;
  display: block;
}

#list-nav a {
  display:inline-block;
  margin: 2px 0px;
}

#list-nav a {
  text-decoration:none;
  padding:5px 5px;
  background:#485e49;
  color:#eee;
  text-align:center;
  border-left:1px solid #fff;
}

#list-nav a:hover {
  background:#a2b3a1;
  color:#000
}`]
})
export class DeveloperTestPadComponent {
}
