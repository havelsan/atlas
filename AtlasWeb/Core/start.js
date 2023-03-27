const terminalImage = require('terminal-image');

console.log('\x1b[32m\x1b[1m', '###### USING DEVELOPMENT #####');

terminalImage.file('wwwroot/Content/ATLASDEV.jpg').then(x => {
    console.log('\n');
    console.log(x);

});