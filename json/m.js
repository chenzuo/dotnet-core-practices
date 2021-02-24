'use strict';

import Ajv from 'ajv';

$(document).ready(function(){
    $(".btn").click(function(){
        var ajv = Ajv({allErrors: true});
        var valid = ajv.validate(userSchema, userData);
        if (valid) {
          console.log('User data is valid');
        } else {
          console.log('User data is INVALID!');
          console.log(ajv.errors);
        }
    });
  });
  