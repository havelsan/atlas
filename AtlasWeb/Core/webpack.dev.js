const path = require('path');
const webpack = require('webpack');
const HtmlWebpackPlugin = require('html-webpack-plugin');
const CopyWebpackPlugin = require('copy-webpack-plugin');
const MiniCssExtractPlugin = require("mini-css-extract-plugin");
const ForkTsCheckerWebpackPlugin = require('fork-ts-checker-webpack-plugin');
const terminalImage = require('terminal-image');
const isHotOnly = process.argv.filter(x => x === '--hot-only').length > 0;

console.log('\x1b[32m\x1b[1m', '###### USING DEVELOPMENT #####');
console.log("isHotOnly=" + isHotOnly);
terminalImage.file('wwwroot/Content/ATLASDEV.jpg').then(x => {
    console.log('\n');
    console.log(x);
});

var logLastBuildTime = function () {
    this.plugin('done', function (stats) {
        setTimeout(
            () => {
                console.log('\x1b[33m\x1b[1m', ('\n --- ATLAS LAST BUILD TIME: ---> ' + new Date().toLocaleString()));
            },
            100
        );
    });
};

module.exports = {
    mode: 'development',
    devtool: 'cheap-module-eval-source-map',
    performance: {
        hints: false
    },
    entry: {
        'polyfills': './wwwroot/app/polyfills.ts',
        'vendor': './wwwroot/app/vendor.ts',
        'app': './wwwroot/app/main.ts',
        'bundle.min': [
            './wwwroot/assets/bootstrap/less/bootstrap.less',
            './wwwroot/assets/global/plugins/simple-line-icons/simple-line-icons.min.css',
            './node_modules/devextreme/dist/css/dx.common.css',
            './wwwroot/assets/metronic/vendors/base/vendors.bundle.css',
            './wwwroot/assets/global/plugins/font-awesome/css/font-awesome.min.css',
            './wwwroot/assets/metronic/sass/demo/default/style.css',
            './node_modules/summernote/dist/summernote.css',
            './node_modules/@devexpress/analytics-core/dist/css/dx-analytics.common.css',
            './node_modules/@devexpress/analytics-core/dist/css/dx-analytics.light.css',
            './node_modules/@devexpress/analytics-core/dist/css/dx-querybuilder.css',
            './node_modules/devexpress-reporting/dist/css/dx-webdocumentviewer.css',
            './node_modules/devexpress-reporting/dist/css/dx-reportdesigner.css',
            './node_modules/devexpress-dashboard/dist/css/dx-dashboard.light.css',

            './node_modules/prism-themes/themes/prism-vs.css',
            './wwwroot/assets/imageannotation/css/annotate.css',
        ],
        'theme': [
            './wwwroot/assets/devextreme/css/theme.css'
        ],
        'override': [
            './wwwroot/Content/Site.css'
        ]
    },
    output: {
        path: __dirname + '/wwwroot/dist',
        filename: 'bundles/[name].[hash].bundle.js',
        chunkFilename: 'bundles/[name].[hash].chunk.js',
        publicPath: '/',
        pathinfo: false
    },
    externals: {
        // This mean that require('jquery') will refer to global var jQuery
        'jquery': 'jQuery'
    },
    resolve: {
        alias: {
            app: path.resolve(__dirname, 'wwwroot', 'app'),
            Fw: path.resolve(__dirname, 'wwwroot', 'app', 'Fw'),
            NebulaClient: path.resolve(__dirname, 'wwwroot', 'app', 'NebulaClient'),
            System: path.resolve(__dirname, 'wwwroot', 'app', 'System'),
            AppModules: path.resolve(__dirname, 'wwwroot', 'app'),
            Modules: path.resolve(__dirname, 'Modules'),
            ExternalService: path.resolve(__dirname, 'wwwroot', 'app', 'NebulaClient', 'Services', 'External'),
            ObjectClassService: path.resolve(__dirname, 'wwwroot', 'app', 'NebulaClient', 'Services', 'ObjectService'),
            globalscripts: path.resolve(__dirname, 'wwwroot', 'assets', 'global', 'scripts'),
            tslib: path.resolve(__dirname, 'node_modules', 'tslib', 'tslib.js'),
            devextreme: path.resolve(__dirname, 'node_modules', 'devextreme'),
            'file-saver': path.resolve(__dirname, 'node_modules/file-saver/FileSaver.min.js'),
            globalize$: path.resolve(__dirname, 'node_modules/globalize/dist/globalize.js'),
            globalize: path.resolve(__dirname, 'node_modules/globalize/dist/globalize'),
            webcam: path.resolve(__dirname, 'node_modules/webcamjs/webcam.min.js'),
            quill: path.resolve(__dirname, 'node_modules/quill/dist/quill.min.js'),
            screenfull: path.resolve(__dirname, 'node_modules/screenfull/dist/screenfull.js'),
            'object-hash': path.resolve(__dirname, 'node_modules/object-hash/dist/object_hash.js'),
            cldr$: path.resolve(__dirname, 'node_modules/cldrjs/dist/cldr.js'),
            cldr: path.resolve(__dirname, 'node_modules/cldrjs/dist/cldr'),
            '@aspnet/signalr': path.resolve('node_modules/@aspnet/signalr/dist/browser/signalr.js')
        },
        extensions: ['.ts', '.js', '.json', '.css', '.scss', '.html'],
        modules: ['app', 'Modules', 'node_modules']
    },
    devServer: {
        open: 'Chrome',
        stats: 'errors-only',
        historyApiFallback: true,
        watchContentBase: true,
        contentBase: path.join(__dirname, '/wwwroot/app/'),
        watchOptions: {
            ignored: ['**/*.cs', 'node_modules', 'wwwroot/assets'],
            aggregateTimeout: 300,
            poll: 2500
        }
    },
    module: {
        rules: [
            {
                test: /\.ts$/,
                use: [
                    { loader: 'cache-loader' },
                    {
                        loader: 'thread-loader',
                        options: {
                            // there should be 1 cpu for the fork-ts-checker-webpack-plugin
                            workers: require('os').cpus().length - 1
                        }
                    },
                    {
                        loader: 'ng-router-loader'
                    },
                    {
                        loader: 'ts-loader',
                        options: {
                            //experimentalWatchApi: true,
                            transpileOnly: true,
                            happyPackMode: true
                        }
                    },
                    {
                        loader: 'angular2-template-loader'
                    }
                ],
                exclude: [/\.(spec|e2e)\.ts$/]
            },
            /* Embed files. */
            {
                test: /\.(html)$/,
                loader: 'raw-loader',
                exclude: /\.async\.(html)$/
            },
            /* Async loading. */
            {
                test: /\.async\.(html)$/,
                loaders: ['file?name=[name].[hash].[ext]', 'extract']
            },
            {
                test: /\.(png|jpg|gif|woff|woff2|ttf|svg|eot)$/,
                loader: 'file-loader?name=assets/[name]-[hash:6].[ext]'
            },
            {
                test: /favicon.ico$/,
                loader: 'file-loader?name=/[name].[ext]'
            },
            //{
            //    test: /\.json$/,
            //    use: 'json-loader'
            //}
            {
                test: /\.(css)$/,
                oneOf: [
                    {
                        resourceQuery: /inline/,
                        use: [
                            "raw-loader",
                        ],
                    },
                    {
                        use: [
                            {
                                loader: MiniCssExtractPlugin.loader,
                                options: {
                                    // you can specify a publicPath here
                                    // by default it use publicPath in webpackOptions.output
                                    publicPath: '../'
                                }
                            },
                            {
                                loader: 'css-loader'
                            }
                        ]
                    }
                ],
            },
            {
                test: /\.(less)$/,
                use: [
                    MiniCssExtractPlugin.loader,
                    "css-loader",
                    "less-loader"
                ]
            },
            {
                test: /\.scss$/,
                use: [
                    "raw-loader",
                    "sass-loader" // compiles Sass to CSS, using Node Sass by default
                ]
            }
        ],
        exprContextCritical: false
    },
    optimization: {
        minimize: false,
        removeAvailableModules: true,
        removeEmptyChunks: false,
        splitChunks: {
            chunks: 'async',
            minSize: 30000,
            maxSize: 0,
            minChunks: 1,
            maxAsyncRequests: 5,
            maxInitialRequests: 3,
            automaticNameDelimiter: '~',
            name: true,
            cacheGroups: {
                vendors: {
                    test: /[\\/]node_modules[\\/]/,
                    priority: -10
                },
                default: {
                    minChunks: 2,
                    priority: -20,
                    reuseExistingChunk: true
                }
            }
        }
    },
    plugins: [
        new webpack.ProvidePlugin({
            $: 'jquery',
            jQuery: 'jquery',
            'window.jQuery': 'jquery',
            '_': 'lodash'
        }),
        new HtmlWebpackPlugin({
            filename: 'index.html',
            inject: 'body',
            template: 'wwwroot/app/index.html'
        }),
        new webpack.DefinePlugin({
            'require.specified': 'require.resolve'
        }),
        new CopyWebpackPlugin([
            { from: './wwwroot/assets', to: 'assets' },
            { from: './wwwroot/Content', to: 'Content' },
            { from: './wwwroot/help', to: 'help' },
            { from: './wwwroot/js', to: 'js' }
        ]),
        new MiniCssExtractPlugin({
            filename: "[name].[hash].css"
        }),
        isHotOnly && new webpack.HotModuleReplacementPlugin(),
        logLastBuildTime,
        new webpack.IgnorePlugin(/vertx/),
        new webpack.IgnorePlugin(/NodeHttpClient/),
        new webpack.IgnorePlugin(/eventsource/),
        new ForkTsCheckerWebpackPlugin({ checkSyntacticErrors: true })
    ].filter(Boolean)
};
