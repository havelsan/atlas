var gulp = require("gulp");
var sass = require('gulp-sass');
var rimraf = require("rimraf");

var paths = {
    //runDistApp: "../dist/wwwroot/app",
    //runDistModules: "../dist/Modules",
    //webrootAppHtml: "./wwwroot/app/**/*.html",
    //modulesHtml: "./modules/**/*.html",
    //webroot: "./wwwroot/",
    //modules: "./Modules/**/*.ts",
    distSource: "./wwwroot/dist/**/*",
    publishFolder: "c:/publish/wwwroot",
    //publishModulesFolder: "c:/publish/Modules",
    sassPath: "./wwwroot/assets/metronic/sass/demo/default/"
};

gulp.task("clean:dist", function (cb) {
    return rimraf(paths.publishFolder + "/dist", cb);
});

gulp.task("copy:dist", function (cb) {
    return gulp.src([paths.distSource]).pipe(gulp.dest(paths.publishFolder));
});

//gulp.task("copy:modulests", function (cb) {
//    return gulp.src(paths.modules).pipe(gulp.dest(paths.publishModulesFolder));
//});
//gulp.task("copy:appTemplates", function (cb) {
//    return gulp.src([paths.webrootAppHtml]).pipe(gulp.dest(paths.runDistApp));
//});
//gulp.task("copy:moduleTemplates", function (cb) {
//    return gulp.src([paths.modulesHtml]).pipe(gulp.dest(paths.runDistModules));
//});

gulp.task('copy:metronic', function () {
    return gulp.src(paths.sassPath + "/style.scss")
        .pipe(sass().on('error', sass.logError))
        .pipe(gulp.dest(paths.sassPath));
});

gulp.task("copy:templates", ["copy:metronic"]);