'use strict';
require.config({
    baseUrl: 'bower_components',
    paths: {
        app: '../app',
        angular: 'angular/angular',
        'ui-router': 'angular-ui-router/release/angular-ui-router',
        'moment': 'moment/moment',
        'angular-moment': 'angular-moment/angular-moment'
    },
    shim: {
        angular: {
            exports: 'angular'
        },
        'ui-router': {
            deps: ['angular']
        },
        'angular-moment': {
            deps: ['moment']
        }
    }
});
//# sourceMappingURL=app.config.js.map