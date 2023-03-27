/**
 * System configuration for Angular 2 samples
 * Adjust as necessary for your application needs.
 */
(function (global) {
    System.config({
        baseURL: './',
        paths: {
            // paths serve as alias
            'npm:': 'node_modules/',
            'NebulaClient:*': './app/NebulaClient/*.js',
            'app:*': './app/*.js',
            'Fw:*': './app/Fw/*.js',
            'System:*': './app/System/*.js',
            'AppModules:*': './app/*.js',
            'Modules:*': './Modules/*.js',
            'ExternalService:*': './app/NebulaClient/Services/External/*.js',
            'ObjectClassService:*': './app/NebulaClient/Services/ObjectService/*.js'
        },
        // map tells the System loader where to look for things
        map: {
            // our app is within the app folder
            app: 'app',
            // angular bundles
            '@angular/animations': 'npm:@angular/animations/bundles/animations.umd.js',
            '@angular/animations/browser': 'npm:@angular/animations/bundles/animations-browser.umd.js',
            '@angular/platform-browser/animations': 'npm:@angular/platform-browser/bundles/platform-browser-animations.umd.js',
            '@angular/core': 'npm:@angular/core/bundles/core.umd.js',
            '@angular/common': 'npm:@angular/common/bundles/common.umd.js',
            '@angular/common/http': 'npm:@angular/common/bundles/common-http.umd.js',
            '@angular/compiler': 'npm:@angular/compiler/bundles/compiler.umd.js',
            '@angular/platform-browser': 'npm:@angular/platform-browser/bundles/platform-browser.umd.js',
            '@angular/platform-browser-dynamic': 'npm:@angular/platform-browser-dynamic/bundles/platform-browser-dynamic.umd.js',
            '@angular/http': 'npm:@angular/http/bundles/http.umd.js',
            '@angular/router': 'npm:@angular/router/bundles/router.umd.js',
            '@angular/forms': 'npm:@angular/forms/bundles/forms.umd.js',
            '@aspnet/signalr': 'npm:@aspnet/signalr/dist/browser/signalr.js',
            // other libraries
            'ng2-signalr': 'npm:ng2-signalr/bundles/ng2-signalr.umd.js',
            'devextreme': 'npm:devextreme',
            'jszip': 'npm:jszip/dist/jszip.min.js',
            'devextreme-angular': 'npm:devextreme-angular',
            'jquery': './Scripts/jquery.js',
            'rxjs': 'npm:rxjs',
            'angular2-in-memory-web-api': 'npm:angular2-in-memory-web-api',
            'ng2-simple-timer': 'npm:ng2-simple-timer',
            'angular2-jwt': 'npm:angular2-jwt',
            'quill': 'npm:quill',
            'tslib': 'npm:tslib',
            'file-saver': 'npm:file-saver',
            'webcam': 'npm:webcamjs',
            'screenfull': 'npm:screenfull',
            'object-hash': 'npm:object-hash',
            'ng2-responsive': 'npm:ng2-responsive',
            'object-path': 'npm:object-path',
            // local folder shortcuts
            NebulaClient: './app/NebulaClient',
            Fw: './app/Fw',
            System: './app/System',
            Modules: './Modules',
            AppModules: './app',
            ExternalService: './app/NebulaClient/Services/External',
            ObjectClassService: './app/NebulaClient/Services/ObjectService',
            // Globalize configuration
            'globalize': 'npm:globalize/dist/globalize',
            'cldr': 'npm:cldrjs/dist/cldr',
            'cldr-data': 'npm:cldr-data',
            'plugin-json': 'npm:systemjs-plugin-json/json.js',
            'text': '/js/systemjs-text-plugin.js'
            //'ngx-perfect-scrollbar': 'npm:ngx-perfect-scrollbar'
        },
        meta: {
            '*.json': {
                loader: 'plugin-json'
            },
            "*.scss": { "loader": "sass-loader" },
            "*.sass": { "loader": "sass-loader" }
        },
        sassPluginOptions: {
            "copyAssets": true,
            "rewriteUrl": true
        },
        // packages tells the System loader how to load when no filename and/or no extension
        packages: {
            app: {
                main: './main.js',
                defaultExtension: 'js',
                meta: {
                    './*.js': {
                        loader: '/js/systemjs-angular-loader.js'
                    },
                    '*.json': { loader: 'plugin-json' }
                }
            },
            NebulaClient: {
                defaultExtension: 'js',
                meta: {
                    './*.js': {
                        loader: '/js/systemjs-angular-loader.js'
                    },
                    '*.json': { loader: 'plugin-json' }
                }
            },
            Fw: {
                defaultExtension: 'js',
                meta: {
                    './*.js': {
                        loader: '/js/systemjs-angular-loader.js'
                    },
                    '*.json': { loader: 'plugin-json' }
                }
            },
            System: {
                defaultExtension: 'js',
                meta: {
                    './*.js': {
                        loader: '/js/systemjs-angular-loader.js'
                    },
                    '*.json': { loader: 'plugin-json' }
                }
            },
            AppModules: {
                defaultExtension: 'js',
                meta: {
                    './*.js': {
                        loader: '/js/systemjs-angular-loader.js'
                    },
                    '*.json': { loader: 'plugin-json' }
                }
            },
            Modules: {
                defaultExtension: 'js',
                meta: {
                    './*.js': {
                        loader: '/js/systemjs-angular-loader.js'
                    },
                    '*.json': { loader: 'plugin-json' }
                }
            },
            ExternalService: {
                defaultExtension: 'js',
                meta: {
                    './*.js': {
                        loader: '/js/systemjs-angular-loader.js'
                    },
                    '*.json': { loader: 'plugin-json' }
                }
            },
            ObjectClassService: {
                defaultExtension: 'js',
                meta: {
                    './*.js': {
                        loader: '/js/systemjs-angular-loader.js'
                    },
                    '*.json': { loader: 'plugin-json' }
                }
            },
            rxjs: {
                main: './Rx.js',
                defaultExtension: 'js'
            },
            quill: {
                main: 'dist/quill.js',
                defaultExtension: 'js'
            },
            screenfull: {
                main: 'dist/screenfull.js',
                defaultExtension: 'js'
            },
            'object-hash': {
                main: 'dist/object_hash.js',
                defaultExtension: 'js'
            },
            'ng2-responsive': {
                main: './index.js',
                defaultExtension: 'js'
            },
            //'ngx-perfect-scrollbar': {
            //    main: './bundles/ngx-perfect-scrollbar.umd.js',
            //    //main: './dist/ngx-perfect-scrollbar.es5.js',
            //    defaultExtension: 'js'
            //},
            'webcam': {
                main: 'webcam.min.js',
                defaultExtension: 'js'
            },
            tslib: {
                main: 'tslib.js',
                defaultExtension: 'js'
            },
            'file-saver': {
                main: 'FileSaver.js',
                defaultExtension: 'js'
            },
            'angular2-jwt': {
                main: 'angular2-jwt.js',
                defaultExtension: 'js'
            },
            'NebulaClient/ClassTransformer': {
                main: './index.js',
                defaultExtension: 'js'
            },
            'angular2-in-memory-web-api': {
                main: './index.js',
                defaultExtension: 'js'
            },
            'ng2-simple-timer': {
                main: './index.js',
                defaultExtension: 'js'
            },
            'devextreme-angular': { main: 'index.js', defaultExtension: 'js' },
            'devextreme': { defaultExtension: 'js' },

            // Globalize configuration
            'globalize': {
                main: '../globalize.js',
                defaultExtension: 'js'
            },
            'cldr': {
                main: '../cldr.js',
                defaultExtension: 'js'
            },
            'object-path': {
                main: './index.js',
                defaultExtension: 'js'
            },
        }
    });
})(this);