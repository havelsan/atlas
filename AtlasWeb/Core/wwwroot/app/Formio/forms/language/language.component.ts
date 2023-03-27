import { Component, EventEmitter } from '@angular/core';
import { FormioOptions, FormioAppConfig } from 'angular-formio';

@Component({
  selector: 'app-language',
  templateUrl: './language.component.html',
  styleUrls: ['./language.component.scss']
})
export class LanguageComponent {
  public language: EventEmitter<string>;
  public options: FormioOptions;

  /* tslint:disable:max-line-length */
  constructor(public config: FormioAppConfig) {
    this.language = new EventEmitter();
    this.options = {
      i18n: {
        sp: {
          'First Name': 'Nombre de pila',
          'Last Name': 'Apellido',
          'Enter your first name': 'Ponga su primer nombre',
          'Enter your last name': 'Introduce tu apellido',
          Email: 'Email',
          'Enter your email address':
            'Ingrese su dirección de correo electrónico',
          'Phone Number': 'Número de teléfono',
          'Enter your phone number': 'Ingrese su número telefónico',
          Submit: 'Enviar',
          'This is a dynamically rendered JSON form built with Form.io. Using a simple drag-and-drop form builder, you can create any form that includes e-signatures, wysiwyg editors, date fields, layout components, data grids, surveys, etc.':
            'Se trata de un formulario JSON dinámicamente generado con Form.io. Utilizando un simple constructor de formularios de arrastrar y soltar, puede crear cualquier formulario que incluya firmas electrónicas, editores wysiwyg, campos de fecha, componentes de diseño, cuadrículas de datos, encuestas, etc.',
          'Form.io Example Form': 'Ejemplo Form.io',
          Survey: 'Encuesta',
          'How would you rate the Form.io platform?':
            '¿Cómo calificaría la plataforma Form.io?',
          'How was Customer Support?':
            '¿Cómo fue el servicio de atención al cliente?',
          'Overall Experience?': '¿Experiencia general?',
          Excellent: 'Excelente',
          Great: 'Estupendo',
          Good: 'Bueno',
          Average: 'Promedio',
          Poor: 'Pobre',
          'Sign above': 'Signo de arriba'
        },
        ch: {
          'First Name': '名字',
          'Last Name': '姓',
          'Enter your first name': '输入你的名字',
          'Enter your last name': '输入你的姓氏',
          Email: '电子邮件',
          'Enter your email address': '输入你的电子邮箱地址',
          'Phone Number': '电话号码',
          'Enter your phone number': '输入你的电话号码',
          Submit: '提交',
          'This is a dynamically rendered JSON form built with Form.io. Using a simple drag-and-drop form builder, you can create any form that includes e-signatures, wysiwyg editors, date fields, layout components, data grids, surveys, etc.':
            '这是一个使用Form.io构建的动态呈现的JSON表单。使用简单的拖放表单构建器，您可以创建包括电子签名，wysiwyg编辑器，日期字段，布局组件，数据网格，调查等的任何表单。',
          'Form.io Example Form': 'Form.io示例表单',
          Survey: '调查',
          'How would you rate the Form.io platform?': '你如何评价Form.io平台？',
          'How was Customer Support?': '客户支持如何？',
          'Overall Experience?': '总体体验？',
          Excellent: '优秀',
          Great: '大',
          Good: '好',
          Average: '平均',
          Poor: '错',
          'Sign above': '上面标注'
        }
      }
    };
  }
  /* tslint:enable:max-line-length */

  changeLanguage(lang: string) {
    console.log(lang);
    this.language.emit(lang);
  }
}
