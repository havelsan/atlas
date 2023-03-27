var path = require('path');
var webpack = require('webpack');
var HtmlWebpackPlugin = require('html-webpack-plugin');
var CopyWebpackPlugin = require('copy-webpack-plugin');
var CleanWebpackPlugin = require('clean-webpack-plugin');
var GlobalizePlugin = require("globalize-webpack-plugin");
const { CheckerPlugin, TsConfigPathsPlugin } = require('awesome-typescript-loader');
const CircularDependencyPlugin = require('circular-dependency-plugin');
var helpers = require('./webpack.helpers');

console.log('@@@@@@@@@ USING PRODUCTION WITH AOT @@@@@@@@@@@@@@@');

module.exports = {

    performance: {
        hints: false
    },
    entry: {
        'polyfills': './wwwroot/app/polyfills.ts',
        'vendor': './wwwroot/app/vendor.ts',
        'app': './wwwroot/app/main.ts'
    },

    output: {
        path: __dirname + '/wwwroot/dist',
        filename: 'bundles/[name].bundle.js',
        chunkFilename: 'bundles/[id].chunk.js',
        publicPath: '/'
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
        },
        extensions: ['.ts', '.js', '.json', '.css', '.scss', '.html'],
        modules: ['app', 'Modules', 'node_modules']
    },

    devServer: {
        historyApiFallback: true,
        contentBase: path.join(__dirname, '/wwwroot/'),
        watchOptions: {
            aggregateTimeout: 300,
            poll: 1000
        }
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
                        loader: 'awesome-typescript-loader'
                    }
                ],
                exclude: [/\.(spec|e2e)\.ts$/]
            },
            {
                test: /\.(png|jpg|gif|woff|woff2|ttf|svg|eot)$/,
                loader: 'file-loader?name=assets/[name]-[hash:6].[ext]'
            },
            {
                test: /favicon.ico$/,
                loader: 'file-loader?name=/[name].[ext]'
            },
            {
                test: /\.css$/,
                loader: 'style-loader!css-loader'
            }
        ],
        exprContextCritical: false
    },
    plugins: [
        new webpack.ProgressPlugin(),
        new CheckerPlugin(),
        new webpack.optimize.CommonsChunkPlugin({ name: ['vendor', 'polyfills'] }),
        new GlobalizePlugin({
            production: true,
            developmentLocale: 'tr',
            supportedLocales: ['tr', 'en'],
            messages: 'wwwroot/app/localization/[locale].json',
            output: 'i18n/[locale].[hash].js'
        }),
        new webpack.ProvidePlugin({
            $: 'jquery',
            jQuery: 'jquery',
            'window.jQuery': 'jquery',
            '_': 'lodash'
        }),
        new webpack.optimize.UglifyJsPlugin({
          sourceMap: false,
          mangle: false,
          beautify: false,
          compress: true
        }), 
        new CleanWebpackPlugin(['wwwroot/dist']),
        new HtmlWebpackPlugin({
            filename: 'index.html',
            inject: 'body',
            template: 'wwwroot/app/index.html'
        }),
        new CopyWebpackPlugin([
            { from: './wwwroot/images/*.*', to: 'assets/', flatten: true }
        ])
    ]
};

