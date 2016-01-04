﻿'use strict';
declare var require;
require.config({

    baseUrl: 'bower_components',

    paths: {
        app: '../app',

        angular: 'angular/angular',
        'ui-router': 'angular-ui-router/release/angular-ui-router'
    },

    shim: {
        angular: {
            exports: 'angular'
        },
        'ui-router': {
            deps: ['angular']
        }
    }
});