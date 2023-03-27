const path = require('path');

module.exports = (cfg) => {
    cfg.resolve.alias['app'] = path.resolve(__dirname, 'wwwroot', 'app');

    var terserPluginIndex = cfg.optimization.minimizer.findIndex(x => x.constructor.name == 'TerserPlugin');
    if(terserPluginIndex > -1){
        var terserPlugin = cfg.optimization.minimizer[terserPluginIndex];
        terserPlugin.options.terserOptions.keep_classnames = true;
        terserPlugin.options.terserOptions.keep_fnames = true;
        terserPlugin.options.terserOptions.ie8 = false;
        terserPlugin.options.terserOptions.safari10 = false;
    }


    return cfg;
};