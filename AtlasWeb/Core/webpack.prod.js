const path = require('path');
const webpack = require('webpack');
const HtmlWebpackPlugin = require('html-webpack-plugin');
const CopyWebpackPlugin = require('copy-webpack-plugin');
const CleanWebpackPlugin = require('clean-webpack-plugin');
const ForkTsCheckerWebpackPlugin = require('fork-ts-checker-webpack-plugin');
const MiniCssExtractPlugin = require("mini-css-extract-plugin");
const TerserPlugin = require('terser-webpack-plugin');

console.log('@@@@@@@@@ USING PRODUCTION @@@@@@@@@@@@@@@');

module.exports = {
    mode: 'production',
    devtool: 'none',
    //devtool: 'cheap-module-source-map',
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
            './node_modules/summernote/dist/summernote.css'
        ],
        'themecss': [
            './wwwroot/assets/devextreme/css/theme.css'
        ],
        'sitecss': [
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
    module: {
        rules: [
            {
                test: /\.ts$/,
                use: [
                    {
                        loader: 'ng-router-loader'
                    },
                    {
                        loader: 'ts-loader',
                        options: {
                            //experimentalWatchApi: true,
                            transpileOnly: true
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
        minimizer: [
            new TerserPlugin({
                cache: true,
                parallel: true,
                terserOptions: {
                    ecma: undefined,
                    warnings: false,
                    parse: {},
                    compress: {},
                    mangle: true, // Note `mangle.properties` is `false` by default.
                    module: true,
                    output: null,
                    toplevel: true,
                    nameCache: null,
                    ie8: false,
                    keep_classnames: true,
                    keep_fnames: true,
                    safari10: false,
                },
            }),
        ],
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
        new CleanWebpackPlugin(['wwwroot/dist']),
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
        new webpack.NormalModuleReplacementPlugin(/\.\/environment\.dev/, './environment.prod'),
        new CopyWebpackPlugin([
            { from: './wwwroot/assets', to: 'assets' },
            { from: './wwwroot/Content', to: 'Content' },
            { from: './wwwroot/help', to: 'help' },
            { from: './wwwroot/js', to: 'js' }
        ]),
        new MiniCssExtractPlugin({
            filename: "[name].[hash].css"
        }),
        new webpack.IgnorePlugin(/vertx/),
        new webpack.IgnorePlugin(/NodeHttpClient/),
        new webpack.IgnorePlugin(/eventsource/),
        new ForkTsCheckerWebpackPlugin({ checkSyntacticErrors: true })
    ]
};
