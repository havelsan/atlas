del /f package-lock.json
del /f yarn.lock
rmdir node_modules /S /q
set NODE_TLS_REJECT_UNAUTHORIZED=0
yarn config set "strict-ssl" false && yarn install
copy "./angular_compiler_plugin.js" "./node_modules/@ngtools/webpack/src/angular_compiler_plugin.js"
copy "./summernote.js" "./node_modules/summernote/dist/summernote.js"
pause