const gulp = require('gulp');
const shell = require('gulp-shell');
const watch = require('gulp-watch');

gulp.task('build', shell.task(['npm run build']));

gulp.task('copy', () => {
  return gulp.src('./dist/**/*')
    .pipe(gulp.dest('../wwwroot/dist'));
});

gulp.task('watch', () => {
  watch('./src/**/*', gulp.series('build', 'copy'));
});

gulp.task('default', gulp.series('build', 'copy', 'watch'));
