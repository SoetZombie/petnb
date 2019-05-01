/// <binding AfterBuild='sass' />
'use strict';

var gulp = require('gulp');
var sass = require('gulp-sass');

sass.compiler = require('node-sass');

gulp.task('sass', function () {
    return gulp.src('./wwwroot/**/*.scss')
        .pipe(sass().on('error', sass.logError))
        .pipe(gulp.dest('./wwwroot/'));
});

gulp.task('sass:watch', function () {
    gulp.watch('./wwwroot/**/*.scss', ['sass']);
});